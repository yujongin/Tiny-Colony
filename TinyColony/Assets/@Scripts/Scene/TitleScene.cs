using UnityEngine;
using UnityEngine.EventSystems;

public class TitleScene : MonoBehaviour
{
    public GameObject startButton;
    public GameObject levelButton;
    public GameObject tutorialButton;
    public GameObject quitButton;

    void Start()
    {
        startButton.BindEvent(OnGameStart);
    }

    public void OnGameStart(PointerEventData eventData)
    {
        Managers.ExScene.LoadScene(Define.EScene.GameScene);
    }
    public void OnLevelPopup(PointerEventData eventData)
    {
        //open level popup
    }
    public void OnTutorialPopup(PointerEventData eventData)
    {
        //open tutorial popup
    }
    public void OnGameQuit(PointerEventData eventData)
    {
        Application.Quit();
    }
}
