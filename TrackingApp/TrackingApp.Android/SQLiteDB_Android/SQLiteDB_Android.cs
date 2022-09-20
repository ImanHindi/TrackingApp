using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TrackingApp.Droid.SQLiteDB_Android;
using Xamarin.Forms;
using System.IO;
using Environment = System.Environment;
using SQLite;
using TrackingApp.Services.LocalDb;

[assembly: Dependency(typeof(SQLiteDB_Android))]
namespace TrackingApp.Droid.SQLiteDB_Android
{
    class SQLiteDB_Android : ISQLite
    {
        public string GetDbPath(string _fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbFolder = Path.Combine(docFolder, "databases");
            if (!Directory.Exists(dbFolder))
            {
                Directory.CreateDirectory(dbFolder);
            }
            string FileDbPath= Path.Combine(dbFolder, _fileName);
            return FileDbPath;
        }
       
    }
    
}