using CalculadoraGrafica.Funcao.Gramatica.Atributos;

namespace CalculadoraGrafica.Funcao.Gramatica
{
    [Lexema]
    public class Numero : NodoBase
    {
        private static readonly string _regex = @"\d+,?\d*"; 
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