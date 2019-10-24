
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Root", menuName = "FL/Create Game Session Settings")]
public class GameSessionSettings : ScriptableObject {
    [Header("Config")]
    [SerializeField] 
    protected GameplaySettings _GameplaySettings;

    [Header("Game Parameters")]
    public int GameLevel;

    public int BulletsRemaining;

    public int WeepingAngelsRemaining;
    
    public Vector2 AngelsAttackPosition;

    public GameplaySettings GameplaySettings => _GameplaySettings;

    public int NumberOfWeepingAngels =>
        Math.Max(0, Mathf.RoundToInt(GameplaySettings.WeepingAngelsSpawnCount.Evaluate(GameLevel)));

    public int NumberOfRegularAngels => 
        Math.Max(0, Mathf.RoundToInt(GameplaySettings.BaseAngelsSpawnCount.Evaluate(GameLevel)));

    protected int NumberOfBulletsInLevel => 
        Math.Max(0, Mathf.RoundToInt(GameplaySettings.WeepingAngelsSpawnCount.Evaluate(GameLevel)));
    
    public void InitLevel(int level) {
        GameLevel = level;
        BulletsRemaining = NumberOfBulletsInLevel;
        WeepingAngelsRemaining = NumberOfWeepingAngels;
    }
    
    public float NewAngelSpawnRadius() {
        return UnityEngine.Random.Range(
            _GameplaySettings.AngelsSpawnRadiusMinMax.x,
            _GameplaySettings.AngelsSpawnRadiusMinMax.y);
    }

    public float NewAngelMovmentDelay() {
        return UnityEngine.Random.Range(
            _GameplaySettings.MovementDelayMinMax.x,
            _GameplaySettings.MovementDelayMinMax.y);
    }
    
    public float GetAngelVelocity(float distanceToTarget) {
        return _GameplaySettings.AngelsMovementVelocity.Evaluate(distanceToTarget);
    }
}
