using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterController : MonoBehaviour
{
    // Variables pour l'IA / Pathfinding
    [SerializeField]
    private NavMeshAgent navAgent;
    [SerializeField]
    private float wanderDistance = 8;

    private void Update()
    {
        // Si l'ennemi a atteint sa destination, on lui attribue une nouvelle destination
        if (navAgent.remainingDistance < .5f)
        {
            GetNewDestination();
        }
    }

    // Recupère une nouvelle destination a proximité (utilisé par l'IA pour les déplacements)
    private void GetNewDestination()
    {
        Vector3 nextDestination = transform.position;
        nextDestination += wanderDistance * new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(nextDestination, out hit, 3f, NavMesh.AllAreas))
        {
            navAgent.SetDestination(hit.position);
        }
    }

    // Permet de passer du mode "déplacement" au mode "Ragdoll"
    // On désactive : le collider général de l'objet, le système d'animation, le système de déplacement et ce même script.
    public void EnableRagdoll()
    {
        transform.GetChild(0).GetComponent<Animator>().enabled = false;
        navAgent.enabled = false;
        this.enabled = false;
    }

}