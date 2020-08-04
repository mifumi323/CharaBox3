using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using MifuminLib;

namespace CharaBox3
{
    public partial class Form1 : Form
    {
        CharaData data;
        Image imgDefault;

        enum ViewMode
        {
            ABC,
            Age,
            Size,
            Update,
            Description,

            Game,
            GameAge,
            GameSize,
            GameUpdate,
            GameDescription,
            GameSex,
            GameGraphics,

            Sex,
            SexAge,
            SexSize,
            SexUpdate,
            SexDescription,
            SexGame,
            SexGraphics,

            Graphics,
            GraphicsAge,
            GraphicsSize,
            GraphicsUpdate,
            GraphicsDescription,
            GraphicsGame,
            GraphicsSex,

            Find,
            FindAge,
            FindSize,
            FindUpdate,
            FindDescription,
            FindGame,
            FindSex,
            FindGraphics,

            None,
        };
        ViewMode view = ViewMode.None;
        int[] sortedList = new int[0];

        struct DataFiles { public string name, file; }
        DataFiles[] files = new DataFiles[0];

        CharaData.FindCondition find;

        bool save = true;

        WindowSizeSaver sizesaver;

        #region Compare

        private static readonly StringComparer scomp = StringComparer.Create(CultureInfo.GetCultureInfo(0x0011), true);
        public class ComparerABC : IComparer
        {
            readonly CharaData.CharaInfo[] chara;
            public ComparerABC(ref CharaData.CharaInfo[] c) { chara = c; }
            int IComparer.Compare(object x, object y)
            { return scomp.Compare(chara[(int)x].name[0], chara[(int)y].name[0]); }
        }
        public class ComparerGame : IComparer
        {
            readonly CharaData.CharaInfo[] chara;
            public ComparerGame(ref CharaData.CharaInfo[] c) { chara = c; }
            int IComparer.Compare(object x, object y)
            { return scomp.Compare(chara[(int)x].game[0], chara[(int)y].game[0]); }
        }
        public class ComparerSex : IComparer
        {
            readonly CharaData.CharaInfo[] chara;
            public ComparerSex(ref CharaData.CharaInfo[] c) { chara = c; }
            int IComparer.Compare(object x, object y)
            { return (int)chara[(int)x].sex - (int)chara[(int)y].sex; }
        }
        public class ComparerAge : IComparer
        {
            readonly CharaData.CharaInfo[] chara;
            readonly double[] age;
            public ComparerAge(ref CharaData.CharaInfo[] c)
            {
                chara = c;
                age = new double[chara.Length];
                for (int i = 0; i < chara.Length; i++)
                {
                    age[i] = chara[i].age != "" ? CharaData.pqaAge.GetValue(CharaData.GetAgeString(chara[i].age)) : -1;
                }
            }
            int IComparer.Compare(object x, object y)
            { return Math.Sign(age[(int)y] - age[(int)x]); }
        }
        public class ComparerSize : IComparer
        {
            readonly CharaData.CharaInfo[] chara;
            readonly double[] size;
            public ComparerSize(ref CharaData.CharaInfo[] c)
            {
                chara = c;
                size = new double[chara.Length];
                for (int i = 0; i < chara.Length; i++)
                {
                    size[i] = chara[i].size != "" ? CharaData.pqaSize.GetValue(chara[i].size) : -1;
                }
            }
            int IComparer.Compare(object x, object y)
            { return Math.Sign(size[(int)y] - size[(int)x]); }
        }
        public class ComparerUpdate : IComparer
        {
            readonly CharaData.CharaInfo[] chara;
            public ComparerUpdate(ref CharaData.CharaInfo[] c) { chara = c; }
            int IComparer.Compare(object x, object y)
            { return chara[(int)y].update.CompareTo(chara[(int)x].update); }
        }
        public class ComparerDescription : IComparer
        {
            readonly CharaData.CharaInfo[] chara;
            public ComparerDescription(ref CharaData.CharaInfo[] c) { chara = c; }
            int IComparer.Compare(object x, object y)
            { return chara[(int)y].description.Length - chara[(int)x].description.Length; }
        }
        public class ComparerGraphics : IComparer
        {
            readonly CharaData.CharaInfo[] chara;
            public ComparerGraphics(ref CharaData.CharaInfo[] c) { chara = c; }
            int IComparer.Compare(object x, object y)
            { return scomp.Compare(Path.GetExtension(chara[(int)x].graphic), Path.GetExtension(chara[(int)y].graphic)); }
        }
        public class ComparerFind : IComparer
        {
            readonly CharaData.CharaInfo[] chara;
            public bool[] match;
            public ComparerFind(ref CharaData.CharaInfo[] c, CharaData.FindCondition f)
            {
                chara = c;
                match = new bool[chara.Length];
                for (int i = 0; i < chara.Length; i++) match[i] = f.Match(chara[i]);
            }
            int IComparer.Compare(object x, object y)
            {
                if (match[(int)x] == match[(int)y]) return 0;
                if (match[(int)y] == true) return 1;
                return -1;
            }
        }
        public class ComparerNone : IComparer
        {
            int IComparer.Compare(object x, object y) { return 0; }
        }
        public class ComparerMulti : IComparer
        {
            readonly IComparer[] comparers;
            public ComparerMulti(IComparer[] comparers) { this.comparers = comparers; }
            int IComparer.Compare(object x, object y)
            {
                int ret = 0;
                foreach (var comparer in comparers)
                {
                    ret = comparer.Compare(x, y);
                    if (ret != 0) break;
                }
                return ret;
            }
        }

        #endregion

        public Form1() { InitializeComponent(); }

        private void LayoutInfo()
        {
            if (picImage.Visible && picImage.Image != null)
            {
                int padx = pnlImage.Padding.Left + pnlImage.Padding.Right;
                int pady = pnlImage.Padding.Top + pnlImage.Padding.Bottom;
                int wlim = scMain.Panel2.Width;
                int hlim = scMain.Panel2.Height;
                int wmax = wlim / 3;
                int hmax = hlim / 3;
                int w = picImage.Image.Width + padx;
                int h = picImage.Image.Height + pady;
                if (h <= hmax)
                {
                    pnlImage.Dock = DockStyle.Top;
                    if (w <= wlim) pnlImage.Height = h;
                    else pnlImage.Width = wlim;
                }
                else if (w <= wmax)
                {
                    pnlImage.Dock = DockStyle.Left;
                    if (h <= hlim) pnlImage.Width = w;
                    else pnlImage.Height = hlim;
                }
                else
                {
                    int areat1 = hmax * hmax * w / h;
                    int areat2 = wlim * wlim * h / w;
                    int areal1 = hlim * hlim * w / h;
                    int areal2 = wmax * wmax * h / w;
                    if (Math.Min(areat1, areat2) >= Math.Min(areal1, areal2))
                    {
                        pnlImage.Dock = DockStyle.Top;
                        if (areat1 <= areat2) pnlImage.Height = hmax;
                        else pnlImage.Width = wlim;
                    }
                    else
                    {
                        pnlImage.Dock = DockStyle.Left;
                        if (areal1 >= areal2) pnlImage.Width = wmax;
                        else pnlImage.Height = hlim;
                    }
                }
            }
            cmbName.Width = cmbGame.Width = cmbInfo.Width = pnlInfoUpper.Width - lblName.Width;
        }

        private void ChangeView(ViewMode next)
        {
            if (next == view) return;
            switch (view)
            {
                case ViewMode.ABC: miViewABC.Checked = false; break;
                case ViewMode.Age: miViewAge.Checked = false; break;
                case ViewMode.Size: miViewSize.Checked = false; break;
                case ViewMode.Update: miViewUpdate.Checked = false; break;
                case ViewMode.Description: miViewDescription.Checked = false; break;
                case ViewMode.Game: miViewGameABC.Checked = false; break;
                case ViewMode.GameAge: miViewGameAge.Checked = false; break;
                case ViewMode.GameSize: miViewGameSize.Checked = false; break;
                case ViewMode.GameUpdate: miViewGameUpdate.Checked = false; break;
                case ViewMode.GameDescription: miViewGameDescription.Checked = false; break;
                case ViewMode.GameSex: miViewGameSex.Checked = false; break;
                case ViewMode.GameGraphics: miViewGameGraphics.Checked = false; break;
                case ViewMode.Sex: miViewSexABC.Checked = false; break;
                case ViewMode.SexAge: miViewSexAge.Checked = false; break;
                case ViewMode.SexSize: miViewSexSize.Checked = false; break;
                case ViewMode.SexUpdate: miViewSexUpdate.Checked = false; break;
                case ViewMode.SexDescription: miViewSexDescription.Checked = false; break;
                case ViewMode.SexGame: miViewSexGame.Checked = false; break;
                case ViewMode.SexGraphics: miViewSexGraphics.Checked = false; break;
                case ViewMode.Graphics: miViewGraphicsABC.Checked = false; break;
                case ViewMode.GraphicsAge: miViewGraphicsAge.Checked = false; break;
                case ViewMode.GraphicsSize: miViewGraphicsSize.Checked = false; break;
                case ViewMode.GraphicsUpdate: miViewGraphicsUpdate.Checked = false; break;
                case ViewMode.GraphicsDescription: miViewGraphicsDescription.Checked = false; break;
                case ViewMode.GraphicsGame: miViewGraphicsGame.Checked = false; break;
                case ViewMode.GraphicsSex: miViewGraphicsSex.Checked = false; break;
                case ViewMode.Find: miViewFindABC.Checked = false; break;
                case ViewMode.FindAge: miViewFindAge.Checked = false; break;
                case ViewMode.FindSize: miViewFindSize.Checked = false; break;
                case ViewMode.FindUpdate: miViewFindUpdate.Checked = false; break;
                case ViewMode.FindDescription: miViewFindDescription.Checked = false; break;
                case ViewMode.FindGame: miViewFindGame.Checked = false; break;
                case ViewMode.FindSex: miViewFindSex.Checked = false; break;
                case ViewMode.FindGraphics: miViewFindGraphics.Checked = false; break;
            }
            view = next;
            RefreshView();
            switch (view)
            {
                case ViewMode.ABC: miViewABC.Checked = true; break;
                case ViewMode.Age: miViewAge.Checked = true; break;
                case ViewMode.Size: miViewSize.Checked = true; break;
                case ViewMode.Update: miViewUpdate.Checked = true; break;
                case ViewMode.Description: miViewDescription.Checked = true; break;
                case ViewMode.Game: miViewGameABC.Checked = true; break;
                case ViewMode.GameAge: miViewGameAge.Checked = true; break;
                case ViewMode.GameSize: miViewGameSize.Checked = true; break;
                case ViewMode.GameUpdate: miViewGameUpdate.Checked = true; break;
                case ViewMode.GameDescription: miViewGameDescription.Checked = true; break;
                case ViewMode.GameSex: miViewGameSex.Checked = true; break;
                case ViewMode.GameGraphics: miViewGameGraphics.Checked = true; break;
                case ViewMode.Sex: miViewSexABC.Checked = true; break;
                case ViewMode.SexAge: miViewSexAge.Checked = true; break;
                case ViewMode.SexSize: miViewSexSize.Checked = true; break;
                case ViewMode.SexUpdate: miViewSexUpdate.Checked = true; break;
                case ViewMode.SexDescription: miViewSexDescription.Checked = true; break;
                case ViewMode.SexGame: miViewSexGame.Checked = true; break;
                case ViewMode.SexGraphics: miViewSexGraphics.Checked = true; break;
                case ViewMode.Graphics: miViewGraphicsABC.Checked = true; break;
                case ViewMode.GraphicsAge: miViewGraphicsAge.Checked = true; break;
                case ViewMode.GraphicsSize: miViewGraphicsSize.Checked = true; break;
                case ViewMode.GraphicsUpdate: miViewGraphicsUpdate.Checked = true; break;
                case ViewMode.GraphicsDescription: miViewGraphicsDescription.Checked = true; break;
                case ViewMode.GraphicsGame: miViewGraphicsGame.Checked = true; break;
                case ViewMode.GraphicsSex: miViewGraphicsSex.Checked = true; break;
                case ViewMode.Find: miViewFindABC.Checked = true; break;
                case ViewMode.FindAge: miViewFindAge.Checked = true; break;
                case ViewMode.FindSize: miViewFindSize.Checked = true; break;
                case ViewMode.FindUpdate: miViewFindUpdate.Checked = true; break;
                case ViewMode.FindDescription: miViewFindDescription.Checked = true; break;
                case ViewMode.FindGame: miViewFindGame.Checked = true; break;
                case ViewMode.FindSex: miViewFindSex.Checked = true; break;
                case ViewMode.FindGraphics: miViewFindGraphics.Checked = true; break;
            }
        }

        #region SortTreeView

        private void RefreshView()
        {
            tvChara.Visible = false;
            tvChara.Nodes.Clear();
            if (sortedList.Length != data.chara.Length)
            {
                // リストが増減した
                int oldLength = sortedList.Length, newLength = data.chara.Length;
                int start = oldLength < newLength ? oldLength : 0;
                Array.Resize(ref sortedList, newLength);
                for (int i = start; i < newLength; i++) sortedList[i] = i;
            }
            // 表示形式別の処理
            switch (view)
            {
                case ViewMode.ABC: LayoutTVABC(); break;
                case ViewMode.Age: LayoutTVAge(); break;
                case ViewMode.Size: LayoutTVSize(); break;
                case ViewMode.Update: LayoutTVUpdate(); break;
                case ViewMode.Description: LayoutTVDescription(); break;
                case ViewMode.Game: LayoutTVGame(); break;
                case ViewMode.GameAge: LayoutTVGameAge(); break;
                case ViewMode.GameSize: LayoutTVGameSize(); break;
                case ViewMode.GameUpdate: LayoutTVGameUpdate(); break;
                case ViewMode.GameDescription: LayoutTVGameDescription(); break;
                case ViewMode.GameSex: LayoutTVGameSex(); break;
                case ViewMode.GameGraphics: LayoutTVGameGraphics(); break;
                case ViewMode.Sex: LayoutTVSex(); break;
                case ViewMode.SexAge: LayoutTVSexAge(); break;
                case ViewMode.SexSize: LayoutTVSexSize(); break;
                case ViewMode.SexUpdate: LayoutTVSexUpdate(); break;
                case ViewMode.SexDescription: LayoutTVSexDescription(); break;
                case ViewMode.SexGame: LayoutTVSexGame(); break;
                case ViewMode.SexGraphics: LayoutTVSexGraphics(); break;
                case ViewMode.Graphics: LayoutTVGraphics(); break;
                case ViewMode.GraphicsAge: LayoutTVGraphicsAge(); break;
                case ViewMode.GraphicsSize: LayoutTVGraphicsSize(); break;
                case ViewMode.GraphicsUpdate: LayoutTVGraphicsUpdate(); break;
                case ViewMode.GraphicsDescription: LayoutTVGraphicsDescription(); break;
                case ViewMode.GraphicsGame: LayoutTVGraphicsGame(); break;
                case ViewMode.GraphicsSex: LayoutTVGraphicsSex(); break;
                case ViewMode.Find: LayoutTVFind(); break;
                case ViewMode.FindAge: LayoutTVFindAge(); break;
                case ViewMode.FindSize: LayoutTVFindSize(); break;
                case ViewMode.FindUpdate: LayoutTVFindUpdate(); break;
                case ViewMode.FindDescription: LayoutTVFindDescription(); break;
                case ViewMode.FindGame: LayoutTVFindGame(); break;
                case ViewMode.FindSex: LayoutTVFindSex(); break;
                case ViewMode.FindGraphics: LayoutTVFindGraphics(); break;
            }
            TreeNode[] found = tvChara.Nodes.Find(data.selected.ToString(), true);
            if (found != null && found.Length > 0) tvChara.SelectedNode = found[0];
            tvChara.Visible = true;
        }

        void LayoutTVABC()
        {
            // カテゴリ
            string[] catABC = {
                "あ","い","う","え","お", "か","き","く","け","こ",
                "さ","し","す","せ","そ", "た","ち","つ","て","と",
                "な","に","ぬ","ね","の", "は","ひ","ふ","へ","ほ",
                "ま","み","む","め","も", "や",     "ゆ",     "よ",
                "ら","り","る","れ","ろ", "わ","ゐ",
            };
            tvChara.Nodes.Add("ABC", "アルファベット・記号");
            for (int i = 0; i < catABC.Length - 1; i++)
            {
                tvChara.Nodes.Add(catABC[i], catABC[i]);
            }
            tvChara.Nodes.Add("ゐ", "漢字・その他");
            // データ
            Array.Sort(sortedList, new ComparerABC(ref data.chara));
            var nodeABC = tvChara.Nodes.Find("ABC", false)[0];
            int j = 0;
            for (int i = 0; i < data.chara.Length; i++)
            {
                string name = data.chara[sortedList[i]].name[0];
                if (j < catABC.Length)
                {
                    while (scomp.Compare(catABC[j], name) <= 0)
                    {
                        nodeABC = tvChara.Nodes.Find(catABC[j], false)[0];
                        j++;
                        if (j == catABC.Length) break;
                    }
                }
                nodeABC.Nodes.Add(sortedList[i].ToString(), name);
            }
        }
        void LayoutTVAge()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerAge(ref data.chara), new ComparerABC(ref data.chara) }));
            for (int i = 0; i < data.chara.Length; i++)
            {
                tvChara.Nodes.Add(sortedList[i].ToString(), $"{CharaData.GetAgeString(data.chara[sortedList[i]].age)} {data.chara[sortedList[i]].name[0]}");
            }
        }
        void LayoutTVSize()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerSize(ref data.chara), new ComparerABC(ref data.chara) }));
            for (int i = 0; i < data.chara.Length; i++)
            {
                tvChara.Nodes.Add(sortedList[i].ToString(), $"{data.chara[sortedList[i]].size} {data.chara[sortedList[i]].name[0]}");
            }
        }
        void LayoutTVUpdate()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerUpdate(ref data.chara), new ComparerABC(ref data.chara) }));
            for (int i = 0; i < data.chara.Length; i++)
            {
                tvChara.Nodes.Add(sortedList[i].ToString(), $"{data.chara[sortedList[i]].update:yyyy/MM/dd HH:mm:ss} {data.chara[sortedList[i]].name[0]}");
            }
        }
        void LayoutTVDescription()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerDescription(ref data.chara), new ComparerABC(ref data.chara) }));
            for (int i = 0; i < data.chara.Length; i++)
            {
                tvChara.Nodes.Add(sortedList[i].ToString(), $"{data.chara[sortedList[i]].description.Length}字 {data.chara[sortedList[i]].name[0]}");
            }
        }
        void LayoutTVGame()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerGame(ref data.chara), new ComparerABC(ref data.chara) }));
            string currentGame = null;
            TreeNode nodeGame = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (data.chara[j].game[0] != currentGame)
                {
                    currentGame = data.chara[j].game[0];
                    nodeGame = new TreeNode(currentGame);
                    tvChara.Nodes.Add(nodeGame);
                }
                nodeGame.Nodes.Add(j.ToString(), data.chara[j].name[0]);
            }
        }
        void LayoutTVGameAge()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerGame(ref data.chara), new ComparerAge(ref data.chara), new ComparerABC(ref data.chara) }));
            string currentGame = null;
            TreeNode nodeGame = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (data.chara[j].game[0] != currentGame)
                {
                    currentGame = data.chara[j].game[0];
                    nodeGame = new TreeNode(currentGame);
                    tvChara.Nodes.Add(nodeGame);
                }
                nodeGame.Nodes.Add(j.ToString(), $"{CharaData.GetAgeString(data.chara[sortedList[i]].age)} {data.chara[sortedList[i]].name[0]}");
            }
        }
        void LayoutTVGameSize()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerGame(ref data.chara), new ComparerSize(ref data.chara), new ComparerABC(ref data.chara) }));
            string currentGame = null;
            TreeNode nodeGame = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (data.chara[j].game[0] != currentGame)
                {
                    currentGame = data.chara[j].game[0];
                    nodeGame = new TreeNode(currentGame);
                    tvChara.Nodes.Add(nodeGame);
                }
                nodeGame.Nodes.Add(j.ToString(), $"{data.chara[sortedList[i]].size} {data.chara[sortedList[i]].name[0]}");
            }
        }
        void LayoutTVGameUpdate()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerGame(ref data.chara), new ComparerUpdate(ref data.chara), new ComparerABC(ref data.chara) }));
            string currentGame = null;
            TreeNode nodeGame = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (data.chara[j].game[0] != currentGame)
                {
                    currentGame = data.chara[j].game[0];
                    nodeGame = new TreeNode(currentGame);
                    tvChara.Nodes.Add(nodeGame);
                }
                nodeGame.Nodes.Add(j.ToString(), $"{data.chara[sortedList[i]].update:yyyy/MM/dd HH:mm:ss} {data.chara[sortedList[i]].name[0]}");
            }
        }
        void LayoutTVGameDescription()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerGame(ref data.chara), new ComparerDescription(ref data.chara), new ComparerABC(ref data.chara) }));
            string currentGame = null;
            TreeNode nodeGame = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (data.chara[j].game[0] != currentGame)
                {
                    currentGame = data.chara[j].game[0];
                    nodeGame = new TreeNode(currentGame);
                    tvChara.Nodes.Add(nodeGame);
                }
                nodeGame.Nodes.Add(j.ToString(), $"{data.chara[sortedList[i]].description.Length}字 {data.chara[j].name[0]}");
            }
        }
        void LayoutTVGameSex()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerGame(ref data.chara), new ComparerSex(ref data.chara), new ComparerABC(ref data.chara) }));
            string currentGame = null;
            int currentSex = -1;
            TreeNode nodeGame = null, nodeSex = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (data.chara[j].game[0] != currentGame)
                {
                    currentGame = data.chara[j].game[0];
                    nodeGame = new TreeNode(currentGame);
                    tvChara.Nodes.Add(nodeGame);
                    currentSex = -1;
                }
                if ((int)data.chara[j].sex != currentSex)
                {
                    currentSex = (int)data.chara[j].sex;
                    nodeSex = new TreeNode(CharaData.GetSex(data.chara[j].sex));
                    nodeGame.Nodes.Add(nodeSex);
                }
                nodeSex.Nodes.Add(j.ToString(), data.chara[j].name[0]);
            }
        }
        void LayoutTVGameGraphics()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerGame(ref data.chara), new ComparerGraphics(ref data.chara), new ComparerABC(ref data.chara) }));
            string currentGame = null, currentExt = null;
            TreeNode nodeGame = null, nodeExt = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (data.chara[j].game[0] != currentGame)
                {
                    currentGame = data.chara[j].game[0];
                    nodeGame = new TreeNode(currentGame);
                    tvChara.Nodes.Add(nodeGame);
                    currentExt = null;
                }
                if (Path.GetExtension(data.chara[j].graphic) != currentExt)
                {
                    currentExt = Path.GetExtension(data.chara[j].graphic);
                    nodeExt = new TreeNode(currentExt != "" ? currentExt : "なし");
                    nodeGame.Nodes.Add(nodeExt);
                }
                nodeExt.Nodes.Add(j.ToString(), data.chara[j].name[0]);
            }
        }
        void LayoutTVSex()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerSex(ref data.chara), new ComparerABC(ref data.chara) }));
            int currentSex = -1;
            TreeNode nodeSex = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if ((int)data.chara[j].sex != currentSex)
                {
                    currentSex = (int)data.chara[j].sex;
                    nodeSex = new TreeNode(CharaData.GetSex(data.chara[j].sex));
                    tvChara.Nodes.Add(nodeSex);
                }
                nodeSex.Nodes.Add(j.ToString(), data.chara[j].name[0]);
            }
        }
        void LayoutTVSexAge()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerSex(ref data.chara), new ComparerAge(ref data.chara), new ComparerABC(ref data.chara) }));
            int currentSex = -1;
            TreeNode nodeSex = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if ((int)data.chara[j].sex != currentSex)
                {
                    currentSex = (int)data.chara[j].sex;
                    nodeSex = new TreeNode(CharaData.GetSex(data.chara[j].sex));
                    tvChara.Nodes.Add(nodeSex);
                }
                nodeSex.Nodes.Add(j.ToString(), $"{CharaData.GetAgeString(data.chara[sortedList[i]].age)} {data.chara[j].name[0]}");
            }
        }
        void LayoutTVSexSize()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerSex(ref data.chara), new ComparerSize(ref data.chara), new ComparerABC(ref data.chara) }));
            int currentSex = -1;
            TreeNode nodeSex = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if ((int)data.chara[j].sex != currentSex)
                {
                    currentSex = (int)data.chara[j].sex;
                    nodeSex = new TreeNode(CharaData.GetSex(data.chara[j].sex));
                    tvChara.Nodes.Add(nodeSex);
                }
                nodeSex.Nodes.Add(j.ToString(), $"{data.chara[sortedList[i]].size} {data.chara[j].name[0]}");
            }
        }
        void LayoutTVSexUpdate()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerSex(ref data.chara), new ComparerUpdate(ref data.chara), new ComparerABC(ref data.chara) }));
            int currentSex = -1;
            TreeNode nodeSex = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if ((int)data.chara[j].sex != currentSex)
                {
                    currentSex = (int)data.chara[j].sex;
                    nodeSex = new TreeNode(CharaData.GetSex(data.chara[j].sex));
                    tvChara.Nodes.Add(nodeSex);
                }
                nodeSex.Nodes.Add(j.ToString(), $"{data.chara[sortedList[i]].update:yyyy/MM/dd HH:mm:ss} {data.chara[j].name[0]}");
            }
        }
        void LayoutTVSexDescription()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerSex(ref data.chara), new ComparerDescription(ref data.chara), new ComparerABC(ref data.chara) }));
            int currentSex = -1;
            TreeNode nodeSex = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if ((int)data.chara[j].sex != currentSex)
                {
                    currentSex = (int)data.chara[j].sex;
                    nodeSex = new TreeNode(CharaData.GetSex(data.chara[j].sex));
                    tvChara.Nodes.Add(nodeSex);
                }
                nodeSex.Nodes.Add(j.ToString(), $"{data.chara[sortedList[i]].description.Length}字 {data.chara[j].name[0]}");
            }
        }
        void LayoutTVSexGame()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerSex(ref data.chara), new ComparerGame(ref data.chara), new ComparerABC(ref data.chara) }));
            int currentSex = -1;
            string currentGame = null;
            TreeNode nodeSex = null, nodeGame = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if ((int)data.chara[j].sex != currentSex)
                {
                    currentSex = (int)data.chara[j].sex;
                    nodeSex = new TreeNode(CharaData.GetSex(data.chara[j].sex));
                    tvChara.Nodes.Add(nodeSex);
                    currentGame = null;
                }
                if (data.chara[j].game[0] != currentGame)
                {
                    currentGame = data.chara[j].game[0];
                    nodeGame = new TreeNode(currentGame);
                    nodeSex.Nodes.Add(nodeGame);
                }
                nodeGame.Nodes.Add(j.ToString(), data.chara[j].name[0]);
            }
        }
        void LayoutTVSexGraphics()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerSex(ref data.chara), new ComparerGraphics(ref data.chara), new ComparerABC(ref data.chara) }));
            int currentSex = -1;
            string currentExt = null;
            TreeNode nodeSex = null, nodeExt = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if ((int)data.chara[j].sex != currentSex)
                {
                    currentSex = (int)data.chara[j].sex;
                    nodeSex = new TreeNode(CharaData.GetSex(data.chara[j].sex));
                    tvChara.Nodes.Add(nodeSex);
                    currentExt = null;
                }
                if (Path.GetExtension(data.chara[j].graphic) != currentExt)
                {
                    currentExt = Path.GetExtension(data.chara[j].graphic);
                    nodeExt = new TreeNode(currentExt != "" ? currentExt : "なし");
                    nodeSex.Nodes.Add(nodeExt);
                }
                nodeExt.Nodes.Add(j.ToString(), data.chara[j].name[0]);
            }
        }
        void LayoutTVGraphics()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerGraphics(ref data.chara), new ComparerABC(ref data.chara) }));
            string currentExt = null;
            TreeNode nodeExt = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (Path.GetExtension(data.chara[j].graphic) != currentExt)
                {
                    currentExt = Path.GetExtension(data.chara[j].graphic);
                    nodeExt = new TreeNode(currentExt != "" ? currentExt : "なし");
                    tvChara.Nodes.Add(nodeExt);
                }
                nodeExt.Nodes.Add(j.ToString(), data.chara[j].name[0]);
            }
        }
        void LayoutTVGraphicsAge()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerGraphics(ref data.chara), new ComparerAge(ref data.chara), new ComparerABC(ref data.chara) }));
            string currentExt = null;
            TreeNode nodeExt = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (Path.GetExtension(data.chara[j].graphic) != currentExt)
                {
                    currentExt = Path.GetExtension(data.chara[j].graphic);
                    nodeExt = new TreeNode(currentExt != "" ? currentExt : "なし");
                    tvChara.Nodes.Add(nodeExt);
                }
                nodeExt.Nodes.Add(j.ToString(), $"{CharaData.GetAgeString(data.chara[sortedList[i]].age)} {data.chara[sortedList[i]].name[0]}");
            }
        }
        void LayoutTVGraphicsSize()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerGraphics(ref data.chara), new ComparerSize(ref data.chara), new ComparerABC(ref data.chara) }));
            string currentExt = null;
            TreeNode nodeExt = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (Path.GetExtension(data.chara[j].graphic) != currentExt)
                {
                    currentExt = Path.GetExtension(data.chara[j].graphic);
                    nodeExt = new TreeNode(currentExt != "" ? currentExt : "なし");
                    tvChara.Nodes.Add(nodeExt);
                }
                nodeExt.Nodes.Add(j.ToString(), $"{data.chara[sortedList[i]].size} {data.chara[j].name[0]}");
            }
        }
        void LayoutTVGraphicsUpdate()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerGraphics(ref data.chara), new ComparerUpdate(ref data.chara), new ComparerABC(ref data.chara) }));
            string currentExt = null;
            TreeNode nodeExt = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (Path.GetExtension(data.chara[j].graphic) != currentExt)
                {
                    currentExt = Path.GetExtension(data.chara[j].graphic);
                    nodeExt = new TreeNode(currentExt != "" ? currentExt : "なし");
                    tvChara.Nodes.Add(nodeExt);
                }
                nodeExt.Nodes.Add(j.ToString(), $"{data.chara[sortedList[i]].update:yyyy/MM/dd HH:mm:ss} {data.chara[j].name[0]}");
            }
        }
        void LayoutTVGraphicsDescription()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerGraphics(ref data.chara), new ComparerDescription(ref data.chara), new ComparerABC(ref data.chara) }));
            string currentExt = null;
            TreeNode nodeExt = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (Path.GetExtension(data.chara[j].graphic) != currentExt)
                {
                    currentExt = Path.GetExtension(data.chara[j].graphic);
                    nodeExt = new TreeNode(currentExt != "" ? currentExt : "なし");
                    tvChara.Nodes.Add(nodeExt);
                }
                nodeExt.Nodes.Add(j.ToString(), $"{data.chara[sortedList[i]].description.Length}字 {data.chara[j].name[0]}");
            }
        }
        void LayoutTVGraphicsGame()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerGraphics(ref data.chara), new ComparerGame(ref data.chara), new ComparerABC(ref data.chara) }));
            string currentExt = null, currentGame = null;
            TreeNode nodeExt = null, nodeGame = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (Path.GetExtension(data.chara[j].graphic) != currentExt)
                {
                    currentExt = Path.GetExtension(data.chara[j].graphic);
                    nodeExt = new TreeNode(currentExt != "" ? currentExt : "なし");
                    tvChara.Nodes.Add(nodeExt);
                    currentGame = null;
                }
                if (data.chara[j].game[0] != currentGame)
                {
                    currentGame = data.chara[j].game[0];
                    nodeGame = new TreeNode(currentGame);
                    nodeExt.Nodes.Add(nodeGame);
                }
                nodeGame.Nodes.Add(j.ToString(), data.chara[j].name[0]);
            }
        }
        void LayoutTVGraphicsSex()
        {
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { new ComparerGraphics(ref data.chara), new ComparerSex(ref data.chara), new ComparerABC(ref data.chara) }));
            string currentExt = null;
            int currentSex = -1;
            TreeNode nodeExt = null, nodeSex = null;
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (Path.GetExtension(data.chara[j].graphic) != currentExt)
                {
                    currentExt = Path.GetExtension(data.chara[j].graphic);
                    nodeExt = new TreeNode(currentExt != "" ? currentExt : "なし");
                    tvChara.Nodes.Add(nodeExt);
                    currentSex = -1;
                }
                if ((int)data.chara[j].sex != currentSex)
                {
                    currentSex = (int)data.chara[j].sex;
                    nodeSex = new TreeNode(CharaData.GetSex(data.chara[j].sex));
                    nodeExt.Nodes.Add(nodeSex);
                }
                nodeSex.Nodes.Add(j.ToString(), data.chara[j].name[0]);
            }
        }
        void LayoutTVFind()
        {
            ComparerFind f = new ComparerFind(ref data.chara, find);
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { f, new ComparerABC(ref data.chara) }));
            bool bFound = true;
            TreeNode nodeFind = new TreeNode("条件に一致");
            tvChara.Nodes.Add(nodeFind);
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (f.match[j] != bFound)
                {
                    bFound = false;
                    nodeFind = new TreeNode("条件に不一致");
                    tvChara.Nodes.Add(nodeFind);
                }
                nodeFind.Nodes.Add(j.ToString(), data.chara[j].name[0]);
            }
        }
        void LayoutTVFindAge()
        {
            ComparerFind f = new ComparerFind(ref data.chara, find);
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { f, new ComparerAge(ref data.chara), new ComparerABC(ref data.chara) }));
            bool bFound = true;
            TreeNode nodeFind = new TreeNode("条件に一致");
            tvChara.Nodes.Add(nodeFind);
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (f.match[j] != bFound)
                {
                    bFound = false;
                    nodeFind = new TreeNode("条件に不一致");
                    tvChara.Nodes.Add(nodeFind);
                }
                nodeFind.Nodes.Add(j.ToString(), $"{CharaData.GetAgeString(data.chara[sortedList[i]].age)} {data.chara[sortedList[i]].name[0]}");
            }
        }
        void LayoutTVFindSize()
        {
            ComparerFind f = new ComparerFind(ref data.chara, find);
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { f, new ComparerSize(ref data.chara), new ComparerABC(ref data.chara) }));
            bool bFound = true;
            TreeNode nodeFind = new TreeNode("条件に一致");
            tvChara.Nodes.Add(nodeFind);
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (f.match[j] != bFound)
                {
                    bFound = false;
                    nodeFind = new TreeNode("条件に不一致");
                    tvChara.Nodes.Add(nodeFind);
                }
                nodeFind.Nodes.Add(j.ToString(), $"{data.chara[sortedList[i]].size} {data.chara[j].name[0]}");
            }
        }
        void LayoutTVFindUpdate()
        {
            ComparerFind f = new ComparerFind(ref data.chara, find);
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { f, new ComparerUpdate(ref data.chara), new ComparerABC(ref data.chara) }));
            bool bFound = true;
            TreeNode nodeFind = new TreeNode("条件に一致");
            tvChara.Nodes.Add(nodeFind);
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (f.match[j] != bFound)
                {
                    bFound = false;
                    nodeFind = new TreeNode("条件に不一致");
                    tvChara.Nodes.Add(nodeFind);
                }
                nodeFind.Nodes.Add(j.ToString(), $"{data.chara[sortedList[i]].update:yyyy/MM/dd HH:mm:ss} {data.chara[j].name[0]}");
            }
        }
        void LayoutTVFindDescription()
        {
            ComparerFind f = new ComparerFind(ref data.chara, find);
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { f, new ComparerDescription(ref data.chara), new ComparerABC(ref data.chara) }));
            bool bFound = true;
            TreeNode nodeFind = new TreeNode("条件に一致");
            tvChara.Nodes.Add(nodeFind);
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (f.match[j] != bFound)
                {
                    bFound = false;
                    nodeFind = new TreeNode("条件に不一致");
                    tvChara.Nodes.Add(nodeFind);
                }
                nodeFind.Nodes.Add(j.ToString(), $"{data.chara[sortedList[i]].description.Length}字 {data.chara[j].name[0]}");
            }
        }
        void LayoutTVFindGame()
        {
            ComparerFind f = new ComparerFind(ref data.chara, find);
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { f, new ComparerGame(ref data.chara), new ComparerABC(ref data.chara) }));
            bool bFound = true;
            string currentGame = null;
            TreeNode nodeFind = new TreeNode("条件に一致"), nodeGame = null;
            tvChara.Nodes.Add(nodeFind);
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (f.match[j] != bFound)
                {
                    bFound = false;
                    nodeFind = new TreeNode("条件に不一致");
                    tvChara.Nodes.Add(nodeFind);
                    currentGame = null;
                }
                if (data.chara[j].game[0] != currentGame)
                {
                    currentGame = data.chara[j].game[0];
                    nodeGame = new TreeNode(currentGame);
                    nodeFind.Nodes.Add(nodeGame);
                }
                nodeGame.Nodes.Add(j.ToString(), data.chara[j].name[0]);
            }
        }
        void LayoutTVFindSex()
        {
            ComparerFind f = new ComparerFind(ref data.chara, find);
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { f, new ComparerSex(ref data.chara), new ComparerABC(ref data.chara) }));
            bool bFound = true;
            int currentSex = -1;
            TreeNode nodeFind = new TreeNode("条件に一致"), nodeSex = null;
            tvChara.Nodes.Add(nodeFind);
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (f.match[j] != bFound)
                {
                    bFound = false;
                    nodeFind = new TreeNode("条件に不一致");
                    tvChara.Nodes.Add(nodeFind);
                    currentSex = -1;
                }
                if ((int)data.chara[j].sex != currentSex)
                {
                    currentSex = (int)data.chara[j].sex;
                    nodeSex = new TreeNode(CharaData.GetSex(data.chara[j].sex));
                    nodeFind.Nodes.Add(nodeSex);
                }
                nodeSex.Nodes.Add(j.ToString(), data.chara[j].name[0]);
            }
        }
        void LayoutTVFindGraphics()
        {
            ComparerFind f = new ComparerFind(ref data.chara, find);
            Array.Sort(sortedList, new ComparerMulti(new IComparer[] { f, new ComparerGraphics(ref data.chara), new ComparerABC(ref data.chara) }));
            string currentExt = null;
            bool bFound = true;
            TreeNode nodeExt = null, nodeFind = new TreeNode("条件に一致");
            tvChara.Nodes.Add(nodeFind);
            for (int i = 0; i < data.chara.Length; i++)
            {
                int j = sortedList[i];
                if (f.match[j] != bFound)
                {
                    bFound = false;
                    nodeFind = new TreeNode("条件に不一致");
                    tvChara.Nodes.Add(nodeFind);
                    currentExt = null;
                }
                if (Path.GetExtension(data.chara[j].graphic) != currentExt)
                {
                    currentExt = Path.GetExtension(data.chara[j].graphic);
                    nodeExt = new TreeNode(currentExt != "" ? currentExt : "なし");
                    nodeFind.Nodes.Add(nodeExt);
                }
                nodeExt.Nodes.Add(j.ToString(), data.chara[j].name[0]);
            }
        }

        #endregion

        private void ViewChara(int i)
        {
            var c = data.chara[i];
            // 名前
            cmbName.Items.Clear();
            foreach (string s1 in c.name) cmbName.Items.Add(s1);
            cmbName.SelectedIndex = 0;
            // 登場作品
            cmbGame.Items.Clear();
            foreach (string s2 in c.game) cmbGame.Items.Add(s2);
            cmbGame.SelectedIndex = 0;
            // その他もろもろ
            cmbInfo.Items.Clear();
            cmbInfo.Items.Add($"{CharaData.GetSex(c.sex)}{(c.age != "" ? "  " + CharaData.GetAgeString(c.age) : "")}{(c.size != "" ? "  " + c.size : "")}  説明：{c.description.Length}文字  更新：{c.update}");
            cmbInfo.Items.Add($"性別：{CharaData.GetSex(c.sex)}");
            if (c.age != "") cmbInfo.Items.Add($"年齢：{CharaData.GetAgeString(c.age)} = {CharaData.pqaAge.GetValue(c.age) / 31536000.0}年");
            if (c.size != "") cmbInfo.Items.Add($"大きさ：{c.size} = {CharaData.pqaSize.GetValue(c.size)}m");
            cmbInfo.Items.Add($"説明の長さ：{c.description.Length}文字");
            cmbInfo.Items.Add($"最終更新：{c.update}");
            cmbInfo.SelectedIndex = 0;
            // 説明
            txtDescription.Text = c.description;
            // 画像
            if (ImageAnimator.CanAnimate(picImage.Image))
            {
                // アニメGIFストップ
                ImageAnimator.StopAnimate(picImage.Image, new EventHandler(OnFrameChanged));
            }
            Image img;
            if (File.Exists("bmp/" + c.graphic))
            {
                img = Image.FromFile("bmp/" + c.graphic);
                if (ImageAnimator.CanAnimate(img))
                {
                    // アニメGIFスタート
                    ImageAnimator.Animate(img, new EventHandler(OnFrameChanged));
                }
            }
            else { img = imgDefault; }
            picImage.Image = img;
            LayoutInfo();
            data.selected = i;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sizesaver = new WindowSizeSaver(this);
            var viewMode = ViewMode.ABC;
            try
            {
                using StreamReader sr = new StreamReader("CharaBox3.ini");
                string line;
                var sep = new char[] { '\t' };
                var state = FormWindowState.Normal;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] item = line.Split(sep);
                    switch (item[0])
                    {
                        case "File":
                            Array.Resize(ref files, files.Length + 1);
                            files[files.Length - 1].name = item[1];
                            files[files.Length - 1].file = item[2];
                            miFileSelect.DropDown.Items.Add(item[1], null, new EventHandler(miFileSelect_Click));
                            break;
                        case "Location":
                            Left = int.Parse(item[1]);
                            Top = int.Parse(item[2]);
                            break;
                        case "Size":
                            Width = int.Parse(item[1]);
                            Height = int.Parse(item[2]);
                            break;
                        case "State":
                            state = (FormWindowState)int.Parse(item[1]);
                            break;
                        case "ViewMode":
                            viewMode = (ViewMode)int.Parse(item[1]);
                            break;
                        default: break;
                    }
                }
                WindowState = state;
            }
            catch (Exception)
            {
            }
            if (files.Length == 0)
            {
                Array.Resize(ref files, files.Length + 1);
                files[files.Length - 1].name = "デフォルト";
                files[files.Length - 1].file = "default.dat";
                miFileSelect.DropDown.Items.Add(files[files.Length - 1].name, null, new EventHandler(miFileSelect_Click));
            }
            data = new CharaData(files[0].file);
            imgDefault = picImage.Image;
            pnlInfoUpper.Height = cmbName.Height * 3;
            lblName.Left = lblGame.Left = lblInfo.Left = 0;
            lblName.Height = lblGame.Height = lblInfo.Height = lblGame.Top = cmbGame.Top = cmbName.Height;
            lblInfo.Top = cmbInfo.Top = cmbName.Height * 2;
            lblGame.Width = lblInfo.Width = cmbName.Left = cmbGame.Left = cmbInfo.Left = lblName.Width;
            data.Load();
            ChangeView(viewMode);
            LayoutInfo();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            LayoutInfo();
        }

        private void tvChara_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                ViewChara(int.Parse(e.Node.Name));
                ssLabel.Text = $"{(e.Node.Level > 0 ? e.Node.Parent.Nodes.Count : tvChara.Nodes.Count)}項目中{e.Node.Index + 1}番目  全{data.chara.Length}項目";
            }
            catch (Exception)
            {
                ssLabel.Text = $"子項目{e.Node.Nodes.Count}個  全{data.chara.Length}項目 {100.0f * e.Node.Nodes.Count / data.chara.Length:0.00}%";
            }
        }

        private void OnFrameChanged(object o, EventArgs e)
        {
            picImage.Invalidate();
        }

        private void scMain_Panel2_Resize(object sender, EventArgs e)
        {
            LayoutInfo();
        }

        private void miItemEdit_Click(object sender, EventArgs e)
        {
            if (data.selected >= data.chara.Length) return;
            var fe = new FormEdit
            {
                chara = data.chara[data.selected]
            };
            fe.SetGames(data.chara);
            fe.ShowDialog(this);
            if (!fe.Canceled)
            {
                data.chara[data.selected] = fe.chara;
                ViewChara(data.selected);
                RefreshView();
            }
        }

        private void scMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            LayoutInfo();
        }

        private void miItemRandom_Click(object sender, EventArgs e)
        {
            tvChara.SelectedNode = tvChara.Nodes.Find(new Random().Next(data.chara.Length).ToString(), true)[0];
        }

        private void miFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void miItemDelete_Click(object sender, EventArgs e)
        {
            var title = $"{data.chara[data.selected].name[0]}の削除";
            if (MessageBox.Show("削除してよいのですか？", title, MessageBoxButtons.YesNo) == DialogResult.No) return;
            if (MessageBox.Show("やっぱり削除したくないでしょう？", title, MessageBoxButtons.YesNo) == DialogResult.Yes) return;
            if (MessageBox.Show("では、消します。", title, MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
            ViewChara(data.selected = data.Delete(data.selected));
            RefreshView();
        }

        private void miItemAdd_Click(object sender, EventArgs e)
        {
            FormEdit fe = new FormEdit();
            fe.SetGames(data.chara);
            fe.ShowDialog(this);
            if (!fe.Canceled)
            {
                ViewChara(data.Add(fe.chara));
                RefreshView();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (save) data.Save();
            using StreamWriter sw = new StreamWriter("CharaBox3.ini");
            foreach (DataFiles f in files)
            {
                sw.WriteLine($"File\t{f.name}\t{f.file}");
            }
            sw.WriteLine($"Location\t{sizesaver.Location.X}\t{sizesaver.Location.Y}");
            sw.WriteLine($"Size\t{sizesaver.Size.Width}\t{sizesaver.Size.Height}");
            sw.WriteLine($"State\t{(int)sizesaver.WindowState}");
            sw.WriteLine($"ViewMode\t{(int)view}");
        }

        private void miFileSelect_Click(object sender, EventArgs e)
        {
            foreach (DataFiles f in files)
            {
                if (f.name == sender.ToString())
                {
                    data.Save();
                    data = new CharaData(f.file);
                    data.Load();
                    RefreshView();
                }
            }
        }

        #region miView

        private void miViewABC_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.ABC); }
        private void miViewGame_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.Game); }
        private void miViewAge_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.Age); }
        private void miViewSex_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.Sex); }
        private void miViewSize_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.Size); }
        private void miViewUpdate_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.Update); }
        private void miViewDescription_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.Description); }
        private void miViewGraphics_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.Graphics); }
        private void miViewGraphicsGame_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.GraphicsGame); }
        private void miViewGameAge_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.GameAge); }
        private void miViewGameSize_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.GameSize); }
        private void miViewGameUpdate_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.GameUpdate); }
        private void miViewGameDescription_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.GameDescription); }
        private void miViewGameSex_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.GameSex); }
        private void miViewGameGraphics_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.GameGraphics); }
        private void miViewGraphicsAge_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.GraphicsAge); }
        private void miViewGraphicsSize_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.GraphicsSize); }
        private void miViewGraphicsUpdate_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.GraphicsUpdate); }
        private void miViewGraphicsDescription_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.GraphicsDescription); }
        private void miViewGraphicsSex_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.GraphicsSex); }
        private void miViewSexAge_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.SexAge); }
        private void miViewSexSize_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.SexSize); }
        private void miViewSexUpdate_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.SexUpdate); }
        private void miViewSexDescription_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.SexDescription); }
        private void miViewSexGame_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.SexGame); }
        private void miViewSexGraphics_Click(object sender, EventArgs e)
        { ChangeView(ViewMode.SexGraphics); }
        private void miViewFindABC_Click(object sender, EventArgs e)
        {
            var f = new FormFind
            {
                find = find
            };
            f.ShowDialog(this);
            if (!f.isOK) return;
            find = f.find;
            if (view == ViewMode.Find) view = ViewMode.None;    // 同じのクリックしても検索するよー
            ChangeView(ViewMode.Find);
        }
        private void miViewFindAge_Click(object sender, EventArgs e)
        {
            var f = new FormFind
            {
                find = find
            };
            f.ShowDialog(this);
            if (!f.isOK) return;
            find = f.find;
            if (view == ViewMode.FindAge) view = ViewMode.None;    // 同じのクリックしても検索するよー
            ChangeView(ViewMode.FindAge);
        }
        private void miViewFindSize_Click(object sender, EventArgs e)
        {
            var f = new FormFind
            {
                find = find
            };
            f.ShowDialog(this);
            if (!f.isOK) return;
            find = f.find;
            if (view == ViewMode.FindSize) view = ViewMode.None;    // 同じのクリックしても検索するよー
            ChangeView(ViewMode.FindSize);
        }
        private void miViewindUpdate_Click(object sender, EventArgs e)
        {
            var f = new FormFind
            {
                find = find
            };
            f.ShowDialog(this);
            if (!f.isOK) return;
            find = f.find;
            if (view == ViewMode.FindUpdate) view = ViewMode.None;    // 同じのクリックしても検索するよー
            ChangeView(ViewMode.FindUpdate);
        }
        private void miViewFindDescription_Click(object sender, EventArgs e)
        {
            var f = new FormFind
            {
                find = find
            };
            f.ShowDialog(this);
            if (!f.isOK) return;
            find = f.find;
            if (view == ViewMode.FindDescription) view = ViewMode.None;    // 同じのクリックしても検索するよー
            ChangeView(ViewMode.FindDescription);
        }
        private void miViewFindGame_Click(object sender, EventArgs e)
        {
            var f = new FormFind
            {
                find = find
            };
            f.ShowDialog(this);
            if (!f.isOK) return;
            find = f.find;
            if (view == ViewMode.FindGame) view = ViewMode.None;    // 同じのクリックしても検索するよー
            ChangeView(ViewMode.FindGame);
        }
        private void miViewFindSex_Click(object sender, EventArgs e)
        {
            var f = new FormFind
            {
                find = find
            };
            f.ShowDialog(this);
            if (!f.isOK) return;
            find = f.find;
            if (view == ViewMode.FindSex) view = ViewMode.None;    // 同じのクリックしても検索するよー
            ChangeView(ViewMode.FindSex);
        }
        private void miViewFindGraphics_Click(object sender, EventArgs e)
        {
            var f = new FormFind
            {
                find = find
            };
            f.ShowDialog(this);
            if (!f.isOK) return;
            find = f.find;
            if (view == ViewMode.FindGraphics) view = ViewMode.None;    // 同じのクリックしても検索するよー
            ChangeView(ViewMode.FindGraphics);
        }

        #endregion

        private void miFileOpen_Click(object sender, EventArgs e)
        {
            var cd = Directory.GetCurrentDirectory();
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                Directory.SetCurrentDirectory(cd);
                var d = new CharaData(ofdFile.FileName);
                if (d.Load())
                {
                    data.Save();
                    data = d;
                    RefreshView();
                }
                else
                {
                    MessageBox.Show("CharaBox3のファイルでないため開けませんでした！");
                }
            }
        }

        private void miFileExitNoSave_Click(object sender, EventArgs e)
        {
            string title = "セーブせず終了";
            if (MessageBox.Show("セーブせず終了してよいのですか？", title, MessageBoxButtons.YesNo) == DialogResult.No) return;
            if (MessageBox.Show("やっぱりセーブしたいでしょう？", title, MessageBoxButtons.YesNo) == DialogResult.Yes) return;
            if (MessageBox.Show("では、セーブせず終了します。", title, MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
            save = false;
            Close();
        }

        private void miFileExportAsJson_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog()
            {
                DefaultExt = "json",
                FileName = $"{Path.GetFileNameWithoutExtension(data.fileName)}.json",
                Filter = "JSON形式|*.json|その他|*.*",
                Title = "JSON形式でエクスポート",
            };
            if (sfd.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            File.WriteAllText(sfd.FileName, Newtonsoft.Json.JsonConvert.SerializeObject(data.chara));
        }

        private void miFileAdd_Click(object sender, EventArgs e)
        {
            using var f = new FormAddFile();
            if (f.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
        }
    }
}
