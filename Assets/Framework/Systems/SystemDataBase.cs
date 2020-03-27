using System;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Security;
using System.EnterpriseServices;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.UI;

namespace FinanceProgram.Framework
{
    
    [System.Serializable]
    public class SystemDataBase : MonoBehaviour
    {
        public string login;
        public string password;
        public Text status;
        
        public static DataBase dataBase = new DataBase();

        private void Awake()
        {
            status.text = "Connection is absent!";

        }

        public void Connect()
        {
            string state;
            dataBase.OnConnect(out state);
            status.text = state;
        }
                
        
        public void Request()
        {
            var request = "Select * from Users";
            dataBase.OnCommand(request);

        }

        public void Read(SqliteCommand command)
        {
            var request = "Select * from Users";
            dataBase.OnCommand(request);

        }



    }

    //TODO: Reclass DataBaseConnection
    public class DataBase
    {
        public SqliteConnection Connection {get; private set;}
        private string path;
        
        private SqliteCommand command;
        private SqliteDataReader reader;
        
        public bool OnConnect(out string status) 
        {
            
            status = "Connection is absent!";
            
            try
            {
                path = Application.dataPath + "/Source/DataBase/financeprogramdb.bytes";
                Connection = new SqliteConnection("URI=file:" + path );
                Connection.Open();

                if(Connection.State == ConnectionState.Open)
                    status = path.ToString() + "has been connected!";

                
                return true;
            }
            catch(Exception exeption)
            {

                status = exeption.ToString();
                return false;
            }
        
        }  

        public bool OnCommand(string request)
        {
            try
            {
                command = new SqliteCommand(request, Connection);      
                return true;
            }
            catch(Exception exeption)
            {
                Debug.Log(exeption.ToString());
                return false;
            }


        }
 


    }
}