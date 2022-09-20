using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrackingApp.ViewModels.Base;

namespace TrackingApp.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {

        public override async Task InitializeAsync(object navigationData)
        {
            await Task.Delay(500);
        }
    }
}
