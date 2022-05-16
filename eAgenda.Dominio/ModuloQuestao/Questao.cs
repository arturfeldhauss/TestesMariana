using Testes_da_Mariana.Dominio.Compartilhado;
using Testes_da_Mariana.Dominio.ModuloDisciplina;
using Testes_da_Mariana.Dominio.ModuloMateria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes_da_Mariana.Dominio.ModuloQuestao
{
    public class Questao : EntidadeBase<Questao>
    {
        private List<Alternativa> _alternativas;

        public string Enunciado { get; set; }
        public Disciplina Disciplina { get; set; }
        public Materia Materia { get; set; }

        public List<Alternativa> Alternativas { get => _alternativas; set => _alternativas = value; }

        public void AdicionarAlternativa(Alternativa alternativaParaInserir)
        {
            if(Alternativas.Exists(x => x.Equals(alternativaParaInserir)) == false)
                _alternativas.Add(alternativaParaInserir);
        }

        public override void Atualizar(Questao registro)
        {
            Enunciado = registro.Enunciado;
            Disciplina = registro.Disciplina;
            Materia = registro.Materia;
        }

        public override string ToString()
        {
            return Enunciado;
        }

    }
}
