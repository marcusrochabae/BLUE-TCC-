using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour
{
    private Light m_Light;

    public float m_MinRange;
    public float m_MaxRange;
    public float m_TimeRate;

    public LightType m_Type;

    private float m_StartRange;

    private IEnumerator m_PulseCoroutine;

    private void Start()
    {
        m_Light = GetComponent<Light>();
        m_StartRange = m_Light.range;
    }

    private void Update()
    {
        Pulse();
    }

    public void Pulse()
    {
        if (m_PulseCoroutine == null)
        {
            m_PulseCoroutine = Lerp(m_StartRange, Random.Range(m_MinRange, m_MaxRange), Time.time);
            StartCoroutine(m_PulseCoroutine);
        }
        
    }

    private IEnumerator Lerp(float start, float end, float time)
    {
        float startTime = time;
        float timeRate = 0.0f;

        do
        {
            timeRate = Mathf.Clamp01((Time.time - startTime) / m_TimeRate);
            float range = Mathf.Lerp(start, end, timeRate);

            if (m_Type == LightType.Point)
                m_Light.range = range;
            else if (m_Type == LightType.Spot)
                m_Light.spotAngle = range;

            yield return null;

        } while (timeRate < 1.0f);

        m_StartRange = end;
        StopCoroutine(m_PulseCoroutine);
        m_PulseCoroutine = null;
    }
}
