# About

This project demonstrates simple unit tests, the use of a base class, and test events.

:sparkles: Data is retrieved from `BogusLibrary.csproj`

## NuGet Packages

- [Shouldly](https://www.nuget.org/packages/Shouldly/4.3.0?_src=template)  is an assertion framework which focuses on giving great error messages when the assertion fails while being simple and terse.
- [CompareNETObjects](https://www.nuget.org/packages/CompareNETObjects/4.83.0?_src=template) for deep compare of any two .NET objects using reflection. Shows the differences between the two objects.

## TestConfiguration class

The `TestConfiguration` class gets data used for test which is a singleton with a private constructor. The `Instance` method is used to get the instance of the class. Note the private constructor is called the first time the `Instance` method is called. 

---