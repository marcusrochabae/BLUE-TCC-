using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ColorManipulation : MonoBehaviour
{
    public ColorGrading m_ColorGrading;

    public PostProcessVolume m_ColorVol;

    // Start is called before the first frame update
    void Start()
    {
        m_ColorVol = GetComponent<PostProcessVolume>();
        m_ColorGrading = m_ColorVol.profile.GetSetting<ColorGrading>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
