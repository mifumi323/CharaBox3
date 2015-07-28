using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CharaBox3
{
    public partial class FormFind : Form
    {
        public bool isOK = false;
        public CharaData.FindCondition find;

        public FormFind()
        {
            InitializeComponent();
        }

        private void FormFind_Load(object sender, EventArgs e)
        {
            foreach (CharaData.CharaInfo.Sex s in CharaData.sexes)
            {
                cmbSex.Items.Add(CharaData.GetSex(s));
            }
            txtName.Text = find.name;
            txtGame.Text = find.game;
            txtDescription.Text = find.description;
            txtGraphics.Text = find.graphic;
            cmbSex.SelectedIndex = (int)find.sex;
            txtAgeMin.Text = find.agemin;
            txtAgeMax.Text = find.agemax;
            txtSizeMin.Text = find.sizemin;
            txtSizeMax.Text = find.sizemax;
            if (find.namematch) cmbName.SelectedIndex = 0;
            if (find.namecontain) cmbName.SelectedIndex = 1;
            if (find.namenotcontain) cmbName.SelectedIndex = 2;
            if (find.gamematch) cmbGame.SelectedIndex = 0;
            if (find.gamecontain) cmbGame.SelectedIndex = 1;
            if (find.gamenotcontain) cmbGame.SelectedIndex = 2;
            if (find.descriptionmatch) cmbDescription.SelectedIndex = 0;
            if (find.descriptioncontain) cmbDescription.SelectedIndex = 1;
            if (find.descriptionnotcontain) cmbDescription.SelectedIndex = 2;
            if (find.graphicmatch) cmbGraphics.SelectedIndex = 0;
            if (find.graphiccontain) cmbGraphics.SelectedIndex = 1;
            if (find.graphicnotcontain) cmbGraphics.SelectedIndex = 2;
            if (find.sexmatch) cmbSex2.SelectedIndex = 0;
            if (find.sexnotmatch) cmbSex2.SelectedIndex = 1;
            if (find.ageminormore) cmbAgeMin.SelectedIndex = 0;
            if (find.ageminmore) cmbAgeMin.SelectedIndex = 1;
            if (find.agemaxorless) cmbAgeMax.SelectedIndex = 0;
            if (find.agemaxless) cmbAgeMax.SelectedIndex = 1;
            if (find.sizeminormore) cmbSizeMin.SelectedIndex = 0;
            if (find.sizeminmore) cmbSizeMin.SelectedIndex = 1;
            if (find.sizemaxorless) cmbSizeMax.SelectedIndex = 0;
            if (find.sizemaxless) cmbSizeMax.SelectedIndex = 1;
            chkName.Checked = find.namematch || find.namecontain || find.namenotcontain;
            chkGame.Checked = find.gamematch || find.gamecontain || find.gamenotcontain;
            chkDescription.Checked = find.descriptionmatch || find.descriptioncontain || find.descriptionnotcontain;
            chkGraphics.Checked = find.graphicmatch || find.graphiccontain || find.graphicnotcontain;
            chkSex.Checked = find.sexmatch || find.sexnotmatch;
            chkAgeMin.Checked = find.ageminmore || find.ageminormore;
            chkAgeMax.Checked = find.agemaxless || find.agemaxorless;
            chkSizeMin.Checked = find.sizeminmore || find.sizeminormore;
            chkSizeMax.Checked = find.sizemaxless || find.sizemaxorless;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            isOK = true;
            find.name = txtName.Text;
            find.game = txtGame.Text;
            find.description = txtDescription.Text;
            find.graphic=txtGraphics.Text;
            find.sex=(CharaData.CharaInfo.Sex)cmbSex.SelectedIndex;
            find.agemin=txtAgeMin.Text;
            find.agemax=txtAgeMax.Text;
            find.sizemin=txtSizeMin.Text;
            find.sizemax=txtSizeMax.Text;
            find.namematch = chkName.Checked && cmbName.SelectedIndex == 0;
            find.namecontain = chkName.Checked && cmbName.SelectedIndex == 1;
            find.namenotcontain = chkName.Checked && cmbName.SelectedIndex == 2;
            find.gamematch = chkGame.Checked && cmbGame.SelectedIndex == 0;
            find.gamecontain = chkGame.Checked && cmbGame.SelectedIndex == 1;
            find.gamenotcontain = chkGame.Checked && cmbGame.SelectedIndex == 2;
            find.descriptionmatch = chkDescription.Checked && cmbDescription.SelectedIndex == 0;
            find.descriptioncontain = chkDescription.Checked && cmbDescription.SelectedIndex == 1;
            find.descriptionnotcontain = chkDescription.Checked && cmbDescription.SelectedIndex == 2;
            find.graphicmatch = chkGraphics.Checked && cmbGraphics.SelectedIndex == 0;
            find.graphiccontain = chkGraphics.Checked && cmbGraphics.SelectedIndex == 1;
            find.graphicnotcontain = chkGraphics.Checked && cmbGraphics.SelectedIndex == 2;
            find.sexmatch = chkSex.Checked && cmbSex2.SelectedIndex == 0;
            find.sexnotmatch = chkSex.Checked && cmbSex2.SelectedIndex == 1;
            find.ageminormore = chkAgeMin.Checked && cmbAgeMin.SelectedIndex == 0;
            find.ageminmore = chkAgeMin.Checked && cmbAgeMin.SelectedIndex == 1;
            find.agemaxorless = chkAgeMax.Checked && cmbAgeMax.SelectedIndex == 0;
            find.agemaxless = chkAgeMax.Checked && cmbAgeMax.SelectedIndex == 1;
            find.sizeminormore = chkSizeMin.Checked && cmbSizeMin.SelectedIndex == 0;
            find.sizeminmore = chkSizeMin.Checked && cmbSizeMin.SelectedIndex == 1;
            find.sizemaxorless = chkSizeMax.Checked && cmbSizeMax.SelectedIndex == 0;
            find.sizemaxless = chkSizeMax.Checked && cmbSizeMax.SelectedIndex == 1;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}