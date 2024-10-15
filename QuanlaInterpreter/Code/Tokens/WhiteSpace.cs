using Steradian.CoreLib.Utils.Colors;
using System.Drawing;

namespace QuanlaInterpreter.Code.Tokens
{
    public class WhiteSpace(Words.WhiteSpace ws)
        : IGenericToken<WhiteSpace>
    {
        public static WhiteSpace? FromCode(string keyword) =>
            keyword switch
            {
                "\t" => new(Words.WhiteSpace.Tab),
                "\n" => new(Words.WhiteSpace.NewLine),
                "\r" => new(Words.WhiteSpace.CarriageReturn),
                _ => null
            };

        public string Word => ws.ToString();

        public List<string> Parameters { get; } = [];

        ConsoleColor IColoredComponent.AssociatedConsoleColor { get; set; } = ConsoleColor.White;
        Color IColoredComponent.AssociatedDrawingColor { get; set; } = Color.White;
    }
}
