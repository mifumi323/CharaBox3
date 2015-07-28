using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MifuminLib;

namespace CharaBox3
{
    /// <summary>�L�����f�[�^���Ǘ����Ă���N���X�B</summary>
    public class CharaData
    {
        string fileName;

        public struct CharaInfo
        {
            public string[] name;
            public string[] game;
            public string graphic;
            public enum Sex
            {
                Unknown,
                Male,
                Female,
                Bisexual,
                Mixed,
                None
            };
            public Sex sex;
            public string age;
            public string size;
            public string description;
            public DateTime update;
        };
        public CharaInfo[] chara = new CharaInfo[0];
        public int selected = 0;

        public struct FindCondition
        {
            public string name;
            public string game;
            public string description;
            public string graphic;
            public CharaInfo.Sex sex;
            public string agemin;
            public string agemax;
            public string sizemin;
            public string sizemax;
            public bool namematch;
            public bool namecontain;
            public bool namenotcontain;
            public bool gamematch;
            public bool gamecontain;
            public bool gamenotcontain;
            public bool descriptionmatch;
            public bool descriptioncontain;
            public bool descriptionnotcontain;
            public bool graphicmatch;
            public bool graphiccontain;
            public bool graphicnotcontain;
            public bool sexmatch;
            public bool sexnotmatch;
            public bool ageminormore;
            public bool ageminmore;
            public bool agemaxorless;
            public bool agemaxless;
            public bool sizeminormore;
            public bool sizeminmore;
            public bool sizemaxorless;
            public bool sizemaxless;

            public bool Match(CharaInfo chara)
            {
                bool match;
                // ���O
                if (namematch)
                {
                    match = false;
                    foreach (string s in chara.name) { if (name == s) { match = true; break; } }
                    if (!match) return false;
                }
                else if (namecontain)
                {
                    match = false;
                    foreach (string s in chara.name) { if (s.Contains(name)) { match = true; break; } }
                    if (!match) return false;
                }
                else if (namenotcontain)
                {
                    foreach (string s in chara.name) { if (s.Contains(name)) return false; }
                }
                // �o���i
                if (gamematch)
                {
                    match = false;
                    foreach (string s in chara.game) { if (game == s) { match = true; break; } }
                    if (!match) return false;
                }
                else if (gamecontain)
                {
                    match = false;
                    foreach (string s in chara.game) { if (s.Contains(game)) { match = true; break; } }
                    if (!match) return false;
                }
                else if (gamenotcontain)
                {
                    foreach (string s in chara.game) { if (s.Contains(game)) return false; }
                }
                // ����
                if (descriptionmatch) { if (chara.description != description) return false; }
                else if (descriptioncontain) { if (!chara.description.Contains(description)) return false; }
                else if (descriptionnotcontain) { if (chara.description.Contains(description)) return false; }
                // �摜
                if (graphicmatch) { if (chara.graphic != graphic) return false; }
                else if (graphiccontain) { if (!chara.graphic.Contains(graphic)) return false; }
                else if (graphicnotcontain) { if (chara.graphic.Contains(graphic)) return false; }
                // ����
                if (sexmatch) { if (chara.sex != sex) return false; }
                else if (sexnotmatch) { if (chara.sex == sex) return false; }
                // �N���
                if (ageminormore) { if (pqaAge.GetValue(chara.age) < pqaAge.GetValue(agemin)) return false; }
                else if (ageminmore) { if (pqaAge.GetValue(chara.age) <= pqaAge.GetValue(agemin)) return false; }
                // �N����
                if (agemaxorless) { if (pqaAge.GetValue(chara.age) > pqaAge.GetValue(agemax)) return false; }
                else if (agemaxless) { if (pqaAge.GetValue(chara.age) >= pqaAge.GetValue(agemax)) return false; }
                // �傫������
                if (sizeminormore) { if (pqaSize.GetValue(chara.size) < pqaSize.GetValue(sizemin)) return false; }
                else if (sizeminmore) { if (pqaSize.GetValue(chara.size) <= pqaSize.GetValue(sizemin)) return false; }
                // �傫�����
                if (sizemaxorless) { if (pqaSize.GetValue(chara.size) > pqaSize.GetValue(sizemax)) return false; }
                else if (sizemaxless) { if (pqaSize.GetValue(chara.size) >= pqaSize.GetValue(sizemax)) return false; }
                return true;
            }
        }

        static public PhysicalQuantityAnalyzer pqaAge = new PhysicalQuantityAnalyzer(PhysicalQuantityAnalyzer.Word.def, PhysicalQuantityAnalyzer.Word.time);
        static public PhysicalQuantityAnalyzer pqaSize = new PhysicalQuantityAnalyzer(PhysicalQuantityAnalyzer.Word.def, PhysicalQuantityAnalyzer.Word.len);

        public static CharaInfo.Sex[] sexes = new CharaInfo.Sex[]{
            CharaInfo.Sex.Unknown,
            CharaInfo.Sex.Male,
            CharaInfo.Sex.Female,
            CharaInfo.Sex.Bisexual,
            CharaInfo.Sex.Mixed,
            CharaInfo.Sex.None
        };

        public CharaData(string file)
        {
            fileName = file;
        }

        public bool Load()
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    String line, buf;
                    int i, j;
                    bool isValid = false;
                    i = 0;
                    line = "End";
                    chara = new CharaInfo[1];
                    do
                    {
                        switch (line)
                        {
                            case "CharaBox3":
                                isValid = true;
                                break;
                            case "Selected":
                                selected = int.Parse(sr.ReadLine());
                                break;
                            case "Name":
                                j = 0;
                                while ((buf = sr.ReadLine()) != "")
                                {
                                    Array.Resize(ref chara[i - 1].name, j + 1);
                                    chara[i - 1].name[j] = buf;
                                    j++;
                                }
                                break;
                            case "Game":
                                j = 0;
                                while ((buf = sr.ReadLine()) != "")
                                {
                                    Array.Resize(ref chara[i - 1].game, j + 1);
                                    chara[i - 1].game[j] = buf;
                                    j++;
                                }
                                break;
                            case "Graphic":
                                chara[i - 1].graphic = sr.ReadLine();
                                break;
                            case "Sex":
                                chara[i - 1].sex = GetSex(sr.ReadLine());
                                break;
                            case "Age":
                                chara[i - 1].age = sr.ReadLine();
                                break;
                            case "Size":
                                chara[i - 1].size = sr.ReadLine();
                                break;
                            case "Description":
                                chara[i - 1].description = sr.ReadLine().Replace("\\n", "\r\n");
                                break;
                            case "Update":
                                chara[i - 1].update = new DateTime(long.Parse(sr.ReadLine()));
                                break;
                            case "End":
                                i++;
                                if (i > chara.Length) Array.Resize(ref chara, chara.Length * 2);
                                chara[i - 1].name = new string[0];
                                chara[i - 1].game = new string[0];
                                break;
                            default: break;
                        }
                    } while ((line = sr.ReadLine()) != null);
                    Array.Resize(ref chara, i - 1);
                    return isValid;
                }
            }
            catch (FileNotFoundException)
            {
                return true;    // �t�@�C�������݂��Ȃ��Ȃ�V�K�쐬
            }
            catch (Exception)
            {
                return false;   // ���̑��G���[�Ȃ�ǂݍ��܂Ȃ�
            }
        }

        public void Save()
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("CharaBox3");
                sw.WriteLine("Selected");
                sw.WriteLine(selected);
                foreach (CharaInfo c in chara)
                {
                    sw.WriteLine("Name");
                    foreach (string name in c.name)
                    {
                        sw.WriteLine(name);
                    }
                    sw.WriteLine();
                    sw.WriteLine("Game");
                    foreach (string game in c.game)
                    {
                        sw.WriteLine(game);
                    }
                    sw.WriteLine();
                    sw.WriteLine("Graphic");
                    sw.WriteLine(c.graphic);
                    sw.WriteLine("Sex");
                    sw.WriteLine(GetSex(c.sex));
                    sw.WriteLine("Age");
                    sw.WriteLine(c.age);
                    sw.WriteLine("Size");
                    sw.WriteLine(c.size);
                    sw.WriteLine("Description");
                    sw.WriteLine(c.description.Replace("\r\n", "\\n").Replace("\r", "\\n").Replace("\n", "\\n"));
                    sw.WriteLine("Update");
                    sw.WriteLine(c.update.Ticks);
                    sw.WriteLine("End");
                }
            }
        }

        static public string GetSex(CharaInfo.Sex sex)
        {
            return
                sex == CharaInfo.Sex.Unknown ? "�s��" :
                sex == CharaInfo.Sex.Male ? "�j" :
                sex == CharaInfo.Sex.Female ? "��" :
                sex == CharaInfo.Sex.Bisexual ? "����" :
                sex == CharaInfo.Sex.Mixed ? "����" :
                sex == CharaInfo.Sex.None ? "�Ȃ�" :
                "�s��";
        }

        static public CharaInfo.Sex GetSex(string sex)
        {
            return
                sex == "�s��" ? CharaInfo.Sex.Unknown :
                sex == "�j" ? CharaInfo.Sex.Male :
                sex == "��" ? CharaInfo.Sex.Female :
                sex == "����" ? CharaInfo.Sex.Bisexual :
                sex == "����" ? CharaInfo.Sex.Mixed :
                sex == "�Ȃ�" ? CharaInfo.Sex.None :
                CharaInfo.Sex.Unknown;
        }

        public int Add(CharaInfo newChara)
        {
            Array.Resize(ref chara, chara.Length + 1);
            chara[chara.Length - 1] = newChara;
            return chara.Length - 1;
        }

        public int Delete(int index)
        {
            if (index < 0 || chara.Length <= index) return index;
            chara[index] = chara[chara.Length - 1];
            Array.Resize(ref chara, chara.Length - 1);
            return Math.Min(index, chara.Length - 1);
        }

        static public float GetSize(string size)
        {
            return 0.0f;
        }

        static public string GetAgeString(string age)
        {
            if (age.Length < 8) return age;
            try
            {
                DateTime date = DateTime.Parse(age);
                int nAge = DateTime.Now.Year - date.Year;
                if (DateTime.Now.Month * 32 + DateTime.Now.Day < date.Month * 32 + date.Day) nAge--;
                if (nAge != 0) return nAge + "��";
                int nMonth = DateTime.Now.Month - date.Month;
                if (DateTime.Now.Day < date.Day) nMonth--;
                if (nMonth < 0) nMonth += 12;
                return DateTime.Now.Subtract(date).Days + "��";
            }
            catch (Exception)
            {
                return age;
            }
        }
    }
}
