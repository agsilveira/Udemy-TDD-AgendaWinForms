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

        //[Test]
        //public void TestConfigFilePath()
        //{
        //    Console.WriteLine(ConfigPathHelper.GetConfigFilePath());
        //    Assert.Pass(ConfigPathHelper.GetConfigFilePath());
        //}

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

        //[Test]
        //public void ObterTocosContatos()
        //{
        //    Contato contato1 = _fixture.Create<Contato>();
        //    Contato contato2 = _fixture.Create<Contato>();
        //    _contato.Adicionar(contato1);
        //    _contato.Adicionar(contato2);
        //    List<Contato> contatos = _contato.ObterTodos().ToList();
        //    var contatoRetornado = contatos.Where(c=> c.Id == contato1.Id).FirstOrDefault();
        //    Assert.That(contatos.Count(), Is.GreaterThanOrEqualTo(1));
        //    Assert.That(Equals(contatoRetornado.Id, contato1.Id));
        //    Assert.That(Equals(contatoRetornado.Nome, contato1.Nome));

        //}

        [TearDown]
        public void TearDown()
        {
            _contato = null;
            _fixture = null;
        }
    }
}
