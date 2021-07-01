using System;
using System.Media;
using System.Windows.Forms;

namespace NotifyControl
{
    public partial class FrmNotification : Form
    {
        private readonly SoundPlayer _simpleSound;
        private readonly bool _isPlaySoundAlert;
        public int _qtdMinutesExtend;

        public FrmNotification(string message, bool isPlaySoundAlert)
        {
            InitializeComponent();
            _isPlaySoundAlert = isPlaySoundAlert;
            _qtdMinutesExtend = 0;

            lblMessage.Text = message;

            if (_isPlaySoundAlert)
            {
                _simpleSound = new SoundPlayer(@"Alerts\Alert01.wav");
                _simpleSound.PlayLooping();
            }            
        }

        private void btnCloseNotification_Click(object sender, EventArgs e)
        {
            CloseForm(0);
        }

        private void btnExtend10_Click(object sender, EventArgs e)
        {
            CloseForm(10);
        }

        private void CloseForm(int qtdMinutes)
        {
            _qtdMinutesExtend = qtdMinutes;
            if (_isPlaySoundAlert)
                _simpleSound.Stop();
            this.Close();
        }
    }
}