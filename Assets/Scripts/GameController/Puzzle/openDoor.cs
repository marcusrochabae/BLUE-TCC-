using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public GameObject m_openDoor;
    public GameObject m_closeDoor;

    private void Update()
    {
        if(m_closeDoor == null)
        {
            soundFX.playSound(sound.m_openDoorSound);
            m_openDoor.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
