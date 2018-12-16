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
               


            }
           
           
           //this.dataGridView1.Columns["UnitPrice"].DefaultCellStyle.Format = "c";
            addCombobox();
            //ScrollAll();
            showBooks();


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
            comboBox3.Items.Clear();
            comboBox2.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            using (UserContext db = new UserContext())
            {

                foreach (Style style in db.Styles)
                {
                    comboBox2.Items.Add(style.StyleName.ToString());
                    comboBox5.Items.Add(style.StyleName.ToString());
                }

                foreach (Categor style in db.Categors)
                {
                    comboBox3.Items.Add(style.CategorName.ToString());
                    comboBox6.Items.Add(style.CategorName.ToString());
                }

                foreach (Publication style in db.Publication)
                {
                    comboBox1.Items.Add(style.PublicatName.ToString());
                    comboBox4.Items.Add(style.PublicatName.ToString());
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
                            PublicationId = bPub(comboBox1.Text),
                            StyleId = bstyl(comboBox2.Text),
                            CategorId =bCat(comboBox3.Text),
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

        public int bCat(string name)
        {
            int index = 1;
            using (UserContext db = new UserContext())
            {
                
                foreach (Categor element in db.Categors)
                {
                    if (element.CategorName == name) index = element.Id;
                }          
            }
            return index;
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

        public int bPub(string name)
        {
            using (UserContext db = new UserContext())
            {
                int index = 1;
                foreach (Publication element in db.Publication)
                {
                    if (element.PublicatName == name) index = element.Id;
                }
                return index;
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


        public int bstyl(string name)
        {
            using (UserContext db = new UserContext())
            {
                int index = 1;
                foreach (Style element in db.Styles)
                {
                    if (element.StyleName == name) index = element.Id;
                }
                return index;
            }
        }




        public int iBooks(string name, string avtor, int pubyear, int publiicat)
        {
            int index = 0;
            using (UserContext db = new UserContext())
            {
              
                foreach (Books element in db.Books)
                {
                    if ((element.BookName== name) && (element.BookAvtor==avtor) && (element.PublicationId==publiicat) && (element.PublicatiomYear==pubyear)) index = element.Id;
                }
               
            }
            return index;
        }

        public int CaunBook(int id)
        {
            int index = 0;
            using (UserContext db = new UserContext())
            {

                foreach (Stock element in db.Stocks)
                {
                    if (element.BookId ==id )  index = element.BookCount;
                }
                return index;
            }
            return index;
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

  


        

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить из таблицы Книги " , "Удаление", MessageBoxButtons.YesNo);
            
          
            
                using (UserContext db = new UserContext())
                {
                    if (dialogResult == DialogResult.Yes)
                    {

                        foreach (Books books in db.Books)
                        {
                            if ((books.BookName == textBox1.Text)&&(books.BookAvtor==textBox2.Text)&&(pubB(books.PublicationId)==comboBox1.Text))
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

       

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            showBooks();         
        }

        public void showBooks()
        {
            using (UserContext db = new UserContext())
            {
                foreach (Books books in db.Books)
                {
                    int i = dataGridView2.Rows.Add();
                     dataGridView2.Rows[i].Cells[0].Value = books.BookName;
                     dataGridView2.Rows[i].Cells[1].Value = books.BookAvtor;
                     dataGridView2.Rows[i].Cells[2].Value = books.BookDescrip;
                     dataGridView2.Rows[i].Cells[3].Value = pubB(books.PublicationId);
                     dataGridView2.Rows[i].Cells[4].Value = stylB(books.StyleId);
                     dataGridView2.Rows[i].Cells[5].Value = books.PublicatiomYear.ToString();
                     dataGridView2.Rows[i].Cells[6].Value = catB(books.CategorId);
                     dataGridView2.Rows[i].Cells[7].Value = books.BookPrice.ToString();
                     dataGridView2.Rows[i].Cells[8].Value = new Bitmap(books.BookPhoto);
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

         
            textBox1.Text = Convert.ToString( dataGridView2.CurrentRow.Cells[0].Value);
            textBox2.Text = Convert.ToString(dataGridView2.CurrentRow.Cells[1].Value);
            textBox3.Text = Convert.ToString(dataGridView2.CurrentRow.Cells[2].Value);
            textBox8.Text = Convert.ToString(dataGridView2.CurrentRow.Cells[7].Value);
            textBox4.Text = Convert.ToString(dataGridView2.CurrentRow.Cells[5].Value);
            comboBox1.Text = Convert.ToString(dataGridView2.CurrentRow.Cells[3].Value);
            comboBox2.Text = Convert.ToString(dataGridView2.CurrentRow.Cells[4].Value);
            comboBox3.Text = Convert.ToString(dataGridView2.CurrentRow.Cells[6].Value);
            pictureBox13.Image =(Image)dataGridView2.CurrentRow.Cells[8].Value;
    }

        private void metroLabel18_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text == "") textBox5.BackColor = Color.LightGray;
            else textBox10.BackColor = Color.White;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Clear();
            using (UserContext db = new UserContext())
            {

                foreach (Books books in db.Books)
                {
                    auto.Add(books.BookName);
                    auto.Add(books.BookAvtor);
                }

               
            }

            textBox10.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox10.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox10.AutoCompleteCustomSource = auto;
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                dataGridView2.Rows.Clear();
                
                foreach (Books books in db.Books)
                {
                    if (books.BookName == textBox10.Text || books.BookAvtor == textBox10.Text)
                    {
                        int i = dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells[0].Value = books.BookName;
                        dataGridView2.Rows[i].Cells[1].Value = books.BookAvtor;
                        dataGridView2.Rows[i].Cells[2].Value = books.BookDescrip;
                        dataGridView2.Rows[i].Cells[3].Value = pubB(books.PublicationId);
                        dataGridView2.Rows[i].Cells[4].Value = stylB(books.StyleId);
                        dataGridView2.Rows[i].Cells[5].Value = books.PublicatiomYear.ToString();
                        dataGridView2.Rows[i].Cells[6].Value = catB(books.CategorId);
                        dataGridView2.Rows[i].Cells[7].Value = books.BookPrice.ToString();
                        dataGridView2.Rows[i].Cells[8].Value = new Bitmap(books.BookPhoto);
                    }
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Multiline = true;
            textBox3.ScrollBars = ScrollBars.Vertical;
            textBox3.AcceptsReturn = true;
            textBox3.AcceptsTab = true;
            textBox3.SelectionStart = textBox3.Text.Length;
            textBox3.ScrollToCaret();
            textBox3.Refresh();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            showBookComboBox(1);
        }

        public void showBookComboBox(int index)
        {
            using (UserContext db = new UserContext())
            {
                dataGridView2.Rows.Clear();

                foreach (Books books in db.Books)
                {
                    if (index == 1)
                    {
                        if (books.PublicationId== bPub(comboBox4.Text))
                        {
                            int i = dataGridView2.Rows.Add();
                            dataGridView2.Rows[i].Cells[0].Value = books.BookName;
                            dataGridView2.Rows[i].Cells[1].Value = books.BookAvtor;
                            dataGridView2.Rows[i].Cells[2].Value = books.BookDescrip;
                            dataGridView2.Rows[i].Cells[3].Value = pubB(books.PublicationId);
                            dataGridView2.Rows[i].Cells[4].Value = stylB(books.StyleId);
                            dataGridView2.Rows[i].Cells[5].Value = books.PublicatiomYear.ToString();
                            dataGridView2.Rows[i].Cells[6].Value = catB(books.CategorId);
                            dataGridView2.Rows[i].Cells[7].Value = books.BookPrice.ToString();
                            dataGridView2.Rows[i].Cells[8].Value = new Bitmap(books.BookPhoto);
                        }
                    }

                    if (index == 2)
                    {
                        if (books.StyleId == bstyl(comboBox5.Text))
                        {
                            int i = dataGridView2.Rows.Add();
                            dataGridView2.Rows[i].Cells[0].Value = books.BookName;
                            dataGridView2.Rows[i].Cells[1].Value = books.BookAvtor;
                            dataGridView2.Rows[i].Cells[2].Value = books.BookDescrip;
                            dataGridView2.Rows[i].Cells[3].Value = pubB(books.PublicationId);
                            dataGridView2.Rows[i].Cells[4].Value = stylB(books.StyleId);
                            dataGridView2.Rows[i].Cells[5].Value = books.PublicatiomYear.ToString();
                            dataGridView2.Rows[i].Cells[6].Value = catB(books.CategorId);
                            dataGridView2.Rows[i].Cells[7].Value = books.BookPrice.ToString();
                            dataGridView2.Rows[i].Cells[8].Value = new Bitmap(books.BookPhoto);
                        }
                    }

                    if (index == 3)
                    {
                        if (books.CategorId == bCat(comboBox6.Text))
                        {
                            int i = dataGridView2.Rows.Add();
                            dataGridView2.Rows[i].Cells[0].Value = books.BookName;
                            dataGridView2.Rows[i].Cells[1].Value = books.BookAvtor;
                            dataGridView2.Rows[i].Cells[2].Value = books.BookDescrip;
                            dataGridView2.Rows[i].Cells[3].Value = pubB(books.PublicationId);
                            dataGridView2.Rows[i].Cells[4].Value = stylB(books.StyleId);
                            dataGridView2.Rows[i].Cells[5].Value = books.PublicatiomYear.ToString();
                            dataGridView2.Rows[i].Cells[6].Value = catB(books.CategorId);
                            dataGridView2.Rows[i].Cells[7].Value = books.BookPrice.ToString();
                            dataGridView2.Rows[i].Cells[8].Value = new Bitmap(books.BookPhoto);
                        }
                    }

                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            showBookComboBox(2);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            showBookComboBox(3);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Изменить  книгу ", "Изменение", MessageBoxButtons.YesNo);
            if (!Check(textBox1) || !Check(textBox2) || !Check(textBox3) || !Check(textBox4) || !Check(textBox8)
                || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "") MessageBox.Show("Заполните поля");

            if (Check(textBox1) && (CheckTable(textBox1.Text, 4) && Check(textBox2) && Check(textBox3) && Check(textBox4) && Check(textBox8)))
            {
                if (dialogResult == DialogResult.Yes)
                {
                    using (UserContext db = new UserContext())
                    {
                        foreach (Books books in db.Books)
                        {
                            if ((books.BookName == label4.Text) && (books.BookAvtor == label5.Text) && (pubB(books.PublicationId) == label9.Text))
                            {
                                db.Books.Remove(books);
                              
                            }

                        }
                        db.Books.Add(new Books
                        {
                            BookName = textBox1.Text,
                            BookAvtor = textBox2.Text,
                            BookDescrip = textBox3.Text,
                            BookPrice = Convert.ToInt32(textBox8.Text),
                            PublicatiomYear = Convert.ToInt32(textBox4.Text),
                            PublicationId = bPub(comboBox1.Text),
                            StyleId = bstyl(comboBox2.Text),
                            CategorId = bCat(comboBox3.Text),
                            BookPhoto = put,
                        });
                        db.SaveChanges();


                    }
                    MessageBox.Show("Изменение прошло успешно! с=");
                }
                else MessageBox.Show("Изменение отменено.");

                cleartextBox();


            }
        }

      

       

     

      

      

       

        private void pictureBox13_MouseHover(object sender, EventArgs e)
        {
            metroToolTip1.SetToolTip(pictureBox13, "Нажмите на картинку, чтобы добавить картинку для книги");
        }

        private void pictureBox14_MouseHover(object sender, EventArgs e)
        {
            metroToolTip1.SetToolTip(pictureBox14, "Добавить книгу");
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            label26.Text = textBox1.Text;
            label27.Text = textBox2.Text;
            textBox18.Text = textBox3.Text;
            label29.Text = comboBox1.Text;
            label30.Text = comboBox2.Text;
            label31.Text = comboBox3.Text;
            panel1.Visible = true;
            panel1.Dock = DockStyle.Fill;
            pictureBox28.Image = pictureBox13.Image;
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            textBox18.Multiline = true;
            textBox18.ScrollBars = ScrollBars.Vertical;
            textBox18.AcceptsReturn = true;
            textBox18.AcceptsTab = true;
            textBox18.SelectionStart = textBox18.Text.Length;
            textBox18.ScrollToCaret();
            textBox18.Refresh();
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            
            DialogResult dialogResult = MessageBox.Show("Добавить книгу в склад", "Добавление", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                
                  
              
                if (Check(textBox15) && Check(textBox1) && Check(textBox2))
                {

                    if (Convert.ToInt32(textBox15.Text) > 0)
                    {
                        using (UserContext db = new UserContext())
                        {

                            db.Stocks.Add(new Stock()
                            {
                                BookId = iBooks(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox4.Text),
                                    bPub(comboBox1.Text)),
                                BookCount = Convert.ToInt32(textBox15.Text),
                                DataBook = dateTimePicker2.Value
                            });
                            db.SaveChanges();
                            MessageBox.Show("Добавление прошло успешно");
                        }
                    }
                    else MessageBox.Show("ОШИБКА! Неправильно введено количество!");

                }
                else MessageBox.Show("ОШИБКА! Не выбрана книга или неправильно введено количество!");
            }

            if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Вы отменили добавление");
            }


        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Добавить книгу в потери", "Добавление", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (Check(textBox16) && Check(textBox1) && Check(textBox2)&& (Check(textBox17)))
                {

                    if (Convert.ToInt32(textBox17.Text) > 0)
                    {
                        using (UserContext db = new UserContext())
                        {
                            int caunt = 0;
                            foreach (Stock stock in db.Stocks)
                            {
                                if (stock.BookId == iBooks(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox4.Text), bPub(comboBox1.Text)))
                                caunt += stock.BookCount;
                                db.Stocks.Remove(stock);
                            }

                            if( caunt - Convert.ToInt32(textBox17.Text) >= 0){
                                db.Losses.Add(new Losses()
                                {
                                    BookId = iBooks(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox4.Text),
                                        bPub(comboBox1.Text)),
                                    BookCount = Convert.ToInt32(textBox17.Text),
                                    Why = textBox16.Text
                                });
                                db.Stocks.Add(new Stock()
                                {
                                    BookId = iBooks(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox4.Text), bPub(comboBox1.Text)),
                                    BookCount = caunt - Convert.ToInt32(textBox17.Text), 
                                    DataBook =  DateTime.Now
                                });
                                db.SaveChanges();
                                MessageBox.Show("Добавление прошло успешно");
                            }
                            else MessageBox.Show("Нет такого количество на складе!");
                        }
                    }
                    else MessageBox.Show("ОШИБКА! Неправильно введено количество!");

                }
                else MessageBox.Show("ОШИБКА! Не выбрана книга или не заполнены поля!");
            }

            if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Вы отменили добавление");
            }
        }
    }
}

   // private void pictureBox11_Click(object sender, EventArgs e)
    


