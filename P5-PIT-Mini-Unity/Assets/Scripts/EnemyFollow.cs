using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] LayerMask longViewMask;
    [SerializeField] LayerMask shortViewMask;
    [SerializeField] float shortViewDistance;
    [SerializeField] public float longViewDistance;

    [SerializeField] float viewAngle;
    [SerializeField] GameObject player;

    [SerializeField] NavMeshAgent NMAgent;
    [SerializeField] float walkSpeed;

    [SerializeField] float lookForPlayerTime;
    public float clock;

    public Vector3 lastPlayerSighting;

    [SerializeField ]Vector2[] targetPositions;
    int targetCounter = 0;
    void Start()
    {
        clock = lookForPlayerTime;
        NMAgent.speed = walkSpeed;   
    }

    void Update()
    {
        Vector2 position2D = new Vector2(transform.position.x, transform.position.z);
        if (CheckPlayerSighting())
        {
            clock = 0f;

            //Vector3 playerDistance = player.transform.position - transform.position;
            NMAgent.destination = player.transform.position;

        }
        else if(clock < lookForPlayerTime)
        {
            clock += Time.deltaTime;

            NMAgent.destination = lastPlayerSighting;

           
            Vector2 lastPlayerSight2D = new Vector2(lastPlayerSighting.x, lastPlayerSighting.z);
            
            if((position2D-lastPlayerSight2D).magnitude < 0.1f)
            {
                Vector2 randomOffset = Random.insideUnitCircle * 5f;

                Vector3 randomPosition = transform.position +
                    new Vector3(randomOffset.x, 0f, randomOffset.y);

                if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, 2f, NavMesh.AllAreas))
                {
                    lastPlayerSighting = hit.position;
                }
            }
           
            
        }
        else if (targetPositions.Length > 0)
        {
            NMAgent.destination = new Vector3(targetPositions[targetCounter].x, 0f, targetPositions[targetCounter].y);
            if ((position2D - targetPositions[targetCounter]).magnitude < 0.5f)
            {
                targetCounter += 1;
                if (targetCounter >= targetPositions.Length)
                {
                    targetCounter = 0;
                }
            }


        }

    }

    bool CheckPlayerSighting()
    {
        RaycastHit longView;
        RaycastHit shortView; //Can see through bushes

        Vector3 playerDistance = player.transform.position - transform.position;
            
        if (playerDistance.magnitude > longViewDistance)
        {
            return false;
        }
        if (Vector3.Angle(transform.forward, playerDistance) > viewAngle)
        {
            return false;
        }
           
        if (Physics.Raycast(transform.position, playerDistance.normalized, out shortView, shortViewDistance, shortViewMask))
        {
            if (shortView.collider.tag == "Player")
            {
                lastPlayerSighting = player.transform.position;
                return true;
            }
            else return false;
        }

        else if (Physics.Raycast(transform.position, playerDistance.normalized, out longView, longViewDistance, longViewMask))
        {
            if (longView.collider.tag == "Player")
            {
                lastPlayerSighting = player.transform.position;
                return true;
            }
            else return false;
        }
        else
        {
            return false;
        }


    }
}
