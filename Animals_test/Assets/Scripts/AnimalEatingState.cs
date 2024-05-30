using UnityEngine;

public class AnimalEatingState : AnimalBaseState
{
    private float _timer;
    private float _timerStopDuration;
    public override void EnterState(AIAnimalStateManager animal)
    {
        animal.DebugLog("Entering Eating State");
        animal.animalAction = AnimalActions.Eating;
        animal.PlayAnimation(AIAnimalStateManager.AnimState.Eating);
        _timerStopDuration = animal.EatingTime;
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
        base.ExitState(animal);
    }

    public override void OnStateTriggerEnter(AIAnimalStateManager animal, Collider animalCollider)
    {
        base.OnStateTriggerEnter(animal, animalCollider);
    }
}
