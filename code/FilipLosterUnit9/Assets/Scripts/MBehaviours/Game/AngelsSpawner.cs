using System;
using System.Collections.Generic;
using TinyMessenger;
using UnityEngine;

public class AngelsSpawner : MonoBehaviour {

    [Header("Config")] 
    [SerializeField] 
    protected GameSessionSettings _Session;
    
    [Header("Prefabs")]
    [SerializeField] 
    protected List<GameObject> _WeepingAngelPrefabs;
    
    [SerializeField] 
    protected List<GameObject> _BaseAngelPrefabs;

    protected void OnEnable() {
        TinyTokenManager
            .Instance
            .Register(this, (Msg.SpawnAngels m) => {
                SpawnNewAngelBatch();
            });
    }

    protected void OnDisable() {
        TinyTokenManager
            .Instance
            .UnregisterAll(this);
    }

    [ContextMenu("Spawn Angels")]
    public void SpawnNewAngelBatch() {
        TinyMessengerHub
            .Instance
            .Publish(Msg.CleanAngels.Get());
        
        var weepingAngelsCount = _Session.NumberOfWeepingAngels;
        var regularAngelsCount = _Session.NumberOfRegularAngels;

        while (weepingAngelsCount-- > 0)
            Instantiate(_WeepingAngelPrefabs.GetRandom(), transform, false);

        while (regularAngelsCount-- > 0)
            Instantiate(_BaseAngelPrefabs.GetRandom(), transform, false);
    }
}
