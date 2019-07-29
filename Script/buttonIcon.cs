using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonIcon : MonoBehaviour {
    
    public Texture2D defaultTexture;
    public Texture2D pickupTexture;
    public CursorMode curMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public UIEraserTexture eraser;
	// Use this for initialization
	void Start () {
        Cursor.SetCursor(defaultTexture, hotSpot, curMode);
        
	}
	

    public void changeIcon()
    {
        Cursor.SetCursor(pickupTexture, hotSpot, curMode);
    }

    public void Activer()
    {
        eraser.active = true;
    }
}
