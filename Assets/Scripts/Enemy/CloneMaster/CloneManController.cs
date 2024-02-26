using Assets.Scripts.Enemy.CloneMaster;
using StatePattern.Enemy;
using StatePattern.StateMachine;

public class CloneManController : EnemyController
{
    private CloneManStateMachine stateMachine;

    public CloneManController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
    {
        enemyView.SetController(this);
        CreateStateMachine();
        stateMachine.ChangeState(States.IDLE);
    }

    private void CreateStateMachine() => stateMachine = new CloneManStateMachine(this);

    public override void UpdateEnemy()
    {
        if (currentState == EnemyState.DEACTIVE)
            return;

        stateMachine.Update();
    }
}