using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class CursorManager : MonoBehaviour
{
    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Cursor.visible = false;
       if (Application.isPlaying) { 
            Cursor.lockState = CursorLockMode.None; 
       } else { 
            Cursor.lockState = CursorLockMode.Confined;
       }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Input.mousePosition;
        image.rectTransform.position = cursorPos;

        // if (!Application.isPlaying) { return; }  
        // Cursor.visible = false;
    }
}
