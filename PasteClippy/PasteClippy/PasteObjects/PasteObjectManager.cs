using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasteClippy.PasteObjects
{
    /// <summary>
    /// This class manages the context menu and handles getting and setting the clipboard
    /// </summary>
    public class PasteObjectManager
    {
        private List<PasteObject> pasteObjects;

        /// <summary>
        /// Gets or sets the number of the clipboard items
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Gets the context menu for the icon
        /// </summary>
        public ContextMenuStrip Menu { get; private set; }

        /// <summary>
        /// Constructs a new instace
        /// </summary>
        public PasteObjectManager()
        {
            pasteObjects = new List<PasteObject>();
            
            Menu = new ContextMenuStrip();
        }

        /// <summary>
        /// Sets up all the menu items based on the current state of the manager
        /// </summary>
        public void InitialiseMenuStrip()
        {
            Menu.Items.Clear();

            ToolStripLabel title = new ToolStripLabel("Paste Clippy");
            title.Name = "title";
            Menu.Items.Add(title);

            Menu.Items.Add(new ToolStripSeparator());

            SetUp();

            Menu.Items.Add(new ToolStripSeparator());

            ToolStripMenuItem exit = new ToolStripMenuItem("Exit");
            exit.Click += exit_Click;
            Menu.Items.Add(exit);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Set up the menu from the paste objects
        /// </summary>
        private void SetUp()
        {
            foreach(PasteObject pObj in pasteObjects)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(pObj.ToString(50));
                item.Click += (sender, eventArgs) =>
                    {
                        Clipboard.SetText(pObj.PasteValue);
                    };

                Menu.Items.Add(item);
            }
        }

        /// <summary>
        /// Records clipboard text if the current item in the clipboard is text
        /// </summary>
        public void GetClipboardText()
        {
            if(Clipboard.ContainsText())
            {
                PasteObject paste = new PasteObject
                {
                    PasteValue = Clipboard.GetText()
                };

                if(pasteObjects.Count > Size)
                    pasteObjects.RemoveAt(0);

                pasteObjects.Add(paste);
            }
        }
    }
}
