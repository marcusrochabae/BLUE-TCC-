using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum sound
{
    m_scenarioChange, m_nickelSound, m_lockpickSound, m_openDoorSound, m_scissorsSound, m_cameraSound, m_carestackerSound, m_wardrobeSound, m_elevatorSound
}

public class soundFX : MonoBehaviour
{
    [Header("SFX Puzzle 1")]
    public AudioClip m_sChange;
    public AudioClip m_nickel;
    public AudioClip m_lockpick;
    public AudioClip m_openDoor;
    public AudioClip m_scissors;
    public AudioClip m_camera;
    public AudioClip m_carestakerCart;
    public AudioClip m_warDrobe;
    public AudioClip m_elevator;

    public static soundFX m_instance;
    private AudioSource   m_audio;

    // Start is called before the first frame update
    void Start()
    {
        //inicializando o audioSource
        m_audio = GetComponent<AudioSource>();

        m_instance = this;
    }

    public static void playSound(sound currrentSound)
    {
        switch (currrentSound)
        {
            case sound.m_scenarioChange:
                m_instance.m_audio.PlayOneShot (m_instance.m_sChange);
                break;
            case sound.m_nickelSound:
                m_instance.m_audio.PlayOneShot(m_instance.m_nickel);
                break;
            case sound.m_lockpickSound:
                m_instance.m_audio.PlayOneShot(m_instance.m_lockpick);
                break;
            case sound.m_openDoorSound:
                m_instance.m_audio.PlayOneShot(m_instance.m_openDoor);
                break;
            case sound.m_scissorsSound:
                m_instance.m_audio.PlayOneShot(m_instance.m_scissors);
                break;
            case sound.m_cameraSound:
                m_instance.m_audio.PlayOneShot(m_instance.m_camera);
                break;
            case sound.m_carestackerSound:
                m_instance.m_audio.PlayOneShot(m_instance.m_carestakerCart);
                break;
            case sound.m_wardrobeSound:
                m_instance.m_audio.PlayOneShot(m_instance.m_warDrobe);
                break;
            case sound.m_elevatorSound:
                m_instance.m_audio.PlayOneShot(m_instance.m_elevator);
                break;
        }
    }
}
