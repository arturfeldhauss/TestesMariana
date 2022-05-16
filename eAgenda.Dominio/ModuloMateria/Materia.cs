using Testes_da_Mariana.Dominio.Compartilhado;
using Testes_da_Mariana.Dominio.ModuloDisciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes_da_Mariana.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public string Nome { get; set; }
        public Disciplina Disciplina { get; set; }
        public TipoSerieEnum Serie { get; set; }

        public override void Atualizar(Materia registro)
        {
            Nome = registro.Nome;
            Disciplina = registro.Disciplina;
            Serie = registro.Serie;
        }

        public override string ToString()
        {
            return $"{Nome}";
        }
    }
}
