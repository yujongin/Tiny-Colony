using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using static Define;

public class LoadItemButton : MoveUI
{
    //이후에 스테이지 데이터에서 받아오기.
    public int maxItemCount;
    int remainItemCount;
    public EItemName itemName;
    public TMP_Text remainCountText;

    public override bool Init()
    {
        if (base.Init() == false)
        {
            return false;
        }
        remainItemCount = maxItemCount;
        remainCountText = transform.GetComponentInChildren<TMP_Text>();
        itemName = Util.ParseEnum<EItemName>(gameObject.name);
        remainCountText.text = maxItemCount.ToString();
        gameObject.BindEvent(OnLeftClick, EUIEvent.LeftClick);
        gameObject.BindEvent(OnRightClick, EUIEvent.RigthClick);
        return true;
    }

    void SpawnItem()
    {
        if (remainItemCount > 0)
        {
            Managers.Object.SpawnItem(itemName);
            remainItemCount--;
            remainCountText.text = remainItemCount.ToString();
        }
    }
    void DespawnItem()
    {
        if (remainItemCount < maxItemCount)
        {
            Managers.Object.DespawnItem(itemName);
            remainItemCount++;
            remainCountText.text = remainItemCount.ToString();
        }
    }

    public void OnLeftClick(PointerEventData data)
    {
        SpawnItem();
    }

    public void OnRightClick(PointerEventData data)
    {
        DespawnItem();
    }
}
