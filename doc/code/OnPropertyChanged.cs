public class SomeViewModel : ViewModelBase
{
    public string SomeName
    {
        get{ return SomeName; }
        set
        {
            SomeName = value;
            OnPropertyChanged(nameof(SomeName));
        }
    }
}