
using System;
using System.Collections.Generic;
using System.Linq;
using TinyMessenger;
using UnityEngine;

public class Thunder : MonoBehaviour {

    private static string LIGHTNING = "_Lightning";
    
    [SerializeField] 
    protected Material _SkyMesh;

    public float LightningValue {
        get { return _SkyMesh.GetFloat(LIGHTNING); }
        set {
            _SkyMesh.SetFloat(LIGHTNING, value);
        }
    }

    private float _Ligthing;

    protected void OnEnable() {
        TinyTokenManager
            .Instance
            .Register(this, (Msg.PlaySound m) => {
                if (m.Sound == SoundController.Sounds.THUNDER) {
                    _Ligthing = 1.0f;
                }
            });
    }

    protected void OnDisable() {
        TinyTokenManager
            .Instance
            .UnregisterAll(this);
    }

    protected void Update() {
        if (_Ligthing > 0.0f) {
            _Ligthing -= Time.deltaTime / 0.5f;
            _Ligthing = Mathf.Clamp01(_Ligthing);
            
            LightningValue = Mathf.Lerp(0.0f, 1.0f, _Ligthing);
        }
    }
}
