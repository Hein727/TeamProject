using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneLoader : MonoBehaviour
{
    [SerializeField]
    private string stageSelectSceneName = "Stage Select"; // ÀÛ‚ÌƒV[ƒ“–¼‚É‡‚í‚¹‚ÄI

    public void LoadStageSelectScene()
    {
        SceneManager.LoadScene(stageSelectSceneName);
    }
}