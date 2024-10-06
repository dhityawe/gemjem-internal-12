using System.Collections;
using UnityEngine;

public class KarniBase : MonoBehaviour
{
    public float health = 100f;
    public float movementSpeed = 2f;
    public GameObject smokeAnimPrefab;
    public SpriteRenderer spriteRenderer;

    private bool isAttacking = false;

    private void Update()
    {
        if (!isAttacking)
        {
            MoveLeft();
        }
    }

    private void MoveLeft()
    {
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Herbi") && !isAttacking)
        {
            isAttacking = true;
            StartCoroutine(HandleCombat(other.gameObject.GetComponent<HerbiBase>()));
        }
    }

    private IEnumerator HandleCombat(HerbiBase herbi)
    {
        SetOpacity(0f); // Make both invisible
        herbi.SetOpacity(0f);

        Instantiate(smokeAnimPrefab, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(3f); // Wait 3 seconds before resolving the fight

        // Decide who dies
        float randomValue = Random.value;
        if (randomValue < 0.33f)
        {
            Die();
        }
        else if (randomValue < 0.66f)
        {
            herbi.Die();
        }
        else
        {
            Die();
            herbi.Die();
        }

        // If Karni survives, reset opacity
        if (health > 0)
        {
            SetOpacity(1f);
        }

        isAttacking = false;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void SetOpacity(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }
}
