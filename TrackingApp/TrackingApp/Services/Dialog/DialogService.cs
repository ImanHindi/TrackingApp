using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrackingApp.Services

{

    public class DialogService : IDialogService

    {
        private static Acr.UserDialogs.IProgressDialog currentProgressDialog;

        public Task ShowAlertAsync(string message, string title, string buttonLabel)

        {

            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);

        }
        public static void LoadProgressDialog(string title)
        {
            currentProgressDialog = Acr.UserDialogs.UserDialogs.Instance.Loading(title, maskType: Acr.UserDialogs.MaskType.Clear);
        }

        public static void HideProgressDialog()
        {
            currentProgressDialog?.Hide();
        }

        public static void ShowProgressDialog()
        {
            currentProgressDialog?.Show();
        }

        public static void DisposeProgressDialog()
        {
            currentProgressDialog?.Dispose();
            currentProgressDialog = null;
        }



    }

}