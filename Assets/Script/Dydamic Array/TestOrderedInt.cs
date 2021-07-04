using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestOrderedInt : MonoBehaviour
{
    void Start()
    {
        TestAddMiddle();
        TestRemoveMiddle();
    }

    void TestAddMiddle()
    {
        OrderedInt array = new OrderedInt();
        array.Add(40);
        array.Add(42);
        array.Add(41);
        Debug.Log("TestAddMiddle");
        String arrayString = array.ToString();
        if(arrayString.Equals("40,41,42") && array.Count == 3)
        {
            Debug.Log("Passed");
        }
        else
        {
            Debug.Log("Failed! it not : " + arrayString);
        }
    }
    void TestRemoveMiddle()
    {
        OrderedInt array = new OrderedInt();
        array.Add(40);
        array.Add(41);
        array.Add(42);
        Debug.Log("TestRemoveMiddle");
        bool removed = array.Remove(41);
        String arrayString = array.ToString();
        if (arrayString.Equals("40,42") && array.Count == 2)
        {
            Debug.Log("Passed");
        }
        else
        {
            Debug.Log("Failed! it not : " + arrayString);
        }
    }
}
