using System.Threading.Tasks;

namespace DodoCafe.Networking.Sockets
{
    public interface ISignalReceivingTcpSocketState
    {
        Task ConnectAsync( string strServerApplicationIpv4, int nServerApplicationPortNumber );
    }
}
