using UnityEngine;

public class AnimalEatingState : AnimalBaseState
{
    public override void EnterState(AIAnimalStateManager animal)
    {
        
    }

    public override void UpdateState(AIAnimalStateManager animal)
    {
        base.UpdateState(animal);
    }

    public override void ExitState(AIAnimalStateManager animal)
    {
        base.ExitState(animal);
    }

    public override void OnStateTriggerEnter(AIAnimalStateManager animal, Collider animalCollider)
    {
        base.OnStateTriggerEnter(animal, animalCollider);
    }
}
