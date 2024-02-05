using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject enemy;

    Renderer rend;

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            enemy = Instantiate(enemyPrefab) as GameObject;
            rend = enemy.GetComponent<Renderer>();
            enemy.transform.position = new Vector3(0, 1, 0);
            enemy.transform.localScale = new Vector3(1f, Random.Range(0.5f, 3f), 1);
            rend.material.color = Random.ColorHSV(0f,1f,1f,1f,0.5f,1f);
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }

    }
}
