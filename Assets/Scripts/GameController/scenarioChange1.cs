using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenarioChange1 : MonoBehaviour {
    
    public GameObject    m_house, m_arcade, m_school;
    public bool          m_houseAct, m_arcadeAct, m_schoolAct, m_btHouse, m_btArcade, m_btSchool;
    
    [Header("Material Refs")]
    public  Material     m_materialColor;
    public  Color        m_materialRed, m_materialBlack, m_materialGreen, m_materialBlue;
    public  float        m_timeColor;
    private bool         m_lerpColor, m_redAct, m_blueAct, m_greenAct;

	// Use this for initialization
	void Start () {
        m_materialColor.color = m_materialGreen;
        m_houseAct  = false;
        m_arcadeAct = false;
        m_schoolAct = false;
        m_lerpColor = false;
        m_redAct    = false;
        m_greenAct  = false;
        m_blueAct   = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //indentificando botão ativo
        m_btHouse  = Input.GetButtonDown("Fire1");
        m_btArcade = Input.GetButtonDown("Fire2");
        m_btSchool = Input.GetButtonDown("Fire3");

        //Apertando o botão o cenário é trocado quando se está em cima do objeto correto Arcade
        if (m_btArcade == true && m_arcadeAct == false && (m_houseAct == true || m_schoolAct == true))
        {
            m_lerpColor = false;
            m_greenAct = false;
            m_blueAct = false;
            m_houseAct = false;
            m_schoolAct = false;
            m_materialColor.color = Color.black;
            if (m_lerpColor == false) {
                m_house.SetActive(false);
                m_school.SetActive(false);
                m_arcade.SetActive(true);
                m_lerpColor = !m_lerpColor;
                m_redAct = !m_redAct;
            }
        }

        if (m_lerpColor == true && m_redAct == true)
        {
            m_materialColor.color = Color.Lerp(m_materialColor.color, m_materialRed, m_timeColor);  
        }

        //Apertando o botão o cenário é trocado quando se está em cima do objeto correto Escola
        if (m_btSchool == true && m_schoolAct == false && (m_arcadeAct == true || m_houseAct == true))
        {
            m_lerpColor = false;
            m_redAct = false;
            m_greenAct = false;
            m_houseAct = false;
            m_arcadeAct = false;
            m_materialColor.color = Color.black;
            if (m_lerpColor == false)
            {
                m_arcade.SetActive(false);
                m_house.SetActive(false);
                m_school.SetActive(true);
                m_lerpColor = !m_lerpColor;
                m_blueAct = !m_blueAct;
            }
        }
        
        if (m_lerpColor == true && m_blueAct == true)
        {
            m_materialColor.color = Color.Lerp(m_materialColor.color, m_materialBlue, m_timeColor);
        }

        //Apertando o botão o cenário é trocado quando se está em cima do objeto correto Casa
        if (m_btHouse == true && m_houseAct == false && (m_schoolAct == true || m_arcadeAct == true))
        {
            m_lerpColor = false;
            m_redAct = false;
            m_blueAct = false;
            m_arcadeAct = false;
            m_schoolAct = false;
            m_materialColor.color = Color.black;
            if (m_lerpColor == false)
            {
                m_school.SetActive(false);
                m_arcade.SetActive(false);
                m_house.SetActive(true);
                m_lerpColor = !m_lerpColor;
                m_greenAct = !m_greenAct;
            }
        }

        if (m_lerpColor == true && m_greenAct == true)
        {
            m_materialColor.color = Color.Lerp(m_materialColor.color, m_materialGreen, m_timeColor);
        }
    }


    //função para ativar a função de troca de cenário
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Clock":
                m_houseAct = true;
            break;

            case "Arcade":
                m_arcadeAct = true;
            break;

            case "School":
                m_schoolAct = true;
            break;
        }
    }


    //função para desativar a função de troca de cenário
    private void OnTriggerExit2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Clock":
                m_houseAct = false;
            break;

            case "Arcade":
                m_arcadeAct = false;
            break;

            case "School":
                m_schoolAct = false;
            break;
        }
    }
}
