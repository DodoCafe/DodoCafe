using DodoCafe.Networking.Sockets.Mocks;
using DodoCafe.Wrappers.Mocks.Windows.Networking.Sockets;
using DodoCafe.Wrappers.Windows.Networking.Sockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DodoCafe.Networking.Sockets.Tests
{
    [ TestClass() ]
    public class CSignalReceivingTcpSocketTest
    {
        private static string PRIVATE_MEMBER_VARIABLE_NAME_STREAM_SOCKET = "m_kStreamSocket";
        private static string PRIVATE_MEMBER_VARIABLE_NAME_STATE = "m_kState";
        private static string PROTECTED_MEMBER_FUNCTION_NAME_CHANGE_STATE_TO_CONNECTING = "ChangeStateToConnecting";
        private static string PROTECTED_MEMBER_FUNCTION_NAME_CHANGE_STATE_TO_DISCONNECTING = "ChangeStateToDisconnecting";
        private static string PROTECTED_MEMBER_FUNCTION_NAME_CALL_STREAM_SOCKET_CONNECT_ASYNC = "CallStreamSocketConnectAsync";
        private CSignalReceivingTcpSocket m_kSocket;
        private CStreamSocketWrapperMock m_kStreamSocket;
        private CSignalReceivingTcpSocketStateMock m_kState;

        private void SetNonPublicMemberVariable( string strNonPublicMemberVariableName, object kValue )
        {
            FieldInfo kFieldInfo = typeof( CSignalReceivingTcpSocket ).GetField( strNonPublicMemberVariableName, CTestDefinitions.NON_PUBLIC_MEMBER_BINDING_FLAGS );
            kFieldInfo.SetValue( m_kSocket, kValue );
        }

        private object GetNonPublicMemberVariable( CSignalReceivingTcpSocket kSocket, string strNonPublicMemberVariableName )
        {
            FieldInfo kStateFieldInfo = typeof( CSignalReceivingTcpSocket ).GetField( strNonPublicMemberVariableName, CTestDefinitions.NON_PUBLIC_MEMBER_BINDING_FLAGS );
            return kStateFieldInfo.GetValue( kSocket );
        }

        private object CallNonPublicMemberFunction( string strNonPublicMemberFunctionName, object[] kNonPublicMemberFunctionArguments )
        {
            MethodInfo kMethodInfo = typeof( CSignalReceivingTcpSocket ).GetMethod( strNonPublicMemberFunctionName, CTestDefinitions.NON_PUBLIC_MEMBER_BINDING_FLAGS );
            return kMethodInfo.Invoke( m_kSocket, kNonPublicMemberFunctionArguments );
        }

        [ TestInitialize() ]
        public void Initialize()
        {
            m_kSocket = new CSignalReceivingTcpSocket();
            m_kStreamSocket = new CStreamSocketWrapperMock();
            m_kState = new CSignalReceivingTcpSocketStateMock();
            SetNonPublicMemberVariable( PRIVATE_MEMBER_VARIABLE_NAME_STREAM_SOCKET, m_kStreamSocket );
            SetNonPublicMemberVariable( PRIVATE_MEMBER_VARIABLE_NAME_STATE, m_kState );
        }

        [ TestMethod() ]
        public void test_constructor_creating_stream_socket_and_setting_state_to_disconnecting()
        {
            var kSocket = new CSignalReceivingTcpSocket();
            Assert.IsInstanceOfType( GetNonPublicMemberVariable( kSocket, PRIVATE_MEMBER_VARIABLE_NAME_STREAM_SOCKET ), typeof( CStreamSocketWrapper ) );
            Assert.IsInstanceOfType( GetNonPublicMemberVariable( kSocket, PRIVATE_MEMBER_VARIABLE_NAME_STATE ), typeof( CSignalReceivingTcpSocket.CSignalReceivingTcpSocketDisconnectingState ) );
        }

        [ TestMethod() ]
        public async Task test_connect_calling_state_connect()
        {
            await m_kSocket.ConnectAsync( "1.1.1.1", 0 );
            Assert.IsTrue( m_kState.IsCalledConnectAsync );
        }

        [ TestMethod() ]
        public void test_changing_state_to_connecting()
        {
            CallNonPublicMemberFunction( PROTECTED_MEMBER_FUNCTION_NAME_CHANGE_STATE_TO_CONNECTING, null );
            Assert.IsInstanceOfType( GetNonPublicMemberVariable( m_kSocket, PRIVATE_MEMBER_VARIABLE_NAME_STATE ), typeof( CSignalReceivingTcpSocket.CSignalReceivingTcpSocketConnectingState ) );
        }

        [ TestMethod() ]
        public void test_changing_state_to_disconnecting()
        {
            CallNonPublicMemberFunction( PROTECTED_MEMBER_FUNCTION_NAME_CHANGE_STATE_TO_DISCONNECTING, null );
            Assert.IsInstanceOfType( GetNonPublicMemberVariable( m_kSocket, PRIVATE_MEMBER_VARIABLE_NAME_STATE ), typeof( CSignalReceivingTcpSocket.CSignalReceivingTcpSocketDisconnectingState ) );
        }

        [ TestMethod() ]
        public async Task test_call_stream_socket_connect_to_server_application_ip_not_being_ipv4_throwing_exception()
        {
            object[] kArguments = { "4744:56f:e445:f0a8:57ea:25b0:ea64:aaf7", CTestDefinitions.DUMP_INTEGER };
            await Assert.ThrowsExceptionAsync< ArgumentException >( () => ( Task )CallNonPublicMemberFunction( PROTECTED_MEMBER_FUNCTION_NAME_CALL_STREAM_SOCKET_CONNECT_ASYNC, kArguments ) );
        }

        [ TestMethod() ]
        public async Task test_call_stream_socket_connect_to_server_application_port_number_not_being_tcp_port_number_throwing_exception()
        {
            object[] kArguments = { "1.1.1.1", 65536 };
            await Assert.ThrowsExceptionAsync< ArgumentException >( () => ( Task )CallNonPublicMemberFunction( PROTECTED_MEMBER_FUNCTION_NAME_CALL_STREAM_SOCKET_CONNECT_ASYNC, kArguments ) );
        }

        [ TestMethod() ]
        public async Task test_call_stream_socket_connect_calling_stream_socket_connect()
        {
            object[] kArguments = { "1.1.1.1", 0 };
            await ( Task )CallNonPublicMemberFunction( PROTECTED_MEMBER_FUNCTION_NAME_CALL_STREAM_SOCKET_CONNECT_ASYNC, kArguments );
            Assert.IsTrue( m_kStreamSocket.IsCalledConnectAsync );
        }
    }
}