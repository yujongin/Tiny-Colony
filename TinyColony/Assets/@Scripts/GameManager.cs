using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public List<Gate> gates;
  public ItemSpawner itemSpawner;
  int goalPoint;
  int currentPoint;
  private static GameManager instance;

  public static GameManager Instance
  {
    get
    {
      if (instance == null)
      {
        return null;
      }
      return instance;
    }
  }
  void Awake()
  {
    if (instance == null)
    {
      instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else
    {
      Destroy(gameObject);
    }

    itemSpawner = GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>();
  }
  void Start()
  {
    for (int i = 0; i < gates.Count; i++)
    {
      goalPoint += gates[i].maxHuman;
    }

  }

  public void UpdatePoint()
  {
    currentPoint++;
    if (goalPoint == currentPoint)
    {
      StageClear();
    }
  }

  public void StageClear()
  {
    Debug.Log("stage Clear!");
  }

  public void GameOver()
  {
    Debug.Log("GameOver");
  }

  public void Restart()
  {
    //scene reload
  }
}
