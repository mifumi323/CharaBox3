using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CharaBox3
{
    public partial class FormEdit : Form
    {
        public CharaData.CharaInfo chara;
        public bool Canceled = true;

        string[] games = new string[0];

        public FormEdit()
        {
            InitializeComponent();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            txtHint.Text = "改行区切りで複数の名前を入力できます。\r\nリストに出るのは最初の名前だけです。";
        }

        private void txtGame_Enter(object sender, EventArgs e)
        {
            txtHint.Text = "改行区切りで複数の作品を入力できます。\r\nリストに出るのは最初の作品だけです。";
        }

        private void lstGame_Enter(object sender, EventArgs e)
        {
            txtHint.Text = "ダブルクリックで登場作品を追加できます。";
        }

        private void txtDescription_Enter(object sender, EventArgs e)
        {
            txtHint.Text = "説明を書きます。";
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            foreach (string game in games)
            {
                lstGame.Items.Add(game);
            }
            tvGraphic.Nodes.Add("", "なし");
            AddDiretory("bmp",tvGraphic.Nodes);
            foreach (CharaData.CharaInfo.Sex s in CharaData.sexes)
            {
                cmbSex.Items.Add(CharaData.GetSex(s));
            }
            tlpOther.RowStyles[0].Height = cmbSex.Height;
            tlpOther.RowStyles[1].Height = txtAge.Height;
            tlpOther.RowStyles[2].Height = txtSize.Height;
            // データ
            if (chara.name != null)
            {
                foreach (string name in chara.name)
                {
                    txtName.Text += name + "\r\n";
                }
            }
            if (chara.game != null)
            {
                foreach (string game in chara.game)
                {
                    txtGame.Text += game + "\r\n";
                }
            }
            txtDescription.Text = chara.description;
            TreeNode[] found = tvGraphic.Nodes.Find(chara.graphic, true);
            tvGraphic.SelectedNode = found.Length > 0 ? found[0] : tvGraphic.Nodes[0];
            cmbSex.SelectedIndex = (int)chara.sex;
            txtAge.Text = chara.age;
            txtSize.Text = chara.size;
        }

        private void cmbSex_Enter(object sender, EventArgs e)
        {
            txtHint.Text = "残念ながらオカマという項目はございません。";
        }

        private void txtAge_Enter(object sender, EventArgs e)
        {
            txtHint.Text = "代表作品での年齢です。";
        }

        private void txtSize_Enter(object sender, EventArgs e)
        {
            txtHint.Text = "代表作品での大きさです。\r\n立ちキャラなら身長、這いつくばってるなら体長、まん丸なら直径。";
        }

        void ShowImage(string file)
        {
            if (System.IO.File.Exists("bmp/" + file))
            {
                picGraphic.Image = Image.FromFile("bmp/" + file);
                if (picGraphic.Image.Width > picGraphic.Width || picGraphic.Image.Height > picGraphic.Height)
                {
                    picGraphic.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    picGraphic.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
            else
            {
                picGraphic.Image = null;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string[] lines, sep = { "\r\n" };
            // 名前
            lines = txtName.Text.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length > 0)
            {
                chara.name = lines;
            }
            else
            {
                txtHint.Text = "名前は必須です。";
                return;
            }
            // 登場作品
            lines = txtGame.Text.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length > 0)
            {
                chara.game = lines;
            }
            else
            {
                txtHint.Text = "登場作品は必須です。";
                return;
            }
            // 説明
            chara.description = txtDescription.Text;
            // 画像
            chara.graphic = tvGraphic.SelectedNode.Name;
            // 性別
            chara.sex = CharaData.GetSex(cmbSex.Text);
            // 年齢
            chara.age = txtAge.Text;
            // 大きさ
            chara.size = txtSize.Text;
            // 更新日
            chara.update = DateTime.Now;
            // 終了
            Canceled = false;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picGraphic_Resize(object sender, EventArgs e)
        {
            if (picGraphic.Image != null)
            {
                if (picGraphic.Image.Width > picGraphic.Width || picGraphic.Image.Height > picGraphic.Height)
                {
                    picGraphic.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    picGraphic.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
        }

        private void tvGraphic_Enter(object sender, EventArgs e)
        {
            txtHint.Text = "ここから画像を選びます。";
        }

        void AddDiretory(string dir, TreeNodeCollection nodes)
        {
            try
            {
                foreach (string subdir in System.IO.Directory.GetDirectories(dir, "*", System.IO.SearchOption.TopDirectoryOnly))
                {
                    TreeNode node = new TreeNode(System.IO.Path.GetFileName(subdir));
                    AddDiretory(subdir, node.Nodes);
                    nodes.Add(node);
                }
            }
            catch (Exception)
            {
            }
            try
            {
                foreach (string file in System.IO.Directory.GetFiles(dir, "*", System.IO.SearchOption.TopDirectoryOnly))
                {
                    TreeNode node = new TreeNode(System.IO.Path.GetFileName(file));
                    node.Name = file.Remove(0, 4);  // 最初の"bmp\"を取り除く
                    nodes.Add(node);
                }
            }
            catch (Exception)
            {
            }
        }

        private void tvGraphic_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowImage(e.Node.Name);
        }

        public void SetGames(CharaData.CharaInfo[] charaList)
        {
            games = new string[1];
            int count = 0;
            bool found;
            foreach (CharaData.CharaInfo chara in charaList)
            {
                foreach (string game in chara.game)
                {
                    found = false;
                    foreach (string item in games)
                    {
                        if (item == game)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        if (count >= games.Length) Array.Resize(ref games, count * 2);
                        games[count] = game;
                        count++;
                    }
                }
            }
            Array.Resize(ref games, count);
            Array.Sort(games);
        }

        private void lstGame_DoubleClick(object sender, EventArgs e)
        {
            txtGame.Text += lstGame.SelectedItem + "\r\n";
        }
    }
}