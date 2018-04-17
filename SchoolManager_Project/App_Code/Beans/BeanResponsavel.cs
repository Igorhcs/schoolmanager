using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BeanResponsavel
/// </summary>
public class BeanResponsavel
{
    private long idresponsavel;
    private String nome_responsavel;
    private String senha;
    private String login;

    public long Idresponsavel
    {
        get { return idresponsavel; }
        set { idresponsavel = value; }
    }
    

    public String Nome_responsavel
    {
        get { return nome_responsavel; }
        set { nome_responsavel = value; }
    }
    

    public String Login
    {
        get { return login; }
        set { login = value; }
    }
    

    public String Senha
    {
        get { return senha; }
        set { senha = value; }
    }
	public BeanResponsavel()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}