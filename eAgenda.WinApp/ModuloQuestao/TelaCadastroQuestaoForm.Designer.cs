namespace Testes_da_Mariana.WinApp.ModuloQuestao
{
    partial class TelaCadastroQuestaoForm
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
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.listAlternativas = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEnunciadoAlternativa = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.txtEnunciado = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboMateria = new System.Windows.Forms.ComboBox();
            this.isCorreta = new System.Windows.Forms.CheckBox();
            this.comboDisciplina = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAlterarAlternativaCorreta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(501, 117);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(86, 31);
            this.btnAdicionar.TabIndex = 19;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // listAlternativas
            // 
            this.listAlternativas.FormattingEnabled = true;
            this.listAlternativas.ItemHeight = 20;
            this.listAlternativas.Location = new System.Drawing.Point(11, 159);
            this.listAlternativas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listAlternativas.Name = "listAlternativas";
            this.listAlternativas.Size = new System.Drawing.Size(575, 204);
            this.listAlternativas.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Alternativas:";
            // 
            // txtEnunciadoAlternativa
            // 
            this.txtEnunciadoAlternativa.Location = new System.Drawing.Point(109, 119);
            this.txtEnunciadoAlternativa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEnunciadoAlternativa.Name = "txtEnunciadoAlternativa";
            this.txtEnunciadoAlternativa.Size = new System.Drawing.Size(222, 27);
            this.txtEnunciadoAlternativa.TabIndex = 16;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(505, 371);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(82, 52);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(413, 371);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(82, 52);
            this.btnGravar.TabIndex = 14;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // txtEnunciado
            // 
            this.txtEnunciado.Location = new System.Drawing.Point(107, 84);
            this.txtEnunciado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEnunciado.Name = "txtEnunciado";
            this.txtEnunciado.Size = new System.Drawing.Size(388, 27);
            this.txtEnunciado.TabIndex = 25;
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(85, 15);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(73, 27);
            this.txtNumero.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Enunciado:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Número:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Matéria:";
            // 
            // comboMateria
            // 
            this.comboMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMateria.FormattingEnabled = true;
            this.comboMateria.Location = new System.Drawing.Point(344, 49);
            this.comboMateria.Name = "comboMateria";
            this.comboMateria.Size = new System.Drawing.Size(151, 28);
            this.comboMateria.TabIndex = 27;
            // 
            // isCorreta
            // 
            this.isCorreta.AutoSize = true;
            this.isCorreta.Location = new System.Drawing.Point(337, 121);
            this.isCorreta.Name = "isCorreta";
            this.isCorreta.Size = new System.Drawing.Size(161, 24);
            this.isCorreta.TabIndex = 28;
            this.isCorreta.Text = "Alternativa correta?";
            this.isCorreta.UseVisualStyleBackColor = true;
            // 
            // comboDisciplina
            // 
            this.comboDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDisciplina.FormattingEnabled = true;
            this.comboDisciplina.Location = new System.Drawing.Point(98, 49);
            this.comboDisciplina.Name = "comboDisciplina";
            this.comboDisciplina.Size = new System.Drawing.Size(151, 28);
            this.comboDisciplina.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Disciplina:";
            // 
            // btnAlterarAlternativaCorreta
            // 
            this.btnAlterarAlternativaCorreta.Location = new System.Drawing.Point(12, 371);
            this.btnAlterarAlternativaCorreta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAlterarAlternativaCorreta.Name = "btnAlterarAlternativaCorreta";
            this.btnAlterarAlternativaCorreta.Size = new System.Drawing.Size(146, 51);
            this.btnAlterarAlternativaCorreta.TabIndex = 31;
            this.btnAlterarAlternativaCorreta.Text = "Alterar alternativa correta";
            this.btnAlterarAlternativaCorreta.UseVisualStyleBackColor = true;
            this.btnAlterarAlternativaCorreta.Click += new System.EventHandler(this.btnAlterarAlternativaCorreta_Click);
            // 
            // TelaCadastroQuestaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 435);
            this.Controls.Add(this.btnAlterarAlternativaCorreta);
            this.Controls.Add(this.comboDisciplina);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.isCorreta);
            this.Controls.Add(this.comboMateria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEnunciado);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.listAlternativas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEnunciadoAlternativa);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroQuestaoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Questão";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaCadastroQuestaoForm_FormClosing);
            this.Load += new System.EventHandler(this.TelaCadastroQuestaoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.ListBox listAlternativas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEnunciadoAlternativa;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.TextBox txtEnunciado;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboMateria;
        private System.Windows.Forms.CheckBox isCorreta;
        private System.Windows.Forms.ComboBox comboDisciplina;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAlterarAlternativaCorreta;
        private System.Windows.Forms.Button btnAtualizarAlternativaCorreta;
    }
}