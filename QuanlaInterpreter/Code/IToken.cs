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
    }
}
