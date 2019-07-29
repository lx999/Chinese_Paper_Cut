using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Splashes : MonoBehaviour
{
    [Header("Splash Screen")]
    public bool useSplashScreen = true;
    public GameObject splashesContent;
    private List<Graphic> splashes = new List<Graphic>();
    public float splashStayDiration = 3f;
    public float splashCrossFadeTime = 1f;



    void Start()
    {

        if (!useSplashScreen || splashesContent.GetComponentsInChildren<Graphic>(true).Length <= 0) return;

        //if we use splash screens and we have splash screens
#region Get All Splashes
        //if you build on PC Standalone - you can uncomment this
        //foreach (var splash in splashesContent.GetComponentsInChildren<Graphic>(true).Where(splash => splash != splashesContent.GetComponent<Graphic>()))
        //{
        //    splashes.Add(splash);
        //}

        for (var i = 0; i < splashesContent.GetComponentsInChildren<Graphic>(true).Length; i++)
        {
            var splash = splashesContent.GetComponentsInChildren<Graphic>(true)[i];
            if (splash != splashesContent.GetComponent<Graphic>())
            {
                splashes.Add(splash);
            }
        }

#endregion

        //And starting playing splashes
        StartCoroutine(PlayAllSplashes());
    }

    private IEnumerator PlayAllSplashes()
    {
        //Enabling Splashes root transform
        if (!splashesContent.activeSelf) splashesContent.SetActive(true);

        //main loop for playing
        foreach (var t in splashes)
        {
            t.gameObject.SetActive(true);
            t.canvasRenderer.SetAlpha(0.0f);
            t.CrossFadeAlpha(1, splashCrossFadeTime, false);
            yield return new WaitForSeconds(splashStayDiration + splashCrossFadeTime);
            t.CrossFadeAlpha(0, splashCrossFadeTime, false);
            yield return new WaitForSeconds(splashCrossFadeTime);
            t.gameObject.SetActive(false);
        }

        //Smooth main menu enabling
        splashesContent.GetComponent<Graphic>().CrossFadeAlpha(0, 0.5f, false);
        yield return new WaitForSeconds(0.5f);
        splashesContent.gameObject.SetActive(false);
    }

   

    public void ExitGame()
    {
        Application.Quit();
    }
}
