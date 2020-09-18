using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static CarService.DataContracts;

namespace CarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICarAPI" in both code and config file together.
    [ServiceContract]
    public interface ICarAPI
    {
        [OperationContract]
        void DoWork();


        [OperationContract]
        void TestInsert(string make, string year, string carid);

        [OperationContract]
        void Update(string make, string year, string carid, int counter);

        [OperationContract]
        void Delete(string make, string year, string carid, int counter);

        [OperationContract]
        void List(int Counter);

        [OperationContract]

        string[] Listid();

        [OperationContract]

        string[][] AllInfoFromDb();

        //[OperationContract]

        //List<object> GetAllInfoFromDb();


    }
}
