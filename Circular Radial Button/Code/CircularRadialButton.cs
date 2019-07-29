using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CircularRadialButton : MonoBehaviour
{
    [Header("References")]
    public Button MainButton;
    [Tooltip("is the reference the image inside the menu button. The one that will change when the menu is open or closed.")]
    public Image MainButtonImage;
    [Tooltip("is the sprite that will Main Button Image show when the button is expanded.")]
    public Sprite OpenSprite;
    [Tooltip("is the sprite that will Main Button Image show when the button is collapsed.")]
    public Sprite ClosedSprite;

    [Header("Main Button Settings")]
    [Tooltip("is the scale size the menu button will show when expanded.")]
    public float MainButtonMinSize = 0.5f;
    [Tooltip("is the scale size the menu button will show when collapsed.")]
    public float MainButtonMaxSize = 1f;

    [Tooltip("is the curve used in the transition when the button is clicked. As per default in the prefab and shown in this example one image collapse and the other")]
    public AnimationCurve MainButtonImageCurve;

    [Tooltip("sets whether the menu button will close its child menu buttons")]
    public bool CloseChildOptionsOnClose;

    [Header("Options Settings")]
    [Tooltip("holds the references to the different element the menu button has")]
    public List<RectTransform> Options;

    [Tooltip("is the minimum radius distance where the options will be placed when the menu is collapsed.")]
    public float OptionsMinRadius = 75;
    [Tooltip("is the maximum radius distance where the options will be placed when the menu is expanded.")]
    public float OptionsMaxRadius = 120;

    [Tooltip("the scale size the options will have when the menu is collapsed.")]
    public float OptionsMinSize = 0.1f;
    [Tooltip("the scale size the options will have when the menu is expanded")]
    public float OptionsMaxSize = 1;

    [Tooltip("this defines the options’ angle separation when the menu is collapsed.")]
    public float MinAngleDistanceBetweenOptions = 15;
    [Tooltip("this defines the options’ angle separation when the menu is expanded.")]
    public float MaxAngleDistanceBetweenOptions = 35;

    [Tooltip("defines the start angle for the previous options (counterclockwise)")]
    public float StartAngleOffset = 0;

    [Tooltip("sets whether the menu options are shown one by one or all at once.")]
    public bool ShowAllOptionsAtOnce = false;

    [Tooltip("defines the time is takes from the collapsed menu to be expanded.")]
    public float OpenTransitionTime = 0.5f;
    [Tooltip("defines the time is takes from the expanded menu to be collapsed.")]
    public float CloseTransitionTime = 0.5f;

    private float TransitionTime = 0.5f;

    [Tooltip("is used to define the options’ scale size over Open Transition time.")]
    public AnimationCurve OpenCurve;
    [Tooltip("is used to define the options’ scale size over Close Transition time.")]
    public AnimationCurve CloseCurve;

    //Private
    private AnimationCurve CurrentCurve;
    private bool Open;
    private float T;

	void Awake ()
	{
        CurrentCurve = Open ? OpenCurve : CloseCurve;
	    TransitionTime = Open ? OpenTransitionTime : CloseTransitionTime;
	    T = TransitionTime;
	    Animate();
	}

    public void Toggle()
    {
        // wait for animation to complete
        if (T < TransitionTime)
            return;

        Open = !Open;
        CurrentCurve = Open ? OpenCurve : CloseCurve;
        TransitionTime = Open ? OpenTransitionTime : CloseTransitionTime;
        T = 0;

        if (!Open && CloseChildOptionsOnClose)
        {
            CircularRadialButton[] childButtons = GetComponentsInChildren<CircularRadialButton>();
            foreach (CircularRadialButton button in childButtons)
            {
                button.CloseIfOpen();
            }
        }
    }

    public void CloseIfOpen()
    {
        if (Open)
            Toggle();
    }

	void Update ()
	{
	    if (T >= TransitionTime)
	        return;

	    T += Time.deltaTime;

	    if (T > TransitionTime) T = TransitionTime;

	    Animate();
	}

    private void Animate()
    {
        float bScale = MainButtonMinSize + (MainButtonMaxSize - MainButtonMinSize) * CurrentCurve.Evaluate(1 - (T / TransitionTime));

        if (!MainButton)
        {
            Debug.LogError("Main Button missing reference, drag Main Button to Component Field");
            T = TransitionTime;
            return;
        }

        MainButton.transform.localScale = new Vector3(bScale, bScale, bScale);
        float bImageScale = MainButtonImageCurve.Evaluate(T / TransitionTime);
        if (MainButtonImage)
        {
            MainButtonImage.transform.localScale = new Vector3(bImageScale, bImageScale, bImageScale);

            if (T >= TransitionTime/2)
                MainButtonImage.sprite = !Open ? OpenSprite : ClosedSprite;
        }

        if (Options == null || Options.Count <= 0)
            return;

        int count = Options.Count;

        float tSegment = TransitionTime / count;

        float angleDistanceT = (T * 2) / TransitionTime;

        float distanceBetweenButtons = MinAngleDistanceBetweenOptions + (MaxAngleDistanceBetweenOptions - MinAngleDistanceBetweenOptions) * CurrentCurve.Evaluate(angleDistanceT);

        float startAngle = (distanceBetweenButtons * (count - 1)) / 2 + StartAngleOffset;

        for (int i = 0; i < count; i++)
        {
            if (Options[i] == null)
                continue;

            var tEval = (T - tSegment * i) / tSegment;
            if (T >= tSegment * i && T < tSegment * (i + 1))
            {
                tEval = (T - tSegment*i)/tSegment;
                
                float scale = OptionsMinSize + (OptionsMaxSize - OptionsMinSize) * CurrentCurve.Evaluate(tEval);
                Options[i].transform.localScale = new Vector3(scale, scale, scale);
            }
            if (ShowAllOptionsAtOnce || T >= tSegment * (i + 1))
            {
                tEval = T/tSegment;

                float scale = OptionsMinSize + (OptionsMaxSize - OptionsMinSize) * CurrentCurve.Evaluate(tEval);
                Options[i].transform.localScale = new Vector3(scale, scale, scale);

            }

            var radius = OptionsMinRadius + (OptionsMaxRadius - OptionsMinRadius) * CurrentCurve.Evaluate(tEval);

            float x = radius * Mathf.Cos(Mathf.Deg2Rad * startAngle);
            float y = radius * Mathf.Sin(Mathf.Deg2Rad * startAngle);

            Options[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);

            startAngle -= distanceBetweenButtons;
        }
    }


    /// <summary>
    /// Adds an option to the Menu.
    /// </summary>
    /// <param name="optionGameObject"> 
    /// The Option to be set as a child of the menu</param>
    /// <param name="optionSprite"> 
    /// The sprite to set to this new option. 
    /// The method looks for the Image component tagged as "MainImage" </param>
    /// <param name="methodToCallOnClick"> 
    /// Optional. If the option is a button you can pass a method to be called on click.</param>
    public void AddOption(GameObject optionGameObject, Sprite optionSprite, Action<int> methodToCallOnClick = null)
    {
        GameObject go = Instantiate(optionGameObject);
        go.SetActive(true);
        go.transform.parent = transform;

        Button btn = go.GetComponent<Button>();
        RectTransform rt = go.GetComponent<RectTransform>();

        if (Options == null)
            Options = new List<RectTransform>();

        Options.Add(rt);

        int i = Options.Count - 1;//Lock reference

        if (btn && methodToCallOnClick != null)
            btn.onClick.AddListener(delegate { methodToCallOnClick(i); });

        Image[] images = go.GetComponentsInChildren<Image>();

        foreach (Image image in images)
        {
            if (image.tag == "MainImage")
                image.sprite = optionSprite;
        }

        rt.localPosition = new Vector3(0, 0, 0);
        rt.localRotation = Quaternion.identity;

        Animate();
    }

    /// <summary>
    /// Removes all options from this menu.
    /// </summary>
    public void RemoveAllOptions()
    {
        if (Options == null)
            return;

        foreach (RectTransform rt in Options)
        {
            DestroyImmediate(rt.gameObject);
        }
        Options.Clear();
    }
}
