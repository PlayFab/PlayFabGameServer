//
//  PUIResizableWindow.cs
//  
//  Created by William Burgers (wpburgers@gmail.com) on 4/20/16.
//  Use however you want! Also, check out my File Browser for Unity UI: http://u3d.as/s09  ;)
//
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PUIResizableWindow : MonoBehaviour {

	Vector2 mouse_position = new Vector2(0,0);
	bool resizing = false;
	bool moving = false;
	RectTransform rect_transform;

	public float min_width = 100f;
	public float min_height = 100f;

	void Start ()
	{
		rect_transform = GetComponent<RectTransform>();
	}

	public void ResizeStart ()
	{
		resizing = true;
		mouse_position = Input.mousePosition;
	}
	public void ResizeEnd ()
	{
		resizing = false;
	}
	public void MoveStart ()
	{
		moving = true;
		mouse_position = Input.mousePosition;
	}
	public void MoveEnd ()
	{
		moving = false;
	}

	void Update ()
	{
		if (resizing){
			Vector2 new_mouse_position = Input.mousePosition;
			Vector2 delta = new_mouse_position - mouse_position;
			mouse_position = new_mouse_position;
			Vector2 new_size = new Vector2(rect_transform.sizeDelta.x+delta.x, rect_transform.sizeDelta.y-delta.y);
			if(new_size.x<min_width){new_size.x = min_width;}
			if(new_size.y<min_height){new_size.y = min_height;}
			rect_transform.sizeDelta = new_size;
		}
		else if (moving){
			Vector2 new_mouse_position = Input.mousePosition;
			Vector2 delta = new_mouse_position - mouse_position;
			mouse_position = new_mouse_position;
			rect_transform.anchoredPosition = new Vector2(rect_transform.anchoredPosition.x+delta.x, rect_transform.anchoredPosition.y+delta.y);
		}


	}


}
