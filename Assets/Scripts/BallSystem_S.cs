using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using Unity.Collections;
using System.Linq;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;
using System.Collections;
using UnityEngine.InputSystem.LowLevel;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class BallSystem_S : MonoBehaviour
{
    private List<GameObject> list;
    private List<GameObject> list2;
    private GameObject prefab;
    private Shooting_S Shooting;
    public Image[] images;
    private Dictionary<string, int> amount = new Dictionary<string, int>()
    {
        { "N_0", 2 },
        { "RANK1", 3 },
        { "RANK2", 3 },
        { "RANK3", 3 },
        { "RANK4", 3 },
        { "RANK5", 2 },
        { "RANK6", 2 },
        { "RANK7", 2 },
        { "RANK8", 2 },
        { "RANK9", 1 },
        { "RANK10", 1 },
    };
    private int count = 0;
    private int swapCount = 0;
    public bool GameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        list = new List<GameObject>();
        list2 = new List<GameObject>();
        StartCoroutine(LoadPrefabs());
    }

    private IEnumerator LoadPrefabs()
    {
        AsyncOperationHandle<IList<GameObject>> opHandle = Addressables.LoadAssetsAsync<GameObject>("PlayerPrefabs", null);
        yield return opHandle;

        if(opHandle.Status == AsyncOperationStatus.Succeeded)
        {
            foreach (GameObject prefab in opHandle.Result)
            {
                int copies = 0;

                if (amount.ContainsKey(prefab.name))
                {
                    copies = amount[prefab.name];
                }

                for (int i = 0; i < copies; i++)
                {
                    list.Add(prefab);
                    Debug.Log("Object" + prefab);
                }
            }
            Shuffle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Draw();

        if (count >= 24)
        {
            GameOver = true;
            Debug.Log("Game Over! You have no more balls left to play with." + GameOver);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Swapping();
        }

        if (list2.Count != 0) UISwap();
    }

    private void Shuffle()
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject temp;
            temp = list[i];
            int rand = Random.Range(i, list.Count);
            list[i] = list[rand];
            list[rand] = temp;
        }
    }

    private void Draw()
    {
        GameOver = false;
        GameObject gameObject = GameObject.FindWithTag("Player");
        Shooting = FindFirstObjectByType<Shooting_S>();
        if (gameObject == null)
        {
            if (count < list.Count && list[count] != null && Shooting.spawnCheck)
            {
                if (list2.Count == 0)
                {
                    prefab = list[count];
                    list2.Add(prefab);
                    GameObject instance = Instantiate(prefab, GameObject.Find("Start Point").transform.position, Quaternion.identity);
                    instance.tag = "Player";
                    for (int i = 1; i < 4 && count < list.Count; i++)
                    {
                        list2.Add(list[count++]);
                        Debug.Log("Number" + count);
                    }

                    UISwap();
                }
                else if (list2[swapCount] != null)
                {
                    if (list2.Count == 0) return;

                    list2.RemoveAt(swapCount);

                    // Make sure swapCount is valid now
                    if (list2.Count == 0) return; // Nothing to swap to

                    swapCount %= list2.Count; // Stay within bounds

                    // Spawn the new one
                    prefab = list2[swapCount];
                    GameObject pawn = Instantiate(prefab, GameObject.Find("Start Point").transform.position, Quaternion.identity);

                }
            }
            else return;
        }
       
    }

    private void Swapping()
    {
        if(Shooting.swap)
        {
            GameObject gameObject = GameObject.FindWithTag("Player");

            if (list2.Count == 0) return;

            swapCount = (swapCount + 1) % list2.Count;
            prefab = list2[swapCount];

            if (Shooting.ballsUsed > 4)
            {
                list2.Clear();
                swapCount = 0;
                return;
            }

            if (gameObject != null)
            {
                Destroy(gameObject);
            }

            GameObject pawn = Instantiate(prefab, GameObject.Find("Start Point").transform.position, Quaternion.identity);
            UISwap();
        }
    }

    private void UISwap()   
    {
        for (int i = 0; i < images.Length;i++)
        {
            int imageIndex = (swapCount + i + 1) % list2.Count;

            if (i + 1 >= list2.Count)
            {
                images[i].enabled = false;
                continue;
            }

            if (list2[imageIndex] != null)
            {
                Sprite sprite = list2[imageIndex].GetComponent<SpriteRenderer>()?.sprite;
                if (sprite != null)
                {
                    images[i].sprite = sprite;
                    images[i].enabled = true;
                }
                else
                {
                    images[i].enabled = false;
                }
            }
            else
            {
                images[i].enabled = false;
            }
        }
    }
}
