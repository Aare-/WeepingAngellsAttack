using UnityEditor;
using UnityEngine;

public class GameController : Singleton<GameController> {
    [SerializeField] 
    protected GameObject _Root;

    [Header("Prefabs"),
     SerializeField] 
    protected GameObject _MainMenu;
    
    [SerializeField] 
    protected GameObject _GameLevel;

    #region Lifecycle
    protected void OnEnable() {
        TinyTokenManager
            .Instance
            .Register<Msg.GoToGame>(this, BeginNewGame);
        TinyTokenManager
            .Instance
            .Register<Msg.GoToMainMenu>(this, m => DisplayMenu());
        
        DisplayMenu();
    }

    protected void OnDisable() {
        TinyTokenManager
            .Instance
            .UnregisterAll(this);
    }
    #endregion

    #region Game States
    private void BeginNewGame(Msg.GoToGame m) {
        CleanUpScene();
        Instantiate(
            _GameLevel,
            _Root.transform,
            false);
    }

    private void DisplayMenu() {
        CleanUpScene();
        
        Instantiate(
            _MainMenu, 
            _Root.transform, 
            false);
    }
    #endregion

    private void CleanUpScene() {
        _Root.RemoveAllChildren();
    }
}
