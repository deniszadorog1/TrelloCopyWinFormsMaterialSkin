namespace TrelloCopyWinForms.Windows.TableWindows
{
    partial class DeleteUsersFromTable
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
            this.UsersBox = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.DeleteUserBut = new MaterialSkin.Controls.MaterialButton();
            this.BuckBut = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // UsersBox
            // 
            this.UsersBox.AutoResize = false;
            this.UsersBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.UsersBox.Depth = 0;
            this.UsersBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.UsersBox.DropDownHeight = 174;
            this.UsersBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UsersBox.DropDownWidth = 121;
            this.UsersBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.UsersBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UsersBox.FormattingEnabled = true;
            this.UsersBox.IntegralHeight = false;
            this.UsersBox.ItemHeight = 43;
            this.UsersBox.Location = new System.Drawing.Point(18, 113);
            this.UsersBox.MaxDropDownItems = 4;
            this.UsersBox.MouseState = MaterialSkin.MouseState.OUT;
            this.UsersBox.Name = "UsersBox";
            this.UsersBox.Size = new System.Drawing.Size(228, 49);
            this.UsersBox.StartIndex = 0;
            this.UsersBox.TabIndex = 0;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(15, 82);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(119, 19);
            this.materialLabel1.TabIndex = 2;
            this.materialLabel1.Text = "Users to Remove";
            // 
            // DeleteUserBut
            // 
            this.DeleteUserBut.AutoSize = false;
            this.DeleteUserBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DeleteUserBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.DeleteUserBut.Depth = 0;
            this.DeleteUserBut.HighEmphasis = true;
            this.DeleteUserBut.Icon = null;
            this.DeleteUserBut.Location = new System.Drawing.Point(18, 171);
            this.DeleteUserBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DeleteUserBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.DeleteUserBut.Name = "DeleteUserBut";
            this.DeleteUserBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.DeleteUserBut.Size = new System.Drawing.Size(228, 41);
            this.DeleteUserBut.TabIndex = 3;
            this.DeleteUserBut.Text = "Delete User";
            this.DeleteUserBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.DeleteUserBut.UseAccentColor = false;
            this.DeleteUserBut.UseVisualStyleBackColor = true;
            this.DeleteUserBut.Click += new System.EventHandler(this.DeleteUserBut_Click);
            // 
            // BuckBut
            // 
            this.BuckBut.AutoSize = false;
            this.BuckBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BuckBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BuckBut.Depth = 0;
            this.BuckBut.HighEmphasis = true;
            this.BuckBut.Icon = null;
            this.BuckBut.Location = new System.Drawing.Point(18, 224);
            this.BuckBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BuckBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.BuckBut.Name = "BuckBut";
            this.BuckBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BuckBut.Size = new System.Drawing.Size(228, 41);
            this.BuckBut.TabIndex = 4;
            this.BuckBut.Text = "Back";
            this.BuckBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BuckBut.UseAccentColor = false;
            this.BuckBut.UseVisualStyleBackColor = true;
            this.BuckBut.Click += new System.EventHandler(this.BuckBut_Click);
            // 
            // DeleteUsersFromTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 282);
            this.Controls.Add(this.BuckBut);
            this.Controls.Add(this.DeleteUserBut);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.UsersBox);
            this.Name = "DeleteUsersFromTable";
            this.Text = "DeleteUsersFromTable";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox UsersBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton DeleteUserBut;
        private MaterialSkin.Controls.MaterialButton BuckBut;
    }
}