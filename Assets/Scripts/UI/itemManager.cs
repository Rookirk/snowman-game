using UnityEngine;
using UnityEngine.UI;

public class itemManager : MonoBehaviour
{
    public static itemManager instance; // reference to this instance
    public Text itemNumText;            // reference to text in the UI

    int _itemCount = 0;
    int _itemMax = 10;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // Update text
        itemNumText.text = "Items Collected: " + _itemCount.ToString() + "/" + _itemMax.ToString();
    }

    // Add item to total items collected
    public void AddItem()
    {
        _itemCount++;
    }
}
