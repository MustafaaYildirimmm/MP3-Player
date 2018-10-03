using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mp3Player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnAddMusic_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();
            for (int i = 0; i < openFileDialog1.SafeFileNames.Length; i++)
            {
                lstMusic.Items.Add(openFileDialog1.SafeFileNames[i].ToString());

                lstYol.Items.Add(openFileDialog1.FileNames[i].ToString());
            }
        }

        private void lstMusic_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstYol.SelectedIndex = lstMusic.SelectedIndex;
            axWindowsMediaPlayer1.URL = lstYol.SelectedIndex.ToString();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void lstYol_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstYol.SelectedIndex = lstMusic.SelectedIndex;
            axWindowsMediaPlayer1.URL = lstYol.SelectedIndex.ToString();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is ListBox)
                {
                    ListBox itm = (ListBox)item;
                    itm.Items.Clear();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Value = axWindowsMediaPlayer1.settings.volume;
        }
    }
}
