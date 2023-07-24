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
    public class ListUsrCtrlViewModel : ViewModelBase
    {
        private readonly UserControl _this;

        public ListUsrCtrlViewModel(UserControl main)
        {
            _this = main;
        }
    }
}
