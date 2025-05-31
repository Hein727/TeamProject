using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// スプライトをEキーで切り替えるスクリプト
public class SpriteSwitcher : MonoBehaviour
{
    // 通常時のスプライト（最初に表示される画像）
    public Sprite spriteA;//通常の画像

    // Eキーを押したときに切り替えるスプライト
    public Sprite spriteB;//Eキーを押したときに切り替える画像

    // スプライトを表示するためのSpriteRendererコンポーネント
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // ゲームオブジェクトのSpriteRendererコンポーネントを取得
        spriteRenderer = GetComponent<SpriteRenderer>();

        // ゲーム開始時にspriteA（通常の画像）を表示
        spriteRenderer.sprite = spriteA;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            spriteRenderer.sprite = spriteB;
        }
        else
        {
            spriteRenderer.sprite = spriteA;
        }
    }
}
