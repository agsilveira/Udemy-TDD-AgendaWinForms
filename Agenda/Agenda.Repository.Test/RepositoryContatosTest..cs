using Agenda.Dao.Interface;
using Agenda.Domain.Interface;
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
        public void DeveSerPossivelObterContatoPorIdComTelefones()
        {
            //monta
            //Criar MoCk de IContato
            Mock<IContato> mContato = new Mock<IContato>();
            mContato.SetupGet(o => o.Id).Returns(Guid.NewGuid());
            mContato.SetupGet(o => o.Nome).Returns("João");
            //Criar Mock do metodo obter
            _contatos.Setup(o => o.Obter(It.IsAny<Guid>())).Returns(mContato.Object);

            // criar mock de Itelefone
            Mock<ITelefone> mTelefone = new Mock<ITelefone>();
            mTelefone.SetupGet(o=> o.Id).Returns(Guid.NewGuid());
            mTelefone.SetupGet(o => o.Numero).Returns("1234-1234");
            mTelefone.SetupGet(o => o.ContatoId).Returns(Guid.NewGuid());

            // mock do metodo ObTerTodosDoContato

            _telefones.Setup(o=>o.ObTerTodosDoContato(It.IsAny<Guid>())).Returns(new List<ITelefone> { mTelefone.Object });

            //execução
            //chamar o método ObiterPorId do repositorio
            IContato contatoRetornado= _repository.ObterPorId(Guid.NewGuid());
            Assert.That(Equals(mContato.Object.Id,contatoRetornado.Id));
            Assert.That(Equals(mContato.Object.Nome, contatoRetornado.Nome));

            //teste


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
