using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 20f;
    public float range = 100f;
    public Camera fpscam;
    public ParticleSystem muzzle;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            shoot();
        }
    }
    void shoot()
    {

        muzzle.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyAI target = hit.transform.GetComponent<EnemyAI>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
