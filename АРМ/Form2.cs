using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace АРМ
{
    public partial class Form2 : MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void metroScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            metroPanel1.Top = -metroScrollBar1.Value;
            
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {

                Style style = new Style
                {
                    StyleName = textBox5.Text,
                    StyleDescrip = textBox6.Text,
                };

                db.Styles.Add(style);            
                db.SaveChanges();
                MessageBox.Show("Все сохранилось!");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                Categor categor = new Categor
                {
                    CategorName = textBox5.Text,
                    CategorDescrip = textBox6.Text,
                };

                db.Categors.Add(categor);
                db.SaveChanges();
                MessageBox.Show("Все сохранилось!");
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            using (UserContext db = new UserContext())
            {
                foreach (Style style in db.Styles)
                {
                   
                    textBox7.Text += style.StyleName + "\r\n" + style.StyleDescrip + "\r\n";
                    textBox7.Text += "--------------------------------------------------------\r\n";

                }
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

            ///sd
            textBox7.Multiline = true;
            // Add vertical scroll bars to the TextBox control.
            textBox7.ScrollBars = ScrollBars.Vertical;
            // Allow the TAB key to be entered in the TextBox control.
            textBox7.AcceptsReturn = true;
            // Allow the TAB key to be entered in the TextBox control.
            textBox7.AcceptsTab = true;
            textBox7.SelectionStart = textBox7.Text.Length;
            textBox7.ScrollToCaret();
            textBox7.Refresh();


        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            using (UserContext db = new UserContext())
            {
                foreach (Categor categor in db.Categors)
                {

                    textBox7.Text += categor.CategorName + "\r\n" + categor.CategorDescrip + "\r\n";
                    textBox7.Text += "--------------------------------------------------------\r\n";

                }
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                Publicat publicat = new Publicat
                {
                    PublicatName = textBox5.Text,
                    PublicatDescrip = textBox6.Text,
                };

                db.Publicats.Add(publicat);
                db.SaveChanges();
                MessageBox.Show("Все сохранилось!");
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            using (UserContext db = new UserContext())
            {
                foreach (Publicat publicat in db.Publicats)
                {

                    textBox7.Text += publicat.PublicatName + "\r\n" + publicat.PublicatDescrip + "\r\n";
                    textBox7.Text += "--------------------------------------------------------\r\n";

                }
            }
        }
    }
}
