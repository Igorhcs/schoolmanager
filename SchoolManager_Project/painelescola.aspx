<%@ Page Language="C#" AutoEventWireup="true" CodeFile="painelescola.aspx.cs" Inherits="painelescola" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Painel - Escola</title>
    <link href="lib/css/painelescola.css" title="default" rel="stylesheet" media="all"/>
    <script src="lib/js/default.js"></script>
    <script src="lib/js/jquery-1.12.1.min.js" type="text/javascript"> </script>
</head>
<body>
    <form id="form1" runat="server">
        <header id="head" class="logo">

            </header>
        <div id="container" class="container">
            
            <div id="mainnav">
              <ul id="menu">
                  <li id="responsavel"><a href="cadastroresponsavel.aspx" target="_top" class="spanr">RESPONSAVEL</a></li>
                  <li id="turma"><a href="cadastroturma.aspx" target="_top" class="spanr">TURMA</a></li>
                  <li id="aluno"><a href="cadastroaluno.aspx" target="_top" class="spanr">ALUNO</a></li>
                  <li id="relatorio"><a href="relatorio.aspx" target="_top" class="spanr">RELATORIO</a></li>
              </ul>
            </div>
             <div id="content">
               
             </div>
            
        </div>
    </form>
</body>
    <script>
        $(function () {
            $("ul#menu a").click(function () {

                pagina = $(this).attr('href')
                $(window.document.location).attr('href', pagina);
                //$("#content").load(pagina)
                return false;

            });
        })
    </script>
    
  
</html>
