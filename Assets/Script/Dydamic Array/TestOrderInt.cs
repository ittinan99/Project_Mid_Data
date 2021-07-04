using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TestOrderInt : MonoBehaviour
{
    void Start()
    {
        //AddEmpty();
        //AddExpand();
        //RemoveEmpty();
        //CheckDuplicateItem();
        //CheckLastItem();
    }
    void AddEmpty()
    {
        UnOrderInt array = new UnOrderInt();
        array.Add(5);
        Debug.Log("AddEmpty : ");
        String arrayString = array.ToString();
        if(arrayString.Equals("5") && array.Count == 1)
        {
            Debug.Log("Passed");
        }
        else
        {
            Debug.Log("Failed! Expected : 5 but Actual : " + arrayString);
        }
    }
    void AddExpand()
    {
        UnOrderInt array = new UnOrderInt();
        array.Add(5);
        array.Add(7);
        array.Add(2);
        array.Add(9);
        array.Add(1);
        array.Add(4);
        Debug.Log("AddExpand : ");
        String arrayString = array.ToString();
        if(arrayString.Equals("5,7,2,9,1,4") && array.Count == 6)
        {
            Debug.Log("Passed");
        }
        else
        {
            Debug.Log("Failed! Expected : 5,7,2,9,1,4 but Actual : " + arrayString);
        }
    }
    void RemoveEmpty()
    {
        UnOrderInt array = new UnOrderInt();
        Debug.Log("removeEmpty : ");
        if(!array.Remove(5))
        {
            Debug.Log("Passed");
        }
        else
        {
            Debug.Log("Failed! Expect : false Actucl : true");
        }
    }
    void CheckDuplicateItem()
    {
        UnOrderInt array = new UnOrderInt();
        array.Add(3);
        array.Add(4);
        array.Add(5);
        array.Add(5);
        array.Add(6);

        String arrayString = array.AllIndexOf(5);

        if (arrayString.Equals("2,3"))
        {
            Debug.Log("Passed");
        }
        else
        {
            Debug.Log("Failed! Expect : CheckDuplicateItem != 2,3");
        }
    }
    void CheckLastItem()
    {
        UnOrderInt array = new UnOrderInt();
        array.Add(3);
        array.Add(4);
        array.Add(5);
        array.Add(5);
        array.Add(6);

        if(array.LastIndexOf(6) == 4)
        {
            Debug.Log("Passed");
        }
        else
        {
            Debug.Log("Failed! Expect : CheckLastItem != 6");
        }
    }
}
