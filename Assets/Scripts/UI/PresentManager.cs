using UnityEngine;
using UnityEngine.UI;

public class PresentManager : MonoBehaviour
{
    public static PresentManager instance; // reference to this instance
    public Text itemNumText;            // reference to text in the UI

    private int _itemCount = 0;
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

    // Add item to total items collected
    public void AddItem()
    {
        _itemCount++;
        SetText();
    }
}
