using Testes_da_Mariana.Dominio.Compartilhado;
using Testes_da_Mariana.Dominio.ModuloDisciplina;
using Testes_da_Mariana.Dominio.ModuloMateria;
using Testes_da_Mariana.Dominio.ModuloQuestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes_da_Mariana.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>, ICloneable
    {
        public int NumeroQuestoes { get; set; }
        public string Titulo { get; set; }
        public Disciplina Disciplina { get; set; }
        public Materia Materia { get; set; }
        public DateTime Data { get; set; }
        public List<Questao> Questoes { get; set; }

        public Teste()
        {
            Data = DateTime.Now;
        }

        private Teste(Teste registro)
        {
            Titulo = registro.Titulo;
            Disciplina = registro.Disciplina;
            Materia = registro.Materia;
            Data = DateTime.Now;
            Questoes = registro.Questoes;
            NumeroQuestoes = registro.NumeroQuestoes;
        }

        public override void Atualizar(Teste registro)
        {
            Titulo = registro.Titulo;
            Disciplina = registro.Disciplina;
            Materia = registro.Materia;
            Data = registro.Data;
            Questoes = registro.Questoes;
            NumeroQuestoes = registro.NumeroQuestoes;
        }

        public object Clone()
        {
            return new Teste(this);
        }
    }
}
