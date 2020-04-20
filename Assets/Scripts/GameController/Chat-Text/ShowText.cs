using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Sempre que for acessar este script de qualquer objeto para
exibir mensagens na tela, fazer da seginte forma:

    private ShowText m_ScriptText;

    void Start()
    {
        m_ScriptText = FindObjectOfType(typeof(ShowText)) as ShowText;
        m_ScriptText.showText("Daniel boiola!");
        cleanTextAfterSeconds(10);
    }
*/

public class ShowText : MonoBehaviour
{
    private Text m_text;
    public bool m_active = false;

    void Start()
    {
        m_text = GetComponent<Text>();
    }

    public void showText(string text)
    {
        m_text.text = text;
        m_active = true;
    }

    public void cleanText()
    {
        m_text.text = "";
        m_active = false;
    }

    public void cleanTextAfterSeconds(int seconds)
    {
        StartCoroutine(waitAndDoIt(seconds));
    }

    IEnumerator waitAndDoIt(int seconds)
    {
        yield return new WaitForSeconds(5);
        m_text.text = "";
        m_active = false;
    }
}
