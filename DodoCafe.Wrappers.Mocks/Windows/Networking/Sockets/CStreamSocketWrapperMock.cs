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
        public bool IsCalledIsEmptyReceivedString
        {
            get; set;
        }

        public CStreamSocketWrapperMock()
        {
            IsCalledConnectAsync = false;
            IsCalledIsEmptyReceivedString = false;
        }

        public override async Task ConnectAsync( string strServerApplicationIp, int nServerApplicationPortNumber )
        {
            IsCalledConnectAsync = true;
        }

        public override async Task< bool > IsEmptyReceivedString()
        {
            IsCalledIsEmptyReceivedString = true;
            return true;
        }
    }
}