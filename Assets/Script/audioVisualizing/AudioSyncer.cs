using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent class responsible for extracting beats from..
/// ..spectrum value given by AudioSpectrum.cs
/// </summary>
public class AudioSyncer : MonoBehaviour {
    public float bias;
    public float timeStep;
    public float timeToBeat;
    public float restSmoothTime;

    private float m_previousAudioValue;
    private float m_audioValue;
    private float m_timer;

    protected bool m_isBeat;
    public virtual void OnBeat()
    {
        m_timer = 0;
        m_isBeat = true;
    }
    public void Start()
    {
        bias *= (float)PlayerPrefs.GetInt("__volume") / 100f;
    }

    public virtual void OnUpdate()
    {
        // update audio value
        m_previousAudioValue = m_audioValue;
        m_audioValue = AudioSpectrum.spectrumValue;

        if (m_previousAudioValue > bias &&
            m_audioValue <= bias)
        {
            if (m_timer > timeStep)
                OnBeat();
        }

        if (m_previousAudioValue <= bias &&
            m_audioValue > bias)
        {
            if (m_timer > timeStep)
                OnBeat();
        }

        m_timer += Time.deltaTime;
    }

    private void Update()
    {
        OnUpdate();
    }
}
