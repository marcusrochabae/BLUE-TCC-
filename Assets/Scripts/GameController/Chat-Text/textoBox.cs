using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class textoBox : MonoBehaviour {

    [Header("Chat Box")]
    public  Text        m_textBox;
    public  string[]    m_text;
    public  float       m_timeText;
    private bool        m_spaceAct;

    [Header("Image Box")]
    public Image imageSequence;
    public Sprite[] sprites;
    public int m_indexImage;
    public int m_indexImageFix;

    [Header("Sound")]
    public AudioSource soundSequence;
    public AudioClip[] m_speak;
    public static textoBox instance;

    [Header("Skip/SkipAll")]
    public Text m_TextoSkip;

    public string m_Scene;

    private IdentificarControle m_IdentificarControle;

    // Use this for initialization
    void Start()
    {
        m_spaceAct = false;
        m_IdentificarControle = FindObjectOfType(typeof(IdentificarControle)) as IdentificarControle;
        //StartCoroutine(textBox(m_text[m_indexImage]));
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        if(m_IdentificarControle.m_ControllerIs == "Teclado"){
            m_TextoSkip.text = "Pular-(Esc)";
        }else if(m_IdentificarControle.m_ControllerIs == "PS4"){
            m_TextoSkip.text = "Pular-(Esc/Option)";
        }else if(m_IdentificarControle.m_ControllerIs == "PS3"){
            m_TextoSkip.text = "Pular-(Esc/Start)";
        }else if(m_IdentificarControle.m_ControllerIs == "XOne"){
            m_TextoSkip.text = "Pular-(Esc/Menu)";
        }else if(m_IdentificarControle.m_ControllerIs == "X360"){
            m_TextoSkip.text = "Pular-(Esc/Start)";
        }
        //input para passar a corrotina    
        if (/*(m_IdentificarControle.m_Skip && m_spaceAct == false && m_indexImage < m_indexImageFix) ||*/ !soundSequence.isPlaying && m_indexImage < m_indexImageFix)
        {
            imageSequence.sprite = sprites[m_indexImage];
            m_spaceAct = true;
            //StopCoroutine(textBox(m_text[m_indexImage]));
            soundSequence.Stop();
            StartCoroutine(textBox(m_text[m_indexImage]));

            if (m_indexImage < m_indexImageFix)
            {
                StopCoroutine(textBox(m_text[m_indexImage]));
            }
        } else if (!soundSequence.isPlaying && m_spaceAct == false && m_indexImage == m_indexImageFix && m_Scene == "Intro")
        {
            SceneManager.LoadScene("Tutorial");
        }
        else if (!soundSequence.isPlaying && m_spaceAct == false && m_indexImage == m_indexImageFix && m_Scene == "Final")
        {
            SceneManager.LoadScene("Continua");
        }
        else if (!soundSequence.isPlaying && m_spaceAct == false && m_indexImage == m_indexImageFix && m_Scene == "Tutorial")
        {
            SceneManager.LoadScene("Puzzle1");
        }
        else if(m_indexImage == 0 && m_spaceAct == false){
            imageSequence.sprite = sprites[m_indexImage];
            m_spaceAct = true;
            soundSequence.Stop();
            StartCoroutine(textBox(m_text[m_indexImage]));

            if (m_indexImage < m_indexImageFix)
            {
                StopCoroutine(textBox(m_text[m_indexImage]));
            }
        }

        if (m_IdentificarControle.m_Start && m_Scene == "Intro")
        {
            SceneManager.LoadScene("Tutorial"); 
        }
        else if (m_IdentificarControle.m_Start &&  m_Scene == "Final")
        {
            SceneManager.LoadScene("Continua");
        }
        else if (m_IdentificarControle.m_Start && m_Scene == "Tutorial")
        {
            SceneManager.LoadScene("Puzzle1");
        }
    }

    //função responsável por controlar caixa de texto (concatena as letras)
    IEnumerator textBox(string m_readyText)
    {
        soundSequence.PlayOneShot(m_speak[m_indexImage]);
        m_textBox.text = m_readyText;
        m_indexImage++;
        yield return new WaitForSeconds(m_timeText);
        m_spaceAct = false;
        //adicionar aviso de PRESS SPACE
    }
    
}