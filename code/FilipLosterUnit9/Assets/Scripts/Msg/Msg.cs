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

}