using System.Threading.Tasks;

namespace DodoCafe.Networking.Sockets.Mocks
{
    public class CSignalReceivingTcpSocketStateMock : ISignalReceivingTcpSocketState
    {
        public bool IsCalledConnectAsync
        {
            get; set;
        }

        public CSignalReceivingTcpSocketStateMock()
        {
            IsCalledConnectAsync = false;
        }

        public async Task ConnectAsync( string strServerApplicationIpv4, int nServerApplicationPortNumber )
        {
            IsCalledConnectAsync = true;
        }
    }
}
