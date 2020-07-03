using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameManager{


    public class Main
    {
        private static Main _instance;
        private Main(){

        }
        public static Main GameManager{
            get {if(_instance == null)
            {
                _instance = new Main();
            }
            return _instance;
            }
        }

        public void testeMethod(){
        }
    }
}

