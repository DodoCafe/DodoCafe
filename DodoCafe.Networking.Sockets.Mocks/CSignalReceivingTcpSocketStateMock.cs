using System.Threading.Tasks;

namespace DodoCafe.Networking.Sockets.Mocks
{
    public class CSignalReceivingTcpSocketStateMock : ISignalReceivingTcpSocketState
    {
        public bool IsCalledConnectAsync
        {
            get; set;
        }
        public bool IsCalledReceiveSignalAsync
        {
            get; set;
        }

        public CSignalReceivingTcpSocketStateMock()
        {
            IsCalledConnectAsync = false;
            IsCalledReceiveSignalAsync = false;
        }

        public async Task ConnectAsync( string strServerApplicationIpv4, int nServerApplicationPortNumber )
        {
            IsCalledConnectAsync = true;
        }

        public async Task ReceiveSignalAsync()
        {
            IsCalledReceiveSignalAsync = true;
        }
    }
}
