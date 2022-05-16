using Testes_da_Mariana.Dominio.ModuloTeste;
using Testes_da_Mariana.Infra.Arquivos.Compartilhado;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes_da_Mariana.Infra.Arquivos.ModuloTeste
{
    public class RepositorioTesteEmArquivo : RepositorioEmArquivoBase<Teste>, IRepositorioTeste
    {
        public RepositorioTesteEmArquivo(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Testes.Count > 0)
                contador = dataContext.Testes.Max(x => x.Numero);
        }

        public override ValidationResult Inserir(Teste novoRegistro)
        {
            var resultadoValidacao = Validar(novoRegistro);

            if (resultadoValidacao.IsValid)
            {
                novoRegistro.Numero = ++contador;

                var registros = ObterRegistros();

                registros.Add(novoRegistro);
            }

            return resultadoValidacao;
        }

        public override ValidationResult Editar(Teste registro)
        {
            var resultadoValidacao = Validar(registro);

            if (resultadoValidacao.IsValid)
            {
                var registros = ObterRegistros();

                foreach (var item in registros)
                {
                    if (item.Numero == registro.Numero)
                    {
                        item.Atualizar(registro);
                        break;
                    }
                }
            }

            return resultadoValidacao;
        }

        private ValidationResult Validar(Teste registro)
        {
            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var enunciadoEncontrado = ObterRegistros()
               .Select(x => x.Titulo)
               .Contains(registro.Titulo);

            if (enunciadoEncontrado && registro.Numero == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Título já está cadastrado"));

            return resultadoValidacao;
        }

        public override List<Teste> ObterRegistros()
        {
            return dataContext.Testes;
        }

        //public override List<Teste> SelecionarTodos()
        //{
        //    return base.SelecionarTodos()
        //        .OrderByDescending(x => x.Materia)
        //        .ToList();
        //}

        public override AbstractValidator<Teste> ObterValidador()
        {
            return new ValidadorTeste();
        }

    }
}
