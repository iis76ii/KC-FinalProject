using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 20f;
    public float range = 100f;
    public float firerate = 15f;
    public Camera fpscam;
    public ParticleSystem muzzle;
    public GameObject impacteffect;

    private float nextTimetofire = 0f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimetofire)
        {
            nextTimetofire = Time.time + 1 / firerate;
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
           GameObject impactGO = Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
        }
    }
}
