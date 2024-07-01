using UnityEngine;

public abstract class AnimalBaseState : MonoBehaviour
{
    public abstract  void EnterState(AIAnimalStateManager animal);

    public virtual void UpdateState(AIAnimalStateManager animal) { }

    public virtual void ExitState(AIAnimalStateManager animal) { }

    public virtual void OnStateTriggerEnter(AIAnimalStateManager animal, Collider animalCollider) { }
}
