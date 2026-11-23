using UnityEngine;

public class QuitOnObjectClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}