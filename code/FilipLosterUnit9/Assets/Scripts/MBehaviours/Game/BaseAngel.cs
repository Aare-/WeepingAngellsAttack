
using System;
using TinyMessenger;
using UnityEngine;

public class BaseAngel : MonoBehaviour {
    
    [SerializeField] 
    protected GameSessionSettings _Settings;

    protected virtual void OnEnable() {
        #region Register to messages
        TinyTokenManager
            .Instance
            .Register(this, (Msg.CleanAngels m) => {
                DestroyImmediate(this.gameObject);
            });
        
        TinyTokenManager
            .Instance
            .Register(this, (Msg.AngelsWon m) => {
                if (this == null) return;
                this.enabled = false;
            });
        #endregion
        
        var spawnRadius = _Settings.NewAngelSpawnRadius();
        var spawnPosition =
            _Settings.AngelsAttackPosition +
            (Vector2.one * spawnRadius).Rotate(UnityEngine.Random.Range(0, 360));
        
        transform.position = spawnPosition.ToMapPos();
        
        var rotation = new Quaternion();
        rotation.SetLookRotation(_Settings.AngelsAttackPosition.ToMapPos() - transform.position, Vector3.up);
        transform.localRotation = rotation;
    }

    protected void OnDisable() {
        TinyTokenManager
            .Instance
            .UnregisterAll(this);
    }

    public virtual void OnBeingShoot() {
        DestroyAngel();
        
        _Settings.BulletsRemaining--;

        if (_Settings.BulletsRemaining < _Settings.WeepingAngelsRemaining) {
            TinyMessengerHub
                .Instance
                .Publish(Msg.AngelsWon.Get());
        }
    }

    protected void DestroyAngel() {
        Destroy(this.gameObject);
    }
}
