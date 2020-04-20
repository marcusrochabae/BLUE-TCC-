using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initiateScene : MonoBehaviour
{
    public Image m_imageColor;
    public Color m_blackColor;
    public float m_timeColor;

    void FixedUpdate()
    {
        m_imageColor.color = Color.Lerp(m_imageColor.color, m_blackColor, m_timeColor);
        Cursor.visible = false;
    }
}