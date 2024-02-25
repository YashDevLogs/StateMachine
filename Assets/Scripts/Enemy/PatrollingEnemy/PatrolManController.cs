// Controller for a patrolling enemy character.
using StatePattern.Enemy;
using StatePattern.Player;

public class PatrolManController : EnemyController
{
    private PatrolManStateMachine stateMachine;

    // Constructor initializes the controller and sets the initial state to IDLE.
    public PatrolManController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
    {
        enemyView.SetController(this);
        CreateStateMachine();
        stateMachine.ChangeState(States.IDLE);
    }

    // Creates a PatrolManStateMachine.
    private void CreateStateMachine() => stateMachine = new PatrolManStateMachine(this);

    // Override to update the enemy's state machine.
    public override void UpdateEnemy()
    {
        if (currentState == EnemyState.DEACTIVE)
            return;

        stateMachine.Update();
    }

    public override void PlayerEnteredRange(PlayerController targetToSet)
    {
        base.PlayerEnteredRange(targetToSet);
        stateMachine.ChangeState(States.CHASING);
    }

    // Called when a player exits this enemy's detection range.
    public override void PlayerExitedRange() => stateMachine.ChangeState(States.IDLE);
}