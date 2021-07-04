using System.Collections;
using System.Collections.Generic;
using System.Text;

abstract class IntDynamicArray 
{
    const int ExpandMultioleFactor = 2;
    protected int[] itemsArray;
    protected int count;
    protected IntDynamicArray()
    {
        itemsArray = new int[4];
        count = 0;
    }
    public abstract void Add(int item);
    public abstract bool Remove(int item);
    public abstract int IndexOf(int item);
    public abstract int LastIndexOf(int item);
    public abstract string AllIndexOf(int item);
    public abstract List<int> TurnToOutput();
    public abstract int LastInIndex();
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        for(int i = 0; i < count; i++)
        {
            builder.Append(itemsArray[i]);
            if(i < count - 1)
            {
                builder.Append(",");
            }
        }
        return builder.ToString();
    }
    protected void Expand()
    {
        int[] newItems = new int[itemsArray.Length * ExpandMultioleFactor];
        for(int i = 0; i < itemsArray.Length; i++)
        {
            newItems[i] = itemsArray[i];
        }
        itemsArray = newItems;
    }
    public int Count { get { return count; } }
    public void Clear() { count = 0; }
}
