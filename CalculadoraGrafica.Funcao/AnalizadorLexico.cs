using CalculadoraGrafica.Funcao.Gramatica;

namespace CalculadoraGrafica.Funcao
{
    //T é a raiz da arvore de sentencas
    public sealed class AnalizadorLexico<T>
        where T : NodoBase
    {
        public readonly string Texto;
        public T ArvoreSentencas;
        
        public AnalizadorLexico(string texto)
        {
            this.Texto = texto;
        }
    }
}