using System;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;

namespace DodoCafe.Wrappers.Windows.Networking.Sockets
{
    public class CStreamSocketWrapper
    {
        private StreamSocket m_kStreamSocket;

        public CStreamSocketWrapper()
        {
            m_kStreamSocket = new StreamSocket();
        }

        public virtual async Task ConnectAsync( string strServerApplicationIp, int nServerApplicationPortNumber )
        {
            await m_kStreamSocket.ConnectAsync( new HostName( strServerApplicationIp ), nServerApplicationPortNumber.ToString() );
        }
    }
}
