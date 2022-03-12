using ClassLibrary.Connect;
using ClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repository
{
    public class RepositoryStore : Interfaces.IRepository<Store>
    {
        public void Delete(int id)
        {
            GetDb.Connection.Open();

            string query = "delete from Store where Id = @id";
            OleDbCommand delete = new OleDbCommand(query, GetDb.Connection);
            delete.Parameters.AddWithValue("@id", id);

            delete.ExecuteNonQuery();

            GetDb.Connection.Close();
        }

        public void Insert(Store entity)
        {
            try
            {
                GetDb.Connection.Open();

                string query = "INSERT INTO Store (NameTovar, Cost, MyCount, ClientId) " +
                    "VALUES (@nt, @cost, @count, @cId)";

                OleDbCommand insert = new OleDbCommand(query, GetDb.Connection);
                insert.Parameters.AddWithValue("@nt", entity.NameTovar);
                insert.Parameters.AddWithValue("@cost", entity.Cost);
                insert.Parameters.AddWithValue("@count", entity.Count);
                insert.Parameters.AddWithValue("@cId", entity.ClientId);


                insert.ExecuteNonQuery();

                GetDb.Connection.Close();
            }
            catch(Exception mes)
            {
                GetDb.Connection.Close();
                throw new Exception(mes.Message);
            }
        }

        public List<Store> Search(string nameTovar)
        {
            try
            {
                GetDb.Connection.Open();
                List<Store> stores = new List<Store>();

                string query = "select * from Store where NameTovar = @nt";

                OleDbCommand find = new OleDbCommand(query, GetDb.Connection);
                find.Parameters.AddWithValue("@nt", nameTovar);

                List<Store> lst = new List<Store>();

                OleDbDataReader reader = find.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Store obj = new Store();
                        obj.Id = Convert.ToInt32(reader.GetValue(0));
                        obj.NameTovar = reader.GetValue(1).ToString();
                        obj.Cost = Convert.ToInt32(reader.GetValue(2));
                        obj.Count = Convert.ToInt32(reader.GetValue(3));
                        obj.ClientId = Convert.ToInt32(reader.GetValue(4));
                        lst.Add(obj);
                    }
                }

                reader.Close();
                GetDb.Connection.Close();
                return lst;
            }
            catch (Exception mes)
            {
                GetDb.Connection.Close();
                throw new Exception(mes.Message);
            }
        }

        public List<Store> SelectAll()
        {
            GetDb.Connection.Open();

            List<Store> lst = new List<Store>();

            string query = "select * from Store";
            OleDbCommand select = new OleDbCommand(query, GetDb.Connection);
            OleDbDataReader reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Store obj = new Store();
                    obj.Id = Convert.ToInt32(reader.GetValue(0));
                    obj.NameTovar = reader.GetValue(1).ToString();
                    obj.Cost = Convert.ToInt32(reader.GetValue(2));
                    obj.Count = Convert.ToInt32(reader.GetValue(3));
                    obj.ClientId = Convert.ToInt32(reader.GetValue(4));
                    lst.Add(obj);
                }
            }

            reader.Close();
            GetDb.Connection.Close();
            return lst;
        }
    }
}
