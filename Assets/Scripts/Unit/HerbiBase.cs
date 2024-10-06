using System.Collections;
using UnityEngine;

public class HerbiBase : MonoBehaviour
{
    public float health = 100f;
    public float movementSpeed = 2f;
    public GameObject smokeAnimPrefab;
    public SpriteRenderer spriteRenderer; // Reference to main sprite
    public SpriteRenderer weaponSlotSpriteRenderer; // Reference to the WeaponSlot sprite

    private bool isAttacking = false;
    private GameObject instantiatedSmoke; // Store the instantiated smoke animation

    private void Update()
    {
        // Only move if not attacking
        if (!isAttacking)
        {
            MoveRight();
        }
    }

    private void MoveRight()
    {
        // Move to the right at the defined speed
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Start combat when colliding with a Karni and not already attacking
        if (other.CompareTag("Karni") && !isAttacking)
        {
            isAttacking = true; // Stop movement and enter attack mode
            StartCoroutine(HandleCombat(other.gameObject.GetComponent<KarniBase>()));
        }
    }

    private IEnumerator HandleCombat(KarniBase karni)
    {
        SetOpacity(0f); // Make both Herbi and WeaponSlot invisible
        karni.SetOpacity(0f);

        // Instantiate the smoke animation and store the reference
        instantiatedSmoke = Instantiate(smokeAnimPrefab, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(3f); // Wait 3 seconds before resolving the fight

        // Decide who dies
        float randomValue = Random.value;
        if (randomValue < 0.33f)
        {
            Die(); // Herbi dies
        }
        else if (randomValue < 0.66f)
        {
            karni.Die(); // Karni dies
        }
        else
        {
            Die();       // Both die
            karni.Die();
        }

        // Destroy the smoke animation after the fight ends
        if (instantiatedSmoke != null)
        {
            Destroy(instantiatedSmoke);
        }

        isAttacking = false; // Reset attacking state, allowing movement to resume if alive
    }

    public void Die()
    {
        // Herbi dies, destroy the Herbi game object
        Destroy(gameObject);
    }

    public void SetOpacity(float alpha)
    {
        // Set opacity for Herbi's sprite and the WeaponSlot sprite
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;

        if (weaponSlotSpriteRenderer != null)
        {
            Color weaponSlotColor = weaponSlotSpriteRenderer.color;
            weaponSlotColor.a = alpha;
            weaponSlotSpriteRenderer.color = weaponSlotColor;
        }
    }
}
