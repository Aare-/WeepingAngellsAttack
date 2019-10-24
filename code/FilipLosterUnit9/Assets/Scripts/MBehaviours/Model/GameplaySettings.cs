
using UnityEngine;

[CreateAssetMenu(fileName = "Root", menuName = "FL/Create Gameplay Settings")]
public class GameplaySettings : ScriptableObject {

    [Header("Angels Config")]
    public float AngelsWinRadius;
    
    public Vector2 AngelsSpawnRadiusMinMax;
    
    public Vector2 MovementDelayMinMax;

    public AnimationCurve AngelsMovementVelocity;

    public float AttackVelocityWhenWithoutBullet;
    
    [Header("Difficulty Config")]
    public AnimationCurve WeepingAngelsSpawnCount;
    
    public AnimationCurve BulletsPerLevelCount;
    
    public AnimationCurve BaseAngelsSpawnCount;
}
