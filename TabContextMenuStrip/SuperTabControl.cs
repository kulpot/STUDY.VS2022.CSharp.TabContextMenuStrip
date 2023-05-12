using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabContextMenuStrip
{
    class SuperTabControl : TabControl
    {
        private Point _lastClickPos;
        private ContextMenuStrip _CMS;

        public SuperTabControl()
        {
            _CMS = GetCMS();
        }

        private ContextMenuStrip GetCMS()
        {
            ContextMenuStrip CMS = new ContextMenuStrip();
            CMS.Items.Add("Close", null, new EventHandler(Item_Clicked));
            return CMS;
        }

        private void Item_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < this.TabCount; i++)
            {
                Rectangle rect = this.GetTabRect(i);

                //if (rect.Contains(this.PointToClient(Cursor.Position)))
                if(rect.Contains(this.PointToClient(_lastClickPos)))
                {
                    this.TabPages.RemoveAt(i);
                }
            }
        }

            protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _lastClickPos = Cursor.Position;
                _CMS.Show(Cursor.Position);
            }
        }
    }
}