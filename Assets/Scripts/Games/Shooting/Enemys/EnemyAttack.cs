using UnityEngine;
using Games.Shooting.Bullets;

namespace Games.Shooting.Enemys{
    public class EnemyAttack : MonoBehaviour{
        [SerializeField] private IAttack[] waves;
        private int index = 0;

        private void FixedUpdate(){
            if (!waves[index].IsEnd && !waves[index].IsStart) return;
            waves[index].StartAttack();
            if (waves[index].IsEnd){
                index++;
            }
        }
    }
}
