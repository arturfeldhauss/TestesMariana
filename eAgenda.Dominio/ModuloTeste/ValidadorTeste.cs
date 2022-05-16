using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes_da_Mariana.Dominio.ModuloTeste
{
    public class ValidadorTeste : AbstractValidator<Teste>
    {
        public ValidadorTeste()
        {
            RuleFor(x => x.Titulo)
                .NotNull().NotEmpty();

            RuleFor(x => x.NumeroQuestoes)
                .GreaterThan(0);

            RuleFor(x => x.Disciplina)
                .NotNull().NotEmpty();

            RuleFor(x => x.Materia)
                .NotNull().NotEmpty();

            RuleFor(x => x.Questoes)
                .NotNull().NotEmpty();

            RuleFor(x => x.Data)
                .NotNull()
                .NotEmpty()
                .GreaterThan(DateTime.Now);
        }
    }
}
