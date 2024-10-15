using Steradian.CoreLib.Utils.Colors;
using System.Drawing;

namespace QuanlaInterpreter.Code.Tokens
{
    public class Nameable(Words.Nameable command)
        : IGenericToken<Nameable>
    {
        public static Nameable? FromCode(string keyword) =>
            keyword switch
            {
                "var" => new(Words.Nameable.Variable),
                "sym" => new(Words.Nameable.Symbol),
                "eqn" => new(Words.Nameable.Equation),
                _ => null
            };

        public string Word => command.ToString();

        public List<string> Parameters { get; } = [];

        ConsoleColor IColoredComponent.AssociatedConsoleColor { get; set; } = ConsoleColor.Blue;
        Color IColoredComponent.AssociatedDrawingColor { get; set; } = Color.Blue;
    }
}
