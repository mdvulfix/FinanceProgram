namespace FinanceProgram.Framework
{      
    public class DataBaseHandler
    {
        private Query request; 
        private DataStruct data;

        public void Connect(out string state)
        {         

            DataBase.Connect(out state);
     
            
            
            

        }

        
        public DataStruct ReadClientData(out string state)
        {
            var data = new DataStruct();
            var query = new Query("Select * From Users");
            

            DataBase.Read(query, out data, out state);
            
            return data;
            

        }


        public void AddClient(out string state)
        {

            var query = new Query("INSERT INTO Users(ID, Login, Password) values ('" +  data.ClientID + "', '" +  data.Login +"', '" +  data.Password +"')");
            DataBase.Write(query, out state);
  

        }
    


    }
        
}