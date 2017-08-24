using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace Networking
{
    public class Server
    {
        const int maxBuffer = 500;
        private String ip, clave;
        private int port = -1;
        private protocol protocolo;
        private TcpListener srvTcp;
        //private UdpClient srvUdp;
        byte[] bytes = new byte[512];
        string data;
        NetworkStream stream;
        TcpClient client;

        public enum protocol {UDP, TCP};

        public Server()
        {
            
        }

        public Server(String ip, int port, protocol protocolo)
        {
            this.ip = ip;
            this.port = port;
            this.protocolo = protocolo;
            this.clave = "";
        }

        public Server(String ip, int port, protocol protocolo, String clave = "")
        {
            this.ip = ip;
            this.port = port;
            this.protocolo = protocolo;
            this.clave = clave;
        }

        public void StopServer()
        {
            try
            {
                if (protocolo == protocol.TCP)
                {
                    client.Close();
                    srvTcp.Stop();
                }
                else if (protocolo == protocol.UDP)
                {
                    //srvUdp.Close();
                }
            }
            catch { }
        }

        public String StartServer()
        {
            String message = "";

            if (port == -1) {
                throw new Exception("El puerto debe estar entre el 1 y el 65535");
            }

            //Si es TCP
            if (protocolo == protocol.TCP)
            {
                try
                {
                    IPAddress ipAddress;
                    if (ip != "0.0.0.0")
                    {
                        ipAddress = IPAddress.Parse(ip);
                    }
                    else
                    {
                        ipAddress = IPAddress.Any;
                    }
                    try
                    {
                        srvTcp = new TcpListener(ipAddress, port);
                        srvTcp.Start();
                    }
                    catch { }
                    using (client = srvTcp.AcceptTcpClient())
                    {

                        stream = client.GetStream();

                        //byte[] receiveBuffer = new byte[maxBuffer];
                        //int usedBuffer = socket.Receive(receiveBuffer);

                        //for (int i = 0; i < usedBuffer; i++)
                        //{
                        //    message += Convert.ToChar((receiveBuffer[i]));
                        //}
                        int i;
                        i = stream.Read(bytes, 0, bytes.Length);
                        /*while (i != 0)
                        {
                            // Translate data bytes to a ASCII string.
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                            // Process the data sent by the client.
                            message+= data;

                            i = 0;
                            //i = stream.Read(bytes, 0, bytes.Length);

                        }*/

                        do
                        {
                            // Translate data bytes to a ASCII string.
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                            // Process the data sent by the client.
                            message += data;

                            i = 0;
                            //i = stream.Read(bytes, 0, bytes.Length);

                        } while(stream.DataAvailable);
                        //sendMessage("HOLA");

                        DataSet dtsTmp = new DataSet();
                        ASADB.Connection db = new ASADB.Connection(); 
                        dtsTmp = db.fillDts(message);
                        String xmlString;
                        xmlString = dtsTmp.GetXml();
                        sendMessage(xmlString);
                    }

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally { 
                    //StopServer(); 
                }
            }


            if (clave != "")
            {
                try
                {
                    message = Cipher.Decrypt(message, clave);
                }

                catch (Exception ex)
                {
                    throw new Exception("No se ha podido desencriptar" + "\n" + ex.Message);
                }
            }

            return message;

        }

        public void sendMessage(String message)
        {
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(message);

            // Send back a response.
            stream.Write(msg, 0, msg.Length);
        }
    }


}
