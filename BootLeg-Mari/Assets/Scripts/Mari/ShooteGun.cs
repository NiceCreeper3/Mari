using UnityEngine;

public class ShooteGun : MonoBehaviour
{
    [SerializeField] float _gunRange;
    [SerializeField] ParticleSystem _gunFlash;

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootGun();
        }
    }

    void ShootGun()
    {
        RaycastHit hitInfo;

        // the transform.TransformDirection(Vector3.forward) makes it so the beam is dinamik and alwalyes moves forword
        bool hit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, _gunRange);
        _gunFlash.Play(true);

        //draws a fake line that gives visual indekator
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red, 5);

        FindObjectOfType<AudioMangerScript>().PlayAudio("GunShot", true);

        if (hit)
        {
            //Atempets to get the hit opjeket IJumpable if it has one
            IShootebol shootebol = hitInfo.collider.GetComponent<IShootebol>();

            // the PlayerGravity._velocity.y does not work jet
            if (shootebol != null)
            {
                Debug.Log("shoot");
                shootebol.Shoot();

            }
        }
    }
}
