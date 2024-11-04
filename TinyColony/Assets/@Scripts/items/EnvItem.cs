using UnityEngine;
using System;
using static Define;
public class EnvItem : ItemBase
{
    private EItemName itemName;
    public int bonusPoint;

    void Start()
    {
        itemName = Util.ParseEnum<EItemName>(name);
        string[] bonusPoints = Enum.GetNames(typeof(EBonusPoint));
        for(int i = 0; i< bonusPoints.Length; i++)
        {
            if (name.Contains(bonusPoints[i]))
            {
                bonusPoint = (int)Util.ParseEnum<EBonusPoint>(bonusPoints[i]);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Planet")
        {
            //Bonus Point
            Managers.Game.AddBonusPoint(bonusPoint);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Planet")
        {
            //Bonus Point
            Managers.Game.AddBonusPoint(-bonusPoint);
        }
    }

}
