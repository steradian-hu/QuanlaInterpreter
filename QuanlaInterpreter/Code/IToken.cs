using Steradian.CoreLib.Utils.Colors;

namespace QuanlaInterpreter.Code
{
    public interface IToken : IColoredComponent
    {
        string Word { get; }
    }

    public interface IGenericToken<T> : IToken
        where T : IGenericToken<T>
    {
        static abstract T? FromCode(string keyword);

        List<string> Parameters { get; }
    }

    public interface IUserDefinedToken : IToken
    {
        string Name { get; }
    }

    public interface ILiteralToken : IToken
    {
        string Value { get; }
    }
}
