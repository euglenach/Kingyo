using System.Collections;
using System.Collections.Generic;
using Systems.Managers;
using UnityEngine;
using Games.Shooting.Sushi;
using UniRx;
using System;
using UIs;

namespace Games.Shooting.Players{
    public class TakeItem : MonoBehaviour{
        private PlayerManager pm;
        private AudioSource audioSource;
        [SerializeField]private AudioClip eat;
        [SerializeField] private ChangeFace playercf;
        [SerializeField] private ChangeFace itamaecf;

        private void Start(){
            pm = GetComponent<PlayerManager>();
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.CompareTag("Sushi")){
                var temp = other.gameObject.GetComponent<Sushi.Sushi>();
                var price = temp.Price;
                if (!temp.CanEat){
                    itamaecf.Change(1);
                    playercf.Change(1);
                    price = -price;
                    GameManager.Instance.NoMoneyCount++;
                }
                else{
                    playercf.Change(2);
                    itamaecf.Change(2);
                }
                GameManager.Instance.SushiScores[temp.SushiType] += price;
                audioSource.PlayOneShot(eat);
                Destroy(other.gameObject);
                if (temp.SushiType == SushiType.Wasabi){
                    pm.IsAttack = pm.IsMove = false;
                    playercf.Change(1);
                    Observable.Timer(TimeSpan.FromSeconds(1))
                              .Subscribe(_ => { pm.IsAttack = pm.IsMove = true; }).AddTo(gameObject);
                }
                
            }
        }
    }
}