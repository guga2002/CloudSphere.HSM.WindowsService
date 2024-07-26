using System.Net.Sockets;
using System.Net;
using System.Text;
using HSM.WinService.UI.SystemService.SystemInterface;

namespace HSM.WinService.UI.SystemService.SystemServices
{
    public class UdpComunicationService:IUdpComunicationService
    {
        public  string Receive()
        {
            int port = 2024;

            UdpClient server = new UdpClient(port);

            Console.WriteLine("UDP Server is listening on port " + port);
            try
            {
                while (true)
                {
                    IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] receivedBytes = server.Receive(ref clientEndPoint);

                    string receivedMessage = Encoding.UTF8.GetString(receivedBytes);
                    return receivedMessage;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                server.Close();
            }

            return "";
        }
    }
}
