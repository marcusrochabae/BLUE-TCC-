using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public  int         m_itens;
    private bool        m_itensAct, m_moeda, m_lockpick, m_door, m_door2, m_door3, m_scissors, m_camera, m_car, m_wardrobe, m_fimAct;

    
    public  GameObject  m_moedaObj, m_lockpickObj, m_doorObj, m_scissorsObj, m_cameraObj, m_carObj, m_wardrobeObj;
    public  GameObject  m_stair, m_doorOpenObj, m_doorOpen2Obj, m_doorOpen3Obj, m_door2Obj, m_door3Obj, m_cameraOff;

    // Start is called before the first frame update
    void Start()
    {
        m_fimAct = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && m_itensAct)
        {
            if (m_moeda)
            {
                Destroy(this.m_moedaObj);
                m_stair.SetActive(true);
                m_itens += 1;
            }

            if (m_lockpick && m_itens == 1)
            {
                Destroy(this.m_lockpickObj);
                m_itens += 1;
            }

            if (m_door && m_itens == 2)
            {
                Destroy(this.m_doorObj);
                m_doorOpenObj.SetActive(true);
                m_itens += 1;
            }

            if (m_scissors && m_itens == 2)
            {
                Destroy(this.m_scissorsObj);
            }

            if (m_door2Obj && m_itens == 3)
            {
                Destroy(this.m_door2Obj);
                m_doorOpen2Obj.SetActive(true);
                m_itens += 1;
            }

            if (m_door3Obj && m_itens == 6)
            {
                Destroy(this.m_door3Obj);
                m_doorOpen2Obj.SetActive(true);
            }

            if (m_scissors && m_itens == 4)
            {
                Destroy(this.m_scissorsObj);
                m_cameraOff.SetActive(true);
                m_itens += 1;
            }

            if (m_camera && m_itens == 5)
            {
                Destroy(this.m_cameraObj);
                m_itens += 1;
            }

            if (m_car && m_itens == 6)
            {
                Destroy(this.m_carObj);
                m_itens += 1;
            }

            if (m_wardrobe && m_itens == 6)
            {
                Destroy(this.m_wardrobeObj);
                m_fimAct = true;
                m_itens += 1;
            }

        }

        if (Input.GetButtonDown("Interact") && m_fimAct && m_itens == 7)
        {
            SceneManager.LoadScene("FinalScene");
        }
    }

    //função de detecção de colisão com triggers
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            // case "Enemy":
            //     SceneManager.LoadScene("GameOver");
            //     break;
            case "Coin":
                m_itensAct = true;
                m_moeda = true;
                break;
            case "Lockpick":
                m_itensAct = true;
                m_lockpick = true;
                break;
            case "Door":
                m_itensAct = true;
                m_door = true;
                m_door2 = true;
                m_door3 = true;
                break;
            case "Scissors":
                m_itensAct = true;
                m_scissors = true;
                break;
            case "Camera":
                m_itensAct = true;
                m_camera = true;
                break;
            case "Car":
                m_itensAct = true;
                m_car = true;
                break;
            case "Wardrobe":
                m_itensAct = true;
                m_wardrobe = true;
                break;
            case "Fim":
                m_fimAct = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Coin":
                m_itensAct = false;
                m_moeda = false;
                break;
            case "LockPick":
                m_itensAct = false;
                m_lockpick = false;
                break;
            case "Door":
                m_itensAct = false;
                m_door = false;
                break;
            case "Scissors":
                m_itensAct = false;
                m_scissors = false;
                break;
            case "Camera":
                m_itensAct = false;
                m_camera = false;
                break;
            case "Car":
                m_itensAct = false;
                m_car = false;
                break;
            case "Wardrobe":
                m_itensAct = false;
                m_wardrobe = false;
                break;
            case "Fim":
                m_fimAct = false;
                break;
        }
    }
}
