using UnityEngine;
using UnityEngine.UI;

namespace FinanceProgram.Framework
{
    
    [System.Serializable]
    public class SystemDataBase : MonoBehaviour
    {
        
        public DataBaseHandler Handler{get; set;}
        
        
        private string clientId; 
        private string login;
        private string password; 
        
        [SerializeField] private InputField input_ClientId;
        [SerializeField] private InputField input_Login;
        [SerializeField] private InputField input_Password;

        [SerializeField] private Text label_ClientId;
        [SerializeField] private Text label_Login;
        [SerializeField] private Text label_Password;


        public Text status;
        private string _state;
        
        private void Awake()
        {
            status.text = "no connections...";


        }

        private void Start()
        {
            
            Handler = new DataBaseHandler();
        }
        
        public void Connect()
        {
            
            DataBase.LogOnStart();
            Handler.Connect(out _state);
            status.text = _state;
        }

        public void Read()
        {
            Handler.ReadClientData(out _state);
            status.text = _state;

        }

        public void Write()
        {
            Handler.AddClient(out _state);
            status.text = _state;

        }



    }

}