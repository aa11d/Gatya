using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filepath = "..\\..\\..\\" + textBox1.Text;
            //string fileUt2 = @"..\..\..\" + textBox1.Text;

            StreamReader sr = new StreamReader(filepath);
            List<string> sorok = new List<string>();
            string sor = sr.ReadLine();
            while (sor !=null)
            {
                if (sor.Trim() != "")
                {
                    sorok.Add(sor.Trim());
                }
                sor = sr.ReadLine();
            }

            sr.Close();
            kiiras.Lines = sorok.ToArray();

            string[] nev = new string[sorok.Count];
            string[] datum = new string[sorok.Count];
            string[] varos = new string[sorok.Count];
            int[] pontszam = new int[sorok.Count];

            for (int i = 0; i < sorok.Count; i++)
            {
                string[] darabolva = sorok[i].Split(';');
                nev[i] = darabolva[0];
                datum[i] = darabolva[1];
                varos[i] = darabolva[2];
                pontszam[i] = int.Parse(darabolva[3]);
            }

            int maxPont = pontszam.Max();
            int kivolt = Array.IndexOf(pontszam, maxPont);

            string sor1 = "legnagyobb ponszám: " + maxPont;
            kiiras.AppendText(sor1);
            string sor2 = "A legtöb pontot adta: " + nev[kivolt] + " aki itt lakik: " + varos[kivolt];
            kiiras.AppendText(sor2);
        }
    }
}
