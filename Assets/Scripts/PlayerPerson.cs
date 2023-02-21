using UnityEngine;
using UnityEngine.AI;

public class PlayerPerson : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private Camera _camera;

    [SerializeField] private Gun gun;

    [SerializeField] private GameObject model;

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
                
                Vector3 direction = (clickPoint - transform.position).normalized;

                Quaternion  lookRotation = Quaternion.LookRotation(direction);
                lookRotation.x = 0;
                lookRotation.z = 0;
 
                model.transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1);
            
                gun.Fire(clickPoint);
            }
        }
    }

    public void Move(Vector3 target)
    {
        agent.destination = target;
    }
}
