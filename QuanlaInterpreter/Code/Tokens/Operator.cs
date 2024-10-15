using Steradian.CoreLib.Utils.Colors;
using System.Drawing;

namespace QuanlaInterpreter.Code.Tokens
{
    public class Operator(Words.Operators op)
        : IGenericToken<Operator>
    {
        public static Operator? FromCode(string keyword) =>
            keyword switch
            {
                "=" => new(Words.Operators.Equivalent),
                "+" => new(Words.Operators.Addition),
                "-" => new(Words.Operators.Subtraction),
                "*" => new(Words.Operators.Multiplication),
                "^" => new(Words.Operators.Power),
                "/" => new(Words.Operators.FractionalDivision),
                "div" => new(Words.Operators.FloorDivision),
                "mod" => new(Words.Operators.Modulus),
                "_" => new(Words.Operators.Underscore),
                "?" => new(Words.Operators.QuestionMark),
                ":" => new(Words.Operators.Colon),
                "°" => new(Words.Operators.Degree),
                "!" => new(Words.Operators.Factorial),
                "√" => new(Words.Operators.Root),
                "->" => new(Words.Operators.EdgeTo),
                "<-" => new(Words.Operators.EdgeFrom),
                "<->" => new(Words.Operators.EdgeBoth),
                _ => null
            };

        public string Word => op.ToString();

        public List<string> Parameters { get; } = [];

        ConsoleColor IColoredComponent.AssociatedConsoleColor { get; set; } = ConsoleColor.Yellow;
        Color IColoredComponent.AssociatedDrawingColor { get; set; } = Color.Yellow;
    }
}
