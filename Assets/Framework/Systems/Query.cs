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
    public class Query
    {

        public string Request{get; set;}

        public static readonly string QUERY_GET_CLIENT_ID = "Select UID From Users";
        
        //public static string GetClientID{get{return QUERY_GET_CLIENT_ID;}}

        public Query(string request)
        {
            Request = request;
        }


    }
}