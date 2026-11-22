using UnityEngine;
using UnityEngine.UI;

public class OXRedBlockScript : MonoBehaviour
{
    public GameObject textObject;
    public int points = 40;
    Text textComponent;
    PlayerScript playerScript;
    public bool isX = false;

    void Start()
    {
        if (textObject != null)
        {
            textComponent = textObject.GetComponent<Text>();
            textComponent.text = "O";
        }
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        isX = !isX;
        if (textComponent != null)
            textComponent.text = isX ? "X" : "O";

        CheckAllBlocks();
    }

    void CheckAllBlocks()
    {
        var allXO = FindObjectsOfType<OXRedBlockScript>();
        foreach (var b in allXO)
        {
            if (!b.isX) return;
        }

        foreach (var b in allXO)
        {
            Destroy(b.gameObject);
            playerScript.BlockDestroyed(b.points);
        }
    }
}