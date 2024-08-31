using Agenda.Domain.Interface;
using AutoFixture;

namespace Agenda.Repository.Test
{
    public class ITelefoneConstrutor : BaseConstrutor<ITelefone>
    {
        protected ITelefoneConstrutor() : base() { }

        public static ITelefoneConstrutor GetTelefone()
        {
            return new ITelefoneConstrutor();
        }

        public ITelefoneConstrutor TelefonePadrao()
        {
            _mock.SetupGet(o => o.Id).Returns(_fixture.Create<Guid>());
            _mock.SetupGet(o => o.Numero).Returns(_fixture.Create<string>());
            _mock.SetupGet(o => o.ContatoId).Returns(_fixture.Create<Guid>());
            return this;
        }
        public ITelefoneConstrutor ComId(Guid id)
        {
            _mock.SetupGet(o => o.Id).Returns(id);
            return this;
        }
        public ITelefoneConstrutor ComNumero(string numero)
        {
            _mock.SetupGet(o => o.Numero).Returns(numero);
            return this;
        }

        public ITelefoneConstrutor ComContatoId(Guid contatoId)
        {
            _mock.SetupGet(o => o.ContatoId).Returns(contatoId);
            return this;
        }


    }
}
