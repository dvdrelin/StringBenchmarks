using System.Buffers;

namespace StringBenchmarks;

public sealed class AnotherOneStringBuilder : IDisposable
{
    private int _alreadyIn;
    private char[]? _chars;
    private char[]? _buffer;
    private string? _alreadyBuilt;
    private bool _disposed;

    public AnotherOneStringBuilder()
    {
        _chars = ArrayPool<char>.Shared.Rent(ushort.MaxValue * byte.MaxValue);
        _buffer = ArrayPool<char>.Shared.Rent(ushort.MaxValue);
    }

    public AnotherOneStringBuilder Clear()
    {
        _alreadyBuilt = null;
        _alreadyIn = 0;
        return this;
    }

    public AnotherOneStringBuilder Append(char value)
    {
        _alreadyBuilt = null;
        _chars![_alreadyIn] = value;
        _alreadyIn += 1;
        return this;
    }
    public AnotherOneStringBuilder Append(char[]? value)
    {
        if (value is null) return this;

        _alreadyBuilt = null;

        return Append(value.AsSpan());
    }
    public AnotherOneStringBuilder Append(Span<char> value)
    {
        _alreadyBuilt = null;

        value.CopyTo(_chars!.AsSpan().Slice(_alreadyIn, value.Length));

        _alreadyIn += value.Length;

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


    public AnotherOneStringBuilder Insert(int index, string value)
    {
        if (string.IsNullOrEmpty(value)) return this;

        if (index > _alreadyIn)
        {
            var message = $"{nameof(index)} (= {index}) has to be in range of currently accumulated string = [0, {_alreadyIn}]";
            throw new IndexOutOfRangeException(message);
        }
        
        _alreadyBuilt = null;

        var countThatShouldBeMoved = _alreadyIn - index;//zero based
        var restAsSpan = _buffer.AsSpan(0, countThatShouldBeMoved);
        _chars.AsSpan(index, countThatShouldBeMoved).CopyTo(restAsSpan);
        _alreadyIn = index;
        return Append(value).Append(restAsSpan);
    }

    public override string ToString() => _alreadyBuilt ??= new string(_chars!, 0, _alreadyIn);

    public void Dispose()
    {
        if (_disposed) return;

        ArrayPool<char>.Shared.Return(_buffer!);
        _buffer = null;

        ArrayPool<char>.Shared.Return(_chars!);
        _chars = null;

        _alreadyBuilt = null;
        _alreadyIn = 0;
        
        _disposed = true;
    }
}