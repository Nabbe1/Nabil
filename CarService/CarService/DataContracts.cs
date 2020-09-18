using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CarService
{
    [DataContract]
    public class DataContracts
    {
        [DataContract]
        public class Car
        {
            [DataMember(Name = "make")]
            public string Make { get; set; }

            [DataMember(Name = "yearofmodel")]
            public string YearOfModel { get; set; }

            [DataMember(Name = "carid")]
            public string CarID { get; set; }

            [DataMember(Name = "counter")]
            public int Counter{ get; set; }

            

        }

        [DataContract]
        public class StatusObj
        {
            [DataMember(Name = "status")]
            public string Status { get; set; }

            [DataMember(Name = "host")]
            public string Host { get; set; }

            [DataMember(Name = "port")]
            public int Port { get; set; }

      
        }
        [DataContract]
        public class ErrorData
        {


            public ErrorData(string message, string action = "")
            {
                Message = message;
                Action = action;
            }

            [DataMember(Name = "context")]
            public string Context { get; set; }

            [DataMember(Name = "action")]
            public string Action { get; set; }

            [DataMember(Name = "message")]
            public string Message { get; set; }

        }
    }
}