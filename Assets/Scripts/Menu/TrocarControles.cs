using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocarControles : MonoBehaviour
{
    public GameObject[] m_ArrayObjects;
    public int m_Contador = 0;
    private bool m_bool = true;
    public float countdown = 0f;
    private IdentificarControle m_IdentificarControle;
    void Start(){
        m_IdentificarControle = FindObjectOfType(typeof(IdentificarControle)) as IdentificarControle;
    }
    void Update()
    {
        if(!m_bool){
            countdown += Time.deltaTime;
            if(countdown >= 0.49f){
                m_bool = true;
                countdown = 0f;
            }
        }
        if(m_IdentificarControle.m_Horizontal != 0 && m_bool){
            m_bool = false;
            TrocaControle();
        }
    }

    void TrocaControle(){
            // print(m_IdentificarControle.m_Horizontal);
            if(m_IdentificarControle.m_Horizontal == 1){

                m_IdentificarControle.m_Horizontal = 0;
                m_ArrayObjects[m_Contador].SetActive(false);
                m_Contador++;
                if(m_Contador > 4){
                    m_Contador = 0;
                }
                m_ArrayObjects[m_Contador].SetActive(true);
            }else if(m_IdentificarControle.m_Horizontal == -1){

                m_ArrayObjects[m_Contador].SetActive(false);
                m_Contador--;
                if(m_Contador < 0){
                    m_Contador = 4;
                }
                m_ArrayObjects[m_Contador].SetActive(true);
            }
    }
}
