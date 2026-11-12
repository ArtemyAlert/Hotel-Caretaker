using UnityEngine;

public class WindowOpener : MonoBehaviour
{
    private Animator animator; // Один аниматор на родителе

    void Start()
    {
        // Берем аниматор с самого себя (родителя)
        animator = GetComponent<Animator>();

        if (animator == null)
            Debug.LogError("❌ Не найден Animator на объекте " + gameObject.name);
        else
            Debug.Log("✅ Animator успешно подключен!");
    }

    void OnMouseDown()
    {
        if (animator != null)
        {
            // Отправляем сигнал этому одному аниматору
            // Имя должно совпадать с параметром в CombinedWindowController
            animator.SetTrigger("OpenWindow");

            Debug.Log("🖱️ Клик! Триггер 'OpenWindow' отправлен.");
        }
    }
}