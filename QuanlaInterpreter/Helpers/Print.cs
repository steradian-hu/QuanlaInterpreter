using QuanlaInterpreter.Code;
using Steradian.CoreLib.Utils.Colors;
using Steradian.CoreLib.Utils.Extensions;
using System.Reflection;

namespace QuanlaInterpreter.Helpers
{
    public static class Print
    {
        private static readonly ColoredString hello = new(Assembly.GetExecutingAssembly().GetName().Version!.ToString())
        {
            AssociatedConsoleColor = ConsoleColor.DarkCyan
        };

        public static void HelloWorld() =>
            ConsoleExtension.CPrintLnCC((
                StringExtension.Header([
                    "Quanla Interpreter",
                            "Version " + hello.String,
                            string.Empty,
                            "STERADIAN mernokiroda (Fodor Attila EV.)",
                ], 40), hello));

        public static void PrintLn(params (object o, bool b)[] obj)
        {
            foreach (var (o, b) in obj)
                ConsoleExtension.CPrintLn(o.AsString(recursively: b), ConsoleColor.White);
        }

        public static void Tokens(IEnumerable<IToken> tokens, ConfigHint hint)
        {
            bool isCommentLine = false;

            var prevToken = tokens.First();
            foreach (var token in tokens)
            {
                if (token.Word == Words.Keyword.Comment.ToString())
                    isCommentLine = true;
                else if (isCommentLine)
                {
                    if (token.GetType() == typeof(WhiteSpace))
                        isCommentLine = false;
                    else
                        ConsoleExtension.CPrint(hint.ShowComments ? token.Word + " " : hint.CommentReplacement, ConsoleColor.DarkGreen);
                }
                else
                {
                    if (token.GetType() == typeof(WhiteSpace))
                    {
                        if ((prevToken.Word == Words.WhiteSpace.NewLine.ToString()) && (token.Word == Words.WhiteSpace.NewLine.ToString()) && !hint.ShowEmptyLines)
                            continue;
                        Console.Write(Enum.Parse<Words.WhiteSpace>(token.Word) switch
                        {
                            Words.WhiteSpace.Tab => "    ",
                            Words.WhiteSpace.NewLine => "\n",
                            Words.WhiteSpace.CarriageReturn => "\r",
                            _ => ""
                        });
                    }
                    else
                        ConsoleExtension.CPrint(token.Word + " ", token.AssociatedConsoleColor);
                }
                if (token.Word != Words.WhiteSpace.CarriageReturn.ToString())
                    prevToken = token;
            }
        }
    }
}
