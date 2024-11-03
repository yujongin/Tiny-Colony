using System;
using TMPro;
using UnityEngine;

public class LoadItemButton : MonoBehaviour
{
  public GameObject itemPrefab;
  public int remainCount;
  public string itemName;
  public TMP_Text remainCountText;

  public void AddItem()
  {
    if (remainCount > 0)
    {
      GameManager.Instance.itemSpawner.GetItem((ItemSpawner.ItemName)Enum.Parse(typeof(ItemSpawner.ItemName), itemName));
      remainCount--;
    }
  }

  // TODO : left Click, right Click event 

}
