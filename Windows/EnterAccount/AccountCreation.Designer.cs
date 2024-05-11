namespace TrelloCopyWinForms.Windows.EnterAccount
{
    partial class AccountCreation
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
            this.ShowHidePass = new MaterialSkin.Controls.MaterialButton();
            this.CreateBut = new MaterialSkin.Controls.MaterialButton();
            this.PasswordBox = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.LoginBox = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.EmailBox = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.ReturnToMainPage = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // ShowHidePass
            // 
            this.ShowHidePass.AutoSize = false;
            this.ShowHidePass.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ShowHidePass.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ShowHidePass.Depth = 0;
            this.ShowHidePass.HighEmphasis = true;
            this.ShowHidePass.Icon = null;
            this.ShowHidePass.Location = new System.Drawing.Point(207, 351);
            this.ShowHidePass.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ShowHidePass.MouseState = MaterialSkin.MouseState.HOVER;
            this.ShowHidePass.Name = "ShowHidePass";
            this.ShowHidePass.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ShowHidePass.Size = new System.Drawing.Size(158, 36);
            this.ShowHidePass.TabIndex = 11;
            this.ShowHidePass.Text = "Hide password";
            this.ShowHidePass.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ShowHidePass.UseAccentColor = false;
            this.ShowHidePass.UseVisualStyleBackColor = true;
            this.ShowHidePass.Click += new System.EventHandler(this.ShowHidePass_Click);
            // 
            // CreateBut
            // 
            this.CreateBut.AutoSize = false;
            this.CreateBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.CreateBut.Depth = 0;
            this.CreateBut.HighEmphasis = true;
            this.CreateBut.Icon = null;
            this.CreateBut.Location = new System.Drawing.Point(20, 351);
            this.CreateBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateBut.Name = "CreateBut";
            this.CreateBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.CreateBut.Size = new System.Drawing.Size(166, 36);
            this.CreateBut.TabIndex = 10;
            this.CreateBut.Text = "Create";
            this.CreateBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CreateBut.UseAccentColor = false;
            this.CreateBut.UseVisualStyleBackColor = true;
            this.CreateBut.Click += new System.EventHandler(this.CreateBut_Click);
            // 
            // PasswordBox
            // 
            this.PasswordBox.AnimateReadOnly = false;
            this.PasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordBox.Depth = 0;
            this.PasswordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PasswordBox.LeadingIcon = null;
            this.PasswordBox.Location = new System.Drawing.Point(20, 282);
            this.PasswordBox.MaxLength = 32;
            this.PasswordBox.MouseState = MaterialSkin.MouseState.OUT;
            this.PasswordBox.Multiline = false;
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(345, 50);
            this.PasswordBox.TabIndex = 9;
            this.PasswordBox.Text = "";
            this.PasswordBox.TrailingIcon = null;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel2.Location = new System.Drawing.Point(15, 250);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(107, 29);
            this.materialLabel2.TabIndex = 8;
            this.materialLabel2.Text = "Password";
            // 
            // LoginBox
            // 
            this.LoginBox.AnimateReadOnly = false;
            this.LoginBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoginBox.Depth = 0;
            this.LoginBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LoginBox.LeadingIcon = null;
            this.LoginBox.Location = new System.Drawing.Point(20, 195);
            this.LoginBox.MaxLength = 32;
            this.LoginBox.MouseState = MaterialSkin.MouseState.OUT;
            this.LoginBox.Multiline = false;
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(345, 50);
            this.LoginBox.TabIndex = 7;
            this.LoginBox.Text = "";
            this.LoginBox.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel1.Location = new System.Drawing.Point(15, 163);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(60, 29);
            this.materialLabel1.TabIndex = 6;
            this.materialLabel1.Text = "Login";
            // 
            // EmailBox
            // 
            this.EmailBox.AnimateReadOnly = false;
            this.EmailBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmailBox.Depth = 0;
            this.EmailBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.EmailBox.LeadingIcon = null;
            this.EmailBox.Location = new System.Drawing.Point(20, 110);
            this.EmailBox.MaxLength = 32;
            this.EmailBox.MouseState = MaterialSkin.MouseState.OUT;
            this.EmailBox.Multiline = false;
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(345, 50);
            this.EmailBox.TabIndex = 13;
            this.EmailBox.Text = "";
            this.EmailBox.TrailingIcon = null;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel3.Location = new System.Drawing.Point(15, 78);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(61, 29);
            this.materialLabel3.TabIndex = 12;
            this.materialLabel3.Text = "Email";
            // 
            // ReturnToMainPage
            // 
            this.ReturnToMainPage.AutoSize = false;
            this.ReturnToMainPage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ReturnToMainPage.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ReturnToMainPage.Depth = 0;
            this.ReturnToMainPage.HighEmphasis = true;
            this.ReturnToMainPage.Icon = null;
            this.ReturnToMainPage.Location = new System.Drawing.Point(20, 399);
            this.ReturnToMainPage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ReturnToMainPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.ReturnToMainPage.Name = "ReturnToMainPage";
            this.ReturnToMainPage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ReturnToMainPage.Size = new System.Drawing.Size(345, 36);
            this.ReturnToMainPage.TabIndex = 14;
            this.ReturnToMainPage.Text = "return to main page ";
            this.ReturnToMainPage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ReturnToMainPage.UseAccentColor = false;
            this.ReturnToMainPage.UseVisualStyleBackColor = true;
            this.ReturnToMainPage.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // AccountCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 450);
            this.Controls.Add(this.ReturnToMainPage);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.ShowHidePass);
            this.Controls.Add(this.CreateBut);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.materialLabel1);
            this.Name = "AccountCreation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountCreation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton ShowHidePass;
        private MaterialSkin.Controls.MaterialButton CreateBut;
        private MaterialSkin.Controls.MaterialTextBox PasswordBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox LoginBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox EmailBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton ReturnToMainPage;
    }
}