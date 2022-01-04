namespace Forum
{
    public class CustomerViewModel : ViewModelBase, IViewModelWithMessage
    {
        public string Message { get; private set; }

        public CustomerViewModel(int i)
        {
            Message = $"Customer {i} is greeting you!";
        }
    }
}
