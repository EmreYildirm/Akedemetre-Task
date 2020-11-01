using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Task_Cevap
{
    public class Program
    {
        public static DataTable dt;
        public static void Main(string[] args)
        {
            CreateDataTable();
            CreateHostBuilder(args).Build().Run();

        }
        public static void CreateDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("PersonId", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Mail", typeof(string));
            dt.Rows.Add(1, "Test", "Test", "Test", "Test");
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
