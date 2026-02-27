using System.Buffers;
using System.Text;

namespace CommonHelpersLibrary.LanguageExtensions;

/// <summary>
/// <see cref="StringExtensions"/> that uses <see cref="StringBuilder"/>
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Joins the elements of the specified sequence into a single string, 
    /// using the specified separator between elements and a specified token 
    /// before the last element.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
    /// <param name="source">The sequence of elements to join.</param>
    /// <param name="separator">
    /// The string to use as a separator between elements. Defaults to ", " if not provided.
    /// </param>
    /// <param name="token">
    /// The string to insert before the last element. Defaults to "and" if not provided.
    /// </param>
    /// <returns>
    /// A string that consists of the elements of the sequence joined by the separator, 
    /// with the token inserted before the last element. Returns an empty string if the 
    /// sequence is null or empty.
    /// </returns>
    /// <remarks>
    /// This method is designed to be efficient with memory and performance, using
    /// stack allocation and pooled arrays as needed.
    ///
    /// See also version in <see cref="StringExtensions"/> that uses <see cref="StringBuilder"/>.
    /// </remarks>
    public static string JoinWithLastSeparator1<T>(this IEnumerable<T> source, string separator = ", ", string token = "and")
    {
        if (source is null) return string.Empty;
        separator ??= ", ";
        token ??= "and";

        using var e = source.GetEnumerator();
        if (!e.MoveNext()) return string.Empty;

        var first = e.Current?.ToString() ?? string.Empty;
        if (!e.MoveNext()) return first;

        // Start with a stack buffer; grow into pooled arrays if necessary.
        Span<char> initial = stackalloc char[256];
        var vsb = new ValueStringBuilder(initial);

        try
        {
            vsb.Append(first);

            // one-item lookbehind so we can insert the "token" cleanly
            var prev = e.Current?.ToString() ?? string.Empty;

            while (e.MoveNext())
            {
                vsb.Append(separator);
                vsb.Append(prev);
                prev = e.Current?.ToString() ?? string.Empty;
            }

            vsb.Append(' ');
            vsb.Append(token);
            vsb.Append(' ');
            vsb.Append(prev);

            return vsb.ToString();
        }
        finally
        {
            vsb.Dispose();
        }
    }

    // Faster path when you already have contiguous strings (e.g., string[]).
    public static string JoinWithLastSeparator(ReadOnlySpan<string> items, string separator = ", ", string token = "and")
    {
        if (items.Length == 0) return string.Empty;
        if (items.Length == 1) return items[0] ?? string.Empty;

        separator ??= ", ";
        token ??= "and";

        Span<char> initial = stackalloc char[256];
        var vsb = new ValueStringBuilder(initial);

        try
        {
            vsb.Append(items[0] ?? string.Empty);

            for (int i = 1; i < items.Length - 1; i++)
            {
                vsb.Append(separator);
                vsb.Append(items[i] ?? string.Empty);
            }

            vsb.Append(' ');
            vsb.Append(token);
            vsb.Append(' ');
            vsb.Append(items[^1] ?? string.Empty);

            return vsb.ToString();
        }
        finally
        {
            vsb.Dispose();
        }
    }

    // Minimal ValueStringBuilder (public-domain style; based on common patterns).
    private ref struct ValueStringBuilder
    {
        private Span<char> _span;
        private char[]? _arrayFromPool;
        private int _pos;

        public ValueStringBuilder(Span<char> initialBuffer)
        {
            _span = initialBuffer;
            _arrayFromPool = null;
            _pos = 0;
        }

        public void Append(char c)
        {
            if (_pos >= _span.Length) Grow(1);
            _span[_pos++] = c;
        }

        public void Append(string? s)
        {
            if (string.IsNullOrEmpty(s)) return;
            var src = s.AsSpan();
            if (src.Length > _span.Length - _pos) Grow(src.Length);
            src.CopyTo(_span.Slice(_pos));
            _pos += src.Length;
        }

        public void Append(ReadOnlySpan<char> s)
        {
            if (s.Length == 0) return;
            if (s.Length > _span.Length - _pos) Grow(s.Length);
            s.CopyTo(_span.Slice(_pos));
            _pos += s.Length;
        }

        private void Grow(int additionalNeeded)
        {
            // New size: double current or fit required, whichever is larger.
            int newSize = Math.Max(_pos + additionalNeeded, _span.Length * 2);
            var newArray = ArrayPool<char>.Shared.Rent(newSize);
            _span.Slice(0, _pos).CopyTo(newArray);
            if (_arrayFromPool is not null)
                ArrayPool<char>.Shared.Return(_arrayFromPool);
            _span = _arrayFromPool = newArray;
        }

        public override string ToString()
        {
            var s = new string(_span.Slice(0, _pos));
            return s;
        }

        public void Dispose()
        {
            if (_arrayFromPool is not null)
            {
                ArrayPool<char>.Shared.Return(_arrayFromPool);
                _arrayFromPool = null;
            }
        }
    }
}
