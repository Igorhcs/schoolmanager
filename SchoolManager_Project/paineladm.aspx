<%@ Page Language="C#" AutoEventWireup="true" CodeFile="paineladm.aspx.cs" Inherits="paineladm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Painel - Admin</title>
    <link href="lib/css/paineladm.css" title="default" rel="stylesheet" media="all"/>
    <script src="lib/js/default.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="painel" class="painel">
            <div id="options" class="options">
                <a class="cadastrare" href="#" onclick="redirect('Painel')"></a>
                <a class="inserira" href="#" onclick="redirect('InserirA')"></a>
            </div>
        </div>
    <div id="containerpainel">
        
        <div id="content" class="content">
               <!-- <div id="menu" class="menu">
                    <ul>
                        <li class="menuli"><a href="#" onclick="redirect('Painel')">Painel</a></li>
                        <li class="menuli"><a href="#" onclick="redirect('LogOut')">SignOut</a></li>
                    </ul>
                </div> -->
                <ul>
                           <li>
                              <!--  <asp:Label ID="fnome" runat="server" Text="*Nome:"></asp:Label> -->
                                <asp:textBox type="text" runat="server" ID="tb_nome" name="tb_nome" placeholder="Digite o nome da escola" required="required" title="Descreva o nome da escola"> </asp:textBox>
                                
                            </li>
                            <li>
                               <!-- <asp:Label ID="fcnpj" runat="server" Text="*CNPJ:"></asp:Label> -->
                                <asp:textBox type="text" runat="server" ID="tb_cnpj" name="tb_cnpj" placeholder="CNPJ com 15 dígitos" required="required" title="Descreva o CNPJ"> </asp:textBox>
                                
                            </li>                       
                            <li>
                              <!--  <asp:Label ID="femail" runat="server" Text="*Email:"></asp:Label> -->
                                <asp:textBox type="email" runat="server" ID="tb_email" name="tb_email" placeholder="seuemail@exemplo.com" required="required" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$" title="emailcorreto@exemplo.com"> </asp:textBox>
                                
                            </li>
                            <li>
                             <!--   <asp:Label ID="fpass"  runat="server" Text="*Senha:" ></asp:Label> -->
                                <asp:textBox type="password" runat="server" ID="tb_pass" name="tb_pass" MaxLength="6" placeholder="Senha no minimo 6 digitos" required="required"></asp:textBox>
                                
                            </li>
                            <li>
                                <asp:label ID="fid" runat="server"></asp:label>
                                <asp:textBox type="hidden" runat="server" ID="cnpj" name="cnpj" value=""></asp:textBox>
                            </li>
                            <asp:Button type="submit" cssClass="submit" runat="server" ID="enviar" Text="" OnClick="enviar_Click" />
              </ul>
                         
                <asp:Label cssClass="boasvindas" runat="server" ID="bv" Text=""></asp:Label>       
                <div  class="mode" >
                    <div  class="mode_title" >
                        <h1> </h1>
                    </div>
                    <div  class="mode_list" >
                        <asp:GridView ID="listaUsuarios" runat="server"  ShowFooter="False" AllowPaging="True" AutoGenerateColumns="False"
                             BackColor="#CCCCCC" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                            ForeColor="Black" Height="110px" Width="1112px" style="margin-right: 4px" 
                            OnRowCancelingEdit="listaUsuarios_RowCancelingEdit" OnRowUpdating="listaUsuarios_RowUpdating" 
                            OnRowEditing="listaUsuarios_RowEditing" OnRowDeleting="listaUsuarios_RowDeleting"   >
                            <Columns>
                                <asp:TemplateField HeaderText="CNPJ" InsertVisible="False" SortExpression="idusuario" >                               
                                    <FooterTemplate>
                                        <asp:Label ID="Lfid" runat="server" Text='CNPJ'></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Lid" runat="server" Text='<%# Bind("cnpj") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NOME" InsertVisible="False" SortExpression="nome" >                               
                                   <FooterTemplate>
                                        <asp:Label ID="Lfnome" runat="server" Text='NOME'></asp:Label>
                                    </FooterTemplate> 
                                    <ItemTemplate>
                                        <asp:Label ID="Lnome" runat="server" Text='<%# Bind("nome_escola") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EMAIL" InsertVisible="False" SortExpression="email">                               
                                    <FooterTemplate>
                                        <asp:Label ID="Lfemail" runat="server" Text='EMAIL'></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Lemail" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PASS" InsertVisible="False" SortExpression="pass">                               
                                    <FooterTemplate>
                                        <asp:Label ID="Lfpass" runat="server" Text='PASS'></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Lpass" runat="server" Text='<%# Bind("senha") %>'></asp:Label>
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
                                Não há escolas cadastradas a serem exibidas
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
            <div id="menu" class="menu">
                    <a class="menuli" href="#" onclick="redirect('LogOut')"></a>
                </div>
                
                    </div>
        
           </div>     
                
    </form>
</body>
</html>
