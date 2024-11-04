using UnityEngine;

public class StageSelector : MonoBehaviour
{
    public GameObject stagePrefab;
    public StageData stageData;
    

    public void OnSendData()
    {
        string json = JsonUtility.ToJson(stageData);
        Managers.Stage.RecieveStageData(json);
        Managers.Stage.stagePrefab = stagePrefab;
    }
}
