using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CharaBox3
{
    public partial class FormAddFile : Form
    {
        public string DisplayName => txtDisplayName.Text;
        public string FileName => !string.IsNullOrEmpty(txtFileName.Text) ? txtFileName.Text : $"{txtDisplayName.Text}.dat";

        public string[] UsedTitles { get; set; }

        /// <summary>
        /// 使用不可能なファイル名(デバイス名として予約済みなんだとか)
        /// </summary>
        private readonly string[] invalidFileNames = {
            "AUX",
            "COM0", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
            "CON",
            "LPT0", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9",
            "NUL",
            "PRN",
        };

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

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            UpdateOKButton();
        }

        private void UpdateOKButton()
        {
            var ok = true;
            errorProvider.Clear();
            if (string.IsNullOrEmpty(DisplayName))
            {
                errorProvider.SetError(txtDisplayName, "表示名を記入してください。");
                ok = false;
            }
            if (UsedTitles.Contains(DisplayName))
            {
                errorProvider.SetError(txtDisplayName, $"{DisplayName}という表示名は既に使用されています。別の表示名を指定してください。");
                ok = false;
            }
            var errorChars = Path.GetInvalidFileNameChars().Where(c => FileName.Contains(c)).ToArray();
            if (errorChars.Any())
            {
                errorProvider.SetError(txtFileName, $"ファイル名に使えない文字({string.Join(", ", errorChars)})が含まれています。ファイル名を変更してください。");
                ok = false;
            }
            var fileTitle = Path.GetFileNameWithoutExtension(FileName).ToUpper();
            if (invalidFileNames.Contains(fileTitle))
            {
                errorProvider.SetError(txtFileName, $"{fileTitle}というファイル名は使えません。別のファイル名を指定してください。");
                ok = false;
            }
            var errPrefix = invalidFileNames.Select(f => $"{f}.").FirstOrDefault(p => fileTitle.StartsWith(p));
            if (errPrefix != null)
            {
                errorProvider.SetError(txtFileName, $"{errPrefix}で始まるファイル名は使えません。別のファイル名を指定してください。");
                ok = false;
            }
            if (File.Exists(FileName) || Directory.Exists(FileName))
            {
                errorProvider.SetError(txtFileName, $"{FileName}というファイル名は既に使用されています。別のファイル名を指定してください。");
                ok = false;
            }
            btnOK.Enabled = ok;
        }
    }
}
