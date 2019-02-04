using System;
using UnityEditor;
using System.Threading;
using System.Threading.Tasks;
using UniRx.Async;

namespace Games.Shooting.Bullets{
    public interface IAttack{
        bool IsEnd { get;}
        bool IsStart { get; }
        void StartAttack();
    }
}