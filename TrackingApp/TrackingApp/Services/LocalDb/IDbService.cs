using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;


namespace TrackingApp.Services.LocalDb
{
    public interface IDbServices

    {

        //  Task<ObservableCollection<T>> GetDataAsync<T>(bool InternetConnection);
        Task<ObservableCollection<T>> GetTables<T>();

        Task<ObservableCollection<T>> GetDataAsync<T>(int Id);

         Task<int> AddDataAsync<T>(T Data);

        
    }
}
