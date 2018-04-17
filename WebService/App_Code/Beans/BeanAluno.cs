using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class BeanAluno
{
    private long idaluno;
    private String nome_aluno;
    private DateTime dt_nasc;
    private BeanTurma turma;
    private BeanResponsavel responsavel;
    private BeanEscola escola;

    public BeanResponsavel Responsavel
    {
        get { return responsavel; }
        set { responsavel = value; }
    }
    

    public BeanEscola Escola
    {
        get { return escola; }
        set { escola = value; }
    }

    public BeanTurma Turma
    {
        get { return turma; }
        set { turma = value; }
    }

    public long Idaluno
    {
        get { return idaluno; }
        set { idaluno = value; }
    }
   

    public String Nome_aluno
    {
        get { return nome_aluno; }
        set { nome_aluno = value; }
    }
   

    public DateTime Dt_nasc
    {
        get { return dt_nasc; }
        set { dt_nasc = value; }
    }

	public BeanAluno()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    

}