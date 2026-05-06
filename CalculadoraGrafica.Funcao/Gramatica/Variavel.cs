using CalculadoraGrafica.Funcao.Gramatica.Atributos;

namespace CalculadoraGrafica.Funcao.Gramatica
{
    [Lexema]
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