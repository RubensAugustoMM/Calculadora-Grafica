namespace CalculadoraGrafica.Funcao.Gramatica
{
    public abstract class NodoBase
    {
        public NodoBase NodoAnterior { get; set; }
        public string Identificador { get; private set; }
        public readonly bool Folha = false;

        public abstract bool Avaliar();
    }
}