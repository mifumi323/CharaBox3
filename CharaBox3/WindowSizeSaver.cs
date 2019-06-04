using System;
using System.Drawing;
using System.Windows.Forms;

namespace MifuminLib
{
    class WindowSizeSaver
    {
        Point location;
        Size size;

        public WindowSizeSaver(Form form)
        {
            location = form.Location;
            size = form.Size;
            WindowState = form.WindowState;
            form.Resize += new EventHandler(form_Event);
            form.Move += new EventHandler(form_Event);
        }

        private void form_Event(object sender, EventArgs e)
        {
            var form = (Form)sender;
            if ((WindowState = form.WindowState) == FormWindowState.Normal)
            {
                location = form.Location;
                size = form.Size;
            }
        }

        public Point Location => location;
        public Size Size => size;
        public FormWindowState WindowState { get; private set; }
    }
}
