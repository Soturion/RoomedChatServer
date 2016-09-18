using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace chatServer
{
    public enum serverCommands
    {
        nothing = 0,
        connect = 1,
        sendMessage = 2,
        disconnect = 3,
        getMessages = 4,
    }

    class clientCommunication
    {
        private Thread tCommunicate;
        private TcpClient cClient;
        private NetworkStream netStream;
        private byte[] bReceivedMessage = new byte[4096];
        private byte[] bSendMessage = new byte[4096];
        private string sServerMessage;
        private List<string> lReceivedMessageSplit = new List<string>();
        private receivedCommand received = new receivedCommand();
        private room myRoom;
        private chatUser connectedUser;
        private bool bCleanDC = false;

        public clientCommunication(TcpClient client)
        {
            cClient = client;
            netStream = cClient.GetStream();
            tCommunicate = new Thread(handleClient);
            tCommunicate.Start();
        }

        private void handleClient()
        {
            Console.WriteLine(">> Client handling started");
            while (cClient.Connected)
            {
                Array.Clear(bReceivedMessage, 0, bReceivedMessage.Length);
                try
                {
                    netStream.Read(bReceivedMessage, 0, bReceivedMessage.Length);
                }
                catch (System.IO.IOException ex)
                {
                    cClient.Close();
                    break;
                }

                sServerMessage = Encoding.ASCII.GetString(bReceivedMessage, 0, bReceivedMessage.Length).Replace("\0", "");

                if (sServerMessage == "")
                {
                    RoomHandler.disconnectUser(connectedUser, true);
                    Console.WriteLine(">> Connection assumed aborted");
                    return;
                }

                lReceivedMessageSplit.Clear();
                received.getData(sServerMessage);

                Console.WriteLine(">> Received: " + received.getLogMessage());

                switch (received.Action)
                {
                    case serverCommands.connect:
                        room rToCreate;
                     if (RoomHandler.checkRoomExist(received.Room))
                        {
                            rToCreate = RoomHandler.findRoom(received.Room);
                            if (rToCreate.RoomPassword == received.Pass)
                            {
                                connectedUser = new chatUser(received, rToCreate, cClient);
                                rToCreate.RoomClients.Add(connectedUser);
                                dbHelper.queueGetMessages(connectedUser);
                                
                                //connectedUser.sendOldMessages(amelia.getMessages(connectedUser.RoomOfUser.RoomName, connectedUser.RoomOfUser.RoomPassword));
                            }
                            else
                            {
                                cClient.Close();
                                Console.WriteLine(">> Client rejected: Wrong password");
                                break;
                            }
                        }
                        else
                        {
                            rToCreate = received.getRoomFromCommand();
                            connectedUser = new chatUser(received, rToCreate, cClient);
                            RoomHandler.Rooms.Add(rToCreate);
                            rToCreate.RoomClients.Add(connectedUser);
                            myRoom = rToCreate;
                        }

                       
                        break;

                    case serverCommands.disconnect:
                        bCleanDC = true;
                        RoomHandler.disconnectUser(connectedUser,true);
                        break;

                    case serverCommands.sendMessage:
                        connectedUser.RoomOfUser.broadcastMessage(received.Data);
                        dbHelper.queueInsertMessage(received.User, received.Room, received.Data);
                        break;
                }

            }
            
            if(!cClient.Connected)
            {
                //Verbindung abgebrochen
                if (bCleanDC) { return; }
                Console.WriteLine(">> Connection assumed aborted");
                if(connectedUser != null)
                {
                    RoomHandler.disconnectUser(connectedUser,true);
                }
            }
        }
    }
}
