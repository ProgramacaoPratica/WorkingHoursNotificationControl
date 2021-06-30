using NotifyControl.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NotifyControl
{
    public partial class FrmControl : Form
    {
        [DllImport("User32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool SetForegroundWindow(HandleRef hWnd);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true)]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);
        const int WM_COMMAND = 0x111;
        const int MIN_ALL = 419;

        private readonly ContextApp _contexto;

        public int _qtdMinutesExtend;

        public FrmControl()
        {
            InitializeComponent();
            _contexto = new ContextApp();
            _qtdMinutesExtend = 0;
        }

        private void FrmControl_Load(object sender, EventArgs e)
        {
            ntfInfo.BalloonTipTitle = "Controle de Horário";
            ntfInfo.BalloonTipText = "Aplicação minimizada";
            ntfInfo.Visible = false;

            //Exibe detalhes
            lvlHorarios.View = View.Details;
            //Permite selecionar a linha toda
            lvlHorarios.FullRowSelect = true;
            //Exite as linhas no listview
            lvlHorarios.GridLines = true;
            //Permite que o usuário edite o texto
            lvlHorarios.LabelEdit = true;

            lvlHorarios.Columns.Add("Data", 150, HorizontalAlignment.Center);
            lvlHorarios.Columns.Add("Entrada 1", 120, HorizontalAlignment.Center);
            lvlHorarios.Columns.Add("Saída 1", 120, HorizontalAlignment.Center);
            lvlHorarios.Columns.Add("Entrada 2", 120, HorizontalAlignment.Center);
            lvlHorarios.Columns.Add("Saída 2", 120, HorizontalAlignment.Center);
            lvlHorarios.Columns.Add("Tempo", 120, HorizontalAlignment.Center);

            RefreshList();
        }

        private void FrmControl_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowIcon = false;
                ShowInTaskbar = false;
                ntfInfo.Visible = true;
                ntfInfo.ShowBalloonTip(1);
            }
        }

        private void ntfInfo_MouseClick(object sender, MouseEventArgs e)
        {
            SetForegroundWindow(new HandleRef(this, this.Handle));
            int x = Control.MousePosition.X;
            int y = Control.MousePosition.Y;
            x = x - 10;
            y = y - 40;
            this.cmsMenu.Show(x, y);
        }

        private async void tsmCheckIn_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifica se já tem um registro para a data atual
                Record tempRec = null;

                if (_contexto.Records.Count() > 0)
                {
                    DateTime dtAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                    tempRec = _contexto.Records.Where(r => r.Date == dtAtual).FirstOrDefault();
                }

                //Se não possui registro no dia então cria
                if (tempRec == null)
                {
                    //Insere o registro
                    Record rec = new Record()
                    {
                        Date = DateTime.Now,
                        CheckIn1 = DateTime.Now,
                        NotifiedCheckIn1 = true
                    };
                    _contexto.Records.Add(rec);
                    await _contexto.SaveChangesAsync();

                    MessageBox.Show("Primeira entrada registrada com sucesso!",
                            "Registro de Horários",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                }
                //Ou se já possui registro então verifica se já possui a segunda entrada
                else
                {
                    if (tempRec.CheckIn2 == null)
                    {
                        if (tempRec.CheckOut1 == null)
                        {
                            MessageBox.Show("Atenção, você ainda não registrou a sua primeira saída",
                                "Registro de Horários",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                        else
                        {
                            //Atualiza o registro
                            tempRec.CheckIn2 = DateTime.Now;
                            tempRec.NotifiedCheckIn2 = true;

                            TimeSpan contractHours = new TimeSpan(8, 0, 0);
                            TimeSpan morningHours = (TimeSpan)(tempRec.CheckOut1 - tempRec.CheckIn1);
                            TimeSpan missingTime = contractHours - morningHours;
                            tempRec.PredictionCheckOut2 = tempRec.CheckIn2 + missingTime;

                            //int predictCheckOut = 

                            await _contexto.SaveChangesAsync();

                            MessageBox.Show("Segunda entrada registrada com sucesso!",
                                "Registro de Horários",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Atenção, você já registrou a sua segunda entrada",
                            "Registro de Horários",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema ao registrar entrada!" + Environment.NewLine + ex.Message);
            }
        }

        private async void tsmCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifica se já tem um registro para a data atual
                Record tempRec = null;

                if (_contexto.Records.Count() > 0)
                {
                    DateTime dtAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                    tempRec = _contexto.Records.Where(r => r.Date == dtAtual).FirstOrDefault();
                }

                //Se não possui registro no dia então cria
                if (tempRec == null)
                {
                    MessageBox.Show("Atenção, você ainda não registrou a sua primeira entrada!",
                            "Registro de Horários",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                }
                else
                {
                    if (tempRec.CheckOut1 == null)
                    {
                        //Atualiza o registro
                        tempRec.CheckOut1 = DateTime.Now;
                        tempRec.NotifiedCheckOut1 = true;
                        await _contexto.SaveChangesAsync();

                        MessageBox.Show("Primeira saída registrada com sucesso!",
                            "Registro de Horários",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (tempRec.CheckOut2 == null)
                        {
                            if (tempRec.CheckIn2 == null)
                            {
                                MessageBox.Show("Atenção, você precisa registrar a sua segunda entrada",
                                "Registro de Horários",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            }
                            else
                            {
                                tempRec.CheckOut2 = DateTime.Now;
                                tempRec.NotifiedCheckOut2 = true;
                                await _contexto.SaveChangesAsync();

                                MessageBox.Show("Segunda saída registrada com sucesso!",
                                    "Registro de Horários",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Atenção, você já registrou a sua segunda saída",
                            "Registro de Horários",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema ao registrar entrada!" + Environment.NewLine + ex.Message);
            }
        }

        private void tsmView_Click(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            ntfInfo.Visible = false;
            WindowState = FormWindowState.Normal;
            RefreshList();
        }

        private void tmrControl_Tick(object sender, EventArgs e)
        {
            DateTime dtAtual = DateTime.Now;

            Record tempRec = null;

            if (_contexto.Records.Count() > 0)
            {
                DateTime refDtAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                tempRec = _contexto.Records.Where(r => r.Date == refDtAtual).FirstOrDefault();
                //Se não tem registro no dia
                if (tempRec == null)
                {
                    //Horário Flexível de entrada 1
                    if (dtAtual >= new DateTime(dtAtual.Year, dtAtual.Month, dtAtual.Day, 7, 0, 0).AddMinutes(_qtdMinutesExtend) &&
                        dtAtual < new DateTime(dtAtual.Year, dtAtual.Month, dtAtual.Day, 9, 0, 0))
                    {
                        ShowNotification("Registre a sua primeira entrada!");
                    }
                }
                else{

                    //Horário Flexível de intervalo: saída 1 || entrada 2
                    if (dtAtual >= new DateTime(dtAtual.Year, dtAtual.Month, dtAtual.Day, 11, 30, 0) &&
                        dtAtual < new DateTime(dtAtual.Year, dtAtual.Month, dtAtual.Day, 14, 0, 0))
                    {
                        if (!tempRec.NotifiedCheckOut1)
                        {
                            if ((dtAtual - tempRec.CheckIn1) > new TimeSpan(3, 0, 0).Add(new TimeSpan(0, _qtdMinutesExtend, 0)))
                            {
                                ShowNotification("Registre a sua primeira saída!");
                            }
                        }
                        else if (!tempRec.NotifiedCheckIn2)
                        {
                            //Pelo menos 30 minutos de intervalo
                            if ((dtAtual - tempRec.CheckOut1) > new TimeSpan(0, 30, 0).Add(new TimeSpan(0, _qtdMinutesExtend, 0)))
                            {
                                ShowNotification("Registre a sua segunda entrada!");
                            }
                        }
                    }
                    //Horário Flexível de saída 2
                    else if (dtAtual >= ((DateTime)tempRec.PredictionCheckOut2).AddMinutes(_qtdMinutesExtend))
                    {
                        //Verifica se já chegou na hora prevista para sair
                        if (!tempRec.NotifiedCheckOut2)
                        {
                            ShowNotification("Registre a sua segunda saída!");
                        }
                    }
                }
            }
        }

        private void ShowNotification(string message)
        {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType().Equals(typeof(FrmNotification)))
                {
                    isOpen = true;
                    break;
                }
            }

            if (!isOpen)
            {
                IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
                SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL, IntPtr.Zero);

                FrmNotification form = new FrmNotification(message, chkPlaySoundAlert.Checked);
                form.ShowDialog();
                _qtdMinutesExtend = form._qtdMinutesExtend;
            }
        }

        private void tmsSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fechar a aplicação de controle de horários?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
            ws.Name = "Horários Registrados";
            int linha = 2, coluna = 1;

            ws.Cells[1, 1] = lvlHorarios.Columns[0].Text;
            ws.Cells[1, 2] = lvlHorarios.Columns[1].Text;
            ws.Cells[1, 3] = lvlHorarios.Columns[2].Text;
            ws.Cells[1, 4] = lvlHorarios.Columns[3].Text;
            ws.Cells[1, 5] = lvlHorarios.Columns[4].Text;
            ws.Cells[1, 6] = lvlHorarios.Columns[5].Text;

            foreach (ListViewItem lvi in lvlHorarios.Items)
            {
                coluna = 1;
                foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                {
                    ws.Cells[linha, coluna] = lvs.Text;
                    coluna++;
                }
                linha++;
            }
        }

        private async void RefreshList()
        {
            var horarios = await _contexto.Records.ToListAsync();

            lvlHorarios.Items.Clear();

            foreach (var item in horarios)
            {
                //Definir os itens da lista
                ListViewItem lvi = new ListViewItem(item.Date.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(item.CheckIn1.ToString("HH:mm:ss"));
                lvi.SubItems.Add(item.CheckOut1.HasValue ? ((DateTime)item.CheckOut1).ToString("HH:mm:ss") : "");
                lvi.SubItems.Add(item.CheckIn2.HasValue ? ((DateTime)item.CheckIn2).ToString("HH:mm:ss") : "");
                lvi.SubItems.Add(item.CheckOut2.HasValue ? ((DateTime)item.CheckOut2).ToString("HH:mm:ss") : "");
                if (item.CheckOut1.HasValue && item.CheckIn2.HasValue && item.CheckOut2.HasValue)
                {
                    var tempTime = ((TimeSpan)((item.CheckOut1 - item.CheckIn1) + (item.CheckOut2 - item.CheckIn2)));
                    var tempDate = new DateTime(1900, 1, 1, tempTime.Hours, tempTime.Minutes, tempTime.Seconds);
                    lvi.SubItems.Add(tempDate.ToString("HH:mm:ss"));
                }
                else
                    lvi.SubItems.Add("");

                //Adicionar o item criado(linha criada) no listview
                lvlHorarios.Items.Add(lvi);
            }
        }
    }
}
