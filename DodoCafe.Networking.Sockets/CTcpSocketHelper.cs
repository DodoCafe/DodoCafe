namespace DodoCafe.Networking.Sockets
{
    public static class CTcpSocketHelper
    {
        public static bool IsTcpPortNumber( int nPortNumber )
        {
            return 0 <= nPortNumber && nPortNumber <= 65535;
        }
    }
}