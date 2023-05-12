using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tipa_graf;

namespace TypografUnitTest
{
    [TestClass]
    public class Unittest
    {
        [TestMethod]
        public void Meth1()
        {
            var t = new Form1();
            string s = "a,b";
            string result = t.Punctuacziya(s);
            Assert.AreEqual("a, b", result);
        }
        [TestMethod]
        public void Meth2()
        {
            var t = new Form1();
            string s = "a ,b";
            string result = t.Punctuacziya(s);
            Assert.AreEqual("a, b", result);
        }
        [TestMethod]
        public void Meth5()
        {
            var t = new Form1();
            string s = "a(b)";
            string result = t.Punctuacziya(s);
            Assert.AreEqual("a (b) ", result);
        }
        [TestMethod]
        public void Meth6()
        {
            var t = new Form1();
            string s = "a(b)c";
            string result = t.Punctuacziya(s);
            Assert.AreEqual("a (b) c", result);
        }
        [TestMethod]
        public void Meth7()
        {
            var t = new Form1();
            string s = "a—b";
            string result = t.Punctuacziya(s);
            Assert.AreEqual("a — b", result);
        }
        [TestMethod]
        public void Tech()
        {
            var t = new Form1();
            string s = "100 B";
            string result = t.TechXarakteristiki(s);
            Assert.AreEqual("100 B", result);
        }
        [TestMethod]
        public void Num()
        {
            var t = new Form1();
            string s = "100";
            bool result = t.IsNumeric(s);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void Degree()
        {
            string in_str = "^2";
            string excepted = "\u00B2";

            Form1 main = new Form1();

            string actual = main.Degrees(in_str);

            Assert.AreEqual(excepted, actual);
        }
        [TestMethod]
        public void Apply_Returned()
        {
            string text = "f - f";
            string expected = "f-f";

            Form1 main = new Form1();
            string actual = main.Apply(text);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ProshliyVek_Returned1()
        {
            string text = "пицца";
            string expected = "п1цца";

            Form1 main = new Form1();
            string actual = main.Apply(text);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ProshliyVek_Returned2()
        {
            string text = "карлiк";
            string expected = "к4рл1к";

            Form1 main = new Form1();
            string actual = main.Apply(text);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Smeshki_Returned()
        {
            string text = "орыч";
            string expected = "орыч)0)0)";

            Form1 main = new Form1();
            string actual = main.Apply(text);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Gigachad_Confirmed()
        {
            string text = "Данич";
            string expected = "                      ДАНИССИМУС \\r\\n ⠀⠀⠘⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡜⠀⠀⠀\\r\\n⠀⠀⠀⠑⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\" +\r\n                        \"⡔⠁⠀⠀⠀\\r\\n⠀⠀⠀⠀⠈⠢⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠴⠊⠀⠀⠀⠀⠀\\r\\n⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⢀⣀⣀⣀⣀⣀⡀⠤⠄⠒⠈⠀⠀⠀⠀⠀⠀⠀⠀\\r\\n\" +\r\n                        \"⠀⠀⠀⠀⠀⠀⠀⠘⣀⠄⠊⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\\r\\n⠀\\r\\n⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠛⠛⠛⠋⠉⠈⠉⠉⠉⠉⠛⠻⢿⣿⣿⣿⣿⣿⣿⣿\\r\\n⣿⣿⣿⣿⣿⡿⠋⠁⠀⠀⠀\" +\r\n                        \"⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⢿⣿⣿⣿⣿\\r\\n⣿⣿⣿⣿⡏⣀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣤⣤⣄⡀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿\\r\\n⣿⣿⣿⢏⣴⣿⣷⠀⠀⠀⠀⠀⢾⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀\" +\r\n                        \"⠀⠀⠈⣿⣿\\r\\n⣿⣿⣟⣾⣿⡟⠁⠀⠀⠀⠀⠀⢀⣾⣿⣿⣿⣿⣿⣷⢢⠀⠀⠀⠀⠀⠀⠀⢸⣿\\r\\n⣿⣿⣿⣿⣟⠀⡴⠄⠀⠀⠀⠀⠀⠀⠙⠻⣿⣿⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⣿\\r\\n⣿⣿⣿⠟⠻⠀⠀\" +\r\n                        \"⠀⠀⠀⠀⠀⠀⠀⠀⠶⢴⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⣿\\r\\n⣿⣁⡀⠀⠀⢰⢠⣦⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⣿⣿⣿⣿⣿⡄⠀⣴⣶⣿⡄⣿\\r\\n⣿⡋⠀⠀⠀⠎⢸⣿⡆⠀⠀⠀⠀⠀⠀⣴⣿⣿⣿⣿⣿⣿⣿⠗⢘⣿⣟⠛⠿⣼\\r\\n⣿⣿⠋⢀⡌⢰⣿⡿⢿⡀\" +\r\n                        \"⠀⠀⠀⠀⠀⠙⠿⣿⣿⣿⣿⣿⡇⠀⢸⣿⣿⣧⢀⣼\\r\\n⣿⣿⣷⢻⠄⠘⠛⠋⠛⠃⠀⠀⠀⠀⠀⢿⣧⠈⠉⠙⠛⠋⠀⠀⠀⣿⣿⣿⣿⣿\\r\\n⣿⣿⣧⠀⠈⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠟⠀⠀⠀⠀⢀⢃⠀⠀⢸⣿⣿⣿⣿\\r\\n⣿⣿⡿⠀⠴⢗⣠⣤⣴⡶⠶⠖⠀⠀⠀⠀⠀\" +\r\n                        \"⠀⠀⠀⠀⠀⠀⣀⡸⠀⣿⣿⣿⣿\\r\\n⣿⣿⣿⡀⢠⣾⣿⠏⠀⠠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⠉⠀⣿⣿⣿⣿\\r\\n⣿⣿⣿⣧⠈⢹⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿\\r\\n⣿⣿⣿⣿⡄⠈⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀\" +\r\n                        \"⠀⠀⠀⠀⠀⢀⣠⣴⣾⣿⣿⣿⣿⣿\\r\\n⣿⣿⣿⣿⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿\\r\\n⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\\r\\n⣿⣿⣿⣿⣿⣦⣄⣀⣀⣀⣀⠀⠀⠀\" +\r\n                        \"⠀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\\r\\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡄⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\\r\\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠙⣿⣿⡟⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿\\r\\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠇⠀\" +\r\n                        \"⠁⠀⠀⠹⣿⠃⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿\\r\\n⣿⣿⣿⣿⣿⣿⣿⣿⡿⠛⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⢐⣿⣿⣿⣿⣿⣿⣿⣿⣿\\r\\n⣿⣿⣿⣿⠿⠛⠉⠉⠁⠀⢻⣿⡇⠀⠀⠀⠀⠀⠀⢀⠈⣿⣿⡿⠉⠛⠛⠛⠉⠉\\r\\n⣿⡿⠋⠁⠀⠀⢀⣀⣠⡴⣸⣿⣇⡄⠀⠀⠀⠀⢀⡿⠄⠙⠛⠀⣀⣠⣤⣤⠄⠀";

            Form1 main = new Form1();
            string actual = main.Apply(text);

            Assert.AreEqual(expected, actual);
        }
    }
}
