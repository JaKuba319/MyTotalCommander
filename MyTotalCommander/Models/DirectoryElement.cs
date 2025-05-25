namespace MyTotalCommander.Models
{
    public class DirectoryElement : IDirectoryElement
    {
        public DirectoryElement(string fullPath, string name)
        {
            Name = name;
            FullPath = fullPath;
            IsHidden = false;
        }
        public DirectoryElement(string fullPath)
        {
            FullPath = fullPath;
            Name = Path.GetFileName(fullPath);
            IsHidden = (new DirectoryInfo(fullPath).Attributes & FileAttributes.Hidden) != 0;
        }
        public string Name { get; }
        public string FullPath { get; }
        public bool IsHidden { get; }
        public override string ToString()
        {
            return IsHidden ? $"<D>{Name} - hidden" : $"<D>{Name}";
        }
    }
}