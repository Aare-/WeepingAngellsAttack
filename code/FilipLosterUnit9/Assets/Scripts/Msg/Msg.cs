using System;
using System.Collections;
using TinyMessenger;

public class Msg {
    #region Screen Navigation
    public class ShowScreenWorker : TinyMessenger.ITinyMessage {
        private static ShowScreenWorker _Instance = null;

        public Type ControllerClass;
        public bool Animated;
        public float RemainingAnimationTime;
        public object[] ExtraValues;

        #region Implementation
        public static ShowScreenWorker Get(Type controllerClass, bool animated, float remainingAnimTime, object[] extra) {
            if (_Instance == null)
                _Instance = new ShowScreenWorker();

            _Instance.ControllerClass = controllerClass;
            _Instance.Animated = animated;
            _Instance.RemainingAnimationTime = remainingAnimTime;
            _Instance.ExtraValues = extra;

            return _Instance;
        }

        public object Sender {
            get { return null; }
        }
        #endregion        
    }

    public class HideScreen : TinyMessenger.ITinyMessage {
        private static HideScreen _Instance = null;

        public Type ControllerClass;
        public bool Animated;
        public Action<float> FinishedHideAnimation;

        #region Implementation
        public static HideScreen Get(
                Type controllerClass, 
                bool animated, 
                Action<float> finishedHideAnimation = null) {
            if (_Instance == null)
                _Instance = new HideScreen();

            _Instance.ControllerClass = controllerClass;
            _Instance.Animated = animated;
            _Instance.FinishedHideAnimation = finishedHideAnimation;

            return _Instance;
        }

        public object Sender {
            get { return null; }
        }
        #endregion
    }        
    #endregion
    
    public class PlaySound : TinyMessenger.ITinyMessage {
        private static PlaySound _Instance = null;

        public SoundController.Sounds Sound;
        public float Volume;

        #region Implementation
        public static PlaySound Get(
            SoundController.Sounds sound,
            float volume = 1.0f) {
            if (_Instance == null)
                _Instance = new PlaySound();

            _Instance.Sound = sound;
            _Instance.Volume = volume;

            return _Instance;
        }

        public object Sender {
            get { return null; }
        }
        #endregion
    }
}