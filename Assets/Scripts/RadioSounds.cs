using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RadioSounds : MonoBehaviour
{
    public AudioMixer radioDialMixer;
    public AudioMixerSnapshot snapshotVoicesEnabled;
    public AudioMixerSnapshot snapshotVoicesDisabled;

    public float transitionTime = 1f;

    public void ToggleVoiceSample(bool toggle)
    {
        if (toggle)
        {
            snapshotVoicesEnabled.TransitionTo(transitionTime);
        }
        else
        {
            snapshotVoicesDisabled.TransitionTo(transitionTime);
        }
    }
}
