Imports System
Imports System.Web.Hosting
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardCommon.Native.DashboardRestfulService
Imports DevExpress.DashboardWeb.Designer
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql

Namespace Dashboard_WebDesigner_2010
    Public Class [Global]
        Inherits System.Web.HttpApplication

        Protected Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
            Dim dashboardFileStorage As New DashboardFileStorage("~/App_Data/Dashboards")
            ASPxDashboardDesigner.Storage.SetDashboardStorage(dashboardFileStorage)

'            #Region "XML Data Source"
            Dim xmlParams As New XmlFileConnectionParameters()
            xmlParams.FileName = Server.MapPath("App_Data/DashboardEnergyStatictics.xml")
            Dim xmlDataSource As New DashboardSqlDataSource("XML Data Source", xmlParams)
            Dim countriesQuery As New TableQuery("Countries")
            countriesQuery.AddTable("Countries").SelectColumns("Country", "Latitude", "Longitude", "Year", _
                                                               "EnergyType", "Production", "Import")
            xmlDataSource.Queries.Add(countriesQuery)
'            #End Region

'            #Region "OLAP Data Source"
            Dim olapParams As New OlapConnectionParameters()
            olapParams.ConnectionString = "provider=MSOLAP;" _
                                & ControlChars.CrLf & _
                                "data source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;" _
                                & ControlChars.CrLf & _
                                "initial catalog=Adventure Works DW Standard Edition;" _
                                & ControlChars.CrLf & _
                                "cube name=Adventure Works;"
            Dim olapDataSource As New DashboardOlapDataSource("OLAP Data Source", olapParams)
'            #End Region

            Dim dataSourceStorage As New DataSourceInMemoryStorage()
            dataSourceStorage.RegisterDataSource("xmlDataSource1", xmlDataSource)
            dataSourceStorage.RegisterDataSource("olapDataSource1", olapDataSource)
            ASPxDashboardDesigner.Storage.SetDataSourceStorage(dataSourceStorage)
            AddHandler ASPxDashboardDesigner.Storage.ConfigureDataConnection, AddressOf Storage_ConfigureDataConnection
        End Sub

        Private Sub Storage_ConfigureDataConnection(ByVal sender As Object, _
                                                    ByVal e As ConfigureServiceDataConnectionEventArgs)
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