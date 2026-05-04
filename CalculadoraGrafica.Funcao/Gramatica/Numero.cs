namespace CalculadoraGrafica.Funcao.Gramatica
{
    public class Numero : NodoBase
    {
        public decimal Valor { get; set; }

        public Numero(decimal valor)
        {
            this.Valor = valor;
        } 
        
        public override bool Avaliar()
        {
            throw new NotImplementedException();
        }
    }
}