namespace CalculadoraGrafica.Funcao.Gramatica
{
    public class Expressao : NodoBase
    {
        public Expressao? ExpressaoEsquerda { get; set; }
        public OperadoresAditivos? Operador { get; set; }
        public Fator Fator { get; set; }

        public Expressao
            (
                Fator fator, 
                Expressao? expressaoEsquerda = null, 
                OperadoresAditivos? operador = null
            )
        {
           this.Fator = fator;
           this.ExpressaoEsquerda = expressaoEsquerda;
           this.Operador = operador;
        }
        
        public override bool Avaliar()
        {
            throw new NotImplementedException();
        }
    }
}