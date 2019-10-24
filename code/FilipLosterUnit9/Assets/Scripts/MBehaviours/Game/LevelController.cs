
using System;
using TinyMessenger;
using UnityEngine;

public class LevelController : MonoBehaviour {
    [SerializeField] 
    protected GameSessionSettings _GameSession;

    protected void Start() {
        _GameSession.GameLevel = 0;
        InitNextLevel();
    }

    protected void OnEnable() {
        TinyTokenManager
            .Instance
            .Register(this, (Msg.WeepingAngelKilled m) => {
                if (_GameSession.WeepingAngelsRemaining == 0)
                    InitNextLevel();
            });
        TinyTokenManager
            .Instance
            .Register(this, (Msg.AngelsWon m) => {
                //TODO: display endgame screen
                TinyMessengerHub
                    .Instance
                    .Publish(Msg.GoToMainMenu.Get());
            });
    }

    protected void OnDisable() {
        TinyTokenManager
            .Instance
            .UnregisterAll(this);
    }

    private void InitNextLevel() {
        _GameSession.InitLevel(_GameSession.GameLevel + 1);
        
        TinyMessengerHub
            .Instance
            .Publish(Msg.SpawnAngels.Get());
    }
}
