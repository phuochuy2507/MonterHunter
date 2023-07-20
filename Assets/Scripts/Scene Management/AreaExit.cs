using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;
    private float waitToLoadTime = 1f;
    void Start() {
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        
        if(ManagerEnemies.no_of_enemies <= 0 && EnemySpawner.EnemytoSpawn == 0) {
            if (other.gameObject.GetComponent<PlayerController>()) {
                SceneManagement.Instance.SetTransitionName(sceneTransitionName);
                UIFade.Instance.FadeToBlack();
                StartCoroutine(LoadSceneRoutine());
            }
        }
    }

    private IEnumerator LoadSceneRoutine() {
        while (waitToLoadTime >= 0) 
        {
            waitToLoadTime -= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}
