using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symetrique : MonoBehaviour {

    public GameObject image;
    public RenderTexturePainter Paint;
    public GameObject Parent;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void copieCanvasTriangle()
    {
        Vector3 position = Paint.transform.position;
        float width = Paint.GetRessouceWidth;
        float height = Paint.GetRessouceHeight;
        //Debug.Log("width: " + width + "height: " + height);
        
        Vector3[] newPosition = new Vector3[12];
        for(int i = 0; i < 12; i++)
        {
            newPosition[i] = position;
        }

        GameObject[] newImage = new GameObject[12];

        newPosition[0].x = position.x + height / 4;
        newPosition[0].y = position.y - height * ((Mathf.Sin(Mathf.PI / 12)) * (Mathf.Sin(Mathf.PI / 12)));
        newImage[0] = Instantiate(image, newPosition[0] / 100, Quaternion.Euler(0, 0, -30));
        newImage[0].transform.localScale = new Vector3(-1f, 1f, 1f);

        newPosition[1].x = position.x + height * Mathf.Cos(Mathf.PI / 6) / 2;
        newPosition[1].y = position.y - height / 4;
        newImage[1] = Instantiate(image, newPosition[1] / 100, Quaternion.Euler(0, 0, -60));
        newImage[1].transform.localScale = new Vector3(1f, 1f, 1f);

        newPosition[2].x = position.x + height / 2;
        newPosition[2].y = position.y - height / 2 ;
        newImage[2] = Instantiate(image, newPosition[2] / 100, Quaternion.Euler(0, 0, -90));
        newImage[2].transform.localScale = new Vector3(-1f, 1f, 1f);

        newPosition[3].x = position.x + height * Mathf.Cos(Mathf.PI / 6) / 2;
        newPosition[3].y = position.y - 3 * height / 4;
        newImage[3] = Instantiate(image, newPosition[3] / 100, Quaternion.Euler(0, 0, -120));
        newImage[3].transform.localScale = new Vector3(1f, 1f, 1f);

        newPosition[4].x = position.x + height / 4;
        newPosition[4].y = position.y - height + height * ((Mathf.Sin(Mathf.PI / 12)) * (Mathf.Sin(Mathf.PI / 12)));
        newImage[4] = Instantiate(image, newPosition[4] / 100, Quaternion.Euler(0, 0, -150));
        newImage[4].transform.localScale = new Vector3(-1f, 1f, 1f);

        newPosition[5].x = position.x;
        newPosition[5].y = position.y - height;
        newImage[5] = Instantiate(image, newPosition[5] / 100, Quaternion.Euler(0, 0, 180));
        newImage[5].transform.localScale = new Vector3(1f, 1f, 1f);

        newPosition[6].x = position.x - height / 4;
        newPosition[6].y = position.y - height + height * ((Mathf.Sin(Mathf.PI / 12)) * (Mathf.Sin(Mathf.PI / 12)));
        newImage[6] = Instantiate(image, newPosition[6] / 100, Quaternion.Euler(0, 0, 150));
        newImage[6].transform.localScale = new Vector3(-1f, 1f, 1f);

        newPosition[7].x = position.x - height * Mathf.Cos(Mathf.PI / 6) / 2;
        newPosition[7].y = position.y - 3 * height / 4;
        newImage[7] = Instantiate(image, newPosition[7] / 100, Quaternion.Euler(0, 0, 120));
        newImage[7].transform.localScale = new Vector3(1f, 1f, 1f);

        newPosition[8].x = position.x - height / 2;
        newPosition[8].y = position.y - height / 2;
        newImage[8] = Instantiate(image, newPosition[8] / 100, Quaternion.Euler(0, 0, 90));
        newImage[8].transform.localScale = new Vector3(-1f, 1f, 1f);

        newPosition[9].x = position.x - height * Mathf.Cos(Mathf.PI / 6) / 2;
        newPosition[9].y = position.y - height / 4;
        newImage[9] = Instantiate(image, newPosition[9] / 100, Quaternion.Euler(0, 0, 60));
        newImage[9].transform.localScale = new Vector3(1f, 1f, 1f);

        newPosition[10].x = position.x - height / 4;
        newPosition[10].y = position.y - height * ((Mathf.Sin(Mathf.PI / 12)) * (Mathf.Sin(Mathf.PI / 12)));
        newImage[10] = Instantiate(image, newPosition[10] / 100, Quaternion.Euler(0, 0, 30));
        newImage[10].transform.localScale = new Vector3(-1f, 1f, 1f);

        newImage[11] = Instantiate(image, newPosition[11] / 100, Quaternion.Euler(0, 0, 0));
        newImage[11].transform.localScale = new Vector3(1f, 1f, 1f);

        for (int i = 0; i < 12; i++)
        {
            newPosition[i] = newPosition[i] / 100;
            newPosition[i].x += 1.5f;
            newPosition[i].y += 2;
            newImage[i].transform.position = newPosition[i];
            newImage[i].transform.parent = Parent.transform;
        }

        Paint.gameObject.SetActive(false);

    }

    public void copieRec1Fois()
    {
        Vector3 position = Paint.transform.position;
        float width = Paint.GetRessouceWidth;
        float height = Paint.GetRessouceHeight;

        GameObject[] newImage = new GameObject[2];
        Vector3[] newPosition = new Vector3[2];
        newPosition[0] = position;
        

        //原位置
        newImage[1] = Instantiate(image, position / 100, Quaternion.Euler(0, 0, 0));
        newImage[1].transform.localScale = new Vector3(1, 1, 1);
        //对折位置
        
        newPosition[0] = newPosition[1];
        newPosition[0].x = newPosition[1].x - width;
        newImage[0] = Instantiate(image, newPosition[0] / 100, Quaternion.Euler(0, 0, 0));
        newImage[0].transform.localScale = new Vector3(-1, 1, 1);

        for (int i = 0; i < 2; i++)
        {
            newPosition[i] = newPosition[i] / 100;
            newPosition[i].x += 2.5f;
            newPosition[i].y += 0.3f;
            newImage[i].transform.parent = Parent.transform;
        }
        newImage[0].transform.position = newPosition[0];
        newImage[1].transform.position = newPosition[1];

        Paint.gameObject.SetActive(false);
    }

    public void copieRec2Fois()
    {
        Vector3 position = Paint.transform.position;
        float width = Paint.GetRessouceWidth;
        float height = Paint.GetRessouceHeight;

        GameObject[] newImage = new GameObject[4];
        Vector3[] newPosition = new Vector3[4];
        for (int i = 0; i < 4; i++)
        {
            newPosition[i] = position;
        }

        newPosition[0].x =position.x+ width;
        newImage[0] = Instantiate(image, newPosition[0] / 100, Quaternion.Euler(0, 0, 0));
        newImage[0].transform.localScale = new Vector3(-1, 1, 1);

        newPosition[1].y = position.y- height;
        newImage[1] = Instantiate(image, newPosition[1] / 100, Quaternion.Euler(0, 0, 0));
        newImage[1].transform.localScale = new Vector3(1, -1, 1);

        newPosition[2].x = position.x + width;
        newPosition[2].y = position.y - height;
        newImage[2] = Instantiate(image, newPosition[2] / 100, Quaternion.Euler(0, 0, 0));
        newImage[2].transform.localScale = new Vector3(-1, -1, 1);

        newImage[3] = Instantiate(image, position / 100, Quaternion.Euler(0, 0, 0));
        newImage[3].transform.localScale = new Vector3(1, 1, 1);

        for (int i = 0; i < 4; i++)
        {
            newPosition[i] = newPosition[i] / 100;
            newPosition[i].x += 1.25f;
            newPosition[i].y += 2;
            newImage[i].transform.position = newPosition[i];
            newImage[i].transform.parent = Parent.transform;
        }

        Paint.gameObject.SetActive(false);

    }

    public void copieRec2Fois_classique()
    {
        Vector3 position = Paint.transform.position;
        float width = Paint.GetRessouceWidth;
        float height = Paint.GetRessouceHeight;

        GameObject[] newImage = new GameObject[4];
        Vector3[] newPosition = new Vector3[4];
        for (int i = 0; i < 4; i++)
        {
            newPosition[i] = position;
        }

        newPosition[0].x = position.x + width;
        newImage[0] = Instantiate(image, newPosition[0] / 100, Quaternion.Euler(0, 0, 0));
        newImage[0].transform.localScale = new Vector3(-1, 1, 1);

        newPosition[1].y = position.y - height;
        newImage[1] = Instantiate(image, newPosition[1] / 100, Quaternion.Euler(0, 0, 0));
        newImage[1].transform.localScale = new Vector3(1, -1, 1);

        newPosition[2].x = position.x + width;
        newPosition[2].y = position.y - height;
        newImage[2] = Instantiate(image, newPosition[2] / 100, Quaternion.Euler(0, 0, 0));
        newImage[2].transform.localScale = new Vector3(-1, -1, 1);

        newImage[3] = Instantiate(image, position / 100, Quaternion.Euler(0, 0, 0));
        newImage[3].transform.localScale = new Vector3(1, 1, 1);

        for (int i = 0; i < 4; i++)
        {
            newPosition[i] = newPosition[i] / 100;
            newPosition[i].x -= 2f;
            newPosition[i].y += 2;
            newImage[i].transform.position = newPosition[i];
            newImage[i].transform.parent = Parent.transform;
        }

        Paint.gameObject.SetActive(false);

    }

    public void copieTriangle45()
    {
        Vector3 position = Paint.transform.position;
        float width = Paint.GetRessouceWidth;
        float height = Paint.GetRessouceHeight;
        Vector3[] newPosition = new Vector3[4];
        for (int i = 0; i < 4; i++)
        {
            newPosition[i] = position;
        }
        GameObject newImage0 = Instantiate(image, newPosition[0] / 100, Quaternion.Euler(0, 0, 0));
        newImage0.transform.localScale = new Vector3(1, 1, 1);

        newPosition[1].x = position.x - width / 4;
        newPosition[1].y = position.y - height / 2;
        GameObject newImage1 = Instantiate(image, newPosition[1] / 100, Quaternion.Euler(0, 0, 90));
        newImage1.transform.localScale = new Vector3(1, 1, 1);

        newPosition[2].x = position.x;
        newPosition[2].y = position.y - height;
        GameObject newImage2 = Instantiate(image, newPosition[2] / 100, Quaternion.Euler(0, 0, 180));
        newImage2.transform.localScale = new Vector3(1, 1, 1);

        newPosition[3].x = position.x + width / 4;
        newPosition[3].y = position.y - height / 2;
        GameObject newImage3 = Instantiate(image, newPosition[3] / 100, Quaternion.Euler(0, 0, 270));
        newImage3.transform.localScale = new Vector3(1, 1, 1);

        newImage0.transform.parent = Parent.transform;
        newImage1.transform.parent = Parent.transform;
        newImage2.transform.parent = Parent.transform;
        newImage3.transform.parent = Parent.transform;
    }



    public void copieTriangle3fois()
    {
        Vector3 position = Paint.transform.position;
        float width = Paint.GetRessouceWidth;
        float height = Paint.GetRessouceHeight;

        GameObject[] newImage = new GameObject[8];
        Vector3[] newPosition = new Vector3[48];
        for (int i = 0; i < 8; i++)
        {
            newPosition[i] = position;
        }

        newImage[0] = Instantiate(image, newPosition[0] / 100, Quaternion.Euler(0, 0, 0));
        newImage[0].transform.localScale = new Vector3(1f, 1f, 1f);

        newPosition[1].x = position.x + width;
        newImage[1] = Instantiate(image, newPosition[1] / 100, Quaternion.Euler(0, 0, 0));
        newImage[1].transform.localScale = new Vector3(-1f, 1f, 1f);

        newPosition[2].x = position.x + width;
        newImage[2] = Instantiate(image, newPosition[2] / 100, Quaternion.Euler(0, 0, -90));
        newImage[2].transform.localScale = new Vector3(1f, 1f, 1f);

        newPosition[3].x = position.x + width;
        newPosition[3].y = position.y - height;
        newImage[3] = Instantiate(newImage[0], newPosition[3] / 100, Quaternion.Euler(0, 0, -90));
        newImage[3].transform.localScale = new Vector3(-1f, 1f, 1f);

        newPosition[4].x = position.x + width;
        newPosition[4].y = position.y - height;
        newImage[4] = Instantiate(newImage[3], newPosition[4] / 100, Quaternion.Euler(0, 0, 0));
        newImage[4].transform.localScale = new Vector3(-1f, -1f, 1f);

        newPosition[5].x = position.x;
        newPosition[5].y = position.y - height;
        newImage[5] = Instantiate(newImage[0], newPosition[5] / 100, Quaternion.Euler(0, 0, 0));
        newImage[5].transform.localScale = new Vector3(1f, -1f, 1f);

        newPosition[6].x = position.x;
        newPosition[6].y = position.y - height;
        newImage[6] = Instantiate(newImage[4], newPosition[6] / 100, Quaternion.Euler(0, 0, 90));
        newImage[6].transform.localScale = new Vector3(1f, 1f, 1f);


        newImage[7] = Instantiate(image, newPosition[7] / 100, Quaternion.Euler(0, 0, 90));
        newImage[7].transform.localScale = new Vector3(-1f, 1f, 1f);


        for (int i = 0; i < 8; i++)
        {
            newPosition[i] = newPosition[i] / 100;
            newPosition[i].x -= 2;
            newPosition[i].y += 2;
            newImage[i].transform.position = newPosition[i];
            newImage[i].transform.parent = Parent.transform;
        }

        Paint.gameObject.SetActive(false);

    }

    public GameObject FinishBackground;
    public GameObject toolbar;
    //展开后遮住其他
    public void Finish()
    {
        FinishBackground.SetActive(true);
        toolbar.SetActive(false);
    }

    public void Continue()
    {
        FinishBackground.SetActive(false);
        toolbar.SetActive(true);
        foreach (Transform child in Parent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        Paint.gameObject.SetActive(true);
        Paint.GetComponent<RenderTexturePainter>().activerScissor();
    }
}
