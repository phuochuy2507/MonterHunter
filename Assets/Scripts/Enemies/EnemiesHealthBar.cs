using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealthBar : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private float knockBackThrust = 15f;

    private int currentHealth;
    private Knockback knockback;
    private Flash flash;
    [SerializeField] FloatingHealthBar healthBar;

    private void Awake() {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    private void Start() {
        currentHealth = startingHealth;
        healthBar.UpdateHealthBar(currentHealth, startingHealth);
    }

    public void TakeDamageBar(int damage) {
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, startingHealth);
        knockback.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
    }

    private IEnumerator CheckDetectDeathRoutine() {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }

    public void DetectDeath() {
        if (currentHealth <= 0) {
            ManagerEnemies.no_of_enemies -= 1;
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            GetComponent<PickUpSpawner>().DropItems();
            Destroy(gameObject);
        }
    }

    public bool checkAllDie(){
        if (currentHealth <= 0)
        {
            return true;
        }
       else return false;
    }
}
