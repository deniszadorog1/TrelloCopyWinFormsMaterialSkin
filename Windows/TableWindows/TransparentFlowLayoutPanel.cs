using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrelloCopyWinForms.Windows.TableWindows
{
    public class TransparentFlowLayoutPanel : FlowLayoutPanel
    {
        public TransparentFlowLayoutPanel()
        {
            // Встановити стиль для підтримки прозорості
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Не малювати фоновий колір
        }
    }
}
