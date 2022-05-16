using Testes_da_Mariana.Dominio.ModuloDisciplina;
using Testes_da_Mariana.Dominio.ModuloMateria;
using Testes_da_Mariana.Dominio.ModuloQuestao;
using Testes_da_Mariana.Dominio.ModuloTeste;
using Testes_da_Mariana.Infra.Arquivos.Compartilhado.Serializadores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Testes_da_Mariana.Infra.Arquivos.Compartilhado
{
    [Serializable]
    public class DataContext //Container
    {
        private readonly ISerializador serializador;

        public DataContext()
        {
            Questoes = new List<Questao>();
            Disciplinas = new List<Disciplina>();
            Materias = new List<Materia>();
            Testes = new List<Teste>();
        }

        public DataContext(ISerializador serializador) : this()
        {
            this.serializador = serializador;

            CarregarDados();
        }

        public List<Questao> Questoes { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
        public List<Materia> Materias { get; set; }
        public List<Teste> Testes { get; set; }

        public void GravarDados()
        {
            serializador.GravarDadosEmArquivo(this);
        }

        private void CarregarDados()
        {
            var ctx = serializador.CarregarDadosDoArquivo();

            if (ctx.Disciplinas.Any())
                Disciplinas.AddRange(ctx.Disciplinas);

            if (ctx.Materias.Any())
                Materias.AddRange(ctx.Materias);

            if (ctx.Questoes.Any())
                Questoes.AddRange(ctx.Questoes);

            if (ctx.Testes.Any())
                Testes.AddRange(ctx.Testes);
        }
    }
}
