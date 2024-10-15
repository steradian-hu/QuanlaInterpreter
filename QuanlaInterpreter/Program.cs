using Steradian.CoreLib.Utils.Extensions;

using QuanlaInterpreter;

static void print(params (object o, bool b)[] obj)
{
    foreach (var (o, b) in obj)
        ConsoleExtension.CPrintLn(o.AsString(recursively: b), ConsoleColor.White);
}

Console.WriteLine("Hello Quanla!");

QProject project = new();
project.DefaultWorkingDirectory();
project.CreateProjectFile();
QFile main = project.CreateDataFile("main", QFile.FileType.Source);

print((project, false));


string content = main.Content;
var tokens = Lexer.Tokenize(content);
tokens = tokens.Where(t => t.Word != "").ToList();

bool showComments = false, showEmptyLines = false;
bool isCommentLine = false;

var prevToken = tokens.First();
foreach (var token in tokens)
{
    if (token.Word == Code.Keyword.Comment.ToString())
        isCommentLine = true;
    else if (isCommentLine)
    {
        if (token.GetType() == typeof(WhiteSpace))
            isCommentLine = false;
        else
            ConsoleExtension.CPrint(showComments ? token.Word + " " : "#", ConsoleColor.DarkGreen);
    }
    else
    {
        if (token.GetType() == typeof(WhiteSpace))
        {
            if ((prevToken.Word == Code.WhiteSpace.NewLine.ToString()) && (token.Word == Code.WhiteSpace.NewLine.ToString()) && !showEmptyLines)
                continue;
            Console.Write(Enum.Parse<Code.WhiteSpace>(token.Word) switch
            {
                Code.WhiteSpace.Tab => "    ",
                Code.WhiteSpace.NewLine => "\n",
                Code.WhiteSpace.CarriageReturn => "\r",
                _ => ""
            });
        }
        else
            ConsoleExtension.CPrint(token.Word + " ", token.AssociatedConsoleColor);
    }
    if (token.Word != Code.WhiteSpace.CarriageReturn.ToString())
        prevToken = token;
}
