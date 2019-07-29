using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu_level : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler { //3 ports for dragging
	RectTransform rt;
	Vector3 initPos;//Position initiale
	Vector3 targetPos;//position terminale
    int actuelPosition = 0;

	// Use this for initialization
	void Start () {
		rt = gameObject.GetComponent <RectTransform> ();
		targetPos = initPos = rt.position;
	}

	// Update is called once per frame
	void Update () {
		rt.position = Vector3.Lerp (rt.position, targetPos, 0.2f);//3rd element: percentage 0-1
        ClavierControl();
	}

	public void Select (int i){
		targetPos.x = -400 * i;
		targetPos.y = initPos.y;
        actuelPosition = i;
		//rt.position = new Vector3 (-400 * i, initPos.y, 0);//set new position when click (onclick)
	}

	Vector3 globalMousePos;
	Vector3 offset; //偏差
	//begin dragging
	public void OnBeginDrag (PointerEventData eventData){
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle (rt, eventData.position, eventData.pressEventCamera, out globalMousePos))
		{
			offset = globalMousePos - rt.position;
		}
	}

	//during dragging
	public void OnDrag(PointerEventData eventData){
	    if (RectTransformUtility.ScreenPointToWorldPointInRectangle (rt, eventData.position, eventData.pressEventCamera, out globalMousePos))
		{
					targetPos = globalMousePos - offset;
					targetPos.y = initPos.y;
		}
	}

	//end drugging
	public void OnEndDrag(PointerEventData eventData){
		int i = Mathf.FloorToInt (Mathf.Abs (rt.position.x) / 400);//开始算离前后按钮哪个近
        if(rt.position.x > 0)
        {
            i = 0;
        }else if (i < 6 && i>=0) {
			if (Mathf.Abs (rt.position.x) % 400 > 150) {
				i = i + 1;
			}
        }
        else if(i > 5)
        {
            i = 6;
        }
		targetPos.x = -400 * i;
        actuelPosition = i;
        Debug.Log(actuelPosition);
	}

    public void ClavierControl()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) && actuelPosition > 0)
        {
            actuelPosition -= 1;
            Select(actuelPosition);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && actuelPosition < 6)
        {
            actuelPosition += 1;
            Select(actuelPosition);
        }

    }

    public int GetActuelPosition()
    {
           return actuelPosition;
    }

}
