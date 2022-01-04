using System.Collections.Generic;
using System.Windows.Input;

namespace Forum
{
    public class MainWindowViewModel : ViewModelBase
    {
        public int Index { get; set; }

        public List<ViewModelBase> ViewModels { get; set; }

        private string newMessage;

        public string NewMessage
        {
            get { return newMessage; }
            set
            {
                if (newMessage != value)
                {
                    newMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand MoveToNextViewModelCmd { get; }

        public MainWindowViewModel()
        {
            Index = 0;
            ViewModels = new List<ViewModelBase>();
            for (int i = 0; i < 2; i++)
            {
                ViewModels.Add(new CustomerViewModel(i));
            }
            for (int i = 0; i < 3; i++)
            {
                ViewModels.Add(new NonCustomerViewModel());
            }
            for (int i = 5; i < 10; i++)
            {
                ViewModels.Add(new CustomerViewModel(i));
            }
            MoveToNextViewModelCmd = new MoveToNextViewModelCommand(this);
        }
    }
}
