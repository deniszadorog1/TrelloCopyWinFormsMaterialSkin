namespace TrelloCopyWinForms.Windows.TableWindows
{
    partial class CreateInviteMessage
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
            this.components = new System.ComponentModel.Container();
            this.TypeBox = new MaterialSkin.Controls.MaterialComboBox();
            this.UserTypeLb = new MaterialSkin.Controls.MaterialLabel();
            this.GenerateCodeBut = new MaterialSkin.Controls.MaterialButton();
            this.CodeBox = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.GenedCodeLB = new MaterialSkin.Controls.MaterialLabel();
            this.CopyCode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // TypeBox
            // 
            this.TypeBox.AutoResize = false;
            this.TypeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TypeBox.Depth = 0;
            this.TypeBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.TypeBox.DropDownHeight = 174;
            this.TypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeBox.DropDownWidth = 121;
            this.TypeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.TypeBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TypeBox.FormattingEnabled = true;
            this.TypeBox.IntegralHeight = false;
            this.TypeBox.ItemHeight = 43;
            this.TypeBox.Location = new System.Drawing.Point(6, 105);
            this.TypeBox.MaxDropDownItems = 4;
            this.TypeBox.MouseState = MaterialSkin.MouseState.OUT;
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(220, 49);
            this.TypeBox.StartIndex = 0;
            this.TypeBox.TabIndex = 0;
            // 
            // UserTypeLb
            // 
            this.UserTypeLb.AutoSize = true;
            this.UserTypeLb.Depth = 0;
            this.UserTypeLb.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.UserTypeLb.Location = new System.Drawing.Point(6, 83);
            this.UserTypeLb.MouseState = MaterialSkin.MouseState.HOVER;
            this.UserTypeLb.Name = "UserTypeLb";
            this.UserTypeLb.Size = new System.Drawing.Size(115, 19);
            this.UserTypeLb.TabIndex = 1;
            this.UserTypeLb.Text = "User type to add";
            // 
            // GenerateCodeBut
            // 
            this.GenerateCodeBut.AutoSize = false;
            this.GenerateCodeBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GenerateCodeBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.GenerateCodeBut.Depth = 0;
            this.GenerateCodeBut.HighEmphasis = true;
            this.GenerateCodeBut.Icon = null;
            this.GenerateCodeBut.Location = new System.Drawing.Point(6, 163);
            this.GenerateCodeBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.GenerateCodeBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.GenerateCodeBut.Name = "GenerateCodeBut";
            this.GenerateCodeBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.GenerateCodeBut.Size = new System.Drawing.Size(220, 36);
            this.GenerateCodeBut.TabIndex = 2;
            this.GenerateCodeBut.Text = "Generate Code";
            this.GenerateCodeBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.GenerateCodeBut.UseAccentColor = false;
            this.GenerateCodeBut.UseVisualStyleBackColor = true;
            this.GenerateCodeBut.Click += new System.EventHandler(this.GenerateCodeBut_Click);
            // 
            // CodeBox
            // 
            this.CodeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CodeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CodeBox.ContextMenuStrip = this.CopyCode;
            this.CodeBox.Depth = 0;
            this.CodeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.CodeBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CodeBox.Location = new System.Drawing.Point(248, 105);
            this.CodeBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.CodeBox.Name = "CodeBox";
            this.CodeBox.ReadOnly = true;
            this.CodeBox.Size = new System.Drawing.Size(176, 94);
            this.CodeBox.TabIndex = 3;
            this.CodeBox.Text = "";
            // 
            // GenedCodeLB
            // 
            this.GenedCodeLB.AutoSize = true;
            this.GenedCodeLB.Depth = 0;
            this.GenedCodeLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.GenedCodeLB.Location = new System.Drawing.Point(245, 83);
            this.GenedCodeLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.GenedCodeLB.Name = "GenedCodeLB";
            this.GenedCodeLB.Size = new System.Drawing.Size(113, 19);
            this.GenedCodeLB.TabIndex = 4;
            this.GenedCodeLB.Text = "Generated Code";
            // 
            // CopyCode
            // 
            this.CopyCode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.CopyCode.Name = "CopyCode";
            this.CopyCode.Size = new System.Drawing.Size(103, 26);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // CreateInviteMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 224);
            this.Controls.Add(this.GenedCodeLB);
            this.Controls.Add(this.CodeBox);
            this.Controls.Add(this.GenerateCodeBut);
            this.Controls.Add(this.UserTypeLb);
            this.Controls.Add(this.TypeBox);
            this.Name = "CreateInviteMessage";
            this.Text = "CreateInviteMessage";
            this.CopyCode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox TypeBox;
        private MaterialSkin.Controls.MaterialLabel UserTypeLb;
        private MaterialSkin.Controls.MaterialButton GenerateCodeBut;
        private MaterialSkin.Controls.MaterialMultiLineTextBox CodeBox;
        private MaterialSkin.Controls.MaterialLabel GenedCodeLB;
        private System.Windows.Forms.ContextMenuStrip CopyCode;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    }
}