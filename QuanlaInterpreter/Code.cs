using Steradian.CoreLib.Physical.Units;
using Steradian.CoreLib.Physical.Units.Basic;
using Steradian.CoreLib.Physical.Units.Derived;

using Steradian.CoreLib.Utils.Colors;

using System.Drawing;

namespace QuanlaInterpreter
{
    public class Code
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
            Force
        }

        // Create a variable: var <Quantity>: <variable_name> = <value> <[prefix]<unit>[expression]>
        // Create a symbol: sym <Quantity>: <symbol_name> = ? [[prefix]<unit>[expression]]
        // Create an equation: eqn <eqn_name>: <equation using literals, variables and symbols>
        // Solve an equation: solve <equation> [symbol]
        // Print a variable or symbol: print <variable|symbol> [unit <unit>]
        // Use a command: <command> [arguments]
    }

    public class WhiteSpace(Code.WhiteSpace ws)
        : IGenericToken<WhiteSpace>
    {
        public static WhiteSpace? FromCode(string keyword) =>
            keyword switch
            {
                "\t" => new WhiteSpace(Code.WhiteSpace.Tab),
                "\n" => new WhiteSpace(Code.WhiteSpace.NewLine),
                "\r" => new WhiteSpace(Code.WhiteSpace.CarriageReturn),
                _ => null
            };

        public string Word => ws.ToString();

        ConsoleColor IColoredComponent.AssociatedConsoleColor { get; set; } = ConsoleColor.White;
        Color IColoredComponent.AssociatedDrawingColor { get; set; } = Color.White;
    }

    public class Keyword(Code.Keyword keyword)
        : IGenericToken<Keyword>
    {
        public static Keyword? FromCode(string keyword) =>
            keyword switch
            {
                "namespace" => new Keyword(Code.Keyword.Namespace),
                "#" => new Keyword(Code.Keyword.Comment),
                "unit" => new Keyword(Code.Keyword.Unit),
                "exit" => new Keyword(Code.Keyword.Exit),
                _ => null
            };

        public string Word => keyword.ToString();

        ConsoleColor IColoredComponent.AssociatedConsoleColor { get; set; } = ConsoleColor.DarkBlue;
        Color IColoredComponent.AssociatedDrawingColor { get; set; } = Color.DarkBlue;
    }

    public class Command(Code.Command command)
        : IGenericToken<Command>
    {
        public static Command? FromCode(string keyword) =>
            keyword switch
            {
                "help" => new Command(Code.Command.Help),
                "var" => new Command(Code.Command.Variable),
                "sym" => new Command(Code.Command.Symbol),
                "solve" => new Command(Code.Command.Solve),
                "print" => new Command(Code.Command.Print),
                "save" => new Command(Code.Command.Save),
                "clear" => new Command(Code.Command.Clear),
                _ => null
            };

        public string Word => command.ToString();

        ConsoleColor IColoredComponent.AssociatedConsoleColor { get; set; } = ConsoleColor.Blue;
        Color IColoredComponent.AssociatedDrawingColor { get; set; } = Color.Blue;
    }

    public class Operator(Code.Operators op)
        : IGenericToken<Operator>
    {
        public static Operator? FromCode(string keyword) =>
            keyword switch
            {
                "=" => new Operator(Code.Operators.Equivalent),
                "+" => new Operator(Code.Operators.Addition),
                "-" => new Operator(Code.Operators.Subtraction),
                "*" => new Operator(Code.Operators.Multiplication),
                "^" => new Operator(Code.Operators.Power),
                "/" => new Operator(Code.Operators.FractionalDivision),
                "div" => new Operator(Code.Operators.FloorDivision),
                "mod" => new Operator(Code.Operators.Modulus),
                "_" => new Operator(Code.Operators.Underscore),
                "?" => new Operator(Code.Operators.QuestionMark),
                ":" => new Operator(Code.Operators.Colon),
                "°" => new Operator(Code.Operators.Degree),
                _ => null
            };

        public string Word => op.ToString();

        ConsoleColor IColoredComponent.AssociatedConsoleColor { get; set; } = ConsoleColor.Yellow;
        Color IColoredComponent.AssociatedDrawingColor { get; set; } = Color.Yellow;
    }

    public class Quantity(Code.Quantities quantity)
        : IGenericToken<Quantity>
    {
        public static Quantity? FromCode(string keyword) =>
            int.TryParse(keyword, out var _) ? null :
            Enum.TryParse<Code.Quantities>(keyword, out var quantity) ?
                new Quantity(quantity) : null;

        public string Word => quantity.ToString();

        public IPhysicalUnit GetQuntityUnit() =>
            quantity switch
            {
                Code.Quantities.One => new One(),
                Code.Quantities.Pressure => new Pressure(),
                Code.Quantities.Length => new Length(),
                //Code.Quantities.Force => new Force(),
                _ => throw new System.NotImplementedException("Unknown quantity: " + quantity)
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
