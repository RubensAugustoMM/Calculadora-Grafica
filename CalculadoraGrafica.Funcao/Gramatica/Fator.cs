namespace CalculadoraGrafica.Funcao.Gramatica;

public class Fator : NodoBase
{
    public Numero Numero { get; set; }
    public Fator? FatorDireito { get; set; }

    public Fator(Numero numero, Fator? fatorDireito = null)
    {
        this.Numero = numero;
        this.FatorDireito = fatorDireito;
    }
    
    public override bool Avaliar()
    {
        throw new NotImplementedException();
    }
}