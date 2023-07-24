using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CraftHelper.ViewModels.Base
{
    public class ICommandBase : ICommand
    {
        public Action ExecuteAction { get; set; }
        public Func<bool> CanExecuteFunc { get; set; }
        public Action<object> ExecuteParaAction { get; set; }
        public Func<object, bool> CanExecuteParaFunc { get; set; }

        // 可执行状态发生改变时触发该事件
        public event EventHandler CanExecuteChanged;

        // executeAction指定命令执行逻辑，可选参数canExecuteFunc指定命令的可执行状态判断逻辑
        public ICommandBase(Action executeAction, Func<bool> canExecuteFunc = null) 
        {
            this.ExecuteAction = executeAction;
            this.CanExecuteFunc = canExecuteFunc;
        }

        // executeParaAction指定带参数命令的执行逻辑，可选参数canExecuteParaFunc指定命令的可执行状态判断逻辑
        public ICommandBase(Action<object> executeParaAction, Func<object, bool> canExecuteParaFunc = null)
        {
            this.ExecuteParaAction = executeParaAction;
            this.CanExecuteParaFunc = canExecuteParaFunc;
        }

        // 判断命令是否可执行，如果传入参数则调用CanExecuteParaFunc，否则调用CanExecuteFunc
        public bool CanExecute(object parameter = null)
        {
            if (parameter == null)
            {
                return this.CanExecuteFunc == null || CanExecuteFunc.Invoke();
            }
            return CanExecuteParaFunc == null || CanExecuteParaFunc.Invoke(parameter);
        }

        // 执行命令
        public void Execute(object parameter = null)
        {
            if (parameter == null)
            {
                ExecuteAction?.Invoke();
            }
            else
            {
                ExecuteParaAction?.Invoke(parameter);
            }
        }
    }
}
