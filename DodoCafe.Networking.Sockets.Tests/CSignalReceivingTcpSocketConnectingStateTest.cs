using DodoCafe.Networking.Sockets.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DodoCafe.Networking.Sockets.Tests
{
    [ TestClass() ]
    public class CSignalReceivingTcpSocketConnectingStateTest
    {
        private static string PRIVATE_MEMBER_VARIABLE_NAME_SOCKET = "m_kSocket";
        private CSignalReceivingTcpSocket.CSignalReceivingTcpSocketConnectingState m_kState;
        private CSignalReceivingTcpSocketMock m_kSocket;

        private CSignalReceivingTcpSocket GetSocket( CSignalReceivingTcpSocket.CSignalReceivingTcpSocketConnectingState kState )
        {
            FieldInfo kSocketFieldInfo = typeof( CSignalReceivingTcpSocket.CSignalReceivingTcpSocketConnectingState ).GetField( PRIVATE_MEMBER_VARIABLE_NAME_SOCKET, CTestDefinitions.NON_PUBLIC_MEMBER_BINDING_FLAGS );
            return ( CSignalReceivingTcpSocket )kSocketFieldInfo.GetValue( kState );
        }

        [ TestInitialize() ]
        public void Initialize()
        {
            m_kSocket = new CSignalReceivingTcpSocketMock();
            m_kState = new CSignalReceivingTcpSocket.CSignalReceivingTcpSocketConnectingState( m_kSocket );
        }

        [ TestMethod() ]
        public void test_constructor_setting_socket_to_null_throwing_exception()
        {
            Assert.ThrowsException< ArgumentNullException >( () => new CSignalReceivingTcpSocket.CSignalReceivingTcpSocketConnectingState( null ) );
        }

        [ TestMethod() ]
        public void test_constructor_setting_socket_to_argument()
        {
            var kSocket = new CSignalReceivingTcpSocket();
            var kState = new CSignalReceivingTcpSocket.CSignalReceivingTcpSocketConnectingState( kSocket );
            Assert.AreSame( kSocket, GetSocket( kState ) );
        }

        [ TestMethod() ]
        public async Task test_connect_throwing_exception()
        {
            await Assert.ThrowsExceptionAsync< InvalidOperationException >( () => m_kState.ConnectAsync( CTestDefinitions.DUMP_STRING, CTestDefinitions.DUMP_INTEGER ) );
        }

        [ TestMethod() ]
        public async Task test_receive_signal_calling_context_receive_non_empty_string_since_after_connection_is_established_until_before_connection_is_closed_unilaterally_by_remote_host()
        {
            await m_kState.ReceiveSignalAsync();
            Assert.IsTrue( m_kSocket.IsCalledReceiveNonEmptyStringSinceAfterConnectionIsEstablishedUntilBeforeConnectionIsClosedUnilaterallyByRemoteHost );
        }
    }
}