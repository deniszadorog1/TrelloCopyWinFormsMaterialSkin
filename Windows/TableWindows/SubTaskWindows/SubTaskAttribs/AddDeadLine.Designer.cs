namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs
{
    partial class AddDeadLine
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
            this.StartDateLB = new MaterialSkin.Controls.MaterialLabel();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDateBox = new System.Windows.Forms.CheckBox();
            this.EndDateCheckBox = new System.Windows.Forms.CheckBox();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateLB = new MaterialSkin.Controls.MaterialLabel();
            this.AddBut = new MaterialSkin.Controls.MaterialButton();
            this.BackBut = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // StartDateLB
            // 
            this.StartDateLB.AutoSize = true;
            this.StartDateLB.Depth = 0;
            this.StartDateLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.StartDateLB.Location = new System.Drawing.Point(38, 87);
            this.StartDateLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartDateLB.Name = "StartDateLB";
            this.StartDateLB.Size = new System.Drawing.Size(72, 19);
            this.StartDateLB.TabIndex = 2;
            this.StartDateLB.Text = "Start Date";
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Location = new System.Drawing.Point(18, 109);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(213, 20);
            this.StartDatePicker.TabIndex = 4;
            // 
            // StartDateBox
            // 
            this.StartDateBox.AutoSize = true;
            this.StartDateBox.Location = new System.Drawing.Point(18, 89);
            this.StartDateBox.Name = "StartDateBox";
            this.StartDateBox.Size = new System.Drawing.Size(15, 14);
            this.StartDateBox.TabIndex = 5;
            this.StartDateBox.UseVisualStyleBackColor = true;
            // 
            // EndDateCheckBox
            // 
            this.EndDateCheckBox.AutoSize = true;
            this.EndDateCheckBox.Location = new System.Drawing.Point(18, 157);
            this.EndDateCheckBox.Name = "EndDateCheckBox";
            this.EndDateCheckBox.Size = new System.Drawing.Size(15, 14);
            this.EndDateCheckBox.TabIndex = 8;
            this.EndDateCheckBox.UseVisualStyleBackColor = true;
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Location = new System.Drawing.Point(18, 177);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(213, 20);
            this.EndDatePicker.TabIndex = 7;
            // 
            // EndDateLB
            // 
            this.EndDateLB.AutoSize = true;
            this.EndDateLB.Depth = 0;
            this.EndDateLB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.EndDateLB.Location = new System.Drawing.Point(38, 155);
            this.EndDateLB.MouseState = MaterialSkin.MouseState.HOVER;
            this.EndDateLB.Name = "EndDateLB";
            this.EndDateLB.Size = new System.Drawing.Size(69, 19);
            this.EndDateLB.TabIndex = 6;
            this.EndDateLB.Text = "End Date ";
            // 
            // AddBut
            // 
            this.AddBut.AutoSize = false;
            this.AddBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.AddBut.Depth = 0;
            this.AddBut.HighEmphasis = true;
            this.AddBut.Icon = null;
            this.AddBut.Location = new System.Drawing.Point(18, 224);
            this.AddBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddBut.Name = "AddBut";
            this.AddBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.AddBut.Size = new System.Drawing.Size(158, 36);
            this.AddBut.TabIndex = 10;
            this.AddBut.Text = "Add ";
            this.AddBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AddBut.UseAccentColor = false;
            this.AddBut.UseVisualStyleBackColor = true;
            this.AddBut.Click += new System.EventHandler(this.AddBut_Click);
            // 
            // BackBut
            // 
            this.BackBut.AutoSize = false;
            this.BackBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BackBut.Depth = 0;
            this.BackBut.HighEmphasis = true;
            this.BackBut.Icon = null;
            this.BackBut.Location = new System.Drawing.Point(18, 272);
            this.BackBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBut.Name = "BackBut";
            this.BackBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BackBut.Size = new System.Drawing.Size(158, 36);
            this.BackBut.TabIndex = 13;
            this.BackBut.Text = "Back";
            this.BackBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BackBut.UseAccentColor = false;
            this.BackBut.UseVisualStyleBackColor = true;
            this.BackBut.Click += new System.EventHandler(this.BackBut_Click);
            // 
            // AddDeadLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 335);
            this.Controls.Add(this.BackBut);
            this.Controls.Add(this.AddBut);
            this.Controls.Add(this.EndDateCheckBox);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.EndDateLB);
            this.Controls.Add(this.StartDateBox);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.StartDateLB);
            this.Name = "AddDeadLine";
            this.Text = "AddDeadLine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel StartDateLB;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.CheckBox StartDateBox;
        private System.Windows.Forms.CheckBox EndDateCheckBox;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private MaterialSkin.Controls.MaterialLabel EndDateLB;
        private MaterialSkin.Controls.MaterialButton AddBut;
        private MaterialSkin.Controls.MaterialButton BackBut;
    }
}