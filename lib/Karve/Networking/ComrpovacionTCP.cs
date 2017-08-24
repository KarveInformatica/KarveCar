using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Networking
{
    public class ComrpovacionTCP
    {
        Server srv;
        String ip, cifrado, destip;
        int puerto;

        public ComrpovacionTCP(String ip, int puerto, String cifrado, String destip)
        {
            this.ip = ip;
            this.puerto = puerto;
            this.cifrado = cifrado;
            this.destip = destip;
            if (cifrado != ""){
                srv = new Server(ip, puerto, Server.protocol.TCP, cifrado);
            }
            else
            {
                srv = new Server(ip, puerto, Server.protocol.TCP);
            }
        }

        public String getmsg()
        {
            try
                {
            String msg = srv.StartServer();
            if (msg == "AAA")
            {
                
                    //stop();
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

        public String sendData(String input)
        {
            String servidor = destip;
            int port = puerto;
            String retorno = "";


            try
            {
                using (TcpClient tcpClient = new TcpClient())
                {

                    int maxBuffer = 1024;
                    if (false)//(IsListening(servidor, port) == false)
                    {
                        //lblStatus.Text = string.Format("Error enviando a {0} en puerto {1}", servidor, port);

                    }
                    else
                    {


                        tcpClient.Connect(servidor, port);



                        byte[] array = Encoding.ASCII.GetBytes(input);
                        NetworkStream networkStream = tcpClient.GetStream();

                        byte[] sendBuffer = new ASCIIEncoding().GetBytes(input);
                        String textocifrado;

                        if (cifrado != "")
                        {
                            textocifrado = Encriptar(input, "");
                        }
                        else
                        {
                            textocifrado = input;
                        }
                        //sendBuffer = StrToByteArray(input);
                        sendBuffer = StrToByteArray(textocifrado);
                        networkStream.Write(sendBuffer, 0, sendBuffer.Length);

                        //lblStatus.Text = "Confirmación recibida del servidor...";
                        byte[] receiveBuffer = new byte[maxBuffer];
                        //int k = networkStream.Read(receiveBuffer, 0, maxBuffer);

                        //networkStream.EndWrite;
                        networkStream = tcpClient.GetStream();
                        byte[] bytes = new byte[512];
                        String data;
                        int i;
                        i = networkStream.Read(bytes, 0, bytes.Length);
                        while (i != 0)
                        {
                            // Translate data bytes to a ASCII string.
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                            // Process the data sent by the client.
                            retorno += data;

                            i = networkStream.Read(bytes, 0, bytes.Length);

                        }
                        /*
                        do
                        {
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                            // Process the data sent by the client.
                            retorno += data;

                            i = networkStream.Read(bytes, 0, bytes.Length);

                        } while (networkStream.DataAvailable);
                        */
                        networkStream.Close();
                        tcpClient.Close();

                    }
                }
            }



            catch (Exception ex)
            {
                String error = ex.Message;
                throw new Exception("Error enviando a {0} en puerto {1}");
            }

            return retorno;
        }

        public String Encriptar(String input, String pass)
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
