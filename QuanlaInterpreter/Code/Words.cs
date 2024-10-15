using Steradian.CoreLib.Physical.Units;
using Steradian.CoreLib.Physical.Units.Basic;
using Steradian.CoreLib.Physical.Units.Derived;

using Steradian.CoreLib.Utils.Colors;

using System.Drawing;

namespace QuanlaInterpreter.Code
{
    public class Words
    {
        public enum WhiteSpace
        {
            Tab,
            NewLine,
            CarriageReturn
        }

        public enum Keyword
        {
            Namespace,          // namespace
            Comment,            // #
            Unit,               // unit
            Exit                // exit
        }

        public enum Command
        {
            Help,               // help
            Variable,           // var
            Symbol,             // sym
            Equation,           // eqn
            Solve,              // solve
            Print,              // print
            Save,               // save
            Clear               // clear
        }

        public enum Operators
        {
            Equivalent,         // =
            Addition,           // +
            Subtraction,        // -
            Multiplication,     // *
            Power,              // ^
            FractionalDivision, // /
            FloorDivision,      // div
            Modulus,            // mod
            Underscore,         // _
            QuestionMark,       // ?
            Colon,              // :
            Degree,             // °
        }

        public enum Quantities
        {
            One,
            Pressure,
            Length,
            Area, //TODO: Complex quantities should be created by combining basic quantities
            Force
        }

        // Create a variable: var <Quantity>: <variable_name> = <value> <[prefix]<unit>[expression]>
        // Create a symbol: sym <Quantity>: <symbol_name> = ? [[prefix]<unit>[expression]]
        // Create an equation: eqn <eqn_name>: <equation using literals, variables and symbols>
        // Solve an equation: solve <equation> [symbol]
        // Print a variable or symbol: print <variable|symbol> [unit <unit>]
        // Use a command: <command> [arguments]
    }

    public class WhiteSpace(Words.WhiteSpace ws)
        : IGenericToken<WhiteSpace>
    {
        public static WhiteSpace? FromCode(string keyword) =>
            keyword switch
            {
                "\t" => new WhiteSpace(Words.WhiteSpace.Tab),
                "\n" => new WhiteSpace(Words.WhiteSpace.NewLine),
                "\r" => new WhiteSpace(Words.WhiteSpace.CarriageReturn),
                _ => null
            };

        public string Word => ws.ToString();

        ConsoleColor IColoredComponent.AssociatedConsoleColor { get; set; } = ConsoleColor.White;
        Color IColoredComponent.AssociatedDrawingColor { get; set; } = Color.White;
    }

    public class Keyword(Words.Keyword keyword)
        : IGenericToken<Keyword>
    {
        public static Keyword? FromCode(string keyword) =>
            keyword switch
            {
                "namespace" => new Keyword(Words.Keyword.Namespace),
                "#" => new Keyword(Words.Keyword.Comment),
                "unit" => new Keyword(Words.Keyword.Unit),
                "exit" => new Keyword(Words.Keyword.Exit),
                _ => null
            };

        public string Word => keyword.ToString();

        ConsoleColor IColoredComponent.AssociatedConsoleColor { get; set; } = ConsoleColor.DarkBlue;
        Color IColoredComponent.AssociatedDrawingColor { get; set; } = Color.DarkBlue;
    }

    public class Command(Words.Command command)
        : IGenericToken<Command>
    {
        public static Command? FromCode(string keyword) =>
            keyword switch
            {
                "help" => new Command(Words.Command.Help),
                "var" => new Command(Words.Command.Variable),
                "sym" => new Command(Words.Command.Symbol),
                "eqn" => new Command(Words.Command.Equation),
                "solve" => new Command(Words.Command.Solve),
                "print" => new Command(Words.Command.Print),
                "save" => new Command(Words.Command.Save),
                "clear" => new Command(Words.Command.Clear),
                _ => null
            };

        public string Word => command.ToString();

        ConsoleColor IColoredComponent.AssociatedConsoleColor { get; set; } = ConsoleColor.Blue;
        Color IColoredComponent.AssociatedDrawingColor { get; set; } = Color.Blue;
    }

    public class Operator(Words.Operators op)
        : IGenericToken<Operator>
    {
        public static Operator? FromCode(string keyword) =>
            keyword switch
            {
                "=" => new Operator(Words.Operators.Equivalent),
                "+" => new Operator(Words.Operators.Addition),
                "-" => new Operator(Words.Operators.Subtraction),
                "*" => new Operator(Words.Operators.Multiplication),
                "^" => new Operator(Words.Operators.Power),
                "/" => new Operator(Words.Operators.FractionalDivision),
                "div" => new Operator(Words.Operators.FloorDivision),
                "mod" => new Operator(Words.Operators.Modulus),
                "_" => new Operator(Words.Operators.Underscore),
                "?" => new Operator(Words.Operators.QuestionMark),
                ":" => new Operator(Words.Operators.Colon),
                "°" => new Operator(Words.Operators.Degree),
                _ => null
            };

        public string Word => op.ToString();

        ConsoleColor IColoredComponent.AssociatedConsoleColor { get; set; } = ConsoleColor.Yellow;
        Color IColoredComponent.AssociatedDrawingColor { get; set; } = Color.Yellow;
    }

    public class Quantity(Words.Quantities quantity)
        : IGenericToken<Quantity>
    {
        public static Quantity? FromCode(string keyword) =>
            int.TryParse(keyword, out var _) ? null :
            Enum.TryParse<Words.Quantities>(keyword, out var quantity) ?
                new Quantity(quantity) : null;

        public string Word => quantity.ToString();

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

    public class Operand(string str)
        : IToken
    {
        public string Word => str;

        ConsoleColor IColoredComponent.AssociatedConsoleColor { get; set; } = ConsoleColor.Gray;
        Color IColoredComponent.AssociatedDrawingColor { get; set; } = Color.Gray;
    }
}
