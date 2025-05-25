namespace MyTotalCommander.Views
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private PanelTC panelTC1;
        private PanelTC paneltc2;
        private Button copyButton;

        private void InitializeComponent()
        {
            panelTC1 = new PanelTC();
            paneltc2 = new PanelTC();
            copyButton = new Button();
            SuspendLayout();
            // 
            // panelTC1
            // 
            panelTC1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelTC1.Location = new Point(0, 0);
            panelTC1.Name = "panelTC1";
            panelTC1.Size = new Size(400, 500);
            panelTC1.TabIndex = 0;
            // 
            // paneltc2
            // 
            paneltc2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            paneltc2.Location = new Point(400, 0);
            paneltc2.Name = "paneltc2";
            paneltc2.Size = new Size(400, 500);
            paneltc2.TabIndex = 1;
            // 
            // copyButton
            // 
            copyButton.Location = new Point(350, 520);
            copyButton.Name = "copyButton";
            copyButton.Size = new Size(100, 23);
            copyButton.TabIndex = 2;
            copyButton.Text = "Copy >>";
            copyButton.Click += copyButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            MinimumSize = new Size(600, 400);
            Controls.Add(paneltc2);
            Controls.Add(panelTC1);
            Controls.Add(copyButton);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Resize;
            Resize += Form1_Resize;
            ResumeLayout(false);
        }

        // Add this method to Form1.cs to handle resizing and keep panels 50/50 and button in the right place
        private void Form1_Resize(object sender, EventArgs e)
        {
            int halfWidth = ClientSize.Width / 2;
            panelTC1.Location = new Point(0, 0);
            panelTC1.Size = new Size(halfWidth, ClientSize.Height - 100);
            paneltc2.Location = new Point(halfWidth, 0);
            paneltc2.Size = new Size(ClientSize.Width - halfWidth, ClientSize.Height - 100);
            copyButton.Location = new Point(halfWidth - 50, ClientSize.Height - 80);
        }
        
        #endregion

    }
}
