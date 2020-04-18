using System;
using System.IO;
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

        public virtual async Task< bool > IsEmptyStringReceivedSinceAfterConnectionIsEstablishedUntilBeforeConnectionIsClosedUnilaterallyByRemoteHost()
        {
            return ( await GetStringReceivedSinceAfterConnectionIsEstablishedUntilBeforeConnectionIsClosedUnilaterallyByRemoteHost() ) == "";
        }

        private Task< string > GetStringReceivedSinceAfterConnectionIsEstablishedUntilBeforeConnectionIsClosedUnilaterallyByRemoteHost()
        {
            return ( new StreamReader( m_kStreamSocket.InputStream.AsStreamForRead() ) ).ReadToEndAsync();
        }

        public virtual void Disconnect()
        {
            m_kStreamSocket.Dispose();
        }
    }
}