using System;
using System.Threading.Tasks;

namespace DodoCafe.Networking.Sockets
{
    public partial class CSignalReceivingTcpSocket
    {
        public class CSignalReceivingTcpSocketDisconnectingState : ISignalReceivingTcpSocketState
        {
            private CSignalReceivingTcpSocket m_kSocket;

            public CSignalReceivingTcpSocketDisconnectingState( CSignalReceivingTcpSocket kSocket )
            {
                if ( kSocket == null )
                {
                    throw new ArgumentNullException( CDefinitions.ERROR_SIGNAL_RECEIVING_TCP_SOCKET_IS_NULL );
                }
                m_kSocket = kSocket;
            }

            public async Task ConnectAsync( string strServerApplicationIpv4, int nServerApplicationPortNumber )
            {
                await m_kSocket.CallStreamSocketConnectAsync( strServerApplicationIpv4, nServerApplicationPortNumber );
                m_kSocket.ChangeStateToConnecting();
            }

            public async Task ReceiveSignalAsync()
            {
            }
        }
    }
}
