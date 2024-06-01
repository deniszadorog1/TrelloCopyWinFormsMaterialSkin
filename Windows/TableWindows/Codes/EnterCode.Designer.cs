namespace TrelloCopyWinForms.Windows.TableWindows.Codes
{
    partial class EnterCode
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
            this.CodeBox = new MaterialSkin.Controls.MaterialTextBox();
            this.CodeLB = new MaterialSkin.Controls.MaterialLabel();
            this.EnterCodeBut = new MaterialSkin.Controls.MaterialButton();
            this.BackBut = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // CodeBox
            // 
            this.CodeBox.AnimateReadOnly = false;
            this.CodeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CodeBox.Depth = 0;
            this.CodeBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.CodeBox.LeadingIcon = null;
            this.CodeBox.Location = new System.Drawing.Point(9, 99);
            this.CodeBox.MaxLength = 50;
            this.CodeBox.MouseState = MaterialSkin.MouseState.OUT;
            this.CodeBox.Multiline = false;
            this.CodeBox.Name = "CodeBox";
            this.CodeBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.CodeBox.Size = new System.Drawing.Size(250, 50);
            this.CodeBox.TabIndex = 0;
            this.CodeBox.Text = "";
            this.CodeBox.TrailingIcon = null;
            // 
            // CodeLB
            // 
            this.CodeLB.AutoSize = true;
            this.CodeLB.Depth = 0;
            this.CodeLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.CodeLB.Location = new System.Drawing.Point(6, 77);
            this.CodeLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.CodeLB.Name = "CodeLB";
            this.CodeLB.Size = new System.Drawing.Size(41, 19);
            this.CodeLB.TabIndex = 1;
            this.CodeLB.Text = "Code:";
            // 
            // EnterCodeBut
            // 
            this.EnterCodeBut.AutoSize = false;
            this.EnterCodeBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EnterCodeBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.EnterCodeBut.Depth = 0;
            this.EnterCodeBut.HighEmphasis = true;
            this.EnterCodeBut.Icon = null;
            this.EnterCodeBut.Location = new System.Drawing.Point(9, 158);
            this.EnterCodeBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.EnterCodeBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.EnterCodeBut.Name = "EnterCodeBut";
            this.EnterCodeBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.EnterCodeBut.Size = new System.Drawing.Size(122, 36);
            this.EnterCodeBut.TabIndex = 2;
            this.EnterCodeBut.Text = "Enter code";
            this.EnterCodeBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.EnterCodeBut.UseAccentColor = false;
            this.EnterCodeBut.UseVisualStyleBackColor = true;
            this.EnterCodeBut.Click += new System.EventHandler(this.EnterCodeBut_Click);
            // 
            // BackBut
            // 
            this.BackBut.AutoSize = false;
            this.BackBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BackBut.Depth = 0;
            this.BackBut.HighEmphasis = true;
            this.BackBut.Icon = null;
            this.BackBut.Location = new System.Drawing.Point(139, 158);
            this.BackBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBut.Name = "BackBut";
            this.BackBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BackBut.Size = new System.Drawing.Size(120, 36);
            this.BackBut.TabIndex = 3;
            this.BackBut.Text = "Back";
            this.BackBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BackBut.UseAccentColor = false;
            this.BackBut.UseVisualStyleBackColor = true;
            this.BackBut.Click += new System.EventHandler(this.BackBut_Click);
            // 
            // EnterCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 213);
            this.Controls.Add(this.BackBut);
            this.Controls.Add(this.EnterCodeBut);
            this.Controls.Add(this.CodeLB);
            this.Controls.Add(this.CodeBox);
            this.Name = "EnterCode";
            this.Text = "EnterCode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox CodeBox;
        private MaterialSkin.Controls.MaterialLabel CodeLB;
        private MaterialSkin.Controls.MaterialButton EnterCodeBut;
        private MaterialSkin.Controls.MaterialButton BackBut;
    }
}