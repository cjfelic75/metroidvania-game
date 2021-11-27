using UnityEngine;
using UnityEngine.UI;

public class Playerstats : MonoBehaviour
{

    [SerializeField]
    private Text ValueHealth;


    public PlayerHealth playerHealth;

    // Update is called once per frame
    void Update()
    {
        ValueHealth.text = playerHealth.currentHealth.ToString();

    }
}
