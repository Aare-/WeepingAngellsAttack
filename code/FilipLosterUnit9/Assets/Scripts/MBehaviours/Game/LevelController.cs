
using System;
using System.Collections;
using System.Collections.Generic;
using TinyMessenger;
using UnityEngine;

public class LevelController : MonoBehaviour {
    enum GAME_STATE {
        NONE,
        IN_PROGRESS,
        DEFEAT,
        VICTORY,
        NEW_LEVEL
    }
    
    [SerializeField] 
    protected GameSessionSettings _GameSession;

    private GAME_STATE _CurrentState;

        
    protected void Start() {
        _CurrentState = GAME_STATE.NONE;
        
        _GameSession.GameLevel = 0;
        StartCoroutine(InitNextLevel());
    }

    protected void OnEnable() {
        TinyTokenManager
            .Instance
            .Register(this, (Msg.WeepingAngelKilled m) => {
                StartCoroutine(AdvanceToNextLevel());
            });
        TinyTokenManager
            .Instance
            .Register(this, (Msg.AngelsWon m) => { StartCoroutine(AngelsWon()); });
    }

    protected void OnDisable() {
        TinyTokenManager
            .Instance
            .UnregisterAll(this);
    }

    private IEnumerator InitNextLevel() {
        _CurrentState = GAME_STATE.NEW_LEVEL;
        
        _GameSession.InitLevel(_GameSession.GameLevel + 1);
        
        TinyMessengerHub
            .Instance
            .Publish(Msg.PlaySound.Get(SoundController.Sounds.THUNDER));
        
        yield return new WaitForSeconds(0.5f);
        
        TinyMessengerHub
            .Instance
            .Publish(Msg.SpawnAngels.Get());                
        
        _CurrentState = GAME_STATE.IN_PROGRESS;
    }

    private IEnumerator AngelsWon() {
        if (_CurrentState != GAME_STATE.IN_PROGRESS) 
            yield break;

        _CurrentState = GAME_STATE.DEFEAT;
                
        TinyMessengerHub
            .Instance
            .Publish(Msg.PlaySound.Get(SoundController.Sounds.ANGELS_WON));
                
        yield return new WaitForSeconds(2.0f);
        
        //TODO: display endgame screen
        TinyMessengerHub
            .Instance
            .Publish(Msg.GoToMainMenu.Get());
    }

    private IEnumerator AdvanceToNextLevel() {
        if (_CurrentState != GAME_STATE.IN_PROGRESS) yield break;
        if (_GameSession.WeepingAngelsRemaining > 0) yield break;
            
        _CurrentState = GAME_STATE.VICTORY;
        
        yield return new WaitForSeconds(0.5f);
        
        TinyMessengerHub
            .Instance
            .Publish(Msg.PlaySound.Get(SoundController.Sounds.BELL));
        
        yield return new WaitForSeconds(1.0f);
        
        StartCoroutine(InitNextLevel());
    }
}
