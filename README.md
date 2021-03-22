# 2.WithBaseViewModel

Her er IPNC flyttet ud i en ViewModelBase-klasse, der indeholder en lidt mere avanceret `SetProperty<T>` metode:

```csharp
public class ViewModelBase : INotifyPropertyChanged
{
    protected bool SetProperty<T>(ref T backingStore, T value,
        [CallerMemberName] string propertyName = "", Action onChanged = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;
        onChanged?.Invoke();
        OnPropertyChanged(propertyName);
        return true;
    }

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        var changed = PropertyChanged;
        if (changed == null)
            return;

        changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}
```

&nbsp;

Det betyder en forenkling af de enkelte properties:

```csharp
string _name;
public string Name
{
    get { return _name; }
    set { SetProperty(ref _name, value); }
}
```