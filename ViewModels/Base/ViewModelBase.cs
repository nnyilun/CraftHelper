using CraftHelper.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CraftHelper.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        // 当类属性发生更改的时候，触发该事件，通知订阅者属性更改
        public event PropertyChangedEventHandler PropertyChanged;

        // 触发PropertyChanged事件。接收可选参数name，指定发生更改的属性名称。
        // 使用 CallerMemberName 特性，可以自动获取调用该方法的成员的名称作为参数，避免了手动指定属性名称。
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        // App._StateText.StateText为全局的static变量，App._StateText是单例，修改作用于全局
        public string StateText
        {
            get { return StateTextModel.StateText; }
            set { StateTextModel.StateText = value; OnPropertyChanged(); }
        }

        public string StateColor
        {
            get { return StateTextModel._Color; }
            set { StateTextModel._Color = value; OnPropertyChanged(); }
        }
    }
}
