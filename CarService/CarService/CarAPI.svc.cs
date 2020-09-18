using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CarAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CarAPI.svc or CarAPI.svc.cs at the Solution Explorer and start debugging.
    public class CarAPI : ICarAPI
    {
        public void DoWork()
        {
        }

        public void TestInsert(string make, string year, string carid)
        {

            DatabaseHandler.CreateRow(make, year, carid);

            
        }

        public void Update(string make, string year, string carid, int counter)
        {

            DatabaseHandler.UpdateRow(make, year, carid, counter);


        }

        
        public void Delete(string make, string year, string carid, int counter)
        {

            DatabaseHandler.DeleteRow(make, year, carid, counter);


        }

        public void List(int Counter)
        {

            DatabaseHandler.ListRow(3);


        }

        public string[] Listid()
        {
            return DatabaseHandler.ListAllId();
        }

        
        public string[][] AllInfoFromDb()
        {
            return DatabaseHandler.RetriveAllInfoFromDb();
        }
   

        //public List<object> GetAllInfoFromDb()
        //{
        //    return DatabaseHandler.GetAll();
        //}
    }
}
