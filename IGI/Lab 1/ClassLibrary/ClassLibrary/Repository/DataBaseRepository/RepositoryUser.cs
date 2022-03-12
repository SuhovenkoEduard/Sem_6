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
    public class RepositoryUser : Interfaces.IRepository<Entities.User>
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

        public void Insert(User entity)
        {
            GetDb.Connection.Open();

            string query = "insert into Users (ULogin, UPassword, URank) " +
                                    "values (@log, @pass, @rank)";

            OleDbCommand insert = new OleDbCommand(query, GetDb.Connection);
            insert.Parameters.AddWithValue("@log", entity.Login);
            insert.Parameters.AddWithValue("@pass", entity.Password);
            insert.Parameters.AddWithValue("@rank", entity.Rank);


            insert.ExecuteNonQuery();

            GetDb.Connection.Close();
            
        }

        public List<User> Search(string login)
        {
            try
            {
                GetDb.Connection.Open();

                List<User> lst = new List<User>();

                string query = "select * from Users where Login = @log";
                OleDbCommand select = new OleDbCommand(query, GetDb.Connection);
                select.Parameters.AddWithValue("@log", login);

                OleDbDataReader reader = select.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User obj = new User();
                        obj.Id = Convert.ToInt32(reader.GetValue(0));
                        obj.Login = reader.GetValue(1).ToString();
                        obj.Password = reader.GetValue(2).ToString();
                        obj.Rank = reader.GetValue(3).ToString();
                        lst.Add(obj);
                    }
                }

                reader.Close();
                return lst;
            }
            catch(Exception mes) { throw new Exception(mes.Message); }
            finally { GetDb.Connection.Close(); }
        }

        public List<User> SelectAll()
        {
            GetDb.Connection.Open();

            List<User> lst = new List<User>();

            string query = "select * from Users";
            OleDbCommand select = new OleDbCommand(query, GetDb.Connection);
            OleDbDataReader reader = select.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User obj = new User();
                    obj.Id = Convert.ToInt32(reader.GetValue(0));
                    obj.Login = reader.GetValue(1).ToString();
                    obj.Password = reader.GetValue(2).ToString();
                    obj.Rank = reader.GetValue(3).ToString();
                    lst.Add(obj);
                }
            }

            reader.Close();
            GetDb.Connection.Close();
            return lst;
        }
    }
}
