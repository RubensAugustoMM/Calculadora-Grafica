namespace CalculadoraGrafica.Funcao.Gramatica;

public class Funcao : NodoBase
{
    public Expressao Expressao { get; set; }
    public String FuncaoString { get; private set; }

    public Funcao(String funcaoString, Expressao expressao)
    {
        this.Expressao = expressao;
        this.FuncaoString = funcaoString;
    }
    
    public override bool Avaliar()
    {
        throw new NotImplementedException();
    }
}