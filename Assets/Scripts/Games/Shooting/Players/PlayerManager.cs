using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Games.Shooting.Players{
	public class PlayerManager : MonoBehaviour{
		public bool IsMove { get; set; } = true;
		public bool IsAttack { get; set; } = true;
	}
}