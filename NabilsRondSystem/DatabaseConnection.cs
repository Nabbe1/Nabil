
using System;

using System.Collections.Generic;

using System.Text;

using SQLite;

using System.IO;
using NabilsRondSystem.Models;

[assembly: Xamarin.Forms.Dependency(typeof(NabilsRondSystem.DatabaseConnection))]


namespace NabilsRondSystem

{
    class DatabaseConnection : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()

        {

            var dbName = "Barcode.db";

            var path = Path.Combine(System.Environment.

              GetFolderPath(System.Environment.

              SpecialFolder.Personal), dbName);

            return new SQLiteConnection(path);

        }

    }
}