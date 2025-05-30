using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneContoroller : MonoBehaviour
{
    void Start()
    {
        string nextStage = PlayerPrefs.GetString("NextStageName", "");

        if (!string.IsNullOrEmpty(nextStage))
        {
            Debug.Log("���̃X�e�[�W��ǂݍ��݂܂�: " + nextStage);
            SceneManager.LoadScene(nextStage);
        }
        else
        {
            Debug.LogWarning("NextStageName ���ݒ肳��Ă��܂���I");
        }
    }
}

