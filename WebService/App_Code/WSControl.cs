using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for WSControl
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WSControl : System.Web.Services.WebService {

    public WSControl () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    //METODOS PARA DAO ADM
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebInvoke(Method = "POST", UriTemplate = "post_resposta", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    public String loginADM(String json)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();

        BeanADM obje = js.Deserialize<BeanADM>(json);
        
        Boolean r = false;
        AdmDAO adm = new AdmDAO();
        r = adm.loginADM(obje.Login,obje.Senha);
        return js.Serialize(r);
    }


    [WebMethod]
     [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
     [WebInvoke(Method = "POST", UriTemplate = "post_resposta", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
     public String admIn(String json)
     {
         int i = 0;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
         try
         {
             // Deserializando a string para Object
             
             BeanADM obje = serializer.Deserialize<BeanADM>(json);

             AdmDAO adm = new AdmDAO();
             i = adm.insertADM(obje);
         }
         catch (WebException ex)
         {
             Debug.WriteLine("Erro: " + ex);
         }
         return serializer.Serialize(i.ToString());
     }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String admAll()
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        AdmDAO adm = new AdmDAO();
        List<BeanADM> list = new List<BeanADM>();
        list = adm.selectAllADM();
        return js.Serialize(list);
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String admID(String json)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        BeanADM obje = js.Deserialize<BeanADM>(json);

        AdmDAO adm = new AdmDAO();
        List<BeanADM> list = new List<BeanADM>();
        list = adm.selectIDADM(obje);
        return js.Serialize(list);
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String updateADM(String json)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        BeanADM obje = js.Deserialize<BeanADM>(json);

        AdmDAO adm = new AdmDAO();
        int i = 0;
        i = adm.updateADM(obje);
        return js.Serialize(i);
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebInvoke(Method = "POST", UriTemplate = "post_resposta", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    public String admDel(String json)
    {
        int i = 0;
        try
        {
            // Deserializando a string para Object
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            BeanADM obje = serializer.Deserialize<BeanADM>(json);

            AdmDAO adm = new AdmDAO();
            i = adm.deleteADM(obje);
        }
        catch (WebException ex)
        {
            Debug.WriteLine("Erro: " + ex);
        }
        return i.ToString();
    }
    //FIM METODOS PARA DAO ADM
    
    //METODOS PARA EscolaDAO
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebInvoke(Method = "POST", UriTemplate = "post_resposta", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    public String loginEscola(String json)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();

        BeanEscola obje = js.Deserialize<BeanEscola>(json);

        Boolean r = false;
        EscolaDAO esc = new EscolaDAO();
        r = esc.loginEscola(obje.Email, obje.Senha);
        return js.Serialize(r);
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebInvoke(Method = "POST", UriTemplate = "post_resposta", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    public String insertEscola(String json)
    {
        int i = 0;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        try
        {
            // Deserializando a string para Object

            BeanEscola obje = serializer.Deserialize<BeanEscola>(json);

            EscolaDAO esc = new EscolaDAO();
            i = esc.insertEscola(obje);
        }
        catch (WebException ex)
        {
            Debug.WriteLine("Erro: " + ex);
        }
        return serializer.Serialize(i.ToString());
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String escolaAll()
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        EscolaDAO esc = new EscolaDAO();
        List<BeanEscola> list = new List<BeanEscola>();
        list = esc.escolaAll();
        return js.Serialize(list);
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String escolaID(String json)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        BeanEscola obje = js.Deserialize<BeanEscola>(json);

        EscolaDAO esc = new EscolaDAO();
        List<BeanEscola> list = new List<BeanEscola>();
        list = esc.selectCNPJ(obje);
        return js.Serialize(list);
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String updateEscola(String json)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        BeanEscola obje = js.Deserialize<BeanEscola>(json);

        EscolaDAO esc = new EscolaDAO();
        int i = 0;
        i = esc.updateEscola(obje);
        return js.Serialize(i);
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebInvoke(Method = "POST", UriTemplate = "post_resposta", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    public String escolaDel(String json)
    {
        int i = 0;
        try
        {
            // Deserializando a string para Object
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            BeanEscola obje = serializer.Deserialize<BeanEscola>(json);

            EscolaDAO esc = new EscolaDAO();
            i = esc.deleteEscola(obje);
        }
        catch (WebException ex)
        {
            Debug.WriteLine("Erro: " + ex);
        }
        return i.ToString();
    }
    //FIM METODOS PARA DAO ESCOLA

    //METODOS PARA AlunoDAO

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebInvoke(Method = "POST", UriTemplate = "post_resposta", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    public String alunoIn(String json)
    {
        int i = 0;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        try
        {
            // Deserializando a string para Object
            // BeanAluno ba = serializer.Serialize(json.ToString());
            BeanAluno obje = serializer.Deserialize<BeanAluno>(json);

            AlunoDAO al = new AlunoDAO();
            i = al.insertUsuario(obje);
        }
        catch (WebException ex)
        {
            Debug.WriteLine("Erro: " + ex);
        }
        return serializer.Serialize(i.ToString());
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String alunoAll()
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        AlunoDAO al = new AlunoDAO();
        List<BeanAluno> list = new List<BeanAluno>();
        list = al.selectAll();
        return js.Serialize(list);
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String alunoID(String json)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        BeanAluno obje = js.Deserialize<BeanAluno>(json);

        AlunoDAO al = new AlunoDAO();
        List<BeanAluno> list = new List<BeanAluno>();
        list = al.selectID(obje);
        return js.Serialize(list);
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String updateAluno(String json)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        BeanAluno obje = js.Deserialize<BeanAluno>(json);

        AlunoDAO al = new AlunoDAO();
        int i = 0;
        i = al.updateUsuario(obje);
        return js.Serialize(i);
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebInvoke(Method = "POST", UriTemplate = "post_resposta", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    public String alunoDel(String json)
    {
        int i = 0;
        try
        {
            // Deserializando a string para Object
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            BeanAluno obje = serializer.Deserialize<BeanAluno>(json);

            AlunoDAO al = new AlunoDAO();
            i = al.deleteUsuario(obje);
        }
        catch (WebException ex)
        {
            Debug.WriteLine("Erro: " + ex);
        }
        return i.ToString();
    }

    //FIM METODOS AlunoDAO

    //METODOS PARA TurmaDAO
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebInvoke(Method = "POST", UriTemplate = "post_resposta", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    public String turmaIn(String json)
    {
        int i = 0;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        try
        {
            // Deserializando a string para Object

            BeanTurma obje = serializer.Deserialize<BeanTurma>(json);

            TurmaDAO tu = new TurmaDAO();
            i = tu.insertUsuario(obje);
        }
        catch (WebException ex)
        {
            Debug.WriteLine("Erro: " + ex);
        }
        return serializer.Serialize(i.ToString());
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String turmaAll()
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        TurmaDAO tu = new TurmaDAO();
        List<BeanTurma> list = new List<BeanTurma>();
        list = tu.selectAll();
        return js.Serialize(list);
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String updateTurma(String json, String turmaantes)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        BeanTurma obje = js.Deserialize<BeanTurma>(json);

        TurmaDAO tu = new TurmaDAO();
        int i = 0;
        i = tu.updateUsuario(obje, turmaantes);
        return js.Serialize(i);
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebInvoke(Method = "POST", UriTemplate = "post_resposta", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    public String turmaDel(String json)
    {
        int i = 0;
        try
        {
            // Deserializando a string para Object
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            BeanTurma obje = serializer.Deserialize<BeanTurma>(json);

            TurmaDAO tu = new TurmaDAO();
            i = tu.deleteUsuario(obje);
        }
        catch (WebException ex)
        {
            Debug.WriteLine("Erro: " + ex);
        }
        return i.ToString();
    }

    //FIM METODOS TurmaDAO

    //METODOS PARA RESPONSAVELDAO
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebInvoke(Method = "POST", UriTemplate = "post_resposta", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    public String responsavelIn(String json)
    {
        int i = 0;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        try
        {
            // Deserializando a string para Object

            BeanResponsavel obje = serializer.Deserialize<BeanResponsavel>(json);

            ResponsavelDAO resp = new ResponsavelDAO();
            i = resp.insertUsuario(obje);
        }
        catch (WebException ex)
        {
            Debug.WriteLine("Erro: " + ex);
        }
        return serializer.Serialize(i.ToString());
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String responsavelAll()
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        ResponsavelDAO resp = new ResponsavelDAO();
        List<BeanResponsavel> list = new List<BeanResponsavel>();
        list = resp.selectAll();
        return js.Serialize(list);
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String updateResponsavel(String json)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        BeanResponsavel obje = js.Deserialize<BeanResponsavel>(json);

        ResponsavelDAO resp = new ResponsavelDAO();
        int i = 0;
        i = resp.updateUsuario(obje);
        return js.Serialize(i);
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebInvoke(Method = "POST", UriTemplate = "post_resposta", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    public String responsavelDel(String json)
    {
        int i = 0;
        try
        {
            // Deserializando a string para Object
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            BeanResponsavel obje = serializer.Deserialize<BeanResponsavel>(json);

            ResponsavelDAO resp = new ResponsavelDAO();
            i = resp.deleteUsuario(obje);
        }
        catch (WebException ex)
        {
            Debug.WriteLine("Erro: " + ex);
        }
        return i.ToString();
    }

    //FIM METODOS PARA RESPONSAVELDAO

    //METODOS PARA HISTORICO DAO

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebInvoke(Method = "POST", UriTemplate = "post_resposta", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    public String historicoIn(String json)
    {
        int i = 0;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        try
        {
            // Deserializando a string para Object

            BeanHistorico obje = serializer.Deserialize<BeanHistorico>(json);

            HistoricoDAO his = new HistoricoDAO();
            i = his.insertHistorico(obje);
        }
        catch (WebException ex)
        {
            Debug.WriteLine("Erro: " + ex);
        }
        return serializer.Serialize(i.ToString());
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String historicoAll()
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        HistoricoDAO his = new HistoricoDAO();
        List<BeanHistorico> list = new List<BeanHistorico>();
        list = his.selectAll();
        return js.Serialize(list);
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebInvoke(Method = "POST", UriTemplate = "post_resposta", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    public String historicoDel(String json)
    {
        int i = 0;
        try
        {
            // Deserializando a string para Object
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            BeanHistorico obje = serializer.Deserialize<BeanHistorico>(json);

            HistoricoDAO his = new HistoricoDAO();
            i = his.deleteHistorico(obje);
        }
        catch (WebException ex)
        {
            Debug.WriteLine("Erro: " + ex);
        }
        return i.ToString();
    }

   
}
