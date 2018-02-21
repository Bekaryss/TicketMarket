using DemoApp.Helpers;
using DemoApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace DemoApp
{
    class Program
    {
        public static SaveHelper sh = new SaveHelper();
        static void Main(string[] args)
        {
            string s = sh.GetJson(SaveHelper.Type.ServiceCategory);
            if(s != null)
            {
                sh.ServiceCategoryList = JsonConvert.DeserializeObject<List<ServiceCategory>>(s);
            }
            sh.ServiceCategoryCRUD();
            
            Console.ReadKey();
        }
    }
}
