using System;
using System.Windows.Forms;

namespace CharaBox3
{
    public partial class FormAddFile : Form
    {
        public string DisplayName => txtDisplayName.Text;
        public string FileName => !string.IsNullOrEmpty(txtFileName.Text) ? txtFileName.Text : txtDisplayName.Text;

        public FormAddFile()
        {
            InitializeComponent();
        }

        private void FormAddFile_Load(object sender, EventArgs e)
        {
            UpdateOKButton();
        }

        private void txtDisplayName_TextChanged(object sender, EventArgs e)
        {
            UpdateOKButton();
        }

        private void UpdateOKButton()
        {
            btnOK.Enabled = !string.IsNullOrEmpty(txtDisplayName.Text);
        }
    }
}
