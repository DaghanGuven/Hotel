using System;
using System.Media;
using System.Windows.Forms;

namespace Güven_otel
{
    public partial class Error : Form
    {
        public Error()
        {
            InitializeComponent();
        }
        public void Give(string message)
        {
            SoundPlayer player = new SoundPlayer("Windows XP Error - Sound Effect.wav");
            player.Play();
            label1.Text = message;
            Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
