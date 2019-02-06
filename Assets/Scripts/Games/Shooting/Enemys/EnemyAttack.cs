using System.Linq;
using System.Runtime.InteropServices;
using Systems.Managers;
using UnityEngine;
using Games.Shooting.Bullets;
using UniRx;
using Games.Shooting.Systems.Managers;

namespace Games.Shooting.Enemys{
    public class EnemyAttack : MonoBehaviour{
        [SerializeField] private BaseAttack[] waves;
        [SerializeField] private ShootingGameManager sgm;
        private bool endWave;
        private int currentIndex = 0;

        void GoNext(){

            if (waves.Length > currentIndex + 1){
                currentIndex++;
                waves[currentIndex].StartAttack();
            }
            else{
                endWave = true;
            }
        }
        
        void Shot(){         
            foreach (var item in waves){
                item.EndWave.Subscribe(_ => {
                    GoNext();
                });
            }
            waves[0].StartAttack();
        }

        private void Start(){
            Observable.Timer(System.TimeSpan.FromSeconds(2))
                      .Subscribe(_ => Shot());
            
            this
                .ObserveEveryValueChanged(x => endWave)
                .First(n => n || GameManager.Instance.CoinCount - GameManager.Instance.UseCoin < 1)
                .Subscribe(_ => sgm.EndGame());
        }
    }
}
