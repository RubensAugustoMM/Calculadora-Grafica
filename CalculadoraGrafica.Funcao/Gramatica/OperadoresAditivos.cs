using CalculadoraGrafica.Funcao.Gramatica.Atributos;

namespace CalculadoraGrafica.Funcao.Gramatica
{
    [Lexema("+","-")]
    public enum OperadoresAditivos 
    {
        Adicao = 0,
        Subtracao = 1
    }
}