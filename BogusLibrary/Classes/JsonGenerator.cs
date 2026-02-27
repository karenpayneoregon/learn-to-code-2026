using System.Text.Json;

namespace BogusLibrary.Classes;
public static class JsonGenerator
{

    public static string HumansAsJson(int count, bool random = false) 
        => HumanGenerator.Create(count, random).GenerateJson();
    
    public static string ProductsAsJson(int count, bool random = false) 
        => ProductGenerator.Create(count, random).GenerateJson();

    public static string UsersAsJson(int count, bool random = false)
        => UserGenerator.Create(count, random).GenerateJson();

    public static string CategoriesAsJson(int count, bool random = false)
        => CategoryGenerator.Create(count, random).GenerateJson();

    public static string GenerateJson<T>(this T data) => JsonSerializer.Serialize(data, Indented);
    public static JsonSerializerOptions Indented => new() { WriteIndented = true };
}
