using System;
using System.Media;
using System.Windows.Forms;

namespace NotifyControl
{
    public partial class FrmNotification : Form
    {
        private readonly SoundPlayer simpleSound;
        public FrmNotification(string message, bool isPlaySoundAlert)
        {
            InitializeComponent();

            lblMessage.Text = message;

            if (isPlaySoundAlert)
            {
                simpleSound = new SoundPlayer(@"Alerts/Alert01.wav");
                simpleSound.PlayLooping();
            }            
        }

        private void btnCloseNotification_Click(object sender, EventArgs e)
        {
            simpleSound.Stop();
            this.Close();
        }
    }
}