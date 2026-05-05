namespace CalculadoraGrafica.Funcao.Gramatica
{
    public class Variavel : NodoBase
    {
        private static readonly string _regex = "[XYZ]";
        public override string[][] Definicoes { get; } =
        [
            [_regex]
        ];

        public override bool Avaliar()
        {
            throw new NotImplementedException();
        }
    }
}