using UnityEngine;

namespace FinanceProgram.Framework
{      
    public class DataBaseHandler
    {
        private string request; 
        private string status; 

        private static readonly string CONNECTING_STATE_FAILED = "connection was failed...";
        private static readonly string CONNECTING_STATE_CONNECTION_WAS_OPENED = "connection was opened!";
        private static readonly string CONNECTING_STATE_CONNECTION_WAS_CLOSED = "connection was closed!";
        
        
        
        public void OnRead()
        {

            Connect(out status);

            Command();


            
            
            
            Disconnect(out status);


        }

        public void OnWrite()
        {

            Connect(out status);
            Command();
  

            Disconnect(out status);


        }

        
    
        
        private void Connect(out string state)
        {
            if(DataBase.OnConnect())
                state = CONNECTING_STATE_CONNECTION_WAS_OPENED;

            state = CONNECTING_STATE_FAILED;

        }
        

        private void Disconnect(out string state)
        {

            if(DataBase.OnDisconnect())
                state = CONNECTING_STATE_CONNECTION_WAS_OPENED;

            state = CONNECTING_STATE_CONNECTION_WAS_CLOSED;

        }


        private void Command()
        {  
            DataBase.OnCommand(request);


        }
        

        


    }
        
}