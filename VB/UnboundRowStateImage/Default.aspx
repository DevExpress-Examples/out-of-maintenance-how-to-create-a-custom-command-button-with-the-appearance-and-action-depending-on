<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="UnboundRowStateImage._Default" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxwgv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="ID"  OnDataBinding="ASPxGridView1_DataBinding"
            ClientInstanceName="grid"
            OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared" OnCustomCallback="ASPxGridView1_CustomCallback">
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