using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace Games.Shooting.Bullets{
	public abstract class BaseAttack : MonoBehaviour{
		public bool IsEnd { get; protected set; }
		public bool IsStart { get; protected set; }
		protected Subject<Unit> end = new Subject<Unit>();
		public IObservable<Unit> EndWave => end;
		public abstract void StartAttack();
	}
}