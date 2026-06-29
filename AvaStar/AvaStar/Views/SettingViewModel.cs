using System;
using System.Collections.Generic;
using System.Text;
using AvaStar.ViewModels;
using Material.Icons;

namespace AvaStar.Views
{
    public class SettingViewModel : ViewModelBase
    {
        public SettingViewModel() : base("设置", MaterialIconKind.Settings, 99)
        {
        }
    }
}
