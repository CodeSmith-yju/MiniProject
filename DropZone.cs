using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropZone : MonoBehaviour, IDropHandler
{
    public bool dropCheck = false;
    public void OnDrop(PointerEventData eventData)
    {
        dropCheck = true;
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (HandingManager.Instance.endDraw && d.mousePointFollow)
        {
            Card dropCard = eventData.pointerDrag.GetComponent<Card>();
            HandingManager.Instance.DropCard(0.5f, dropCard.order);
            d.isOnDropZone = true;
            HandingManager.Instance.SortAllCard();
        }        
    }
}
