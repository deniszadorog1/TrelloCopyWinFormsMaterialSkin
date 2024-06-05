namespace TrelloCopyWinForms.Windows.TableWindows
{
    partial class TableWindow
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
            this.TablePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.LeftTablesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.CreateInviteMessBut = new MaterialSkin.Controls.MaterialButton();
            this.CreateTableBut = new MaterialSkin.Controls.MaterialButton();
            this.EnterCodeBut = new MaterialSkin.Controls.MaterialButton();
            this.DeleteUsers = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // TablePanel
            // 
            this.TablePanel.AllowDrop = true;
            this.TablePanel.AutoScroll = true;
            this.TablePanel.Location = new System.Drawing.Point(147, 67);
            this.TablePanel.Name = "TablePanel";
            this.TablePanel.Size = new System.Drawing.Size(650, 457);
            this.TablePanel.TabIndex = 1;
            this.TablePanel.WrapContents = false;
            // 
            // LeftTablesPanel
            // 
            this.LeftTablesPanel.AutoScroll = true;
            this.LeftTablesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeftTablesPanel.Location = new System.Drawing.Point(0, 67);
            this.LeftTablesPanel.Name = "LeftTablesPanel";
            this.LeftTablesPanel.Size = new System.Drawing.Size(145, 267);
            this.LeftTablesPanel.TabIndex = 0;
            // 
            // CreateInviteMessBut
            // 
            this.CreateInviteMessBut.AutoSize = false;
            this.CreateInviteMessBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateInviteMessBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.CreateInviteMessBut.Depth = 0;
            this.CreateInviteMessBut.HighEmphasis = true;
            this.CreateInviteMessBut.Icon = null;
            this.CreateInviteMessBut.Location = new System.Drawing.Point(0, 478);
            this.CreateInviteMessBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateInviteMessBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateInviteMessBut.Name = "CreateInviteMessBut";
            this.CreateInviteMessBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.CreateInviteMessBut.Size = new System.Drawing.Size(145, 46);
            this.CreateInviteMessBut.TabIndex = 0;
            this.CreateInviteMessBut.Text = "Сreate invite message";
            this.CreateInviteMessBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CreateInviteMessBut.UseAccentColor = false;
            this.CreateInviteMessBut.UseVisualStyleBackColor = true;
            this.CreateInviteMessBut.Click += new System.EventHandler(this.CreateInviteMessBut_Click);
            // 
            // CreateTableBut
            // 
            this.CreateTableBut.AutoSize = false;
            this.CreateTableBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateTableBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.CreateTableBut.Depth = 0;
            this.CreateTableBut.HighEmphasis = true;
            this.CreateTableBut.Icon = null;
            this.CreateTableBut.Location = new System.Drawing.Point(0, 430);
            this.CreateTableBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateTableBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateTableBut.Name = "CreateTableBut";
            this.CreateTableBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.CreateTableBut.Size = new System.Drawing.Size(145, 46);
            this.CreateTableBut.TabIndex = 2;
            this.CreateTableBut.Text = "Create Table";
            this.CreateTableBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CreateTableBut.UseAccentColor = false;
            this.CreateTableBut.UseVisualStyleBackColor = true;
            this.CreateTableBut.Click += new System.EventHandler(this.CreateTableBut_Click);
            // 
            // EnterCodeBut
            // 
            this.EnterCodeBut.AutoSize = false;
            this.EnterCodeBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EnterCodeBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.EnterCodeBut.Depth = 0;
            this.EnterCodeBut.HighEmphasis = true;
            this.EnterCodeBut.Icon = null;
            this.EnterCodeBut.Location = new System.Drawing.Point(0, 382);
            this.EnterCodeBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.EnterCodeBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.EnterCodeBut.Name = "EnterCodeBut";
            this.EnterCodeBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.EnterCodeBut.Size = new System.Drawing.Size(145, 46);
            this.EnterCodeBut.TabIndex = 3;
            this.EnterCodeBut.Text = "Enter Code";
            this.EnterCodeBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.EnterCodeBut.UseAccentColor = false;
            this.EnterCodeBut.UseVisualStyleBackColor = true;
            this.EnterCodeBut.Click += new System.EventHandler(this.EnterCodeBut_Click);
            // 
            // DeleteUsers
            // 
            this.DeleteUsers.AutoSize = false;
            this.DeleteUsers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DeleteUsers.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.DeleteUsers.Depth = 0;
            this.DeleteUsers.HighEmphasis = true;
            this.DeleteUsers.Icon = null;
            this.DeleteUsers.Location = new System.Drawing.Point(0, 335);
            this.DeleteUsers.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DeleteUsers.MouseState = MaterialSkin.MouseState.HOVER;
            this.DeleteUsers.Name = "DeleteUsers";
            this.DeleteUsers.NoAccentTextColor = System.Drawing.Color.Empty;
            this.DeleteUsers.Size = new System.Drawing.Size(145, 46);
            this.DeleteUsers.TabIndex = 4;
            this.DeleteUsers.Text = "Delete Users";
            this.DeleteUsers.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.DeleteUsers.UseAccentColor = false;
            this.DeleteUsers.UseVisualStyleBackColor = true;
            this.DeleteUsers.Click += new System.EventHandler(this.DeleteUsers_Click);
            // 
            // TableWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.DeleteUsers);
            this.Controls.Add(this.EnterCodeBut);
            this.Controls.Add(this.CreateTableBut);
            this.Controls.Add(this.CreateInviteMessBut);
            this.Controls.Add(this.LeftTablesPanel);
            this.Controls.Add(this.TablePanel);
            this.Name = "TableWindow";
            this.Text = "TableWindow";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel TablePanel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FlowLayoutPanel LeftTablesPanel;
        private MaterialSkin.Controls.MaterialButton CreateInviteMessBut;
        private MaterialSkin.Controls.MaterialButton CreateTableBut;
        private MaterialSkin.Controls.MaterialButton EnterCodeBut;
        private MaterialSkin.Controls.MaterialButton DeleteUsers;
    }
}