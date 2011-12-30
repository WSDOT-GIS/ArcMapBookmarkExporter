namespace BookmarkExporterAddIn
{
    partial class BookmarkExporterWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._directoryTextBox = new System.Windows.Forms.TextBox();
            this._directoryButton = new System.Windows.Forms.Button();
            this.exportFormatComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._exportButton = new System.Windows.Forms.Button();
            this._dpiNud = new System.Windows.Forms.NumericUpDown();
            this._dpiLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._dpiNud)).BeginInit();
            this.SuspendLayout();
            // 
            // _directoryTextBox
            // 
            this._directoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._directoryTextBox.Location = new System.Drawing.Point(4, 23);
            this._directoryTextBox.Name = "_directoryTextBox";
            this._directoryTextBox.Size = new System.Drawing.Size(212, 20);
            this._directoryTextBox.TabIndex = 0;
            // 
            // _directoryButton
            // 
            this._directoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._directoryButton.Location = new System.Drawing.Point(222, 23);
            this._directoryButton.Name = "_directoryButton";
            this._directoryButton.Size = new System.Drawing.Size(75, 23);
            this._directoryButton.TabIndex = 1;
            this._directoryButton.Text = "Directory";
            this._directoryButton.UseVisualStyleBackColor = true;
            this._directoryButton.Click += new System.EventHandler(this._directoryButton_Click);
            // 
            // exportFormatComboBox
            // 
            this.exportFormatComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exportFormatComboBox.FormattingEnabled = true;
            this.exportFormatComboBox.Location = new System.Drawing.Point(82, 49);
            this.exportFormatComboBox.Name = "exportFormatComboBox";
            this.exportFormatComboBox.Size = new System.Drawing.Size(215, 21);
            this.exportFormatComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Export Format";
            // 
            // _exportButton
            // 
            this._exportButton.Location = new System.Drawing.Point(222, 78);
            this._exportButton.Name = "_exportButton";
            this._exportButton.Size = new System.Drawing.Size(75, 23);
            this._exportButton.TabIndex = 4;
            this._exportButton.Text = "Export";
            this._exportButton.UseVisualStyleBackColor = true;
            this._exportButton.Click += new System.EventHandler(this._exportButton_Click);
            // 
            // _dpiNud
            // 
            this._dpiNud.Location = new System.Drawing.Point(38, 81);
            this._dpiNud.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this._dpiNud.Name = "_dpiNud";
            this._dpiNud.Size = new System.Drawing.Size(120, 20);
            this._dpiNud.TabIndex = 5;
            this._dpiNud.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // _dpiLabel
            // 
            this._dpiLabel.AutoSize = true;
            this._dpiLabel.Location = new System.Drawing.Point(7, 83);
            this._dpiLabel.Name = "_dpiLabel";
            this._dpiLabel.Size = new System.Drawing.Size(25, 13);
            this._dpiLabel.TabIndex = 6;
            this._dpiLabel.Text = "DPI";
            // 
            // BookmarkExporterWindow
            // 
            this.Controls.Add(this._dpiLabel);
            this.Controls.Add(this._dpiNud);
            this.Controls.Add(this._exportButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exportFormatComboBox);
            this.Controls.Add(this._directoryButton);
            this.Controls.Add(this._directoryTextBox);
            this.Name = "BookmarkExporterWindow";
            this.Size = new System.Drawing.Size(300, 300);
            this.Load += new System.EventHandler(this.BookmarkExporterWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this._dpiNud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _directoryTextBox;
        private System.Windows.Forms.Button _directoryButton;
        private System.Windows.Forms.ComboBox exportFormatComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _exportButton;
        private System.Windows.Forms.NumericUpDown _dpiNud;
        private System.Windows.Forms.Label _dpiLabel;

    }
}
