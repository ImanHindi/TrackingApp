using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingApp.Services.LocalDb
{
    public interface ISQLite
    {

        string GetDbPath(string DbFileName);
        

    }
}
