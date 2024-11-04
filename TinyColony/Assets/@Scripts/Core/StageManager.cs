
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject stagePrefab;
    public StageData currentStageData;

    public void RecieveStageData(string data)
    {
        currentStageData = JsonUtility.FromJson<StageData>(data);
    }

}
