namespace TrelloCopyWinForms
{
    partial class Login
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.LoginBox = new MaterialSkin.Controls.MaterialTextBox();
            this.PasswordBox = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.LoginBut = new MaterialSkin.Controls.MaterialButton();
            this.NewAccBut = new MaterialSkin.Controls.MaterialButton();
            this.FacePic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FacePic)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel1.Location = new System.Drawing.Point(64, 195);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(60, 29);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Login";
            // 
            // LoginBox
            // 
            this.LoginBox.AnimateReadOnly = false;
            this.LoginBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoginBox.Depth = 0;
            this.LoginBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LoginBox.LeadingIcon = null;
            this.LoginBox.Location = new System.Drawing.Point(69, 227);
            this.LoginBox.MaxLength = 32;
            this.LoginBox.MouseState = MaterialSkin.MouseState.OUT;
            this.LoginBox.Multiline = false;
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(345, 50);
            this.LoginBox.TabIndex = 1;
            this.LoginBox.Text = "";
            this.LoginBox.TrailingIcon = null;
            // 
            // PasswordBox
            // 
            this.PasswordBox.AnimateReadOnly = false;
            this.PasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordBox.Depth = 0;
            this.PasswordBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PasswordBox.LeadingIcon = null;
            this.PasswordBox.Location = new System.Drawing.Point(69, 314);
            this.PasswordBox.MaxLength = 32;
            this.PasswordBox.MouseState = MaterialSkin.MouseState.OUT;
            this.PasswordBox.Multiline = false;
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Password = true;
            this.PasswordBox.Size = new System.Drawing.Size(345, 50);
            this.PasswordBox.TabIndex = 3;
            this.PasswordBox.Text = "";
            this.PasswordBox.TrailingIcon = null;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel2.Location = new System.Drawing.Point(64, 282);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(107, 29);
            this.materialLabel2.TabIndex = 2;
            this.materialLabel2.Text = "Password";
            // 
            // LoginBut
            // 
            this.LoginBut.AutoSize = false;
            this.LoginBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoginBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.LoginBut.Depth = 0;
            this.LoginBut.HighEmphasis = true;
            this.LoginBut.Icon = null;
            this.LoginBut.Location = new System.Drawing.Point(69, 391);
            this.LoginBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.LoginBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.LoginBut.Name = "LoginBut";
            this.LoginBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.LoginBut.Size = new System.Drawing.Size(166, 36);
            this.LoginBut.TabIndex = 4;
            this.LoginBut.Text = "Log In";
            this.LoginBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.LoginBut.UseAccentColor = false;
            this.LoginBut.UseVisualStyleBackColor = true;
            // 
            // NewAccBut
            // 
            this.NewAccBut.AutoSize = false;
            this.NewAccBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NewAccBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.NewAccBut.Depth = 0;
            this.NewAccBut.HighEmphasis = true;
            this.NewAccBut.Icon = null;
            this.NewAccBut.Location = new System.Drawing.Point(256, 391);
            this.NewAccBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.NewAccBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.NewAccBut.Name = "NewAccBut";
            this.NewAccBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.NewAccBut.Size = new System.Drawing.Size(158, 36);
            this.NewAccBut.TabIndex = 5;
            this.NewAccBut.Text = "New Account";
            this.NewAccBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.NewAccBut.UseAccentColor = false;
            this.NewAccBut.UseVisualStyleBackColor = true;
            this.NewAccBut.Click += new System.EventHandler(this.NewAccBut_Click);
            // 
            // FacePic
            // 
            this.FacePic.Location = new System.Drawing.Point(193, 82);
            this.FacePic.Name = "FacePic";
            this.FacePic.Size = new System.Drawing.Size(100, 100);
            this.FacePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FacePic.TabIndex = 6;
            this.FacePic.TabStop = false;
            // 
            // Loign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 475);
            this.Controls.Add(this.FacePic);
            this.Controls.Add(this.NewAccBut);
            this.Controls.Add(this.LoginBut);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.materialLabel1);
            this.Name = "Loign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FacePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox LoginBox;
        private MaterialSkin.Controls.MaterialTextBox PasswordBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialButton LoginBut;
        private MaterialSkin.Controls.MaterialButton NewAccBut;
        private System.Windows.Forms.PictureBox FacePic;
    }
}

