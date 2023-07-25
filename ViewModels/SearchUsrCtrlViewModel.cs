using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CraftHelper.Models;
using CraftHelper.Views;
using CraftHelper.ViewModels.Base;

namespace CraftHelper.ViewModels
{
    public class SearchUsrCtrlViewModel : ViewModelBase
    {
        private readonly UserControl _this;
        private bool _isInput = false;
        private string _TextBoxContent = "请输入要搜索的物品名称";
        private string _TextBoxColor = "Gray";
        public ICommandBase SearchListBoxDoubleClickCommand { get; set; }
        public ICommandBase TextBoxGotFocusCommand { get; set; }

        public SearchUsrCtrlViewModel(UserControl main)
        {
            _this = main;
            SearchListBoxDoubleClickCommand = new ICommandBase((object param) => SearchListBoxDoubleClick(param as ListBox));
            TextBoxGotFocusCommand = new ICommandBase(TextBoxGotFocus);
        }

        private void SearchListBoxDoubleClick(ListBox obj) 
        {
            Console.WriteLine(obj.SelectedIndex);
        }

        private void TextBoxGotFocus()
        {
            if(!_isInput)
            {
                _isInput = true;
                TextBoxContent = "";
                TextBoxColor = "Black";
            }
        }

        public List<SearchModel.SearchInfo> SearchResultTable
        {
            get { return SearchModel.SearchResult; }
            set { SearchModel.SearchResult = value; OnPropertyChanged(); }
        }

        public List<SearchModel.SearchInfo> SearchAdditionTable
        {
            get { return SearchModel.SearchAddition; }
            set { SearchModel.SearchAddition = value; OnPropertyChanged(); }
        }

        public string TextBoxContent
        {
            get { return _TextBoxContent; }
            set { _TextBoxContent = value; OnPropertyChanged(); }
        }

        public string TextBoxColor
        {
            get { return _TextBoxColor; }
            set { _TextBoxColor = value; OnPropertyChanged(); }
        }
    }
}
