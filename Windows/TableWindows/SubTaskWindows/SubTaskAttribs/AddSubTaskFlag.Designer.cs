namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs
{
    partial class AddSubTaskFlag
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
            this.ColorsLB = new MaterialSkin.Controls.MaterialLabel();
            this.ColorsBox = new MaterialSkin.Controls.MaterialCheckedListBox();
            this.ChosenColorLB = new MaterialSkin.Controls.MaterialLabel();
            this.BackBut = new MaterialSkin.Controls.MaterialButton();
            this.OwnColorBut = new MaterialSkin.Controls.MaterialButton();
            this.TagNameBox = new MaterialSkin.Controls.MaterialTextBox();
            this.TagNameLB = new MaterialSkin.Controls.MaterialLabel();
            this.ColorAction = new MaterialSkin.Controls.MaterialButton();
            this.ChoseColor = new System.Windows.Forms.ColorDialog();
            this.ChosenColorBox = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ColorsLB
            // 
            this.ColorsLB.AutoSize = true;
            this.ColorsLB.Depth = 0;
            this.ColorsLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ColorsLB.Location = new System.Drawing.Point(18, 86);
            this.ColorsLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.ColorsLB.Name = "ColorsLB";
            this.ColorsLB.Size = new System.Drawing.Size(46, 19);
            this.ColorsLB.TabIndex = 0;
            this.ColorsLB.Text = "Colors";
            // 
            // ColorsBox
            // 
            this.ColorsBox.AutoScroll = true;
            this.ColorsBox.BackColor = System.Drawing.SystemColors.Control;
            this.ColorsBox.Depth = 0;
            this.ColorsBox.Location = new System.Drawing.Point(21, 117);
            this.ColorsBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.ColorsBox.Name = "ColorsBox";
            this.ColorsBox.Size = new System.Drawing.Size(233, 291);
            this.ColorsBox.Striped = false;
            this.ColorsBox.StripeDarkColor = System.Drawing.Color.Empty;
            this.ColorsBox.TabIndex = 2;
            // 
            // ChosenColorLB
            // 
            this.ChosenColorLB.AutoSize = true;
            this.ChosenColorLB.Depth = 0;
            this.ChosenColorLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ChosenColorLB.Location = new System.Drawing.Point(292, 86);
            this.ChosenColorLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChosenColorLB.Name = "ChosenColorLB";
            this.ChosenColorLB.Size = new System.Drawing.Size(98, 19);
            this.ChosenColorLB.TabIndex = 3;
            this.ChosenColorLB.Text = "New tag color";
            // 
            // BackBut
            // 
            this.BackBut.AutoSize = false;
            this.BackBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BackBut.Depth = 0;
            this.BackBut.HighEmphasis = true;
            this.BackBut.Icon = null;
            this.BackBut.Location = new System.Drawing.Point(342, 372);
            this.BackBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBut.Name = "BackBut";
            this.BackBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BackBut.Size = new System.Drawing.Size(156, 36);
            this.BackBut.TabIndex = 4;
            this.BackBut.Text = "Back";
            this.BackBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BackBut.UseAccentColor = false;
            this.BackBut.UseVisualStyleBackColor = true;
            this.BackBut.Click += new System.EventHandler(this.BackBut_Click);
            // 
            // OwnColorBut
            // 
            this.OwnColorBut.AutoSize = false;
            this.OwnColorBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OwnColorBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.OwnColorBut.Depth = 0;
            this.OwnColorBut.HighEmphasis = true;
            this.OwnColorBut.Icon = null;
            this.OwnColorBut.Location = new System.Drawing.Point(342, 173);
            this.OwnColorBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.OwnColorBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.OwnColorBut.Name = "OwnColorBut";
            this.OwnColorBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.OwnColorBut.Size = new System.Drawing.Size(156, 36);
            this.OwnColorBut.TabIndex = 5;
            this.OwnColorBut.Text = "Chose own color";
            this.OwnColorBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.OwnColorBut.UseAccentColor = false;
            this.OwnColorBut.UseVisualStyleBackColor = true;
            this.OwnColorBut.Click += new System.EventHandler(this.OwnColorBut_Click);
            // 
            // TagNameBox
            // 
            this.TagNameBox.AnimateReadOnly = false;
            this.TagNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TagNameBox.Depth = 0;
            this.TagNameBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TagNameBox.LeadingIcon = null;
            this.TagNameBox.Location = new System.Drawing.Point(295, 237);
            this.TagNameBox.MaxLength = 10;
            this.TagNameBox.MouseState = MaterialSkin.MouseState.OUT;
            this.TagNameBox.Multiline = false;
            this.TagNameBox.Name = "TagNameBox";
            this.TagNameBox.Size = new System.Drawing.Size(245, 50);
            this.TagNameBox.TabIndex = 7;
            this.TagNameBox.Text = "";
            this.TagNameBox.TrailingIcon = null;
            // 
            // TagNameLB
            // 
            this.TagNameLB.AutoSize = true;
            this.TagNameLB.Depth = 0;
            this.TagNameLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TagNameLB.Location = new System.Drawing.Point(292, 215);
            this.TagNameLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.TagNameLB.Name = "TagNameLB";
            this.TagNameLB.Size = new System.Drawing.Size(73, 19);
            this.TagNameLB.TabIndex = 8;
            this.TagNameLB.Text = "Tag name";
            // 
            // ColorAction
            // 
            this.ColorAction.AutoSize = false;
            this.ColorAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ColorAction.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ColorAction.Depth = 0;
            this.ColorAction.HighEmphasis = true;
            this.ColorAction.Icon = null;
            this.ColorAction.Location = new System.Drawing.Point(342, 296);
            this.ColorAction.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ColorAction.MouseState = MaterialSkin.MouseState.HOVER;
            this.ColorAction.Name = "ColorAction";
            this.ColorAction.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ColorAction.Size = new System.Drawing.Size(156, 36);
            this.ColorAction.TabIndex = 9;
            this.ColorAction.Text = "Add Color In List ";
            this.ColorAction.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ColorAction.UseAccentColor = false;
            this.ColorAction.UseVisualStyleBackColor = true;
            this.ColorAction.Click += new System.EventHandler(this.AddColorInListBut_Click);
            // 
            // ChosenColorBox
            // 
            this.ChosenColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChosenColorBox.Location = new System.Drawing.Point(295, 117);
            this.ChosenColorBox.Name = "ChosenColorBox";
            this.ChosenColorBox.Size = new System.Drawing.Size(245, 47);
            this.ChosenColorBox.TabIndex = 10;
            // 
            // AddSubTaskFlag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 450);
            this.Controls.Add(this.ChosenColorBox);
            this.Controls.Add(this.ColorAction);
            this.Controls.Add(this.TagNameLB);
            this.Controls.Add(this.TagNameBox);
            this.Controls.Add(this.OwnColorBut);
            this.Controls.Add(this.BackBut);
            this.Controls.Add(this.ChosenColorLB);
            this.Controls.Add(this.ColorsBox);
            this.Controls.Add(this.ColorsLB);
            this.Name = "AddSubTaskFlag";
            this.Text = "AddSubTaskFlag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel ColorsLB;
        private MaterialSkin.Controls.MaterialCheckedListBox ColorsBox;
        private MaterialSkin.Controls.MaterialLabel ChosenColorLB;
        private MaterialSkin.Controls.MaterialButton BackBut;
        private MaterialSkin.Controls.MaterialButton OwnColorBut;
        private MaterialSkin.Controls.MaterialTextBox TagNameBox;
        private MaterialSkin.Controls.MaterialLabel TagNameLB;
        private MaterialSkin.Controls.MaterialButton ColorAction;
        private System.Windows.Forms.ColorDialog ChoseColor;
        private System.Windows.Forms.Panel ChosenColorBox;
    }
}