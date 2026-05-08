using System.Reflection;
using System.Text.RegularExpressions;
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
            var correspondencia = atributo.Simbolos.Select((simbolo, index) => 
                new {simbolo, index})
                .FirstOrDefault(x => Regex.IsMatch(Texto, x.simbolo));
            if (correspondencia == null)
                return;
            Valor = Enum.ToObject(Tipo, correspondencia.index);
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