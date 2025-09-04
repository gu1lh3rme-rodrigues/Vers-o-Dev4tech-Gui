namespace Dev4Tech
{
    partial class cadastro_funcionário
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
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCadFuncEmail = new System.Windows.Forms.TextBox();
            this.txtCadFuncSenha = new System.Windows.Forms.TextBox();
            this.txtCadFuncConfirmSenha = new System.Windows.Forms.TextBox();
            this.txtCadFuncNome = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbBoxCargoFunc = new System.Windows.Forms.ComboBox();
            this.txtCadFuncTelefone = new System.Windows.Forms.MaskedTextBox();
            this.txtCadFuncDataNasc = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCadFuncCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtEndereço = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEndereçoNum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.Location = new System.Drawing.Point(181, 589);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(75, 23);
            this.btnCadastrar.TabIndex = 78;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(181, 618);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltar.TabIndex = 77;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(108, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(193, 15);
            this.label12.TabIndex = 75;
            this.label12.Text = "Se já possuir uma conta, você pode";
            // 
            // txtCadFuncEmail
            // 
            this.txtCadFuncEmail.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCadFuncEmail.Location = new System.Drawing.Point(127, 443);
            this.txtCadFuncEmail.Name = "txtCadFuncEmail";
            this.txtCadFuncEmail.Size = new System.Drawing.Size(214, 22);
            this.txtCadFuncEmail.TabIndex = 71;
            this.txtCadFuncEmail.Text = "gui@hotmail.com";
            this.txtCadFuncEmail.Click += new System.EventHandler(this.txtCadFuncEmail_Click);
            this.txtCadFuncEmail.TextChanged += new System.EventHandler(this.txtCadFuncEmail_TextChanged);
            // 
            // txtCadFuncSenha
            // 
            this.txtCadFuncSenha.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCadFuncSenha.Location = new System.Drawing.Point(127, 497);
            this.txtCadFuncSenha.Name = "txtCadFuncSenha";
            this.txtCadFuncSenha.Size = new System.Drawing.Size(119, 22);
            this.txtCadFuncSenha.TabIndex = 70;
            this.txtCadFuncSenha.Text = "func";
            this.txtCadFuncSenha.Click += new System.EventHandler(this.txtCadFuncSenha_Click);
            this.txtCadFuncSenha.TextChanged += new System.EventHandler(this.txtCadFuncSenha_TextChanged);
            // 
            // txtCadFuncConfirmSenha
            // 
            this.txtCadFuncConfirmSenha.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCadFuncConfirmSenha.Location = new System.Drawing.Point(127, 549);
            this.txtCadFuncConfirmSenha.Name = "txtCadFuncConfirmSenha";
            this.txtCadFuncConfirmSenha.Size = new System.Drawing.Size(119, 22);
            this.txtCadFuncConfirmSenha.TabIndex = 69;
            this.txtCadFuncConfirmSenha.Text = "func";
            this.txtCadFuncConfirmSenha.Click += new System.EventHandler(this.txtCadFuncConfirmSenha_Click);
            this.txtCadFuncConfirmSenha.TextChanged += new System.EventHandler(this.txtCadFuncConfirmSenha_TextChanged);
            // 
            // txtCadFuncNome
            // 
            this.txtCadFuncNome.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCadFuncNome.Location = new System.Drawing.Point(127, 176);
            this.txtCadFuncNome.Name = "txtCadFuncNome";
            this.txtCadFuncNome.Size = new System.Drawing.Size(214, 22);
            this.txtCadFuncNome.TabIndex = 68;
            this.txtCadFuncNome.Text = "Guilherme";
            this.txtCadFuncNome.Click += new System.EventHandler(this.txtCadFuncNome_Click);
            this.txtCadFuncNome.TextChanged += new System.EventHandler(this.txtCadFuncNome_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(124, 533);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 13);
            this.label11.TabIndex = 67;
            this.label11.Text = "Confirmação de senha";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(124, 481);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 66;
            this.label10.Text = "Senha";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(124, 427);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 65;
            this.label9.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(124, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 62;
            this.label6.Text = "CPF";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(124, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Cargo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(124, 160);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Nome";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(303, 115);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(64, 15);
            this.lblLogin.TabIndex = 59;
            this.lblLogin.TabStop = true;
            this.lblLogin.Text = "Entrar aqui";
            this.lblLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLogin_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(108, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 15);
            this.label3.TabIndex = 58;
            this.label3.Text = "Faça o cadastro do funcionário ingressante";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(108, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 15);
            this.label2.TabIndex = 57;
            this.label2.Text = "Cadastro do funcionário";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 30);
            this.label1.TabIndex = 56;
            this.label1.Text = "WORKFLOW";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.pictureBox2.BackgroundImage = global::Dev4Tech.Properties.Resources._141;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(580, 53);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(442, 356);
            this.pictureBox2.TabIndex = 80;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Dev4Tech.Properties.Resources.Group_33__2_;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(532, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(550, 550);
            this.pictureBox1.TabIndex = 76;
            this.pictureBox1.TabStop = false;
            // 
            // cbBoxCargoFunc
            // 
            this.cbBoxCargoFunc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBoxCargoFunc.FormattingEnabled = true;
            this.cbBoxCargoFunc.Items.AddRange(new object[] {
            "RH",
            "Contabilidade",
            "Estagiário"});
            this.cbBoxCargoFunc.Location = new System.Drawing.Point(127, 229);
            this.cbBoxCargoFunc.Name = "cbBoxCargoFunc";
            this.cbBoxCargoFunc.Size = new System.Drawing.Size(129, 21);
            this.cbBoxCargoFunc.TabIndex = 81;
            this.cbBoxCargoFunc.Text = "Selecione o Cargo";
            this.cbBoxCargoFunc.SelectedIndexChanged += new System.EventHandler(this.cbBoxCargo_SelectedIndexChanged);
            // 
            // txtCadFuncTelefone
            // 
            this.txtCadFuncTelefone.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCadFuncTelefone.Location = new System.Drawing.Point(126, 387);
            this.txtCadFuncTelefone.Mask = "(00) 00000-0000";
            this.txtCadFuncTelefone.Name = "txtCadFuncTelefone";
            this.txtCadFuncTelefone.Size = new System.Drawing.Size(120, 22);
            this.txtCadFuncTelefone.TabIndex = 85;
            this.txtCadFuncTelefone.Text = "55888080808";
            // 
            // txtCadFuncDataNasc
            // 
            this.txtCadFuncDataNasc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCadFuncDataNasc.Location = new System.Drawing.Point(126, 339);
            this.txtCadFuncDataNasc.Mask = "00/00/0000";
            this.txtCadFuncDataNasc.Name = "txtCadFuncDataNasc";
            this.txtCadFuncDataNasc.Size = new System.Drawing.Size(66, 22);
            this.txtCadFuncDataNasc.TabIndex = 84;
            this.txtCadFuncDataNasc.Text = "11082000";
            this.txtCadFuncDataNasc.ValidatingType = typeof(System.DateTime);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(124, 371);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 83;
            this.label13.Text = "Telefone";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(124, 323);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 13);
            this.label14.TabIndex = 82;
            this.label14.Text = "Data de nascimento";
            // 
            // txtCadFuncCPF
            // 
            this.txtCadFuncCPF.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCadFuncCPF.Location = new System.Drawing.Point(127, 284);
            this.txtCadFuncCPF.Mask = "000.000.000-00";
            this.txtCadFuncCPF.Name = "txtCadFuncCPF";
            this.txtCadFuncCPF.Size = new System.Drawing.Size(119, 22);
            this.txtCadFuncCPF.TabIndex = 86;
            this.txtCadFuncCPF.Text = "78744394985";
            // 
            // txtEndereço
            // 
            this.txtEndereço.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndereço.Location = new System.Drawing.Point(298, 230);
            this.txtEndereço.Name = "txtEndereço";
            this.txtEndereço.Size = new System.Drawing.Size(184, 22);
            this.txtEndereço.TabIndex = 88;
            this.txtEndereço.Text = "Avenida Paulista";
            this.txtEndereço.TextChanged += new System.EventHandler(this.txtEndereço_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(295, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 87;
            this.label7.Text = "Endereço";
            // 
            // txtEndereçoNum
            // 
            this.txtEndereçoNum.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndereçoNum.Location = new System.Drawing.Point(298, 284);
            this.txtEndereçoNum.Name = "txtEndereçoNum";
            this.txtEndereçoNum.Size = new System.Drawing.Size(56, 22);
            this.txtEndereçoNum.TabIndex = 89;
            this.txtEndereçoNum.Text = "530";
            this.txtEndereçoNum.TextChanged += new System.EventHandler(this.txtEndereçoNum_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(295, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 90;
            this.label8.Text = "Número endereço";
            // 
            // cadastro_funcionário
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEndereçoNum);
            this.Controls.Add(this.txtEndereço);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCadFuncCPF);
            this.Controls.Add(this.txtCadFuncTelefone);
            this.Controls.Add(this.txtCadFuncDataNasc);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cbBoxCargoFunc);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCadFuncEmail);
            this.Controls.Add(this.txtCadFuncSenha);
            this.Controls.Add(this.txtCadFuncConfirmSenha);
            this.Controls.Add(this.txtCadFuncNome);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "cadastro_funcionário";
            this.Text = "cadastro_funcionário";
            this.Load += new System.EventHandler(this.cadastro_funcionário_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCadFuncEmail;
        private System.Windows.Forms.TextBox txtCadFuncSenha;
        private System.Windows.Forms.TextBox txtCadFuncConfirmSenha;
        private System.Windows.Forms.TextBox txtCadFuncNome;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lblLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cbBoxCargoFunc;
        private System.Windows.Forms.MaskedTextBox txtCadFuncTelefone;
        private System.Windows.Forms.MaskedTextBox txtCadFuncDataNasc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox txtCadFuncCPF;
        private System.Windows.Forms.TextBox txtEndereço;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEndereçoNum;
        private System.Windows.Forms.Label label8;
    }
}