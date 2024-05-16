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
            this.BGImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BGImage)).BeginInit();
            this.SuspendLayout();
            // 
            // TablePanel
            // 
            this.TablePanel.AllowDrop = true;
            this.TablePanel.AutoScroll = true;
            this.TablePanel.Location = new System.Drawing.Point(6, 79);
            this.TablePanel.Name = "TablePanel";
            this.TablePanel.Size = new System.Drawing.Size(788, 302);
            this.TablePanel.TabIndex = 1;
            this.TablePanel.WrapContents = false;
            // 
            // BGImage
            // 
            this.BGImage.BackColor = System.Drawing.SystemColors.Control;
            this.BGImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BGImage.Location = new System.Drawing.Point(6, 116);
            this.BGImage.Name = "BGImage";
            this.BGImage.Size = new System.Drawing.Size(788, 328);
            this.BGImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BGImage.TabIndex = 0;
            this.BGImage.TabStop = false;
            this.BGImage.Click += new System.EventHandler(this.BGImage_Click);
            // 
            // TableWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TablePanel);
            this.Controls.Add(this.BGImage);
            this.Name = "TableWindow";
            this.Text = "TableWindow";
            ((System.ComponentModel.ISupportInitialize)(this.BGImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox BGImage;
        private System.Windows.Forms.FlowLayoutPanel TablePanel;
    }
}