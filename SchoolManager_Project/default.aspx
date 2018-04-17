<%@ Page Language="C#" AutoEventwireup="true" %>
<%@ Import Namespace="System.Net.Mail" %>
<%@ Import Namespace="System.Text" %>
<html>
<form id="Form1" method="post" runat="server">
<h2>CONTATO</h2>
<table>
<tbody>
<tr>
<td>Nome:</td>
<td><asp:textbox id="txtNome" runat="server" width="280px"></asp:textbox></td>
</tr>
<tr>
<td>Email:</td>
<td><asp:textbox id="txtEmail" runat="server" width="277px"></asp:textbox></td>
</tr>
<tr>
<td>Assunto:</td>
<td><asp:textbox id="txtAssunto" runat="server"></asp:textbox></td>
</tr>
<tr>
<td>Mensagem:</td>
<td><asp:textbox div="" height="69px" id="txtMensagem" runat="server" width="326px">TextMode="MultiLine"></asp:textbox></td>
</tr>
</tbody>
</table>

<asp:label id="lblMensagem" runat="server" text=""></asp:label>
</form>
    </html>