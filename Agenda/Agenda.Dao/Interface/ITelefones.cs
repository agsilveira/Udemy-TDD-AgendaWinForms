using Agenda.Domain.Interface;

namespace Agenda.Dao.Interface
{
    public interface ITelefones
    {
        IList<ITelefone> ObiTerTodosDoContato(IContato contato);
    }
}
