using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BeanHistorico
/// </summary>
public class BeanHistorico{
    private long idhistorico;
    private String msg;
    //private long idaluno_fk;
    private BeanAluno aluno;

    public BeanAluno Aluno
    {
        get { return aluno; }
        set { aluno = value; }
    }

    public long Idhistorico
    {
        get { return idhistorico; }
        set { idhistorico = value; }
    }
    

    public String Msg
    {
        get { return msg; }
        set { msg = value; }
    }

	public BeanHistorico()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}