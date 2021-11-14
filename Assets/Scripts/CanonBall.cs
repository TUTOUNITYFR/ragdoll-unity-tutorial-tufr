using UnityEngine;

// Ce script se trouve sur les projectiles tirés par le canon
public class CanonBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //On vérifie si on a touché le joueur, auquel cas on active son ragdoll
        if(collision.transform.CompareTag("Player"))
        {
            GameObject.Find("Character").GetComponent<CharacterController>().EnableRagdoll();
        }
    }
}
