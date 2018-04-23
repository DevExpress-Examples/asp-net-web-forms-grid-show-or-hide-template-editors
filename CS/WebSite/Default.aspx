<%@ Page Language="C#" AutoEventWireup="false" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript">
        function OnSelectedIndexChangedEventHandler(radioButtonList, rowVisibleIndex) {
            var comboBox = ASPxClientControl.Cast('cmb_' + rowVisibleIndex.toString());
            var memo = ASPxClientControl.Cast('memo_' + rowVisibleIndex.toString());
            
            var selectedItem = radioButtonList.GetSelectedItem();
            if (selectedItem) {
                switch (selectedItem.value) {
                    case '0':
                        comboBox.SetVisible(false);
                        memo.SetVisible(true);
                        break;
                    case '1':
                        comboBox.SetVisible(true);
                        memo.SetVisible(false);
                        break;
                }
           }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
                DataSourceID="AccessDataSource1" KeyFieldName="CustomerID">
                <Columns>
                    <dxwgv:GridViewDataTextColumn FieldName="CustomerID" ReadOnly="True" VisibleIndex="0">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn FieldName="CompanyName" VisibleIndex="1">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn FieldName="ContactName" VisibleIndex="2">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn FieldName="ContactTitle" VisibleIndex="3">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="Send Promotion" VisibleIndex="4">
                        <DataItemTemplate>
                            <dxe:ASPxRadioButtonList ID="ASPxRadioButtonList1" runat="server" OnInit="ASPxRadioButtonList1_Init">
                                <Items>
                                    <dxe:ListEditItem Text="Send" Value="1" />
                                    <dxe:ListEditItem Text="No Send" Value="0" />
                                </Items>
                            </dxe:ASPxRadioButtonList>
                        </DataItemTemplate>
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn Caption="Reazon" VisibleIndex="5">
                        <DataItemTemplate>
                            <dxe:ASPxComboBox ID="ASPxComboBox1" runat="server" ValueType="System.String" OnInit="ASPxComboBox1_Init">
                                <Items>
                                    <dxe:ListEditItem Text="Rain" Value="Rain" />
                                    <dxe:ListEditItem Text="Storm" Value="Storm" />
                                    <dxe:ListEditItem Text="No Car" Value="No Car" />
                                    <dxe:ListEditItem Text="No Fly" Value="No Fly" />
                                </Items>
                            </dxe:ASPxComboBox>
                            <br />
                            <dxe:ASPxMemo ID="ASPxMemo1" runat="server" Height="71px" Width="170px" OnInit="ASPxMemo1_Init">
                            </dxe:ASPxMemo>
                        </DataItemTemplate>
                    </dxwgv:GridViewDataTextColumn>
                </Columns>
            </dxwgv:ASPxGridView>
            <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
                DeleteCommand="DELETE FROM [Customers] WHERE (([CustomerID] = ?) OR ([CustomerID] IS NULL AND ? IS NULL))"
                InsertCommand="INSERT INTO [Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle]) VALUES (?, ?, ?, ?)"
                SelectCommand="SELECT [CustomerID], [CompanyName], [ContactName], [ContactTitle] FROM [Customers] ORDER BY [ContactName]"
                UpdateCommand="UPDATE [Customers] SET [CompanyName] = ?, [ContactName] = ?, [ContactTitle] = ? WHERE (([CustomerID] = ?) OR ([CustomerID] IS NULL AND ? IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="CustomerID" Type="String" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="CompanyName" Type="String" />
                    <asp:Parameter Name="ContactName" Type="String" />
                    <asp:Parameter Name="ContactTitle" Type="String" />
                    <asp:Parameter Name="CustomerID" Type="String" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="CustomerID" Type="String" />
                    <asp:Parameter Name="CompanyName" Type="String" />
                    <asp:Parameter Name="ContactName" Type="String" />
                    <asp:Parameter Name="ContactTitle" Type="String" />
                </InsertParameters>
            </asp:AccessDataSource>
            <dxe:ASPxButton ID="ASPxButton1" runat="server" Text="Save" OnClick="ASPxButton1_Click">
            </dxe:ASPxButton>
        </div>
    </form>
</body>
</html>