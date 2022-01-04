using System;
using System.Windows.Input;

namespace Forum
{
    internal class MoveToNextViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private ViewModelBase viewModel;

        public MoveToNextViewModelCommand(ViewModelBase anyViewModel)
        {
            viewModel = anyViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (viewModel is MainWindowViewModel mainViewModel)
            {
                if (mainViewModel.Index == mainViewModel.ViewModels.Count)
                {
                    mainViewModel.Index = 0;
                }
                if (mainViewModel.ViewModels[mainViewModel.Index] is IViewModelWithMessage viewModelWithMessage)
                {
                    mainViewModel.NewMessage = viewModelWithMessage.Message;
                }
                else
                {
                    mainViewModel.NewMessage = $"ViewModel at Index { mainViewModel.Index } is of type { mainViewModel.ViewModels[mainViewModel.Index] } and has therefore no Message-Property";
                }
                mainViewModel.Index++;
            }
        }
    }
}