using System.Collections;
using System.Collections.Generic;
using Systems.Managers;
using UnityEngine;
using Games.Shooting.Sushi;
using UniRx;
using System;

namespace Games.Shooting.Players{
    public class TakeItem : MonoBehaviour{
        private PlayerManager pm;
        private AudioSource audioSource;
        [SerializeField]private AudioClip eat; 

        private void Start(){
            pm = GetComponent<PlayerManager>();
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.CompareTag("Sushi")){
                var temp = other.gameObject.GetComponent<Sushi.Sushi>();
                var price = temp.Price;
                if (!temp.CanEat){
                    price = -price;
                    GameManager.Instance.NoMoneyCount++;
                }
                GameManager.Instance.SushiScores[temp.SushiType] += price;
                audioSource.PlayOneShot(eat);
                Destroy(other.gameObject);
                if (temp.SushiType == SushiType.Wasabi){
                    pm.IsAttack = pm.IsMove = false;
                    Observable.Timer(TimeSpan.FromSeconds(1))
                              .Subscribe(_ => { pm.IsAttack = pm.IsMove = true; }).AddTo(gameObject);
                }
                
            }
        }
    }
}