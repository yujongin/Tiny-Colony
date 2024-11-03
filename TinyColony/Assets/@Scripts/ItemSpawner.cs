using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
  public enum ItemName
  {
    Human,
    House01,
    House02,
    Tree01,
    Tree02,
    WindTurbine,
    NuclearPowerStation
  }

  public Launcher launcher;
  public List<ItemBase> items;

  public void GetItem(ItemName name)
  {
    //Get Object in ItemBasePool

    //Add Item in Launcher
    //launcher.AddItem();
  }


}
