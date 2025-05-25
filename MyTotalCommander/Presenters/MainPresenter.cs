using MyTotalCommander.Models;
using MyTotalCommander.Views;

namespace MyTotalCommander.Presenters
{
    public class MainPresenter
    {
        private readonly Form1 _view;

        private List<string> _availableDrives = [];
        private string _currentPath = string.Empty;

        public MainPresenter(Form1 view)
        {
            _view = view;
            Initialize();
        }

        private void Initialize()
        {
            _view.Panel1.PopulateDrivesRequested += OnPopulateDrivesRequested;
            _view.Panel2.PopulateDrivesRequested += OnPopulateDrivesRequested;

            _view.Panel1.CurrentPathChanged += OnCurrentPathChanged;
            _view.Panel2.CurrentPathChanged += OnCurrentPathChanged;

            _view.CopyFile += CopySelectedFile;
        }

        private void CopySelectedFile()
        {
            var fileToCopy = _view.Panel1.SelectedFile;
            if (fileToCopy is null)
            {
                MessageBox.Show("Nie wybrano pliku do przekopiowania", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                fileToCopy.CopyTo(_view.Panel2.CurrentPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas kopiowania pliku {fileToCopy.Name}", $"Error - {ex.Message}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PopulateListBoxContent(_view.Panel2, _view.Panel2.CurrentPath);

        }

        private void OnPopulateDrivesRequested(PanelTC panel)
        {
            _availableDrives = Directory.GetLogicalDrives().ToList();
            panel.AvailableDrives = _availableDrives;
        }

        private void OnCurrentPathChanged(PanelTC panel, string newPath)
        {
            if (Directory.Exists(newPath))
            {
                _currentPath = newPath;
                panel.CurrentPath = _currentPath;
                PopulateListBoxContent(panel, _currentPath);
            }
            else
            {
                MessageBox.Show("The specified path does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PopulateListBoxContent(PanelTC panel, string path)
        {
            if (Directory.Exists(path))
            {
                var files = GetFilesFromDirectory(path);
                var directories = GetDirectoriesFromPath(path);

                // Add parent directory element
                var parentPath = Directory.GetParent(path)?.FullName ?? string.Empty;
                if (!string.IsNullOrEmpty(parentPath))
                {
                    var parentDirectory = new DirectoryElement(parentPath, "..");

                    directories = directories.Prepend(parentDirectory).ToList();
                }

                panel.CurrentDirectoryContent = directories.Cast<IDirectoryElement>().Concat(files).ToList();
            }
            else
            {
                MessageBox.Show("The specified path does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<FileElement> GetFilesFromDirectory(string path)
        {
            return Directory.GetFiles(path).Select(f => new FileElement(f)).OrderBy(x => x.IsHidden).ThenBy(x => x.Name).ToList();
        }
        private List<DirectoryElement> GetDirectoriesFromPath(string path)
        {
            return Directory.GetDirectories(path).Select(d => new DirectoryElement(d)).OrderBy(x => x.IsHidden).ThenBy(x => x.Name).ToList();
        }
    }
}
