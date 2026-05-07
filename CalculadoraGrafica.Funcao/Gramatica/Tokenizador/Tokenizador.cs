using System.Text.RegularExpressions;

namespace CalculadoraGrafica.Funcao.Gramatica.Tokenizador
{
    public class Tokenizador
    {
        private readonly string _texto;
        public List<Token> Tokens { get; private set; }
        
        public Tokenizador(string texto)
        {
            this._texto = texto;
            Tokens = [];
            ConstrutorDicionario.GerarTokens();
        }

        public List<Token> Tokenizar()
        {
            var subString = _texto;
            int i = 0;
            while ( subString.Length != 0)
            {
                Match? match = null;
                foreach (var keyValuePair in ConstrutorDicionario.Dicionario)
                {
                    match = Regex.Match(subString, "^" + keyValuePair.Key);
                    if (!match.Success)
                        continue;
                    Tokens.Add(new Token(keyValuePair.Value, i,match.Value ));
                    break;
                }

                if (match is { Success: false })
                {
                    subString = subString.Substring(1);
                    i++;
                    continue;
                }
                subString = subString.Substring(match?.Length ?? 0);
                i++;
            }
            return Tokens;
        }
    }
}