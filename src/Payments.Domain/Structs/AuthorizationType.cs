namespace Payments.Domain.Structs
{
    public struct AuthorizationType
    {
        public const int PAYMENT = 1;
        public const int REPAYMENT = 2;
        public const int REVERSE = 3;
        public const string INVALID_AUTHORIZATION_TYPE = "Invalid Authorization Type";

        public static bool IsPayment(int value) => value == PAYMENT;
        public static bool IsRePayment(int value) => value == REPAYMENT;
        public static bool IsReverse(int value) => value == REVERSE;

        public static int FromAuthorizationType(int authorizationType)
        {
            return authorizationType switch
            {
                PAYMENT => PAYMENT,
                REPAYMENT => REPAYMENT,
                REVERSE => REVERSE,
                _ => throw new NotImplementedException(INVALID_AUTHORIZATION_TYPE)
            };
        }
    }
}
