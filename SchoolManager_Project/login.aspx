<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - admin</title>
    <link href="lib/css/loginadm.css" title="default" rel="stylesheet" media="all"/>
</head>
<body>
<form id="form1" runat="server">
    <div id="container">
        
        <section id="content">
            
            <div id="login">
                    <asp:Label ID="lb_test" runat="server" Text="" CssClass="lbmsg"></asp:Label>
               
                    <!--<asp:Label ID="lb_email" runat="server" Text="Login:"></asp:Label> -->
                    <asp:TextBox ID="tb_email" runat="server"></asp:TextBox>

                    <!--<asp:Label ID="lb_pass" runat="server" Text="Senha:"></asp:Label> -->
                    <asp:TextBox ID="tb_pass" runat="server" TextMode="Password" ></asp:TextBox><br />
                    <a href="index.aspx" target="_self">Esqueceu sua senha?</a>
                    <asp:Button ID="bt_logar" runat="server" Text="" CssClass="button"  OnClick="bt_logar_Click"/>
                    
                    <asp:Label ID="lb_msg" runat="server" Text="" CssClass="lbmsg"></asp:Label>
                    
            </div> 
            
        </section>
    </div>
</form>

</body>
</html>
