using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Chair
{
    public int id;
    public string name;
    public string description;
    public string filename;
    public int price;
}

[Serializable]
public class ChairList
{
    public List<Chair> chairs = new();
}