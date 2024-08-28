using Agenda.Dao.Interface;
using Moq;
using NUnit.Framework;

namespace Agenda.Repository.Test
{
    [TestFixture]
    public class RepositoryContatosTest
    {
        Mock<IContatos> _contatos;
        Mock<ITelefones> _telefones;
        RepositoryContatos _repository;
        [SetUp]
        public void Setup()
        {
            _contatos = new Mock<IContatos>();
            _telefones = new Mock<ITelefones>();
            _repository = new RepositoryContatos(_contatos.Object, _telefones.Object);
        }
        [Test]
        public void Teste()
        {
        }
        [TearDown]
        public void Teardown()
        {
            _contatos = null;
            _telefones = null;
            _repository = null;

        }

    }
}
