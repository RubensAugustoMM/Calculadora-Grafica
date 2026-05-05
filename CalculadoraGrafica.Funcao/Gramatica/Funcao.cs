namespace CalculadoraGrafica.Funcao.Gramatica
{
    public class Funcao : NodoBase
    {
        public override string[][] Definicoes { get; } =
        [
            [nameof(Expressao)]
        ];

        public override bool Avaliar()
        {
            throw new NotImplementedException();
        }
    }
}