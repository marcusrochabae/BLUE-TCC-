using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Material m_materialColor;
    public Color m_blackColor;
    public float m_timeColor;

    private bool m_lerpColor = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) {
            m_lerpColor = true;
            Invoke("changeScene", 1);
        }
    }

    void FixedUpdate () {

        if (m_lerpColor == true)
        {
            m_materialColor.color = Color.Lerp(m_materialColor.color, m_blackColor, m_timeColor);
        }
    }

    void changeScene()
    {
        SceneManager.LoadScene("Final");
    }
}
