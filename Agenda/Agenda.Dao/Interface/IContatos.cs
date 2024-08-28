using Agenda.Domain;
using Agenda.Domain.Interface;

namespace Agenda.Dao.Interface
{
    public interface IContatos
    {
        void Adicionar(IContato contato);
        IContato Obter(Guid id);
        IList<IContato> ObterTodos();
    }
}
