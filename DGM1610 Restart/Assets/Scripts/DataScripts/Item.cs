﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.U2D;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
  public new string name = "New Item";

  public bool isDefaultItem = false;
  
  public Sprite icon;
}
