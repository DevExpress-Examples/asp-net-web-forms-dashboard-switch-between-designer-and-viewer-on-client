using System;
using System.Web.Hosting;
using DevExpress.DashboardCommon;
using DevExpress.DashboardCommon.Native.DashboardRestfulService;
using DevExpress.DashboardWeb.Designer;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;

namespace Dashboard_WebDesigner_2010 {
    public class Global : System.Web.HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {
            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
            ASPxDashboardDesigner.Storage.SetDashboardStorage(dashboardFileStorage);

            #region XML Data Source
            XmlFileConnectionParameters xmlParams = new XmlFileConnectionParameters();
            xmlParams.FileName = Server.MapPath("App_Data/DashboardEnergyStatictics.xml");
            DashboardSqlDataSource xmlDataSource = new DashboardSqlDataSource("XML Data Source", xmlParams);
            TableQuery countriesQuery = new TableQuery("Countries");
            countriesQuery.AddTable("Countries").SelectColumns("Country", "Latitude", "Longitude", "Year", "EnergyType",
                "Production", "Import");
            xmlDataSource.Queries.Add(countriesQuery);
            #endregion

            #region OLAP Data Source
            OlapConnectionParameters olapParams = new OlapConnectionParameters();
            olapParams.ConnectionString = @"provider=MSOLAP;
                                  data source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;
                                  initial catalog=Adventure Works DW Standard Edition;
                                  cube name=Adventure Works;";
            DashboardOlapDataSource olapDataSource = new DashboardOlapDataSource("OLAP Data Source", olapParams);
            #endregion

            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();
            dataSourceStorage.RegisterDataSource("xmlDataSource1", xmlDataSource);
            dataSourceStorage.RegisterDataSource("olapDataSource1", olapDataSource);
            ASPxDashboardDesigner.Storage.SetDataSourceStorage(dataSourceStorage);
            ASPxDashboardDesigner.Storage.ConfigureDataConnection += 
                new ConfigureServiceDataConnectionEventHandler(Storage_ConfigureDataConnection);
        }

        void Storage_ConfigureDataConnection(object sender, ConfigureServiceDataConnectionEventArgs e) {
            if (e.DataSourceName == "XML Data Source") {
                XmlFileConnectionParameters parameters = (XmlFileConnectionParameters)e.ConnectionParameters;
                string databasePath = HostingEnvironment.MapPath("~/App_Data/DashboardEnergyStatictics.xml");
                parameters.FileName = databasePath;
            }
        }

        protected void Session_Start(object sender, EventArgs e) {

        }

        protected void Application_BeginRequest(object sender, EventArgs e) {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {

        }

        protected void Application_Error(object sender, EventArgs e) {

        }

        protected void Session_End(object sender, EventArgs e) {

        }

        protected void Application_End(object sender, EventArgs e) {

        }
    }
}