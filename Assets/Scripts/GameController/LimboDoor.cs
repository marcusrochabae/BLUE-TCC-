using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LimboDoor : MonoBehaviour
{
    // private IEnumerator WaitForSceneLoad()
    // {
    //     yield return new WaitForSeconds();
        
    // }

    private bool m_Button = false;

    void Update(){
        if(m_Button && Input.GetButtonDown("Interact")){
            SceneManager.LoadScene("Puzzle1");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            m_Button = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col){
        m_Button = false;
    }
}
