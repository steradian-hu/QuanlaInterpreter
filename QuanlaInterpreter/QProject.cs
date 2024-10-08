using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace QuanlaInterpreter
{
    public class QProject(string Name = "New Project")
    {
        public string WorkingDirectory { get; set; }
        public List<QFile> Files { get; set; } = [];

        void CreateWorkingDirectory(string workingDirectory)
        {
            if (!Directory.Exists(workingDirectory))
                Directory.CreateDirectory(workingDirectory);
        }
        public string DefaultWorkingDirectory()
        {
            string workingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            workingDirectory = Path.Combine(workingDirectory, "QuanlaProjects");
            CreateWorkingDirectory(workingDirectory);
            WorkingDirectory = workingDirectory;
            return workingDirectory;
        }
    }

    public class QFile
    {
        public enum FileType
        {
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

        public Dictionary<FileType, string> FileExtensions = new Dictionary<FileType, string>
        {
            {FileType.Project, ".qPro"},
            {FileType.Metadata, ".qInf"},
            {FileType.Source, ".qSrc"},
            {FileType.LiveScript, ".qLiv"},
            {FileType.WorkspaceData, ".qBox"}
        };

        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
    }
}
