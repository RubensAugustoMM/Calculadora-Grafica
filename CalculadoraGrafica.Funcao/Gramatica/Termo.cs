namespace CalculadoraGrafica.Funcao.Gramatica
{
    public class Termo : NodoBase
    {
        public override string[][] Definicoes { get; } =
        [
            [nameof(Fator)],
            [nameof(Fator), nameof(OperadoresMultiplicativos), nameof(Fator)]
        ];

        public override bool Avaliar()
        {
            throw new NotImplementedException();
        }
    }
}