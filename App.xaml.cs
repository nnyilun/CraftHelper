using CraftHelper.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CraftHelper
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            StateTextModel._StateText = "状态  就绪";
            StateTextModel._Color = "Gray";
            SettingModel.ReadConfig();
            AboutModel.ConsolePrintBuildInfo();
        }
    }
}
