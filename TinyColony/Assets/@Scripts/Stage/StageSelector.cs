using UnityEngine;
using UnityEngine.UI;
public class StageSelector : MonoBehaviour
{
    public int myIndex;
    public GameObject stagePrefab;
    public StageData stageData;
    public GameObject[] stars;

    
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        OnSendData();
        int highScore = PlayerPrefs.GetInt(stagePrefab.name);
        //Debug.Log("Load!"+ stagePrefab.name + highScore);
        for (int i = 0; i < stageData.StarFlags.Length; i++)
        {
            if (stageData.StarFlags[i] <= highScore)
            {
                stars[i].GetComponent<Image>().color = Color.white;
            }
        }
    }
    void OnSendData()
    {
        string json = JsonUtility.ToJson(stageData);
        Managers.Stage.RecieveStageData(myIndex, json, stagePrefab);
    }

    public void OnSelectLevel()
    {
        Managers.Stage.CurrentIndex = myIndex;
        Managers.ExScene.LoadScene(Define.EScene.GameScene);
    }
}
