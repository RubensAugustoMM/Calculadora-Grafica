namespace CalculadoraGrafica.Funcao.Gramatica.Atributos
{
    public class Lexema : Attribute
    {
        public string[] Simbolos;

        public Lexema(params string[] simbolos)
        {
            this.Simbolos = simbolos;
        }
    }
}