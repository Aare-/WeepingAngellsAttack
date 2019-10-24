using System;
using System.Collections;
using TinyMessenger;

public class Msg {
    public class GoToGame : TinyMessenger.ITinyMessage {
        private static GoToGame _Instance = null;
        
        #region Implementation
        public static GoToGame Get() {
            if (_Instance == null)
                _Instance = new GoToGame();

            return _Instance;
        }

        public object Sender {
            get { return null; }
        }
        #endregion        
    }
    
    public class GoToMainMenu : TinyMessenger.ITinyMessage {
        private static GoToMainMenu _Instance = null;
        
        #region Implementation
        public static GoToMainMenu Get() {
            if (_Instance == null)
                _Instance = new GoToMainMenu();

            return _Instance;
        }

        public object Sender {
            get { return null; }
        }
        #endregion        
    }
    
    public class SpawnAngels : TinyMessenger.ITinyMessage {
        private static SpawnAngels _Instance = null;
        
        #region Implementation
        public static SpawnAngels Get() {
            if (_Instance == null)
                _Instance = new SpawnAngels();

            return _Instance;
        }

        public object Sender {
            get { return null; }
        }
        #endregion        
    }
    
    public class CleanAngels : TinyMessenger.ITinyMessage {
        private static CleanAngels _Instance = null;
        
        #region Implementation
        public static CleanAngels Get() {
            if (_Instance == null)
                _Instance = new CleanAngels();

            return _Instance;
        }

        public object Sender {
            get { return null; }
        }
        #endregion        
    }
    
    public class AngelsWon : TinyMessenger.ITinyMessage {
        private static AngelsWon _Instance = null;
        
        #region Implementation
        public static AngelsWon Get() {
            if (_Instance == null)
                _Instance = new AngelsWon();

            return _Instance;
        }

        public object Sender {
            get { return null; }
        }
        #endregion        
    }
    
    public class WeepingAngelKilled : TinyMessenger.ITinyMessage {
        private static WeepingAngelKilled _Instance = null;

        #region Implementation
        public static WeepingAngelKilled Get() {
            if (_Instance == null)
                _Instance = new WeepingAngelKilled();

            return _Instance;
        }

        public object Sender {
            get { return null; }
        }
        #endregion        
    }
    
    public class PlaySound : ITinyMessage {
        private static PlaySound _Instance;

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