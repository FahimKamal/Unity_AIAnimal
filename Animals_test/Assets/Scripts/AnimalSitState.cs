using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSitState : AnimalBaseState
{
    public override void EnterState(AIAnimalStateManager animal)
    {
        throw new System.NotImplementedException();
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
