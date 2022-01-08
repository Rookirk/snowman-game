using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PresentManager : MonoBehaviour
{
    public static PresentManager instance; // reference to this instance
    public Text itemNumText;            // reference to text in the UI

    private int _itemCount = 0;

    //Make it public to expose it the Inspector 
    private int _itemMax = 10;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetText();
    }

    private void SetText()
    {
        // Update text
        itemNumText.text = "Presents Collected: " + _itemCount.ToString() + "/" + _itemMax.ToString();
    }

    // Add the item count when collecting items
    // Note: Changed the function's name "AddItem" into "AddPresent"
    public void AddPresent()
    {
        _itemCount++;
        SetText();

        // Check item count again item max
        // When item count equals the total amount of gifts, transition to the End Screen
        if (_itemCount == _itemMax)
        {
            // The Scene Manager is referenced & loads End Screen scene by string/name
            SceneManager.LoadScene("EndScreen"); 
        }
    }
}
