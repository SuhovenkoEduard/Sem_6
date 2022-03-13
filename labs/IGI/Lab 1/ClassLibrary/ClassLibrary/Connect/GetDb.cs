using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Connect
{
    class GetDb
    {
        private readonly static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"D:\\Projects\\University\\Semester 6\\Sem_6\\IGI\\Lab 1\\Database_Lab1.mdb\"";

        private static readonly OleDbConnection myConnection = new OleDbConnection(connectString);

        static public OleDbConnection Connection => myConnection;
    }
}
