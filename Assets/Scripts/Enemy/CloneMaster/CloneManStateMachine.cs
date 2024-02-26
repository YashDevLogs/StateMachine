
using StatePattern.Enemy;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Enemy.CloneMaster
{
    public class CloneManStateMachine : MonoBehaviour
    {

        public CloneManStateMachine(CloneManController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(StateMachine.States.IDLE, new IdleState<CloneManController>(this));
            States.Add(StateMachine.States.PATROLLING, new PatrollingState<CloneManController>(this));
            States.Add(StateMachine.States.CHASING, new ChasingState<CloneManController>(this));
            States.Add(StateMachine.States.SHOOTING, new ShootingState<CloneManController>(this));
            States.Add(StateMachine.States.CLONING, new TeleportingState<CloneManController>(this));
        }
    }