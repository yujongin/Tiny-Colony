
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject[] stagePrefabs;
    public  StageData[] stageDatas;

    public GameObject currentStagePrefab;
    public StageData currentStageData;
    int currentIndex;
    public int CurrentIndex
    {
        get
        {
            return currentIndex;
        }
        set
        {
            currentIndex = value;
            if (value == 5)
            {
                Debug.Log("isLast true");
                isLast = true;
            }
            currentStagePrefab = stagePrefabs[currentIndex];
            currentStageData = stageDatas[currentIndex];
        }
    }

    bool isLast;
    public bool IsLast
    {
        get
        {
            return isLast;
        }
    }
    private void Awake()
    {
        stagePrefabs = new GameObject[6];
        stageDatas = new StageData[6];
    }

    public void RecieveStageData(int index, string data, GameObject stagePrefab)
    {
        stagePrefabs[index] = stagePrefab;
        stageDatas[index] = JsonUtility.FromJson<StageData>(data);
    }

    public void NextStage()
    {
        if (IsLast == false)
        {
            CurrentIndex++;
            Managers.ExScene.LoadScene(Define.EScene.GameScene);

        }
    }
}
