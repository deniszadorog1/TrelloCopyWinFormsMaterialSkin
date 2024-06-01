namespace TrelloCopyWinForms.Windows.CreateTableWindow
{
    partial class CreateTable
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
            this.BackFontLB = new MaterialSkin.Controls.MaterialLabel();
            this.TableNameLB = new MaterialSkin.Controls.MaterialLabel();
            this.TableNameBox = new MaterialSkin.Controls.MaterialTextBox();
            this.CreateBut = new MaterialSkin.Controls.MaterialButton();
            this.BackBut = new MaterialSkin.Controls.MaterialButton();
            this.tableBgColor = new System.Windows.Forms.ColorDialog();
            this.ChooseBGBut = new MaterialSkin.Controls.MaterialButton();
            this.ChosenBG = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ChosenBG)).BeginInit();
            this.SuspendLayout();
            // 
            // BackFontLB
            // 
            this.BackFontLB.AutoSize = true;
            this.BackFontLB.Depth = 0;
            this.BackFontLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.BackFontLB.Location = new System.Drawing.Point(337, 89);
            this.BackFontLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackFontLB.Name = "BackFontLB";
            this.BackFontLB.Size = new System.Drawing.Size(117, 19);
            this.BackFontLB.TabIndex = 2;
            this.BackFontLB.Text = "Chosen bg Color";
            // 
            // TableNameLB
            // 
            this.TableNameLB.AutoSize = true;
            this.TableNameLB.Depth = 0;
            this.TableNameLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TableNameLB.Location = new System.Drawing.Point(18, 121);
            this.TableNameLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.TableNameLB.Name = "TableNameLB";
            this.TableNameLB.Size = new System.Drawing.Size(87, 19);
            this.TableNameLB.TabIndex = 3;
            this.TableNameLB.Text = "Table Name";
            // 
            // TableNameBox
            // 
            this.TableNameBox.AnimateReadOnly = false;
            this.TableNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TableNameBox.Depth = 0;
            this.TableNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TableNameBox.LeadingIcon = null;
            this.TableNameBox.Location = new System.Drawing.Point(21, 143);
            this.TableNameBox.MaxLength = 32;
            this.TableNameBox.MouseState = MaterialSkin.MouseState.OUT;
            this.TableNameBox.Multiline = false;
            this.TableNameBox.Name = "TableNameBox";
            this.TableNameBox.Size = new System.Drawing.Size(250, 50);
            this.TableNameBox.TabIndex = 4;
            this.TableNameBox.Text = "";
            this.TableNameBox.TrailingIcon = null;
            // 
            // CreateBut
            // 
            this.CreateBut.AutoSize = false;
            this.CreateBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.CreateBut.Depth = 0;
            this.CreateBut.HighEmphasis = true;
            this.CreateBut.Icon = null;
            this.CreateBut.Location = new System.Drawing.Point(7, 268);
            this.CreateBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateBut.Name = "CreateBut";
            this.CreateBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.CreateBut.Size = new System.Drawing.Size(274, 47);
            this.CreateBut.TabIndex = 5;
            this.CreateBut.Text = "Create";
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
            this.BackBut.Location = new System.Drawing.Point(7, 327);
            this.BackBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBut.Name = "BackBut";
            this.BackBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BackBut.Size = new System.Drawing.Size(556, 47);
            this.BackBut.TabIndex = 6;
            this.BackBut.Text = "Back";
            this.BackBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BackBut.UseAccentColor = false;
            this.BackBut.UseVisualStyleBackColor = true;
            this.BackBut.Click += new System.EventHandler(this.BackBut_Click);
            // 
            // ChooseBGBut
            // 
            this.ChooseBGBut.AutoSize = false;
            this.ChooseBGBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChooseBGBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ChooseBGBut.Depth = 0;
            this.ChooseBGBut.HighEmphasis = true;
            this.ChooseBGBut.Icon = null;
            this.ChooseBGBut.Location = new System.Drawing.Point(289, 268);
            this.ChooseBGBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ChooseBGBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChooseBGBut.Name = "ChooseBGBut";
            this.ChooseBGBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ChooseBGBut.Size = new System.Drawing.Size(274, 47);
            this.ChooseBGBut.TabIndex = 7;
            this.ChooseBGBut.Text = "Choose BG Color";
            this.ChooseBGBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ChooseBGBut.UseAccentColor = false;
            this.ChooseBGBut.UseVisualStyleBackColor = true;
            this.ChooseBGBut.Click += new System.EventHandler(this.ChooseBGBut_Click);
            // 
            // ChosenBG
            // 
            this.ChosenBG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChosenBG.Location = new System.Drawing.Point(340, 111);
            this.ChosenBG.Name = "ChosenBG";
            this.ChosenBG.Size = new System.Drawing.Size(223, 139);
            this.ChosenBG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ChosenBG.TabIndex = 1;
            this.ChosenBG.TabStop = false;
            // 
            // CreateTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 393);
            this.Controls.Add(this.ChooseBGBut);
            this.Controls.Add(this.BackBut);
            this.Controls.Add(this.TableNameBox);
            this.Controls.Add(this.CreateBut);
            this.Controls.Add(this.TableNameLB);
            this.Controls.Add(this.BackFontLB);
            this.Controls.Add(this.ChosenBG);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "CreateTable";
            this.Padding = new System.Windows.Forms.Padding(3, 74, 3, 3);
            this.Text = "CreateTable";
            ((System.ComponentModel.ISupportInitialize)(this.ChosenBG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox ChosenBG;
        private MaterialSkin.Controls.MaterialLabel BackFontLB;
        private MaterialSkin.Controls.MaterialLabel TableNameLB;
        private MaterialSkin.Controls.MaterialTextBox TableNameBox;
        private MaterialSkin.Controls.MaterialButton CreateBut;
        private MaterialSkin.Controls.MaterialButton BackBut;
        private System.Windows.Forms.ColorDialog tableBgColor;
        private MaterialSkin.Controls.MaterialButton ChooseBGBut;
    }
}