namespace MyTotalCommander.Views
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region public interface 
        public PanelTC Panel1
        {
            get { return panelTC1; }
        }
        public PanelTC Panel2
        {
            get { return paneltc2; }
        }


        #endregion

        public Action CopyFile;

        private void copyButton_Click(object sender, EventArgs e)
        {
            CopyFile?.Invoke();
        }
    }
}
