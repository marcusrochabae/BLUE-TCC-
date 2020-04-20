using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class feedbacksPuzzle : MonoBehaviour
{

    public Text m_text;
    private IEnumerator m_coroutine;
    private bool m_coroutineRunning;

    // Start is called before the first frame update
    void Start()
    {
        m_text = GameObject.FindGameObjectWithTag("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        m_coroutine = textBox("");
    }
    public void setText(string text)
    {
        StartCoroutine(textBox(text));
    }

    IEnumerator textBox(string m_readyText)
    {
        m_text.text = "";

        m_coroutineRunning = true;
        m_text.text = m_readyText;
        yield return new WaitForSeconds(3.0f);
        m_text.text = "";
        m_coroutineRunning = false;
    }
}
