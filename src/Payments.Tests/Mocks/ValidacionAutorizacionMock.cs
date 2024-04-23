using Payments.Application.DTOs;

namespace Payments.Tests.Mocks
{
    public class ValidacionAutorizacionMock
    {
        public static object[] Autorizacion_De_Compra_Aprobado_Cliente_Tipo1()
        {
            var paymentAuthorization = new PaymentAuthorizationDTO
            {
                Approved = true,
            };

            return new object[]
            {
                new object[]
                {
                    new AuthorizationRequestDTO
                    {
                        ClientId = "123456",
                        Amount = 450,
                        AuthorizationType = 1,
                        ClientType = 1
                    },
                    new PaymentAuthorizationDTO
                    {
                        Approved = true,
                    },
                    new AuthorizationResponseDTO(paymentAuthorization)
                },
            };
        }
        
        public static object[] Autorizacion_De_Compra_Denegado_Cliente_Tipo1()
        {
            var paymentAuthorization = new PaymentAuthorizationDTO
            {
                Approved = false,
            };

            return new object[]
            {
                new object[]
                {
                    new AuthorizationRequestDTO
                    {
                        ClientId = "123456",
                        Amount = 377,
                        AuthorizationType = 1,
                        ClientType = 1
                    },
                    paymentAuthorization,
                    new AuthorizationResponseDTO(paymentAuthorization)
                },
            };
        }

        public static object[] Autorizacion_De_Compra_Aprobado_Cliente_Tipo2()
        {
            var paymentAuthorization = new PaymentAuthorizationDTO
            {
                Approved = true,
            };

            return new object[]
            {
                new object[]
                {
                    new AuthorizationRequestDTO
                    {
                        ClientId = "123456",
                        Amount = 450,
                        AuthorizationType = 1,
                        ClientType = 2
                    },
                    new PaymentAuthorizationDTO
                    {
                        Approved = true,
                    },
                    new AuthorizationResponseDTO(paymentAuthorization)
                },
            };
        }
    }
}
