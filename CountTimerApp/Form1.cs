using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountTimerApp
{
    public partial class Form1 : Form
    { 
        System.Timers.Timer t;
        int h, m, s;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
        }

        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(()=>
                {
                    s += 1;
                    if (s == 60)
                    {
                        s = 0;
                        m += 1;

                    }
                    if (m == 60)
                    {
                        m = 0;
                        h += 1;

                    }
                    txtResult.Text = String.Format("{0}:{1}:{2}",h.ToString().PadLeft(2,'0'),m.ToString().PadLeft(2,'0'),s.ToString().PadLeft(2,'0'));


                }));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text)){
                textBox2.Visible = true;
                textBox2.Text = "No field path choosen";
                textBox2.ForeColor = Color.Red;
            }else{
            t.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            t.Stop();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Stop();
            Application.DoEvents();
        }


        OpenFileDialog ofd = new OpenFileDialog();
        private void button1_Click_1(object sender, EventArgs e)
        {
            ofd.Filter = "PHP|*.php";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
