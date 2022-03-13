using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Entities;
using ClassLibrary.Interfaces;
using ClassLibrary.Repository;
using ClassLibrary.Repository.SCVsRepository;

namespace App
{
    internal class Program
    {
        static private bool choseDb = false;
        static void Main(string[] args)
        {
            Console.WriteLine("С какими данными вы хотите работать?");
            Console.WriteLine("1. CSV\n2. БД (Access)");
            int choose = int.Parse(Console.ReadLine());
            //while()
            //if (int.TryParse(Console.ReadLine(), out int res))
            //    choose = res;
            //else Console.WriteLine("Неправильный ввод");
            while (true)
            {
                switch (choose)
                {
                    case 1:
                        ChooseTableCSV();
                        break;
                    case 2:
                        choseDb = true;
                        ChooseTableDB();
                        break;
                }
            }
            Console.ReadKey();
        }

        private static void ChooseTableCSV()
        {
            Console.WriteLine("Выберите таблицу");
            Console.WriteLine("1. Store\n2. Users\n3. Clients");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    IRepository<Store> store = new CsvRepStore();
                    ChooseOptionStore(store);
                    break;
                case 2:
                    IRepository<User> user = new CsvRepUser();
                    ChooseOptionUser(user);
                    break;
                case 3:
                    IRepository<Client> client  = new CsvRepClient();
                    ChooseOptionClient(client);
                    break;
            }
        }

        private static void ChooseTableDB()
        {
            Console.WriteLine("Выберите таблицу");
            Console.WriteLine("1. Store\n2. Users\n3. Clients");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    IRepository<Store> store = new RepositoryStore();
                    ChooseOptionStore(store);
                    break;
                case 2:
                    IRepository<User> user = new RepositoryUser();
                    ChooseOptionUser(user);
                    break;
                case 3:
                    IRepository<Client> client = new RepositoryClient();
                    ChooseOptionClient(client);
                    break;
            }
        }

        private static void ChooseOptionStore(IRepository<Store> obj)
        {
            Console.WriteLine("1. SelectAll\n2. Search\n3. Delete\n4. Insert");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    List<Store> lst = obj.SelectAll();
                    lst.ForEach(x => Console.WriteLine(x.ToString()));
                    break;
                case 2:
                    Console.Write("Введите название товара: ");
                    string inp = Console.ReadLine();
                    List<Store> res = obj.Search(inp);
                    if (res.Count == 0)
                        Console.WriteLine("Данных нет");
                    else
                        res.ForEach(x => Console.WriteLine(x.ToString()));
                    break;
                case 3:
                    Console.Write("Введите id: ");
                    int id = int.Parse(Console.ReadLine());
                    obj.Delete(id);
                    obj.SelectAll().ForEach(x => Console.WriteLine(x.ToString()));
                    break;
                case 4:
                    Store data = new Store();
                    Console.Write("NameTovar: ");
                    data.NameTovar = Console.ReadLine();
                    Console.Write("Cost: ");
                    data.Cost = int.Parse(Console.ReadLine());
                    Console.Write("Count: ");
                    data.Count = int.Parse(Console.ReadLine());
                    Console.Write("client id: ");
                    data.ClientId = int.Parse(Console.ReadLine());
                    obj.Insert(data);
                    break;
            }
        }

        private static void ChooseOptionClient(IRepository<Client> obj)
        {
            Console.WriteLine("1. SelectAll\n2. Search\n3. Delete\n4. Insert");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    List<Client> lst = obj.SelectAll();
                    lst.ForEach(x => Console.WriteLine(x.ToString()));
                    break;
                case 2:
                    Console.Write("Введите clientName: ");
                    string inp = Console.ReadLine();
                    List<Client> res = obj.Search(inp);
                    if (res.Count == 0)
                        Console.WriteLine("Данных нет");
                    else
                        res.ForEach(x => Console.WriteLine(x.ToString()));
                    break;
                case 3:
                    Console.Write("Введите id: ");
                    int id = int.Parse(Console.ReadLine());
                    obj.Delete(id);
                    obj.SelectAll().ForEach(x => Console.WriteLine(x.ToString()));
                    break;
                case 4:
                    Client data = new Client();
                    Console.Write("ClientName: ");
                    data.ClientName = Console.ReadLine();
                    Console.Write("Surname: ");
                    data.Surname = Console.ReadLine();
                    Console.Write("UserId: ");
                    data.UserId = int.Parse(Console.ReadLine());
                    Console.Write("Age");
                    data.Age = int.Parse(Console.ReadLine());
                    obj.Insert(data);
                    break;
            }
        }

        private static void ChooseOptionUser(IRepository<User> obj)
        {
            Console.WriteLine("1. SelectAll\n2. Search\n3. Delete\n4. Insert");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    List<User> lst = obj.SelectAll();
                    lst.ForEach(x => Console.WriteLine(x.ToString()));
                    break;
                case 2:
                    Console.Write("Введите login: ");
                    string inp = Console.ReadLine();
                    List<User> res = obj.Search(inp);
                    if (res.Count == 0)
                        Console.WriteLine("Данных нет");
                    else
                        res.ForEach(x => Console.WriteLine(x.ToString()));
                    break;
                case 3:
                    Console.Write("Введите id: ");
                    int id = int.Parse(Console.ReadLine());
                    obj.Delete(id);
                    obj.SelectAll().ForEach(x => Console.WriteLine(x.ToString()));
                    break;
                case 4:
                    User data = new User();
                    if (choseDb == false)
                    {
                        Console.Write("id: ");
                        data.Id = int.Parse(Console.ReadLine());
                    }
                    Console.Write("Login: ");
                    data.Login = Console.ReadLine();
                    Console.Write("Password: ");
                    data.Password = Console.ReadLine();
                    Console.Write("Rank: ");
                    data.Rank = Console.ReadLine();
                    obj.Insert(data);
                    break;
            }
        }
    }
}
