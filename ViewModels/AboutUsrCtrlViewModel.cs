using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CraftHelper.Views;
using CraftHelper.ViewModels.Base;
using CraftHelper.Models;

namespace CraftHelper.ViewModels
{
    public class AboutUsrCtrlViewModel : ViewModelBase
    {
        private readonly UserControl _this;

        public readonly string VersionText = "程序版本: " + SettingModel._Version;
        public readonly string runtimeVersionText = "运行时版本: " + SettingModel.runtimeVersion;
        public readonly string OSText = "操作系统: " + SettingModel.os;

        public ICommandBase AlibabaIconLinkedCommand { get; set; }
        public ICommandBase SideBarLinkedCommand { get; set; }

        public AboutUsrCtrlViewModel(UserControl main)
        {
            _this = main;

            AlibabaIconLinkedCommand = new ICommandBase(AlibabaIconLinked);
            SideBarLinkedCommand = new ICommandBase(SideBarLinked);
        }

        private void AlibabaIconLinked()
        {
            System.Diagnostics.Process.Start(AboutModel.PageIcon);
        }

        private void SideBarLinked()
        {
            System.Diagnostics.Process.Start(AboutModel.SideBar);
        }
    }
}
