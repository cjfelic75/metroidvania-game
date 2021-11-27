using UnityEngine;
using UnityEngine.UI;

public class HealthStats : MonoBehaviour
{
    private SpriteRenderer sr;
    public int maxHealth = 99;
    public int currentHealth;

    public int maxCanisters = 14;
    public int currentCanisters;
    public int currentFullCanisters;
    public int currentEmptyCanisters;

    public Image[] health;
    public Sprite Zero;
    public Sprite One;
    public Sprite Two;
    public Sprite Three;
    public Sprite Four;
    public Sprite Five;
    public Sprite Six;
    public Sprite Seven;
    public Sprite Eight;
    public Sprite Nine;

    public Image[] Canisters;
    public Sprite fullCanister;
    public Sprite emptyCanister;

    void TakeDamage(int enemyDamage)
    {
       int cFc = currentHealth -= enemyDamage;
       currentHealth -= enemyDamage;

        if (currentHealth < 0) {
         
            if (currentFullCanisters > 0)
            {
                currentFullCanisters -= 1;
                currentHealth = maxHealth -= cFc;
            }

            else if(currentHealth == 0)
            {
                //Death Animation Here
                //Game Over
            }
        }
    }

    void Heal(int HealAmount)
    {
        int cEc = currentHealth += HealAmount;
        currentHealth += HealAmount;

        if (currentHealth > 99) 
        {
         
            if (currentEmptyCanisters > 0)
            {
                currentFullCanisters += 1;
                currentHealth = 0 + (cEc - 100);
            }

            else if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;

            }
        }
    }
}
