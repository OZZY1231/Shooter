using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab1;
    public Transform firePoint1;
    
    public GameObject bulletPrefab2;
    public Transform firePoint2;

    public float BulletTime = 5f;

    private void Update() 
    {

        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot1();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Shoot2();
        }
    }

    private void Shoot1()
    {
        GameObject bullet1 = Instantiate(bulletPrefab1, firePoint1.transform.position, firePoint1.transform.rotation);
        Destroy(bullet1, BulletTime);
    }

    private void Shoot2()
    {
        GameObject bullet2 = Instantiate(bulletPrefab2, firePoint2.transform.position, firePoint2.transform.rotation);
        Destroy(bullet2, BulletTime);
    }

}
