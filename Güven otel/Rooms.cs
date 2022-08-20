using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Güven_otel
{
    public partial class Rooms : Form
    {
        public Rooms()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private SqlConnection con = Sql.con;
        private SqlCommand cmd;
        private SqlDataReader reader;
        private void RoomClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            byte id = byte.Parse(btn.Text);
            con.Open();
            cmd = new SqlCommand("select * from Rooms where roomid=@p1", con);
            cmd.Parameters.AddWithValue("@p1", id);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                new Room().show(id, (bool)reader["Full"], reader["ClientName"].ToString());
            }
            con.Close();
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            foreach (Control item in Controls)
            {
                if (item.Name=="button1"||item.Name=="button2"||item.Name=="panel1") continue;
                item.Click += RoomClick;
            }
        }
    }
}
