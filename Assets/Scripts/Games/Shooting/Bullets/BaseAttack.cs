using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Shooting.Bullets{
	public abstract class BaseAttack : MonoBehaviour{
		public bool IsEnd { get; protected set; }
		public bool IsStart { get; protected set; }
		public abstract void StartAttack();
	}
}