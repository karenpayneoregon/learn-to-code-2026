namespace BasicObjectsExamples.Classes.Virtual;
public class Employee
{
    // Virtual property
    public virtual decimal Bonus => 1_000m;
}

public class Manager : Employee
{
    // Override the virtual property
    public override decimal Bonus => 5_000m;
}