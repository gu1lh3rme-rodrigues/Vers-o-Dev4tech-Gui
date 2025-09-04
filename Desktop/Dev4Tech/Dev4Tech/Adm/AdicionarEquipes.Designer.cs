namespace Dev4Tech
{
    partial class AdicionarEquipes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeEquipe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddMembro = new System.Windows.Forms.Button();
            this.cbmEmailMembro = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCriarEquipe = new System.Windows.Forms.Button();
            this.cmbCategoriaEquipe = new System.Windows.Forms.ComboBox();
            this.panelDadosFunc = new System.Windows.Forms.Panel();
            this.picPerfil = new System.Windows.Forms.PictureBox();
            this.btnEquipes = new System.Windows.Forms.PictureBox();
            this.btnCalendar = new System.Windows.Forms.PictureBox();
            this.btnRanking = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.PictureBox();
            this.btnConfig = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEquipes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRanking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(224, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 45);
            this.label1.TabIndex = 99;
            this.label1.Text = "Cadastro de equipes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(229, 171);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 21);
            this.label2.TabIndex = 100;
            this.label2.Text = "Nome da equipe";
            // 
            // txtNomeEquipe
            // 
            this.txtNomeEquipe.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeEquipe.Location = new System.Drawing.Point(232, 195);
            this.txtNomeEquipe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNomeEquipe.Name = "txtNomeEquipe";
            this.txtNomeEquipe.Size = new System.Drawing.Size(164, 25);
            this.txtNomeEquipe.TabIndex = 101;
            this.txtNomeEquipe.Text = "Dev4Tech";
            this.txtNomeEquipe.TextChanged += new System.EventHandler(this.txtNomeEquipe_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(229, 237);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 21);
            this.label3.TabIndex = 102;
            this.label3.Text = "Categoria da equipe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(229, 309);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 21);
            this.label4.TabIndex = 104;
            this.label4.Text = "Adicionar membro";
            // 
            // btnAddMembro
            // 
            this.btnAddMembro.Location = new System.Drawing.Point(470, 334);
            this.btnAddMembro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddMembro.Name = "btnAddMembro";
            this.btnAddMembro.Size = new System.Drawing.Size(31, 20);
            this.btnAddMembro.TabIndex = 106;
            this.btnAddMembro.Text = "+";
            this.btnAddMembro.UseVisualStyleBackColor = true;
            // 
            // cbmEmailMembro
            // 
            this.cbmEmailMembro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmEmailMembro.FormattingEnabled = true;
            this.cbmEmailMembro.Location = new System.Drawing.Point(232, 334);
            this.cbmEmailMembro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbmEmailMembro.Name = "cbmEmailMembro";
            this.cbmEmailMembro.Size = new System.Drawing.Size(232, 25);
            this.cbmEmailMembro.TabIndex = 107;
            this.cbmEmailMembro.Text = "gui@hotmail.com";
            this.cbmEmailMembro.SelectedIndexChanged += new System.EventHandler(this.cbmEmailMembro_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(607, 161);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 21);
            this.label5.TabIndex = 108;
            this.label5.Text = "Membros";
            // 
            // btnCriarEquipe
            // 
            this.btnCriarEquipe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriarEquipe.Location = new System.Drawing.Point(276, 438);
            this.btnCriarEquipe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCriarEquipe.Name = "btnCriarEquipe";
            this.btnCriarEquipe.Size = new System.Drawing.Size(120, 55);
            this.btnCriarEquipe.TabIndex = 115;
            this.btnCriarEquipe.Text = "Criar equipe";
            this.btnCriarEquipe.UseVisualStyleBackColor = true;
            this.btnCriarEquipe.Click += new System.EventHandler(this.btnCriarEquipe_Click);
            // 
            // cmbCategoriaEquipe
            // 
            this.cmbCategoriaEquipe.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoriaEquipe.FormattingEnabled = true;
            this.cmbCategoriaEquipe.Items.AddRange(new object[] {
            "asd",
            "ijn"});
            this.cmbCategoriaEquipe.Location = new System.Drawing.Point(232, 261);
            this.cmbCategoriaEquipe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbCategoriaEquipe.Name = "cmbCategoriaEquipe";
            this.cmbCategoriaEquipe.Size = new System.Drawing.Size(174, 25);
            this.cmbCategoriaEquipe.TabIndex = 118;
            this.cmbCategoriaEquipe.Text = "Desenvolvedores";
            this.cmbCategoriaEquipe.SelectedIndexChanged += new System.EventHandler(this.cmbCategoriaEquipe_SelectedIndexChanged);
            // 
            // panelDadosFunc
            // 
            this.panelDadosFunc.Location = new System.Drawing.Point(602, 187);
            this.panelDadosFunc.Name = "panelDadosFunc";
            this.panelDadosFunc.Size = new System.Drawing.Size(593, 314);
            this.panelDadosFunc.TabIndex = 119;
            this.panelDadosFunc.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDadosFunc_Paint);
            // 
            // picPerfil
            // 
            this.picPerfil.BackColor = System.Drawing.Color.Blue;
            this.picPerfil.BackgroundImage = global::Dev4Tech.Properties.Resources.icon_perfil;
            this.picPerfil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPerfil.Location = new System.Drawing.Point(13, 610);
            this.picPerfil.Margin = new System.Windows.Forms.Padding(4);
            this.picPerfil.Name = "picPerfil";
            this.picPerfil.Size = new System.Drawing.Size(24, 23);
            this.picPerfil.TabIndex = 44;
            this.picPerfil.TabStop = false;
            // 
            // btnEquipes
            // 
            this.btnEquipes.BackColor = System.Drawing.Color.Blue;
            this.btnEquipes.BackgroundImage = global::Dev4Tech.Properties.Resources.icon_equip;
            this.btnEquipes.Location = new System.Drawing.Point(13, 51);
            this.btnEquipes.Margin = new System.Windows.Forms.Padding(4);
            this.btnEquipes.Name = "btnEquipes";
            this.btnEquipes.Size = new System.Drawing.Size(24, 23);
            this.btnEquipes.TabIndex = 43;
            this.btnEquipes.TabStop = false;
            this.btnEquipes.Click += new System.EventHandler(this.btnEquipes_Click_1);
            // 
            // btnCalendar
            // 
            this.btnCalendar.BackColor = System.Drawing.Color.Blue;
            this.btnCalendar.BackgroundImage = global::Dev4Tech.Properties.Resources.icon_calendar;
            this.btnCalendar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCalendar.Location = new System.Drawing.Point(13, 90);
            this.btnCalendar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Size = new System.Drawing.Size(24, 23);
            this.btnCalendar.TabIndex = 42;
            this.btnCalendar.TabStop = false;
            this.btnCalendar.Click += new System.EventHandler(this.btnCalendar_Click);
            // 
            // btnRanking
            // 
            this.btnRanking.BackColor = System.Drawing.Color.Blue;
            this.btnRanking.BackgroundImage = global::Dev4Tech.Properties.Resources.icon_ranking;
            this.btnRanking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRanking.Location = new System.Drawing.Point(13, 132);
            this.btnRanking.Margin = new System.Windows.Forms.Padding(4);
            this.btnRanking.Name = "btnRanking";
            this.btnRanking.Size = new System.Drawing.Size(24, 23);
            this.btnRanking.TabIndex = 41;
            this.btnRanking.TabStop = false;
            this.btnRanking.Click += new System.EventHandler(this.btnRanking_Click_1);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Blue;
            this.btnLogout.BackgroundImage = global::Dev4Tech.Properties.Resources.Nav_Icon_Item;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.Location = new System.Drawing.Point(13, 567);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(24, 23);
            this.btnLogout.TabIndex = 40;
            this.btnLogout.TabStop = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click_1);
            // 
            // btnConfig
            // 
            this.btnConfig.BackColor = System.Drawing.Color.Blue;
            this.btnConfig.BackgroundImage = global::Dev4Tech.Properties.Resources.icon_config;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(13, 539);
            this.btnConfig.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(24, 23);
            this.btnConfig.TabIndex = 39;
            this.btnConfig.TabStop = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Blue;
            this.btnHome.BackgroundImage = global::Dev4Tech.Properties.Resources.icon_Home;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.Location = new System.Drawing.Point(13, 12);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(24, 23);
            this.btnHome.TabIndex = 38;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Blue;
            this.pictureBox1.Location = new System.Drawing.Point(1, -2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 688);
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Blue;
            this.pictureBox4.BackgroundImage = global::Dev4Tech.Properties.Resources.Design_sem_nome__1_;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(13, 171);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 23);
            this.pictureBox4.TabIndex = 152;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // AdicionarEquipes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1100, 732);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.panelDadosFunc);
            this.Controls.Add(this.cmbCategoriaEquipe);
            this.Controls.Add(this.btnCriarEquipe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbmEmailMembro);
            this.Controls.Add(this.btnAddMembro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNomeEquipe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picPerfil);
            this.Controls.Add(this.btnEquipes);
            this.Controls.Add(this.btnCalendar);
            this.Controls.Add(this.btnRanking);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdicionarEquipes";
            this.Text = "AdicionarEquipes";
            this.Load += new System.EventHandler(this.AdicionarEquipes_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.picPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEquipes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRanking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPerfil;
        private System.Windows.Forms.PictureBox btnEquipes;
        private System.Windows.Forms.PictureBox btnCalendar;
        private System.Windows.Forms.PictureBox btnRanking;
        private System.Windows.Forms.PictureBox btnLogout;
        private System.Windows.Forms.PictureBox btnConfig;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeEquipe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddMembro;
        private System.Windows.Forms.ComboBox cbmEmailMembro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCriarEquipe;
        private System.Windows.Forms.ComboBox cmbCategoriaEquipe;
        private System.Windows.Forms.Panel panelDadosFunc;
        private System.Windows.Forms.PictureBox pictureBox4;
        //private System.Windows.Forms.DataGridView dataGridView1;
    }
}