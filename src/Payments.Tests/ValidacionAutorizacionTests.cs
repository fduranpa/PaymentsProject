using Moq;
using Payments.Application.DTOs;
using Payments.Application.Gateways;
using Payments.Application.Interactors;
using Payments.Tests.Mocks;

namespace Payments.Tests
{
    public class ValidacionAutorizacionTests
    {
        private Mock<IPaymentProcessorService> _paymentProcessorService;
        private Mock<IAuthorizationGateway> _authorizationGateway;

        [SetUp]
        public void Setup()
        {
            _paymentProcessorService = new Mock<IPaymentProcessorService>();
            _authorizationGateway = new Mock<IAuthorizationGateway>();
        }

        [Category("Validacion Autorizacion de Compra - Aprobado"), TestCaseSource(typeof(ValidacionAutorizacionMock), nameof(ValidacionAutorizacionMock.Autorizacion_De_Compra_Aprobado_Cliente_Tipo1))]
        [Category("Validacion Autorizacion de Compra - Denegado"), TestCaseSource(typeof(ValidacionAutorizacionMock), nameof(ValidacionAutorizacionMock.Autorizacion_De_Compra_Denegado_Cliente_Tipo1))]
        [Category("Validacion Autorizacion de Compra Tipo Reversa - Aprobada"), TestCaseSource(typeof(ValidacionAutorizacionMock), nameof(ValidacionAutorizacionMock.Autorizacion_De_Compra_Aprobado_Cliente_Tipo2))]
        public async Task ValidarAutorizacionDeCompra(
            AuthorizationRequestDTO authorizationRequest, 
            PaymentAuthorizationDTO paymentAuthorization,
            AuthorizationResponseDTO salidaEsperada
            )
        {
            _authorizationGateway.Setup(x => x.RegisterAuthorization(It.IsAny<AuthorizationRequestDTO>(), It.IsAny<bool>()));

            _paymentProcessorService
                .Setup(x => x.ValidatePaymentAuthorization(It.IsAny<decimal>()))
                .ReturnsAsync(paymentAuthorization);

            var validacionAutorizacionCompra = new GetAuthorizationInteractor(_paymentProcessorService.Object, _authorizationGateway.Object);
            var resultado = await validacionAutorizacionCompra.Execute(authorizationRequest);

            Assert.That(salidaEsperada.Approved, Is.EqualTo(resultado.Approved));
        }
    }
}