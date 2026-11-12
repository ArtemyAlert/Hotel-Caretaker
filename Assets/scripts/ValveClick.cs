using UnityEngine;

public class ValveClick : MonoBehaviour
{
    void OnMouseDown()
    {
        // Ищем Animator на этом объекте ИЛИ на любом из родителей вверх по цепочке
        Animator anim = GetComponentInParent<Animator>();

        if (anim != null)
        {
            // Отправляем триггер OpenWindow (или TurnValve, как ты назвал)
            anim.SetTrigger("OpenWindow");
            Debug.Log("Клик! Триггер отправлен.");
        }
        else
        {
            Debug.LogError("Не найден Animator ни на объекте, ни на родителях!");
        }
    }
}