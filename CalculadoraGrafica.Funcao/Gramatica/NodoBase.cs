namespace CalculadoraGrafica.Funcao.Gramatica
{
    public abstract class NodoBase
    {
        public NodoBase NodoAnterior { get; set; }
        
        public abstract string[][] Definicoes { get; }

        public abstract bool Avaliar();
    }
}