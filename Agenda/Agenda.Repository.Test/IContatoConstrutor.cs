using Agenda.Domain.Interface;
using AutoFixture;

namespace Agenda.Repository.Test
{
    public class IContatoConstrutor:BaseConstrutor<IContato>
    {

        public IContatoConstrutor():base(){}

        public static IContatoConstrutor GetIContato()
        {
            return new IContatoConstrutor();// new Mock<IContato>());
        }
       
        public IContatoConstrutor GetIContatoFull()
        {
            _mock.SetupGet(o => o.Id).Returns(_fixture.Create<Guid>());
            _mock.SetupGet(o => o.Nome).Returns(_fixture.Create<string>);
            return this;
        }
       public IContatoConstrutor ComId(Guid id)
        {
            _mock.SetupGet(o=> o.Id).Returns(id);
            return this;
        }
        public IContatoConstrutor ComNome(string nome)
        {
            _mock.SetupGet(o => o.Nome).Returns(nome);
            return this;
        }


    }
}
