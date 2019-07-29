using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


[System.Serializable]


public class AudioManager : MonoBehaviour
{

    public Slider audioVolume;





    private void SetListenerVolume()
    {
        AudioListener.volume = audioVolume.value;
    }


 

    public void ApplySettings()
    {

        SetListenerVolume();
    }

}
