using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sairFinal : MonoBehaviour
{
    public bool m_scapeButtom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_scapeButtom = Input.GetButtonDown("Skip All");

        if (m_scapeButtom)
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }
}
