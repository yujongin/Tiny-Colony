using TMPro;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public int maxHuman;
    public TMP_Text remaintext;

    int arriveHuman;

    public int ArriveHuman {  
        get { return arriveHuman; }
        set 
        { 
            arriveHuman = value;
            remaintext.text = $"{arriveHuman} + / + {maxHuman}";
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
        }
    }

    void Update()
    {
        
    }
}
