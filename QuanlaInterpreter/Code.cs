namespace QuanlaInterpreter
{
    public class Code
    {
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
}
