namespace FinanceProgram.Framework
{      
    public class DataBaseHandler
    {
        private Query request; 
        private DataStruct data;
        
        public DataStruct ReadClientData()
        {
            var data = new DataStruct();
            var query = new Query("Select * From Users");
            

            DataBase.Read(query, out data);
            
            return data;
            

        }


        public void AddClient()
        {

            var query = new Query("INSERT INTO Users(ID, Login, Password) values ('" +  data.ClientID + "', '" +  data.Login +"', '" +  data.Password +"')");
            DataBase.Write(query);
  

        }
    


    }
        
}