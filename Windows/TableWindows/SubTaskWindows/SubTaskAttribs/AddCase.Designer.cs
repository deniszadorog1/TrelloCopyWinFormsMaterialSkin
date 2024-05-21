namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs
{
    partial class AddCase
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
            this.CaseNameLB = new MaterialSkin.Controls.MaterialLabel();
            this.CaseNameBox = new MaterialSkin.Controls.MaterialTextBox2();
            this.AddBut = new MaterialSkin.Controls.MaterialButton();
            this.BackBut = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // CaseNameLB
            // 
            this.CaseNameLB.AutoSize = true;
            this.CaseNameLB.Depth = 0;
            this.CaseNameLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.CaseNameLB.Location = new System.Drawing.Point(16, 95);
            this.CaseNameLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.CaseNameLB.Name = "CaseNameLB";
            this.CaseNameLB.Size = new System.Drawing.Size(80, 19);
            this.CaseNameLB.TabIndex = 0;
            this.CaseNameLB.Text = "Case name";
            // 
            // CaseNameBox
            // 
            this.CaseNameBox.AnimateReadOnly = false;
            this.CaseNameBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CaseNameBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CaseNameBox.Depth = 0;
            this.CaseNameBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.CaseNameBox.HideSelection = true;
            this.CaseNameBox.LeadingIcon = null;
            this.CaseNameBox.Location = new System.Drawing.Point(19, 128);
            this.CaseNameBox.MaxLength = 32767;
            this.CaseNameBox.MouseState = MaterialSkin.MouseState.OUT;
            this.CaseNameBox.Name = "CaseNameBox";
            this.CaseNameBox.PasswordChar = '\0';
            this.CaseNameBox.PrefixSuffixText = null;
            this.CaseNameBox.ReadOnly = false;
            this.CaseNameBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CaseNameBox.SelectedText = "";
            this.CaseNameBox.SelectionLength = 0;
            this.CaseNameBox.SelectionStart = 0;
            this.CaseNameBox.ShortcutsEnabled = true;
            this.CaseNameBox.Size = new System.Drawing.Size(251, 48);
            this.CaseNameBox.TabIndex = 1;
            this.CaseNameBox.TabStop = false;
            this.CaseNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CaseNameBox.TrailingIcon = null;
            this.CaseNameBox.UseSystemPasswordChar = false;
            // 
            // AddBut
            // 
            this.AddBut.AutoSize = false;
            this.AddBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.AddBut.Depth = 0;
            this.AddBut.HighEmphasis = true;
            this.AddBut.Icon = null;
            this.AddBut.Location = new System.Drawing.Point(19, 195);
            this.AddBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddBut.Name = "AddBut";
            this.AddBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.AddBut.Size = new System.Drawing.Size(111, 36);
            this.AddBut.TabIndex = 2;
            this.AddBut.Text = "Add";
            this.AddBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AddBut.UseAccentColor = false;
            this.AddBut.UseVisualStyleBackColor = true;
            this.AddBut.Click += new System.EventHandler(this.AddBut_Click);
            // 
            // BackBut
            // 
            this.BackBut.AutoSize = false;
            this.BackBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BackBut.Depth = 0;
            this.BackBut.HighEmphasis = true;
            this.BackBut.Icon = null;
            this.BackBut.Location = new System.Drawing.Point(159, 195);
            this.BackBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBut.Name = "BackBut";
            this.BackBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BackBut.Size = new System.Drawing.Size(111, 36);
            this.BackBut.TabIndex = 3;
            this.BackBut.Text = "Back";
            this.BackBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BackBut.UseAccentColor = false;
            this.BackBut.UseVisualStyleBackColor = true;
            this.BackBut.Click += new System.EventHandler(this.BackBut_Click);
            // 
            // AddCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 281);
            this.Controls.Add(this.BackBut);
            this.Controls.Add(this.AddBut);
            this.Controls.Add(this.CaseNameBox);
            this.Controls.Add(this.CaseNameLB);
            this.Name = "AddCase";
            this.Text = "AddCase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel CaseNameLB;
        private MaterialSkin.Controls.MaterialTextBox2 CaseNameBox;
        private MaterialSkin.Controls.MaterialButton AddBut;
        private MaterialSkin.Controls.MaterialButton BackBut;
    }
}