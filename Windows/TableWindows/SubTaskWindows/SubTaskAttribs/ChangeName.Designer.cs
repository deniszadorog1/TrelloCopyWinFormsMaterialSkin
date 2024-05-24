namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs
{
    partial class ChangeName
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
            this.SubTaskNameLB = new MaterialSkin.Controls.MaterialLabel();
            this.SubTaskNameBox = new MaterialSkin.Controls.MaterialTextBox();
            this.InitBut = new MaterialSkin.Controls.MaterialButton();
            this.BackBut = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // SubTaskNameLB
            // 
            this.SubTaskNameLB.AutoSize = true;
            this.SubTaskNameLB.Depth = 0;
            this.SubTaskNameLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SubTaskNameLB.Location = new System.Drawing.Point(31, 91);
            this.SubTaskNameLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.SubTaskNameLB.Name = "SubTaskNameLB";
            this.SubTaskNameLB.Size = new System.Drawing.Size(108, 19);
            this.SubTaskNameLB.TabIndex = 0;
            this.SubTaskNameLB.Text = "SubTask name";
            // 
            // SubTaskNameBox
            // 
            this.SubTaskNameBox.AnimateReadOnly = false;
            this.SubTaskNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SubTaskNameBox.Depth = 0;
            this.SubTaskNameBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SubTaskNameBox.LeadingIcon = null;
            this.SubTaskNameBox.Location = new System.Drawing.Point(34, 113);
            this.SubTaskNameBox.MaxLength = 50;
            this.SubTaskNameBox.MouseState = MaterialSkin.MouseState.OUT;
            this.SubTaskNameBox.Multiline = false;
            this.SubTaskNameBox.Name = "SubTaskNameBox";
            this.SubTaskNameBox.Size = new System.Drawing.Size(294, 50);
            this.SubTaskNameBox.TabIndex = 1;
            this.SubTaskNameBox.Text = "";
            this.SubTaskNameBox.TrailingIcon = null;
            // 
            // InitBut
            // 
            this.InitBut.AutoSize = false;
            this.InitBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.InitBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.InitBut.Depth = 0;
            this.InitBut.HighEmphasis = true;
            this.InitBut.Icon = null;
            this.InitBut.Location = new System.Drawing.Point(34, 189);
            this.InitBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.InitBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.InitBut.Name = "InitBut";
            this.InitBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.InitBut.Size = new System.Drawing.Size(133, 36);
            this.InitBut.TabIndex = 2;
            this.InitBut.Text = "Init";
            this.InitBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.InitBut.UseAccentColor = false;
            this.InitBut.UseVisualStyleBackColor = true;
            this.InitBut.Click += new System.EventHandler(this.InitBut_Click);
            // 
            // BackBut
            // 
            this.BackBut.AutoSize = false;
            this.BackBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BackBut.Depth = 0;
            this.BackBut.HighEmphasis = true;
            this.BackBut.Icon = null;
            this.BackBut.Location = new System.Drawing.Point(191, 189);
            this.BackBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBut.Name = "BackBut";
            this.BackBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BackBut.Size = new System.Drawing.Size(137, 36);
            this.BackBut.TabIndex = 3;
            this.BackBut.Text = "Back";
            this.BackBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BackBut.UseAccentColor = false;
            this.BackBut.UseVisualStyleBackColor = true;
            this.BackBut.Click += new System.EventHandler(this.BackBut_Click);
            // 
            // ChangeName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 256);
            this.Controls.Add(this.BackBut);
            this.Controls.Add(this.InitBut);
            this.Controls.Add(this.SubTaskNameBox);
            this.Controls.Add(this.SubTaskNameLB);
            this.Name = "ChangeName";
            this.Text = "ChangeName";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel SubTaskNameLB;
        private MaterialSkin.Controls.MaterialTextBox SubTaskNameBox;
        private MaterialSkin.Controls.MaterialButton InitBut;
        private MaterialSkin.Controls.MaterialButton BackBut;
    }
}