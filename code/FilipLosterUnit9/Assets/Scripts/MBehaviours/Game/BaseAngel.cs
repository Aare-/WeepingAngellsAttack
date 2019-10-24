
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

    public void OnBeingShoot() {
        if (_Settings.CurrentState != GameSessionSettings.GAME_STATE.GAME_IN_PROGRESS) return;
        if (_Settings.BulletsRemaining <= 0) {
            TinyMessengerHub
                .Instance
                .Publish(Msg.PlaySound.Get(SoundController.Sounds.EMPTY_GUN));
            
            return;
        }
        
        TinyMessengerHub
            .Instance
            .Publish(Msg.PlaySound.Get(SoundController.Sounds.GUNSHOOT));

        _Settings.BulletsRemaining--;
        AngelShot();
    }

    protected virtual void AngelShot() {
        DestroyAngel();
    }

    protected void DestroyAngel() {
        Destroy(this.gameObject);
    }
}
