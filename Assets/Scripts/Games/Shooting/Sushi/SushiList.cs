using System;
using System.Collections;
using System.Collections.Generic;
using Systems.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Games.Shooting.Sushi{
    public class SushiList : SingletonMonoBehaviour<SushiList>{
        public GameObject[] Neta;

        public GameObject GetRandomNeta(){
            return Neta[Random.Range(0, Enum.GetValues(typeof(SushiType)).Length)];
        }

        public SushiType GetRandomType(){
            var i = Random.Range(0, Enum.GetValues(typeof(SushiType)).Length);
            return (SushiType) Enum.ToObject(typeof(SushiType), i);
        }
    }
}