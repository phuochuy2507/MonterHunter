using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSkill2 : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefap;
    [SerializeField] private float bulletMoveSpeed;
    [SerializeField] private int burstCount;
    [SerializeField] private float timebtwBurst;
    [SerializeField] private float restTime = 1f;
    private bool isShooting = false;
  

    public void Attack()
    {
            if (!isShooting)
            {
                StartCoroutine(ShootRoutine());
            }
    }
    private IEnumerator ShootRoutine()
    {
        isShooting = true;

        for (int i = 0; i < burstCount; i++)
        {
            Vector2 targetDirection = PlayerController.Instance.transform.position - transform.position;

            GameObject newBullet = Instantiate(bulletPrefap, transform.position, Quaternion.identity);
            newBullet.transform.right = targetDirection;

            if (newBullet.TryGetComponent(out Projectile projectile))
            {
                projectile.UpdateMoveSpeed(bulletMoveSpeed);
            }
            yield return new WaitForSeconds(timebtwBurst);
        }

        yield return new WaitForSeconds(restTime);
        isShooting = false;
    }
}
