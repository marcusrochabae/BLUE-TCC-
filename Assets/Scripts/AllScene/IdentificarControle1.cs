using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentificarControle1 : MonoBehaviour
{
    private int Xbox_One_Controller = 0;
    private int PS4_Controller = 0;
    private int Xbox_Controller = 0;

    public bool m_Fire1;
    public bool m_Fire2;
    public bool m_Fire3;
    public bool m_Interact;
    public bool m_Jump;
    public bool m_Skip;
    public float m_Vertical;
    public float m_Horizontal;
    public float m_Horizontal2;
    public float m_Vertical2;

    void Update()
    {
        string[] names = Input.GetJoystickNames();
         for (int x = 0; x < names.Length; x++)
         {
            // print(names[x].Length);
            
            if (names[x].Length == 19){ //PS4

                PS4_Controller = 1;
                Xbox_Controller = 0;
                Xbox_One_Controller = 0;
            }else if(names[x].Length == 22){ // 360

                PS4_Controller = 0;
                Xbox_Controller = 1;
                Xbox_One_Controller = 0;
            }else if (names[x].Length == 33){ // One

                PS4_Controller = 0;
                Xbox_Controller = 0;
                Xbox_One_Controller = 1;

            }else{
                Xbox_One_Controller = 0;
            }
         }
 
 
        if(Xbox_One_Controller == 1){

            print("Xbox One Conectado");
        }else if(PS4_Controller == 1){
            
            m_Fire1 = Input.GetButtonDown("PS4 Fire1");
            m_Fire2 = Input.GetButtonDown("PS4 Fire2");
            m_Fire3 = Input.GetButtonDown("PS4 Fire3");
            m_Interact = Input.GetButtonDown("PS4 Interact");
            m_Skip = Input.GetButtonDown("PS4 Skip");
            m_Jump = Input.GetButton("PS4 Jump");
            m_Horizontal = Input.GetAxisRaw("PS4 Horizontal");
            m_Vertical = Input.GetAxisRaw("PS4 Vertical");
            m_Horizontal2 = Input.GetAxisRaw("PS4 Horizontal 2");
            m_Vertical2 = Input.GetAxisRaw("PS4 Vertical 2");

        }else if(Xbox_Controller == 1){
            
            m_Fire1 = Input.GetButtonDown("Xbox360 Fire1");
            m_Fire2 = Input.GetButtonDown("Xbox360 Fire2");
            m_Fire3 = Input.GetButtonDown("Xbox360 Fire3");
            m_Interact = Input.GetButtonDown("Xbox360 Interact");
            m_Skip = Input.GetButtonDown("Xbox360 Skip");
            m_Jump = Input.GetButton("Xbox360 Jump");
            m_Vertical = Input.GetAxisRaw("Xbox360 Vertical");
            m_Horizontal = Input.GetAxisRaw("Xbox360 Horizontal");
            m_Vertical2 = Input.GetAxisRaw("Xbox360 Vertical 2");
            m_Horizontal2 = Input.GetAxisRaw("Xbox360 Horizontal 2");
        }else{
            m_Fire1 = Input.GetButtonDown("Fire1");
            m_Fire2 = Input.GetButtonDown("Fire2");
            m_Fire3 = Input.GetButtonDown("Fire3");
            m_Interact = Input.GetButtonDown("Interact");
            m_Skip = Input.GetButtonDown("Skip");
            m_Jump = Input.GetButton("Jump");
            m_Vertical = Input.GetAxisRaw("Vertical");
            m_Horizontal = Input.GetAxisRaw("Horizontal");
            m_Vertical2 = Input.GetAxisRaw("Vertical 2");
            m_Horizontal2 = Input.GetAxisRaw("Horizontal 2");
        }

    }
}
