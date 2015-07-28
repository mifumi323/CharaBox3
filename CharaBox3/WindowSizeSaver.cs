using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MifuminLib
{
    class WindowSizeSaver
    {
        Point location;
        Size size;
        FormWindowState state;

        public WindowSizeSaver(Form form)
        {
            location = form.Location;
            size = form.Size;
            state = form.WindowState;
            form.Resize += new EventHandler(form_Event);
            form.Move += new EventHandler(form_Event);
        }

        private void form_Event(object sender, EventArgs e)
        {
            Form form = (Form)sender;
            if ((state = form.WindowState) == FormWindowState.Normal)
            {
                location = form.Location;
                size = form.Size;
            }
        }

        public Point Location { get { return location; } }
        public Size Size { get { return size; } }
        public FormWindowState WindowState { get { return state; } }
    }
}
