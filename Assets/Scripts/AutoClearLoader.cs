using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AutoClearLoader : MonoBehaviour
{
    [SerializeField]
    private float waitTime = 3f;  // �҂����ԁi�b�j

    [SerializeField]
    private string clearSceneName = "GameClearScene"; // ���ۂ̃N���A�V�[�����ɍ��킹�ĂˁI

    void Start()
    {
        StartCoroutine(LoadClearSceneAfterDelay());
    }

    IEnumerator LoadClearSceneAfterDelay()
    {
        yield return new WaitForSeconds(waitTime);
        PlayerPrefs.SetString("LastStage", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(clearSceneName);
    }
}