using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Gate> gates;
    public GameScene gameScene;
    int goalPoint;
    int currentPoint;
    int bonusPoint;
    int totalPoint;
    public int CurrentPoint {  get { return currentPoint; } }
    public int BonusPoint {  get { return bonusPoint; } }
    public int TotalPoint {  get { return totalPoint; } }

 

    public void InitPoint()
    {
        currentPoint = 0;
        goalPoint = 0;
        for (int i = 0; i < gates.Count; i++)
        {
            goalPoint += gates[i].maxHuman;
        }
    }

    public void FinishGame()
    {
        gates.Clear();
    }

    public void UpdatePoint()
    {
        currentPoint = currentPoint < goalPoint ? currentPoint + 1 : goalPoint;
        Debug.Log(currentPoint);
        Debug.Log(goalPoint);
        if (goalPoint == currentPoint)
        {
            StageClear();
        }
    }

    public void StageClear()
    {
        Debug.Log("stage Clear!");
        totalPoint = currentPoint + bonusPoint;
        StartCoroutine(gameScene.OpenScore());
        FinishGame();
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        FinishGame();
    }



    public void AddBonusPoint(int point)
    {
        bonusPoint += point;
    }
}
