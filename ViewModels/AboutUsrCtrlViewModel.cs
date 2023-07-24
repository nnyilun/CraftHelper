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
using System.Windows.Input;

namespace CraftHelper.ViewModels
{
    public class AboutUsrCtrlViewModel : ViewModelBase
    {
        private readonly UserControl _this;

        public readonly string _VersionText = "程序版本: " + SettingModel._Version;
        public readonly string _RuntimeVersionText = "当前运行时版本: " + SettingModel.runtimeVersion;
        public readonly string _OSText = "当前操作系统: " + SettingModel.os;

        public ICommandBase AlibabaIconLinkedCommand { get; set; }
        public ICommandBase SideBarLinkedCommand { get; set; }
        public ICommandBase MITBtnClickCommand { get; set; }
        public ICommandBase BuildInfoBtnClickCommand { get; set; }

        public AboutUsrCtrlViewModel(UserControl main)
        {
            _this = main;

            AlibabaIconLinkedCommand = new ICommandBase(AlibabaIconLinked);
            SideBarLinkedCommand = new ICommandBase(SideBarLinked);
            MITBtnClickCommand = new ICommandBase(MITBtnClick);
            BuildInfoBtnClickCommand = new ICommandBase(BuildInfoBtnClick);
        }

        private void AlibabaIconLinked()
        {
            System.Diagnostics.Process.Start(AboutModel.PageIcon);
        }

        private void SideBarLinked()
        {
            System.Diagnostics.Process.Start(AboutModel.SideBar);
        }

        private void MITBtnClick()
        {
            MITLicenseWindow _MITLicenseWindow = new MITLicenseWindow(this);
            _MITLicenseWindow.ShowDialog();
        }

        private void BuildInfoBtnClick()
        {
            BuildInfoWindow _BuildInfoWindow = new BuildInfoWindow(this);
            _BuildInfoWindow.ShowDialog();
        }

        public string VersionText { get { return _VersionText; } }
        public string RuntimeVersionText { get { return _RuntimeVersionText; } }
        public string OSText { get { return _OSText; } }
        public string MITText { get { return AboutModel.MIT_license; } }
        public List<AboutModel.MyBuildInfo> BuildInfoTable { get { return AboutModel._BuildInfo; } }
    }
}
