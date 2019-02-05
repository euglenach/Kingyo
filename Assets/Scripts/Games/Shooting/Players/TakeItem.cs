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

        private void Start(){
            pm = GetComponent<PlayerManager>();
        }
        
        private void OnCollisionEnter(Collision other){
            if (other.gameObject.CompareTag("Sushi")){
                var temp = other.gameObject.GetComponent<Sushi.Sushi>();
                var price = temp.CanEat ? temp.Price : -temp.Price;
                GameManager.Instance.SushiScores[temp.SushiType] += price;

                if (temp.SushiType == SushiType.Wasabi){
                    pm.IsAttack = pm.IsMove = false;
                    Observable.Timer(TimeSpan.FromSeconds(1))
                              .Subscribe(_ => { pm.IsAttack = pm.IsMove = true; }).AddTo(gameObject);
                }
            }
        }
    }
}