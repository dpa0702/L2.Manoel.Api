using L2.Manoel.Core.Entities;
using L2.Manoel.EmbalagemMS.Controllers;
using L2.Manoel.EmbalagemMS.Services.Interfaces;
using L2.Manoel.Tests.Entities.Mock;
using Moq;

namespace L2.Manoel.Tests
{
    [TestClass]
    public class UnitTest1
    {
        EntryController? entryController;
        private Mock<IEntryService> _mockEntryService;

        [TestInitialize]
        public void Start()
        {
            _mockEntryService = new Mock<IEntryService>();

            entryController = new EntryController(_mockEntryService.Object);
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var pedidoMock = new PedidoMock();
            var entry = new Pedido { pedido_id = 1, produtos = new List<Produto>() };
            var entry2 = new Pedido { pedido_id = 2, produtos = new List<Produto>() };

            var pedidos = new List<Pedido>();
            pedidos.Add(entry);
            pedidos.Add(entry2);

            var cancellationToken = new CancellationToken();

            _mockEntryService.Setup(service => service.EmpacotarLoteDePedidos(pedidos, cancellationToken));

            //// Act
            var result = entryController?.Ok(entry);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}