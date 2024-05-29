using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Splines;

public enum AnimalActions
{
    Idle, Walking, Sitting, Eating
}
    
public static class AnimState
{
    public static string Idle = "Idle";
    public static string Walking = "Walking";
    public static string Sitting = "Sitting";
    public static string Eating = "Eating";
}
public class AIAnimalStateManager : MonoBehaviour
{
    
    [SerializeField] private AnimalActions animalActions;

    [SerializeField] private float maxStandTime = 7f;
    [SerializeField] private float minStandTime = 5f;
    [SerializeField] private float maxWalkTime = 19f;
    [SerializeField] private float minWalkTime = 9f;
    
    // Properties for accessing idle and walk time ranges.
    public float MaxStandTime => maxStandTime;
    public float MinStandTime => minStandTime;
    public float MaxWalkTime => maxWalkTime;
    public float MinWalkTime => minWalkTime;
    
    private AnimalBaseState _presentState;
    [HideInInspector] public AnimalIdleState idleState;
    [HideInInspector] public AnimalWalkState walkState;
    [HideInInspector] public AnimalSitState sitState;
    [HideInInspector] public AnimalEatingState eatingState;

    public NavMeshAgent agent;
    public Animator animator;

    [SerializeField] private SplineContainer wayPoints;
    
    private  bool _isBusy;
    [SerializeField] private string currentAnimState = AnimState.Idle;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        idleState = GetComponent<AnimalIdleState>();
        walkState = GetComponent<AnimalWalkState>();
        sitState = GetComponent<AnimalSitState>();
        eatingState = GetComponent<AnimalEatingState>();

        var number = wayPoints[0].Knots;
        
        var something = wayPoints[0][2];
        
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
        if (currentAnimState == newState) return;
        
        currentAnimState = newState;
        animator.CrossFade(newState, 0.08f);
    }
}
