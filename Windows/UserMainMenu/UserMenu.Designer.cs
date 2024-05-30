namespace TrelloCopyWinForms.Windows.UserMainMenu
{
    partial class UserMenu
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
            this.CorrectAccount = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OldPassEyeImg = new System.Windows.Forms.PictureBox();
            this.NewPassEyeImg = new System.Windows.Forms.PictureBox();
            this.CorrectBut = new MaterialSkin.Controls.MaterialButton();
            this.NewPasCorBox = new MaterialSkin.Controls.MaterialTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.OldPassCorBox = new MaterialSkin.Controls.MaterialTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.EmailCorBox = new MaterialSkin.Controls.MaterialTextBox();
            this.EmailLB = new System.Windows.Forms.Label();
            this.LoginCorBox = new MaterialSkin.Controls.MaterialTextBox();
            this.LoginLB = new System.Windows.Forms.Label();
            this.Tables = new System.Windows.Forms.TabPage();
            this.AccessableTablesPanel = new System.Windows.Forms.Panel();
            this.ChooseTableBut = new MaterialSkin.Controls.MaterialButton();
            this.CreateTableBut = new MaterialSkin.Controls.MaterialButton();
            this.UserInfoTab = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EmailInfo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LoginInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MatTab = new MaterialSkin.Controls.MaterialTabControl();
            this.ChosenTablePanel = new System.Windows.Forms.Panel();
            this.ChosenTableLB = new MaterialSkin.Controls.MaterialLabel();
            this.CorrectAccount.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OldPassEyeImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPassEyeImg)).BeginInit();
            this.Tables.SuspendLayout();
            this.UserInfoTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.MatTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // CorrectAccount
            // 
            this.CorrectAccount.Controls.Add(this.groupBox2);
            this.CorrectAccount.Location = new System.Drawing.Point(4, 27);
            this.CorrectAccount.Name = "CorrectAccount";
            this.CorrectAccount.Padding = new System.Windows.Forms.Padding(3);
            this.CorrectAccount.Size = new System.Drawing.Size(719, 352);
            this.CorrectAccount.TabIndex = 3;
            this.CorrectAccount.Text = "Correct user params";
            this.CorrectAccount.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.OldPassEyeImg);
            this.groupBox2.Controls.Add(this.NewPassEyeImg);
            this.groupBox2.Controls.Add(this.CorrectBut);
            this.groupBox2.Controls.Add(this.NewPasCorBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.OldPassCorBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.EmailCorBox);
            this.groupBox2.Controls.Add(this.EmailLB);
            this.groupBox2.Controls.Add(this.LoginCorBox);
            this.groupBox2.Controls.Add(this.LoginLB);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(713, 346);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Account correction";
            // 
            // OldPassEyeImg
            // 
            this.OldPassEyeImg.Location = new System.Drawing.Point(646, 78);
            this.OldPassEyeImg.Name = "OldPassEyeImg";
            this.OldPassEyeImg.Size = new System.Drawing.Size(49, 50);
            this.OldPassEyeImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OldPassEyeImg.TabIndex = 10;
            this.OldPassEyeImg.TabStop = false;
            this.OldPassEyeImg.Click += new System.EventHandler(this.NewPasEyeImg_Click);
            // 
            // NewPassEyeImg
            // 
            this.NewPassEyeImg.Location = new System.Drawing.Point(646, 179);
            this.NewPassEyeImg.Name = "NewPassEyeImg";
            this.NewPassEyeImg.Size = new System.Drawing.Size(49, 50);
            this.NewPassEyeImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NewPassEyeImg.TabIndex = 9;
            this.NewPassEyeImg.TabStop = false;
            this.NewPassEyeImg.Click += new System.EventHandler(this.NewPasEyeImg_Click);
            // 
            // CorrectBut
            // 
            this.CorrectBut.AutoSize = false;
            this.CorrectBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CorrectBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.CorrectBut.Depth = 0;
            this.CorrectBut.HighEmphasis = true;
            this.CorrectBut.Icon = null;
            this.CorrectBut.Location = new System.Drawing.Point(97, 276);
            this.CorrectBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CorrectBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.CorrectBut.Name = "CorrectBut";
            this.CorrectBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.CorrectBut.Size = new System.Drawing.Size(508, 47);
            this.CorrectBut.TabIndex = 8;
            this.CorrectBut.Text = "Correct";
            this.CorrectBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CorrectBut.UseAccentColor = false;
            this.CorrectBut.UseVisualStyleBackColor = true;
            this.CorrectBut.Click += new System.EventHandler(this.CorrectBut_Click);
            // 
            // NewPasCorBox
            // 
            this.NewPasCorBox.AnimateReadOnly = false;
            this.NewPasCorBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NewPasCorBox.Depth = 0;
            this.NewPasCorBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.NewPasCorBox.LeadingIcon = null;
            this.NewPasCorBox.Location = new System.Drawing.Point(368, 179);
            this.NewPasCorBox.MaxLength = 32;
            this.NewPasCorBox.MouseState = MaterialSkin.MouseState.OUT;
            this.NewPasCorBox.Multiline = false;
            this.NewPasCorBox.Name = "NewPasCorBox";
            this.NewPasCorBox.Size = new System.Drawing.Size(272, 50);
            this.NewPasCorBox.TabIndex = 7;
            this.NewPasCorBox.Text = "";
            this.NewPasCorBox.TrailingIcon = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(363, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "New Password";
            // 
            // OldPassCorBox
            // 
            this.OldPassCorBox.AnimateReadOnly = false;
            this.OldPassCorBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OldPassCorBox.Depth = 0;
            this.OldPassCorBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.OldPassCorBox.LeadingIcon = null;
            this.OldPassCorBox.Location = new System.Drawing.Point(368, 78);
            this.OldPassCorBox.MaxLength = 32;
            this.OldPassCorBox.MouseState = MaterialSkin.MouseState.OUT;
            this.OldPassCorBox.Multiline = false;
            this.OldPassCorBox.Name = "OldPassCorBox";
            this.OldPassCorBox.Size = new System.Drawing.Size(272, 50);
            this.OldPassCorBox.TabIndex = 5;
            this.OldPassCorBox.Text = "";
            this.OldPassCorBox.TrailingIcon = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Old Password";
            // 
            // EmailCorBox
            // 
            this.EmailCorBox.AnimateReadOnly = false;
            this.EmailCorBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmailCorBox.Depth = 0;
            this.EmailCorBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.EmailCorBox.LeadingIcon = null;
            this.EmailCorBox.Location = new System.Drawing.Point(26, 179);
            this.EmailCorBox.MaxLength = 32;
            this.EmailCorBox.MouseState = MaterialSkin.MouseState.OUT;
            this.EmailCorBox.Multiline = false;
            this.EmailCorBox.Name = "EmailCorBox";
            this.EmailCorBox.Size = new System.Drawing.Size(272, 50);
            this.EmailCorBox.TabIndex = 3;
            this.EmailCorBox.Text = "";
            this.EmailCorBox.TrailingIcon = null;
            // 
            // EmailLB
            // 
            this.EmailLB.AutoSize = true;
            this.EmailLB.Location = new System.Drawing.Point(21, 139);
            this.EmailLB.Name = "EmailLB";
            this.EmailLB.Size = new System.Drawing.Size(65, 25);
            this.EmailLB.TabIndex = 2;
            this.EmailLB.Text = "Email";
            // 
            // LoginCorBox
            // 
            this.LoginCorBox.AnimateReadOnly = false;
            this.LoginCorBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoginCorBox.Depth = 0;
            this.LoginCorBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LoginCorBox.LeadingIcon = null;
            this.LoginCorBox.Location = new System.Drawing.Point(26, 75);
            this.LoginCorBox.MaxLength = 32;
            this.LoginCorBox.MouseState = MaterialSkin.MouseState.OUT;
            this.LoginCorBox.Multiline = false;
            this.LoginCorBox.Name = "LoginCorBox";
            this.LoginCorBox.Size = new System.Drawing.Size(272, 50);
            this.LoginCorBox.TabIndex = 1;
            this.LoginCorBox.Text = "";
            this.LoginCorBox.TrailingIcon = null;
            // 
            // LoginLB
            // 
            this.LoginLB.AutoSize = true;
            this.LoginLB.Location = new System.Drawing.Point(21, 38);
            this.LoginLB.Name = "LoginLB";
            this.LoginLB.Size = new System.Drawing.Size(65, 25);
            this.LoginLB.TabIndex = 0;
            this.LoginLB.Text = "Login";
            // 
            // Tables
            // 
            this.Tables.BackColor = System.Drawing.SystemColors.Control;
            this.Tables.Controls.Add(this.ChosenTableLB);
            this.Tables.Controls.Add(this.ChosenTablePanel);
            this.Tables.Controls.Add(this.AccessableTablesPanel);
            this.Tables.Controls.Add(this.ChooseTableBut);
            this.Tables.Controls.Add(this.CreateTableBut);
            this.Tables.Location = new System.Drawing.Point(4, 27);
            this.Tables.Name = "Tables";
            this.Tables.Padding = new System.Windows.Forms.Padding(3);
            this.Tables.Size = new System.Drawing.Size(719, 352);
            this.Tables.TabIndex = 1;
            this.Tables.Text = "Tables";
            // 
            // AccessableTablesPanel
            // 
            this.AccessableTablesPanel.AutoScroll = true;
            this.AccessableTablesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AccessableTablesPanel.Location = new System.Drawing.Point(19, 18);
            this.AccessableTablesPanel.Name = "AccessableTablesPanel";
            this.AccessableTablesPanel.Size = new System.Drawing.Size(257, 328);
            this.AccessableTablesPanel.TabIndex = 3;
            // 
            // ChooseTableBut
            // 
            this.ChooseTableBut.AutoSize = false;
            this.ChooseTableBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChooseTableBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ChooseTableBut.Depth = 0;
            this.ChooseTableBut.HighEmphasis = true;
            this.ChooseTableBut.Icon = null;
            this.ChooseTableBut.Location = new System.Drawing.Point(383, 230);
            this.ChooseTableBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ChooseTableBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChooseTableBut.Name = "ChooseTableBut";
            this.ChooseTableBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ChooseTableBut.Size = new System.Drawing.Size(231, 44);
            this.ChooseTableBut.TabIndex = 2;
            this.ChooseTableBut.Text = "Chose Table";
            this.ChooseTableBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ChooseTableBut.UseAccentColor = false;
            this.ChooseTableBut.UseVisualStyleBackColor = true;
            this.ChooseTableBut.Click += new System.EventHandler(this.ChooseTableBut_Click);
            // 
            // CreateTableBut
            // 
            this.CreateTableBut.AutoSize = false;
            this.CreateTableBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateTableBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.CreateTableBut.Depth = 0;
            this.CreateTableBut.HighEmphasis = true;
            this.CreateTableBut.Icon = null;
            this.CreateTableBut.Location = new System.Drawing.Point(383, 286);
            this.CreateTableBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateTableBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateTableBut.Name = "CreateTableBut";
            this.CreateTableBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.CreateTableBut.Size = new System.Drawing.Size(231, 44);
            this.CreateTableBut.TabIndex = 0;
            this.CreateTableBut.Text = "Create button ";
            this.CreateTableBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CreateTableBut.UseAccentColor = false;
            this.CreateTableBut.UseVisualStyleBackColor = true;
            this.CreateTableBut.Click += new System.EventHandler(this.CreateTableBut_Click);
            // 
            // UserInfoTab
            // 
            this.UserInfoTab.Controls.Add(this.label5);
            this.UserInfoTab.Controls.Add(this.groupBox1);
            this.UserInfoTab.Location = new System.Drawing.Point(4, 27);
            this.UserInfoTab.Name = "UserInfoTab";
            this.UserInfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.UserInfoTab.Size = new System.Drawing.Size(719, 352);
            this.UserInfoTab.TabIndex = 0;
            this.UserInfoTab.Text = "User Info";
            this.UserInfoTab.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(34, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(649, 118);
            this.label5.TabIndex = 5;
            this.label5.Text = "This program is copy of trello. Copy of some functions  ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EmailInfo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.LoginInfo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(30, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Info";
            // 
            // EmailInfo
            // 
            this.EmailInfo.AutoSize = true;
            this.EmailInfo.Location = new System.Drawing.Point(96, 109);
            this.EmailInfo.Name = "EmailInfo";
            this.EmailInfo.Size = new System.Drawing.Size(241, 25);
            this.EmailInfo.TabIndex = 3;
            this.EmailInfo.Text = "There will be user Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Email - ";
            // 
            // LoginInfo
            // 
            this.LoginInfo.AutoSize = true;
            this.LoginInfo.Location = new System.Drawing.Point(91, 52);
            this.LoginInfo.Name = "LoginInfo";
            this.LoginInfo.Size = new System.Drawing.Size(240, 25);
            this.LoginInfo.TabIndex = 1;
            this.LoginInfo.Text = "There will be user login ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login  - ";
            // 
            // MatTab
            // 
            this.MatTab.Controls.Add(this.Tables);
            this.MatTab.Controls.Add(this.UserInfoTab);
            this.MatTab.Controls.Add(this.CorrectAccount);
            this.MatTab.Depth = 0;
            this.MatTab.Dock = System.Windows.Forms.DockStyle.Top;
            this.MatTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MatTab.Location = new System.Drawing.Point(3, 64);
            this.MatTab.MouseState = MaterialSkin.MouseState.HOVER;
            this.MatTab.Multiline = true;
            this.MatTab.Name = "MatTab";
            this.MatTab.SelectedIndex = 0;
            this.MatTab.Size = new System.Drawing.Size(727, 383);
            this.MatTab.TabIndex = 0;
            // 
            // ChosenTablePanel
            // 
            this.ChosenTablePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ChosenTablePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChosenTablePanel.Location = new System.Drawing.Point(431, 93);
            this.ChosenTablePanel.Name = "ChosenTablePanel";
            this.ChosenTablePanel.Size = new System.Drawing.Size(100, 100);
            this.ChosenTablePanel.TabIndex = 4;
            // 
            // ChosenTableLB
            // 
            this.ChosenTableLB.AutoSize = true;
            this.ChosenTableLB.Depth = 0;
            this.ChosenTableLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ChosenTableLB.Location = new System.Drawing.Point(428, 71);
            this.ChosenTableLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChosenTableLB.Name = "ChosenTableLB";
            this.ChosenTableLB.Size = new System.Drawing.Size(93, 19);
            this.ChosenTableLB.TabIndex = 5;
            this.ChosenTableLB.Text = "Chosen table";
            // 
            // UserMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 450);
            this.Controls.Add(this.MatTab);
            this.DrawerTabControl = this.MatTab;
            this.Name = "UserMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserMenu";
            this.CorrectAccount.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OldPassEyeImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPassEyeImg)).EndInit();
            this.Tables.ResumeLayout(false);
            this.Tables.PerformLayout();
            this.UserInfoTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.MatTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage CorrectAccount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox OldPassEyeImg;
        private System.Windows.Forms.PictureBox NewPassEyeImg;
        private MaterialSkin.Controls.MaterialButton CorrectBut;
        private MaterialSkin.Controls.MaterialTextBox NewPasCorBox;
        private System.Windows.Forms.Label label7;
        private MaterialSkin.Controls.MaterialTextBox OldPassCorBox;
        private System.Windows.Forms.Label label6;
        private MaterialSkin.Controls.MaterialTextBox EmailCorBox;
        private System.Windows.Forms.Label EmailLB;
        private MaterialSkin.Controls.MaterialTextBox LoginCorBox;
        private System.Windows.Forms.Label LoginLB;
        private System.Windows.Forms.TabPage Tables;
        private MaterialSkin.Controls.MaterialButton ChooseTableBut;
        private MaterialSkin.Controls.MaterialButton CreateTableBut;
        private System.Windows.Forms.TabPage UserInfoTab;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label EmailInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LoginInfo;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialTabControl MatTab;
        private System.Windows.Forms.Panel AccessableTablesPanel;
        private MaterialSkin.Controls.MaterialLabel ChosenTableLB;
        private System.Windows.Forms.Panel ChosenTablePanel;
    }
}