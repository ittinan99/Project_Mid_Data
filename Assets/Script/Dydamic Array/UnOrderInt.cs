using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class UnOrderInt : IntDynamicArray
{
    public List<int> baseList = new List<int>();
    public UnOrderInt() : base() { }
    public override void Add(int item)
    {
        if(count == itemsArray.Length)
        {
            Expand();
        }
        itemsArray[count] = item;
        count++;
    }

    public override int IndexOf(int item)
    {
        for(int i = 0; i < count; i++)
        {
            if(itemsArray[i] == item)
            {
                return i;
            }
        }
        return -1;
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
            itemsArray[itemLocation] = itemsArray[count - 1];
            count--;
            return true;
        }
    }

    public override int LastIndexOf(int item)
    {
        for(int i = count-1; i >= 0; i--)
        {
            if (itemsArray[i] == item)
            {
                return i;
            } 
        }
        return -1;
    }

    public override string AllIndexOf(int item)
    {
        UnOrderInt duplicateItem = new UnOrderInt();
        for (int i = 0; i < count; i++)
        {
            if(itemsArray[i] == item)
            {
                duplicateItem.Add(i);
            }
        }
        if(duplicateItem != null)
        {
            return duplicateItem.ToString();
        }
        else
        {
            return "EmptyList";
        }
    }
    public override List<int> TurnToOutput()
    {
        for (int i = 0; i < count ; i++)
        {
            baseList.Add(itemsArray[i]);
        }               
        return baseList;        
    }
    public override int LastInIndex()
    {
        return itemsArray[count-1];
    }
}
