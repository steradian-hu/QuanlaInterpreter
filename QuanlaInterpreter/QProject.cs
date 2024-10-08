using System.Xml.Linq;

namespace QuanlaInterpreter
{
    public class QProject(string name = "New Project")
    {
        public string Name { get; set; } = name;
        public string WorkingDirectory { get; set; } = string.Empty;
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

        public QFile CreateFile(string name, QFile.FileType fileType)
        {
            QFile file = new(WorkingDirectory)
            {
                Name = name,
                Extension = QFile.FileExtensions[fileType]
            };

            Files.Add(file);
            return file;
        }
        public QFile CreateProjectFile() =>
            CreateFile(Name, QFile.FileType.Project);

        private void UpdateProjectFile()
        {
            QFile projectFile = Files.FirstOrDefault(f => f.Extension == QFile.FileExtensions[QFile.FileType.Project]);
            if (projectFile is null)
                projectFile = CreateProjectFile();

            XDocument doc = new();
            XElement root = new("Project");
            doc.Add(root);

            foreach (var file in Files)
            {
                XElement fileElement = new("File");
                fileElement.Add(new XAttribute("Name", file.Name));
                fileElement.Add(new XAttribute("Extension", file.Extension));
                root.Add(fileElement);
            }

            doc.Save(projectFile.FullPath);
        }

        public QFile CreateDataFile(string name, QFile.FileType type)
        {
            QFile file = CreateFile(name, type);
            UpdateProjectFile();
            file.Create();
            return file;
        }
    }
}
