using System.Text.Json;

namespace JsonCommentsSample.Classes.Configuration;

/// <summary>
/// Provides functionality to add comments to JSON output during serialization.
/// </summary>
/// <remarks>
/// This class extends <see cref="JsonCommentConverter{TBase}"/> and is designed to append a comment
/// to the serialized JSON output. The comment is enclosed within delimiters (e.g., /* and */).
/// </remarks>
/// <param name="comment">
/// The comment text to be appended to the JSON output. This text will be wrapped in comment delimiters.
/// </param>
public class JsonCommentConverter(string comment) : JsonCommentConverter<object>(comment) { }

/// <summary>
/// Provides a mechanism to append comments to JSON output during serialization for types derived from <typeparamref name="TBase"/>.
/// </summary>
/// <typeparam name="TBase">
/// The base type for which the JSON comment converter is applicable. All types to be converted must derive from this type.
/// </typeparam>
/// <remarks>
/// This class extends <see cref="DefaultConverterFactory{TBase}"/> and customizes the JSON serialization process by appending
/// a comment to the serialized JSON output. The comment is enclosed within delimiters (e.g., /* and */).
/// </remarks>
/// <param name="comment">
/// The comment text to be appended to the JSON output. This text will be wrapped in comment delimiters.
/// </param>
public class JsonCommentConverter<TBase>(string comment) : DefaultConverterFactory<TBase>
{
    private readonly string _commentWithDelimiters = $" /*{comment}*/";

    protected override void Write<T>(Utf8JsonWriter writer, T value, JsonSerializerOptions modifiedOptions)
    {
        var json = JsonSerializer.Serialize(value, modifiedOptions);
        writer.WriteRawValue(json + _commentWithDelimiters, skipInputValidation: true);
    }

    protected override JsonSerializerOptions ModifyOptions(JsonSerializerOptions options)
    {
        var modifiedOptions = base.ModifyOptions(options);
        modifiedOptions.WriteIndented = false;
        return modifiedOptions;
    }
}