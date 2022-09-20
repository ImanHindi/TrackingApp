using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using TrackingApp.UWP.SQLiteDB_UWP;
using TrackingApp.Services.LocalDb;
using Windows.Storage;

[assembly: Dependency(typeof(SQLiteDB_UWP))]

namespace TrackingApp.UWP.SQLiteDB_UWP
{
    public class SQLiteDB_UWP : ISQLite
    {
       
       // public SQLiteAsyncConnection DbConnection;

        public string GetDbPath(string _fileName)
        {
            string docFolder = ApplicationData.Current.LocalFolder.Path;
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



