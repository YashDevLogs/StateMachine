using StatePattern.Enemy;
using System.Collections.Generic;

public class PatrolManStateMachine : IStateMachine
{
    private PatrolManController Owner;
    private IState currentState;
    protected Dictionary<States, IState> States = new Dictionary<States, IState>();

    public PatrolManStateMachine(PatrolManController Owner)
    {
        this.Owner = Owner;
        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {
        States.Add(StateMachine.States.IDLE, new IdleState(this));
        States.Add(StateMachine.States.PATROLLING, new PatrollingState(this));
        States.Add(StateMachine.States.CHASING, new ChasingState(this));
        States.Add(StateMachine.States.SHOOTING, new ShootingState(this));
    }

    private void SetOwner()
    {
        foreach (IState state in States.Values)
        {
            state.Owner = Owner;
        }
    }
}