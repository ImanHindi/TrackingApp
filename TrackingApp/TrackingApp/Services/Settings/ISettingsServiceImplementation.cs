using System;

namespace TrackingApp.Services.Settings
{
    public interface ISettingsServiceImplementation
    {
        bool GetValueOrDefault(string key, bool defaultValue);
        string GetValueOrDefault(string key, string defaultValue);
        DateTime GetValueOrDefault(string key, DateTime defaultValue);

        bool AddOrUpdateValue(string key, bool value);
        bool AddOrUpdateValue(string key, string value);
        bool AddOrUpdateValue(string key, DateTime value);
        void Remove(string key);
    }
}
