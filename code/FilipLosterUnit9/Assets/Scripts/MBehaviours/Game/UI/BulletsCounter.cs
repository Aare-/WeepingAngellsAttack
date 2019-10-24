using TMPro;
using UnityEngine;


public class BulletsCounter : MonoBehaviour {
    [SerializeField] 
    protected GameSessionSettings _Settings;
    
    [SerializeField] 
    protected TextMeshProUGUI _Counter;

    [SerializeField] 
    protected Color _GunLoadedColor;
    
    [SerializeField] 
    protected Color _GunUnloadedLoadedColor;
    
    protected void Update() {
        _Counter.gameObject.SetActive(_Settings.CurrentState != GameSessionSettings.GAME_STATE.NONE);
        
        _Counter.text = $"BULLETS: {_Settings.BulletsRemaining.ToString()}";
        _Counter.color = _Settings.BulletsRemaining > 0 ? _GunLoadedColor : _GunUnloadedLoadedColor;

    }
}
