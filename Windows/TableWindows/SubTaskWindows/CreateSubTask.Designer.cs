namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows
{
    partial class CreateSubTask
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
            this.NameLB = new MaterialSkin.Controls.MaterialLabel();
            this.NameBox = new MaterialSkin.Controls.MaterialTextBox();
            this.CreateBut = new MaterialSkin.Controls.MaterialButton();
            this.BackBut = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // NameLB
            // 
            this.NameLB.AutoSize = true;
            this.NameLB.Depth = 0;
            this.NameLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.NameLB.Location = new System.Drawing.Point(6, 91);
            this.NameLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.NameLB.Name = "NameLB";
            this.NameLB.Size = new System.Drawing.Size(107, 19);
            this.NameLB.TabIndex = 0;
            this.NameLB.Text = "Sub task name";
            // 
            // NameBox
            // 
            this.NameBox.AnimateReadOnly = false;
            this.NameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameBox.Depth = 0;
            this.NameBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.NameBox.LeadingIcon = null;
            this.NameBox.Location = new System.Drawing.Point(6, 122);
            this.NameBox.MaxLength = 50;
            this.NameBox.MouseState = MaterialSkin.MouseState.OUT;
            this.NameBox.Multiline = false;
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(324, 50);
            this.NameBox.TabIndex = 1;
            this.NameBox.Text = "";
            this.NameBox.TrailingIcon = null;
            // 
            // CreateBut
            // 
            this.CreateBut.AutoSize = false;
            this.CreateBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.CreateBut.Depth = 0;
            this.CreateBut.HighEmphasis = true;
            this.CreateBut.Icon = null;
            this.CreateBut.Location = new System.Drawing.Point(6, 181);
            this.CreateBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateBut.Name = "CreateBut";
            this.CreateBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.CreateBut.Size = new System.Drawing.Size(158, 36);
            this.CreateBut.TabIndex = 2;
            this.CreateBut.Text = "Create ";
            this.CreateBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CreateBut.UseAccentColor = false;
            this.CreateBut.UseVisualStyleBackColor = true;
            this.CreateBut.Click += new System.EventHandler(this.CreateBut_Click);
            // 
            // BackBut
            // 
            this.BackBut.AutoSize = false;
            this.BackBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BackBut.Depth = 0;
            this.BackBut.HighEmphasis = true;
            this.BackBut.Icon = null;
            this.BackBut.Location = new System.Drawing.Point(172, 181);
            this.BackBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBut.Name = "BackBut";
            this.BackBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BackBut.Size = new System.Drawing.Size(158, 36);
            this.BackBut.TabIndex = 3;
            this.BackBut.Text = "Back";
            this.BackBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BackBut.UseAccentColor = false;
            this.BackBut.UseVisualStyleBackColor = true;
            this.BackBut.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // CreateSubTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 236);
            this.Controls.Add(this.BackBut);
            this.Controls.Add(this.CreateBut);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.NameLB);
            this.Name = "CreateSubTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CreateSubTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel NameLB;
        private MaterialSkin.Controls.MaterialTextBox NameBox;
        private MaterialSkin.Controls.MaterialButton CreateBut;
        private MaterialSkin.Controls.MaterialButton BackBut;
    }
}