using UnityEngine;
using UnityEngine.AI;

public class PlayerPerson : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private Camera _camera;

    [SerializeField] private Gun gun;

    [SerializeField] private GameObject model;

    [SerializeField] private Animator animator;
    private static readonly int IsRun = Animator.StringToHash("isRun");

    private void Start()
    {
        _camera = Camera.main;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast (ray, out hit))
            {
                Vector3 clickPoint = hit.point;
                
                RotateToTarget(clickPoint);
            
                gun.Fire(clickPoint);
            }
        }

        if (agent.hasPath == false)
        {
            animator.SetBool(IsRun, false);
        }
    }

    public void Move(Vector3 target)
    {
        animator.SetBool(IsRun, true);
        agent.destination = target;
    }

    private void RotateToTarget(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;

        Quaternion  lookRotation = Quaternion.LookRotation(direction);
        lookRotation.x = 0;
        lookRotation.z = 0;
 
        model.transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1);
    }
}
