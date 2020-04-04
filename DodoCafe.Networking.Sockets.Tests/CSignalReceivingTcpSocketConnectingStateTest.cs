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

        private CSignalReceivingTcpSocket GetSocket( CSignalReceivingTcpSocket.CSignalReceivingTcpSocketConnectingState kState )
        {
            FieldInfo kSocketFieldInfo = typeof( CSignalReceivingTcpSocket.CSignalReceivingTcpSocketConnectingState ).GetField( PRIVATE_MEMBER_VARIABLE_NAME_SOCKET, CTestDefinitions.NON_PUBLIC_MEMBER_BINDING_FLAGS );
            return ( CSignalReceivingTcpSocket )kSocketFieldInfo.GetValue( kState );
        }

        [ TestInitialize() ]
        public void Initialize()
        {
            m_kState = new CSignalReceivingTcpSocket.CSignalReceivingTcpSocketConnectingState( new CSignalReceivingTcpSocket() );
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
    }
}