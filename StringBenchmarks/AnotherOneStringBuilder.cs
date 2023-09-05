using System.Buffers;

namespace StringBenchmarks;

public class AnotherOneStringBuilder : IDisposable
{
    private int _alreadyIn;
    private char[]? _chars;
    private string? _alreadyBuilt;

    public AnotherOneStringBuilder()
    {
        _chars = ArrayPool<char>.Shared.Rent(ushort.MaxValue * byte.MaxValue);
    }
    public AnotherOneStringBuilder Clear()
    {
        _alreadyBuilt = null;
        _alreadyIn = 0;
        return this;
    }
    public AnotherOneStringBuilder Append(string? value)
    {
        if (value is null) return this;
        _alreadyBuilt = null;
        value.AsSpan().CopyTo(_chars!.AsSpan().Slice(_alreadyIn, value.Length));
        _alreadyIn += value.Length;
        return this;
    }
    public AnotherOneStringBuilder Append(object? value)
    {
        if (value == default) return this;
        var valueAsString = (value as string) ;
        return Append(valueAsString ?? value.ToString());
    }

    public AnotherOneStringBuilder AppendLine(string? value=default) => Append(value).Append(Environment.NewLine);
    public AnotherOneStringBuilder AppendLine(char value) => Append(value).Append(Environment.NewLine);
    public AnotherOneStringBuilder Append(char value)
    {
        _alreadyBuilt = null;
        _chars![_alreadyIn] = value;
        _alreadyIn += 1;
        return this;
    }

    public override string ToString() => _alreadyBuilt ??= new string(_chars!, 0, _alreadyIn);

    public void Dispose()
    {
        if (_chars == null) return;
        ArrayPool<char>.Shared.Return(_chars!);
        _chars = null;
        _alreadyBuilt = null;
        _alreadyIn = 0;
    }
}