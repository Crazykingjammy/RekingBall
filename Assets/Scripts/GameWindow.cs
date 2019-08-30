using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameWindow : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    CameraController gameCam;

    private bool dragging = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Grab the game object at the raycast test.
        GameObject tempObj = eventData.pointerCurrentRaycast.gameObject;

        //Test if this is our game object?
        if (this.gameObject == tempObj)
        { dragging = true; }
        else
        { dragging = false; }
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log ("OnDrag");

        //If dragging flag enabled, call camera udpate.
        if(dragging)
        {
            gameCam.UpdateGameCamera();
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");

    }
  
}
