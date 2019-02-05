﻿using System.Collections;
using System.Collections.Generic;
using Games.Shooting.Sushi;
using UnityEngine;
namespace Games.Shooting.Sushi{
    public class Sushi : MonoBehaviour{
        public SushiType SushiType;
        public int Price;
        public bool CanEat;
        private Rigidbody2D rb;
        private Camera mainCamera;
        Rect rect = new Rect(-0.1f, -0.1f, 1.2f, 1.2f);

        private void Break(){
            
        }

        private void Update(){
            var v = mainCamera.WorldToViewportPoint(transform.position);
            if (!rect.Contains(v)){
                Destroy(gameObject);
            }
        }

        private void Start(){
            mainCamera = Camera.main;
        }

        public void Move(Vector2 position,Vector2 direction, float speed){
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = direction * speed;
        }
    }
}