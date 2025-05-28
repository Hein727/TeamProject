using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �X�v���C�g��E�L�[�Ő؂�ւ���X�N���v�g
public class SpriteSwitcher : MonoBehaviour
{
    // �ʏ펞�̃X�v���C�g�i�ŏ��ɕ\�������摜�j
    public Sprite spriteA;//�ʏ�̉摜

    // E�L�[���������Ƃ��ɐ؂�ւ���X�v���C�g
    public Sprite spriteB;//E�L�[���������Ƃ��ɐ؂�ւ���摜

    // �X�v���C�g��\�����邽�߂�SpriteRenderer�R���|�[�l���g
    private SpriteRenderer spriteRenderer;

    // �X�v���C�g���؂�ւ�������ǂ������Ǘ�����t���O
    private bool isSwitched = false;

    // Start is called before the first frame update
    void Start()
    {
        // �Q�[���I�u�W�F�N�g��SpriteRenderer�R���|�[�l���g���擾
        spriteRenderer = GetComponent<SpriteRenderer>();

        // �Q�[���J�n����spriteA�i�ʏ�̉摜�j��\��
        spriteRenderer.sprite = spriteA;
    }

    // Update is called once per frame
    void Update()
    {
        // E�L�[�������ꂽ�Ƃ��ɃX�v���C�g��؂�ւ���
        if (Input.GetKeyDown(KeyCode.E))
        {
            // isSwitched�t���O�𔽓]�i���݂̏�Ԃ�؂�ւ���j
            isSwitched = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            isSwitched = false;
        }

        spriteRenderer.sprite = isSwitched ? spriteB : spriteA;
    }
}
