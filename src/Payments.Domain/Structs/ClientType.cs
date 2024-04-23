namespace Payments.Domain.Structs
{
    public struct ClientType
    {
        public const int FirstClient = 1;
        public const int SecondClient = 2;

        public static bool IsFirstClient(int value) => value == FirstClient;
        public static bool IsSecondClient(int value) => value == SecondClient;
    }
}
