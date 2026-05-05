namespace CalculadoraGrafica.Funcao.Gramatica
{
    public class Fator : NodoBase
    {
        private static readonly string _exponecial = "^";
        public override string[][] Definicoes { get; } =
        [
            [nameof(Numero)],
            [nameof(Variavel)],
            [nameof(Numero), _exponecial, nameof(Fator)],
            [nameof(Variavel), _exponecial, nameof(Fator)]
        ];

        public override bool Avaliar()
        {
            
            throw new NotImplementedException();
        }
    }
}