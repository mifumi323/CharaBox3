using System;
using System.IO;
using MifuminLib;

namespace CharaBox3
{
    /// <summary>キャラデータを管理しているクラス。</summary>
    public class CharaData
    {
        public readonly string fileName;

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
                // 名前
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
                // 登場作品
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
                // 説明
                if (descriptionmatch) { if (chara.description != description) return false; }
                else if (descriptioncontain) { if (!chara.description.Contains(description)) return false; }
                else if (descriptionnotcontain) { if (chara.description.Contains(description)) return false; }
                // 画像
                if (graphicmatch) { if (chara.graphic != graphic) return false; }
                else if (graphiccontain) { if (!chara.graphic.Contains(graphic)) return false; }
                else if (graphicnotcontain) { if (chara.graphic.Contains(graphic)) return false; }
                // 性別
                if (sexmatch) { if (chara.sex != sex) return false; }
                else if (sexnotmatch) { if (chara.sex == sex) return false; }
                // 年齢下限
                if (ageminormore) { if (pqaAge.GetValue(chara.age) < pqaAge.GetValue(agemin)) return false; }
                else if (ageminmore) { if (pqaAge.GetValue(chara.age) <= pqaAge.GetValue(agemin)) return false; }
                // 年齢上限
                if (agemaxorless) { if (pqaAge.GetValue(chara.age) > pqaAge.GetValue(agemax)) return false; }
                else if (agemaxless) { if (pqaAge.GetValue(chara.age) >= pqaAge.GetValue(agemax)) return false; }
                // 大きさ下限
                if (sizeminormore) { if (pqaSize.GetValue(chara.size) < pqaSize.GetValue(sizemin)) return false; }
                else if (sizeminmore) { if (pqaSize.GetValue(chara.size) <= pqaSize.GetValue(sizemin)) return false; }
                // 大きさ上限
                if (sizemaxorless) { if (pqaSize.GetValue(chara.size) > pqaSize.GetValue(sizemax)) return false; }
                else if (sizemaxless) { if (pqaSize.GetValue(chara.size) >= pqaSize.GetValue(sizemax)) return false; }
                return true;
            }
        }

        public static PhysicalQuantityAnalyzer pqaAge = new PhysicalQuantityAnalyzer(PhysicalQuantityAnalyzer.Word.def, PhysicalQuantityAnalyzer.Word.time);
        public static PhysicalQuantityAnalyzer pqaSize = new PhysicalQuantityAnalyzer(PhysicalQuantityAnalyzer.Word.def, PhysicalQuantityAnalyzer.Word.len);

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
                return true;    // ファイルが存在しないなら新規作成
            }
            catch (Exception)
            {
                return false;   // その他エラーなら読み込まない
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

        public static string GetSex(CharaInfo.Sex sex)
        {
            return
                sex == CharaInfo.Sex.Unknown ? "不明" :
                sex == CharaInfo.Sex.Male ? "男" :
                sex == CharaInfo.Sex.Female ? "女" :
                sex == CharaInfo.Sex.Bisexual ? "両性" :
                sex == CharaInfo.Sex.Mixed ? "混合" :
                sex == CharaInfo.Sex.None ? "なし" :
                "不明";
        }

        public static CharaInfo.Sex GetSex(string sex)
        {
            return
                sex == "不明" ? CharaInfo.Sex.Unknown :
                sex == "男" ? CharaInfo.Sex.Male :
                sex == "女" ? CharaInfo.Sex.Female :
                sex == "両性" ? CharaInfo.Sex.Bisexual :
                sex == "混合" ? CharaInfo.Sex.Mixed :
                sex == "なし" ? CharaInfo.Sex.None :
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

        public static string GetAgeString(string age)
        {
            if (age.Length < 8) return age;
            try
            {
                DateTime date = DateTime.Parse(age);
                int nAge = DateTime.Now.Year - date.Year;
                if (DateTime.Now.Month * 32 + DateTime.Now.Day < date.Month * 32 + date.Day) nAge--;
                if (nAge != 0) return nAge + "歳";
                int nMonth = DateTime.Now.Month - date.Month;
                if (DateTime.Now.Day < date.Day) nMonth--;
                if (nMonth < 0) nMonth += 12;
                return DateTime.Now.Subtract(date).Days + "日";
            }
            catch (Exception)
            {
                return age;
            }
        }
    }
}
