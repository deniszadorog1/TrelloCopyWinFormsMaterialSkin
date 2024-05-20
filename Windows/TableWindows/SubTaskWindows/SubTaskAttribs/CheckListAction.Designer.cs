namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs
{
    partial class CheckListAction
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
            this.CheckNameLb = new MaterialSkin.Controls.MaterialLabel();
            this.CheckName = new MaterialSkin.Controls.MaterialTextBox();
            this.AddBut = new MaterialSkin.Controls.MaterialButton();
            this.CopyFromLB = new MaterialSkin.Controls.MaterialLabel();
            this.ChecosenCheckListLB = new MaterialSkin.Controls.MaterialLabel();
            this.ChosenCheckList = new MaterialSkin.Controls.MaterialLabel();
            this.CheckBoxesToCopy = new System.Windows.Forms.FlowLayoutPanel();
            this.ClearCopyBut = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // CheckNameLb
            // 
            this.CheckNameLb.AutoSize = true;
            this.CheckNameLb.Depth = 0;
            this.CheckNameLb.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.CheckNameLb.Location = new System.Drawing.Point(37, 88);
            this.CheckNameLb.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckNameLb.Name = "CheckNameLb";
            this.CheckNameLb.Size = new System.Drawing.Size(113, 19);
            this.CheckNameLb.TabIndex = 0;
            this.CheckNameLb.Text = "Check list name";
            // 
            // CheckName
            // 
            this.CheckName.AnimateReadOnly = false;
            this.CheckName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CheckName.Depth = 0;
            this.CheckName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.CheckName.LeadingIcon = null;
            this.CheckName.Location = new System.Drawing.Point(40, 121);
            this.CheckName.MaxLength = 50;
            this.CheckName.MouseState = MaterialSkin.MouseState.OUT;
            this.CheckName.Multiline = false;
            this.CheckName.Name = "CheckName";
            this.CheckName.Size = new System.Drawing.Size(208, 50);
            this.CheckName.TabIndex = 1;
            this.CheckName.Text = "";
            this.CheckName.TrailingIcon = null;
            // 
            // AddBut
            // 
            this.AddBut.AutoSize = false;
            this.AddBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.AddBut.Depth = 0;
            this.AddBut.HighEmphasis = true;
            this.AddBut.Icon = null;
            this.AddBut.Location = new System.Drawing.Point(276, 275);
            this.AddBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddBut.Name = "AddBut";
            this.AddBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.AddBut.Size = new System.Drawing.Size(208, 36);
            this.AddBut.TabIndex = 2;
            this.AddBut.Text = "Add box";
            this.AddBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AddBut.UseAccentColor = false;
            this.AddBut.UseVisualStyleBackColor = true;
            this.AddBut.Click += new System.EventHandler(this.AddBut_Click);
            // 
            // CopyFromLB
            // 
            this.CopyFromLB.AutoSize = true;
            this.CopyFromLB.Depth = 0;
            this.CopyFromLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.CopyFromLB.Location = new System.Drawing.Point(37, 180);
            this.CopyFromLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.CopyFromLB.Name = "CopyFromLB";
            this.CopyFromLB.Size = new System.Drawing.Size(150, 19);
            this.CopyFromLB.TabIndex = 4;
            this.CopyFromLB.Text = "Copy Check list From";
            // 
            // ChecosenCheckListLB
            // 
            this.ChecosenCheckListLB.AutoSize = true;
            this.ChecosenCheckListLB.Depth = 0;
            this.ChecosenCheckListLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ChecosenCheckListLB.Location = new System.Drawing.Point(273, 88);
            this.ChecosenCheckListLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChecosenCheckListLB.Name = "ChecosenCheckListLB";
            this.ChecosenCheckListLB.Size = new System.Drawing.Size(124, 19);
            this.ChecosenCheckListLB.TabIndex = 5;
            this.ChecosenCheckListLB.Text = "Chosen check list";
            // 
            // ChosenCheckList
            // 
            this.ChosenCheckList.AutoSize = true;
            this.ChosenCheckList.Depth = 0;
            this.ChosenCheckList.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ChosenCheckList.Location = new System.Drawing.Point(273, 135);
            this.ChosenCheckList.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChosenCheckList.Name = "ChosenCheckList";
            this.ChosenCheckList.Size = new System.Drawing.Size(5, 19);
            this.ChosenCheckList.TabIndex = 6;
            this.ChosenCheckList.Text = "-";
            // 
            // CheckBoxesToCopy
            // 
            this.CheckBoxesToCopy.AutoScroll = true;
            this.CheckBoxesToCopy.Location = new System.Drawing.Point(40, 211);
            this.CheckBoxesToCopy.Name = "CheckBoxesToCopy";
            this.CheckBoxesToCopy.Size = new System.Drawing.Size(200, 100);
            this.CheckBoxesToCopy.TabIndex = 7;
            // 
            // ClearCopyBut
            // 
            this.ClearCopyBut.AutoSize = false;
            this.ClearCopyBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClearCopyBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ClearCopyBut.Depth = 0;
            this.ClearCopyBut.HighEmphasis = true;
            this.ClearCopyBut.Icon = null;
            this.ClearCopyBut.Location = new System.Drawing.Point(276, 227);
            this.ClearCopyBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ClearCopyBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.ClearCopyBut.Name = "ClearCopyBut";
            this.ClearCopyBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ClearCopyBut.Size = new System.Drawing.Size(208, 36);
            this.ClearCopyBut.TabIndex = 8;
            this.ClearCopyBut.Text = "Clear copy";
            this.ClearCopyBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ClearCopyBut.UseAccentColor = false;
            this.ClearCopyBut.UseVisualStyleBackColor = true;
            this.ClearCopyBut.Click += new System.EventHandler(this.ClearCopyBut_Click);
            // 
            // CheckListAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 338);
            this.Controls.Add(this.ClearCopyBut);
            this.Controls.Add(this.CheckBoxesToCopy);
            this.Controls.Add(this.ChosenCheckList);
            this.Controls.Add(this.ChecosenCheckListLB);
            this.Controls.Add(this.CopyFromLB);
            this.Controls.Add(this.AddBut);
            this.Controls.Add(this.CheckName);
            this.Controls.Add(this.CheckNameLb);
            this.Name = "CheckListAction";
            this.Text = "CheckBoxAction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel CheckNameLb;
        private MaterialSkin.Controls.MaterialTextBox CheckName;
        private MaterialSkin.Controls.MaterialButton AddBut;
        private MaterialSkin.Controls.MaterialLabel CopyFromLB;
        private MaterialSkin.Controls.MaterialLabel ChecosenCheckListLB;
        private MaterialSkin.Controls.MaterialLabel ChosenCheckList;
        private System.Windows.Forms.FlowLayoutPanel CheckBoxesToCopy;
        private MaterialSkin.Controls.MaterialButton ClearCopyBut;
    }
}