using System.ComponentModel;
using System.Text.Json.Serialization;
using BogusLibrary.Classes;

namespace BogusLibrary.Models;

public class Human : PropertySetters, INotifyPropertyChanged
{
    private int _id;
    public int Id { get => _id; set => SetField(ref _id, value); }

    private string _firstName;
    public string FirstName { get => _firstName; set => SetField(ref _firstName, value); }

    private string _lastName;
    public string LastName { get => _lastName; set => SetField(ref _lastName, value); }

    private DateTime? _birthDay;
    [JsonIgnore]
    public DateTime? BirthDay { get => _birthDay; set => SetField(ref _birthDay, value); }
    
    private DateOnly _birthDate;
    //[JsonIgnore]
    public DateOnly BirthDate { get => _birthDate; set => SetField(ref _birthDate, value); }

    private string _email;
    public string Email { get => _email; set => SetField(ref _email, value); }
    
    private Gender? _gender;
    public Gender? Gender { get => _gender; set => SetField(ref _gender, value); }
    
    private string _socialSecurityNumber;
    public string SocialSecurityNumber { get => _socialSecurityNumber; set => SetField(ref _socialSecurityNumber, value); }
    
    private Address _address;
    public Address Address { get => _address; set => SetField(ref _address, value); }

}