using CommunityToolkit.Mvvm.Input;
using Material.Icons;
using SukiUI.Dialogs;
using SukiUI.MessageBox;
using SukiUI.Toasts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AvaStar.ViewModels
{
    public partial class SettingViewModel(ISukiDialogManager dialogManager, ISukiToastManager toastManager) : ViewModelBase("设置", MaterialIconKind.Settings, 99)
    {
        private readonly ISukiDialogManager _dialogManager = dialogManager;

        [RelayCommand]
        private void ShowDialog()
        {
            _dialogManager.CreateDialog()
                .WithTitle("A Standard Dialog")
                .WithContent("This is a standard dialog. Click the button below to dismiss.")
                .WithActionButton("Dismiss", _ => { }, true)
                .TryShow();
        }

        [RelayCommand]
        private async Task ShowMessageBoxAsync()
        {
            var result = await SukiMessageBox.ShowDialogResult("Are you sure you want to process this action?",
                SukiMessageBoxButtons.YesNo,
                title: "Basic question dialog",
                header: "Please confirm",
                icon: SukiMessageBoxIcons.Question);

            toastManager.CreateToast()
                .WithTitle("Dialog Option Clicked")
                .WithContent($"You clicked option: {result}")
                .Dismiss().ByClicking()
                .Dismiss().After(TimeSpan.FromSeconds(3))
                .Queue();
        }
    }
}
