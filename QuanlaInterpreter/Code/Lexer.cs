using QuanlaInterpreter.Code.Tokens;

using Steradian.CoreLib.Utils.Extensions;

namespace QuanlaInterpreter.Code
{
    public class Lexer
    {
        //TODO: The functions shouldn't be statics, but they should fill these lists
        //TODO: Implement a solution for loading modules of keywords/non-main source files
        //private readonly List<ILiteralToken> literalTokens = [];
        //private readonly List<IUserDefinedToken> udefTokens = [];
        //private readonly List<IToken> unknownTokens = [];

        public static IToken? FromCode(string keyword)
        {
            IToken? token = null;
            token ??= WhiteSpace.FromCode(keyword);
            token ??= Keyword.FromCode(keyword);
            token ??= Nameable.FromCode(keyword);
            token ??= Operator.FromCode(keyword);
            token ??= Quantity.FromCode(keyword);
            //token ??= new Operand(keyword);
            return token;
        }

        public static IEnumerable<IToken> Tokenize(string code)
        {
            List<IToken> tokens = [];

            code = code
                .Replace("\n", " \n ")
                .Replace("\r", " \r ")
                .Replace("\t", " \t ")
                .Replace(":", " : ");

            string[] rawTokens = code.Split(' ');

            bool inNameableContext = false;
            bool isCommentcontext = false;
            bool isParameterableContext = false;
            bool createdNameable = false;

            foreach (string rawToken in rawTokens)
            {
                IToken? token = FromCode(rawToken);
                Type? type = token?.GetType();

                if (!isCommentcontext)
                    isCommentcontext = (type == typeof(Keyword) && token!.Word == Words.Keyword.Comment.ToString());
                if (isCommentcontext)
                    isCommentcontext = (type != typeof(WhiteSpace));
                if (isCommentcontext)
                    continue;

                if (!isParameterableContext)
                    isParameterableContext = (type == typeof(Keyword));
                if (isParameterableContext)
                    isParameterableContext = (type != typeof(WhiteSpace));
                if (isParameterableContext)
                {
                    //TODO: Filter out the comments and the amount of added parameters are NOT OK!
                    IToken? found = tokens.LastOrDefault(t => t.GetType() == typeof(Keyword));
                    if (found != null)
                    {
                        if (token != null && token.Word != Words.Keyword.Comment.ToString())
                            if (!string.IsNullOrWhiteSpace(rawToken))
                                (found as Keyword)?.Parameters.Add(rawToken);
                    }
                }

                if (!inNameableContext)
                    inNameableContext = (type == typeof(Nameable));
                if (inNameableContext)
                    inNameableContext = (type != typeof(WhiteSpace));
                if (inNameableContext && !string.IsNullOrWhiteSpace(rawToken))
                {
                    //BUGFIX: Sometimes it not recognize the new variable, but finds Nameables instead of variables
                    IToken? found = tokens.Find(t => t.GetType() == typeof(Variable<object>) && t.Word == rawToken);                  
                    if (found == null && !createdNameable)
                    {
                        var newToken = new Variable<object>(rawToken);
                        token ??= found ?? newToken;
                        createdNameable = true;
                        ConsoleExtension.CPrint(rawToken + " ", ConsoleColor.Red);
                    }
                    else
                        token ??= found;
                }
                else
                    createdNameable = false;

                token ??= new Operand(rawToken);

                if (token != null)
                    tokens.Add(token);
            }

            return tokens;
        }

        public static IEnumerable<IToken> FilterEmptyLines(IEnumerable<IToken> tokens) =>
            tokens.Where(t => t.Word != "");
    }
}
