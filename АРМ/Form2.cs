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
        int idbook =0;
        string put = @"G:\курсовая Даши\бд\АРМ\АРМ\Resources\notebook-5.png";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
            using (UserContext db = new UserContext())
            {
                Books books = db.Books.First();
                idbook= books.Id;
                dataGridView1.DataSource = db.Users.Local.ToList();


            }
           
           
           this.dataGridView1.Columns["UnitPrice"].DefaultCellStyle.Format = "c";
            addCombobox();
            ScrollAll();


        }

        private void metroScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

          

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            addDialog(1, "Жанры");

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            addDialog(2, "Категории");

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
            addDialog(3, "Издательство");
            // MessageBox.Show("Добавление прошло успешно! с=");

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
            remove(1, "Жанры", textBox5.Text);

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
                if (index == 4)
                {
                    foreach (var element in db.Books)
                    {
                        if (element.BookName == name) lengt++;
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
            remove(2, "Категории", textBox5.Text);

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            remove(3, "Издательство", textBox5.Text);
        }

        public void cleartextBox()
        {
            textBox5.Text = "";
            textBox6.Text = "";

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            insertTable(1, "Жанров", textBox5.Text);
        }

        public void removeTable(int Index, string name)
        {
            using (UserContext db = new UserContext())
            {

                if (Index == 1)
                {

                    foreach (Style style in db.Styles)
                    {
                        if (style.StyleName == name)
                        {
                            db.Styles.Remove(style);

                        }

                    }
                }
                if (Index == 2)
                {
                    foreach (Categor categor in db.Categors)
                    {
                        if (categor.CategorName == name)
                        {
                            db.Categors.Remove(categor);

                        }

                    }
                }

                if (Index == 3)
                {
                    foreach (Publication publication in db.Publication)
                    {
                        if (publication.PublicatName == name)
                        {
                            db.Publication.Remove(publication);

                        }

                    }

                }

                db.SaveChanges();

            }
        }


        public void remove(int index, string name, string text)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить из таблицы " + name, "Удаление", MessageBoxButtons.YesNo);
            if (!Check(textBox5)) MessageBox.Show("Заполните название " + name);
            else
            {
                using (UserContext db = new UserContext())
                {
                    if (dialogResult == DialogResult.Yes)
                    {
                        removeTable(index, text);
                        MessageBox.Show("Удаление прошло успешно");

                    }

                    db.SaveChanges();


                }


            }
        }
        public void addDialog(int index, string name)
        {
            DialogResult dialogResult = MessageBox.Show("Добавить в таблицу " + name, "Добавление", MessageBoxButtons.YesNo);
            if (!Check(textBox5) || !Check(textBox6)) MessageBox.Show("Заполните поля");

            if ((Check(textBox5) && (CheckTable(textBox5.Text, index) && Check(textBox6))))
            {
                if (dialogResult == DialogResult.Yes)
                {
                    Add(textBox5.Text, textBox6.Text, index);
                    MessageBox.Show("Добавление прошло успешно! с=");
                }

                cleartextBox();


            }
        }

        public void insertTable(int index, string name, string text)
        {
            DialogResult dialogResult = MessageBox.Show("Изменить запись из таблице " + name, "Изменение", MessageBoxButtons.YesNo);
            if (!Check(textBox5)) MessageBox.Show("Заполните название " + name);
            else
            {
                using (UserContext db = new UserContext())
                {
                    if (dialogResult == DialogResult.Yes)
                    {
                        removeTable(index, text);
                        Add(textBox5.Text, textBox6.Text, index);
                        MessageBox.Show("Изменение прошло успешно");

                    }

                    db.SaveChanges();


                }


            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            insertTable(2, "Категорий", textBox5.Text);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            insertTable(3, "Издательст", textBox5.Text);
        }

        public void addCombobox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            using (UserContext db = new UserContext())
            {

                foreach (Style style in db.Styles)
                {
                    comboBox2.Items.Add(style.StyleName.ToString());
                }

                foreach (Categor style in db.Categors)
                {
                    comboBox3.Items.Add(style.CategorName.ToString());
                }

                foreach (Publication style in db.Publication)
                {
                    comboBox1.Items.Add(style.PublicatName.ToString());
                }
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Добавить новую книгу ", "Добавление", MessageBoxButtons.YesNo);
            if (!Check(textBox1) || !Check(textBox2) || !Check(textBox3) || !Check(textBox4) || !Check(textBox8)
                || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "") MessageBox.Show("Заполните поля");

            if (Check(textBox1) && (CheckTable(textBox1.Text, 4) && Check(textBox2) && Check(textBox3) && Check(textBox4) && Check(textBox8)))
            {
                if (dialogResult == DialogResult.Yes)
                {
                    using (UserContext db = new UserContext())
                    {
                        db.Books.Add(new Books
                        {
                            BookName = textBox1.Text,
                            BookAvtor = textBox2.Text,
                            BookDescrip = textBox3.Text,
                            BookPrice = Convert.ToInt32(textBox8.Text),
                            PublicatiomYear = Convert.ToInt32(textBox4.Text),
                            PublicationId = comboBox1.FindString(comboBox1.Text) + 1,
                            StyleId = comboBox2.FindString(comboBox2.Text) + 1,
                            CategorId = comboBox3.FindString(comboBox3.Text) + 1,
                            BookPhoto = put,
                        });
                        db.SaveChanges();


                    }
                    MessageBox.Show("Добавление прошло успешно! с=");
                }
                else MessageBox.Show("Добавление отменено.");

                cleartextBox();


            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
         
  

            //  write();
        }

        public string catB(int index) {
            using (UserContext db = new UserContext())
            {
                string name = "---";
                foreach (Categor element in db.Categors)
                {
                    if (element.Id == index) name = element.CategorName;
                }

                return name;
            }
        }


        public string pubB(int index)
        {
            using (UserContext db = new UserContext())
            {
                string name = "---";
                foreach (Publication element in db.Publication)
                {
                    if (element.Id == index) name = element.PublicatName;
                }

                return name;
            }
        }



        public string stylB(int index)
        {
            using (UserContext db = new UserContext())
            {
                string name = "---";
                foreach (Style element in db.Styles)
                {
                    if (element.Id == index) name = element.StyleName;
                }

                return name;
            }
        }









        public void write()
        {


        }
        public void writeBooks(string bookName, string bookAvtor, string bookPhoto, string bookDescrip, int Yaer, int bookPrise, string bookStyle, string bookCategor, string bookPublic)
        {


            // metroPanel1.Controls.Add(groupBox1);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                put = openFileDialog1.FileName;
                pictureBox13.Image = new Bitmap(put);

            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox7.Multiline = true;         
            textBox7.ScrollBars = ScrollBars.Vertical;           
            textBox7.AcceptsReturn = true;
            textBox7.AcceptsTab = true;
            textBox7.SelectionStart = textBox7.Text.Length;
            textBox7.ScrollToCaret();
            textBox7.Refresh();
        }

        private void metroScrollBar1_Scroll_1(object sender, ScrollEventArgs e)
        {
            ScrollAll();
           
           
        }


        public void ScrollAll()
        {
            using (UserContext db = new UserContext())
            {
                Books books = new Books();
                if (idbook > db.Books.Count()) {
                    books = db.Books.First();
                    idbook = books.Id;
                }
                //books = db.Books.Find();
                 books = db.Books.Find(idbook+1);
                    {
                        pictureBox18.Image = new Bitmap(books.BookPhoto);
                        label4.Text = books.BookName;
                        label5.Text = books.BookAvtor;
                        label8.Text = stylB(books.StyleId);
                        label9.Text = pubB(books.PublicationId);
                        label13.Text = books.PublicatiomYear.ToString();
                        label11.Text = catB(books.CategorId);
                        label15.Text = books.BookPrice.ToString();
                        textBox9.Text = books.BookDescrip;
                        


                    }
               

                idbook++;
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить из таблицы Книги " + label4.Text, "Удаление", MessageBoxButtons.YesNo);
            
          
            
                using (UserContext db = new UserContext())
                {
                    if (dialogResult == DialogResult.Yes)
                    {

                        foreach (Books books in db.Books)
                        {
                            if ((books.BookName == label4.Text)&&(books.BookAvtor==label5.Text)&&(pubB(books.PublicationId)==label9.Text))
                            {
                                db.Books.Remove(books);
                                MessageBox.Show("Удаление прошло успешно");
                            }

                        }
                       

                    }
                    if (dialogResult == DialogResult.No)
                    {

                        
                        MessageBox.Show("Удаление отменено");

                    }
                    db.SaveChanges();


                }


           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void pictureBox17_Click_1(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (var VARIABLE in COLLECTION)
                {
                    
                }
                this.dataGridView1.Columns["UnitPrice"].DefaultCellStyle.Format = "c";
            }
        }
    }
}
   // private void pictureBox11_Click(object sender, EventArgs e)
    


