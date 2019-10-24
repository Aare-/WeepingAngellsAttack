
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Root", menuName = "FL/Create Game Settings")]
public class GameSettings : ScriptableObject {
    [SerializeField]
    public bool IsSoundEnabled {
        get => _IsSoundEnabled;
        set => _IsSoundEnabled = value;
    }

    [SerializeField]
    protected bool _IsSoundEnabled;
}
