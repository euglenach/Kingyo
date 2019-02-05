using System.Collections;
using System.Collections.Generic;
using Games.Shooting.Sushi;
using UnityEngine;
namespace Games.Shooting.Sushi{
    public class Sushi : MonoBehaviour{
        public SushiType SushiType;
        public int Price;
        public bool CanEat;
        private Rigidbody2D rb;

        private void Break(){

        }
        
        public void Move(Vector2 position,Vector2 direction, float speed){
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = direction * speed;
        }
    }
}