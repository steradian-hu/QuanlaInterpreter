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
            Exit,               // exit
            Help,               // help
            Solve,              // solve - solve an equation, the result symbol wil be converted into a variable
            Expression,         // expr - evaluate an expression
            Edge,               // edge - create an edge between two symbols
            Print,              // print
            Save,               // save
            Clear               // clear
        }

        public enum Nameable
        {
            Variable,           // var
            Symbol,             // sym
            Equation            // eqn
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
            Factorial,          // !
            Root,               // √
            EdgeTo,             // ->
            EdgeFrom,           // <-
            EdgeBoth            // <->
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
}
