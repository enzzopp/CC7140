using System.Collections;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speed = 3.0f;
    public float fireRate = 1.0f;
    public float boundX = 9.0f;

    private int direction;

    void Start()
    {
        direction = Random.Range(0, 2) == 0 ? 1 : -1; // Escolhe um lado aleatório para começar
        StartCoroutine(ShootBullets());
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
        
        if (Mathf.Abs(transform.position.x) > boundX)
        {
            Destroy(gameObject); // Some ao alcançar a borda
        }
    }

    IEnumerator ShootBullets()
    {
        while (true)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(fireRate);
        }
    }
}