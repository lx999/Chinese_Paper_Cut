using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum AntialiasingValues { disabled = 0, x2 = 2, x4 = 4, x8 = 8 };

[System.Serializable]
public class QualityData
{
    public string QualityLevelName = "";
    public int textureQuality = 0;
    public AntialiasingValues antialiasingValues = 0;
    public int anisotropic = 0;
    public int vsync = 0;
}

public class OptionsManager : MonoBehaviour
{
    public Dropdown qualitySettings;
    public Dropdown textureQuality;
    public Dropdown antialiasing;
    public Dropdown anisotropicTextures;
    public Dropdown vsync;

    private List<QualityData> currentQualities = new List<QualityData>();

    void Start()
    {
        GetGlobalSettings();
        SetQualitySettingsInOptions();
    }

    public void SetGlobalValues()
    {
        QualityData selectedQuality = currentQualities[qualitySettings.value];

        textureQuality.value = selectedQuality.textureQuality;
        antialiasing.value = (int)selectedQuality.antialiasingValues;
        anisotropicTextures.value = selectedQuality.anisotropic;
        vsync.value = selectedQuality.vsync;
    }

    public void GetGlobalSettings()
    {
        var lastQuality = QualitySettings.GetQualityLevel();

        for (var i = 0; i < QualitySettings.names.Length; i++)
        {
            QualitySettings.SetQualityLevel(i, false);
            currentQualities.Add(new QualityData
            {
                QualityLevelName = QualitySettings.names[QualitySettings.GetQualityLevel()],
                antialiasingValues = (AntialiasingValues)QualitySettings.antiAliasing,
                anisotropic = (int)QualitySettings.anisotropicFiltering,
                textureQuality = QualitySettings.masterTextureLimit,
                vsync = QualitySettings.vSyncCount
            }
            );
        }

        QualitySettings.SetQualityLevel(lastQuality);
    }

    private void SetQualitySettingsInOptions()
    {
        qualitySettings.ClearOptions();
        qualitySettings.AddOptions(QualitySettings.names.ToList());
    }

    #region Applying Settings

    

    private void SetQualityCount()
    {
        QualitySettings.SetQualityLevel(qualitySettings.value);
    }

    private void SetTextureQuality()
    {
        QualitySettings.masterTextureLimit = textureQuality.value;
    }

    //TODO: заменить костыль адекватным решением
    //TODO: fix this with more normal solution
    private void SetAntialiasingLevel()
    {
        if (antialiasing.value == 3)
        {
            QualitySettings.antiAliasing = 8;
        }
        else
        {
            QualitySettings.antiAliasing = antialiasing.value * 2;
        }
    }

    private void SetAnisotropicTextures()
    {
        QualitySettings.anisotropicFiltering = (AnisotropicFiltering)anisotropicTextures.value;
#if false
        switch (anisotropicTextures.value)
        {
            case 0:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
                break;
            case 1:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
                break;
            case 2:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
                break;
        }
#endif
    }



    private void SetVsync()
    {
        QualitySettings.vSyncCount = vsync.value;
    }

    #endregion

    public void ApplySettings()
    {
        SetQualityCount();
        SetTextureQuality();
        SetAntialiasingLevel();
        SetAnisotropicTextures();
        SetVsync();
    }

}
