using Unity.Mathematics;
using UnityEngine;

public class AnimalWalkState : AnimalBaseState
{
    private AIAction _nextAIAction;
    private float3 _aiDestination;
    // private WayPointKnot selectedWayPointKnot;
    public override void EnterState(AIAnimalStateManager animal)
    {
        animal.DebugLog("Entering walk state");
        animal.animalAction = AnimalActions.Walking;
        if (animal.animalAction == AnimalActions.Walking)
        {
            var destination = animal.animalWaypoints.GetRandomWayPoint();
            _aiDestination = destination.positionValue;
            _nextAIAction = destination.action;
            if (animal.selectedWayPointKnot != null)
            {
                animal.selectedWayPointKnot.isKnotSelected = false;
                animal.selectedWayPointKnot = destination.selectedWaypointKnot;
            }
            // selectedWayPointKnot = destination.selectedWaypointKnot;
            animal.DebugLog($"Walking to {_aiDestination}");
            animal.agent.SetDestination((Vector3)_aiDestination);

            animal.PlayAnimation(AIAnimalStateManager.AnimState.Walking);
        }
    }

    public override void UpdateState(AIAnimalStateManager animal)
    {
        var remainingDistance = Vector3.Distance(animal.transform.position, _aiDestination);
        if (animal.animalAction == AnimalActions.Walking && remainingDistance <= animal.agent.stoppingDistance)
        {
            if (_nextAIAction == AIAction.None || _nextAIAction == AIAction.Idle)
            {
                animal.SwitchState(animal.idleState);
            }
            else if (_nextAIAction == AIAction.Eat)
            {
                animal.SwitchState(animal.eatingState);
            }
            else if (_nextAIAction == AIAction.Sit)
            {
                animal.SwitchState(animal.sitState);
            }
            
        }
    }

    public override void ExitState(AIAnimalStateManager animal)
    {
        animal.DebugLog("");
        _nextAIAction = AIAction.None;
        // selectedWayPointKnot.isKnotSelected = false;
    }

    public override void OnStateTriggerEnter(AIAnimalStateManager animal, Collider animalCollider)
    {
        base.OnStateTriggerEnter(animal, animalCollider);
    }
}
