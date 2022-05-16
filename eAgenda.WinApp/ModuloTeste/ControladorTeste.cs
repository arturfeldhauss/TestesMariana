using Testes_da_Mariana.Dominio.ModuloDisciplina;
using Testes_da_Mariana.Dominio.ModuloMateria;
using Testes_da_Mariana.Dominio.ModuloQuestao;
using Testes_da_Mariana.Dominio.ModuloTeste;
using Testes_da_Mariana.WinApp.Compartilhado;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testes_da_Mariana.WinApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        private TabelaTestesControl tabelaTestes;
        private IRepositorioTeste repositorioTeste;
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioMateria repositorioMateria;
        private IRepositorioQuestao repositorioQuestao;

        public ControladorTeste(IRepositorioTeste repositorioTeste, IRepositorioDisciplina repositorioDisciplina, IRepositorioMateria repositorioMateria, IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioTeste = repositorioTeste;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
            this.repositorioQuestao = repositorioQuestao;
        }

        public override void Inserir()
        {
            var disciplinas = repositorioDisciplina.SelecionarTodos();
            var materias = repositorioMateria.SelecionarTodos();

            TelaCadastroTesteForm tela = new TelaCadastroTesteForm(disciplinas, materias, repositorioQuestao);
            tela.Teste = new Teste();

            tela.GravarRegistro = repositorioTeste.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarQuestoes();
            }
        }

        public override void Editar()
        {
            Teste testeSelecionada = ObtemTesteSelecionada();

            if (testeSelecionada == null)
            {
                MessageBox.Show("Selecione um teste primeiro",
                "Edição de Questões", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var disciplinas = repositorioDisciplina.SelecionarTodos();
            var materias = repositorioMateria.SelecionarTodos();

            TelaCadastroTesteForm tela = new TelaCadastroTesteForm(disciplinas, materias, repositorioQuestao);

            tela.Teste = testeSelecionada;

            tela.GravarRegistro = repositorioTeste.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarQuestoes();
            }
        }

        public override void Excluir()
        {
            Teste testeSelecionada = ObtemTesteSelecionada();

            if (testeSelecionada == null)
            {
                MessageBox.Show("Selecione um teste primeiro",
                "Exclusão de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a questão?",
                "Exclusão de Tarefas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTeste.Excluir(testeSelecionada);
                CarregarQuestoes();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxTeste();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaTestes == null)
                tabelaTestes = new TabelaTestesControl();

            CarregarQuestoes();

            return tabelaTestes;
        }

        public void CarregarQuestoes()
        {
            List<Teste> questoes = repositorioTeste.SelecionarTodos();

            tabelaTestes.AtualizarRegistros(questoes);
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {questoes.Count} questões(s)");
        }

        public Teste ObtemTesteSelecionada()
        {
            if (tabelaTestes == null)
                tabelaTestes = new TabelaTestesControl();

            var numero = tabelaTestes.ObtemNumeroTesteSelecionado();

            return repositorioTeste.SelecionarPorNumero(numero);
        }

        public void GerarPdf()
        {
            Teste testeSelecionada = ObtemTesteSelecionada();

            if (testeSelecionada == null)
            {
                MessageBox.Show("Selecione um teste primeiro",
                "Gerador de PDF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string arquivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $@"\{testeSelecionada.Titulo}.pdf";
            if(File.Exists(arquivo))
                File.Delete(arquivo);

            Document document = new Document(PageSize.A4);
            document.SetMargins(25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(arquivo, FileMode.Create, FileAccess.ReadWrite));
            document.Open();

            Font fonte = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 14);

            Paragraph tituloProva = new Paragraph(testeSelecionada.Titulo, fonte);
            tituloProva.Alignment = Element.ALIGN_CENTER;

            Chunk glue = new Chunk(new VerticalPositionMark());
            Paragraph informacoesProva = new Paragraph($"Disciplina: {testeSelecionada.Disciplina.Nome}", fonte);
            informacoesProva.Add(new Chunk(glue));
            informacoesProva.Add($"Matéria: {testeSelecionada.Materia.Nome}");
            Paragraph dataProva = new Paragraph($"Data da Prova: {testeSelecionada.Data.Day}/{testeSelecionada.Data.Month}/{testeSelecionada.Data.Year}", fonte);

            document.Add(tituloProva);
            document.Add(informacoesProva);
            document.Add(dataProva);
            document.Add(new Paragraph(Environment.NewLine));

            for (int i = 0; i < testeSelecionada.Questoes.Count; i++)
            {
                Paragraph questao = new Paragraph($"Questão {i + 1}: {testeSelecionada.Questoes[i].Enunciado}", fonte);
                document.Add(questao);
                foreach (var alternativa in testeSelecionada.Questoes[i].Alternativas)
                {
                    Paragraph alternativaQuestao = new Paragraph($"{alternativa.Letra}: {alternativa.Descricao}", fonte);
                    document.Add(alternativaQuestao);
                }
                document.Add(new Paragraph(Environment.NewLine));
            }

            document.NewPage();
            Paragraph gabarito = new Paragraph("Gabarito", fonte);
            gabarito.Alignment = Element.ALIGN_CENTER;
            document.Add(gabarito);

            for (int i = 0; i < testeSelecionada.Questoes.Count; i++)
            {
                Paragraph questao = new Paragraph($"Questão {i + 1}: {testeSelecionada.Questoes[i].Enunciado}", fonte);
                document.Add(questao);
                
                Alternativa alternativaCorreta;
                alternativaCorreta = testeSelecionada.Questoes[i].Alternativas.Find(x => x.Correta);

                Paragraph alternativaQuestao = new Paragraph($"{alternativaCorreta.Letra}: {alternativaCorreta}", fonte);
                document.Add(alternativaQuestao);
            }

            document.Close();
        }

        public void DuplicarTeste()
        {
            Teste testeSelecionada = ObtemTesteSelecionada();
            Teste testeDuplicado = (Teste) testeSelecionada.Clone();

            if (testeSelecionada == null)
            {
                MessageBox.Show("Selecione um teste primeiro",
                "Duplicador de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var disciplinas = repositorioDisciplina.SelecionarTodos();
            var materias = repositorioMateria.SelecionarTodos();
            var questoes = repositorioQuestao.SelecionarTodos();

            TelaCadastroTesteForm tela = new TelaCadastroTesteForm(disciplinas, materias, repositorioQuestao);

            tela.Teste = testeDuplicado;

            tela.GravarRegistro = repositorioTeste.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarQuestoes();
            }
        }

    }
}
