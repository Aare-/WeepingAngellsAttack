using TinyMessenger;
using UnityEngine;

public class BeginGameButton : MonoBehaviour {
    public void BeginGameButtonHandler() {
        TinyMessengerHub
            .Instance
            .Publish(Msg.GoToGame.Get());
    }
}
