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
            if (!Check(textBox5) || !Check(textBox6)) MessageBox.Show("Заполните поля");
            DialogResult dialogResult = MessageBox.Show("Добавить в таблицу жанров", "Добавление", MessageBoxButtons.YesNo);
            
            if ((Check(textBox5) && (CheckTable(textBox5.Text, 1) && Check(textBox6))))
            {
                if (dialogResult == DialogResult.Yes)
                {
                   
                    //do something 
                    Add(textBox5.Text, textBox6.Text, 1);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
                Add(textBox5.Text, textBox6.Text, 1);
                cleartextBox();


            }
           
            //using (UserContext db = new UserContext())
            //{


            //    Style style = new Style
            //    {
            //        StyleName = textBox5.Text,
            //        StyleDescrip = textBox6.Text,
            //    };

            //      db.Styles.Add(style);            
            //    db.SaveChanges();
            //    MessageBox.Show("Все сохранилось!");
            //}

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Добавить в таблицу категорий", "Добавление", MessageBoxButtons.YesNo);

            if ((Check(textBox5) && (CheckTable(textBox5.Text, 2) && Check(textBox6))))
            {
                if (dialogResult == DialogResult.Yes)
                {
                    //do something 
                    Add(textBox5.Text, textBox6.Text, 2);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
                Add(textBox5.Text, textBox6.Text, 2);
                cleartextBox();

            }
            if (!Check(textBox5) || !Check(textBox6)) MessageBox.Show("Заполните поля");
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
            DialogResult dialogResult = MessageBox.Show("Добавить в таблицу публикаций", "Добавление", MessageBoxButtons.YesNo);

            if ((Check(textBox5) && (CheckTable(textBox5.Text, 3) && Check(textBox6))))
            {
                if (dialogResult == DialogResult.Yes)
                {
                    //do something 
                    Add(textBox5.Text, textBox6.Text, 3);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
                Add(textBox5.Text, textBox6.Text, 3);
                cleartextBox();

            }
            if (!Check(textBox5) || !Check(textBox6)) MessageBox.Show("Заполните поля");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            using (UserContext db = new UserContext())
            {
                foreach (Publication publication in db.Publication)
                {

                    textBox7.Text += publication.PublicatName + "\r\n" + publication.PublicatDescrip + "\r\n";
                    textBox7.Text += "--------------------------------------------------------\r\n";

                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            using (UserContext db = new UserContext())
            {
                // ключ по которому будем удалять данные 


                // Вариант 1. Удаление записи. 
                foreach (Style style in db.Styles)
                {
                    if (style.StyleName == textBox5.Text)
                    {

                        db.Styles.Remove(style);
                        MessageBox.Show("Все удаилось!");
                    }


                }
                db.SaveChanges();


            }




        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "") textBox5.BackColor = Color.LightGray;
            else textBox5.BackColor = Color.White;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Clear();
            using (UserContext db = new UserContext())
            {

                foreach (Style style in db.Styles)
                {
                    auto.Add(style.StyleName.ToString());
                }

                foreach (Categor style in db.Categors)
                {
                    auto.Add(style.CategorName.ToString());
                }

                foreach (Publication style in db.Publication)
                {
                    auto.Add(style.PublicatName.ToString());
                }
            }

            textBox5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox5.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox5.AutoCompleteCustomSource = auto;


        }


        public void Add(string name, string descript, int index)
        {
            using (UserContext db = new UserContext())
            {
                if (index == 1) db.Styles.Add(new АРМ.Style { StyleName = name, StyleDescrip = descript });
                if (index == 2) db.Categors.Add(new Categor { CategorName = name, CategorDescrip = descript });
                if (index == 3) db.Publication.Add(new Publication { PublicatName = name, PublicatDescrip = descript });
                db.SaveChanges();
                MessageBox.Show("Добавление прошло успешно! с=");

            }



        }

        public bool Check(TextBox textBox)
        {
            bool result = false;
            if (textBox.Text != "") result = true;
            
            return result;
        }

        public bool CheckTable(string name, int index)
        {
            bool result = false;
            using (UserContext db = new UserContext())
            {

                int lengt = 0;

                if (index == 1)
                {

                    foreach (var element in db.Styles)
                    {
                        if (element.StyleName == name) lengt++;
                    }


                }
                if (index == 2)
                {

                    foreach (var element in db.Categors)
                    {
                        if (element.CategorName == name) lengt++;
                    }

                }
                if (index == 3)
                {
                    foreach (var element in db.Publication)
                    {
                        if (element.PublicatName == name) lengt++;
                    }

                }

                if (lengt == 0)
                    result = true;
                else MessageBox.Show("Такой элемент уже существует");



            }
            return result;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "") textBox6.BackColor = Color.LightGray;
            else textBox6.BackColor = Color.White;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                // ключ по которому будем удалять данные 


                // Вариант 1. Удаление записи. 
                foreach (Categor categor in db.Categors)
                {
                    if (categor.CategorName == textBox5.Text)
                    {

                        db.Categors.Remove(categor);
                        MessageBox.Show("Все удаилось!");
                    }


                }
                db.SaveChanges();
            }

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                // ключ по которому будем удалять данные 


                // Вариант 1. Удаление записи. 
                foreach (Publication categor in db.Publication)
                {
                    if (categor.PublicatName == textBox5.Text)
                    {

                        db.Publication.Remove(categor);
                        MessageBox.Show("Все удаилось!");
                    }


                }
                db.SaveChanges();
            }
        }

        public void cleartextBox()
        {
            textBox5.Text = "";
            textBox6.Text = "";

        }


    }


   // private void pictureBox11_Click(object sender, EventArgs e)
    

}
