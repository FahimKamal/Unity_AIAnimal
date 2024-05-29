using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimalStateManager : MonoBehaviour
{
    public enum AnimalActions
    {
        Idle, Walking, Sitting, Eating
    }

    [SerializeField] private AnimalActions animalActions;
    
    // private 
}
