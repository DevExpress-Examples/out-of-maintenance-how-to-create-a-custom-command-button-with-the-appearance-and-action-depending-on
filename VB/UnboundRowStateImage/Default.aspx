<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="UnboundRowStateImage._Default" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="ID"  OnDataBinding="ASPxGridView1_DataBinding"
            ClientInstanceName="grid"
            OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared" OnCustomCallback="ASPxGridView1_CustomCallback">
            <Columns>
                <dx:GridViewDataTextColumn Caption="Action" Name="colAction" VisibleIndex="0">
                    <DataItemTemplate>
                        <dx:ASPxButton ID="btnAction" runat="server" AutoPostBack="False" ClientInstanceName="btnAction" >
                        </dx:ASPxButton>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Subject" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DueOn" VisibleIndex="2">
                    <PropertiesDateEdit DisplayFormatString="{0:t}">
                    </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
            </Columns>
        </dx:ASPxGridView>
    </div>
    </form>
</body>
</html>