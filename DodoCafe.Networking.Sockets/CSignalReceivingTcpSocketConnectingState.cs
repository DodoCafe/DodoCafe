using System;
using System.Threading.Tasks;

namespace DodoCafe.Networking.Sockets
{
    public partial class CSignalReceivingTcpSocket
    {
        public class CSignalReceivingTcpSocketConnectingState : ISignalReceivingTcpSocketState
        {
            private static string ERROR_CONNECT_ASYNC_IS_CALLED_IN_SIGNAL_RECEIVING_TCP_SOCKET_CONNECTING_STATE = "Connect is called in the connecting state of a signal receiving TCP socket";
            private CSignalReceivingTcpSocket m_kSocket;

            public CSignalReceivingTcpSocketConnectingState( CSignalReceivingTcpSocket kSocket )
            {
                if ( kSocket == null )
                {
                    throw new ArgumentNullException( CDefinitions.ERROR_SIGNAL_RECEIVING_TCP_SOCKET_IS_NULL );
                }
                m_kSocket = kSocket;
            }

            public async Task ConnectAsync( string strServerApplicationIpv4, int nServerApplicationPortNumber )
            {
                throw new InvalidOperationException( ERROR_CONNECT_ASYNC_IS_CALLED_IN_SIGNAL_RECEIVING_TCP_SOCKET_CONNECTING_STATE );
            }

            public async Task ReceiveSignalAsync()
            {
                await m_kSocket.ReceiveNonEmptyStringSinceAfterConnectionIsEstablishedUntilBeforeConnectionIsClosedUnilaterallyByRemoteHost();
            }

            public void Disconnect()
            {
                m_kSocket.CallStreamSocketDisconnect();
            }
        }
    }
}
