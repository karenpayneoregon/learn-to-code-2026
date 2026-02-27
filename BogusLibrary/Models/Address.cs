using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BogusLibrary.Models;

public class Address 
{
    private int _id;
    private string _street;
    private string _city;
    private string _state;
    private string _zipCode;
    private string _country;
    public int Id { get => _id; set => SetField(ref _id, value); }

    public string Street { get => _street; set => SetField(ref _street, value); }

    public string City { get => _city; set => SetField(ref _city, value); }

    public string State { get => _state; set => SetField(ref _state, value); }

    public string ZipCode { get => _zipCode; set => SetField(ref _zipCode, value); }

    public string Country { get => _country; set => SetField(ref _country, value); }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /// <summary>
    /// Updates the specified field with a new value and raises the <see cref="PropertyChanged"/> event
    /// if the value has changed.
    /// </summary>
    /// <typeparam name="T">The type of the field being updated.</typeparam>
    /// <param name="field">A reference to the field to be updated.</param>
    /// <param name="value">The new value to assign to the field.</param>
    /// <param name="propertyName">
    /// The name of the property that corresponds to the field. This parameter is optional and is
    /// automatically provided by the compiler if not explicitly specified.
    /// </param>
    /// <returns>
    /// <c>true</c> if the field was updated and the <see cref="PropertyChanged"/> event was raised;
    /// otherwise, <c>false</c>.
    /// </returns>
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}