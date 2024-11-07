
using System.Collections;
using TMPro;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public GameObject stageClearPopUp;
    public GameObject soundPanel;
    public GameObject nextBtn;

    public TMP_Text humanScore;
    public TMP_Text envScore;
    public TMP_Text totalScore;

    public GameObject stageClearBtns;
    public GameObject starScore;

    void Awake()
    {
        Managers.Game.gameScene = this;
        GameObject.Instantiate(Managers.Stage.currentStagePrefab);
    }
    void Start()
    {
        Managers.Sound.PlayBGM(Managers.Sound.gameBGM);    
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            soundPanel.SetActive(!soundPanel.activeSelf);
            Time.timeScale = soundPanel.activeSelf ? 0.0f : 1.0f;
        }
    }
    public void SetScore()
    {
        humanScore.text = "Human Score : " + Managers.Game.CurrentPoint;
        envScore.text = "Env Score : " + Managers.Game.BonusPoint;
        totalScore.text = "__________________" + "\n" + "Total : " + Managers.Game.TotalPoint;
    }

    public void SetStarScore()
    {
        StageData data = Managers.Stage.currentStageData;

        int highStarScore = PlayerPrefs.GetInt(Managers.Stage.currentStagePrefab.name);
        if (Managers.Game.TotalPoint > highStarScore)
        {
            for (int i = 0; i < data.StarFlags.Length; i++)
            {
                if (data.StarFlags[i] <= Managers.Game.TotalPoint)
                {
                    starScore.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            PlayerPrefs.SetInt(Managers.Stage.currentStagePrefab.name, Managers.Game.TotalPoint);
            //Debug.Log("Save!" + Managers.Stage.currentStagePrefab.name + Managers.Game.TotalPoint);
        }
        else
        {
            for (int i = 0; i < data.StarFlags.Length; i++)
            {
                if (data.StarFlags[i] <= highStarScore)
                {
                    starScore.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }

    public IEnumerator OpenScore()
    {
        SetScore();
        stageClearPopUp.SetActive(true);
        Debug.Log(Managers.Stage.IsLast);
        if (Managers.Stage.IsLast)
        {
            nextBtn.SetActive(false);
        }
        SetStarScore();
        yield return new WaitForSeconds(0.3f);
        humanScore.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        envScore.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        totalScore.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        stageClearBtns.gameObject.SetActive(true);
    }

    public void Restart()
    {
        Managers.Game.FinishGame();
        Managers.Object.Clear();
        //scene reload
        Managers.ExScene.LoadScene(Define.EScene.GameScene);
    }
    public void LoadTitle()
    {
        Managers.Game.FinishGame();
        Managers.Object.launcher = null;
        Managers.Object.Clear();
        Managers.ExScene.LoadScene(Define.EScene.TitleScene);
    }

    public void NextLevelOpen()
    {
        Managers.Game.FinishGame();
        Managers.Stage.NextStage();
        Managers.Object.Clear();
    }
}
