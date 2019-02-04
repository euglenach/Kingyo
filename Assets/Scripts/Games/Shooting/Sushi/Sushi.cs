using System.Collections;
using System.Collections.Generic;
using Games.Shooting.Sushi;
using UnityEditor;
using UnityEngine;
namespace Games.Shooting.Sushi{
    public class Sushi : MonoBehaviour{
        [SerializeField] private SushiType sushiType;
        [SerializeField] private int price;
        public bool CanEat { get; private set; }

        private void Break(){

        }
    }
}