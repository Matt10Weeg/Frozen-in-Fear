using UnityEngine;

public class EnemyDamege : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damege = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamege(damege);
        }
    }
}

