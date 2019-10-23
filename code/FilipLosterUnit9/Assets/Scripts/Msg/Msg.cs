using System;
using System.Collections;
using TinyMessenger;

public class Msg {
    public class BeginGameClicked : TinyMessenger.ITinyMessage {
        private static BeginGameClicked _Instance = null;
        
        #region Implementation
        public static BeginGameClicked Get() {
            if (_Instance == null)
                _Instance = new BeginGameClicked();

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

}