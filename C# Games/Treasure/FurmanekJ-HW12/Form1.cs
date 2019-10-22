using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurmanekJ_HW12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void resultbar_TextChanged(object sender, EventArgs e)
        {
            resultbar.ScrollBars = ScrollBars.Vertical;
        }

        private void count_Click(object sender, EventArgs e)
        {
            List<char> alphabet = new List<char>();
            alphabet.Add('a');
            alphabet.Add('b');
            alphabet.Add('c');
            alphabet.Add('d');
            alphabet.Add('e');
            alphabet.Add('f');
            alphabet.Add('g');
            alphabet.Add('h');
            alphabet.Add('i');
            alphabet.Add('j');
            alphabet.Add('k');
            alphabet.Add('l');
            alphabet.Add('m');
            alphabet.Add('n');
            alphabet.Add('o');
            alphabet.Add('p');
            alphabet.Add('q');
            alphabet.Add('r');
            alphabet.Add('s');
            alphabet.Add('t');
            alphabet.Add('u');
            alphabet.Add('v');
            alphabet.Add('w');
            alphabet.Add('x');
            alphabet.Add('y');
            alphabet.Add('z');
            string lowered = textcounter.Text.ToLower();
            if (string.IsNullOrEmpty(lowered) == true)
            {
                resultbar.Text = "No Text Entered";
            }
            
            char[] word = lowered.ToCharArray();
            int[] numberof = new int[26] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
            for (int i = 0; i < word.Length; i++)
            {
                for(int j = 0; j < alphabet.Count; j++)
                {
                    if(word[i] == alphabet[j])
                    {
                        numberof[j] += 1;
                    }
                }
            }

            for(int k = 0; k < alphabet.Count; k++)
            {
                if(numberof[k] > 0)
                {
                    int part1 = numberof[k];
                    char part2 = alphabet[k];
                    string answer = "There are " + part1 + " " + part2 + "'s\r\n";
                    resultbar.Text += answer;
                }
            }
            
            
        }

        private void clear_Click(object sender, EventArgs e)
        {
            textcounter.Clear();
            resultbar.Clear();
        }

        private void textcounter_TextChanged(object sender, EventArgs e)
        {
            //string text = Console.ReadLine();
        }
    }
}
