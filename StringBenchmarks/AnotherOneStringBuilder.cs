using System.Buffers;

public class AnotherOneStringBuilder : IDisposable
{
    private int _alreadyIn;
    private char[]? _chars;
    private string? _alreadyBuilt;

    public AnotherOneStringBuilder()
    {
        _chars = ArrayPool<char>.Shared.Rent(ushort.MaxValue*byte.MaxValue);
    }

    public AnotherOneStringBuilder Append(string value)
    {
        _alreadyBuilt = null;
        value.AsSpan().CopyTo(_chars!.AsSpan()[_alreadyIn..]);
        _alreadyIn += value.Length;
        return this;
    }

    public override string ToString() => _alreadyBuilt ??= new(_chars!, 0, _alreadyIn);

    public void Dispose()
    {
        if (_chars == null) return;
        ArrayPool<char>.Shared.Return(_chars!);
        _chars = null;
        _alreadyBuilt = null;
        _alreadyIn = 0;
    }
}