using IComparableApp.Models;
using System.Text.Json;

namespace IComparableApp.Classes;
/// <summary>
/// Provides methods for handling mocked data, including reading and writing 
/// bank account information to and from a JSON file.
/// </summary>
/// <remarks>
/// This class is designed to simulate data retrieval and storage, 
/// mimicking interactions with a cloud-based service. It ensures that 
/// default data is initialized if the required file is missing.
/// </remarks>
internal class MockedData
{
    /// <summary>
    /// Creates and initializes an array of <see cref="BankAccount"/> objects.
    /// </summary>
    /// <returns>
    /// An array of <see cref="BankAccount"/> objects with predefined names and balances.
    /// </returns>
    /// <remarks>
    /// This method is used to provide a collection of bank accounts for further processing, 
    /// such as sorting or displaying in a tabular format.
    /// </remarks>
    private static BankAccount[] CreateBankAccountsArray() =>
    [
        new BankAccount { Name = "Jack",  Balance = 150.08M },
        new BankAccount { Name = "Mary",  Balance = 3400.00M },
        new BankAccount { Name = "James", Balance = 70.45M },
        new BankAccount { Name = "John",  Balance = 200.01M }
    ];

    /// <summary>
    /// Reads bank account data from a JSON file. If the file does not exist, it creates a new file
    /// with default bank account data and then reads from it.
    /// </summary>
    /// <returns>
    /// An array of <see cref="BankAccount"/> objects if the file exists or is successfully created; 
    /// otherwise, <see langword="null"/> if deserialization fails.
    /// </returns>
    /// <remarks>
    /// The method uses the file "accounts.json" to store and retrieve bank account data. 
    /// If the file is missing, it initializes the file with default data.
    ///
    /// Think of this as receiving data from a cloud service.
    /// 
    /// </remarks>
    public static BankAccount[]? AccountsFromFile()
    {
        var fileName = "accounts.json";

        if (!File.Exists(fileName))
        {
            var accounts = CreateBankAccountsArray();

            var json = JsonSerializer.Serialize(accounts, Indented);
            File.WriteAllText("accounts.json", json);
        }

        var json1 = File.ReadAllText("accounts.json");

        return JsonSerializer.Deserialize<BankAccount[]>(json1, Indented);
    }

    public static JsonSerializerOptions Indented => new() { WriteIndented = true };

}
