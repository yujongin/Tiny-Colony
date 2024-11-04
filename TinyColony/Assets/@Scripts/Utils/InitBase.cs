using UnityEngine;

public class InitBase : MonoBehaviour
{
    protected bool isInit = false;

    public virtual bool Init()
    {
        if (isInit)
        {
            return false;
        }

        isInit = true;
        return true;
    }

    private void Awake()
    {
        Init();
    }
}
