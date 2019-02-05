using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Games.Shooting.Sushi;
using UnityEngine;

namespace Games.Shooting.Bullets{
    public class GenerateBullet : MonoBehaviour{

        public static void Generate(SushiType sushiType,Vector2 position,Vector2 direction, float speed){     
            var temp = SushiList.Instance.Neta[(int) sushiType];
            var sushi = Instantiate(temp, position, Quaternion.identity);
            sushi.GetComponent<Sushi.Sushi>().Move(position,direction,speed);
        }
    }
}