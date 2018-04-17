using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BeanEscola
/// </summary>
public class BeanEscola
{
    private String cnpj;

    public String Cnpj
    {
        get { return cnpj; }
        set { cnpj = value; }
    }
    private String email;

    public String Email
    {
        get { return email; }
        set { email = value; }
    }
    private String nome_escola;

    public String Nome_escola
    {
        get { return nome_escola; }
        set { nome_escola = value; }
    }
    private String senha;

    public String Senha
    {
        get { return senha; }
        set { senha = value; }
    }
	public BeanEscola()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}