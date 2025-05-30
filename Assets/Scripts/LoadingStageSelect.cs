using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneLoader : MonoBehaviour
{
    [SerializeField]
    private string stageSelectSceneName = "Stage Select"; // ���ۂ̃V�[�����ɍ��킹�āI

    public void LoadStageSelectScene()
    {
        SceneManager.LoadScene(stageSelectSceneName);
    }
}