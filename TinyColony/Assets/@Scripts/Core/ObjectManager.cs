using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static Define;

internal class Pool
{
    private GameObject _prefab;
    private IObjectPool<GameObject> _pool;

    private Transform _root;
    public Transform Root
    {
        get
        {
            if (_root == null)
            {
                GameObject go = new GameObject() { name = $"@{_prefab.name}Pool" };
                _root = go.transform;
            }

            return _root;
        }
    }

    public Pool(GameObject prefab)
    {
        _prefab = prefab;
        _pool = new ObjectPool<GameObject>(OnCreate, OnGet, OnRelease, OnDestroy);
    }

    public void Push(GameObject go)
    {
        if (go.activeSelf)
            _pool.Release(go);
    }

    public GameObject Pop()
    {
        return _pool.Get();
    }

    #region Funcs
    private GameObject OnCreate()
    {
        GameObject go = GameObject.Instantiate(_prefab);
        go.transform.SetParent(Root);
        go.name = _prefab.name;
        return go;
    }

    private void OnGet(GameObject go)
    {
        go.SetActive(true);
    }

    private void OnRelease(GameObject go)
    {
        go.SetActive(false);
        go.transform.SetParent(Root);
        go.transform.localRotation = Quaternion.identity;
        go.transform.localScale = Vector3.one;
    }

    private void OnDestroy(GameObject go)
    {
        GameObject.Destroy(go);
    }
    #endregion
}

public class ObjectManager : MonoBehaviour
{
    public List<GameObject> itemProfabs = new List<GameObject>();
    private Dictionary<string, Pool> pools = new Dictionary<string, Pool>();

    public Launcher launcher;

    public void SpawnItem(EItemName name)
    {
        if (pools.ContainsKey(name.ToString()) == false)
        {
            CreatePool(itemProfabs[(int)name]);
        }

        launcher.AddItem(pools[name.ToString()].Pop());
    }

    public void DespawnItem(GameObject go)
    {
        if (pools.ContainsKey(go.name) == false)
            return;

        pools[go.name].Push(go);
    }
    public void DespawnItem(EItemName name)
    {
        Transform[] items = launcher.bucket.transform.GetComponentsInChildren<Transform>();

        for(int i = 0; i<items.Length; i++)
        {
            if(items[i].name == name.ToString())
            {
                pools[items[i].name].Push(items[i].gameObject);
                launcher.RemoveItem(items[i].gameObject);
                return;
            }
        }
    }

    public Transform GetRoot(GameObject go)
    {
        return pools[go.name].Root;
    }

    public void Clear()
    {
        pools.Clear();
    }

    private void CreatePool(GameObject original)
    {
        Pool pool = new Pool(original);
        pools.Add(original.name, pool);
    }
}
