using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrackingApp.Services.Motion;
using TrackingApp.ViewModels.Base;
using TrackingApp.Models.Motion;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using DeviceMotion.Plugin.Abstractions;

namespace TrackingApp.ViewModels
{
    public class MotionDetectionViewModel : ViewModelBase
    {
        private MotionInfo _motionInfo;
        private readonly IMotionDetection _motionDetection;
        private ObservableCollection<MotionInfo> _listofMotionInfo;

        public MotionDetectionViewModel(IMotionDetection motionDetection)
        {

            _motionDetection = motionDetection;
        }

        public MotionInfo MotionInfo
        {
            get
            {
                return _motionInfo;
            }
            set
            {
                _motionInfo = value;
                RaisePropertyChanged(() => MotionInfo);
            }
        }
        public ObservableCollection<MotionInfo> ListofMotionInfo
        {
            get { return _listofMotionInfo; }
            set
            {
                _listofMotionInfo = value;
                RaisePropertyChanged(() => ListofMotionInfo);
            }
        }

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            await Task.Delay(100);
            MessagingCenter.Subscribe<MotionDetection, MotionInfo>(this, MessageKeys.UpdateMotion, (sender, arg) =>
            {

                _motionInfo = AddDataAsync(arg);
                MotionInfo = _motionInfo;
                if (ListofMotionInfo == null)
                    ListofMotionInfo = new ObservableCollection<MotionInfo>();
                ListofMotionInfo.Add(new MotionInfo
                {
                    
                    DataTimeOffset = _motionInfo.DataTimeOffset,
                    Date = _motionInfo.Date,
                    Time = _motionInfo.Time,
                    ValueType = _motionInfo.ValueType,
                    SensorType = _motionInfo.SensorType,
                    Value = _motionInfo.Value,
                    XValue= _motionInfo.XValue,
                    YValue= _motionInfo.YValue,
                    ZValue= _motionInfo.ZValue,

                });                RaisePropertyChanged(() => ListofMotionInfo);

            });

            IsBusy = false;

         }
                                                                            

        private MotionInfo AddDataAsync(MotionInfo Data)
        {
            _motionInfo = new MotionInfo()
            {
                ValueType = Data.ValueType,
                SensorType = Data.SensorType,
                Value = Data.Value,
                DataTimeOffset = Data.DataTimeOffset,
                Date = DateTime.Now,
                Time = DateTime.Now.TimeOfDay,            
            };
            if (_motionInfo.ValueType == DeviceMotion.Plugin.Abstractions.MotionSensorValueType.Vector)
            {
                _motionInfo.XValue = ((MotionVector)Data.Value).X;
                _motionInfo.YValue = ((MotionVector)Data.Value).Y;
                _motionInfo.ZValue = ((MotionVector)Data.Value).Z;

            }
            if (_motionInfo.ValueType == DeviceMotion.Plugin.Abstractions.MotionSensorValueType.Single)
            {
                _motionInfo.XValue = (double)Data.Value.Value;
                _motionInfo.YValue = 0;
                _motionInfo.ZValue = 0;

            }
            return _motionInfo;
        }
   }

}
