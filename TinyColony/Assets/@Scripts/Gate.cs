using TMPro;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public int maxHuman;
    public TMP_Text remaintext;

    int arriveHuman;

    private void Awake()
    {
        Managers.Game.gates.Add(this);
        Managers.Game.InitPoint();
        remaintext.text = remaintext.text = $"{arriveHuman}/{maxHuman}";
    }
    public int ArriveHuman {  
        get { return arriveHuman; }
        set 
        { 
            arriveHuman = value;
            remaintext.text = $"{arriveHuman}/{maxHuman}";
            Managers.Game.UpdatePoint();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Human")
        {
            collision.GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
            Human human = collision.GetComponent<Human>();
            human.portal = transform;
            StartCoroutine(human.ArriveCoroutine());
            ArriveHuman = ArriveHuman < maxHuman ? ArriveHuman + 1 : maxHuman;
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
}
