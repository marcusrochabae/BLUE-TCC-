using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentificarControle : MonoBehaviour
{
    private int Xbox_One_Controller = 0;
    private int PS4_Controller = 0;
    private int Xbox_Controller = 0;
    private int PS3_Controller = 0;

    public string m_ControllerIs;

    public bool m_Fire1;
    public bool m_Fire2;
    public bool m_Fire3;
    public bool m_Interact;
    public bool m_Jump;
    public bool m_Skip;
    public bool m_Start;
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

            if(names[x].Length == 18){ //PS3 1

                PS4_Controller = 0;
                PS3_Controller = 1;
                Xbox_Controller = 0;
                Xbox_One_Controller = 0;

            }else if (names[x].Length == 19){ //PS4 1

                PS4_Controller = 1;
                PS3_Controller = 0;
                Xbox_Controller = 0;
                Xbox_One_Controller = 0;

            }else if(names[x].Length == 22){ // 360 1

                PS4_Controller = 0;
                PS3_Controller = 0;
                Xbox_Controller = 1;
                Xbox_One_Controller = 0;

            }else if (names[x].Length == 33){ // One 1

                PS4_Controller = 0;
                PS3_Controller = 0;
                Xbox_Controller = 0;
                Xbox_One_Controller = 1;

            }else{ //teclado 0

                PS4_Controller = 0;
                PS3_Controller = 0;
                Xbox_Controller = 0;
                Xbox_One_Controller = 0;

            }
         }
 
 
        if(Xbox_One_Controller == 1){

            m_ControllerIs = "XOne";
            m_Fire1 = Input.GetButtonDown("XboxOne Fire1");
            m_Fire2 = Input.GetButtonDown("XboxOne Fire2");
            m_Fire3 = Input.GetButtonDown("XboxOne Fire3");
            m_Interact = Input.GetButtonDown("XboxOne Interact");
            m_Skip = Input.GetButtonDown("XboxOne Skip");
            m_Start = Input.GetButtonDown("XboxOne Start");
            m_Jump = Input.GetButton("XboxOne Jump");
            m_Vertical = Input.GetAxisRaw("XboxOne Vertical");
            m_Horizontal = Input.GetAxisRaw("XboxOne Horizontal");
            m_Vertical2 = Input.GetAxisRaw("XboxOne Vertical 2");
            m_Horizontal2 = Input.GetAxisRaw("XboxOne Horizontal 2");

        }else if(PS4_Controller == 1){

            m_ControllerIs = "PS4";
            m_Fire1 = Input.GetButtonDown("PS4 Fire1");
            m_Fire2 = Input.GetButtonDown("PS4 Fire2");
            m_Fire3 = Input.GetButtonDown("PS4 Fire3");
            m_Interact = Input.GetButtonDown("PS4 Interact");
            m_Skip = Input.GetButtonDown("PS4 Skip");
            m_Start = Input.GetButtonDown("PS4 Start");
            m_Jump = Input.GetButton("PS4 Jump");
            m_Horizontal = Input.GetAxisRaw("PS4 Horizontal");
            m_Vertical = Input.GetAxisRaw("PS4 Vertical");
            m_Horizontal2 = Input.GetAxisRaw("PS4 Horizontal 2");
            m_Vertical2 = Input.GetAxisRaw("PS4 Vertical 2");

        }else if(Xbox_Controller == 1){
            
            m_ControllerIs = "X360";
            m_Fire1 = Input.GetButtonDown("Xbox360 Fire1");
            m_Fire2 = Input.GetButtonDown("Xbox360 Fire2");
            m_Fire3 = Input.GetButtonDown("Xbox360 Fire3");
            m_Interact = Input.GetButtonDown("Xbox360 Interact");
            m_Skip = Input.GetButtonDown("Xbox360 Skip");
            m_Start = Input.GetButtonDown("Xbox360 Start");
            m_Jump = Input.GetButton("Xbox360 Jump");
            m_Vertical = Input.GetAxisRaw("Xbox360 Vertical");
            m_Horizontal = Input.GetAxisRaw("Xbox360 Horizontal");
            m_Vertical2 = Input.GetAxisRaw("Xbox360 Vertical 2");
            m_Horizontal2 = Input.GetAxisRaw("Xbox360 Horizontal 2");

        }else if(PS3_Controller == 1){
            
            m_ControllerIs = "PS3";
            m_Fire1 = Input.GetButtonDown("Xbox360 Fire1");
            m_Fire2 = Input.GetButtonDown("Xbox360 Fire2");
            m_Fire3 = Input.GetButtonDown("Xbox360 Fire3");
            m_Interact = Input.GetButtonDown("Xbox360 Interact");
            m_Skip = Input.GetButtonDown("Xbox360 Skip");
            m_Start = Input.GetButtonDown("Xbox360 Start");
            m_Jump = Input.GetButton("Xbox360 Jump");
            m_Vertical = Input.GetAxisRaw("Xbox360 Vertical");
            m_Horizontal = Input.GetAxisRaw("Xbox360 Horizontal");
            m_Vertical2 = Input.GetAxisRaw("Xbox360 Vertical 2");
            m_Horizontal2 = Input.GetAxisRaw("Xbox360 Horizontal 2");

        }else{

            m_ControllerIs = "Teclado";
            m_Fire1 = Input.GetButtonDown("Fire1");
            m_Fire2 = Input.GetButtonDown("Fire2");
            m_Fire3 = Input.GetButtonDown("Fire3");
            m_Interact = Input.GetButtonDown("Interact");
            m_Skip = Input.GetButtonDown("Skip");
            m_Start = Input.GetButtonDown("Start/Pause");
            m_Jump = Input.GetButton("Jump");
            m_Vertical = Input.GetAxisRaw("Vertical");
            m_Horizontal = Input.GetAxisRaw("Horizontal");
            m_Vertical2 = Input.GetAxisRaw("Vertical 2");
            m_Horizontal2 = Input.GetAxisRaw("Horizontal 2");

        }
    }
}
