using UnityEngine;
using UnityEngine.SceneManagement;

public class ExSceneManager : MonoBehaviour
{
    public void LoadScene(Define.EScene type)
    {
        SceneManager.LoadScene(GetSceneName(type));
    }
    private string GetSceneName(Define.EScene type)
    {
        string name = System.Enum.GetName(typeof(Define.EScene), type);
        return name;
    }
}
