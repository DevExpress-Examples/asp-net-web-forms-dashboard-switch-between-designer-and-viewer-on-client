<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128580166/20.1.7%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T362490)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Dashboard for Web Forms - How to Switch between Designer and Viewer Modes

This example shows how to switch between the [Web Dashboard](https://docs.devexpress.com/Dashboard/115955/web-dashboard)'s working modes on the [client-side](https://docs.devexpress.com/Dashboard/116302/web-dashboard/aspnet-web-forms-dashboard-control/client-side-api-overview).

![](web-dashboard.png)

- The [ASPxDashboard.ClientInstanceName](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.ASPxDashboard.ClientInstanceName) property identifies the control's client name. The [ASPxClientDashboard.GetDashboardControl](https://docs.devexpress.com/Dashboard/js-DevExpress.Dashboard.Web.WebForms.ASPxClientDashboard?p=netframework#js_aspxclientdashboard_getdashboardcontrol) method is used to access the [DashboardControl](https://docs.devexpress.com/Dashboard/116302/web-dashboard/aspnet-web-forms-dashboard-control/client-side-api-overview) API. 
- The [DashboardControl.isDesignMode](https://docs.devexpress.com/Dashboard/js-DevExpress.Dashboard.DashboardControl#js_devexpress_dashboard_dashboardcontrol_isdesignmode) method checks whether the Web Dashboard works in designer mode.
- The [DashboardControl.switchToDesigner](https://docs.devexpress.com/Dashboard/js-DevExpress.Dashboard.DashboardControl?p=netframework#js_devexpress_dashboard_dashboardcontrol_switchtodesigner) and [DashboardControl.switchToViewer](https://docs.devexpress.com/Dashboard/js-DevExpress.Dashboard.DashboardControl?p=netframework#js_devexpress_dashboard_dashboardcontrol_switchtoviewer) methods are used to switch between modes.

## Files to Look At

* [WebForm1.aspx](./CS/Dashboard_WebDashboard_2010/WebForm1.aspx) (VB: [WebForm1.aspx](./VB/Dashboard_WebDashboard_2010/WebForm1.aspx))
* [custom-script.js](./CS/Dashboard_WebDashboard_2010/Scripts/custom-script.js)

## Documentation

- [Client-Side API Overview for ASP.NET Web Forms Dashboard](https://docs.devexpress.com/Dashboard/116302/web-dashboard/aspnet-web-forms-dashboard-control/client-side-api-overview)
- [Web Dashboard Technical Overview](https://docs.devexpress.com/Dashboard/119283/web-dashboard/general-information/web-dashboard-technical-overview?p=netframework)

## More Examples

- [Dashboard for MVC - How to Switch between Designer and Viewer Modes](https://github.com/DevExpress-Examples/asp-net-mvc-dashboard-switch-between-designer-and-viewer-on-client)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-dashboard-switch-between-designer-and-viewer-on-client&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-dashboard-switch-between-designer-and-viewer-on-client&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
