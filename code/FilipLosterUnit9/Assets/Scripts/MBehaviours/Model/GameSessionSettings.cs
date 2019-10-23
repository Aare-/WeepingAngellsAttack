
using UnityEngine;

[CreateAssetMenu(fileName = "Root", menuName = "FL/Create Game Session Settings")]
public class GameSessionSettings : ScriptableObject {
    [Header("Config")]
    [SerializeField] 
    protected GameplaySettings _GameplaySettings;

    [Header("Game Parameters")]
    public float GameTime;
    
    public Vector2 AngelsAttackPosition;
    
    public float GameDifficulty => Mathf.Clamp01(_GameplaySettings.GameDifficultyCurve.Evaluate(GameTime));

    public GameplaySettings GameplaySettings => _GameplaySettings;

    public void InitGameSession() {
        GameTime = 0.0f;
    }
    
    public float NewAngelSpawnRadius() {
        return UnityEngine.Random.Range(
            _GameplaySettings.AngelsSpawnRadiusMinMax.x,
            _GameplaySettings.AngelsSpawnRadiusMinMax.y);
    }
    
    public float NewAngelMovementSpeed() {
        return UnityEngine.Random.Range(
            _GameplaySettings.AngelsMovementVelocityMinMax.x,
            _GameplaySettings.AngelsMovementVelocityMinMax.y);
    }
}
