using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CraftHelper.ViewModels.Base;
using CraftHelper.Views;

namespace CraftHelper.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly MainWindow _Main;
        private Type _Type;
        private FrameworkElement _MainContent;
        private string state_tmp;
        public ICommandBase ChangePageCommand { get; set; }
        public ICommandBase QuitCommand { get; set; }
        //public ICommandBase PanelMouseLeaveCommand { get; set; }
        public ICommandBase TgBtnMouseLeftDown { get; set; }
        public ICommandBase TgBtnMouseMove { get; set; }
        public ICommandBase TgBtnMouseLeftUp { get; set; }
        public ICommandBase ListViewItemMouseEnterCommand { get; set; }
        public ICommandBase ListViewItemMouseLeaveCommand { get; set; }


        public MainWindowViewModel(MainWindow main)
        {
            _Main = main;
            ChangePageCommand = new ICommandBase(ChangePage);
            ChangePage("MainUserControl");

            //PanelMouseLeaveCommand = new ICommandBase(PanelMouseLeave);
            QuitCommand = new ICommandBase(Quit);

            TgBtnMouseLeftDown = new ICommandBase((object param) => { Tg_Btn_PreviewMouseLeftButtonDown(param as MouseButtonEventArgs); });
            TgBtnMouseMove = new ICommandBase((object param) => { Tg_Btn_PreviewMouseMove(param as MouseEventArgs); });
            TgBtnMouseLeftUp = new ICommandBase((object param) => { Tg_Btn_PreviewMouseLeftButtonUp(param as MouseButtonEventArgs); });

            ListViewItemMouseEnterCommand = new ICommandBase(ListViewItemMouseEnter);
            ListViewItemMouseLeaveCommand = new ICommandBase(ListViewItemMouseLeave);
        }


        // ------ change page ------
        private void ChangePage(object obj)
        {
            _Type = Type.GetType("CraftHelper.Views." + obj.ToString());
            // Console.WriteLine(_Type.ToString());
            MainContent = (FrameworkElement)System.Activator.CreateInstance(_Type);
        }

        public FrameworkElement MainContent
        {
            get { return _MainContent; }
            set { _MainContent = value; OnPropertyChanged(); }
        }


        //// ------ panel animation ------
        //public void PanelMouseLeave()
        //{
        //    _Main.Tg_Btn.IsChecked = false;
        //}


        // ------ list view item mouse event ------
        private void ListViewItemMouseEnter(object obj)
        {
            var _ = ((ViewModelBase)MainContent.DataContext);
            state_tmp = _.StateText;
            _.StateText = obj.ToString();
            _.StateColor = "Orange";
        }

        private void ListViewItemMouseLeave()
        {
            var _ = ((ViewModelBase)MainContent.DataContext);
            _.StateText = state_tmp;
            _.StateColor = "Gray";
        }


        // ------ quit ------
        private void Quit()
        {
            _Main.Close();
        }

        // ------ move window ------
        Point _pressedPosition;
        bool _isDragMoved = false;
        readonly int _DragEventDis = 0;

        private double GetPointDistance(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }

        private void Tg_Btn_PreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            _pressedPosition = e.GetPosition(_Main);
        }

        private void Tg_Btn_PreviewMouseMove(MouseEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed && GetPointDistance(_pressedPosition, e.GetPosition(_Main)) > _DragEventDis)
            {
                if (!_isDragMoved)
                {
                    _isDragMoved = true;
                    _Main.DragMove();
                }
                _isDragMoved = false;
            }
        }

        private void Tg_Btn_PreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            _isDragMoved = false;
            if (_isDragMoved)
            {
                e.Handled = true;
            }
        }
    }
}
