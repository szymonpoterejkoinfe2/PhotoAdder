﻿using PhotoAdder.ViewModel.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhotoAdder.ViewModel.Commands
{
    public class MinimizeWindowCommand : ICommand
    {
        private PhotoAdderVM VM;
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public MinimizeWindowCommand(PhotoAdderVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            VM.MinimizeWindow();
        }
    }
}
