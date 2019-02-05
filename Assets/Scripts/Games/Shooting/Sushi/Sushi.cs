using System.Collections;
using System.Collections.Generic;
using Games.Shooting.Sushi;
using UnityEngine;
namespace Games.Shooting.Sushi{
    public class Sushi : MonoBehaviour{
        public SushiType SushiType;
        public int Price;
        public bool CanEat;
        private AudioSource audioSource;
        [SerializeField] private AudioClip attack;
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
            audioSource = GetComponent<AudioSource>();
        }

        public void Move(Vector2 position,Vector2 direction, float speed){
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = direction * speed;
        }

        private void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.CompareTag("Coin")){
                CanEat = true;
                audioSource.PlayOneShot(attack);
                var child = transform.GetChild(0).gameObject;
                child.SetActive(true);
                Destroy(other.gameObject);
            }
        }
    }
}