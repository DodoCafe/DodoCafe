using System.Threading.Tasks;

namespace DodoCafe.Networking.Sockets.Mocks
{
    public class CSignalReceivingTcpSocketMock : CSignalReceivingTcpSocket
    {
        public bool IsCalledCallStreamSocketConnectAsync
        {
            get; set;
        }
        public bool IsCalledChangeStateToConnecting
        {
            get; set;
        }

        public CSignalReceivingTcpSocketMock()
        {
            IsCalledCallStreamSocketConnectAsync = false;
            IsCalledChangeStateToConnecting = false;
        }

        protected override void ChangeStateToConnecting()
        {
            IsCalledChangeStateToConnecting = true;
        }

        protected override async Task CallStreamSocketConnectAsync( string strServerApplicationIpv4, int nServerApplicationPortNumber )
        {
            IsCalledCallStreamSocketConnectAsync = true;
        }
    }
}