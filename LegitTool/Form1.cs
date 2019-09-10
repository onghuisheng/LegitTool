using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Tools;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BinaryTool bTool = new BinaryTool();

            List<string> outputs = new List<string>();

            string[] sentences = SanitizeInputSentences();

            foreach (string sentence in sentences)
            {
                string[] keywords = sentence.Split(' ');

                /*
                 [0] Decimal <Input Type>
                 [1] 103 <Value>
                 [2] to <Redundant>
                 [3] Binary <Output Type>
                 */
                switch (keywords[0])
                {
                    case "decimal":
                        {
                            if (keywords[3] == "binary")
                            {
                                outputs.Add(bTool.DecimalToBinary(int.Parse(keywords[1])));
                            }
                        }
                        break;
                    case "binary":
                        {
                            if (keywords[3] == "decimal")
                            {
                                outputs.Add(bTool.BinaryToDecimal(keywords[1]).ToString());
                            }
                        }
                        break;
                    case "octal":
                        {
                            if (keywords[3] == "binary")
                            {
                                outputs.Add(bTool.OctalToBinary(int.Parse(keywords[1])));
                            }
                        }
                        break;
                    case "hexadecimal":
                        {
                            if (keywords[3] == "decimal")
                            {
                                outputs.Add(bTool.HexToDecimal(keywords[1]).ToString());
                            }
                            else if (keywords[3] == "binary")
                            {
                                outputs.Add(bTool.HexToBinary(keywords[1]).ToString());
                            }

                        }
                        break;
                }
            }

            txtOutput.Clear();

            int i = 0;
            foreach (string output in outputs)
            {
                i++;

                string finalOutput = output;

                // Remove leading zeroes
                if (chkTrimZeroes.Checked)
                    finalOutput = output.TrimStart('0');

                txtOutput.AppendText(string.Format("{0}{1}" + ((i != outputs.Count) ? "\r\n\r\n" : ""), (chkIndexedOutput.Checked) ? i.ToString() + " : " : "", finalOutput));
            }

            Console.WriteLine("Buffer Size: " + sentences.Length);
        }

        private string[] SanitizeInputSentences()
        {
            string preBuffer = Regex.Replace(txtInput.Text, "[^a-zA-Z0-9_. ]+", "", RegexOptions.Compiled);
            string[] buffer = preBuffer.Split(new string[] { txtDelimiter.Text }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < buffer.Length; i++)
            {
                string instruction = buffer[i];

                while (char.IsDigit(instruction.Last()))
                {
                    instruction = instruction.Remove(instruction.Length - 1, 1);
                }

                buffer[i] = instruction.ToLower().Trim();
            }

            return buffer;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkIndexedOutput_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
