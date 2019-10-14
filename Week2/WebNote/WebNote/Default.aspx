<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebNote.Default" ValidateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html" charset="UTF-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Hello World</h1>
            
            <asp:GridView ID="grvNotes" runat="server" Width="100%" AutoGenerateSelectButton="False">
                <Columns> 
                    <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select"/>
                </Columns>
            </asp:GridView>
            
             <br />
            <br />
            <asp:TextBox ID="txtSearch" runat="server" Width="50%" BorderColor="Red" BorderStyle="Groove">
            </asp:TextBox><asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        </div>
        <br />
        
        ID: <asp:TextBox ID="txtID" runat="server"></asp:TextBox><br />
        Title: <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox><br />
        Creator: <asp:TextBox ID="txtCreator" runat="server"></asp:TextBox><br />
        Content: <asp:TextBox ID="txtContent" runat="server"></asp:TextBox><br />
        Date: <asp:TextBox ID="txtDate" runat="server"></asp:TextBox><br />
        IsSharable: <asp:CheckBox ID="cbIsSharable" runat="server" />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" OnClientClick="return add_confirm();"/>
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick="return confirm('Bạn Muốn Xóa?');" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return update_confirm();"/>
    </form>

    <script>
        function update_confirm()
        {
        var result = confirm("Bạn có thực sự muốn thay đổi không?");
        if(result)
        {
        return true;
        }
        return false;
        }</script>
    <script>
        function add_confirm()
        {
        var result = confirm("Bạn có muốn thêm user này không?");
        if(result)
        {
        return true;
        }
        return false;
        }</script>
</body>
</html>
