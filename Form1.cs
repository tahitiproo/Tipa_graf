using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tipa_graf
{
    public partial class Form1 : Form
    {
        string result;
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                string text = richTextBox1.Text;

                richTextBox1.BackColor = Color.White;
                richTextBox1.ForeColor = Color.Black;

                result = Punctuacziya(text);
                result = TechXarakteristiki(result);
                result = Apply(result);
                result = Degrees(result);
                result = Rzhomba(result);
                result = ProshliyVek(result);
                result = DANISSIMUS(result);
                
                richTextBox1.Text = result;
                if (richTextBox1.Text.Contains("даниссимус".ToUpper()))
                {
                    richTextBox1.BackColor = Color.Black;
                    richTextBox1.ForeColor = Color.White;
                }
            }
            else
            {
                MessageBox.Show("Вы ничего не ввели");
            }
        }
        public string Punctuacziya(string slova)
        {
            string[] punctuacziya = new string[] { ",", ".", ":", ";", "!", "?" };
            string[] otkrit = new string[] { "(", "«" };
            string[] zakrit = new string[] { ")", "»" };
            string result = slova;

            foreach (string c in punctuacziya)
            {
                if (result.Contains(" " + c))
                {
                    result = result.Replace(" " + c, c);
                }
                if (result.Contains(c))
                {
                    result = result.Replace(c, c + " ");
                }
            }

            if (result.Contains("—"))
            {
                result = result.Replace("—", " — ");
            }

            foreach (string c in otkrit)
            {
                if (result.Contains(c))
                {
                    result = result.Replace(c, " " + c);
                }
                if (result.Contains(c + " "))
                {
                    result = result.Replace(c + " ", c);
                }
            }
            foreach (string c in zakrit)
            {
                if (result.Contains(" " + c))
                {
                    result = result.Replace(" " + c, c);
                }
                if (result.Contains(c))
                {
                    result = result.Replace(c, c + " ");
                }
            }
            return result;
        }



        public string TechXarakteristiki(string slova)
        {
            string result = slova;
            for (int i = 0; i < slova.Length; i++)
            {
                if (i + 2 < slova.Length && IsNumeric(result[i].ToString()) && VsyakieOboz(result[i + 2].ToString()))
                {
                    result = result.Remove(i + 1, 1);
                    result = result.Insert(i + 1, '\u00A0'.ToString());
                }
            }
            return result;
        }

        public bool IsNumeric(string slovo)
        {
            double num;
            return double.TryParse(slovo, out num);
        }

        public bool VsyakieOboz(string slovo)
        {
            string[] units = new string[] { "м", "см", "мм", "км", "кг", "г", "А", "мА", "кА", "В", "мВ", "кВ",
                "Вт", "мВт", "кВт", "Дж", "кДж", "ебар", "Па", "кПа", "бар", "мбар", "мм рт. ст.", "об/мин", "рад/с", "%" };
            return units.Contains(slovo);
        }
        public string Apply(string slovo)
        {
            List<char> textSymbol = slovo.ToList();
            List<int> index = new List<int>();
            for (int i = 1; i < textSymbol.Count() - 1; i++)
            {
                if (textSymbol[i] == '-')
                {
                    if (textSymbol[i - 1] == ' ' && index.IndexOf(i - 1) == -1)
                    {
                        index.Add(i - index.Count());
                    }
                    if (textSymbol[i + 1] == ' ')
                    {
                        index.Add(i + 2 - index.Count());
                    }
                }
            }
            foreach (int k in index)
            {
                textSymbol.RemoveAt(k - 1);
            }
            return String.Join("", textSymbol);
        }
        public string Degrees(string str)
        {
            str = str.Replace("^2", "\u00B2");
            str = str.Replace("^3", "\u00B3");
            return str;
        }
        public string ProshliyVek(string text)
        {
            string[] bukva_a = new string[] { "a", "o", "а", "о" };
            string[] bukva_i = new string[] { "i", "y", "е", "и" };
            for (int i = 0;  i < bukva_i.Length; i++)
            {
                if (text.Contains(bukva_i[i]))
                {
                    text.Replace(bukva_i[i], "1");
                }
            }
            for (int j = 0; j < bukva_a.Length; j++)
            {
                if (text.Contains(bukva_a[j]))
                {
                    text.Replace(bukva_a[j], "4");
                }
            }
            return text;
        }
        public string Rzhomba(string text)
        {
            string[] smeshochki = new string[] { "ржомба", "орыч", "смехечанский", "хех", "смешно", "забавно","ahah" };
            for (int i = 0; i < smeshochki.Length; i++)
            {
                if (text.Contains(smeshochki[i]))
                {
                    text.Replace(smeshochki[i], smeshochki[i]+ ")0)0)");
                }
            }
            return text;
        }
        public string DANISSIMUS(string text)
        {
            string[] klikyxi = new string[] { "даня", "даниил", "данил", "данёк", "даник", "данон", "даниссимо", "данич", "данончик" };

            for (int j = 0; j < klikyxi.Length; j++)
            {
                if (text.ToLower().Contains(klikyxi[j]))
                {
                    text = "                      ДАНИССИМУС \r\n ⠀⠀⠘⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡜⠀⠀⠀\r\n⠀⠀⠀⠑⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                        "⡔⠁⠀⠀⠀\r\n⠀⠀⠀⠀⠈⠢⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠴⠊⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⢀⣀⣀⣀⣀⣀⡀⠤⠄⠒⠈⠀⠀⠀⠀⠀⠀⠀⠀\r\n" +
                        "⠀⠀⠀⠀⠀⠀⠀⠘⣀⠄⠊⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀\r\n⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠛⠛⠛⠋⠉⠈⠉⠉⠉⠉⠛⠻⢿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⡿⠋⠁⠀⠀⠀" +
                        "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⢿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⡏⣀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣤⣤⣄⡀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿\r\n⣿⣿⣿⢏⣴⣿⣷⠀⠀⠀⠀⠀⢾⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀" +
                        "⠀⠀⠈⣿⣿\r\n⣿⣿⣟⣾⣿⡟⠁⠀⠀⠀⠀⠀⢀⣾⣿⣿⣿⣿⣿⣷⢢⠀⠀⠀⠀⠀⠀⠀⢸⣿\r\n⣿⣿⣿⣿⣟⠀⡴⠄⠀⠀⠀⠀⠀⠀⠙⠻⣿⣿⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⣿\r\n⣿⣿⣿⠟⠻⠀⠀" +
                        "⠀⠀⠀⠀⠀⠀⠀⠀⠶⢴⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⣿\r\n⣿⣁⡀⠀⠀⢰⢠⣦⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⣿⣿⣿⣿⣿⡄⠀⣴⣶⣿⡄⣿\r\n⣿⡋⠀⠀⠀⠎⢸⣿⡆⠀⠀⠀⠀⠀⠀⣴⣿⣿⣿⣿⣿⣿⣿⠗⢘⣿⣟⠛⠿⣼\r\n⣿⣿⠋⢀⡌⢰⣿⡿⢿⡀" +
                        "⠀⠀⠀⠀⠀⠙⠿⣿⣿⣿⣿⣿⡇⠀⢸⣿⣿⣧⢀⣼\r\n⣿⣿⣷⢻⠄⠘⠛⠋⠛⠃⠀⠀⠀⠀⠀⢿⣧⠈⠉⠙⠛⠋⠀⠀⠀⣿⣿⣿⣿⣿\r\n⣿⣿⣧⠀⠈⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠟⠀⠀⠀⠀⢀⢃⠀⠀⢸⣿⣿⣿⣿\r\n⣿⣿⡿⠀⠴⢗⣠⣤⣴⡶⠶⠖⠀⠀⠀⠀⠀" +
                        "⠀⠀⠀⠀⠀⠀⣀⡸⠀⣿⣿⣿⣿\r\n⣿⣿⣿⡀⢠⣾⣿⠏⠀⠠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⠉⠀⣿⣿⣿⣿\r\n⣿⣿⣿⣧⠈⢹⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿\r\n⣿⣿⣿⣿⡄⠈⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                        "⠀⠀⠀⠀⠀⢀⣠⣴⣾⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣦⣄⣀⣀⣀⣀⠀⠀⠀" +
                        "⠀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡄⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠙⣿⣿⡟⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠇⠀" +
                        "⠁⠀⠀⠹⣿⠃⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⡿⠛⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⢐⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⠿⠛⠉⠉⠁⠀⢻⣿⡇⠀⠀⠀⠀⠀⠀⢀⠈⣿⣿⡿⠉⠛⠛⠛⠉⠉\r\n⣿⡿⠋⠁⠀⠀⢀⣀⣠⡴⣸⣿⣇⡄⠀⠀⠀⠀⢀⡿⠄⠙⠛⠀⣀⣠⣤⣤⠄⠀";
                    return text;
                }
            }
            return text;
        }
    }
}
