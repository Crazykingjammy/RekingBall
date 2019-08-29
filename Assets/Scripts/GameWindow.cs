using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameWindow : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    RectTransform WindowHandle;

    //Value for the drag speed.
    [SerializeField]
    float speed = 50.0f;

    //Variable for the offset position of the window from base.
    private Vector3 offset;

    //Previous positions of mouse to calculate delta.
    private Vector3 lastMousePos = Vector3.zero;

    //Local reference of my rect.
    RectTransform myRect;

    

    // Start is called before the first frame update
    void Start()
    {
        myRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //if (Input.GetMouseButton(0) && MouseInRect())
        //{
        //    Vector3 delta = Input.mousePosition - lastMousePos;

        //    MouseMoveEvent

        //    //Update the values of the rec position based on mouse change.
        //    offset.x += Input.GetAxis("Mouse X") * speed;
        //    offset.y += Input.GetAxis("Mouse Y") * speed;

        //    Debug.Log("delta X : " + delta.x);
        //    Debug.Log("delta Y : " + delta.y);


        //    //mouseDelta = Input.mousePosition;
        //    lastMousePos = Input.mousePosition;
        //}

        ////Update the position.
        //myRect.localPosition = Vector3.zero + offset;
   

    }


    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log ("OnDrag");

        //this.transform.position = eventData.position;
        //Update the position.
        this.transform.position += (Vector3)eventData.position ;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");

    }


    //TODO:: Actually place this function in a static class, along with other like functions.
    private bool MouseInRect()
    {
        //Grab the mouse posotion from the InverseTransformPoint.
        Vector2 mousepos = WindowHandle.InverseTransformPoint(Input.mousePosition);

        if (WindowHandle.rect.Contains(mousepos))
        {
            return true;
        }

        return false;
    }

}
