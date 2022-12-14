using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // Prefab



    public GameObject itemCoinPrefab;
    public GameObject itemPowerPrefab;
    public GameObject itemSpecialMovePrefab;

    public GameObject bulletSpecialMovePrefab;
    public GameObject bulletObjA_Prefab;
    public GameObject bulletObjB_Prefab;
    public GameObject bulletObjC_Prefab;
    public GameObject bulletObjD_Prefab;
    public GameObject bulletFollow_Prefab;

    // Enemy

    // Item
    GameObject[] itemCoin;
    GameObject[] itemPower;
    GameObject[] itemSpecialMove;

    // Bullet
    GameObject[] bulletSpecialMove;
    GameObject[] bulletObjA;
    GameObject[] bulletObjB;
    GameObject[] bulletObjC;
    GameObject[] bulletObjD;
    GameObject[] bulletFollow;

    GameObject[] targetPool;

    private void Awake()
    {
        itemCoin = new GameObject[30];
        itemPower = new GameObject[10];
        itemSpecialMove = new GameObject[10];

        bulletSpecialMove = new GameObject[100];
        bulletObjA = new GameObject[100];
        bulletObjB = new GameObject[100];
        bulletObjC = new GameObject[100];
        bulletObjD = new GameObject[100];
        bulletFollow = new GameObject[100];

        Generate();

    }

    void Generate()
    {
        // Enemy

        // Item
        for(int index = 0; index < itemCoin.Length; index++)
        {
            itemCoin[index] = Instantiate(itemCoinPrefab);
            itemCoin[index].SetActive(false);
        }
        for (int index = 0; index < itemPower.Length; index++)
        {
            itemPower[index] = Instantiate(itemPowerPrefab);
            itemPower[index].SetActive(false);

        }
        for (int index = 0; index < itemSpecialMove.Length; index++)
        {
            itemSpecialMove[index] = Instantiate(itemSpecialMovePrefab);
            itemSpecialMove[index].SetActive(false);
        }

        // Bullet
        for (int index = 0; index < bulletSpecialMove.Length; index++)
        {
            bulletSpecialMove[index] = Instantiate(bulletSpecialMovePrefab);
            bulletSpecialMove[index].SetActive(false);

        }

        for (int index = 0; index < bulletObjA.Length; index++)
        {
            bulletObjA[index] = Instantiate(bulletObjA_Prefab);
            bulletObjA[index].SetActive(false);

        }

        for (int index = 0; index < bulletObjB.Length; index++)
        {
            bulletObjB[index] = Instantiate(bulletObjB_Prefab);
            bulletObjB[index].SetActive(false);

        }

        for (int index = 0; index < bulletObjC.Length; index++)
        {
            bulletObjC[index] = Instantiate(bulletObjC_Prefab);
            bulletObjC[index].SetActive(false);

        }

        for (int index = 0; index < bulletObjD.Length; index++)
        {
            bulletObjD[index] = Instantiate(bulletObjD_Prefab);
            bulletObjD[index].SetActive(false);

        }

        for (int index = 0; index < bulletFollow.Length; index++)
        {
            bulletFollow[index] = Instantiate(bulletFollow_Prefab);
            bulletFollow[index].SetActive(false);
        }

    }

    public GameObject MakeObj(string type)
    {
        
        switch (type)
        {
            case "itemCoin":
                targetPool = itemCoin;
                break;
            case "itemPower":
                targetPool = itemPower;
                break;
            case "itemSpecialMove":
                targetPool = itemSpecialMove;
                break;

            case "bulletSpecialMove":
                targetPool = bulletSpecialMove;
                break;
            case "bulletObjA":
                targetPool = bulletObjA;
                break;
            case "bulletObjB":
                targetPool = bulletObjB;

                break;
            case "bulletObjC":
                targetPool = bulletObjC;

                break;
            case "bulletObjD":
                targetPool = bulletObjD;

                break;
            case "bulletFollow":
                targetPool = bulletFollow;

                break;
        }

        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }

        return null;
    }

}
