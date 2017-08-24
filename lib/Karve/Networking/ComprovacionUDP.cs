using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Networking
{
    public class ComrpovacionUDP
    {
        Server srv;
        String ip, cifrado, destip;
        int puerto;

        public ComrpovacionUDP(String ip, int puerto, String cifrado, String destip)
        {
            this.ip = ip;
            this.puerto = puerto;
            this.cifrado = cifrado;
            this.destip = destip;
            if (cifrado != "")
            {
                srv = new Server(ip, puerto, Server.protocol.UDP, cifrado);
            }
            else
            {
                srv = new Server(ip, puerto, Server.protocol.UDP);
            }
        }

        public String getmsg()
        {
            try
                {
            String msg = srv.StartServer();
            if (msg == "AAA")
            {
                
                    stop();
                    sendData("BBB");
                    return srv.StartServer();
                
            }
            }
            catch (Exception ex) { return ex.Message; }
            return "error";
        }

        public void stop()
        {
            srv.StopServer();
        }

        public void sendData(String input)
        {
            // String[] parameters = configuracion.getParams();

            String servidor = destip;
            int port = puerto;

            try
            {

                IPEndPoint RemoteEndPoint = new IPEndPoint(IPAddress.Parse(servidor), port);
                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                byte[] data;
                if (cifrado != "")
                {
                    data = Encoding.ASCII.GetBytes(Encriptar(input, cifrado));
                }
                else
                {
                    data = Encoding.ASCII.GetBytes(input);
                }
                server.SendTo(data, data.Length, SocketFlags.None, RemoteEndPoint);


            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Error: {0}", e.StackTrace));
            }
        }




        public static String Encriptar(String input, String pass)
        {
            System.Security.Cryptography.RijndaelManaged AES = new System.Security.Cryptography.RijndaelManaged();
            System.Security.Cryptography.MD5CryptoServiceProvider Hash_AES = new System.Security.Cryptography.MD5CryptoServiceProvider();
            string encrypted = "";
            try
            {
                byte[] hash = new byte[32];
                byte[] temp = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass));
                Array.Copy(temp, 0, hash, 0, 16);
                Array.Copy(temp, 0, hash, 15, 16);
                AES.Key = hash;
                AES.Mode = System.Security.Cryptography.CipherMode.ECB;
                System.Security.Cryptography.ICryptoTransform DESEncrypter = AES.CreateEncryptor();
                byte[] Buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(input);
                encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));
                return encrypted;
            }
            catch (Exception ex)
            {
                String error = ex.Message;
                return null;
            }
        }
        public static byte[] StrToByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }


    }
}
