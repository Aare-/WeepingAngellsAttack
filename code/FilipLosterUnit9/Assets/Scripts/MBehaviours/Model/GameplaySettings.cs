
using UnityEngine;

[CreateAssetMenu(fileName = "Root", menuName = "FL/Create Gameplay Settings")]
public class GameplaySettings : ScriptableObject {

    [Header("Angels Config")]
    public float AngelsWinRadius;
    
    public Vector2 AngelsSpawnRadiusMinMax;
    
    public Vector2 MovementDelayMinMax;

    public AnimationCurve AngelsMovementVelocity;
    
    [Header("Difficulty Config")]
    public AnimationCurve WeepingAngelsSpawnCount;
    
    public AnimationCurve BaseAngelsSpawnCount;
}
