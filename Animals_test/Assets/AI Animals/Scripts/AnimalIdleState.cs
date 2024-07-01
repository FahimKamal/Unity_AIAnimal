using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalIdleState : AnimalBaseState
{
    private float _timer;
    private float _timerStopDuration;
    
    public override void EnterState(AIAnimalStateManager animal)
    {
        _timerStopDuration = Random.Range(animal.MinStandTime, animal.MaxStandTime);
        animal.DebugLog("Entering Idle State");
        animal.animalAction = AnimalActions.Idle;
        if (animal.animalAction == AnimalActions.Idle)
        {
            animal.PlayAnimation(AIAnimalStateManager.AnimationName.Idle);
        }
    }

    public override void UpdateState(AIAnimalStateManager animal)
    {
        _timer += Time.deltaTime;

        if (_timer >= _timerStopDuration)
        {
            animal.SwitchState(animal.walkState);
        }
    }

    public override void ExitState(AIAnimalStateManager animal)
    {
        _timer = 0.0f;
        _timerStopDuration = 0.0f;
        animal.DebugLog("Exiting Idle State");
    }

    public override void OnStateTriggerEnter(AIAnimalStateManager animal, Collider animalCollider)
    {
        base.OnStateTriggerEnter(animal, animalCollider);
    }
}
