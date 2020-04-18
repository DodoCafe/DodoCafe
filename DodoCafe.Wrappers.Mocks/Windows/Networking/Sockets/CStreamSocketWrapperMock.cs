using System.Threading.Tasks;
using DodoCafe.Wrappers.Windows.Networking.Sockets;

namespace DodoCafe.Wrappers.Mocks.Windows.Networking.Sockets
{
    public class CStreamSocketWrapperMock : CStreamSocketWrapper
    {
        public bool IsCalledConnectAsync
        {
            get; set;
        }
        public bool IsCalledIsEmptyStringReceivedSinceAfterConnectionIsEstablishedUntilBeforeConnectionIsClosedUnilaterallyByRemoteHost
        {
            get; set;
        }
        public bool IsCalledDisconnect
        {
            get; set;
        }

        public CStreamSocketWrapperMock()
        {
            IsCalledConnectAsync = false;
            IsCalledIsEmptyStringReceivedSinceAfterConnectionIsEstablishedUntilBeforeConnectionIsClosedUnilaterallyByRemoteHost = false;
            IsCalledDisconnect = false;
        }

        public override async Task ConnectAsync( string strServerApplicationIp, int nServerApplicationPortNumber )
        {
            IsCalledConnectAsync = true;
        }

        public override async Task< bool > IsEmptyReceivedString()
        {
            IsCalledIsEmptyStringReceivedSinceAfterConnectionIsEstablishedUntilBeforeConnectionIsClosedUnilaterallyByRemoteHost = true;
            return true;
        }

        public override void Disconnect()
        {
            IsCalledDisconnect = true;
        }
    }
}