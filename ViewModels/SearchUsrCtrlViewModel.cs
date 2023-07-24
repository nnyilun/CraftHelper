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
    public class SearchUsrCtrlViewModel : ViewModelBase
    {
        private readonly UserControl _this;

        public SearchUsrCtrlViewModel(UserControl main)
        {
            _this = main;
        }
    }
}
