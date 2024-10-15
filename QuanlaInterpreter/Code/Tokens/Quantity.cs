using Steradian.CoreLib.Physical.Units.Basic;
using Steradian.CoreLib.Physical.Units.Derived;
using Steradian.CoreLib.Physical.Units;

using Steradian.CoreLib.Utils.Colors;
using System.Drawing;

namespace QuanlaInterpreter.Code.Tokens
{
    public class Quantity(Words.Quantities quantity)
    : IGenericToken<Quantity>
    {
        public static Quantity? FromCode(string keyword) =>
            int.TryParse(keyword, out var _) ? null :
            Enum.TryParse<Words.Quantities>(keyword, out var quantity) ?
                new(quantity) : null;

        public string Word => quantity.ToString();

        public List<string> Parameters { get; } = [];

        public IPhysicalUnit GetQuntityUnit() =>
            quantity switch
            {
                Words.Quantities.One => new One(),
                Words.Quantities.Pressure => new Pressure(),
                Words.Quantities.Length => new Length(),
                //Code.Quantities.Force => new Force(),
                _ => throw new NotImplementedException("Unknown quantity: " + quantity)
            };

        ConsoleColor IColoredComponent.AssociatedConsoleColor { get; set; } = ConsoleColor.Cyan;
        Color IColoredComponent.AssociatedDrawingColor { get; set; } = Color.Cyan;
    }
}
