using PhotoAdder.ViewModel.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhotoAdder.ViewModel.Commands
{
    public class SelectSaveFolderCommand : ICommand
    {
        private PhotoAdderVM VM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public SelectSaveFolderCommand(PhotoAdderVM vm) 
        { 
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            VM.SelectSaveFolder();
        }
    }
}
