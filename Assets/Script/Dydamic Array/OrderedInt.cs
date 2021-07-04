using System.Collections;
using System.Collections.Generic;
using System.Text;

class OrderedInt : IntDynamicArray
{
    public OrderedInt() : base() { }

public override void Add(int item)
    {
        if(count == itemsArray.Length)
        {
            Expand();
        }
        int addLocation = 0;
        while( (addLocation < count) && (itemsArray[addLocation] < item))
        {
            addLocation++;
        }
        ShiftUp(addLocation);
        itemsArray[addLocation] = item;
        count++;
    }
    void ShiftUp(int index)
    {
        for (int i = count; i > index; i--)
        {
            itemsArray[i] = itemsArray[i - 1];
        }
    }
    void ShiftDown(int index)
    {
        for (int i = index; i < count; i++)
        {
            itemsArray[i-1] = itemsArray[i];
        }
    }
    public override bool Remove(int item)
    {
        int itemLocation = IndexOf(item);
        if(itemLocation == -1)
        {
            return false;
        }
        else
        {
            ShiftDown(itemLocation + 1);
            count--;
            return true;
        }
    }
    public override int IndexOf(int item)
    {
        int lowerBound = 0;
        int upperBound = count - 1;
        int location = -1;

        while(location == -1)
        {
            int middleLocation = lowerBound + (upperBound - lowerBound) / 2;
            int middleValue = itemsArray[middleLocation];
            if(middleValue == item)
            {
                location = middleLocation;
            }
            else
            {
                if(middleValue > item)
                {
                    upperBound = middleLocation - 1;
                }
                else
                {
                    lowerBound = middleLocation + 1;
                }
                if (lowerBound > upperBound) 
                {
                    break; 
                }
            }
        }
        return location;
    }
    public override string AllIndexOf(int item)
    {
        throw new System.NotImplementedException();
    }
    public override int LastIndexOf(int item)
    {
        throw new System.NotImplementedException();
    }
    public override List<int> TurnToOutput()
    {
        throw new System.NotImplementedException();
    }
    public override int LastInIndex()
    {
        return itemsArray[count];
    }
}
