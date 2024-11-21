using UnityEngine;
using UnityEngine.UI;

public class UIClose : MonoBehaviour
{
    private Button closeButton;

    private void Awake()
    {
        closeButton = GetComponent<Button>();
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseUI);
        }
        else
        {
            Debug.LogWarning("Button component not found on " + gameObject.name);
        }
    }

    private void CloseUI()
    {
        UIManager.Instance.CloseUI();
    }

    private void OnDestroy()
    {
        if (closeButton != null)
        {
            closeButton.onClick.RemoveListener(CloseUI);
        }
    }
}