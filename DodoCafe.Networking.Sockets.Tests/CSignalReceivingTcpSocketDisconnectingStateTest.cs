using DodoCafe.Networking.Sockets.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DodoCafe.Networking.Sockets.Tests
{
    [ TestClass() ]
    public class CSignalReceivingTcpSocketDisconnectingStateTest
    {
        private static string PRIVATE_MEMBER_VARIABLE_NAME_SOCKET = "m_kSocket";
        private CSignalReceivingTcpSocket.CSignalReceivingTcpSocketDisconnectingState m_kState;
        private CSignalReceivingTcpSocketMock m_kSocket;

        private CSignalReceivingTcpSocket GetSocket( CSignalReceivingTcpSocket.CSignalReceivingTcpSocketDisconnectingState kState )
        {
            FieldInfo kSocketFieldInfo = typeof( CSignalReceivingTcpSocket.CSignalReceivingTcpSocketDisconnectingState ).GetField( PRIVATE_MEMBER_VARIABLE_NAME_SOCKET, CTestDefinitions.NON_PUBLIC_MEMBER_BINDING_FLAGS );
            return ( CSignalReceivingTcpSocket )kSocketFieldInfo.GetValue( kState );
        }

        [ TestInitialize() ]
        public void Initialize()
        {
            m_kSocket = new CSignalReceivingTcpSocketMock();
            m_kState = new CSignalReceivingTcpSocket.CSignalReceivingTcpSocketDisconnectingState( m_kSocket );
        }

        [ TestMethod() ]
        public void test_constructor_setting_socket_to_null_throwing_exception()
        {
            Assert.ThrowsException< ArgumentNullException >( () => new CSignalReceivingTcpSocket.CSignalReceivingTcpSocketDisconnectingState( null ) );
        }

        [ TestMethod() ]
        public void test_constructor_setting_socket_to_argument()
        {
            var kSocket = new CSignalReceivingTcpSocket();
            var kState = new CSignalReceivingTcpSocket.CSignalReceivingTcpSocketDisconnectingState( kSocket );
            Assert.AreSame( kSocket, GetSocket( kState ) );
        }

        [ TestMethod() ]
        public async Task test_connect_calling_context_methods()
        {
            await m_kState.ConnectAsync( "1.1.1.1", 0 );
            Assert.IsTrue( m_kSocket.IsCalledCallStreamSocketConnectAsync );
            Assert.IsTrue( m_kSocket.IsCalledChangeStateToConnecting );
        }

        [ TestMethod() ]
        public async Task test_receive_signal_throwing_exception()
        {
            await Assert.ThrowsExceptionAsync< InvalidOperationException >( () => m_kState.ReceiveSignalAsync() );
        }

        [ TestMethod() ]
        public void test_disconnect_throwing_exception()
        {
            Assert.ThrowsException< InvalidOperationException >( () => m_kState.Disconnect() );
        }
    }
}