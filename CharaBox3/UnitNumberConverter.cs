using System;
using System.Collections.Generic;
using System.Text;

namespace MifuminLib
{
    /// <summary>
    /// 単位・数値変換クラス
    /// 自然言語に近い形で書かれた単位付きの数値を比較可能な単一の数値に変換します。
    /// </summary>
    public class UnitNumberConverter
    {
        /// <summary>
        /// 変換のヒントとなるデータを与える構造体
        /// </summary>
        public struct Word
        {
            /// <summary>
            /// 構造体にヒントのデータをセットします。
            /// </summary>
            /// <param name="text">変換対象となる文字列</param>
            /// <param name="meaning">文字列の役割</param>
            /// <param name="value">基準との倍率</param>
            public Word(string text, Meaning meaning, double value)
            {
                this.text = text.ToCharArray();
                this.length = text.Length;
                this.meaning = meaning;
                this.value = value;
            }
            public char[] text; // 変換対象の文字配列
            public int length;  // 変換対象の文字列の長さ
            /// <summary>
            /// 文字列の役割
            /// </summary>
            public enum Meaning
            {
                Value,      // 1の位の値(0～9など)
                Hundred,    // 十、百、千などの単位(1の位で修飾される値)
                Thousand,   // 万、億などの単位(千の位以下で修飾される値)
                Unit,       // 単位名
                Point,      // 小数点
            };
            public Meaning meaning; // 文字列の役割
            public double value;    // 基準との倍率
            // デフォルト(単純な数字のみ)
            public static Word[] def = {
                // 半角数字
                new Word("0", Meaning.Value, 0.0),
                new Word("1", Meaning.Value, 1.0), new Word("2", Meaning.Value, 2.0), new Word("3", Meaning.Value, 3.0),
                new Word("4", Meaning.Value, 4.0), new Word("5", Meaning.Value, 5.0), new Word("6", Meaning.Value, 6.0),
                new Word("7", Meaning.Value, 7.0), new Word("8", Meaning.Value, 8.0), new Word("9", Meaning.Value, 9.0),
                // 全角数字
                new Word("０", Meaning.Value, 0.0),
                new Word("１", Meaning.Value, 1.0), new Word("２", Meaning.Value, 2.0), new Word("３", Meaning.Value, 3.0),
                new Word("４", Meaning.Value, 4.0), new Word("５", Meaning.Value, 5.0), new Word("６", Meaning.Value, 6.0),
                new Word("７", Meaning.Value, 7.0), new Word("８", Meaning.Value, 8.0), new Word("９", Meaning.Value, 9.0),
                // 漢数字
                new Word("〇", Meaning.Value, 0.0),
                new Word("一", Meaning.Value, 1.0), new Word("二", Meaning.Value, 2.0), new Word("三", Meaning.Value, 3.0),
                new Word("四", Meaning.Value, 4.0), new Word("五", Meaning.Value, 5.0), new Word("六", Meaning.Value, 6.0),
                new Word("七", Meaning.Value, 7.0), new Word("八", Meaning.Value, 8.0), new Word("九", Meaning.Value, 9.0),
                // 漢数字(大字)
                new Word("零", Meaning.Value, 0.0),
                new Word("壱", Meaning.Value, 1.0), new Word("弐", Meaning.Value, 2.0), new Word("参", Meaning.Value, 3.0),
                new Word("肆", Meaning.Value, 4.0), new Word("伍", Meaning.Value, 5.0), new Word("陸", Meaning.Value, 6.0),
                new Word("漆", Meaning.Value, 7.0), new Word("捌", Meaning.Value, 8.0), new Word("玖", Meaning.Value, 9.0),
                // 小数点
                new Word(".", Meaning.Point, 0.0), new Word("．", Meaning.Point, 0.0), new Word("。", Meaning.Point, 0.0),
                // 千以下
                new Word("十", Meaning.Hundred, 1e1), new Word("百", Meaning.Hundred, 1e2),
                new Word("千", Meaning.Hundred, 1e3),
                // 万以上
                new Word("万", Meaning.Thousand, 1e4), new Word("億", Meaning.Thousand, 1e8),
                new Word("兆", Meaning.Thousand, 1e12), new Word("京", Meaning.Thousand, 1e16),
                new Word("垓", Meaning.Thousand, 1e20), new Word("禾", Meaning.Thousand, 1e24),
                new Word("穣", Meaning.Thousand, 1e28), new Word("溝", Meaning.Thousand, 1e32),
                new Word("澗", Meaning.Thousand, 1e36), new Word("正", Meaning.Thousand, 1e40),
                new Word("載", Meaning.Thousand, 1e44), new Word("極", Meaning.Thousand, 1e48),
                new Word("恒河沙", Meaning.Thousand, 1e52), new Word("阿僧祇", Meaning.Thousand, 1e56),
                new Word("那由他", Meaning.Thousand, 1e60), new Word("不可思議", Meaning.Thousand, 1e64),
                new Word("無量大数", Meaning.Thousand, 1e68),
                // 位取り数字(大字)
                new Word("拾", Meaning.Hundred, 1e1), new Word("陌", Meaning.Hundred, 1e2),
                new Word("阡", Meaning.Hundred, 1e3), new Word("萬", Meaning.Thousand, 1e4),
                // 特殊
                new Word("数", Meaning.Value, 5.0),
            };
            // 長さ（メートル基準）
            public static Word[] len = {
                new Word("ピコメートル", Word.Meaning.Unit, 1e-12),     new Word("ピコ", Word.Meaning.Unit, 1e-12),
                new Word("ナノメートル", Word.Meaning.Unit, 1e-9),      new Word("ナノ", Word.Meaning.Unit, 1e-9),
                new Word("マイクロメートル", Word.Meaning.Unit, 1e-6),  new Word("マイクロ", Word.Meaning.Unit, 1e-6),
                new Word("ミリメートル", Word.Meaning.Unit, 1e-3),      new Word("ミリ", Word.Meaning.Unit, 1e-3),
                new Word("センチメートル", Word.Meaning.Unit, 1e-2),    new Word("センチ", Word.Meaning.Unit, 1e-2),
                new Word("メートル", Word.Meaning.Unit, 1e0),
                new Word("キロメートル", Word.Meaning.Unit, 1e3),       new Word("キロ", Word.Meaning.Unit, 1e3),
                new Word("メガメートル", Word.Meaning.Unit, 1e6),       new Word("メガ", Word.Meaning.Unit, 1e6),
                new Word("pm", Word.Meaning.Unit, 1e-12),   new Word("ｐｍ", Word.Meaning.Unit, 1e-12),
                new Word("nm", Word.Meaning.Unit, 1e-9),    new Word("ｎｍ", Word.Meaning.Unit, 1e-9),
                new Word("um", Word.Meaning.Unit, 1e-6),    new Word("ｕｍ", Word.Meaning.Unit, 1e-6),
                new Word("mm", Word.Meaning.Unit, 1e-3),    new Word("ｍｍ", Word.Meaning.Unit, 1e-3),
                new Word("cm", Word.Meaning.Unit, 1e-2),    new Word("ｃｍ", Word.Meaning.Unit, 1e-2),
                new Word("m", Word.Meaning.Unit, 1e-0),     new Word("ｍ", Word.Meaning.Unit, 1e-0),
                new Word("km", Word.Meaning.Unit, 1e3),     new Word("ｋｍ", Word.Meaning.Unit, 1e3),
                new Word("Mm", Word.Meaning.Unit, 1e6),     new Word("Ｍｍ", Word.Meaning.Unit, 1e6),
                new Word("メーター", Word.Meaning.Unit, 1e-0),
                new Word("ミクロン", Word.Meaning.Unit, 1e-6),
                new Word("μ", Word.Meaning.Unit, 1e-6),
                new Word("μm", Word.Meaning.Unit, 1e-6),
                new Word("μｍ", Word.Meaning.Unit, 1e-6),
                new Word("天文単位", Word.Meaning.Unit, 1.496e11),
                new Word("光年", Word.Meaning.Unit, 9.46e15),
                new Word("パーセク", Word.Meaning.Unit, 30.86e15),
                new Word("オングストローム", Word.Meaning.Unit, 1e-10),     new Word("Å", Word.Meaning.Unit, 1e-10),
                new Word("バーレイコーン", Word.Meaning.Unit, 0.008467),    new Word("barleycorn", Word.Meaning.Unit, 0.008467),
                new Word("インチ", Word.Meaning.Unit, 0.0254),              new Word("inch", Word.Meaning.Unit, 0.0254),
                new Word("フィート", Word.Meaning.Unit, 0.3048),            new Word("feet", Word.Meaning.Unit, 0.3048),
                new Word("ヤード", Word.Meaning.Unit, 0.9144),              new Word("yard", Word.Meaning.Unit, 0.9144),
                new Word("ポール", Word.Meaning.Unit, 5.0292),              new Word("pole", Word.Meaning.Unit, 5.0292),
                new Word("チェーン", Word.Meaning.Unit, 20.1168),           new Word("chain", Word.Meaning.Unit, 20.1168),
                new Word("ハロン", Word.Meaning.Unit, 201.168),             new Word("furlong", Word.Meaning.Unit, 201.168),
                new Word("マイル", Word.Meaning.Unit, 1609.344),            new Word("mile", Word.Meaning.Unit, 1609.344),
                new Word("リーグ", Word.Meaning.Unit, 4828.032),            new Word("league", Word.Meaning.Unit, 4828.032),
                new Word("in", Word.Meaning.Unit, 0.0254),
                new Word("ft", Word.Meaning.Unit, 0.3048),
                new Word("yd", Word.Meaning.Unit, 0.9144),
                new Word("foot", Word.Meaning.Unit, 0.3048),
                new Word("里", Word.Meaning.Unit, 3926.88),
                new Word("町", Word.Meaning.Unit, 109.08),
                new Word("間", Word.Meaning.Unit, 1.818),
                new Word("丈", Word.Meaning.Unit, 3.03),
                new Word("尺", Word.Meaning.Unit, 0.303),
                new Word("寸", Word.Meaning.Unit, 0.0303),
            };
            // 時間（年齢）
            public static Word[] time = {
                new Word("秒", Word.Meaning.Unit, 1.0),
                new Word("分", Word.Meaning.Unit, 60.0),
                new Word("時間", Word.Meaning.Unit, 3600.0),
                new Word("日", Word.Meaning.Unit, 86400.0),
                new Word("週", Word.Meaning.Unit, 604800.0),
                new Word("月", Word.Meaning.Unit, 2592000.0),
                new Word("年", Word.Meaning.Unit, 31536000.0),
                new Word("歳", Word.Meaning.Unit, 31536000.0),      new Word("才", Word.Meaning.Unit, 31536000.0),
                new Word("世紀", Word.Meaning.Unit, 3153600000.0),
                new Word("ミリ秒", Word.Meaning.Unit, 1.0e-3),
                new Word("m秒", Word.Meaning.Unit, 1.0e-3),         new Word("ｍ秒", Word.Meaning.Unit, 1.0e-3),
                new Word("マイクロ秒", Word.Meaning.Unit, 1.0e-6),
                new Word("μ秒", Word.Meaning.Unit, 1.0e-6),
                new Word("u秒", Word.Meaning.Unit, 1.0e-6),         new Word("ｕ秒", Word.Meaning.Unit, 1.0e-6),
                new Word("ナノ秒", Word.Meaning.Unit, 1.0e-9),
                new Word("n秒", Word.Meaning.Unit, 1.0e-9),         new Word("ｎ秒", Word.Meaning.Unit, 1.0e-9),
                new Word("ピコ秒", Word.Meaning.Unit, 1.0e-12),
                new Word("p秒", Word.Meaning.Unit, 1.0e-12),        new Word("ｐ秒", Word.Meaning.Unit, 1.0e-12),
                // これはちょっと特別。
                new Word("代", Word.Meaning.Unit, 31536000.000001),
            };
        };
        Word[] dic;

        /// <summary>
        /// Word構造体の並べ替え基準
        /// </summary>
        public class WordComparer : System.Collections.IComparer
        {
            int System.Collections.IComparer.Compare(Object x, Object y)
            {
                return ((Word)y).text.Length - ((Word)x).text.Length;
            }
        }

        /// <summary>
        /// 単位・数値変換クラスをWord構造体で初期化します
        /// </summary>
        /// <param name="pairs">Word構造体(複数指定可)</param>
        public UnitNumberConverter(params Word[] pairs) : this(new Word[][] { pairs }) { }

        /// <summary>
        /// 単位・数値変換クラスをWord構造体の配列で初期化します
        /// </summary>
        /// <param name="pairs">Word構造体の配列(複数指定可)</param>
        public UnitNumberConverter(params Word[][] pairs)
        {
            int nDicSize = 0;
            foreach (Word[] p in pairs)
            {
                nDicSize += p.Length;
            }
            dic = new Word[nDicSize];
            int nOffset = 0;
            foreach (Word[] p in pairs)
            {
                p.CopyTo(dic, nOffset);
                nOffset += p.Length;
            }
            Array.Sort(dic, new WordComparer());
        }

/*        public UnitNumberConverter(Word[] pairs)
        {
            dic = pairs;
            // 長さについて降順に並べる
            Array.Sort(dic, new WordComparer());
        }

        public UnitNumberConverter(Word[] pairs1, Word[] pairs2)
        {
            dic = new Word[pairs1.Length + pairs2.Length];
            pairs1.CopyTo(dic, 0);
            pairs2.CopyTo(dic, pairs1.Length);
            // 長さについて降順に並べる
            Array.Sort(dic, new WordComparer());
        }*/

        /// <summary>
        /// 文字列を基本単位で表した数値に変換します
        /// </summary>
        /// <param name="str">変換対象の文字列</param>
        /// <returns>変換された数値</returns>
        public double GetValue(string str)
        {
            double sum = 0.0;   // Lv0:単位も考慮した量
            double val = 0.0;   // Lv1:確定した数値
            double ths = 0.0;   // Lv2:確定した整数
            double hnd = 0.0;   // Lv3:十、百五十など、千以下の整数
            double num = 0.0;   // Lv4:123などの数値
            double dec = 0.0;   // 小数の位
            char[] text = str.ToCharArray();
            int length = str.Length;
            int i, j, k;
            int max;
            Word word;
            for (i = 0; i < str.Length; i++)
            {
                // 一致する単語を探す(長さについて降順に並んでるので最長一致)
                for (j = 0; j < dic.Length; j++)
                {
                    word = dic[j];
                    if (i + word.length > length) continue;
                    max = word.length - 1;
                    for (k = 0; k <= max; k++)
                    {
                        if (word.text[k] != text[i + k]) break;
                        if (k == max)
                        {
                            // 一致した！
                            switch (word.meaning)
                            {
                                case Word.Meaning.Value:      // 普通の数字
                                    if (dec == 0.0)
                                    {
                                        num *= 10.0;
                                        num += word.value;
                                    }
                                    else
                                    {
                                        dec /= 10.0;
                                        val += dec * word.value;
                                    }
                                    break;
                                case Word.Meaning.Hundred:    // 千とか百とか十とか
                                    if (num != 0.0)
                                    {
                                        hnd += num * word.value;
                                        num = 0.0;
                                    }
                                    else
                                    {
                                        if (val == 0.0)
                                        {
                                            hnd += word.value;
                                        }
                                        else
                                        {
                                            hnd = val * word.value;
                                            val = 0.0;
                                        }
                                    }
                                    dec = 0.0;
                                    break;
                                case Word.Meaning.Thousand:   // 億とか万とか
                                    if (num != 0.0 || hnd != 0.0)
                                    {
                                        ths += (hnd + num) * word.value;
                                        hnd = num = 0.0;
                                    }
                                    else
                                    {
                                        if (val == 0.0)
                                        {
                                            ths += word.value;
                                        }
                                        else
                                        {
                                            ths = val * word.value;
                                            val = 0.0;
                                        }
                                    }
                                    dec = 0.0;
                                    break;
                                case Word.Meaning.Unit:       // 単位
                                    sum += (val + ths + hnd + num) * word.value;
                                    val = ths = hnd = num = 0.0;
                                    dec = 0.0;
                                    break;
                                case Word.Meaning.Point:      // 小数点
                                    val += ths + hnd + num;
                                    ths = hnd = num = 0.0;
                                    dec = 1.0;
                                    break;
                                default: break;
                            }
                            // 解析が済んだ分ポインタを進める
                            i += max;
                            j = dic.Length;
                        }
                    }
                }
            }
            return sum + val + ths + hnd + num;
        }

        /// <summary>
        /// 文字列を任意の単位で表した数値に変換します
        /// </summary>
        /// <param name="source">変換対象の文字列</param>
        /// <param name="unit">基準となる単位</param>
        /// <returns>変換された数値</returns>
        public double Convert(string source, string unit)
        {
            return GetValue(source) / GetValue(unit);
        }
    }

    /// <summary>
    /// UnitNumberConverterの長さに特化したバージョン
    /// </summary>
    public class LengthConverter : UnitNumberConverter
    {
        public LengthConverter() : base(Word.def, Word.len) { }
    }

    /// <summary>
    /// UnitNumberConverterの時間に特化したバージョン
    /// </summary>
    public class TimeConverter : UnitNumberConverter
    {
        public TimeConverter() : base(Word.def, Word.time) { }
    }

    /// <summary>
    /// PhysicalQuantityAnalyzerはUnitNumberConverterに名称変更しました。
    /// 今後はUnitNumberConverterを使用してください。
    /// </summary>
    public class PhysicalQuantityAnalyzer : UnitNumberConverter
    {
        public PhysicalQuantityAnalyzer(Word[] pairs) : base(pairs) { }
        public PhysicalQuantityAnalyzer(Word[] pairs1, Word[] pairs2)
            : base(new Word[][] { pairs1, pairs2 }) { }
    }
}
