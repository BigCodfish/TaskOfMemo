using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSetting : MonoBehaviour
{
    public Sprite currentHeadSkin;
    public Sprite currentBodySkin;
    public Sprite[] headSkins;
    public Sprite[] bodySkins;
    public bool musicOn = true;
    public bool soundOn = true;
    public float musicVolume = 1;
    public float soundVolume = 1;    
    public int level = 2;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        currentBodySkin = bodySkins[0];
        currentHeadSkin = headSkins[0];
    }
}
