namespace CalculadoraGrafica.Funcao.Gramatica;

public class Termo : NodoBase
{
    public Termo? TermoEsquerdo { get; set; }
    public OperadoresMultiplicativos? Operador { get; set; } 
    public Fator Fator { get; set; }

    public Termo
    (
        Fator fator,
        Termo? termoEsquerdo = null,
        OperadoresMultiplicativos? operador = null
    )
    {
        this.Fator = fator;
        this.TermoEsquerdo = termoEsquerdo;
        this.Operador = operador;
    }
    
    public override bool Avaliar()
    {
        throw new NotImplementedException();
    }
}