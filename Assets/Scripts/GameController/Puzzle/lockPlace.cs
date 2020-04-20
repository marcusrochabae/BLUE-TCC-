using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockPlace : MonoBehaviour
{
    public GameObject m_lockPlace;

    public ObjectSounds m_ObjectSounds = ObjectSounds.none;
    public enum ObjectSounds { none, camera, elevator }

    private void Update()
    {
        switch (m_ObjectSounds)
        {
            case ObjectSounds.camera:
                if (m_lockPlace == null)
                {
                    soundFX.playSound(sound.m_cameraSound);
                    Destroy(this.gameObject);
                }
                break;
            case ObjectSounds.elevator:
                if (m_lockPlace == null)
                {
                    soundFX.playSound(sound.m_elevatorSound);
                    Destroy(this.gameObject);
                }
                break;
        } 
    }
}
