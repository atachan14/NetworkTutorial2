using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoveEffectController : MonoBehaviour
{
    public float fadeDuration = 2f; // フェードアウトにかける時間
    private Renderer objectRenderer;
    private Color initialColor;

    void Start()
    {
        // オブジェクトのRendererを取得
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            initialColor = objectRenderer.material.color; // 元の色を保存
            StartCoroutine(FadeOutAndDestroy());
        }
        else
        {
            Debug.LogWarning("Rendererが見つかりませんでした");
            Destroy(gameObject); // Rendererがない場合は即破壊
        }
    }

    private IEnumerator FadeOutAndDestroy()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // 時間経過に応じてアルファ値を減少させる
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            Color newColor = initialColor;
            newColor.a = alpha;
            objectRenderer.material.color = newColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 最後にオブジェクトを破壊
        Destroy(gameObject);
    }
}