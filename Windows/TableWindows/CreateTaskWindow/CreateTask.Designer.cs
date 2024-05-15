namespace TrelloCopyWinForms.Windows.TableWindows.CreateTaskWindow
{
    partial class CreateTask
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
            this.TaskNameBox = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.AddTaskBut = new MaterialSkin.Controls.MaterialButton();
            this.BackBut = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // TaskNameBox
            // 
            this.TaskNameBox.AnimateReadOnly = false;
            this.TaskNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TaskNameBox.Depth = 0;
            this.TaskNameBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TaskNameBox.LeadingIcon = null;
            this.TaskNameBox.Location = new System.Drawing.Point(18, 111);
            this.TaskNameBox.MaxLength = 50;
            this.TaskNameBox.MouseState = MaterialSkin.MouseState.OUT;
            this.TaskNameBox.Multiline = false;
            this.TaskNameBox.Name = "TaskNameBox";
            this.TaskNameBox.Size = new System.Drawing.Size(321, 50);
            this.TaskNameBox.TabIndex = 0;
            this.TaskNameBox.Text = "";
            this.TaskNameBox.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(15, 89);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(82, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Task Name";
            // 
            // AddTaskBut
            // 
            this.AddTaskBut.AutoSize = false;
            this.AddTaskBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddTaskBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.AddTaskBut.Depth = 0;
            this.AddTaskBut.HighEmphasis = true;
            this.AddTaskBut.Icon = null;
            this.AddTaskBut.Location = new System.Drawing.Point(18, 189);
            this.AddTaskBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddTaskBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddTaskBut.Name = "AddTaskBut";
            this.AddTaskBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.AddTaskBut.Size = new System.Drawing.Size(151, 36);
            this.AddTaskBut.TabIndex = 2;
            this.AddTaskBut.Text = "Add Task";
            this.AddTaskBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AddTaskBut.UseAccentColor = false;
            this.AddTaskBut.UseVisualStyleBackColor = true;
            this.AddTaskBut.Click += new System.EventHandler(this.AddTaskBut_Click);
            // 
            // BackBut
            // 
            this.BackBut.AutoSize = false;
            this.BackBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBut.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BackBut.Depth = 0;
            this.BackBut.HighEmphasis = true;
            this.BackBut.Icon = null;
            this.BackBut.Location = new System.Drawing.Point(188, 189);
            this.BackBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBut.Name = "BackBut";
            this.BackBut.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BackBut.Size = new System.Drawing.Size(151, 36);
            this.BackBut.TabIndex = 3;
            this.BackBut.Text = "Back";
            this.BackBut.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BackBut.UseAccentColor = false;
            this.BackBut.UseVisualStyleBackColor = true;
            this.BackBut.Click += new System.EventHandler(this.BackBut_Click);
            // 
            // CreateTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 248);
            this.Controls.Add(this.BackBut);
            this.Controls.Add(this.AddTaskBut);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.TaskNameBox);
            this.Name = "CreateTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CreateTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox TaskNameBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton AddTaskBut;
        private MaterialSkin.Controls.MaterialButton BackBut;
    }
}