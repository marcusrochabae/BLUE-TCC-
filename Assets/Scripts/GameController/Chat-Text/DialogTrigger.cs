using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    public string m_TriggerName;
    public bool m_interact;
    public bool m_transitionA;
    public bool m_transitionB;
    public bool m_transitionC;
    public bool m_player;
    public float m_timeText = 0.05f;
    public Text m_text;
    private bool m_coroutineRunning;
    private IEnumerator m_coroutine;
    private _GC m_GCScript;
    private IdentificarControle m_IdentificarControle;
    public int m_NumPuzzle;
    private int m_TamanhoLista;
    private bool m_ThisPuzzle = false;
    private string btn1;
    private string btn2;
    private string btn3;
    private string m_TextoJson;

    private void Start()
    {
        m_text = GameObject.FindGameObjectWithTag("Text").GetComponent<Text>();
        m_GCScript = FindObjectOfType(typeof(_GC)) as _GC;
        m_IdentificarControle = FindObjectOfType(typeof(IdentificarControle)) as IdentificarControle;
    }

    private void Update()
    {
        if(m_IdentificarControle.m_ControllerIs == "Teclado"){
            btn1 = "1";
            btn2 = "2";
            btn3 = "3";
        }else if(m_IdentificarControle.m_ControllerIs == "PS4" || m_IdentificarControle.m_ControllerIs == "PS3"){
            btn1 = "Quadrado";
            btn2 = "Triangulo";
            btn3 = "Bolinha";
        }else if(m_IdentificarControle.m_ControllerIs == "XOne" || m_IdentificarControle.m_ControllerIs == "X360"){
            btn1 = "X";
            btn2 = "Y";
            btn3 = "B";
        }

        m_interact      = m_IdentificarControle.m_Interact;
        m_transitionA   = m_IdentificarControle.m_Fire1;
        m_transitionB   = m_IdentificarControle.m_Fire2;
        m_transitionC   = m_IdentificarControle.m_Fire3;

        m_coroutine = textBox("");

        if (m_interact && m_player)
        {
            m_TamanhoLista = m_GCScript.m_ItemLista.Count;

            for(var i = 0; i < m_TamanhoLista; i++){
                if(m_GCScript.m_ItemLista[i] == m_NumPuzzle){
                    m_ThisPuzzle = true;
                }
            }

            if(m_ThisPuzzle == false){
                var trigger = Chat.Instance.Search(m_TriggerName);
                m_TextoJson = trigger.Text;
                m_TextoJson = m_TextoJson.Replace("<btn1>",btn1);
                m_TextoJson = m_TextoJson.Replace("<btn2>",btn2);
                m_TextoJson = m_TextoJson.Replace("<btn3>",btn3);
                setText(m_TextoJson);
                // setText(trigger.Text);

                m_player = !m_player;
                m_ThisPuzzle = false;
            }
        }

        // Tratamento para não bugar o texto ao trocar de cenário.
        if (m_transitionA || m_transitionB || m_transitionC) {
            StopCoroutine(m_coroutine);
            m_coroutineRunning = false;
            m_text.text = "";
        }

        if(m_TriggerName == "Tutorial" && m_interact && m_player)
        {
            var trigger = Chat.Instance.Search(m_TriggerName);
            m_TextoJson = trigger.Text;
            m_TextoJson = m_TextoJson.Replace("<btn1>",btn1);
            m_TextoJson = m_TextoJson.Replace("<btn2>",btn2);
            m_TextoJson = m_TextoJson.Replace("<btn3>",btn3);
            setText(m_TextoJson);

            m_player = !m_player;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            m_player = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            m_player = false;
        }
    }

    private void setText(string text)
    {
        StartCoroutine(textBox(text));
    }

    // Função responsável por controlar caixa de texto (concatena as letras uma a uma)
    IEnumerator textBox(string m_readyText)
    {
        m_text.text = "";

        m_coroutineRunning = true;
        // while (m_letter < m_readyText.Length)
        // {
        //     m_text.text += m_readyText[m_letter];
        //     m_letter += 1;
        //     yield return new WaitForSeconds(m_timeText);
        // }
        // Limpar o texto exibido após 5 segundos
        m_text.text = m_readyText;
        yield return new WaitForSeconds(5);
        m_text.text = "";
        m_coroutineRunning = false;
    }
}
