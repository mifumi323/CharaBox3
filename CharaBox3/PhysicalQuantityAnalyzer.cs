using System;
using System.Collections.Generic;
using System.Text;

namespace MifuminLib
{
    public class PhysicalQuantityAnalyzer
    {
        public struct Word
        {
            public Word(string text, Meaning meaning, double value)
            {
                this.text = text.ToCharArray();
                this.length = text.Length;
                this.meaning = meaning;
                this.value = value;
            }
            public char[] text;
            public int length;
            public enum Meaning
            {
                Value,
                Hundred,
                Thousand,
                Unit,
                Point,
            };
            public Meaning meaning;
            public double value;
            // �f�t�H���g(�P���Ȑ����̂�)
            public static Word[] def = {
                // ���p����
                new Word("0", Meaning.Value, 0.0),
                new Word("1", Meaning.Value, 1.0), new Word("2", Meaning.Value, 2.0), new Word("3", Meaning.Value, 3.0),
                new Word("4", Meaning.Value, 4.0), new Word("5", Meaning.Value, 5.0), new Word("6", Meaning.Value, 6.0),
                new Word("7", Meaning.Value, 7.0), new Word("8", Meaning.Value, 8.0), new Word("9", Meaning.Value, 9.0),
                // �S�p����
                new Word("�O", Meaning.Value, 0.0),
                new Word("�P", Meaning.Value, 1.0), new Word("�Q", Meaning.Value, 2.0), new Word("�R", Meaning.Value, 3.0),
                new Word("�S", Meaning.Value, 4.0), new Word("�T", Meaning.Value, 5.0), new Word("�U", Meaning.Value, 6.0),
                new Word("�V", Meaning.Value, 7.0), new Word("�W", Meaning.Value, 8.0), new Word("�X", Meaning.Value, 9.0),
                // ������
                new Word("�Z", Meaning.Value, 0.0),
                new Word("��", Meaning.Value, 1.0), new Word("��", Meaning.Value, 2.0), new Word("�O", Meaning.Value, 3.0),
                new Word("�l", Meaning.Value, 4.0), new Word("��", Meaning.Value, 5.0), new Word("�Z", Meaning.Value, 6.0),
                new Word("��", Meaning.Value, 7.0), new Word("��", Meaning.Value, 8.0), new Word("��", Meaning.Value, 9.0),
                // ������(�厚)
                new Word("��", Meaning.Value, 0.0),
                new Word("��", Meaning.Value, 1.0), new Word("��", Meaning.Value, 2.0), new Word("�Q", Meaning.Value, 3.0),
                new Word("��", Meaning.Value, 4.0), new Word("��", Meaning.Value, 5.0), new Word("��", Meaning.Value, 6.0),
                new Word("��", Meaning.Value, 7.0), new Word("�J", Meaning.Value, 8.0), new Word("��", Meaning.Value, 9.0),
                // �����_
                new Word(".", Meaning.Point, 0.0), new Word("�D", Meaning.Point, 0.0), new Word("�B", Meaning.Point, 0.0),
                // ��ȉ�
                new Word("�\", Meaning.Hundred, 1e1), new Word("�S", Meaning.Hundred, 1e2),
                new Word("��", Meaning.Hundred, 1e3),
                // ���ȏ�
                new Word("��", Meaning.Thousand, 1e4), new Word("��", Meaning.Thousand, 1e8),
                new Word("��", Meaning.Thousand, 1e12), new Word("��", Meaning.Thousand, 1e16),
                new Word("��", Meaning.Thousand, 1e20), new Word("��", Meaning.Thousand, 1e24),
                new Word("��", Meaning.Thousand, 1e28), new Word("�a", Meaning.Thousand, 1e32),
                new Word("��", Meaning.Thousand, 1e36), new Word("��", Meaning.Thousand, 1e40),
                new Word("��", Meaning.Thousand, 1e44), new Word("��", Meaning.Thousand, 1e48),
                new Word("�P�͍�", Meaning.Thousand, 1e52), new Word("���m�_", Meaning.Thousand, 1e56),
                new Word("�ߗR��", Meaning.Thousand, 1e60), new Word("�s�v�c", Meaning.Thousand, 1e64),
                new Word("���ʑ吔", Meaning.Thousand, 1e68),
                // �ʎ�萔��(�厚)
                new Word("�E", Meaning.Hundred, 1e1), new Word("�", Meaning.Hundred, 1e2),
                new Word("�", Meaning.Hundred, 1e3), new Word("��", Meaning.Thousand, 1e4),
                // ����
                new Word("��", Meaning.Value, 5.0),
            };
            // �����i���[�g����j
            public static Word[] len = {
                new Word("�s�R���[�g��", Word.Meaning.Unit, 1e-12),     new Word("�s�R", Word.Meaning.Unit, 1e-12),
                new Word("�i�m���[�g��", Word.Meaning.Unit, 1e-9),      new Word("�i�m", Word.Meaning.Unit, 1e-9),
                new Word("�}�C�N�����[�g��", Word.Meaning.Unit, 1e-6),  new Word("�}�C�N��", Word.Meaning.Unit, 1e-6),
                new Word("�~�����[�g��", Word.Meaning.Unit, 1e-3),      new Word("�~��", Word.Meaning.Unit, 1e-3),
                new Word("�Z���`���[�g��", Word.Meaning.Unit, 1e-2),    new Word("�Z���`", Word.Meaning.Unit, 1e-2),
                new Word("���[�g��", Word.Meaning.Unit, 1e0),
                new Word("�L�����[�g��", Word.Meaning.Unit, 1e3),       new Word("�L��", Word.Meaning.Unit, 1e3),
                new Word("���K���[�g��", Word.Meaning.Unit, 1e6),       new Word("���K", Word.Meaning.Unit, 1e6),
                new Word("pm", Word.Meaning.Unit, 1e-12),   new Word("����", Word.Meaning.Unit, 1e-12),
                new Word("nm", Word.Meaning.Unit, 1e-9),    new Word("����", Word.Meaning.Unit, 1e-9),
                new Word("um", Word.Meaning.Unit, 1e-6),    new Word("����", Word.Meaning.Unit, 1e-6),
                new Word("mm", Word.Meaning.Unit, 1e-3),    new Word("����", Word.Meaning.Unit, 1e-3),
                new Word("cm", Word.Meaning.Unit, 1e-2),    new Word("����", Word.Meaning.Unit, 1e-2),
                new Word("m", Word.Meaning.Unit, 1e-0),     new Word("��", Word.Meaning.Unit, 1e-0),
                new Word("km", Word.Meaning.Unit, 1e3),     new Word("����", Word.Meaning.Unit, 1e3),
                new Word("Mm", Word.Meaning.Unit, 1e6),     new Word("�l��", Word.Meaning.Unit, 1e6),
                new Word("���[�^�[", Word.Meaning.Unit, 1e-0),
                new Word("�~�N����", Word.Meaning.Unit, 1e-6),
                new Word("��", Word.Meaning.Unit, 1e-6),
                new Word("��m", Word.Meaning.Unit, 1e-6),
                new Word("�ʂ�", Word.Meaning.Unit, 1e-6),
                new Word("�V���P��", Word.Meaning.Unit, 1.496e11),
                new Word("���N", Word.Meaning.Unit, 9.46e15),
                new Word("�p�[�Z�N", Word.Meaning.Unit, 30.86e15),
                new Word("�I���O�X�g���[��", Word.Meaning.Unit, 1e-10),     new Word("��", Word.Meaning.Unit, 1e-10),
                new Word("�o�[���C�R�[��", Word.Meaning.Unit, 0.008467),    new Word("barleycorn", Word.Meaning.Unit, 0.008467),
                new Word("�C���`", Word.Meaning.Unit, 0.0254),              new Word("inch", Word.Meaning.Unit, 0.0254),
                new Word("�t�B�[�g", Word.Meaning.Unit, 0.3048),            new Word("feet", Word.Meaning.Unit, 0.3048),
                new Word("���[�h", Word.Meaning.Unit, 0.9144),              new Word("yard", Word.Meaning.Unit, 0.9144),
                new Word("�|�[��", Word.Meaning.Unit, 5.0292),              new Word("pole", Word.Meaning.Unit, 5.0292),
                new Word("�`�F�[��", Word.Meaning.Unit, 20.1168),           new Word("chain", Word.Meaning.Unit, 20.1168),
                new Word("�n����", Word.Meaning.Unit, 201.168),             new Word("furlong", Word.Meaning.Unit, 201.168),
                new Word("�}�C��", Word.Meaning.Unit, 1609.344),            new Word("mile", Word.Meaning.Unit, 1609.344),
                new Word("���[�O", Word.Meaning.Unit, 4828.032),            new Word("league", Word.Meaning.Unit, 4828.032),
                new Word("in", Word.Meaning.Unit, 0.0254),
                new Word("ft", Word.Meaning.Unit, 0.3048),
                new Word("yd", Word.Meaning.Unit, 0.9144),
                new Word("foot", Word.Meaning.Unit, 0.3048),
                new Word("��", Word.Meaning.Unit, 3926.88),
                new Word("��", Word.Meaning.Unit, 109.08),
                new Word("��", Word.Meaning.Unit, 1.818),
                new Word("��", Word.Meaning.Unit, 3.03),
                new Word("��", Word.Meaning.Unit, 0.303),
                new Word("��", Word.Meaning.Unit, 0.0303),
            };
            // ���ԁi�N��j
            public static Word[] time = {
                new Word("�b", Word.Meaning.Unit, 1.0),
                new Word("��", Word.Meaning.Unit, 60.0),
                new Word("����", Word.Meaning.Unit, 3600.0),
                new Word("��", Word.Meaning.Unit, 86400.0),
                new Word("�T", Word.Meaning.Unit, 604800.0),
                new Word("��", Word.Meaning.Unit, 2592000.0),
                new Word("�N", Word.Meaning.Unit, 31536000.0),
                new Word("��", Word.Meaning.Unit, 31536000.0),      new Word("��", Word.Meaning.Unit, 31536000.0),
                new Word("���I", Word.Meaning.Unit, 3153600000.0),
                new Word("�~���b", Word.Meaning.Unit, 1.0e-3),
                new Word("m�b", Word.Meaning.Unit, 1.0e-3),         new Word("���b", Word.Meaning.Unit, 1.0e-3),
                new Word("�}�C�N���b", Word.Meaning.Unit, 1.0e-6),
                new Word("�ʕb", Word.Meaning.Unit, 1.0e-6),
                new Word("u�b", Word.Meaning.Unit, 1.0e-6),         new Word("���b", Word.Meaning.Unit, 1.0e-6),
                new Word("�i�m�b", Word.Meaning.Unit, 1.0e-9),
                new Word("n�b", Word.Meaning.Unit, 1.0e-9),         new Word("���b", Word.Meaning.Unit, 1.0e-9),
                new Word("�s�R�b", Word.Meaning.Unit, 1.0e-12),
                new Word("p�b", Word.Meaning.Unit, 1.0e-12),        new Word("���b", Word.Meaning.Unit, 1.0e-12),
                new Word("��", Word.Meaning.Unit, 31536000.000001),
            };
        };
        Word[] dic;

        public class WordComparer : System.Collections.IComparer
        {
            int System.Collections.IComparer.Compare(Object x, Object y)
            {
                return ((Word)y).text.Length - ((Word)x).text.Length;
            }
        }

        public PhysicalQuantityAnalyzer(Word[] pairs)
        {
            dic = pairs;
            // �����ɂ��č~���ɕ��ׂ�
            Array.Sort(dic, new WordComparer());
        }

        public PhysicalQuantityAnalyzer(Word[] pairs1, Word[] pairs2)
        {
            dic = new Word[pairs1.Length + pairs2.Length];
            pairs1.CopyTo(dic, 0);
            pairs2.CopyTo(dic, pairs1.Length);
            // �����ɂ��č~���ɕ��ׂ�
            Array.Sort(dic, new WordComparer());
        }

        public double GetValue(string str)
        {
            double sum = 0.0f;   // Lv0:�P�ʂ��l��������
            double val = 0.0f;   // Lv1:�m�肵�����l
            double ths = 0.0f;   // Lv2:�m�肵������
            double hnd = 0.0f;   // Lv3:�\�A�S�܏\�ȂǁA��ȉ��̐���
            double num = 0.0f;   // Lv4:123�Ȃǂ̐��l
            double dec = 0.0f;   // �����̈�
            char[] text = str.ToCharArray();
            int length = str.Length;
            int i, j, k;
            int max;
            Word word;
            for (i = 0; i < str.Length; i++)
            {
                // ��v����P���T��(�����ɂ��č~���ɕ���ł�̂ōŒ���v)
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
                            // ��v�����I
                            switch (word.meaning)
                            {
                                case Word.Meaning.Value:      // ���ʂ̐���
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
                                case Word.Meaning.Hundred:    // ��Ƃ��S�Ƃ��\�Ƃ�
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
                                case Word.Meaning.Thousand:   // ���Ƃ����Ƃ�
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
                                case Word.Meaning.Unit:       // �P��
                                    sum += (val + ths + hnd + num) * word.value;
                                    val = ths = hnd = num = 0.0;
                                    dec = 0.0;
                                    break;
                                case Word.Meaning.Point:      // �����_
                                    val += ths + hnd + num;
                                    ths = hnd = num = 0.0;
                                    dec = 1.0;
                                    break;
                                default: break;
                            }
                            // ��͂��ς񂾕��|�C���^��i�߂�
                            i += max;
                            j = dic.Length;
                        }
                    }
                }
            }
            return sum + val + ths + hnd + num;
        }
    }
}
