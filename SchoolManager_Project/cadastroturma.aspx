<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cadastroturma.aspx.cs" Inherits="cadastroturma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="lib/css/cadastroturma.css" title="default" rel="stylesheet" media="all"/>
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
    <div  class="container2" id="container2" >                   
                    <div  class="content" id="content" >
                        <ul>                      
                            <li>
                                <asp:textBox type="text" runat="server" ID="tb_nome" name="tb_nome" placeholder="Insira o nome da turma" required="required" title="emailcorreto@justamente.com"> </asp:textBox>
                                
                            </li>
                            <li>
                                <asp:label ID="fid" runat="server"></asp:label>
                                <asp:textBox type="hidden" runat="server" ID="id" name="id" value=""></asp:textBox>
                            </li>
                            <li>
                                 <asp:Button type="submit" cssClass="submit" runat="server" ID="enviar" Text="" OnClick="enviar_Click" />                                
                            </li>                   
                       </ul>
                    </div>
                
        <div  class="mode" > 
                    <div  class="mode_list" >
                        <asp:GridView ID="listaUsuarios" runat="server"  ShowFooter="False" AllowPaging="True" AutoGenerateColumns="False"
                             BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                            ForeColor="Black" Height="110px" Width="998px" style="margin-right: 4px" 
                            OnRowCancelingEdit="listaUsuarios_RowCancelingEdit" OnRowUpdating="listaUsuarios_RowUpdating" 
                            OnRowEditing="listaUsuarios_RowEditing" OnRowDeleting="listaUsuarios_RowDeleting"   >
                            <Columns>
                                
                                <asp:TemplateField HeaderText="Turma" InsertVisible="False" SortExpression="nome_turma">                               
                                    <FooterTemplate>
                                        <asp:Label ID="Lfturma" runat="server" Text='TURMA'></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Lturma" runat="server" Text='<%# Bind("nome_turma") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:CommandField ShowEditButton="true" ButtonType ="Image" 
                                    EditImageUrl="lib/icons/editar.jpg" 
                                    HeaderText="Editar"  ControlStyle-Width="16px"  ShowCancelButton="False" ShowInsertButton="false" ShowDeleteButton="false" ShowSelectButton="false">
<ControlStyle Width="16px"></ControlStyle>
                                </asp:CommandField>
                                <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="lib/icons/checkboxerro.png" HeaderText="Deletar" ControlStyle-Width="16px" >
                               
<ControlStyle Width="16px"></ControlStyle>
                                </asp:CommandField>
                               
                            </Columns>
                            <EmptyDataTemplate>
                                Não há produtos a serem exibidos
                            </EmptyDataTemplate>
                          
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="Gray" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />

                        </asp:GridView>
                    </div>
                </div>
            </div>
        <asp:Label cssClass="boasvindas" runat="server" ID="bv" Text=""></asp:Label>
    </form>
</body>
</html>
