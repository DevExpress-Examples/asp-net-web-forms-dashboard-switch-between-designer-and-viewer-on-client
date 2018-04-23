Imports System
Imports System.Web.Hosting
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql

Namespace Dashboard_WebDesigner_2010
    Public Class [Global]
        Inherits System.Web.HttpApplication

        Protected Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
            '            #Region "#DashboardStorage"
            Dim dashboardFileStorage As New DashboardFileStorage("~/App_Data/Dashboards")
            DashboardService.SetDashboardStorage(dashboardFileStorage)
            '            #End Region ' #DashboardStorage

            '            #Region "#DataSourceStorage"
            Dim xmlParams As New XmlFileConnectionParameters()
            xmlParams.FileName = Server.MapPath("App_Data/DashboardEnergyStatictics.xml")
            Dim xmlDataSource As New DashboardSqlDataSource("XML Data Source", xmlParams)
            Dim countriesQuery As SelectQuery = SelectQueryFluentBuilder.AddTable("Countries").
                SelectColumns("Country", "Latitude", "Longitude", "Year", "EnergyType", _
                              "Production", "Import").Build("Countries")
            xmlDataSource.Queries.Add(countriesQuery)

            Dim olapParams As New OlapConnectionParameters()
            olapParams.ConnectionString = "provider=MSOLAP;" _
                                & ControlChars.CrLf & _
                                "data source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;" _
                                & ControlChars.CrLf & _
                                "initial catalog=Adventure Works DW Standard Edition;" _
                                & ControlChars.CrLf & _
                                "cube name=Adventure Works;"
            Dim olapDataSource As New DashboardOlapDataSource("OLAP Data Source", olapParams)

            Dim dataSourceStorage As New DataSourceInMemoryStorage()
            dataSourceStorage.RegisterDataSource("xmlDataSource1", xmlDataSource.SaveToXml())
            dataSourceStorage.RegisterDataSource("olapDataSource1", olapDataSource.SaveToXml())
            DashboardService.SetDataSourceStorage(dataSourceStorage)
            '            #End Region ' #DataSourceStorage

            AddHandler DashboardService.DataApi.ConfigureDataConnection, AddressOf DataApi_ConfigureDataConnection
        End Sub

        Private Sub DataApi_ConfigureDataConnection(ByVal sender As Object, _
                                                    ByVal e As ServiceConfigureDataConnectionEventArgs)
            If e.DataSourceName = "XML Data Source" Then
                Dim parameters As XmlFileConnectionParameters = CType(e.ConnectionParameters, XmlFileConnectionParameters)
                Dim databasePath As String = HostingEnvironment.MapPath("~/App_Data/DashboardEnergyStatictics.xml")
                parameters.FileName = databasePath
            End If
        End Sub

        Protected Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)

        End Sub
    End Class
End Namespace