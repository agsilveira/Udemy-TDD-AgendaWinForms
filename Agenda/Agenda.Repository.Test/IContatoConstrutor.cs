using Agenda.Domain.Interface;
using AutoFixture;
using Moq;

namespace Agenda.Repository.Test
{
    public class IContatoConstrutor
    {
        Mock<IContato> _mockIContato;
        Fixture _fixture;
            public IContatoConstrutor(Mock<IContato> mockIContato, Fixture fixture)
        {
            _mockIContato = mockIContato;
            _fixture = fixture;
        }

        public static IContatoConstrutor GetIContato()
        {            
            return new IContatoConstrutor(new Mock<IContato>(), new Fixture());
        }
        public IContato Construir()
        {
            return _mockIContato.Object;
        }
        public Mock<IContato> Obter(){
            return _mockIContato;
        }
        public IContatoConstrutor GetIContatoFull()
        {
            _mockIContato.SetupGet(o => o.Id).Returns(_fixture.Create<Guid>());
            _mockIContato.SetupGet(o => o.Nome).Returns(_fixture.Create<string>);
            return this;
        }
       public IContatoConstrutor ComId(Guid id)
        {
            _mockIContato.SetupGet(o=> o.Id).Returns(id);
            return this;
        }
        public IContatoConstrutor ComNome(string nome)
        {
            _mockIContato.SetupGet(o => o.Nome).Returns(nome);
            return this;
        }



        //Mock<IContato> mContato = new Mock<IContato>();
        //mContato.SetupGet(o => o.Id).Returns(contatoId);
        //mContato.SetupGet(o => o.Nome).Returns("João");
        // -- moca um método set para recebimento de valor esterno
        // -- mContato.SetupSet(o => o.Telefones = It.IsAny<IList<ITelefone>>())
        //        .Callback<IList<ITelefone>>(p => lsTelefone = p);

    }
}
