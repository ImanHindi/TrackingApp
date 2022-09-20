using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingApp.Models;
using TrackingApp.Models.Device;
using TrackingApp.Models.Tracking;
using Xamarin.Forms;

namespace TrackingApp.Services.LocalDb
{
   public  class DbServices: IDbServices
    {
        private static  SQLiteAsyncConnection Db;
        private static  string _fullPath = string.Empty;

        private static readonly string FileName = "Tracking.db3";

        public DbServices()
        {
            _fullPath = DependencyService.Get<ISQLite>().GetDbPath(FileName);
            Db = new SQLiteAsyncConnection(_fullPath);
          //  Db.CreateTableAsync<DeviceInfo>().Wait();
            Db.CreateTableAsync<TrackingData>().Wait();
        }

     

           public async Task<ObservableCollection<T>> GetTables<T>()
        {
            ObservableCollection<T> result = await Db.Table<ObservableCollection<T>>().FirstOrDefaultAsync();
            return result;
        }
        public async Task<ObservableCollection<T>> GetDataAsync<T>(int Id)
        {
            ObservableCollection<T> result = await Db.GetAsync<ObservableCollection<T>>(Id);
            return result;
        }

        public async Task<int> AddDataAsync<T>(T Data)
        {
          int result = await Db.InsertAsync(Data);
          return result;
        }


    }
}
