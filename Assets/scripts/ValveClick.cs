using UnityEngine;

public class ValveClick : MonoBehaviour
{
    // Ссылка на компонент Animator, который управляет анимациями
    public Animator animatorTarget;

    void OnMouseDown()
    {
        // Эта функция срабатывает автоматически при клике мышкой по объекту с коллайдером
        if (animatorTarget != null)
        {
            // Запускает наш триггер "Play", активируя оба слоя в Animator Controller
            animatorTarget.SetTrigger("Play");
        }
    }
}