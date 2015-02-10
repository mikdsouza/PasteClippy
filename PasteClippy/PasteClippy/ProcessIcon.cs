using PasteClippy.PasteObjects;
using PasteClippy.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasteClippy
{
    /// <summary>
    /// This class shows the notification tray icon and handles the mouse events
    /// </summary>
    public class ProcessIcon: IDisposable
    {
        private NotifyIcon icon;

        private PasteObjectManager manager;

        /// <summary>
        /// Constructs an new instance
        /// </summary>
        public ProcessIcon()
        {
            icon = new NotifyIcon();
            manager = new PasteObjectManager();
            manager.Size = 10;
        }

        /// <summary>
        /// Dispose of the icon object
        /// </summary>
        public void Dispose()
        {
            icon.Dispose();
        }

        /// <summary>
        /// Show the notification icon
        /// </summary>
        public void Display()
        {
            icon.MouseClick += icon_MouseClick;
            icon.Icon = Resources.clippy___tray;
            icon.Text = "PasteClippy";
            icon.Visible = true;

            icon.ContextMenuStrip = manager.Menu;
        }

        private void icon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                manager.GetClipboardText();
            }
            else if(e.Button == MouseButtons.Right)
            {
                manager.InitialiseMenuStrip();
            }
        }
    }
}
