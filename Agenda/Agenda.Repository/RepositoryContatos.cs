using Agenda.Dao.Interface;
using Agenda.Domain.Interface;

namespace Agenda.Repository
{
    public class RepositoryContatos
    {
        private readonly IContatos _contatos;
        private readonly ITelefones _telefones;
        public RepositoryContatos(IContatos contatos, ITelefones telefones)
        {
            _contatos = contatos;
            _telefones = telefones;
        }

        public IContato ObterPorId(Guid id)
        {
            IContato contato = _contatos.Obter(id);
            IList<ITelefone> lstTelefones = _telefones.ObTerTodosDoContato(id);
            contato.Telefones = lstTelefones;
            return contato;
        }

    }
}
