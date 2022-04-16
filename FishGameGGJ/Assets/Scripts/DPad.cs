using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DPad : MonoBehaviour, IPointerEnterHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        print("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        eventData.pointerPress = eventData.pointerDrag;

        print("OnDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // End Drag will be called as usual
        print("OnEndDrag" + gameObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.dragging)
        {
            // The following line is not required if you don't have OnEndDrag in script
            eventData.pointerDrag.SendMessage("OnEndDrag", eventData);

            eventData.pointerDrag = gameObject;
            OnBeginDrag(eventData);
        }
    }
}
