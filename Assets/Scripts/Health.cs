using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 5f;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Takedamage(float damage)
    {
        health -= damage;
        Die();
    }
    public void Die()
    {
        if (health <= 0)
        {
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(0);
        }
    }
    public void DieFromVoid()
    {
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(1);
    }
}
