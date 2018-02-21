using DemoApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DemoApp.Helpers
{
    public class SaveHelper
    {
        public List<ServiceCategory> ServiceCategoryList = new List<ServiceCategory>();
        public enum Type
        {
            Service,
            Organization,
            ServiceCategory,
            Ticket,
            TicketDeteil
        }

        public void AddServiceCategory()
        {
            Console.WriteLine();
            Console.WriteLine("Create Service Category");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Description: ");
            string desc = Console.ReadLine();
            int id = ServiceCategoryList.Count + 1;
            ServiceCategoryList.Add(new ServiceCategory(id, name, desc));
        }
        public void EditServiceCategory(int number)
        {
            
            ServiceCategory current = ServiceCategoryList.Where(x => x.Id == number).FirstOrDefault();
            Console.WriteLine();
            Console.WriteLine("Edit Service Category Item");
            Console.WriteLine("Current Name: " + current.Name);
            string name = Console.ReadLine();
            Console.WriteLine("Current Description: " + current.Description);
            Console.WriteLine("Description: ");
            string desc = Console.ReadLine();
            foreach (var item in ServiceCategoryList)
            {
                if(item.Id == number)
                {
                    if(name != "" && desc != "")
                    {
                        item.Name = name;
                        item.Description = desc;
                    }
                }
            }
        }

        public void DeleteServiceCategory(int number)
        {
            List<ServiceCategory> newList = new List<ServiceCategory>();
            int n = 1;
            foreach (var item in ServiceCategoryList)
            {
                if (item.Id != number)
                {
                    item.Id = n;
                    newList.Add(item);
                    n++;
                }  
            }
            ServiceCategoryList = newList;
        }

        public void GetServiceCategoryList()
        {
            foreach (var item in ServiceCategoryList)
            {
                Console.WriteLine("Id: " + item.Id);
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Description: " + item.Description);
            }
        }

        public void ServiceCategoryCRUD()
        {
            bool crud = true;
            string json;
            int id;
            while (crud)
            {
                Console.WriteLine();
                Console.WriteLine("Create new Service Category enter - 1");
                Console.WriteLine("Edit Service Category enter - 2");
                Console.WriteLine("Delete Service Category enter - 3");
                Console.WriteLine("Exit enter - 4");
                Console.WriteLine();
                Console.WriteLine("******* Service Category List ******");
                GetServiceCategoryList();
                Console.WriteLine("************************************");
                Console.WriteLine();
                Console.WriteLine();
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        AddServiceCategory();
                        json = JsonConvert.SerializeObject(ServiceCategoryList);
                        Console.WriteLine(Save(json, Type.ServiceCategory));
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine();
                        Console.WriteLine("Enter Number: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        EditServiceCategory(id);
                        json = JsonConvert.SerializeObject(ServiceCategoryList);
                        Console.WriteLine(Save(json, Type.ServiceCategory));
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine();
                        Console.WriteLine("Enter Number: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        DeleteServiceCategory(id);
                        json = JsonConvert.SerializeObject(ServiceCategoryList);
                        Console.WriteLine(Save(json, Type.ServiceCategory));
                        break;
                    case ConsoleKey.D4:
                        crud = false;
                        break;
                }
            }
        }

        public bool Save(string json, Type type)
        {
            try
            {
                string path = type.ToString() + ".txt";

                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        tw.WriteLine(json);
                        tw.Close();
                    }
                }
                else if (File.Exists(path))
                {
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        tw.WriteLine(json);
                        tw.Close();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string GetJson(Type type)
        {
            try
            {
                using (StreamReader r = new StreamReader(Type.ServiceCategory.ToString() + ".txt"))
                {
                    string json = r.ReadToEnd();
                    return json;
                }
            }
            catch
            {
                return null;
            }

        }
    }
}
