using UnityEngine;

// Ce script permet de tirer des projectiles sur une cible, il se trouve sur le GameObject "Canon".
public class Canon : MonoBehaviour
{
    public Transform target;
    public GameObject canonBall;
    public float firePower = 70f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            // On fait apparaitre le projectile
            GameObject projectile = Instantiate(canonBall);
            projectile.transform.position = transform.position;

            // On envoie le projectile vers la cible (le personnage)
            Vector3 direction = (target.position - transform.position).normalized;
            projectile.GetComponent<Rigidbody>().AddForce(direction * firePower, ForceMode.Impulse);
        }
    }
}
