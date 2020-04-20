using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicControl : MonoBehaviour
{
    public AudioMixer mixer;

    public GameObject m_escola;
    public GameObject m_casa;
    public GameObject m_arcade;

    void Start()
    {
        mixer.SetFloat("VolumeMusica1", -80.0f);
        mixer.SetFloat("VolumeMusica2", -80.0f);
        mixer.SetFloat("VolumeMusica3", -80.0f);
    }

    void Update()
    {
        if (m_escola.activeSelf) {
            changeToMusic(1);
            
        } else if (m_casa.activeSelf) {
            changeToMusic(2);
        } else if (m_arcade.activeSelf) {
            changeToMusic(3);
        }
    }

    void changeToMusic(int number)
    {
        // Pegar os volumes atuais das 3 faixas.
        float volume_musica_1;
        float volume_musica_2;
        float volume_musica_3;

        mixer.GetFloat("VolumeMusica1", out volume_musica_1);
        mixer.GetFloat("VolumeMusica2", out volume_musica_2);
        mixer.GetFloat("VolumeMusica3", out volume_musica_3);

        // Fazer a transição gradativa das músicas quando troca de cenário.
        if (number == 1) {
            mixer.SetFloat("VolumeMusica1", Mathf.Lerp(volume_musica_1, 0.0f, Time.deltaTime * 3.0f));
            mixer.SetFloat("VolumeMusica2", Mathf.Lerp(volume_musica_2, -80.0f, Time.deltaTime * 3.0f));
            mixer.SetFloat("VolumeMusica3", Mathf.Lerp(volume_musica_3, -80.0f, Time.deltaTime * 3.0f));
        }
        if (number == 2) {
            mixer.SetFloat("VolumeMusica1", Mathf.Lerp(volume_musica_1, -80.0f, Time.deltaTime * 3.0f));
            mixer.SetFloat("VolumeMusica2", Mathf.Lerp(volume_musica_2, 0.0f, Time.deltaTime * 3.0f));
            mixer.SetFloat("VolumeMusica3", Mathf.Lerp(volume_musica_3, -80.0f, Time.deltaTime * 3.0f));
        }
        if (number == 3) {
            mixer.SetFloat("VolumeMusica1", Mathf.Lerp(volume_musica_1, -80.0f, Time.deltaTime * 3.0f));
            mixer.SetFloat("VolumeMusica2", Mathf.Lerp(volume_musica_2, -80.0f, Time.deltaTime * 3.0f));
            mixer.SetFloat("VolumeMusica3", Mathf.Lerp(volume_musica_3, 0.0f, Time.deltaTime * 3.0f));
        }
    }
}
