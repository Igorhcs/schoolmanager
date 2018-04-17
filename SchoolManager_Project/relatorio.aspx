<%@ Page Language="C#" AutoEventWireup="true" CodeFile="relatorio.aspx.cs" Inherits="relatorio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="lib/css/relatorio.css" title="default" rel="stylesheet" media="all"/> 
    <link href="lib/css/painelescola.css" title="default" rel="stylesheet" media="all"/>
    <script src="lib/js/jquery-1.12.1.min.js" type="text/javascript"> </script>
</head>
<body>
    <form id="form1" runat="server">
        
        <header id="head" class="logo">

        </header>
        <div id="mainnav">
              <ul id="menu">
                  <li id="responsavel"><a href="cadastroresponsavel.aspx" target="_top" class="spanr">RESPONSAVEL</a></li>
                  <li id="turma"><a href="cadastroturma.aspx" target="_top" class="spanr">TURMA</a></li>
                  <li id="aluno"><a href="cadastroaluno.aspx" target="_top" class="spanr">ALUNO</a></li>
                  <li id="relatorio"><a href="relatorio.aspx" target="_top" class="spanr">RELATORIO</a></li>
              </ul>
        </div>
        <div  class="container3" id="container3" >                   
              <div  class="content" id="content" >
                  <ul>
                      <li>
                          
                          <asp:textBox type="text" runat="server" ID="tb_nome" name="tb_nome" placeholder="Insira o ID" required="required" title="Nome/ID"> </asp:textBox>
                      </li>
                      <li>
                                <asp:label ID="fid" runat="server"></asp:label>
                                <asp:textBox type="hidden" runat="server" ID="id" name="id" value=""></asp:textBox>
                            </li>
                  </ul>
                  <div id="msg" class="msg">
                      
                      <asp:TextBox runat="server" TextMode="multiline" Columns="50" Rows="11" id="msgtb">
                         
                      </asp:TextBox>
                      <%--<img src="" id="img" />--%>
                      
                      <asp:Button type="submit" cssClass="img" runat="server" ID="enviar" Text="" OnClick="enviar_Click" />  

                  </div>
              </div>
                <asp:Label runat="server" ID="msgBD" CssClass="lbmsg" Text="" />
                <asp:Label ID="lb_msg" runat="server" Text="" CssClass="lbmsg"></asp:Label>
        </div>
    </form>
</body>
</html>
