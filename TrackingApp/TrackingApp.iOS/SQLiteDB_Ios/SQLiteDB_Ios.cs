using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TrackingApp.iOS.SQLiteDB_Ios;
using Xamarin.Forms;
using SQLite;
using TrackingApp.Services.LocalDb;

[assembly: Dependency(typeof(SQLiteDB_Ios))]
namespace TrackingApp.iOS.SQLiteDB_Ios
{
  public  class SQLiteDB_Ios : ISQLite
    {

        public string GetDbPath(string _fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbFolder = Path.Combine(docFolder, "databases");
            if (!Directory.Exists(dbFolder))
            {
                Directory.CreateDirectory(dbFolder);
            }
            string FileDbPath = Path.Combine(dbFolder, _fileName);
            return FileDbPath;
        }

       
    }
}
