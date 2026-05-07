using System.Reflection;
using CalculadoraGrafica.Funcao.Gramatica.Atributos;

namespace CalculadoraGrafica.Funcao.Gramatica.Tokenizador;

public record Token
{
    public Type Tipo { get; private set; }
    public int Posicao { get; private set; }
    public string Texto { get; private set; }
    public object Valor { get; private set; }
    
    public Token(Type tipo, int posicao, string texto)
    {
        this.Tipo = tipo;
        this.Posicao = posicao;
        this.Texto = texto;
        AtribuirValor();
    }

    private void AtribuirValor()
    {
        if (float.TryParse(Texto, out var valor))
        {
            Valor = valor;
            return;
        }
        
        if (Tipo.IsEnum)
        {
            var atributo = Tipo.GetCustomAttribute<Lexema>();
            if (atributo == null)
                return;
            var i = atributo.Simbolos.Select(x => x == Texto).Index().FirstOrDefault();
            var instancia = Enum.ToObject(Tipo, i.Index);
            if (instancia == null)
                return;
            Valor = instancia;
            return;
        }

        if (Tipo.IsClass)
        {
            var atributos = Tipo.GetProperties()
                .Where(x => x.GetCustomAttribute<Lexema>() != null);
            var instancia = Activator.CreateInstance(Tipo); 
            var campo = atributos.Where(x => 
                x.GetValue(instancia)  == Texto).FirstOrDefault();
            if (campo == null)
                return;
            Valor = campo.GetValue(instancia);
            return;
        }
    }
}