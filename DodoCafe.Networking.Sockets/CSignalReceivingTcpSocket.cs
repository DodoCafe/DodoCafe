#if WINDOWS_UWP
using DodoCafe.Wrappers.Windows.Networking.Sockets;
using System;
#endif
using System.Threading.Tasks;

namespace DodoCafe.Networking.Sockets
{
    public partial class CSignalReceivingTcpSocket
    {
#if WINDOWS_UWP
        private static string ERROR_SERVER_APPLICATION_IP_IS_NOT_IPV4 = "The given server application IP is not an IPv4";
        private static string ERROR_SERVER_APPLICATION_PORT_NUMBER_IS_NOT_TCP_PORT_NUMBER = "The given server application port number is not a TCP port number";
        private static string ERROR_RECEIVED_STRING_IS_EMPTY = "The string received since after connection is established until before connection is closed unilaterally by the remote host is empty";
        private CStreamSocketWrapper m_kStreamSocket;
        private ISignalReceivingTcpSocketState m_kState;
#endif

        public CSignalReceivingTcpSocket()
        {
#if WINDOWS_UWP
            m_kStreamSocket = new CStreamSocketWrapper();
            ChangeStateToDisconnecting();
#endif
        }

        public async Task ConnectAsync( string strServerApplicationIpv4, int nServerApplicationPortNumber )
        {
#if WINDOWS_UWP
            await m_kState.ConnectAsync( strServerApplicationIpv4, nServerApplicationPortNumber );
#endif
        }

        public async Task ReceiveSignalAsync()
        {
#if WINDOWS_UWP
            await m_kState.ReceiveSignalAsync();
#endif
        }

        public void Disconnect()
        {
#if WINDOWS_UWP
            m_kState.Disconnect();
#endif
        }

#if WINDOWS_UWP
        protected virtual void ChangeStateToConnecting()
        {
            m_kState = new CSignalReceivingTcpSocketConnectingState( this );
        }

        protected virtual void ChangeStateToDisconnecting()
        {
            m_kState = new CSignalReceivingTcpSocketDisconnectingState( this );
        }

        protected virtual async Task CallStreamSocketConnectAsync( string strServerApplicationIpv4, int nServerApplicationPortNumber )
        {
            if ( !CIpAddressHelper.IsIpv4( strServerApplicationIpv4 ) )
            {
                throw new ArgumentException( ERROR_SERVER_APPLICATION_IP_IS_NOT_IPV4 );
            }
            if ( !CTcpSocketHelper.IsTcpPortNumber( nServerApplicationPortNumber ) )
            {
                throw new ArgumentException( ERROR_SERVER_APPLICATION_PORT_NUMBER_IS_NOT_TCP_PORT_NUMBER );
            }
            await m_kStreamSocket.ConnectAsync( strServerApplicationIpv4, nServerApplicationPortNumber );
        }

        protected virtual async Task ReceiveNonEmptyStringSinceAfterConnectionIsEstablishedUntilBeforeConnectionIsClosedUnilaterallyByRemoteHost()
        {
            if ( await m_kStreamSocket.IsEmptyStringReceivedSinceAfterConnectionIsEstablishedUntilBeforeConnectionIsClosedUnilaterallyByRemoteHost() )
            {
                throw new ApplicationException( ERROR_RECEIVED_STRING_IS_EMPTY );
            }
        }

        protected virtual void CallStreamSocketDisconnect()
        {
            m_kStreamSocket.Disconnect();
        }
#endif
    }
}