using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

    //public GameObject loadingScreen;
    //public Slider slider;
    //public Text progressText;

	public void ToThemeMenu()
    {
        SceneManager.LoadScene("ThemeMenu");
        //SceneManager.LoadScene("Scene/ThemeMenu");
        //SceneManager.LoadScene(0);
    }

	public void ToMenu()
	{
		SceneManager.LoadScene ("Menu");
	}

    public void ToLibreMenu()
    {
        SceneManager.LoadScene ("ModeLibreMenu");
    }

	public void ToLibreR1()
	{
		SceneManager.LoadScene ("modelibre_rect");
	}

	public void TolibreCarree()
	{
		SceneManager.LoadScene ("modelibre_caree");
	}

	public void ToLibreTriangle()
	{
		SceneManager.LoadScene ("modelibre_triangle");
	}

	public void ToLibreFlacon()
	{
		SceneManager.LoadScene ("modelibre_flacon");
	}
	
    public void QuitGame()
    {
        Application.Quit();
    }
   

    /*IEnumerator LoadAsynchronously(int sceneIndex)
    {
        loadingScreen.SetActive(true);




        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / .9f);//从0 - 0.9 转化 0 - 1
            slider.value = progress;
            //yield return new WaitForSeconds(2);
            progressText.text = progress * 100f + "%";
            Debug.Log(progress);
            yield return null;  
        }


    }*/


    //public Menu_level bar;
    /*public void LoadLevelSelonMenu()
    {
        int index = bar.GetActuelPosition();
        Debug.Log(index);
        StartCoroutine(LoadAsynchronously(0));
    }*/
}
