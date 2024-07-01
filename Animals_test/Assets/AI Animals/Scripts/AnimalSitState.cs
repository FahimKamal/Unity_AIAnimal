using UnityEngine;

public class AnimalSitState : AnimalBaseState
{
    private float _timer;
    private float _timerStopDuration;
    public override void EnterState(AIAnimalStateManager animal)
    {
        animal.DebugLog("Entering Eating State");
        animal.animalAction = AnimalActions.Sitting;
        animal.PlayAnimation(AIAnimalStateManager.AnimationName.Sitting);
        _timerStopDuration = animal.SittingTime;
    }

    public override void UpdateState(AIAnimalStateManager animal)
    {
        _timer += Time.deltaTime;
        if (_timer >= _timerStopDuration)
        {
            animal.SwitchState(animal.idleState);
        }
    }

    public override void ExitState(AIAnimalStateManager animal)
    {
        _timer = 0.0f;
        _timerStopDuration = 0.0f;
    }

    public override void OnStateTriggerEnter(AIAnimalStateManager animal, Collider animalCollider)
    {
        base.OnStateTriggerEnter(animal, animalCollider);
    }
}
