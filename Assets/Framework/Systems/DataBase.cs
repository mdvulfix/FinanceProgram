using System;
using System.Data;

using Mono.Data.Sqlite;

using UnityEngine;

namespace FinanceProgram.Framework
{      
    

    public struct DataStruct
    {
        public string ClientID {get; set;} 
        public string Login {get; set;} 
        public string Password {get; set;} 

    } 
        
    //TODO: Reclass SQLDataBase connection
    public static class DataBase
    {
        
        public static SqliteConnection Connection {get; private set;}
        public static string Status {get; private set;}

        private static readonly string DATABASE_PATH_FOLDER = "/Source/DataBase/financeprogramdb.bytes";
        
        private static SqliteCommand command;
        private static SqliteDataReader reader;
         

        private static readonly string CONNECTING_STATE_FAILED = "connection was failed...";
        private static readonly string CONNECTING_STATE_CONNECTION_WAS_OPENED = "connection was opened!";
        private static readonly string CONNECTING_STATE_CONNECTION_WAS_CLOSED = "connection was closed!";  
        

        
        public static bool Connect(out string state) 
        {
            try
            {
                var _fullpath = Application.dataPath + DATABASE_PATH_FOLDER;
                Connection = new SqliteConnection("URI=file:" + _fullpath);
                Connection.Open();


                if(Connection.State == ConnectionState.Open) 
                {
                    state = SetStatus(CONNECTING_STATE_CONNECTION_WAS_OPENED);
                    return true;
                    

                }

                state = SetStatus(CONNECTING_STATE_FAILED);
                return false;
            }
            catch(Exception exeption)
            {
                state = SetStatus(CONNECTING_STATE_FAILED);
                Debug.LogWarning(exeption.ToString());
                return false;
            }
        } 

        public static bool Disconnect(out string state) 
        {
            try
            {
                Connection.Close();
                state = SetStatus(CONNECTING_STATE_CONNECTION_WAS_CLOSED);
                return true;
            }
            catch(Exception exeption)
            {
                state = SetStatus(CONNECTING_STATE_FAILED);
                Debug.LogWarning(exeption.ToString());
                return false;
            }

        }  


        public static bool Read(Query query, out DataStruct data, out string state)
        {
            data = new DataStruct();
            
            try
            {
                Connect(out state);
                command = new SqliteCommand(query.Request, Connection);  

                reader = command.ExecuteReader();
                while(reader.Read())
                {
                    data.ClientID = reader[0].ToString();
                    data.Login = reader[1].ToString();
                    data.Password = reader[2].ToString();

                }

                Disconnect(out state);
                return true;

            }
            catch(Exception exeption)
            {
                Debug.Log(exeption.ToString());

                Disconnect(out state);
                return false;
            }


        }

        public static bool Write(Query query, out string state)
        {

            
            try
            {
                
                Connect(out state);
                command = new SqliteCommand(query.Request, Connection);  
                command.ExecuteNonQuery();
                Disconnect(out state);
                return true;

            }
            catch(Exception exeption)
            {
                Debug.Log(exeption.ToString());

                Disconnect(out state);
                return false;
            }


        }
 
        public static string SetStatus(string status)
        {
            Status = status;
            return status;
        }

    }
        
}