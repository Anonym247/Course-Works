using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DES_Algorithm
{
    public partial class Form1 : Form
    {
        int[] ip = { 58, 50, 42, 34, 26, 18, 10, 2, 60, 52, 44, 36, 28, 20, 12, 4, 62, 54, 46, 38, 30, 22, 14, 6, 64, 56, 48, 40, 32, 24, 16, 8, 57, 49, 41, 33, 25, 17, 9, 1, 59, 51, 43, 35, 27, 19, 11, 3, 61, 53, 45, 37, 29, 21, 13, 5, 63, 55, 47, 39, 31, 23, 15, 7 };
        int[] EP = { 32, 1, 2, 3, 4, 5, 4, 5, 6, 7, 8, 9, 8, 9, 10, 11, 12, 13, 12, 13, 14, 15, 16, 17, 16, 17, 18, 19, 20, 21, 20, 21, 22, 23, 24, 25, 24, 25, 26, 27, 28, 29, 28, 29, 30, 31, 32, 1};
        int[] cIP = { 57, 49, 41, 33, 25, 17, 9, 1, 58, 50, 42, 34, 26, 18, 10, 2, 59, 51, 43, 35, 27, 19, 11, 3, 60, 52, 44, 36 };
        int[] dIP = { 63, 55, 47, 39, 31, 23, 15, 7, 62, 54, 46, 38, 30, 22, 14, 6, 61, 53, 45, 37, 29, 21, 13, 5, 28, 20, 12, 4 };
        int[] CPp = { 14, 17, 11, 24, 1, 5, 3, 28, 15, 6, 21, 10, 23, 19, 12, 4, 26, 8, 16, 7, 27, 20, 13, 2, 41, 52, 31, 37, 47, 55, 30, 40, 51, 45, 33, 48, 44, 49, 39, 56, 34, 53, 46, 42, 50, 36, 29, 32 };
        int[,] S1 = { {14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7 }, {0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8 }, {4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0 }, {15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 } };
        int[,] S2 = { {15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10 }, {3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5 }, {0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15 }, {13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 } };
        int[,] S3 = { {10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8 }, {13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1 }, {13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7 }, {1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 } };
        int[,] S4 = { {7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15 }, {13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9 }, {10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4 }, {3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 } };
        int[,] S5 = { {2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9 }, {14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9 ,8 ,6 }, {4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14 }, {11, 8, 12, 7, 1, 14, 2 ,13, 6, 15, 0, 9, 10, 4, 5, 3 } };
        int[,] S6 = { {12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 }, {10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8 }, {9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6 }, {4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 } };
        int[,] S7 = { {4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1 }, {13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6 }, {1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2 }, {6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 } };
        int[,] S8 = { {13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7 }, {1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2 }, {7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8 }, {2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 } };
        int[] funcP = { 16, 7, 20, 21, 29, 12, 28, 17, 1, 15, 23, 26, 5, 18, 31, 10, 2, 8, 24, 14, 32, 27, 3, 9, 19, 13, 30, 6, 22, 11, 4, 25};  
        int[] lastIP = {40, 8, 48, 16, 56, 24, 64, 32, 39, 7, 47, 15, 55, 23, 63, 31, 38, 6, 46, 14, 54, 22, 62, 30, 37, 5, 45, 13, 53, 21, 61, 29, 36, 4, 44, 12, 52, 20, 60, 28, 35, 3, 43, 11, 51, 19, 59, 27, 34, 2, 42, 10, 50, 18, 58, 26, 33, 1, 41, 9, 49, 17, 57, 25};

        string initialBinary = "";
        string[] left = new string[17];
        string[] right = new string[17];
        string[] keys = new string[17];
        
        int blocksCount = 0;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 8)
            {
                MessageBox.Show("Введите ключ длиной 8 символов!");
            }
            byte[] ba = Encoding.Default.GetBytes(richTextBox1.Text);
            var hexstring = BitConverter.ToString(ba);

            hexstring = hexstring.Replace("-", "");
            string initialString = hexstring;
            bool isNormal = false;
            if (initialString.Length % 8 != 0)
            {
                MessageBox.Show("Введите строку кратную на 8");
            }
            else
            {
                blocksCount = initialString.Length/8;
                initialBinary = (HexStringToBinary(initialString));
                
                    textBox2.Text = "Битовый формат: " + initialBinary;
                    textBox2.Text += "\r\n" + "HEX Формат: " + initialString;
                isNormal = true;
            }

            if (isNormal)
            {
                string[] blocks = new string[initialBinary.Length / 64];
                blocks = BinaryToBlocks(initialBinary); // Конвертирование на 64 битовые блоки
                int blocksCount = blocks.Length;// Количество блоков
                string encoded = "";
                string symboleEncoded = "";
                for (int i = 0; i < blocksCount; i++)
                {
                    blocks[i] = firstIP(blocks[i]);
                    left[0] = blocks[i].Substring(0, 32);
                    right[0] = blocks[i].Substring(32, 32);
                    string initialKey = textBox1.Text;
                    byte[] key = Encoding.Default.GetBytes(initialKey);
                    var hexKey = BitConverter.ToString(key);
                    hexKey = hexKey.Replace("-", "");
                    string BinaryKey = HexStringToBinary(hexKey);
                    string C = Cipping(BinaryKey);
                    string D = Dipping(BinaryKey);
                    makeKeysToRounds(C, D); //Создание ключей для раундов

                    //rounds
                    for (int j = 1; j <= 16; j++)
                    {
                        left[j] = right[j - 1];
                        right[j] = XOR(left[j - 1], func(epped(right[j - 1]), keys[j]));
                    }
                    string L16R16 = String.Concat(right[16], left[16]);
                    string encodedBlock = last_ipping(L16R16);
                    encoded += (Convert.ToUInt64(encodedBlock, 2).ToString("X"));
                    symboleEncoded += BinaryToString(encodedBlock);
                }
                richTextBox4.Text = encoded;
                richTextBox3.Text = "\r\nБинарный формат: " + HexStringToBinary(encoded);
                richTextBox3.Text += "\n\nСимвольный формат: " + symboleEncoded;
            }
        }

        public string sanitize(string item)
        {
            if (item.Length < 8)
            {
                while (item.Length < 8)
                {
                    item = '0' + item;
                }
                return item;
            }
            return item;
        }

        public string StringToBinary(string initialString)
        {
            byte[] initialStringInBytes = System.Text.Encoding.UTF8.GetBytes(initialString);
            initialString = "";
            foreach (var item in initialStringInBytes)
            {
                initialString += sanitize(Convert.ToString(item, 2));
            }
            return initialString;
        }

        public string firstIP(string initialBinary)
        {
            char[] ipped = new char[64];
            int position = 0;
            
            for (int i = 0; i <= 63; i++)
            {
                position = ip[i]-1;
                ipped[i] = initialBinary[position];
            }
            string ippedBinary = new string(ipped);
            return ippedBinary.ToString();
        }

        public string Cipping(string C)
        {
            string eppedC = "";
            int position = 0;
            for (int i = 0; i < 28; i++)
            {
                position = cIP[i] - 1;
                eppedC += C[position];
            }
            return eppedC;
        }

        public string Dipping(string D)
        {
            string eppedD = "";
            int position = 0;
            for (int i = 0; i < 28; i++)
            {
                position = dIP[i] - 1;
                eppedD += D[position];
            }
            return eppedD;
        }

        public string CPing(string CP) //сжатие и расширение ключа раунда
        {
            string CPed = "";
            int position = 0;
            for (int i = 0; i < 48; i++)
            {
                position = CPp[i] - 1;
                CPed += CP[position];
            }
            return CPed;
        }

        public string epped(string init) //Расширение блока
        {
            char[] epped = new char[48];
            int position = 0;
            for (int i = 0; i < 48; i++)
			{
			    position = EP[i] - 1;
                epped[i] = init[position];
			}
            string eppedBinary = new string(epped);
            return eppedBinary.ToString();
        }

        public string BinaryToString(string data)
        { 
            List<int> byteList = new List<int>();
            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            int[] charList = byteList.ToArray();
            string result = "";
            for (int i = 0; i < data.Length/8; i++)
            {
                result += (char)charList[i];
            }
            
            return result;
            
        }

        public string[] BinaryToBlocks(string init)
        {
            string[] blocks = new string[init.Length / 64];
            for (int i = 0; i < init.Length/64; i++)
            {
                blocks[i] = init.Substring(i * 64, 64);
            }
            return blocks;
        }

        public void makeKeysToRounds(string C, string D)
        {
            for (int i = 1; i < 17; i++)
            {
                if (i == 1 || i == 2 || i == 9 || i == 16)
                {
                    C = shiftLeft1(C);
                    D = shiftLeft1(D);
                }
                else
                {
                    C = shiftLeft2(C);
                    D = shiftLeft2(D);
                }

                keys[i] = CPing(C+D);
            }
        }

        public string shiftLeft1(string init)
        {
            string temp = "";
            string key = init[0].ToString();
            for (int i = 1; i < init.Length; i++)
            {
                temp += init[i];
            }
            temp += key;
            return temp;
        }

        public string shiftLeft2(string init)
        {
            string temp = "";
            string key = init[0].ToString() + init[1].ToString();
            for (int i = 2; i < init.Length; i++)
            {
                temp += init[i];
            }
            temp += key;
            return temp;
        }

        public string XOR(string first, string second)
        {
            string result = "";
            for (int i = 0; i < first.Length; i++)
            {
                bool a = Convert.ToBoolean(Convert.ToInt32(first[i].ToString()));
                bool b = Convert.ToBoolean(Convert.ToInt32(second[i].ToString()));

                if (a ^ b)
                {
                    result += "1";
                }
                else
                {
                    result += "0";
                }
            }
            return result;
        }

        public string HexStringToBinary(string hex)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in hex)
            {
                result.Append(hexCharacterToBinary[char.ToLower(c)]);
            }
            return result.ToString();
        }

        public string func(string sec1, string sec2)
        {
            string finalBoxes = "";
            string[] boxes = new string[8];
            string firstXOR = XOR(sec1, sec2);
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i] = firstXOR.Substring(i * 6, 6);
            }

            finalBoxes = FixBlocks(boxes);
            finalBoxes = fipping(finalBoxes);
            return finalBoxes;
        }

        public string FixBlocks(string[] box)
        {
            string resultString = "";
            int value = 0;
            for (int i = 0; i < 8; i++)
            {
                int row = Convert.ToInt32((box[i][0].ToString() + box[i][5].ToString()), 2);
                int column = Convert.ToInt32((box[i][1].ToString() + box[i][2].ToString() + box[i][3].ToString() + box[i][4].ToString()), 2);
                switch (i)
                {
                    case 0:
                        value = S1[row, column];
                        break;
                    case 1:
                        value = S2[row, column];
                        break;
                    case 2:
                        value = S3[row, column];
                        break;
                    case 3:
                        value = S4[row, column];
                        break;
                    case 4:
                        value = S5[row, column];
                        break;
                    case 5:
                        value = S6[row, column];
                        break;
                    case 6:
                        value = S7[row, column];
                        break;
                    case 7:
                        value = S8[row, column];
                        break;
                }

                resultString += Convert.ToString(value, 2).PadLeft(4, '0');
            }
            return resultString;
        }

        public string fipping(string result)
        {
            char[] epping = new char[32];
            int position = 0;
            for (int i = 0; i < 32; i++)
			{   
			    position = funcP[i] - 1;
                epping[i] = result[position];
			}
            string eppingBin = new string(epping);
            return eppingBin.ToString();
        }

        public string last_ipping(string last)
        {
            char[] ipping = new char[64];
            int position = 0;
            for (int i = 0; i < 64; i++)
            {
                position = lastIP[i] - 1;
                ipping[i] = last[position];
            }
            string ippingBin = new string(ipping);
            return ippingBin.ToString();
        }
        //Конец шифрования
        public void makeKeysArray(string keyText)
        {
            string initialKey = textBox1.Text;
            byte[] key = Encoding.Default.GetBytes(initialKey);
            var hexKey = BitConverter.ToString(key);
            hexKey = hexKey.Replace("-", "");
            string BinaryKey = HexStringToBinary(hexKey);
            string C = Cipping(BinaryKey);
            string D = Dipping(BinaryKey);
            makeKeysToRounds(C, D); //Создание ключей для раундов
        }

        private static readonly Dictionary<char, string> hexCharacterToBinary = new Dictionary<char, string> 
        {
                { '0', "0000" },
                { '1', "0001" },
                { '2', "0010" },
                { '3', "0011" },
                { '4', "0100" },
                { '5', "0101" },
                { '6', "0110" },
                { '7', "0111" },
                { '8', "1000" },
                { '9', "1001" },
                { 'a', "1010" },
                { 'b', "1011" },
                { 'c', "1100" },
                { 'd', "1101" },
                { 'e', "1110" },
                { 'f', "1111" },
                { 'A', "1010" },
                { 'B', "1011" },
                { 'C', "1100" },
                { 'D', "1101" },
                { 'E', "1110" },
                { 'F', "1111" },
        };

        private void button2_Click(object sender, EventArgs e)
        {
            

            if (textBox1.Text.Length != 8)//Change condition
            {
                MessageBox.Show("Введите ключ длиной 8 символов!");
            }
            else
            {
                makeKeysArray(textBox1.Text);//Создание ключа
                reverse(keys);
                string initialString = richTextBox4.Text;
                string initialBinary = HexStringToBinary(initialString);
                string[] blocks = new string[initialBinary.Length / 64];
                string decoded = "";
                blocks = BinaryToBlocks(initialBinary); // Конвертирование на 64 битовые блоки
                int blocksCount = blocks.Length;// Количество блоков
                for (int i = 0; i < blocksCount; i++)
                {
                    blocks[i] = firstIP(blocks[i]);
                    left[0] = blocks[i].Substring(0, 32);
                    right[0] = blocks[i].Substring(32, 32);

                    for (int j = 1; j <= 16; j++)
                    {
                        left[j] = right[j - 1];
                        right[j] = XOR(left[j - 1], func(epped(right[j - 1]), keys[j-1]));
                    }
                    string L16R16 = String.Concat(right[16], left[16]);
                    string encodedBlock = last_ipping(L16R16);
                    decoded += BinaryToString(encodedBlock);
                }
                MessageBox.Show("Расшифрованный текст: " + decoded);
                
            }
        }

        public void reverse(string[] massiv)
        {
            for (int i = 0; i < massiv.Length / 2; i++)
            {
                string tmp = massiv[i];
                massiv[i] = massiv[massiv.Length - i - 1];
                massiv[massiv.Length - i - 1] = tmp;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = richTextBox1.Text.Length.ToString();
            if (richTextBox1.Text.Length % 8 != 0)
            {
                label3.ForeColor = Color.Red;
            }
            else label3.ForeColor = Color.FromArgb(0, 0, 192);
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";
            richTextBox3.Text = "";
            richTextBox4.Text = "";
        }

        Timer t = new Timer();

        private void Form1_Load(object sender, EventArgs e)
        {
            t.Interval = 500;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            label4.Visible = !label4.Visible;
            label4.ForeColor = Color.FromArgb(255, 0, 0);
        }
    }
}
