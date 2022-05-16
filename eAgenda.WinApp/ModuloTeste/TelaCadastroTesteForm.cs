using Testes_da_Mariana.Dominio.ModuloDisciplina;
using Testes_da_Mariana.Dominio.ModuloMateria;
using Testes_da_Mariana.Dominio.ModuloQuestao;
using Testes_da_Mariana.Dominio.ModuloTeste;
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

namespace Testes_da_Mariana.WinApp.ModuloTeste
{
    public partial class TelaCadastroTesteForm : Form
    {
        private Teste teste;
        private IRepositorioQuestao repositorioQuestao;
        List<Questao> questoesTeste = new List<Questao>();

        public TelaCadastroTesteForm(List<Disciplina> disciplinas, List<Materia> materias, IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioQuestao = repositorioQuestao;

            InitializeComponent();
            CarregarDisciplinas(disciplinas);
            CarregarMaterias(materias);
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

        public Func<Teste, ValidationResult> GravarRegistro { get; set; }

        public Teste Teste
        {
            get
            {
                return teste;
            }
            set
            {
                teste = value;
                txtNumero.Text = teste.Numero.ToString();
                txtTitulo.Text = teste.Titulo;
                comboDisciplina.SelectedItem = teste.Disciplina;
                comboMateria.SelectedItem = teste.Materia;
                dateData.Value = teste.Data;
                txtNrQuestoes.Text = teste.NumeroQuestoes.ToString();
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            teste.Titulo = txtTitulo.Text;
            teste.Disciplina = (Disciplina) comboDisciplina.SelectedItem;
            teste.Materia = (Materia) comboMateria.SelectedItem;
            teste.Data = dateData.Value;
            teste.NumeroQuestoes = int.Parse(txtNrQuestoes.Text);
            teste.Questoes = questoesTeste;

            var resultadoValidacao = GravarRegistro(teste);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroTesteForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroTesteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void btnGerarQuestoes_Click(object sender, EventArgs e)
        {
            listQuestoes.Items.Clear();

            int countNumeroQuestao = 1;

            var questoes = repositorioQuestao.SelecionarTodos()
                            .Where(x => x.Disciplina.Nome == comboDisciplina.Text)
                            .Where(x => x.Materia.Nome == comboMateria.Text)
                            .ToList();

            var random = new Random();
            var questoesEmbaralhadas = questoes.OrderBy(item => random.Next()).ToList();

            for (int i = 0; i < int.Parse(txtNrQuestoes.Text); i++)
            {
                questoesTeste.Add(questoesEmbaralhadas.ElementAt(i));
            }

            listQuestoes.Items.Clear();

            foreach (var item in questoesTeste)
            {
                listQuestoes.Items.Add(countNumeroQuestao + "- " + item.ToString());
                countNumeroQuestao++;
            }
        }
    }
}
