using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFree : MonoBehaviour
{
    public GameObject m_lockPlace;

    private void Update()
    {
        if (m_lockPlace == null)
        {
            soundFX.playSound(sound.m_cameraSound);
            Destroy(this.gameObject);
        }
    }
}
