using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public event Action<PointerEventData> OnLeftClickHandler = null;
    public event Action<PointerEventData> OnRighttClickHandler = null;
    public event Action<PointerEventData> OnPointerEnterHandler = null;
    public event Action<PointerEventData> OnPointerExitHandler = null;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClickHandler?.Invoke(eventData);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRighttClickHandler?.Invoke(eventData);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnPointerEnterHandler?.Invoke(eventData);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointerExitHandler?.Invoke(eventData);
    }

}
