using System.Net.Sockets;
using System.Net;
using System.Text;
using UDP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

IPEndPoint ServerEndPoint = new IPEndPoint(IPAddress.Any, 9050);
Socket WinSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
WinSocket.Bind(ServerEndPoint);

DataContext context = new DataContext();


while (true)
{

    byte[] data = new byte[25];

    Console.Write("Waiting for client");
    IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

    EndPoint Remote = (EndPoint)sender;
    int recv = WinSocket.ReceiveFrom(data, ref Remote);
    Console.WriteLine("Message received from {0}:", Remote.ToString());
    Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

    //Write to DB



    DataModel udpData = new DataModel
    {
        Data = Encoding.ASCII.GetString(data),
        IP = Remote.ToString()
    };


    context.DataModels.Add(udpData);
    context.SaveChanges();
}