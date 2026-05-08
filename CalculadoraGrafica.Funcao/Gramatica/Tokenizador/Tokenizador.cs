using System.Text.RegularExpressions;

namespace CalculadoraGrafica.Funcao.Gramatica.Tokenizador
{
    public class Tokenizador
    {
        private readonly string _texto;
        private int Posicao;
        public List<Token> Tokens { get; private set; }
        
        public Tokenizador(string texto)
        {
            this._texto = texto;
            Tokens = [];
            ConstrutorDicionario.GerarTokens();
        }

        public List<Token> Tokenizar()
        {
            Posicao = 0;
            while ( Posicao < _texto.Length )
            {
                Match? match = null;
                foreach (var keyValuePair in ConstrutorDicionario.Dicionario)
                {
                    match = Regex.Match(_texto.Substring(Posicao), "^" + keyValuePair.Key);
                    if (!match.Success)
                        continue;
                    Tokens.Add(new Token(keyValuePair.Value, Posicao,match.Value ));
                    break;
                }

                Posicao++;
            }
            return Tokens;
        }
    }
}