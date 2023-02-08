<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteCapacitacion.aspx.cs" Inherits="SIGOFCv3.Areas.Capacitacion.Reporte.ReporteCapacitacion" %>
<%@Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%--<asp:ScriptManager runat="server" />--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <rsweb:ReportViewer  SizeToReportContent="true" ID="rv_capacitacion" runat="server"></rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
