using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escadas : MonoBehaviour
{
    bool es_trigger = false;
    // bool es_stair = false;
    public bool es_buttonW = true;
    Collider2D es_collider;
    public GameObject es_floor;

    void Start(){
        es_collider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        es_trigger = true;
        if(es_collider.enabled){
            es_collider.enabled = !es_collider.enabled;
            es_buttonW = !es_buttonW;
            // print(es_buttonW);
            es_floor.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        es_trigger = false;
        if(es_collider.enabled){
            // print(es_buttonW);
        }
    }

    void Update(){
        if(es_buttonW){
            if(Input.GetKeyDown(KeyCode.W)){
                if(es_trigger){
                    es_collider.enabled = !es_collider.enabled;
                    es_floor.SetActive(false);
                }
            }    
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (es_trigger)
            {
                es_collider.enabled = !es_collider.enabled;
                es_floor.SetActive(false);
            }
        }
    }

}
