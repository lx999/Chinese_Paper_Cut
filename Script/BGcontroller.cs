using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGcontroller : MonoBehaviour {

    public Sprite[] OtherSprite;
    public Image BgImage;
    public Menu_level clavierController;
    int actuelPosition;
    
	// Use this for initialization
	void Start () {
        actuelPosition = clavierController.GetActuelPosition();
        BgImage.sprite = OtherSprite[0];
    }
	
	// Update is called once per frame
	void Update () {
        actuelPosition = clavierController.GetActuelPosition();
        swapImage(actuelPosition);
	}

    void swapImage(int Index)
    {
        BgImage.sprite = OtherSprite[Index];
    }
}
