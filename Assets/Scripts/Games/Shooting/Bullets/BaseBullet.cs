using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.Managers;

namespace Games.Shooting.Bullets{
    public abstract class BaseBullet : MonoBehaviour{
        protected float speed;
        protected Vector2 direction;
        private Rigidbody2D rb;
        
        public void Init(Vector2 dir,float speed){
            direction = dir;
            this.speed = speed;
        }
        
        protected virtual void Start(){
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = direction * speed;
        }
    }
}