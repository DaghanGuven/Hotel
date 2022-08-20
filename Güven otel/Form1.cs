using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Güven_otel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            while (true)
            {
                if (Opacity == 0) break;
                Opacity -= 0.1;
                Thread.Sleep(1);
            } // Make disappear the form.
            WindowState = FormWindowState.Minimized; // Minimize the form.
            Opacity = 1; // Make normal the form.
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Clear();
        }
        private SqlConnection con = Sql.con;
        private SqlCommand cmd;
        private SqlDataReader reader;
        private void Button3_clck2(object sender, EventArgs e)
        {
            
        }
        private void label3_login(object sender, EventArgs e)
        {
            label6.Visible = false;
            label5.Visible = false;
            textBox4.Visible = false;
            textBox3.Visible = false;
            button3.Text = "LOGIN";
            while (button3.Location.Y != 160)
            {
                button3.Location = new Point(button3.Location.X, button3.Location.Y - 2);
                Thread.Sleep(1);
            }
            while (label3.Location.Y != 219)
            {
                label3.Location = new Point(label3.Location.X, label3.Location.Y - 2);
                Thread.Sleep(1);
            }
            label3.Text = "Didn't register yet?\r\nRegister from here now!\r\n";
            while (label3.Location.X != 45)
            {
                label3.Location = new Point(label3.Location.X - 2, label3.Location.Y);
                Thread.Sleep(1);
            }
            while (Size != new Size(332, 280))
            {
                Size = new Size(332, Size.Height - 2);
                Thread.Sleep(1);
            }
            button3.Click -= Button3_clck2;
            button3.Click += button3_Click;
            button3.Click -= label3_login;
            label3.Click += label3_Click;
        }
        private void label3_Click(object sender, EventArgs e)
        {

            
            while (Size!=new Size(332,346))
            {
                Size = new Size(332, Size.Height + 2);
                Thread.Sleep(1);
            }
            while (label3.Location.Y!=287)
            {
                label3.Location = new Point(label3.Location.X, label3.Location.Y + 2);
                Thread.Sleep(1);
            }
            label3.Text = "Click here to\nlogin.";
            while (label3.Location.X != 85)
            {
                label3.Location = new Point(label3.Location.X+2, label3.Location.Y);
                Thread.Sleep(1);
            }
            while (button3.Location.Y != 222)
            {
                button3.Location = new Point(button3.Location.X, button3.Location.Y + 2);
                Thread.Sleep(1);
            }
            label6.Visible = true;
            label5.Visible = true;
            textBox4.Visible = true;
            textBox3.Visible = true;
            button3.Text = "REGISTER";
            button3.Click -= button3_Click;
            button3.Click += Button3_clck2;
            button3.Click -= label3_Click;
            label3.Click += label3_login;

        }
        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }
        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("select * from Clients where name=@p1 and passwd=@p2", con);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            reader = cmd.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
                Client.Name = textBox1.Text;
                Client.Passwd = textBox2.Text;
                Client.Gmail = reader["gmail"].ToString();
                Client.Phone = reader["phone"].ToString();
            }
            con.Close();
            if (count == 0)
            {
                new Error().Give("Username or password was incorrect.");
                return;
            }
            // new Error().Give("Name:" + Client.Name+"\nPassword:"+Client.Passwd+"\nGmail:"+Client.Gmail+"\nPhone:"+Client.Phone);
            new Homepage().Show();
        }
    }
}
