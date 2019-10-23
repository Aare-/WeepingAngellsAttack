
using UnityEngine;

[CreateAssetMenu(fileName = "Root", menuName = "FL/Create Gameplay Settings")]
public class GameplaySettings : ScriptableObject {

    public AnimationCurve GameDifficultyCurve;

    [Header("Angels Config")]
    public float AngelsWinRadius;
    
    public Vector2 AngelsSpawnRadiusMinMax;

    public Vector2 AngelsMovementVelocityMinMax;
}
