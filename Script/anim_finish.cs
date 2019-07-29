using UnityEngine;
using System.Collections;

public class anim_finish : MonoBehaviour {
    public GameObject anim;

    public GameObject ToolBar;

    public GameObject Paint;
    public RenderTexturePainter r;

    // Use this for initialization
    IEnumerator active_gameobjet()
    {

        if (anim.name == "animflacon" || anim.name == "Anim4")
            yield return new WaitForSeconds(4);

        else yield return new WaitForSeconds(2.5f);

        anim.SetActive(false);
        ToolBar.SetActive(true);
        Paint.SetActive(true);
       

    }

    IEnumerator active_gameobjet_replay()
    {
        
        ToolBar.SetActive(false);
        Paint.SetActive(false);
		if (anim.name == "animflacon"|| anim.name == "Anim4")
            yield return new WaitForSeconds(4);

        else yield return new WaitForSeconds(2.5f);

        anim.SetActive(false);
        ToolBar.SetActive(true);
        Paint.SetActive(true);


    }

    void Start () {
        StartCoroutine(active_gameobjet());

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void replay()
    {
        anim.SetActive(true);
        r.activerScissor();
        StartCoroutine(active_gameobjet_replay());
    }
}
