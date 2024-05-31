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
            this.SuspendLayout();
            // 
            // TablePanel
            // 
            this.TablePanel.AllowDrop = true;
            this.TablePanel.AutoScroll = true;
            this.TablePanel.Location = new System.Drawing.Point(147, 67);
            this.TablePanel.Name = "TablePanel";
            this.TablePanel.Size = new System.Drawing.Size(650, 380);
            this.TablePanel.TabIndex = 1;
            this.TablePanel.WrapContents = false;
            this.TablePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TablePanel_Paint);
            // 
            // LeftTablesPanel
            // 
            this.LeftTablesPanel.Location = new System.Drawing.Point(0, 67);
            this.LeftTablesPanel.Name = "LeftTablesPanel";
            this.LeftTablesPanel.Size = new System.Drawing.Size(145, 318);
            this.LeftTablesPanel.TabIndex = 0;
            // 
            // TableWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}