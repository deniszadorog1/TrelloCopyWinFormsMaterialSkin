namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs
{
    partial class ParticipantsAction
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
            this.UsersToAddBox = new MaterialSkin.Controls.MaterialComboBox();
            this.AddUsersLB = new MaterialSkin.Controls.MaterialLabel();
            this.AddBut = new MaterialSkin.Controls.MaterialButton();
            this.RemoveBut = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.UsersInSubTaskBox = new MaterialSkin.Controls.MaterialComboBox();
            this.BackBut = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // UsersToAddBox
            // 
            this.UsersToAddBox.AutoResize = false;
            this.UsersToAddBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.UsersToAddBox.Depth = 0;
            this.UsersToAddBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.UsersToAddBox.DropDownHeight = 174;
            this.UsersToAddBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UsersToAddBox.DropDownWidth = 121;
            this.UsersToAddBox.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.UsersToAddBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UsersToAddBox.FormattingEnabled = true;
            this.UsersToAddBox.IntegralHeight = false;
            this.UsersToAddBox.ItemHeight = 43;
            this.UsersToAddBox.Location = new System.Drawing.Point(9, 116);
            this.UsersToAddBox.MaxDropDownItems = 4;
            this.UsersToAddBox.MouseState = MaterialSkin.MouseState.OUT;
            this.UsersToAddBox.Name = "UsersToAddBox";
            this.UsersToAddBox.Size = new System.Drawing.Size(229, 49);
            this.UsersToAddBox.StartIndex = 0;
            this.UsersToAddBox.TabIndex = 0;
            // 
            // AddUsersLB
            // 
            this.AddUsersLB.AutoSize = true;
            this.AddUsersLB.Depth = 0;
            this.AddUsersLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.AddUsersLB.Location = new System.Drawing.Point(6, 94);
            this.AddUsersLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddUsersLB.Name = "AddUsersLB";
            this.AddUsersLB.Size = new System.Drawing.Size(154, 19);
            this.AddUsersLB.TabIndex = 1;
            this.AddUsersLB.Text = "Users that can be add";
            // 
            // AddBut
            // 
            this.AddBut.AutoSize = false;
            this.AddBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.AddBut.Depth = 0;
            this.AddBut.HighEmphasis = true;
            this.AddBut.Icon = null;
            this.AddBut.Location = new System.Drawing.Point(245, 129);
            this.AddBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddBut.Name = "AddBut";
            this.AddBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.AddBut.Size = new System.Drawing.Size(169, 36);
            this.AddBut.TabIndex = 3;
            this.AddBut.Text = "Add";
            this.AddBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AddBut.UseAccentColor = false;
            this.AddBut.UseVisualStyleBackColor = true;
            this.AddBut.Click += new System.EventHandler(this.AddBut_Click);
            // 
            // RemoveBut
            // 
            this.RemoveBut.AutoSize = false;
            this.RemoveBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RemoveBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.RemoveBut.Depth = 0;
            this.RemoveBut.HighEmphasis = true;
            this.RemoveBut.Icon = null;
            this.RemoveBut.Location = new System.Drawing.Point(245, 231);
            this.RemoveBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RemoveBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.RemoveBut.Name = "RemoveBut";
            this.RemoveBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.RemoveBut.Size = new System.Drawing.Size(169, 36);
            this.RemoveBut.TabIndex = 6;
            this.RemoveBut.Text = "Remove";
            this.RemoveBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.RemoveBut.UseAccentColor = false;
            this.RemoveBut.UseVisualStyleBackColor = true;
            this.RemoveBut.Click += new System.EventHandler(this.RemoveBut_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(6, 196);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(176, 19);
            this.materialLabel1.TabIndex = 5;
            this.materialLabel1.Text = "Users that alreadyInTask";
            // 
            // UsersInSubTaskBox
            // 
            this.UsersInSubTaskBox.AutoResize = false;
            this.UsersInSubTaskBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.UsersInSubTaskBox.Depth = 0;
            this.UsersInSubTaskBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.UsersInSubTaskBox.DropDownHeight = 174;
            this.UsersInSubTaskBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UsersInSubTaskBox.DropDownWidth = 121;
            this.UsersInSubTaskBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.UsersInSubTaskBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UsersInSubTaskBox.FormattingEnabled = true;
            this.UsersInSubTaskBox.IntegralHeight = false;
            this.UsersInSubTaskBox.ItemHeight = 43;
            this.UsersInSubTaskBox.Location = new System.Drawing.Point(9, 218);
            this.UsersInSubTaskBox.MaxDropDownItems = 4;
            this.UsersInSubTaskBox.MouseState = MaterialSkin.MouseState.OUT;
            this.UsersInSubTaskBox.Name = "UsersInSubTaskBox";
            this.UsersInSubTaskBox.Size = new System.Drawing.Size(229, 49);
            this.UsersInSubTaskBox.StartIndex = 0;
            this.UsersInSubTaskBox.TabIndex = 4;
            // 
            // BackBut
            // 
            this.BackBut.AutoSize = false;
            this.BackBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BackBut.Depth = 0;
            this.BackBut.HighEmphasis = true;
            this.BackBut.Icon = null;
            this.BackBut.Location = new System.Drawing.Point(71, 291);
            this.BackBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBut.Name = "BackBut";
            this.BackBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BackBut.Size = new System.Drawing.Size(251, 36);
            this.BackBut.TabIndex = 7;
            this.BackBut.Text = "Back";
            this.BackBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BackBut.UseAccentColor = false;
            this.BackBut.UseVisualStyleBackColor = true;
            this.BackBut.Click += new System.EventHandler(this.BackBut_Click);
            // 
            // ParticipantsAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 347);
            this.Controls.Add(this.BackBut);
            this.Controls.Add(this.RemoveBut);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.UsersInSubTaskBox);
            this.Controls.Add(this.AddBut);
            this.Controls.Add(this.AddUsersLB);
            this.Controls.Add(this.UsersToAddBox);
            this.Name = "ParticipantsAction";
            this.Text = "ParticipantsAction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox UsersToAddBox;
        private MaterialSkin.Controls.MaterialLabel AddUsersLB;
        private MaterialSkin.Controls.MaterialButton AddBut;
        private MaterialSkin.Controls.MaterialButton RemoveBut;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialComboBox UsersInSubTaskBox;
        private MaterialSkin.Controls.MaterialButton BackBut;
    }
}