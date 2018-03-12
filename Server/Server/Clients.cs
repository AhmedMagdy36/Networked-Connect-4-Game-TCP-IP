using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Clients
    {
        private Socket socket;
        private NetworkStream nStream;
        private BinaryReader breader;
        private BinaryWriter bwriter;
        private List<string> msgs;
        private Thread thread;
        private int endpoint;
        private string name;
        public string bWriter
        {
            set
            {
                try
                { bwriter.Write(value); }
                catch (Exception)
                {
                    Disconnect();
                }
            }
        }
        public List<string> Msgs { get { return msgs; } }
        public int Endpoint { get { return endpoint; } }
        public string Name { get { return name; } }

        public Clients(Socket socket)
        {
            this.socket = socket;
            endpoint = int.Parse(socket.RemoteEndPoint.ToString().Split(':')[1]);
            nStream = new NetworkStream(socket);
            breader = new BinaryReader(nStream);
            bwriter = new BinaryWriter(nStream);
            msgs = new List<string>();
            name = breader.ReadString();
            bWriter = endpoint.ToString();

            thread = new Thread(new ThreadStart(DataRead));
            thread.Start();
        }

        private void DataRead()
        {
            while (true)
            {
                try
                {
                    msgs.Add(breader.ReadString());
                }
                catch (Exception) { Disconnect(); }
            }
        }

        public void RemoveMsg(string msg)
        {
            msgs.Remove(msg);
        }

        
        public void Disconnect()
        {
            thread.Abort();
            breader.Close();
            bwriter.Close();
            nStream.Close();
        }
    }
}
