using System;
using System.Windows.Forms;

namespace Güven_otel
{
    public partial class Room : Form
    {
        public Room()
        {
            InitializeComponent();
        }

        private void Room_Load(object sender, EventArgs e)
        {

        }
        public void show(byte RoomID, bool rented, string clientname)
        {
            label1.Text = "Room Number:"+RoomID;
            clientname = clientname == Client.Name ? "you" : clientname;
            if (rented)
            {
                button3.Text = "Room is already rented by "+clientname;
                button3.Enabled = false;
            }
            Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can get your key from first floor");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
