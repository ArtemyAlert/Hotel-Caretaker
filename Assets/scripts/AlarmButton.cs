using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Обязательно для работы корутин

public class AlarmButton : MonoBehaviour
{
    public Text alarmText;
    public float displayTime = 2f; // Сколько секунд текст висит на экране
    public float fadeDuration = 1f; // За сколько секунд он плавно исчезнет

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (alarmText != null)
            alarmText.gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        if (animator != null)
        {
            animator.SetTrigger("Click");
        }

        if (alarmText != null)
        {
            // Включаем текст и запускаем процесс его исчезновения
            StopAllCoroutines(); // Останавливаем, если вдруг что-то уже работало
            StartCoroutine(ShowAndFadeText());
        }
    }

    IEnumerator ShowAndFadeText()
    {
        // 1. Делаем текст полностью непрозрачным и включаем его
        Color textColor = alarmText.color;
        textColor.a = 1f;
        alarmText.color = textColor;
        alarmText.gameObject.SetActive(true);

        // 2. Ждем указанное время, чтобы игрок прочитал текст
        yield return new WaitForSeconds(displayTime);

        // 3. Плавно уменьшаем прозрачность (Alpha)
        float currentTime = 0;
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            // Вычисляем новую прозрачность от 1 до 0
            textColor.a = Mathf.Lerp(1f, 0f, currentTime / fadeDuration);
            alarmText.color = textColor;
            yield return null; // Ждем следующий кадр
        }

        // 4. Полностью выключаем текст
        alarmText.gameObject.SetActive(false);
    }
}