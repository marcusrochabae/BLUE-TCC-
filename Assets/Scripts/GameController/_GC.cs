using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class _GC : MonoBehaviour {

    [Header("Scenario Objects")]
    public GameObject m_house;
    public GameObject m_arcade;
    public GameObject m_school;
    private scenarioChange m_ScenarioScript;
    private ShowText m_ScriptText;

    [Header("Material Refs")]
    public Material m_materialColor;
    public Color m_materialBlack, m_materialGrey;
    public float m_timeColor;
    private bool m_lerpColor;

    [Header("Puzzle")]
    public List<int> m_ItemLista;

    // Use this for initialization
    void Start () {
        m_ScenarioScript = FindObjectOfType(typeof(scenarioChange)) as scenarioChange;
        m_ScriptText = FindObjectOfType(typeof(ShowText)) as ShowText;
        // Dar ao jogador o objetivo do puzzle
        m_ScriptText.showText("Seu amigo está no terraço da escola. Melhor ir para lá...");
        m_ScriptText.cleanTextAfterSeconds(5);
        m_ItemLista = new List<int>();
        m_lerpColor = true;

    }

    // Update is called once per frame
    void FixedUpdate () {
        //Apertando o botão o cenário é trocado quando se está em cima do objeto correto Arcade
        if (m_ScenarioScript.m_btArcade == true && m_ScenarioScript.m_arcadeAct == false && (m_ScenarioScript.m_houseAct == true || m_ScenarioScript.m_schoolAct == true))
        {
            soundFX.playSound(sound.m_scenarioChange);
            m_lerpColor = false;
            m_ScenarioScript.m_houseAct = false;
            m_ScenarioScript.m_schoolAct = false;
            m_materialColor.color = Color.black;
            if (m_lerpColor == false)
            {
                m_house.SetActive(false);
                m_school.SetActive(false);
                m_arcade.SetActive(true);
                m_lerpColor = !m_lerpColor;
            }
        }

        //Apertando o botão o cenário é trocado quando se está em cima do objeto correto Escola
        if (m_ScenarioScript.m_btSchool == true && m_ScenarioScript.m_schoolAct == false && (m_ScenarioScript.m_arcadeAct == true || m_ScenarioScript.m_houseAct == true))
        {
            soundFX.playSound(sound.m_scenarioChange);
            m_lerpColor = false;
            m_ScenarioScript.m_houseAct = false;
            m_ScenarioScript.m_arcadeAct = false;
            m_materialColor.color = Color.black;
            if (m_lerpColor == false)
            {
                m_arcade.SetActive(false);
                m_house.SetActive(false);
                m_school.SetActive(true);
                m_lerpColor = !m_lerpColor;
            }
        }

        //Apertando o botão o cenário é trocado quando se está em cima do objeto correto Casa
        if (m_ScenarioScript.m_btHouse == true && m_ScenarioScript.m_houseAct == false && (m_ScenarioScript.m_schoolAct == true || m_ScenarioScript.m_arcadeAct == true))
        {
            soundFX.playSound(sound.m_scenarioChange);
            m_lerpColor = false;
            m_ScenarioScript.m_arcadeAct = false;
            m_ScenarioScript.m_schoolAct = false;
            m_materialColor.color = Color.black;
            if (m_lerpColor == false)
            {
                m_school.SetActive(false);
                m_arcade.SetActive(false);
                m_house.SetActive(true);
                m_lerpColor = !m_lerpColor;
            }
        }

        //Controla FadeIn FadeOut da transição de cenários
        if (m_lerpColor == true)
        {
            m_materialColor.color = Color.Lerp(m_materialColor.color, m_materialGrey, m_timeColor);
        }
    }
}