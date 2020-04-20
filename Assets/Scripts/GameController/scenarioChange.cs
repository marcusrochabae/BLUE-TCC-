using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenarioChange : MonoBehaviour {

    [Header("Variáveis de verificação")]
    public bool m_houseAct;  
    public bool m_arcadeAct, m_schoolAct, m_btHouse, m_btArcade, m_btSchool;
    private IdentificarControle m_IdentificarControle;

	// Use this for initialization
	void Start () {
        m_houseAct  = false;
        m_arcadeAct = false;
        m_schoolAct = false;
        m_IdentificarControle = FindObjectOfType(typeof(IdentificarControle)) as IdentificarControle;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //indentificando botão ativo
        m_btHouse  = m_IdentificarControle.m_Fire1;
        m_btArcade = m_IdentificarControle.m_Fire2;
        m_btSchool = m_IdentificarControle.m_Fire3;
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
