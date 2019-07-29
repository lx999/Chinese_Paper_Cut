using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textController : MonoBehaviour {
    public Menu_level theme;
    public GameObject retour;

    int actuelPosition;
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        actuelPosition = theme.GetActuelPosition();
        if (actuelPosition == 0)
            retour.SetActive(true);
        else retour.SetActive(false);
        /*{
            switch (actuelPosition=theme.GetActuelPosition())
            {
                case 1:
                    all.SetActive(false);
                    animaux.SetActive(true);
                    flacon.SetActive(false);
                    classique.SetActive(false);
                    StartCoroutine(all.GetComponent<Fade>().FadeTextToFullAlpha(1f, all.GetComponent<Text>()));
                    break;
                case 2:
                    //StartCoroutine(all.GetComponent<Fade>().FadeTextToZeroAlpha(1f, all.GetComponent<Text>()));
                    all.SetActive(false);
                    animaux.SetActive(false);
                    flacon.SetActive(true);
                    classique.SetActive(false);
                    StartCoroutine(all.GetComponent<Fade>().FadeTextToFullAlpha(1f, flacon.GetComponent<Text>()));
                    break;
                case 3:
                    //StartCoroutine(all.GetComponent<Fade>().FadeTextToZeroAlpha(1f, flacon.GetComponent<Text>()));
                    all.SetActive(false);
                    animaux.SetActive(false);
                    flacon.SetActive(false);
                    classique.SetActive(true);
                    StartCoroutine(all.GetComponent<Fade>().FadeTextToZeroAlpha(1f, all.GetComponent<Text>()));
                    break;
                default:
                    all.SetActive(true);
                    animaux.SetActive(false);
                    flacon.SetActive(false);
                    classique.SetActive(false);
                    StartCoroutine(all.GetComponent<Fade>().FadeTextToFullAlpha(1f, all.GetComponent<Text>()));
                    break;


            }
        }*/

    }
}
