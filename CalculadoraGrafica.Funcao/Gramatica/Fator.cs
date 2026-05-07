using CalculadoraGrafica.Funcao.Gramatica.Atributos;

namespace CalculadoraGrafica.Funcao.Gramatica
{
    public class Fator : NodoBase
    {
        [Lexema]
        public static string Exponecial { get; } = @"[\^]";
        
        public override string[][] Definicoes { get; } =
        [
            [nameof(Numero)],
            [nameof(Variavel)],
            [nameof(Numero), Exponecial, nameof(Fator)],
            [nameof(Variavel), Exponecial, nameof(Fator)]
        ];

        public override bool Avaliar()
        {
            
            throw new NotImplementedException();
        }
    }
}