using System;
using System.Data;

using Mono.Data.Sqlite;

using UnityEngine;

namespace FinanceProgram.Framework
{      
    //TODO: Reclass SQLDataBase connection
    public static class DataBase
    {
        public static SqliteConnection Connection {get; private set;}
        private static readonly string DATABASE_PATH_FOLDER = "/Source/SQLDataBase/financeprogramdb.bytes";
        
        private static SqliteCommand command;
        private static SqliteDataReader reader;


        private static readonly string CONNECTING_STATE_FAILED = "connection was failed...";
        private static readonly string CONNECTING_STATE_CONNECTION_WAS_OPENED = "connection was opened!";
        private static readonly string CONNECTING_STATE_CONNECTION_WAS_CLOSED = "connection was closed!";  

        
        private static bool Connect() 
        {
            try
            {
                var _fullpath = Application.dataPath + DATABASE_PATH_FOLDER;
                Connection = new SqliteConnection("URI=file:" + _fullpath);
                Connection.Open();


                if(Connection.State == ConnectionState.Open) 
                    return true;

                return false;
            }
            catch(Exception exeption)
            {
                Debug.LogWarning(exeption.ToString());
                return false;
            }
        }  

        private static bool Disconnect() 
        {
            try
            {
                Connection.Close();

                return true;
            }
            catch(Exception exeption)
            {
                Debug.LogWarning(exeption.ToString());
                return false;
            }

        }  

        public static bool OnRead(Query query)
        {
            
  
            try
            {
                Connect();
                command = new SqliteCommand(query.Request, Connection);  
                reader = command.ExecuteReader();
                while(reader.Read())
                {
                    



                }

                
                
                Disconnect();
                return true;    
            
            
            
            }
            catch(Exception exeption)
            {
                Debug.Log(exeption.ToString());
                Disconnect();
                return false;

            }
            
            
        }

        public static bool OnWrite(Query query)
        {
            try
            {
                
                Connect();
                command = new SqliteCommand(query.Request, Connection);      
                command.ExecuteNonQuery();



                
                return true;
            }
            catch(Exception exeption)
            {
                Debug.Log(exeption.ToString());

                Disconnect();
                return false;
            }


        }
 


    }
        
}