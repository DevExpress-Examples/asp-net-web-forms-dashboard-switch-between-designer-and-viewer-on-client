using System;
using System.Web.Hosting;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;

namespace Dashboard_WebDesigner_2010 {
    public class Global : System.Web.HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {
            #region #DashboardStorage
            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
            DashboardService.SetDashboardStorage(dashboardFileStorage);
            #endregion #DashboardStorage

            #region #DataSourceStorage
            XmlFileConnectionParameters xmlParams = new XmlFileConnectionParameters();
            xmlParams.FileName = Server.MapPath("App_Data/DashboardEnergyStatictics.xml");
            DashboardSqlDataSource xmlDataSource = new DashboardSqlDataSource("XML Data Source", xmlParams);
            SelectQuery countriesQuery = SelectQueryFluentBuilder
                .AddTable("Countries")
                .SelectColumns("Country", "Latitude", "Longitude", "Year", "EnergyType", "Production", "Import")
                .Build("Countries");
            xmlDataSource.Queries.Add(countriesQuery);

            OlapConnectionParameters olapParams = new OlapConnectionParameters();
            olapParams.ConnectionString = @"provider=MSOLAP;
                                  data source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;
                                  initial catalog=Adventure Works DW Standard Edition;
                                  cube name=Adventure Works;";
            DashboardOlapDataSource olapDataSource = new DashboardOlapDataSource("OLAP Data Source", olapParams);

            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();
            dataSourceStorage.RegisterDataSource("xmlDataSource1", xmlDataSource.SaveToXml());
            dataSourceStorage.RegisterDataSource("olapDataSource1", olapDataSource.SaveToXml());
            DashboardService.SetDataSourceStorage(dataSourceStorage);
            #endregion #DataSourceStorage

            DashboardService.DataApi.ConfigureDataConnection += DataApi_ConfigureDataConnection;
        }

        void DataApi_ConfigureDataConnection(object sender, ServiceConfigureDataConnectionEventArgs e) {
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