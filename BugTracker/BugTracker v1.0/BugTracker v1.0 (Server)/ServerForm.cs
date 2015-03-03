using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace BugTracker_v1._0__Server_
{
    public partial class ServerForm : Form
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private int connectedClients = 0;


        public ServerForm()
        {
            InitializeComponent();
            Server();
        }

        private void Server()
        {
            this.tcpListener = new TcpListener(IPAddress.Loopback, 3000); // Change to IPAddress.Any for internet wide Communication
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }
        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (true) // Never ends until the Server is closed.
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();

                //create a thread to handle communication 
                //with connected client
                connectedClients++; // Increment the number of clients that have communicated with us.
                clientNumberLabel.Text = connectedClients.ToString();
                

                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }
        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    connectedClients--;
                    clientNumberLabel.Text = connectedClients.ToString();
                    break;
                }

                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();

                // Convert the Bytes received to a string and display it on the Server Screen
                string msg = encoder.GetString(message, 0, bytesRead);
                //WriteMessage(msg);
                
                // Now Echo the message back

                //Echo(msg, encoder, clientStream);
            }

            tcpClient.Close();
        }
        private void Server_Load(object sender, EventArgs e)
        {

        }
    }
}
