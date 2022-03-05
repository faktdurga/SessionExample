<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lag In.aspx.cs" Inherits="SessionExample.Lag_In" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <table align ="center">
                
                <tr>
                    <td>User Name</td>
                    <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td>Passoword</td>
                    <td>
                        <asp:TextBox ID="txtPwd" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnLogin" runat="server" Text="Log In" OnClick="btnLogin_Click" /></td>
                    <td><asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" /></td>
                    
                </tr>
            </table>


        </div>
        <center><asp:Label ID="lblDisplay" runat="server" ForeColor="Red"></asp:Label>
         <asp:Label ID="newlbl" runat="server" ForeColor="Orange"></asp:Label>
    </center>

    </form>
</body>
</html>
