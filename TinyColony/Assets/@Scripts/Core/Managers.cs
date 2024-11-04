using UnityEngine;

public class Managers : MonoBehaviour
{
    public static bool Initialized { get; set; } = false;
    private static Managers instance;
    private static Managers Instance
    {
        get
        {
            if (instance == null)
                return null;

            return instance;
        }
    }

    private GameManager gameManager;
    private ObjectManager objectManager;
    private ExSceneManager exSceneManager;
    private StageManager stageManager;
    public static GameManager Game { get { return Instance?.gameManager; } }
    public static ObjectManager Object { get { return Instance?.objectManager; } }
    public static ExSceneManager ExScene { get { return Instance?.exSceneManager; } }
    public static StageManager Stage { get { return Instance?.stageManager; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        gameManager = transform.Find("GameManager").GetComponent<GameManager>();
        objectManager = transform.Find("ObjectManager").GetComponent<ObjectManager>();
        exSceneManager = transform.Find("ExSceneManager").GetComponent<ExSceneManager>();
        stageManager = transform.Find("StageManager").GetComponent<StageManager>();
    }
}
