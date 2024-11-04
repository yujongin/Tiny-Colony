
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public GameObject stageClearPopUp;
    public GameObject gameOverPopUp;

    public TMP_Text humanScore; 
    public TMP_Text envScore; 
    public TMP_Text totalScore;

    public GameObject stageClearBtns;

    void Awake()
    {
        Managers.Game.gameScene = this;
    }

    public void SetScore()
    {
        humanScore.text = "Human Score : " + Managers.Game.CurrentPoint;
        envScore.text = "Env Score : " + Managers.Game.BonusPoint;
        totalScore.text = "__________________" + "\n" + "Total : " + Managers.Game.TotalPoint;
    }

    public void SetStarScore()
    {

    }

    public IEnumerator OpenScore()
    {
        SetScore();
        stageClearPopUp.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        humanScore.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        envScore.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        totalScore.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        stageClearBtns.gameObject.SetActive(true);
    }

    public void Restart()
    {
        Managers.Object.Clear();
        //scene reload
        Managers.ExScene.LoadScene(Define.EScene.GameScene);
    }
    public void LoadTitle()
    {
        Managers.Object.launcher = null;
        Managers.Object.Clear();
        Managers.ExScene.LoadScene(Define.EScene.TitleScene);
    }
}
