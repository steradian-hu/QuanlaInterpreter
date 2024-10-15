namespace QuanlaInterpreter.Files
{
    public class QFile(string workingDirectory)
    {
        public enum FileType
        {
            /// <summary> .quanla - Quanla, a non-structured file of a Quanla program </summary>
            Quanla,

            /// <summary>.qPro - Project, contains all the linking informations for the files in the project</summary>
            Project,

            /// <summary>.qInf - Metadata, contains comments and other documenting infromations for the language elements like functions, classes, etc.</summary>
            Metadata,

            /// <summary>.qSrc - Source, contains the source code of a Quanla program</summary>
            Source,

            /// <summary>.qLiv - Live Script, contains the source code of a Quanla program that is to be executed in a live environment (presentation, TeX, figures etc.)</summary>
            LiveScript,

            /// <summary>.qBox - Workspace data, contains the data of a workspace, like variables or equations</summary>
            WorkspaceData
        }

        public const string DefaultExtension = ".quanla";

        public static readonly Dictionary<FileType, string> FileExtensions = new()
        {
            {FileType.Quanla, DefaultExtension},
            {FileType.Project, ".qPro"},
            {FileType.Metadata, ".qInf"},
            {FileType.Source, ".qSrc"},
            {FileType.LiveScript, ".qLiv"},
            {FileType.WorkspaceData, ".qBox"}
        };

        public string Name { get; set; } = string.Empty;
        public string Extension { get; set; } = DefaultExtension;

        public string FullName =>
            Name + Extension;
        public string FullPath =>
            Path.Combine(workingDirectory, FullName);

        public void Create()
        {
            if (!Exists)
                File.Create(FullPath);
        }

        public bool Exists =>
            File.Exists(FullPath);

        public string Content =>
            Exists ? File.ReadAllText(FullPath) : string.Empty;
    }
}
