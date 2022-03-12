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
    public class RepositoryClient : Interfaces.IRepository<Entities.Client>
    {
        public void Delete(int id)
        {
            try
            {
                GetDb.Connection.Open();

                string query = "delete from Clients where Id = @id";
                OleDbCommand delete = new OleDbCommand(query, GetDb.Connection);
                delete.Parameters.AddWithValue("@id", id);

                delete.ExecuteNonQuery();

                GetDb.Connection.Close();
            }
            catch (Exception mes)
            {
                GetDb.Connection.Close();
                throw new Exception(mes.Message);
            }
        }

        public void Insert(Client entity)
        {
            GetDb.Connection.Open();

            string query = "INSERT INTO Clients (ClientName, Surname, UserId, Age) " +
                "VALUES (@cn, @sn, @uId, @age)";

            OleDbCommand insert = new OleDbCommand(query, GetDb.Connection);
            insert.Parameters.AddWithValue("@cn", entity.ClientName);
            insert.Parameters.AddWithValue("@sn", entity.Surname);
            insert.Parameters.AddWithValue("@uId", entity.UserId);
            insert.Parameters.AddWithValue("@age", entity.Age);
            GetDb.Connection.Close();
        }

        public List<Client> Search(string clientName)
        {
            try
            {
                GetDb.Connection.Open();
                List<Client> clients = new List<Client>();

                string query = "select * from Clients where ClientName = @cn";

                OleDbCommand find = new OleDbCommand(query, GetDb.Connection);
                find.Parameters.AddWithValue("@cn", clientName);

                List<Client> lst = new List<Client>();

                OleDbDataReader reader = find.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Client client = new Client();
                        client.Id = Convert.ToInt32(reader.GetValue(0));
                        client.ClientName = reader.GetValue(1).ToString();
                        client.Surname = reader.GetValue(2).ToString();
                        client.UserId = Convert.ToInt32(reader.GetValue(3));
                        client.Age = Convert.ToInt32(reader.GetValue(4));
                        lst.Add(client);
                    }
                }

                return lst;
            }
            catch(Exception mes)
            {
                throw new Exception(mes.Message);
            }
            finally
            {
                GetDb.Connection.Close();
            }
        }

        public List<Client> SelectAll()
        {
            try
            {
                GetDb.Connection.Open();

                List<Client> lst = new List<Client>();

                string query = "select * from Clients";
                OleDbCommand select = new OleDbCommand(query, GetDb.Connection);
                OleDbDataReader reader = select.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Client client = new Client();
                        client.Id = Convert.ToInt32(reader.GetValue(0));
                        client.ClientName = reader.GetValue(1).ToString();
                        client.Surname = reader.GetValue(2).ToString();
                        client.UserId = Convert.ToInt32(reader.GetValue(3));
                        client.Age = Convert.ToInt32(reader.GetValue(4));
                        lst.Add(client);
                    }
                }

                reader.Close();
                return lst;
            }
            catch (Exception mes)
            {
                throw new Exception(mes.Message);
            }
            finally
            {
                GetDb.Connection.Close();
            }
        }
    }
}
