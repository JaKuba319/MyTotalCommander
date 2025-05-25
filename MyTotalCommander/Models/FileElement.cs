
namespace MyTotalCommander.Models
{
    public class FileElement : IDirectoryElement
    {
        public FileElement(string fullPath)
        {
            FullPath = fullPath;
            Name = Path.GetFileName(fullPath);
            IsHidden = (new FileInfo(fullPath).Attributes & FileAttributes.Hidden) != 0;
        }
        public string Name { get; }
        public string FullPath { get; }
        public bool IsHidden
        {
            get;
        }

        public override string ToString()
        {
            return IsHidden ? $"{Name} - hidden" : Name;
        }

        public void CopyTo(string destinationPath)
        {
            if (string.IsNullOrEmpty(destinationPath))
            {
                throw new ArgumentException("Destination path cannot be null or empty.", nameof(destinationPath));
            }
            var destinationFile = Path.Combine(destinationPath, Name);

            File.Copy(FullPath, destinationFile, false);

        }
    }
}