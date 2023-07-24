using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CraftHelper.Views;
using CraftHelper.ViewModels.Base;

namespace CraftHelper.ViewModels
{
    public class ExportUsrCtrlViewModel : ViewModelBase
    {
        private readonly UserControl _this;

        public ExportUsrCtrlViewModel(UserControl main)
        {
            _this = main;
        }
    }
}
