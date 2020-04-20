using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscadaUp : MonoBehaviour
{
    public bool es_trigger = false;
    public GameObject es_floor;
    public GameObject es_stair;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            es_trigger = true;
            es_floor.SetActive(true);
            es_stair.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        es_trigger = false;
    }

    void Update()
    {
        float m_movY = Input.GetAxis("Vertical");

        if (-m_movY > 0.8f)
        {
            if (es_trigger){
                es_floor.SetActive(false);
                es_stair.SetActive(true);
            }
        }
    }
}
