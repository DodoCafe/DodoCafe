﻿using DodoCafe.Wrappers.Windows.Networking.Sockets;
using System;
using System.Threading.Tasks;

namespace DodoCafe.Networking.Sockets
{
    public partial class CSignalReceivingTcpSocket
    {
        private static string ERROR_SERVER_APPLICATION_IP_IS_NOT_IPV4 = "The given server application IP is not an IPv4";
        private static string ERROR_SERVER_APPLICATION_PORT_NUMBER_IS_NOT_TCP_PORT_NUMBER = "The given server application port number is not a TCP port number.";
        private CStreamSocketWrapper m_kStreamSocket;
        private ISignalReceivingTcpSocketState m_kState;

        public CSignalReceivingTcpSocket()
        {
            m_kStreamSocket = new CStreamSocketWrapper();
            ChangeStateToDisconnecting();
        }

        public async Task ConnectAsync( string strServerApplicationIpv4, int nServerApplicationPortNumber )
        {
            await m_kState.ConnectAsync( strServerApplicationIpv4, nServerApplicationPortNumber );
        }

        protected virtual void ChangeStateToConnecting()
        {
            m_kState = new CSignalReceivingTcpSocketConnectingState( this );
        }

        protected void ChangeStateToDisconnecting()
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
    }
}