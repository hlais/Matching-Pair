using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchMakingGame
{
    public partial class Form1 : Form
    {
        Random m_random = new Random();

        List<string> m_icons = new List<string>()
        {
            "E", "E", "!", "!", ",", ",","G", "G",
            "j", "j", "x", "x", "q", "q","L","L"
        };

        Label m_firstClicked, m_secondClicked;

        public Form1()
        {
            InitializeComponent();
            AssigningIconsToSquare();
        }

        private void label_Click(object sender, EventArgs e)
        {
            //to prevent more then two clicks lets stop.
            if (m_firstClicked != null && m_secondClicked != null)
            {
                return;
            }
            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
            {
                return;
            }
            //if user clicked same icon twice, 
            if (clickedLabel.ForeColor == Color.Black)
            {
                return;
            }
            if (m_firstClicked == null)
            {
                m_firstClicked = clickedLabel;
                m_firstClicked.ForeColor = Color.Black;
                return;
            }
            m_secondClicked = clickedLabel;
            m_secondClicked.ForeColor = Color.Black;
            CheckForWinner();

            //check for matching icons
            if (m_firstClicked.Text == m_secondClicked.Text)
            {
                //clears vairables 
                m_firstClicked = null;
                m_secondClicked = null;
            }
            else 
            
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            m_firstClicked.ForeColor = m_firstClicked.BackColor;
            m_secondClicked.ForeColor = m_secondClicked.BackColor;

            m_firstClicked = null;
            m_secondClicked = null;

        }
        private void CheckForWinner()
        {
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                {
                    return;
                }
            }
            MessageBox.Show("You are very Smart. You Win!!");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void aboutAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by: Halim Lais \n Isolated Gamerz \n github.com/hlais");
        }

        private void AssigningIconsToSquare()
        {
            Label label;
            int randomNumber;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                {
                    label = (Label)tableLayoutPanel1.Controls[i];
                }
                else
                {
                    continue;
                }
                randomNumber = m_random.Next(0, m_icons.Count());
                label.Text = m_icons[randomNumber];

                //now to avoid to get double numbers. remove number for list

                m_icons.RemoveAt(randomNumber);
                    

            }
        }
    }
}
