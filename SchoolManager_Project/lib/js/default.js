/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
function redirect(page){
    
    switch(page){
        case "InserirA":
            window.location.href = "cadastroadm.aspx"; 
        break;
        case "AlterarC":
            window.location.href = "AlterarEscola.aspx";
        break;
        case "ResponsavelC":
            window.location.href = "cadastroresponsavel.aspx";
        break;
         case "UsuarioR":
             window.location.href = "RelatorioUsuario.aspx";
        break;
        case "CategoriaR":
            window.location.href = "RelatorioCategoria.aspx";
        break;
        case "AnuncioR":
            window.location.href = "RelatorioAnuncio.aspx";
            break;
        case "LogOut":
            window.location.href = "LogOut.aspx";
            break;
        default:
            window.location.href = "paineladm.aspx";
            break;
    }
       
}

