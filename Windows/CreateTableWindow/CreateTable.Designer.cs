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
            this.BackgroundTypes = new MaterialSkin.Controls.MaterialCheckedListBox();
            this.ChosenBG = new System.Windows.Forms.PictureBox();
            this.BackFontLB = new MaterialSkin.Controls.MaterialLabel();
            this.TableNameLB = new MaterialSkin.Controls.MaterialLabel();
            this.TableNameBox = new MaterialSkin.Controls.MaterialTextBox();
            this.CreateBut = new MaterialSkin.Controls.MaterialButton();
            this.BackBut = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.ChosenBG)).BeginInit();
            this.SuspendLayout();
            // 
            // BackgroundTypes
            // 
            this.BackgroundTypes.AutoScroll = true;
            this.BackgroundTypes.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundTypes.Depth = 0;
            this.BackgroundTypes.Location = new System.Drawing.Point(7, 78);
            this.BackgroundTypes.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackgroundTypes.Name = "BackgroundTypes";
            this.BackgroundTypes.Size = new System.Drawing.Size(271, 435);
            this.BackgroundTypes.Striped = false;
            this.BackgroundTypes.StripeDarkColor = System.Drawing.Color.Empty;
            this.BackgroundTypes.TabIndex = 0;
            // 
            // ChosenBG
            // 
            this.ChosenBG.Location = new System.Drawing.Point(666, 199);
            this.ChosenBG.Name = "ChosenBG";
            this.ChosenBG.Size = new System.Drawing.Size(215, 125);
            this.ChosenBG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ChosenBG.TabIndex = 1;
            this.ChosenBG.TabStop = false;
            // 
            // BackFontLB
            // 
            this.BackFontLB.AutoSize = true;
            this.BackFontLB.Depth = 0;
            this.BackFontLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.BackFontLB.Location = new System.Drawing.Point(684, 177);
            this.BackFontLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackFontLB.Name = "BackFontLB";
            this.BackFontLB.Size = new System.Drawing.Size(125, 19);
            this.BackFontLB.TabIndex = 2;
            this.BackFontLB.Text = "Chosen BackFont";
            // 
            // TableNameLB
            // 
            this.TableNameLB.AutoSize = true;
            this.TableNameLB.Depth = 0;
            this.TableNameLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TableNameLB.Location = new System.Drawing.Point(344, 78);
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
            this.TableNameBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TableNameBox.LeadingIcon = null;
            this.TableNameBox.Location = new System.Drawing.Point(284, 100);
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
            this.CreateBut.Location = new System.Drawing.Point(319, 454);
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
            // 
            // BackBut
            // 
            this.BackBut.AutoSize = false;
            this.BackBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BackBut.Depth = 0;
            this.BackBut.HighEmphasis = true;
            this.BackBut.Icon = null;
            this.BackBut.Location = new System.Drawing.Point(620, 454);
            this.BackBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBut.Name = "BackBut";
            this.BackBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BackBut.Size = new System.Drawing.Size(274, 47);
            this.BackBut.TabIndex = 6;
            this.BackBut.Text = "Back";
            this.BackBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BackBut.UseAccentColor = false;
            this.BackBut.UseVisualStyleBackColor = true;
            this.BackBut.Click += new System.EventHandler(this.BackBut_Click);
            // 
            // CreateTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.BackBut);
            this.Controls.Add(this.TableNameBox);
            this.Controls.Add(this.CreateBut);
            this.Controls.Add(this.TableNameLB);
            this.Controls.Add(this.BackFontLB);
            this.Controls.Add(this.ChosenBG);
            this.Controls.Add(this.BackgroundTypes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "CreateTable";
            this.Padding = new System.Windows.Forms.Padding(3, 74, 3, 3);
            this.Text = "CreateTable";
            ((System.ComponentModel.ISupportInitialize)(this.ChosenBG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialCheckedListBox BackgroundTypes;
        private System.Windows.Forms.PictureBox ChosenBG;
        private MaterialSkin.Controls.MaterialLabel BackFontLB;
        private MaterialSkin.Controls.MaterialLabel TableNameLB;
        private MaterialSkin.Controls.MaterialTextBox TableNameBox;
        private MaterialSkin.Controls.MaterialButton CreateBut;
        private MaterialSkin.Controls.MaterialButton BackBut;
    }
}