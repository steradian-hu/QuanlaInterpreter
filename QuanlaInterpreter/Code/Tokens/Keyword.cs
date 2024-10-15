using Steradian.CoreLib.Utils.Colors;
using System.Drawing;

namespace QuanlaInterpreter.Code.Tokens
{
    public class Keyword(Words.Keyword keyword)
        : IGenericToken<Keyword>
    {
        public static Keyword? FromCode(string keyword) =>
            keyword switch
            {
                "namespace" => new(Words.Keyword.Namespace),
                "#" => new(Words.Keyword.Comment),
                "unit" => new(Words.Keyword.Unit),
                "exit" => new(Words.Keyword.Exit),
                "help" => new(Words.Keyword.Help),
                "solve" => new(Words.Keyword.Solve),
                "expr" => new(Words.Keyword.Expression),
                "edge" => new(Words.Keyword.Edge),
                "print" => new(Words.Keyword.Print),
                "save" => new(Words.Keyword.Save),
                "clear" => new(Words.Keyword.Clear),
                _ => null
            };

        public string Word => keyword.ToString() + "[" + Parameters.Count + "]";

        public List<string> Parameters { get; } = [];

        ConsoleColor IColoredComponent.AssociatedConsoleColor { get; set; } = ConsoleColor.DarkBlue;
        Color IColoredComponent.AssociatedDrawingColor { get; set; } = Color.DarkBlue;
    }
}
