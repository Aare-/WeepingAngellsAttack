
using System;
using System.Collections;
using System.Collections.Generic;
using TinyMessenger;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField] 
    protected GameSessionSettings _GameSession;


    protected void Start() {
        _GameSession.CurrentState = GameSessionSettings.GAME_STATE.NONE;

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
        
        _GameSession.CurrentState = GameSessionSettings.GAME_STATE.NONE;
    }

    private IEnumerator InitNextLevel() {
        _GameSession.CurrentState = GameSessionSettings.GAME_STATE.NEW_LEVEL;

        _GameSession.InitLevel(_GameSession.GameLevel + 1);
        
        TinyMessengerHub
            .Instance
            .Publish(Msg.PlaySound.Get(SoundController.Sounds.THUNDER));
        
        TinyMessengerHub
            .Instance
            .Publish(Msg.SpawnAngels.Get());
        
        yield return new WaitForSeconds(0.5f);
        
        
        _GameSession.CurrentState = GameSessionSettings.GAME_STATE.GAME_IN_PROGRESS;
    }

    private IEnumerator AngelsWon() {
        if (_GameSession.CurrentState != GameSessionSettings.GAME_STATE.GAME_IN_PROGRESS) 
            yield break;

        _GameSession.CurrentState = GameSessionSettings.GAME_STATE.DEFEAT;

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
        if (_GameSession.CurrentState != GameSessionSettings.GAME_STATE.GAME_IN_PROGRESS) yield break;
        if (_GameSession.WeepingAngelsRemaining > 0) yield break;
            
        _GameSession.CurrentState = GameSessionSettings.GAME_STATE.VICTORY;

        yield return new WaitForSeconds(0.5f);
        
        TinyMessengerHub
            .Instance
            .Publish(Msg.PlaySound.Get(SoundController.Sounds.BELL));
        
        yield return new WaitForSeconds(1.0f);
        
        StartCoroutine(InitNextLevel());
    }
}
