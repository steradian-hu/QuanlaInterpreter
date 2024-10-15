using Steradian.CoreLib.Utils.Colors;
using System.Drawing;

namespace QuanlaInterpreter.Code
{
    public class Variable<T>(string name)
        : IUserDefinedToken
    {
        public string Name => name;
        public T? Value { get; }

        string IToken.Word => name;

        ConsoleColor IColoredComponent.AssociatedConsoleColor { get; set; } = ConsoleColor.DarkYellow;
        Color IColoredComponent.AssociatedDrawingColor { get; set; } = Color.Orange;
    }
}
