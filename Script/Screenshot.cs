using UnityEngine;
using System.Collections;

public class Screenshot : MonoBehaviour 
{
    public GameObject button;
	public GameObject stamp;
	public void screenshot()
	{
		stamp.gameObject.SetActive (true);
        button.gameObject.SetActive(false);
		ScreenCapture.CaptureScreenshot("screenshot"+ System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png");
        StartCoroutine(goOn());
        
    }

    IEnumerator goOn()
    {
        yield return new WaitForSeconds(0.5f);
        button.gameObject.SetActive(true);
		stamp.gameObject.SetActive (false);
    }

}

