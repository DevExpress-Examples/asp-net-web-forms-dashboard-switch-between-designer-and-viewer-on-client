<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Dashboard_WebDashboard_2010.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        html, body, form {  
            height: 100%;  
            margin: 0;  
            padding: 0;  
            overflow: hidden;  
        }
    </style>
    <script type="text/javascript">
        function onClick(s, e) {
            var workingMode = webDashboard.GetWorkingMode();

            if (workingMode == 'designer') {
                webDashboard.SwitchToViewer();
                button.SetText('Switch to Designer');
            }
            else {
                webDashboard.SwitchToDesigner();
                button.SetText('Switch to Viewer');
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Switch to Viewer" 
            ClientInstanceName="button" AutoPostBack="False">
            <ClientSideEvents Click="onClick" />
        </dx:ASPxButton>
        <dx:ASPxDashboard ID="ASPxDashboard1" runat="server" Height="100%" ClientInstanceName="webDashboard" 
            OnConfigureDataConnection="ASPxDashboard1_ConfigureDataConnection">
        </dx:ASPxDashboard>
    </form>
</body>
</html>