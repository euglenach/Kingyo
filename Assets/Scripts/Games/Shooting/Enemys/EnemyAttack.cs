using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using Games.Shooting.Bullets;
using UniRx;

namespace Games.Shooting.Enemys{
    public class EnemyAttack : MonoBehaviour{
        [SerializeField] private BaseAttack[] waves;
        private int currentIndex = 0;

//        private void FixedUpdate(){
//            if (currentIndex  == waves.Length) return;
//            var i = currentIndex == 0 ? 0 : currentIndex - 1;
//            Debug.Log(i);
//            if (waves[i].IsEnd || i == 0){
//                waves[currentIndex].StartAttack();
//                if (waves[currentIndex].IsEnd){
//                    if (currentIndex + 1 < waves.Length){
//                        currentIndex++;
//                    }
//                }
//            }
//            
//        }

        void GoNext(){

            if (waves.Length > currentIndex + 1){
                currentIndex++;
                waves[currentIndex].StartAttack();
            }
        }
        
        void Start(){
            

            foreach (var item in waves){
                item.EndWave.Subscribe(_ => {
                    GoNext();
                });
            }
            waves[0].StartAttack();
//            waves[currentIndex]
//                .ObserveEveryValueChanged(x => x.IsEnd)
//                .Where(x => x)
//                .Subscribe(_ => Debug.Log("fff"));
        }
    }
}
