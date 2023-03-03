using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicleList : MonoBehaviour
{
    public void GivenArrayOfFixedLength_ThenReturnCorrectLength()
    {
        var students = new string[2];
        Assert.AreEqual(2, students.Length);
    }
}
