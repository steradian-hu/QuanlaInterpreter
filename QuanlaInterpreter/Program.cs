using Steradian.CoreLib.Utils.Extensions;

using QuanlaInterpreter;

void print(params (object o, bool b)[] obj)
{
    foreach (var item in obj)
        ConsoleExtension.CPrintLn(item.o.AsString(recursively: item.b), ConsoleColor.White);
}

Console.WriteLine("Hello Quanla!");

QProject project = new();
project.DefaultWorkingDirectory();
project.CreateProjectFile();
QFile main = project.CreateDataFile("main", QFile.FileType.Source);

print((project, true));

//Execute the source file
string content = main.Content;
