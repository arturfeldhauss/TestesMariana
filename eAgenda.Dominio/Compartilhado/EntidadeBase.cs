namespace Testes_da_Mariana.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public int Numero { get; set; }

        public abstract void Atualizar(T registro);

    }
}
