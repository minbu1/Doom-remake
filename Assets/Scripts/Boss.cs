using UnityEngine;

public class CircularBulletShooter : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign your bullet prefab here
    public float bulletSpeed = 5f;  // Speed of the bullets
    public int bulletCount = 10;    // Number of bullets to shoot
    public float shootInterval = 1f; // Interval between each shot in seconds

    void Start()
    {
        InvokeRepeating("ShootBulletsInCircle", 0f, shootInterval);
    }

    void ShootBulletsInCircle()
    {
        float angleStep = 360f / bulletCount;
        float angle = 0f;

        for (int i = 0; i < bulletCount; i++)
        {
            // Calculate direction
            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180);

            Vector3 bulletVector = new Vector3(bulletDirX, bulletDirY, 0);
            Vector3 bulletMoveDirection = (bulletVector - transform.position).normalized * bulletSpeed;

            // Create bullet and set its position
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletMoveDirection.x, bulletMoveDirection.y);

            angle += angleStep;
        }
    }
}