using StatePattern.Enemy;
using StatePattern.StateMachine;
using System.Collections;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy.States
{
    public class CloningState<T> : IState where T : EnemyController
    {
        public EnemyController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;


        public CloningState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            stateMachine.ChangeState(States.CHASING);

        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void OnStateExit()
        {
              public override void UpdateEnemy()
        {
            if (currentState == EnemyState.DEACTIVE)
                return;
            stateMachine.Update();
        }
    }

    private void TeleportToRandomPosition() => Owner.Agent.Warp(GetRandomNavMeshPoint());

    // Generates a random NavMesh position within the teleporting radius.
    private Vector3 GetRandomNavMeshPoint()
    {
        // Calculate a random direction within the teleporting radius.
        Vector3 randomDirection = Random.insideUnitSphere * Owner.Data.TeleportingRadius + Owner.Position;
        NavMeshHit hit;

        // Try to find a valid NavMesh position within the radius, return spawn position if not found.
        if (NavMesh.SamplePosition(randomDirection, out hit, Owner.Data.TeleportingRadius, NavMesh.AllAreas))
            return hit.position;

        return Owner.Data.SpawnPosition;
    }

}