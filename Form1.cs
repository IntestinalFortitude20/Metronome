using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Metronome
{
    public partial class Form1 : Form
    {
        SoundPlayer metronomeClick = new SoundPlayer(Properties.Resources.MetronomeClick);

        int tempo;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tempo = trackBar1.Value = 120;

            lblTempo.Text = tempo.ToString();
            
            timer1.Interval = 60000 / tempo;

            lblInterval.Text = timer1.Interval.ToString();
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled) timer1.Enabled = false;
            else timer1.Enabled = true; 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            metronomeClick.Play();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            tempo = trackBar1.Value;

            lblTempo.Text = tempo.ToString();

            timer1.Interval = 60000 / tempo;

            lblInterval.Text = timer1.Interval.ToString();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            trackBar1.Value += 1;

            trackBar1_Scroll(sender, e);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            trackBar1.Value -= 1;

            trackBar1_Scroll(sender, e);
        }
    }
}
