namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs
{
    partial class AddAttachment
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
            this.TaskBox = new MaterialSkin.Controls.MaterialComboBox();
            this.TaskLB = new MaterialSkin.Controls.MaterialLabel();
            this.SubTaskLB = new MaterialSkin.Controls.MaterialLabel();
            this.SubTaskBox = new MaterialSkin.Controls.MaterialComboBox();
            this.AddBut = new MaterialSkin.Controls.MaterialButton();
            this.BackBut = new MaterialSkin.Controls.MaterialButton();
            this.SignBox = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // TaskBox
            // 
            this.TaskBox.AutoResize = false;
            this.TaskBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TaskBox.Depth = 0;
            this.TaskBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.TaskBox.DropDownHeight = 174;
            this.TaskBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TaskBox.DropDownWidth = 121;
            this.TaskBox.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.TaskBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TaskBox.FormattingEnabled = true;
            this.TaskBox.IntegralHeight = false;
            this.TaskBox.ItemHeight = 43;
            this.TaskBox.Location = new System.Drawing.Point(19, 108);
            this.TaskBox.MaxDropDownItems = 4;
            this.TaskBox.MouseState = MaterialSkin.MouseState.OUT;
            this.TaskBox.Name = "TaskBox";
            this.TaskBox.Size = new System.Drawing.Size(275, 49);
            this.TaskBox.StartIndex = 0;
            this.TaskBox.TabIndex = 1;
            // 
            // TaskLB
            // 
            this.TaskLB.AutoSize = true;
            this.TaskLB.Depth = 0;
            this.TaskLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TaskLB.Location = new System.Drawing.Point(19, 86);
            this.TaskLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.TaskLB.Name = "TaskLB";
            this.TaskLB.Size = new System.Drawing.Size(82, 19);
            this.TaskLB.TabIndex = 2;
            this.TaskLB.Text = "Task Name";
            // 
            // SubTaskLB
            // 
            this.SubTaskLB.AutoSize = true;
            this.SubTaskLB.Depth = 0;
            this.SubTaskLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SubTaskLB.Location = new System.Drawing.Point(19, 177);
            this.SubTaskLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.SubTaskLB.Name = "SubTaskLB";
            this.SubTaskLB.Size = new System.Drawing.Size(94, 19);
            this.SubTaskLB.TabIndex = 3;
            this.SubTaskLB.Text = "SubTask box";
            // 
            // SubTaskBox
            // 
            this.SubTaskBox.AutoResize = false;
            this.SubTaskBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SubTaskBox.Depth = 0;
            this.SubTaskBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.SubTaskBox.DropDownHeight = 174;
            this.SubTaskBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SubTaskBox.DropDownWidth = 121;
            this.SubTaskBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.SubTaskBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SubTaskBox.FormattingEnabled = true;
            this.SubTaskBox.IntegralHeight = false;
            this.SubTaskBox.ItemHeight = 43;
            this.SubTaskBox.Location = new System.Drawing.Point(19, 199);
            this.SubTaskBox.MaxDropDownItems = 4;
            this.SubTaskBox.MouseState = MaterialSkin.MouseState.OUT;
            this.SubTaskBox.Name = "SubTaskBox";
            this.SubTaskBox.Size = new System.Drawing.Size(275, 49);
            this.SubTaskBox.StartIndex = 0;
            this.SubTaskBox.TabIndex = 4;
            // 
            // AddBut
            // 
            this.AddBut.AutoSize = false;
            this.AddBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.AddBut.Depth = 0;
            this.AddBut.HighEmphasis = true;
            this.AddBut.Icon = null;
            this.AddBut.Location = new System.Drawing.Point(19, 341);
            this.AddBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddBut.Name = "AddBut";
            this.AddBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.AddBut.Size = new System.Drawing.Size(128, 36);
            this.AddBut.TabIndex = 5;
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
            this.BackBut.Location = new System.Drawing.Point(169, 341);
            this.BackBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBut.Name = "BackBut";
            this.BackBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BackBut.Size = new System.Drawing.Size(125, 36);
            this.BackBut.TabIndex = 6;
            this.BackBut.Text = "Back";
            this.BackBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BackBut.UseAccentColor = false;
            this.BackBut.UseVisualStyleBackColor = true;
            this.BackBut.Click += new System.EventHandler(this.BackBut_Click);
            // 
            // SignBox
            // 
            this.SignBox.AnimateReadOnly = false;
            this.SignBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SignBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.SignBox.Depth = 0;
            this.SignBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SignBox.HideSelection = true;
            this.SignBox.LeadingIcon = null;
            this.SignBox.Location = new System.Drawing.Point(19, 284);
            this.SignBox.MaxLength = 32767;
            this.SignBox.MouseState = MaterialSkin.MouseState.OUT;
            this.SignBox.Name = "SignBox";
            this.SignBox.PasswordChar = '\0';
            this.SignBox.PrefixSuffixText = null;
            this.SignBox.ReadOnly = false;
            this.SignBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SignBox.SelectedText = "";
            this.SignBox.SelectionLength = 0;
            this.SignBox.SelectionStart = 0;
            this.SignBox.ShortcutsEnabled = true;
            this.SignBox.Size = new System.Drawing.Size(275, 48);
            this.SignBox.TabIndex = 7;
            this.SignBox.TabStop = false;
            this.SignBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SignBox.TrailingIcon = null;
            this.SignBox.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(19, 262);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(33, 19);
            this.materialLabel1.TabIndex = 8;
            this.materialLabel1.Text = "Sign";
            // 
            // AddAttachment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 399);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.SignBox);
            this.Controls.Add(this.BackBut);
            this.Controls.Add(this.AddBut);
            this.Controls.Add(this.SubTaskBox);
            this.Controls.Add(this.SubTaskLB);
            this.Controls.Add(this.TaskLB);
            this.Controls.Add(this.TaskBox);
            this.Name = "AddAttachment";
            this.Text = "AddAttachment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox TaskBox;
        private MaterialSkin.Controls.MaterialLabel TaskLB;
        private MaterialSkin.Controls.MaterialLabel SubTaskLB;
        private MaterialSkin.Controls.MaterialComboBox SubTaskBox;
        private MaterialSkin.Controls.MaterialButton AddBut;
        private MaterialSkin.Controls.MaterialButton BackBut;
        private MaterialSkin.Controls.MaterialTextBox2 SignBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}