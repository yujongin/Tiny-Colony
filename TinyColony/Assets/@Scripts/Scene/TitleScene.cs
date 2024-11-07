using UnityEngine;
using UnityEngine.EventSystems;

public class TitleScene : MonoBehaviour
{
    public GameObject startButton;
    public GameObject levelButton;
    public GameObject tutorialButton;
    public GameObject quitButton;
    public GameObject optionButton;

    public GameObject levelPanel;
    public GameObject tutorialPanel;
    public GameObject soundPanel;
    void Start()
    {
        startButton.BindEvent(OnGameStart);
        levelButton.BindEvent(OnLevelPopup);
        quitButton.BindEvent(OnGameQuit);
        tutorialButton.BindEvent(OnTutorialPopup);
        optionButton.BindEvent(OnOptionPopup);
        levelPanel.SetActive(false);
        Managers.Sound.PlayBGM(Managers.Sound.titleBGM);
    }

    public void OnGameStart(PointerEventData eventData)
    {
        Managers.Stage.CurrentIndex = 0;
        Managers.ExScene.LoadScene(Define.EScene.GameScene);
    }
    public void OnLevelPopup(PointerEventData eventData)
    {
        levelPanel.SetActive(true);
    }
    public void OnTutorialPopup(PointerEventData eventData)
    {
        tutorialPanel.SetActive(true);
    }
    public void OnOptionPopup(PointerEventData eventData)
    {
        soundPanel.SetActive(true);
    }
    public void OnGameQuit(PointerEventData eventData)
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            levelPanel.SetActive(false);
            tutorialPanel.SetActive(false);
            soundPanel.SetActive(false);
        }
    }
}
