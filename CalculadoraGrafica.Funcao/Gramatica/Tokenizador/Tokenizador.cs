using System.Reflection;
using CalculadoraGrafica.Funcao.Gramatica.Atributos;

namespace CalculadoraGrafica.Funcao.Gramatica.Tokenizador;

public class Tokenizador
{
    private readonly string _texto;
    private Dictionary<string, Type> _tokens;

    public Tokenizador(string texto)
    {
        this._texto = texto;
        ObterTokens();
        foreach(var token in _tokens)
            Console.WriteLine($"{token.Key}: {token.Value}");
    }

    private void ObterTokens()
    {
        _tokens = new Dictionary<string, Type>();
        
        var tipos = typeof(NodoBase).Assembly.GetTypes()
            .Where(x => x.IsClass || x.IsEnum)
            .ToArray();

        foreach (var tipo in tipos.Where(x => x.IsClass && x.GetCustomAttribute<Lexema>() != null))
        {
            if(tipo.BaseType != typeof(NodoBase))
                continue;
            
            var propriedadeDefinicao = tipo.GetProperty(nameof(NodoBase.Definicoes));
            if (propriedadeDefinicao == null)
                continue;
            
            var instancia = Activator.CreateInstance(tipo);
            if (propriedadeDefinicao.GetValue(instancia) is not string[][] definicoes)
                continue;
            if (definicoes.Length != 1)
                continue;
            if(definicoes[0].Length != 1)
                continue;
            _tokens[definicoes[0][0]] = tipo; 
        }

        foreach (var tipo in tipos.Where(x => x.IsEnum && x.GetCustomAttribute<Lexema>() != null))
        {
            var simbolos = tipo.GetCustomAttribute<Lexema>()?.Simbolos;
            if (simbolos == null || simbolos.Length == 0)
                continue;
            var valores = Enum.GetNames(tipo);
            if(valores.Length == 0)
                continue;
            if(valores.Length != simbolos.Length) 
                continue;
            
            for(int i = 0; i < valores.Length; i++)
                _tokens[simbolos[i]] = tipo;
        }

        foreach (var tipo in tipos.Where(x => x.IsClass && x.GetCustomAttribute<Lexema>() == null))
        {
            var propriedades = tipo.GetProperties()
                .Where(x => x.GetCustomAttribute<Lexema>() != null)
                .ToArray();
            if (propriedades.Length != 1)
                continue;
            foreach (var propriedade in propriedades)
            {
                var valor = propriedade.GetValue(Activator.CreateInstance(tipo));
                if(valor is string texto) 
                    _tokens[texto] = tipo;
            }
        }
    }
}