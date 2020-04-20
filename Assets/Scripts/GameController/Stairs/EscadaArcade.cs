using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscadaArcade : MonoBehaviour
{
    public GameObject m_escadaUp;
    private _GC m_GCScript;
    private int m_NItem;
    private int m_TamanhoLista;
    // private bool m_boolean = false;

    private void Start()
    {
        m_GCScript = FindObjectOfType(typeof(_GC)) as _GC;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // print(m_GCScript.m_ItemLista.Count);
        m_TamanhoLista = m_GCScript.m_ItemLista.Count;
        if (collision.gameObject.tag == "Player" && m_TamanhoLista > 0)
        {
            for(var i = 0; i < m_TamanhoLista; i++){
                if(m_GCScript.m_ItemLista[i] == 0){
                    m_escadaUp.SetActive(true);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        m_TamanhoLista = m_GCScript.m_ItemLista.Count;
        if (collision.gameObject.tag == "Player" && m_TamanhoLista > 0)
        {
            for(var i = 0; i < m_TamanhoLista; i++){
                if(m_GCScript.m_ItemLista[i] == 0){
                    this.gameObject.SetActive(false);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
