namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs
{
    partial class CorrectComment
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
            this.CorrectComLB = new MaterialSkin.Controls.MaterialLabel();
            this.CommentBox = new MaterialSkin.Controls.MaterialTextBox2();
            this.CorrectBut = new MaterialSkin.Controls.MaterialButton();
            this.BackBut = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // CorrectComLB
            // 
            this.CorrectComLB.AutoSize = true;
            this.CorrectComLB.Depth = 0;
            this.CorrectComLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.CorrectComLB.Location = new System.Drawing.Point(17, 94);
            this.CorrectComLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.CorrectComLB.Name = "CorrectComLB";
            this.CorrectComLB.Size = new System.Drawing.Size(168, 19);
            this.CorrectComLB.TabIndex = 0;
            this.CorrectComLB.Text = "Correct Comment Value";
            // 
            // CommentBox
            // 
            this.CommentBox.AnimateReadOnly = false;
            this.CommentBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CommentBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CommentBox.Depth = 0;
            this.CommentBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.CommentBox.HideSelection = true;
            this.CommentBox.LeadingIcon = null;
            this.CommentBox.Location = new System.Drawing.Point(20, 126);
            this.CommentBox.MaxLength = 250;
            this.CommentBox.MouseState = MaterialSkin.MouseState.OUT;
            this.CommentBox.Name = "CommentBox";
            this.CommentBox.PasswordChar = '\0';
            this.CommentBox.PrefixSuffixText = null;
            this.CommentBox.ReadOnly = false;
            this.CommentBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CommentBox.SelectedText = "";
            this.CommentBox.SelectionLength = 0;
            this.CommentBox.SelectionStart = 0;
            this.CommentBox.ShortcutsEnabled = true;
            this.CommentBox.Size = new System.Drawing.Size(336, 48);
            this.CommentBox.TabIndex = 1;
            this.CommentBox.TabStop = false;
            this.CommentBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CommentBox.TrailingIcon = null;
            this.CommentBox.UseSystemPasswordChar = false;
            // 
            // CorrectBut
            // 
            this.CorrectBut.AutoSize = false;
            this.CorrectBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CorrectBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.CorrectBut.Depth = 0;
            this.CorrectBut.HighEmphasis = true;
            this.CorrectBut.Icon = null;
            this.CorrectBut.Location = new System.Drawing.Point(20, 183);
            this.CorrectBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CorrectBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.CorrectBut.Name = "CorrectBut";
            this.CorrectBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.CorrectBut.Size = new System.Drawing.Size(165, 36);
            this.CorrectBut.TabIndex = 2;
            this.CorrectBut.Text = "Correct";
            this.CorrectBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CorrectBut.UseAccentColor = false;
            this.CorrectBut.UseVisualStyleBackColor = true;
            this.CorrectBut.Click += new System.EventHandler(this.CorrectBut_Click);
            // 
            // BackBut
            // 
            this.BackBut.AutoSize = false;
            this.BackBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BackBut.Depth = 0;
            this.BackBut.HighEmphasis = true;
            this.BackBut.Icon = null;
            this.BackBut.Location = new System.Drawing.Point(191, 183);
            this.BackBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBut.Name = "BackBut";
            this.BackBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BackBut.Size = new System.Drawing.Size(165, 36);
            this.BackBut.TabIndex = 3;
            this.BackBut.Text = "Back";
            this.BackBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BackBut.UseAccentColor = false;
            this.BackBut.UseVisualStyleBackColor = true;
            this.BackBut.Click += new System.EventHandler(this.BackBut_Click);
            // 
            // CorrectComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 252);
            this.Controls.Add(this.BackBut);
            this.Controls.Add(this.CorrectBut);
            this.Controls.Add(this.CommentBox);
            this.Controls.Add(this.CorrectComLB);
            this.Name = "CorrectComment";
            this.Text = "CorrectComment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel CorrectComLB;
        private MaterialSkin.Controls.MaterialTextBox2 CommentBox;
        private MaterialSkin.Controls.MaterialButton CorrectBut;
        private MaterialSkin.Controls.MaterialButton BackBut;
    }
}