using Steradian.CoreLib.Utils.Colors;

namespace QuanlaInterpreter
{
    public interface IToken : IColoredComponent
    {
       string Word { get; }
    }

    public interface IGenericToken<T> : IToken
        where T : IGenericToken<T>
    {
        static abstract T? FromCode(string keyword);
    }

    public class Lexer
    {
        public static IToken? FromCode(string keyword)
        {
            IToken? token = null;
            token ??= WhiteSpace.FromCode(keyword);
            token ??= Keyword.FromCode(keyword);
            token ??= Command.FromCode(keyword);
            token ??= Operator.FromCode(keyword);
            token ??= Quantity.FromCode(keyword);
            token ??= new Operand(keyword);
            return token;
        }

        public static IEnumerable<IToken> Tokenize(string code)
        {
            code = code.Replace("\n", " \n ").Replace("\r", " \r ").Replace("\t", " \t ");
            string[] tokens = code.Split(' ');
            foreach (var token in tokens)
            {
                IToken? t = FromCode(token);
                if (t != null)
                    yield return t;
            }
        }
    }
}
