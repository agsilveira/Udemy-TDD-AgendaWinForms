using Agenda.Domain.Interface;
using AutoFixture;
using Moq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Agenda.Repository.Test
{
    public class ITelefoneConstrutor
    {
       private readonly Mock<ITelefone> _mockTelefone;
        private readonly Fixture _fixture;

        public ITelefoneConstrutor(Mock<ITelefone> Telefone, Fixture fixture)
        {
            _mockTelefone = Telefone;
            _fixture = fixture;

        }
        public ITelefone Construir() {  return _mockTelefone.Object; }

        public static ITelefoneConstrutor GetTelefone() { return new ITelefoneConstrutor(new Mock<ITelefone>(), new Fixture()); }

        public ITelefoneConstrutor TelefonePadrao()
        {
            _mockTelefone.SetupGet(o => o.Id).Returns(_fixture.Create<Guid>());
            _mockTelefone.SetupGet(o => o.Numero).Returns(_fixture.Create<string>());
            _mockTelefone.SetupGet(o => o.ContatoId).Returns(_fixture.Create<Guid>());
            return this;
        }
        public ITelefoneConstrutor ComId (Guid id){
            _mockTelefone.SetupGet(o => o.Id).Returns(id);
            return this;
        }
        public ITelefoneConstrutor ComNumero(string numero)
        {
            _mockTelefone.SetupGet(o => o.Numero).Returns(numero);
            return this;
        }

        public ITelefoneConstrutor ComContatoId(Guid contatoId)
        {
            _mockTelefone.SetupGet(o => o.ContatoId).Returns(contatoId);
            return this;
        }

       
    }
}
