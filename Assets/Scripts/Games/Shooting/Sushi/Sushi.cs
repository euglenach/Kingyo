using System.Collections;
using System.Collections.Generic;
using Games.Shooting.Sushi;
using UnityEngine;
namespace Games.Shooting.Sushi{
    public class Sushi : MonoBehaviour{
        public SushiType SushiType { get; set; }
        public int Price{get; set; }
        public bool CanEat { get; private set; }

        private void Break(){

        }
    }
}