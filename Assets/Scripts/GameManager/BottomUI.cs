using System.Collections;
using UnityEngine;

public class BottomUI : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;

    public float spawnCooldown = 3f;

    public GameObject spawnPoint;

    private bool canUseButton = true; // To track if any button can be used

    public void Button1()
    {
        if (canUseButton)
        {
            Instantiate(prefab1, spawnPoint.transform.position, Quaternion.identity);
            StartCoroutine(Cooldown());
        }
    }

    public void Button2()
    {
        if (canUseButton)
        {
            Instantiate(prefab2, spawnPoint.transform.position, Quaternion.identity);
            StartCoroutine(Cooldown());
        }
    }

    public void Button3()
    {
        if (canUseButton)
        {
            Instantiate(prefab3, spawnPoint.transform.position, Quaternion.identity);
            StartCoroutine(Cooldown());
        }
    }

    public void Button4()
    {
        if (canUseButton)
        {
            Instantiate(prefab4, spawnPoint.transform.position, Quaternion.identity);
            StartCoroutine(Cooldown());
        }
    }

    public void Button5()
    {
        if (canUseButton)
        {
            Instantiate(prefab5, spawnPoint.transform.position, Quaternion.identity);
            StartCoroutine(Cooldown());
        }
    }

    // Cooldown coroutine to disable buttons for the cooldown duration
    private IEnumerator Cooldown()
    {
        canUseButton = false; // Disable button usage
        yield return new WaitForSeconds(spawnCooldown); // Wait for cooldown time
        canUseButton = true;  // Re-enable button usage
    }
}
