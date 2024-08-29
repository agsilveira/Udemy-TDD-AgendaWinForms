﻿using Agenda.Dao.Interface;
using Agenda.Domain.Interface;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;

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
        public void DeveSerPossivelObterContatoPorIdComTelefonesV2()
        {
            //versão bem detalhada para o entendimento do mock
            IList<ITelefone> lsTelefone = new List<ITelefone>();
            //monta
            //Criar MoCk de IContato
            Mock<IContato> mContato = new Mock<IContato>();
            mContato.SetupGet(o => o.Id).Returns(Guid.NewGuid());
            mContato.SetupGet(o => o.Nome).Returns("João");
            //moca um método set para recebimento de valor esterno
            mContato.SetupSet(o => o.Telefones = It.IsAny<IList<ITelefone>>())
                .Callback<IList<ITelefone>>(p => lsTelefone = p);// quando SetupSet for chamado ele vai colocar o valor recebido na variavel

            //Criar Mock do metodo obter
            _contatos.Setup(o => o.Obter(It.IsAny<Guid>())).Returns(mContato.Object);

            // criar mock de Itelefone
            Mock<ITelefone> mTelefone = new Mock<ITelefone>();
            mTelefone.SetupGet(o => o.Id).Returns(Guid.NewGuid());
            mTelefone.SetupGet(o => o.Numero).Returns("1234-1234");
            mTelefone.SetupGet(o => o.ContatoId).Returns(Guid.NewGuid());

            // mock do metodo ObTerTodosDoContato

            _telefones.Setup(o => o.ObTerTodosDoContato(It.IsAny<Guid>())).Returns(new List<ITelefone> { mTelefone.Object });

            //execução
            //chamar o método ObiterPorId do repositorio
            IContato contatoRetornado = _repository.ObterPorId(Guid.NewGuid());

            //quando chamar ObterPorId esse irar chamar o set de telefones, agora nós configuramos o get para mostra retornar esse valor
            mContato.SetupGet(o => o.Telefones).Returns(lsTelefone);

            //teste
            Assert.That(Equals(mContato.Object.Id, contatoRetornado.Id));
            Assert.That(Equals(mContato.Object.Nome, contatoRetornado.Nome));
            Assert.That(Equals(1, contatoRetornado.Telefones.Count));
        }
        [Test]
        public void DeveSerPossivelObterContatoPorIdComTelefonesV1()
        {
            //versão bem detalhada para o entendimento do mock
            //essa valida somente se o metodo traz dados passados pelo Mock
            // v2 será um pouco mais  enchuta a´té termos uma versão final
            // para ficar como exemplo .

            IList<ITelefone> lsTelefone = new List<ITelefone>(); 
            //monta
            //Criar MoCk de IContato
            Mock<IContato> mContato = new Mock<IContato>();
            mContato.SetupGet(o => o.Id).Returns(Guid.NewGuid());
            mContato.SetupGet(o => o.Nome).Returns("João");
            //moca um método set para recebimento de valor esterno
            mContato.SetupSet(o => o.Telefones = It.IsAny<IList<ITelefone>>())
                .Callback<IList<ITelefone>>(p => lsTelefone = p);// quando SetupSet for chamado ele vai colocar o valor recebido na variavel

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

            //quando chamar ObterPorId esse irar chamar o set de telefones, agora nós configuramos o get para mostra retornar esse valor
            mContato.SetupGet(o => o.Telefones).Returns(lsTelefone);

            //teste
            Assert.That(Equals(mContato.Object.Id, contatoRetornado.Id));
            Assert.That(Equals(mContato.Object.Nome, contatoRetornado.Nome));
            Assert.That(Equals(1, contatoRetornado.Telefones.Count));
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
