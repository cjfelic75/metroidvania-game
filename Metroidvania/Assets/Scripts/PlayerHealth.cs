using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private SpriteRenderer sr;
    private int maxHealth = 99;
    public int currentHealth;


    private int maxCanisters = 14;
    public int currentFullCanisters;
    public int currentEmptyCanisters;

    public Image[] Canisters;
    public Sprite fullCanister;
    public Sprite emptyCanister;

    public void TakeDamage(int enemyDamage)
    {
        int cFc = currentHealth - enemyDamage;
        currentHealth -= enemyDamage;
        if (currentHealth <= 0)
        {

            if (currentFullCanisters > 0)
            {
                currentFullCanisters -= 1;
                currentEmptyCanisters += 1;
                currentHealth = (maxHealth + cFc);
            }

            else if (currentHealth < 0)
            {
                currentHealth = 0;
                //Death Animation Here
                //Game Over
            }
        }
    }


    public void Heal(int healAmount)
    {
        int cEc = currentHealth + healAmount;
        currentHealth += healAmount;

        if (currentHealth > 99)
        {

            if (currentEmptyCanisters > 0)
            {
                currentEmptyCanisters -= 1;
                currentFullCanisters += 1;
                currentHealth = 1 + (cEc - 100);
                if (currentHealth > maxHealth)
                {
                    currentHealth = maxHealth;

                }
            }

            else if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;

            }
        }
    }
}
