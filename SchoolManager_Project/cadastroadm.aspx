<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cadastroadm.aspx.cs" Inherits="cadastroadm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cadastro - Admin</title>
    <link href="lib/css/cadadm.css" title="default" rel="stylesheet" media="all"/>
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
                                <asp:textBox type="text" runat="server" ID="tb_nome" name="tb_nome" placeholder="Digite o nome do admin" required="required" title="Descreva o nome"> </asp:textBox>
                                
                            </li>
                            <li>
                               <!-- <asp:Label ID="fcnpj" runat="server" Text="*CNPJ:"></asp:Label> -->
                                <asp:textBox type="text" runat="server" ID="tb_login" name="tb_login" placeholder="Digite o login" required="required" title="Descreva o login"> </asp:textBox>
                                
                            </li>
                            <li>
                             <!--   <asp:Label ID="fpass"  runat="server" Text="*Senha:" ></asp:Label> -->
                                <asp:textBox type="password" runat="server" ID="tb_pass" name="tb_pass" MaxLength="6" placeholder="Senha no minimo 6 digitos" required="required"></asp:textBox>
                                
                            </li>                       
                            <li>
                              <!--  <asp:Label ID="femail" runat="server" Text="*Email:"></asp:Label> -->
                                <asp:textBox type="text" runat="server" ID="tb_status" name="tb_status" placeholder="0 ou 1" required="required"  title="Enable or disable"> </asp:textBox>
                                
                            </li>
                            
                            <li>
                                <asp:label ID="fid" runat="server"></asp:label>
                                <asp:textBox type="hidden" runat="server" ID="id" name="id" value=""></asp:textBox>
                            </li>
                            
                                 <asp:Button type="submit" cssClass="submit" runat="server" ID="enviar" Text="" OnClick="enviar_Click" />
                                                    
                                               
                       </ul>
                            <asp:Label cssClass="boasvindas" runat="server" ID="bv" Text=""></asp:Label>
                <div  class="mode" >
                    <div  class="mode_title" >
                        <h1> </h1>
                    </div>
                    <div  class="mode_list" >
                        <asp:GridView ID="listaUsuarios" runat="server"  ShowFooter="True" AllowPaging="True" AutoGenerateColumns="False"
                             BackColor="#CCCCCC" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                            ForeColor="Black" Height="110px" Width="1112px" style="margin-right: 4px" 
                            OnRowCancelingEdit="listaUsuarios_RowCancelingEdit" OnRowUpdating="listaUsuarios_RowUpdating" 
                            OnRowEditing="listaUsuarios_RowEditing" OnRowDeleting="listaUsuarios_RowDeleting"   >
                            <Columns>
                                <asp:TemplateField HeaderText="ID" InsertVisible="False" SortExpression="idusuario" >                               
                                    <FooterTemplate>
                                        <asp:Label ID="Lfid" runat="server" Text='ID'></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Lid" runat="server" Text='<%# Bind("idadm") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NOME" InsertVisible="False" SortExpression="nome" >                               
                                    <FooterTemplate>
                                        <asp:Label ID="Lfnome" runat="server" Text='NOME'></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Lnome" runat="server" Text='<%# Bind("nome") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="LOGIN" InsertVisible="False" SortExpression="login">                               
                                    <FooterTemplate>
                                        <asp:Label ID="Lflogin" runat="server" Text='LOGIN'></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Llogin" runat="server" Text='<%# Bind("login") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PASS" InsertVisible="False" SortExpression="pass">                               
                                    <FooterTemplate>
                                        <asp:Label ID="Lfsenha" runat="server" Text='SENHA'></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Lsenha" runat="server" Text='<%# Bind("senha") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="STATUS" InsertVisible="False" SortExpression="status">                               
                                    <FooterTemplate>
                                        <asp:Label ID="Lfstatus" runat="server" Text='STATUS'></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Lstatus" runat="server" Text='<%# Bind("status") %>'></asp:Label>
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
