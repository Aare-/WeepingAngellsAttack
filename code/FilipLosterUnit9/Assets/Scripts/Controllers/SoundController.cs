using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : Singleton<SoundController> {

    [SerializeField] 
    protected GameSettings _Settings;
    
    public enum Sounds {
        SHOOT = 0,
    }

    [Serializable]
    public class ListWrapper {
        public List<AudioClip> Clips = new List<AudioClip>();
    }        
    
    [HideInInspector]
    public List<ListWrapper> _AudioClipses = new List<ListWrapper>();

    [HideInInspector]
    public List<float> _SourcesBaseVolumes = new List<float>();

    public AudioSource[] _AudioSources;

    protected void OnEnable() {
        TinyTokenManager
            .Instance
            .Register<Msg.PlaySound>(this, PlaySound);
    }

    protected void OnDisable() {
        TinyTokenManager
            .Instance
            .UnregisterAll(this);
    }

    private void PlaySound(Msg.PlaySound msg) {
        if (!_Settings.IsSoundEnabled) return;

        foreach(var audioSource in _AudioSources)
            if(!audioSource.isPlaying){                                                        
                
                audioSource.PlayOneShot(
                    _AudioClipses[(int)msg.Sound].Clips.Count == 0 ? 
                        null : 
                        _AudioClipses[(int)msg.Sound].Clips.GetRandom(), 
                    msg.Volume * _SourcesBaseVolumes[(int)msg.Sound]);
                break;
            }
    }
}
