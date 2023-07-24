using CraftHelper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CraftHelper.Views
{
    /// <summary>
    /// ExportUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class ExportUserControl : UserControl
    {
        private readonly ExportUsrCtrlViewModel _ExportUsrCtrlVM;
        public ExportUserControl()
        {
            InitializeComponent();
            _ExportUsrCtrlVM = new ExportUsrCtrlViewModel(this);
            this.DataContext = _ExportUsrCtrlVM;
        }
    }
}
