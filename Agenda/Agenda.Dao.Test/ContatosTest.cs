using Agenda.Domain;
using AutoFixture;
using NUnit.Framework;

namespace Agenda.Dao.Test
{
    [TestFixture]
    public class ContatosTest:BaseTest
    {

        Contatos _contato;
        Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _contato = new Contatos();
            _fixture = new Fixture();
        }
       

        [Test]
        public void AdicionarContatoTest()
        {
            //monta
            Contato contato = _fixture.Create<Contato>();

            //execução
            _contato.Adicionar(contato);

            //teste
            Assert.Pass("Este teste sempre passará.");
        }

        [Test]
        public void ObterContatoTest()
        {
            Contato contato = _fixture.Create<Contato>();
            var contatoRetornado = new Contato();


            _contato.Adicionar(contato);
            contatoRetornado = _contato.Obter(contato.Id.ToString());

            Assert.That(Equals(contatoRetornado.Id, contato.Id));
            Assert.That(Equals(contatoRetornado.Nome, contato.Nome));
        }

        

        [TearDown]
        public void TearDown()
        {
            _contato = null;
            _fixture = null;
        }
    }
}
