using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSetting : MonoBehaviour
{
    public Sprite currentHeadSkin;
    public Sprite currentBodySkin;
    public float bgmVolume;
    public float soundVolume;
    public Sprite[] headSkins;
    public Sprite[] bodySkins;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        currentBodySkin = bodySkins[0];
        currentHeadSkin = headSkins[0];
    }
}
