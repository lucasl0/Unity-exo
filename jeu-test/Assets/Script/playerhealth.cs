using System.Collections;
using UnityEngine;

public class playerhealth : MonoBehaviour
{
    public int maxLifePoints = 3;
    public int currentLifePoints = 3;
    public bool isInvulnerable = false;
    public float InvulnerableTime = 2.5f;
    public float InvulnerableFlash = 0.2f;
    public SpriteRenderer sr;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLifePoints = maxLifePoints;
    }

    public void Hurt(int damage = 1)
    {
        if (isInvulnerable)
        {
            return;
        }
        currentLifePoints = currentLifePoints - damage;
        if (currentLifePoints <= 0)
        {
            Debug.Log("Fin de la partie");
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(Invulnerable());
        }

    }
    IEnumerator Invulnerable()
    {
        isInvulnerable = true;
        Color startColor = sr.color;
        WaitForSeconds invulnerableFlashWait =
        new WaitForSeconds(InvulnerableFlash);

        for (float i = 0; i <= InvulnerableTime; i += InvulnerableFlash)
        {
            if (sr.color.a == 1)
            {
                sr.color = Color.clear;
            }
            else
            {
                sr.color = startColor;
            }
            yield return new WaitForSeconds(InvulnerableFlash);
        }
        sr.color = startColor;
        isInvulnerable = false;
        yield return null;
    }
}
