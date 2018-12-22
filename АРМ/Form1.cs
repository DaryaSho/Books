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
using MetroFramework.Components;
using MetroFramework.Forms;

namespace АРМ
{
    public partial class Form1 : MetroForm
    {
      
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            UserContext db = new UserContext();
            var users = db.Users;

            foreach (User u in users)
            {
                if ((textBox1.Text == u.Login) && (textBox2.Text == u.Password))
                {
                   
                  //  pictureBox1.Refresh();
                    MessageBox.Show("Вы зашли в программу");
                   
                   var form2 = new Form2();
                    form2.ShowDialog();
                    form2.idUser = u.ID;
                    this.Show();

                }
            }

            //using (UserContext db = new UserContext())
            //{

            //    var users = db.Users;
            //    User user1 = new User
            //    {
            //        Login = textBox1.Text,
            //        Password = textBox2.Text,


            //    };
            //    foreach (User u in users)
            //    //             if ((textBox1.Text == u.Login) || (textBox2.Text == u.Password)) MessageBox.Show("Такой уже суўествует");
            //           }

            //    //    db.Users.Add(user1);
            //    //db.SaveChanges();
            //    //MessageBox.Show("Все сохранилось!");
            //}
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            using (UserContext db = new UserContext())
            {
                var users = db.Users;
               
                
               
               
                
                User user1 = new User
                {
                    Login = textBox3.Text,
                    Password = textBox4.Text,
                    Name = textBox5.Text,
                    Phone = textBox6.Text,
                    Adress = textBox7.Text,
                   


                };
                db.Users.Add(user1);
                db.SaveChanges();
                MessageBox.Show("Все сохранилось!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           // if (openFileDialog1.ShowDialog() == DialogResult.OK) pictureBox1.Image =new Bitmap( openFileDialog1.OpenFile());
            
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
    }




}

