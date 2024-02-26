using StatePattern.Enemy;
using StatePattern.StateMachine;

public class HitmanController : EnemyController
{
    private HitmanStateMachine stateMachine;

    public HitmanController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
    {
        enemyView.SetController(this);
        CreateStateMachine();
        stateMachine.ChangeState(States.IDLE);
    }

    private void CreateStateMachine() => stateMachine = new HitmanStateMachine(this);

    public override void UpdateEnemy()
    {
        if (currentState == EnemyState.DEACTIVE)
            return;

        stateMachine.Update();
    }
}