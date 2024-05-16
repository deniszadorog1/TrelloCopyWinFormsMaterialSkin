namespace TrelloCopyWinForms.Windows.TableWindows.CreateTaskWindow
{
    partial class RenameTask
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
            this.TaskNameLb = new MaterialSkin.Controls.MaterialLabel();
            this.NameBox = new MaterialSkin.Controls.MaterialTextBox();
            this.RenameBut = new MaterialSkin.Controls.MaterialButton();
            this.BackBut = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // TaskNameLb
            // 
            this.TaskNameLb.AutoSize = true;
            this.TaskNameLb.Depth = 0;
            this.TaskNameLb.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TaskNameLb.Location = new System.Drawing.Point(6, 89);
            this.TaskNameLb.MouseState = MaterialSkin.MouseState.HOVER;
            this.TaskNameLb.Name = "TaskNameLb";
            this.TaskNameLb.Size = new System.Drawing.Size(80, 19);
            this.TaskNameLb.TabIndex = 0;
            this.TaskNameLb.Text = "Task name";
            // 
            // NameBox
            // 
            this.NameBox.AnimateReadOnly = false;
            this.NameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameBox.Depth = 0;
            this.NameBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.NameBox.LeadingIcon = null;
            this.NameBox.Location = new System.Drawing.Point(9, 111);
            this.NameBox.MaxLength = 32;
            this.NameBox.MouseState = MaterialSkin.MouseState.OUT;
            this.NameBox.Multiline = false;
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(250, 50);
            this.NameBox.TabIndex = 1;
            this.NameBox.Text = "";
            this.NameBox.TrailingIcon = null;
            // 
            // RenameBut
            // 
            this.RenameBut.AutoSize = false;
            this.RenameBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RenameBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.RenameBut.Depth = 0;
            this.RenameBut.HighEmphasis = true;
            this.RenameBut.Icon = null;
            this.RenameBut.Location = new System.Drawing.Point(11, 181);
            this.RenameBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RenameBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.RenameBut.Name = "RenameBut";
            this.RenameBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.RenameBut.Size = new System.Drawing.Size(120, 36);
            this.RenameBut.TabIndex = 2;
            this.RenameBut.Text = "Rename";
            this.RenameBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.RenameBut.UseAccentColor = false;
            this.RenameBut.UseVisualStyleBackColor = true;
            this.RenameBut.Click += new System.EventHandler(this.RenameBut_Click);
            // 
            // BackBut
            // 
            this.BackBut.AutoSize = false;
            this.BackBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BackBut.Depth = 0;
            this.BackBut.HighEmphasis = true;
            this.BackBut.Icon = null;
            this.BackBut.Location = new System.Drawing.Point(139, 181);
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
            // RenameTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 252);
            this.Controls.Add(this.BackBut);
            this.Controls.Add(this.RenameBut);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.TaskNameLb);
            this.Name = "RenameTask";
            this.Text = "RenameTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel TaskNameLb;
        private MaterialSkin.Controls.MaterialTextBox NameBox;
        private MaterialSkin.Controls.MaterialButton RenameBut;
        private MaterialSkin.Controls.MaterialButton BackBut;
    }
}