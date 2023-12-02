using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, ITarget
{
    [SerializeField]private TargetData targetData;

    void Awake()
    {
        targetData = ScriptableObject.Instantiate(targetData);
        targetData.currentHealth += targetData.maxHealth;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damageTaken)
    {
        targetData.currentHealth -= damageTaken;
        if(targetData.currentHealth <= 0)
        {
            Destroy();
        }
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
