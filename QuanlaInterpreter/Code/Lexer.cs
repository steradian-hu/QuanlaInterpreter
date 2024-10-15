namespace QuanlaInterpreter.Code
{
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
            code = code
                .Replace("\n", " \n ")
                .Replace("\r", " \r ")
                .Replace("\t", " \t ")
                .Replace(":", " : ");

            string[] tokens = code.Split(' ');
            foreach (var token in tokens)
            {
                IToken? t = FromCode(token);
                if (t != null)
                    yield return t;
            }
        }

        public static IEnumerable<IToken> FilterEmptyLines(IEnumerable<IToken> tokens) =>
            tokens.Where(t => t.Word != "");
    }
}
