using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrasesLimbo : MonoBehaviour
{
    public Text m_TextBox;
    public string[] m_FrasesLimbo;
    public int m_IndexText;
    // Start is called before the first frame update
    void Start()
    {
        m_IndexText = Random.Range(0, 9);
        m_TextBox = GameObject.FindGameObjectWithTag("FrasesLimbo").GetComponent<Text>();
        m_TextBox.text = m_FrasesLimbo[m_IndexText];
    }

    // Update is called once per frame
    // void FixedUpdate()
    // {
    //     m_textBox.text = "";
    // }
}