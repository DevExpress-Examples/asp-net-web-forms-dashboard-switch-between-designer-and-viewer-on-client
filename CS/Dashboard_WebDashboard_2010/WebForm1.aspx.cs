using System;
using System.Web.Hosting;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;

namespace Dashboard_WebDashboard_2010 {
    public partial class WebForm1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            #region #DashboardStorage
            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
            ASPxDashboard1.SetDashboardStorage(dashboardFileStorage); 
            #endregion #DashboardStorage

            #region #DataSourceStorage
            DashboardSqlDataSource sqlDataSource = new DashboardSqlDataSource("SQL Data Source", "sqlConnection");
            SelectQuery countriesQuery = SelectQueryFluentBuilder
                .AddTable("Countries")
                .SelectColumns("Country", "Latitude", "Longitude", "Year", "EnergyType", "Production", "Import")
                .Build("Countries");
            sqlDataSource.Queries.Add(countriesQuery);

            DashboardOlapDataSource olapDataSource = new DashboardOlapDataSource("OLAP Data Source", "olapConnection");

            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();
            dataSourceStorage.RegisterDataSource("sqlDataSource1", sqlDataSource.SaveToXml());
            dataSourceStorage.RegisterDataSource("olapDataSource1", olapDataSource.SaveToXml());
            ASPxDashboard1.SetDataSourceStorage(dataSourceStorage);
            #endregion #DataSourceStorage
        }

        protected void ASPxDashboard1_ConfigureDataConnection(object sender, ConfigureDataConnectionWebEventArgs e) {
            if (e.ConnectionName == "sqlConnection") {
                string databasePath = HostingEnvironment.MapPath("~/App_Data/DashboardEnergyStatictics.xml");
                e.ConnectionParameters = new XmlFileConnectionParameters(databasePath);
            }
        }
    }
}