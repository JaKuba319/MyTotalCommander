
using MyTotalCommander.Models;

namespace MyTotalCommander.Views
{
    public partial class PanelTC
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Deklaracje kontrolek
        private ComboBox cboDrives;
        private TextBox txtCurrentPath;
        private ListBox lstContent;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; w przeciwnym razie fałsz.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            cboDrives = new ComboBox();
            txtCurrentPath = new TextBox();
            lstContent = new ListBox();
            SuspendLayout();
            // 
            // cboDrives
            // 
            cboDrives.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboDrives.FormattingEnabled = true;
            cboDrives.Location = new Point(10, 10);
            cboDrives.Name = "cboDrives";
            cboDrives.Size = new Size(411, 23);
            cboDrives.TabIndex = 0;
            cboDrives.DropDown += cboDrives_DropDown;
            cboDrives.SelectedIndexChanged += cboDrives_SelectedIndexChanged;
            // 
            // txtCurrentPath
            // 
            txtCurrentPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCurrentPath.Location = new Point(10, 40);
            txtCurrentPath.Name = "txtCurrentPath";
            txtCurrentPath.ReadOnly = true;
            txtCurrentPath.Enabled = false;
            txtCurrentPath.Size = new Size(411, 23);
            txtCurrentPath.TabIndex = 1;
            // 
            // lstContent
            // 
            lstContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstContent.FormattingEnabled = true;
            lstContent.Location = new Point(10, 70);
            lstContent.Name = "lstContent";
            lstContent.Size = new Size(411, 469);
            lstContent.TabIndex = 2;
            lstContent.SelectedValueChanged += lstContent_SelectedValueChanged;
            // Add this after lstContent initialization in InitializeComponent
            lstContent.DrawMode = DrawMode.OwnerDrawFixed;
            lstContent.DrawItem += lstContent_DrawItem;


            // 
            // PanelTC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lstContent);
            Controls.Add(txtCurrentPath);
            Controls.Add(cboDrives);
            Name = "PanelTC";
            Size = new Size(431, 556);
            ResumeLayout(false);
            PerformLayout();
        }

        // Add this method to the PanelTC partial class (outside InitializeComponent)
        private void lstContent_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var item = lstContent.Items[e.Index] as IDirectoryElement;
            if (item == null)
            {
                e.DrawBackground();
                return;
            }

            Color foreColor = SystemColors.ControlText;
            Font font = lstContent.Font;

            if (item is DirectoryElement)
            {
                font = new Font(lstContent.Font, FontStyle.Bold);
            }
            else if (item.Name.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                foreColor = Color.Black;
            }
            else if (item.Name.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                foreColor = Color.FromArgb(180, 0, 0);
            }
            else if (item.Name.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
            {
                foreColor = Color.FromArgb(0, 0, 180);
            }
            else if (item.Name.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                     item.Name.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                     item.Name.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
            {
                foreColor = Color.FromArgb(0, 180, 0);
            }
            else if(item.Name.EndsWith(".zip", StringComparison.OrdinalIgnoreCase) || 
                    item.Name.EndsWith(".tar", StringComparison.OrdinalIgnoreCase) ||
                    item.Name.EndsWith(".gz", StringComparison.OrdinalIgnoreCase))
            {
                foreColor = Color.FromArgb(100, 0, 100);
            }

            if (item.IsHidden )
            {
                foreColor = Color.DarkGray;
                font = new Font(lstContent.Font, FontStyle.Italic);
            }


            e.DrawBackground();
            using (var brush = new SolidBrush(foreColor))
            {
                e.Graphics.DrawString(item.ToString(), font, brush, e.Bounds);
            }
            e.DrawFocusRectangle();
        }

        #endregion
    }
}
