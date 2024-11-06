using UnityEngine;
using UnityEngine.EventSystems;

public class TitleScene : MonoBehaviour
{
    public GameObject startButton;
    public GameObject levelButton;
    public GameObject tutorialButton;
    public GameObject quitButton;

    public GameObject levelPage;
    public GameObject tutorialPage;
    void Start()
    {
        startButton.BindEvent(OnGameStart);
        levelButton.BindEvent(OnLevelPopup);
        quitButton.BindEvent(OnGameQuit);
        tutorialButton.BindEvent(OnTutorialPopup);
        levelPage.SetActive(false);
    }

    public void OnGameStart(PointerEventData eventData)
    {
        Managers.Stage.CurrentIndex = 0;
        Managers.ExScene.LoadScene(Define.EScene.GameScene);
    }
    public void OnLevelPopup(PointerEventData eventData)
    {
        //open level popup
        levelPage.SetActive(true);
    }
    public void OnTutorialPopup(PointerEventData eventData)
    {
        //open tutorial popup
        tutorialPage.SetActive(true);
    }
    public void OnGameQuit(PointerEventData eventData)
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            levelPage.SetActive(false);
            tutorialPage.SetActive(false);

        }
    }
}
