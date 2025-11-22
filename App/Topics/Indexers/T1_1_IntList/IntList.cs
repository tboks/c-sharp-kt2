namespace App.Topics.Indexers.T1_1_IntList;

public class IntList
{
    private int[] data;
    private int count;

    public IntList()
    {
        data = new int[4];
        count = 0;
    }

    public int Count => count;

    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index));
            return data[index];
        }
        set
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == count)
            {
                EnsureCapacity(count + 1);
                data[count] = value;
                count++;
            }
            else if (index < count)
            {
                data[index] = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
    }

    private void EnsureCapacity(int minCapacity)
    {
        if (data.Length < minCapacity)
        {
            int newCapacity = data.Length * 2;
            if (newCapacity < minCapacity)
                newCapacity = minCapacity;
            Array.Resize(ref data, newCapacity);
        }
    }
}
