internal void Update()
{
    ClassBooks = new ObservableCollection<ClassBook>(ClassBooks);
    OnPropertyChanged(nameof(ClassBooks));
}