using System.Threading.Tasks;

namespace TrackingApp.Services
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title, string buttonLabel);
    }
}
