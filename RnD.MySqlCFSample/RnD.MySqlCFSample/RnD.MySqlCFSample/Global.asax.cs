using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using RnD.MySqlCFSample.Models;
using System.Data.Entity.Infrastructure;

namespace RnD.MySqlCFSample
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            InitializeAndSeedDb();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        private static void InitializeAndSeedDb()
        {
            try
            {
                // Initializes and seeds the database.
                Database.SetInitializer(new DBInitializer());

                //MySql ConnectionString
                string connectionString = "server=localhost;user id=rasel;password=123456;database=ef_db;port=3306";

                //MySql ProviderName
                string providerName = "MySql.Data.MySqlClient";

                ////Sql
                //string connectionString = "Data Source=|DataDirectory|APP_DB.sdf";

                ////Sql
                //string providerName = "System.Data.SqlServerCe.4.0";

                //Need to Default Connection Factory
                //MySql Factory
                Database.DefaultConnectionFactory = new SqlCeConnectionFactory(providerName, "", connectionString); //by String


                using (var context = new AppDbContext(connectionString))
                {
                    //context.Database.Initialize(force: true);
                    context.Database.CreateIfNotExists();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}