<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="UnboundRowStateImage._Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v8.2, Version=8.2.8.0, Culture=neutral, PublicKeyToken=9B171C9FD64DA1D1"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.2, Version=8.2.8.0, Culture=neutral, PublicKeyToken=9B171C9FD64DA1D1"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" 
			ClientInstanceName="grid"
			OnHtmlRowCreated="ASPxGridView1_HtmlRowCreated" OnCustomCallback="ASPxGridView1_CustomCallback">
			<Columns>
				<dxwgv:GridViewDataTextColumn Caption="Action" Name="colAction" VisibleIndex="0">
					<DataItemTemplate>
						<dxe:ASPxButton ID="btnAction" runat="server" AutoPostBack="False" ClientInstanceName="btnAction" >
						</dxe:ASPxButton>
					</DataItemTemplate>
				</dxwgv:GridViewDataTextColumn>
				<dxwgv:GridViewDataTextColumn FieldName="Subject" VisibleIndex="1">
				</dxwgv:GridViewDataTextColumn>
				<dxwgv:GridViewDataDateColumn FieldName="DueOn" VisibleIndex="2">
					<PropertiesDateEdit DisplayFormatString="{0:t}">
					</PropertiesDateEdit>
				</dxwgv:GridViewDataDateColumn>
			</Columns>
		</dxwgv:ASPxGridView>
	</div>
	</form>
</body>
</html>
