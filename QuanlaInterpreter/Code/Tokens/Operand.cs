using Steradian.CoreLib.Utils.Colors;
using System.Drawing;

namespace QuanlaInterpreter.Code.Tokens
{
    public class Operand(string str)
        : IToken
    {
        public string Word => str;

        ConsoleColor IColoredComponent.AssociatedConsoleColor { get; set; } = ConsoleColor.Gray;
        Color IColoredComponent.AssociatedDrawingColor { get; set; } = Color.Gray;
    }
}
