using MyTotalCommander.Models;
using System.ComponentModel;
using System.Data;

namespace MyTotalCommander.Views
{
    public partial class PanelTC : UserControl
    {
        public PanelTC()
        {
            InitializeComponent();
        }


        #region public interface
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CurrentPath
        {
            get { return txtCurrentPath.Text; }
            set { txtCurrentPath.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<string> AvailableDrives
        {
            get
            {
                return cboDrives.Items.Cast<string>();
            }
            set
            {
                cboDrives.Items.Clear();
                foreach (var drive in value)
                {
                    cboDrives.Items.Add(drive);
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<IDirectoryElement> CurrentDirectoryContent
        {
            get
            {
                return lstContent.Items.Cast<IDirectoryElement>();
            }
            set
            {
                lstContent.Items.Clear();
                foreach (var element in value)
                {
                    lstContent.Items.Add(element);
                }
            }
        }

        public FileElement? SelectedFile
        {
            get
            {
                return lstContent.SelectedItem as FileElement;
            }
        }

        public event Action<PanelTC> PopulateDrivesRequested;
        public event Action<PanelTC, string> CurrentPathChanged;
        #endregion

        private void cboDrives_DropDown(object sender, EventArgs e)
        {
            PopulateDrivesRequested?.Invoke(this);
        }

        private void cboDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPathChanged?.Invoke(this, cboDrives.SelectedItem?.ToString() ?? string.Empty);
        }

        private void lstContent_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedElement = (sender as ListBox)?.SelectedItem as DirectoryElement;

            if (selectedElement is not null)
            {
                // If the selected element is a directory, change the current path
                CurrentPathChanged?.Invoke(this, selectedElement.FullPath);
            }
        }
    }
}
