using Testes_da_Mariana.Dominio.ModuloDisciplina;
using Testes_da_Mariana.Dominio.ModuloMateria;
using Testes_da_Mariana.Dominio.ModuloQuestao;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testes_da_Mariana.WinApp.ModuloQuestao
{
    public partial class TelaCadastroQuestaoForm : Form
    {
        private Questao questao;
        char[] letras = new char[] { 'A', 'B', 'C', 'D', 'E' };
        int contadorLetra = 0;
        List<Alternativa> alternativasAdicionadas = new List<Alternativa>();

        public TelaCadastroQuestaoForm(List<Disciplina> disciplinas, List<Materia> materias)
        {
            InitializeComponent();
            CarregarDisciplinas(disciplinas);
            CarregarMaterias(materias);

            foreach (Alternativa alternativa in Alternativas)
            {
                listAlternativas.Items.Add(alternativa);
            }
        }

        public TelaCadastroQuestaoForm(List<Disciplina> disciplinas, List<Materia> materias, Questao questao)
        {
            InitializeComponent();
            CarregarDisciplinas(disciplinas);
            CarregarMaterias(materias);

            foreach (Alternativa alternativa in Alternativas)
            {
                listAlternativas.Items.Add(alternativa);
            }

            CarregarAlternativas(questao);
        }

        private void CarregarAlternativas(Questao questao)
        {
            foreach (Alternativa alternativa in questao.Alternativas)
            {
                if(alternativa.Correta)
                    listAlternativas.Items.Add($"{alternativa.Letra}: {alternativa.Descricao} [CORRETA]");
                else
                    listAlternativas.Items.Add($"{alternativa.Letra}: {alternativa.Descricao}");

                alternativasAdicionadas.Add(alternativa);
            }

            btnAdicionar.Enabled = false;
            txtEnunciadoAlternativa.Enabled = false;
            isCorreta.Enabled = false;
            contadorLetra = 5;
        }

        private void CarregarMaterias(List<Materia> materias)
        {
            comboMateria.Items.Clear();

            foreach (var item in materias)
            {
                comboMateria.Items.Add(item);
            }
        }

        private void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            comboDisciplina.Items.Clear();

            foreach (var item in disciplinas)
            {
                comboDisciplina.Items.Add(item);
            }
        }

        public Func<Questao, ValidationResult> GravarRegistro { get; set; }

        public Questao Questao
        {
            get
            {
                return questao;
            }
            set
            {
                questao = value;
                txtNumero.Text = questao.Numero.ToString();
                txtEnunciado.Text = questao.Enunciado;
                comboDisciplina.SelectedItem = questao.Disciplina;
                comboMateria.SelectedItem = questao.Materia;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            questao.Enunciado = txtEnunciado.Text;
            questao.Disciplina = (Disciplina) comboDisciplina.SelectedItem;
            questao.Materia = (Materia) comboMateria.SelectedItem;
            questao.Alternativas = alternativasAdicionadas;

            var resultadoValidacao = GravarRegistro(questao);

            if(contadorLetra != 5)
            {
                string erro = "Insira 5 alternativas";
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
            }
            if (alternativasAdicionadas.Count == 5)
            {
                for (int i = 0; i < alternativasAdicionadas.Count; i++)
                {
                    if (alternativasAdicionadas[i].Correta == true)
                        return;
                }

                string erro = "Nenhuma das alternativas é correta, marque uma";

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
            }

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroQuestaoForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroQuestaoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        public List<Alternativa> Alternativas
        {
            get
            {
                return listAlternativas.Items.Cast<Alternativa>().ToList();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (contadorLetra >= 4)
            {
                btnAdicionar.Enabled = false;
                txtEnunciadoAlternativa.Enabled = false;
                isCorreta.Enabled = false;
            }
            if (String.IsNullOrEmpty(txtEnunciadoAlternativa.Text))
            {
                string erro = "Não pode inserir uma alternativa vazia";
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
            }
            else
            {
                Alternativa alternativa = new Alternativa();
                alternativa.Descricao = txtEnunciadoAlternativa.Text;
                alternativa.Letra = letras[contadorLetra];
                contadorLetra++;
                if (isCorreta.Checked)
                {
                    alternativa.Correta = true;
                    listAlternativas.Items.Add($"{alternativa.Letra}) {alternativa.Descricao} [CORRETA]");
                    isCorreta.Enabled = false;
                }
                else
                {
                    listAlternativas.Items.Add($"{alternativa.Letra}) {alternativa.Descricao}");
                }

                alternativasAdicionadas.Add(alternativa);
                isCorreta.Checked = false;
                txtEnunciadoAlternativa.Text = String.Empty;
            }
        }

        private void btnAlterarAlternativaCorreta_Click(object sender, EventArgs e)
        {
            if (listAlternativas.SelectedItem == null)
            {
                btnAlterarAlternativaCorreta.Visible = false;
            }

            if (questao.Alternativas != null)
            {
                ReceberAlternativasDaQuestao();
                return;
            }
            else
            {
                ReceberAlternativasDaClasse();
                return;
            }
        }

        private void ReceberAlternativasDaClasse()
        {
            for (int i = 0; i < alternativasAdicionadas.Count; i++)
            {
                if (alternativasAdicionadas[i].Correta == true)
                {
                    alternativasAdicionadas[i].Correta = alternativasAdicionadas[i].Correta = false;

                    alternativasAdicionadas[listAlternativas.SelectedIndex].Correta = true;
                    break;
                }
            }

            alternativasAdicionadas[listAlternativas.SelectedIndex].Correta = true;

            listAlternativas.Items.Clear();
            foreach (Alternativa alternativa in alternativasAdicionadas)
            {
                if (alternativa.Correta)
                    listAlternativas.Items.Add($"{alternativa.Letra}: {alternativa.Descricao} [CORRETA]");
                else
                    listAlternativas.Items.Add($"{alternativa.Letra}: {alternativa.Descricao}");
            }
        }

        private void ReceberAlternativasDaQuestao()
        {
            for (int i = 0; i < questao.Alternativas.Count; i++)
            {
                if (questao.Alternativas[i].Correta == true)
                {
                    questao.Alternativas[i].Correta = questao.Alternativas[i].Correta = false;

                    questao.Alternativas[listAlternativas.SelectedIndex].Correta = true;
                    break;
                }
            }

            questao.Alternativas[listAlternativas.SelectedIndex].Correta = true;

            listAlternativas.Items.Clear();
            foreach (Alternativa alternativa in questao.Alternativas)
            {
                if (alternativa.Correta)
                    listAlternativas.Items.Add($"{alternativa.Letra}: {alternativa.Descricao} [CORRETA]");
                else
                    listAlternativas.Items.Add($"{alternativa.Letra}: {alternativa.Descricao}");
            }
        }
    }
}
