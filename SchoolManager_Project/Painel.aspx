
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Painel.aspx.cs" Inherits="Painel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>****PROJETO - FB*******</title>
    <link href="lib/css/default.css" rel="stylesheet" title="default" media="all"/>
    <script src="lib/js/default.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container" class="container">
            <header id="head" class="logo">
                
            </header>
            <div id="content" class="content">
                <div id="menu" class="menu">
                    <ul>
                        <li class="menuli"><a href="#" onclick="redirect('LogOut')">SignOut</a></li>
                    </ul>
                </div>
                <asp:Label cssClass="boasvindas" runat="server" ID="bv" Text=""></asp:Label>
                <div  class="mode" >
                    <div  class="mode_title" >
                        <h1> Escolas</h1>
                    </div>
                    <div  class="mode_list" >
                        <ul class="list_p">
                            <li class="mode_lp"><a href="#" onclick="redirect('EscolaC')">Cadastrar</a></li>
                            <li class="mode_lp"><a href="#" onclick="redirect('AlterarC')">Alterar</a></li>
                        </ul>
                    </div>
                </div>
                <div  class="mode" >
                    <div  class="mode_title" >
                        <h1> Administrador</h1>
                    </div>
                    <div  class="mode_list" >
                        <ul class="list_p">
                              <li class="mode_lp"><a href="#" onclick="redirect('UsuarioR')">Cadastrar</a></li>
                            <li class="mode_lp"><a href="#" onclick="redirect('CategoriaR')">Alterar</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
