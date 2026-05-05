namespace CalculadoraGrafica.Funcao.Gramatica
{
    public class Expressao : NodoBase
    {
        public override string[][] Definicoes { get; } =
        [
            [nameof(Fator)],
            [nameof(Expressao), nameof(OperadoresAditivos), nameof(Fator)],
        ];

        public override bool Avaliar()
        {
            throw new NotImplementedException();
        }
    }
}