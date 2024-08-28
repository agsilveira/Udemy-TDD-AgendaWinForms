using Agenda.Domain;
using Agenda.Domain.Interface;

namespace Agenda.Dao.Interface
{
    public interface IContatos
    {
        void Adicionar(IContato contato);
        IContato Obter(string id);
        IList<IContato> ObterTodos();
    }
}
