namespace Exercism.GenericTypes;

public class CircularBuffer<T>
{

    private int _capacity;
    private List<T> _buffer { get; set;}
    private int Capacity => _buffer.Capacity;
    private bool IsFull => _buffer.Count == _capacity;
    private bool IsEmpty => _buffer.Count == 0;

    private int CurrentIndex
    {
        get;
        set;
    } = 0;

    public CircularBuffer(int capacity)
    {
        _capacity = capacity;
        _buffer = new List<T>(capacity);
    }

    public T Read()
    {
        if (IsEmpty || CurrentIndex > _buffer.Count - 1) throw new InvalidOperationException();

        var res = _buffer[CurrentIndex];

        CurrentIndex += 1;
        _capacity += 1;
        return res;
    }

    public void Write(T value)
    {
        if(IsFull) throw new InvalidOperationException();
        _buffer.Add(value);
    }

    public void Overwrite(T value)
    {
        if (IsFull)
        {
            _buffer.RemoveAt(0);
        }

        _buffer.Add(value);
    }

    public void Clear()
    {
        _buffer = new List<T>(_capacity);
    }
}