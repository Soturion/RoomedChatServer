using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Collections.Specialized;

using Npgsql;
namespace chatServer
{
    public enum sqlAction
    {
        insert = 0,
        getMessages = 1,
        deleteMessages = 2,
    }

    public static class dbHelper
    {
        public static void prepareDBConnection()
        {
            dataBaseHelper.getDbData();
            NpgsqlConnectionStringBuilder stringBuilder = new NpgsqlConnectionStringBuilder();
            stringBuilder.Host = dataBaseHelper.sDbAddress;
            stringBuilder.Port = dataBaseHelper.iDbPort;
            stringBuilder.Username = dataBaseHelper.sDbUser;
            stringBuilder.Password = dataBaseHelper.sDbPass;
            stringBuilder.Database = "chat_db";
            
            dbHelper.connection = new NpgsqlConnection(stringBuilder);
            dbHelper.connection.Open();

            Console.WriteLine("DB connection established");
            
            prepareTable();
        }

        public static NpgsqlConnection connection;

        private static NpgsqlCommand command;

        public static bool bCleaningQueue = false;
        public static ObservableCollection<dbAction> lSqlCommands = new ObservableCollection<dbAction>();

        private static void prepareTable()
        {
            command = new NpgsqlCommand(@"CREATE TABLE chat_tab (uname text, room text, counter SERIAL NOT NULL, message text, PRIMARY KEY(uname, room, counter));", dbHelper.connection);
            
            try
            {
                command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"-- Prepare Table Exception: " + ex.Message);
            }
        }

        public static void queueInsertMessage(string sUser, string sRoom, string sMessage)
        {
            dbAction act = new dbAction();
            act.Command = @"INSERT INTO chat_tab (uname, room, message) VALUES('[uname]','[room]','[message]');".Replace("[uname]", sUser).Replace("[room]",sRoom).Replace("[message]", sMessage);
            act.SqlAction = sqlAction.insert;
            dbHelper.lSqlCommands.Add(act);
        }

        private static List<string> lMessages = new List<string>();

        public static List<string> queueGetMessages(chatUser user)
        {
            lMessages.Clear();
            dbAction act = new dbAction();
            act.Command = @"SELECT * from chat_tab where room = [room]".Replace("[room]", "'" + user.RoomOfUser.RoomName + "'");
            act.SqlAction = sqlAction.getMessages;
            act.ChatUser = user;
            dbHelper.lSqlCommands.Add(act);


            return lMessages;
        }

        public static void queueDeleteMessages(string sRoom)
        {
            dbAction act = new dbAction();
            act.Command = @"DELETE FROM chat_tab where room = [room]".Replace("[room]", "'" + sRoom + "'");
            act.SqlAction = sqlAction.deleteMessages;
            dbHelper.lSqlCommands.Add(act);
        }
        
        public static void executeQueryWithoutReturn(string sQuery)
        {
            if(command != null & connection != null)
            {
                command.CommandText = sQuery;

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("++ Query queue error: " + ex.Message);
                }
            }
        }

        private static NpgsqlDataReader getMessagesReader;
        public static string executeGetMessages(string sQuery)
        {
            if(command != null & connection != null)
            {
                command.CommandText = sQuery;
                try
                {
                    getMessagesReader = command.ExecuteReader();
                    string sResult = Convert.ToInt32(serverCommands.getMessages).ToString() + ";";
                    object[] colResult = new object[4];
                    while(getMessagesReader.Read())
                    {
                        getMessagesReader.GetValues(colResult);
                        foreach(object s in colResult)
                        {
                            sResult += s + ";";
                        }
                        sResult += "|";
                    }
                    getMessagesReader.Close();
                    
                    return sResult;
                }
                catch (Exception ex)
                {

                    return "";
                }
            }
            return "asdfas";

        }

    }
}
