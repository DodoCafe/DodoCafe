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
        public bool IsCalledReceiveNonEmptyStringSinceAfterConnectionIsEstablishedUntilBeforeConnectionIsClosedUnilaterallyByRemoteHost
        {
            get; set;
        }
        public bool IsCalledCallStreamSocketDisconnect
        {
            get; set;
        }
        public bool IsCalledChangeStateToDisconnecting
        {
            get; set;
        }

        public CSignalReceivingTcpSocketMock()
        {
            IsCalledCallStreamSocketConnectAsync = false;
            IsCalledChangeStateToConnecting = false;
            IsCalledReceiveNonEmptyStringSinceAfterConnectionIsEstablishedUntilBeforeConnectionIsClosedUnilaterallyByRemoteHost = false;
            IsCalledCallStreamSocketDisconnect = false;
            IsCalledChangeStateToDisconnecting = false;
        }

        protected override void ChangeStateToConnecting()
        {
            IsCalledChangeStateToConnecting = true;
        }

        protected override async Task CallStreamSocketConnectAsync( string strServerApplicationIpv4, int nServerApplicationPortNumber )
        {
            IsCalledCallStreamSocketConnectAsync = true;
        }

        protected override async Task ReceiveNonEmptyStringSinceAfterConnectionIsEstablishedUntilBeforeConnectionIsClosedUnilaterallyByRemoteHost()
        {
            IsCalledReceiveNonEmptyStringSinceAfterConnectionIsEstablishedUntilBeforeConnectionIsClosedUnilaterallyByRemoteHost = true;
        }
    }
}