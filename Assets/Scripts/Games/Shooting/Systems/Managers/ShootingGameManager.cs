using System.Collections;
using System.Collections.Generic;
using Systems.Managers;
using UnityEditor;
using UniRx;
using System;
using UnityEngine;

namespace Games.Shooting.Systems.Managers{
    public class ShootingGameManager : MonoBehaviour{
        public bool IsEnd { get; private set; }
        [SerializeField] private GameObject shootingObjects;
        [SerializeField] private GameObject lane;
        private Rigidbody2D rb;
        private const float moveSpeed = 10f;
        
        public IEnumerator Transition(){
            GameManager.Instance.NowGame = GameState.Shooting;
            BGMManager.Instance.StartMusic();
            shootingObjects.SetActive(true);
            rb = lane.GetComponent<Rigidbody2D>();

            var dis = Vector2.Distance(Vector2.zero, lane.transform.position);

            var time = dis / moveSpeed;
            
            rb.velocity = Vector2.left * moveSpeed;
            
            yield return new WaitForSeconds(time);
            rb.velocity = Vector2.zero;
            lane.transform.localPosition = Vector2.zero;
        }

        public void EndGame(){
            Observable.Timer(TimeSpan.FromSeconds(3))
                      .Subscribe(_ => FadeManager.Instance.LoadScene(Scene.Result, 4f))
                      .AddTo(gameObject);

        }
    }
}