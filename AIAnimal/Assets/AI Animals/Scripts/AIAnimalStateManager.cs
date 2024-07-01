using UnityEngine;
using UnityEngine.AI;

public enum AnimalActions
{
    Idle, Walking, Sitting, Eating
}
    

public class AIAnimalStateManager : MonoBehaviour
{
    public static class AnimationName
    {
        public const string Idle = "Idle";
        public const string Walking = "Walking";
        public const string Sitting = "Sitting";
        public const string Eating = "Eating";
    }
    
    public AnimalActions animalAction;

    [SerializeField] private float maxStandTime = 2f;
    [SerializeField] private float minStandTime = 3f;
    [SerializeField] private float eatingTime = 5f;
    [SerializeField] private float sittingTime = 9f;
    
    // Properties for accessing idle and walk time ranges.
    public float MaxStandTime => maxStandTime;
    public float MinStandTime => minStandTime;
    public float EatingTime => eatingTime;
    public float SittingTime => sittingTime;
    
    private AnimalBaseState _presentState;
    [HideInInspector] public AnimalIdleState    idleState;
    [HideInInspector] public AnimalWalkState    walkState;
    [HideInInspector] public AnimalSitState     sitState;
    [HideInInspector] public AnimalEatingState  eatingState;

    public NavMeshAgent agent;
    public Animator animator;

    public AnimalWaypoints animalWaypoints;

    public WayPointKnot selectedWayPointKnot;
    
    private  bool _isBusy;
    [SerializeField] private string currentAnimName = AnimationName.Idle;

    private void Start()
    {
        agent        = GetComponent<NavMeshAgent>();
        // animator     = GetComponent<Animator>();

        idleState    = GetComponent<AnimalIdleState>();
        walkState    = GetComponent<AnimalWalkState>();
        sitState     = GetComponent<AnimalSitState>();
        eatingState  = GetComponent<AnimalEatingState>();
        
        // Initial State and entering the state.
        animalAction  = AnimalActions.Walking;
        _presentState = walkState;
        _presentState.EnterState(this);
    }

    private void Update()
    {
        _presentState.UpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        _presentState.OnStateTriggerEnter(this, other);
    }

    public void SwitchState(AnimalBaseState state)
    {
        _presentState.ExitState(this);
        _presentState = state;
        _presentState.EnterState(this);
    }
    
    [SerializeField] private bool showDebugLog;

    public void DebugLog(string log)
    {
        if (showDebugLog)
        {
            Debug.Log(log);
        }
    }
    
    /// <summary>
    /// Internal method to play animation by the farmer animator component. 
    /// </summary>
    /// <param name="newState">Next animation state to play.</param>
    internal void PlayAnimation(string newState)
    {
        // If the given animation state is already playing, do nothing. 
        if (currentAnimName == newState) return;
        
        currentAnimName = newState;
        animator.CrossFade(newState, 0.08f);
    }
}
