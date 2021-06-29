namespace NotifyControl
{
    partial class FrmControl
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmControl));
            this.ntfInfo = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmCheckIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCheckOut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmView = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsSair = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrControl = new System.Windows.Forms.Timer(this.components);
            this.lvlHorarios = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPlaySoundAlert = new System.Windows.Forms.CheckBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmsMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ntfInfo
            // 
            this.ntfInfo.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfInfo.Icon")));
            this.ntfInfo.Text = "Controle de Horários";
            this.ntfInfo.Visible = true;
            this.ntfInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ntfInfo_MouseClick);
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCheckIn,
            this.tsmCheckOut,
            this.tsmView,
            this.tmsSair});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(164, 92);
            this.cmsMenu.Text = "Menu";
            // 
            // tsmCheckIn
            // 
            this.tsmCheckIn.Name = "tsmCheckIn";
            this.tsmCheckIn.Size = new System.Drawing.Size(163, 22);
            this.tsmCheckIn.Text = "Registrar Entrada";
            this.tsmCheckIn.Click += new System.EventHandler(this.tsmCheckIn_Click);
            // 
            // tsmCheckOut
            // 
            this.tsmCheckOut.Name = "tsmCheckOut";
            this.tsmCheckOut.Size = new System.Drawing.Size(163, 22);
            this.tsmCheckOut.Text = "Registrar Saída";
            this.tsmCheckOut.Click += new System.EventHandler(this.tsmCheckOut_Click);
            // 
            // tsmView
            // 
            this.tsmView.Name = "tsmView";
            this.tsmView.Size = new System.Drawing.Size(163, 22);
            this.tsmView.Text = "Exibir";
            this.tsmView.Click += new System.EventHandler(this.tsmView_Click);
            // 
            // tmsSair
            // 
            this.tmsSair.Name = "tmsSair";
            this.tmsSair.Size = new System.Drawing.Size(163, 22);
            this.tmsSair.Text = "Sair";
            this.tmsSair.Click += new System.EventHandler(this.tmsSair_Click);
            // 
            // tmrControl
            // 
            this.tmrControl.Enabled = true;
            this.tmrControl.Interval = 60000;
            this.tmrControl.Tick += new System.EventHandler(this.tmrControl_Tick);
            // 
            // lvlHorarios
            // 
            this.lvlHorarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvlHorarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvlHorarios.HideSelection = false;
            this.lvlHorarios.Location = new System.Drawing.Point(3, 16);
            this.lvlHorarios.Name = "lvlHorarios";
            this.lvlHorarios.Size = new System.Drawing.Size(770, 357);
            this.lvlHorarios.TabIndex = 1;
            this.lvlHorarios.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvlHorarios);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 376);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Horários";
            // 
            // chkPlaySoundAlert
            // 
            this.chkPlaySoundAlert.AutoSize = true;
            this.chkPlaySoundAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPlaySoundAlert.Location = new System.Drawing.Point(15, 394);
            this.chkPlaySoundAlert.Name = "chkPlaySoundAlert";
            this.chkPlaySoundAlert.Size = new System.Drawing.Size(157, 28);
            this.chkPlaySoundAlert.TabIndex = 4;
            this.chkPlaySoundAlert.Text = "Alerta Sonoro";
            this.chkPlaySoundAlert.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Image = global::WorkingHoursNotificationControl.Properties.Resources.exportar;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(630, 392);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(155, 53);
            this.btnExportar.TabIndex = 5;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::WorkingHoursNotificationControl.Properties.Resources.refresh;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(469, 392);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(155, 53);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Atualizar";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FrmControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.chkPlaySoundAlert);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Horários";
            this.Load += new System.EventHandler(this.FrmControl_Load);
            this.Resize += new System.EventHandler(this.FrmControl_Resize);
            this.cmsMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon ntfInfo;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmCheckIn;
        private System.Windows.Forms.ToolStripMenuItem tsmCheckOut;
        private System.Windows.Forms.ToolStripMenuItem tsmView;
        private System.Windows.Forms.Timer tmrControl;
        private System.Windows.Forms.ListView lvlHorarios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolStripMenuItem tmsSair;
        private System.Windows.Forms.CheckBox chkPlaySoundAlert;
        private System.Windows.Forms.Button btnExportar;
    }
}

