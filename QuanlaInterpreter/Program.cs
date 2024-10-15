using QuanlaInterpreter.Code;
using QuanlaInterpreter.Files;
using QuanlaInterpreter.Helpers;

ConfigHint config = new()
{
    ShowComments = false,
    ShowEmptyLines = false,

    CommentReplacement = ""
};

Print.HelloWorld();

QProject project = new();
project.DefaultWorkingDirectory();
project.CreateProjectFile();
QFile main = project.CreateDataFile("main", QFile.FileType.Source);
//Print.PrintLn((project, false));

string content = main.Content;
var tokens = Lexer.FilterEmptyLines(Lexer.Tokenize(content));

Print.Tokens(tokens, config);
