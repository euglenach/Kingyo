namespace Games.Shooting.Bullets{
    public interface IAttack{
        bool IsEnd { get;}
        bool IsStart { get; }
        void StartAttack();
    }
}