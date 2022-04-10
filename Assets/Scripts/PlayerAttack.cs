using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    [Header("Main Settings")]
    public GameObject projectilePrefab;
    public GameObject muzzleFlash;
    public GameObject muzzlePosition;
    public TextMeshProUGUI ammoText;
    public int ammoMax;
    private int ammoCurrent;

    public GameManager gameManager;
    public SoundManager soundManager;

    public void Fire()
    {
        if (!gameManager.onPause)
        {
            if (!gameManager.onPause || !gameManager.isGameOver)
            {
                if (ammoCurrent > 0)
                {
                    ammoCurrent--;
                    ammoText.text = ammoCurrent.ToString() + "/" + ammoMax.ToString();
                    GameObject projectile = GameObject.Instantiate(projectilePrefab, muzzlePosition.transform.position, muzzlePosition.transform.rotation);
                    GameObject flash = GameObject.Instantiate(muzzleFlash, muzzlePosition.transform.position, muzzlePosition.transform.rotation);
                    soundManager.shootSound();
                }
            }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        ammoText.text = ammoCurrent.ToString() + "/" + ammoMax.ToString();
        //gameManager = FindObjectOfType<GameManager>();
    }

    private void Awake()
    {
        ammoCurrent = ammoMax;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0) && !gameManager.onPause)
        //{
        //    if (!gameManager.onPause || !gameManager.isGameOver)
        //    {
        //        if (ammoCurrent > 0)
        //        {
        //            ammoCurrent--;
        //            ammoText.text = ammoCurrent.ToString() + "/" + ammoMax.ToString();
        //            Fire();
        //        }
        //    }
        //}
    }

    public void addAmmo()
    {
        ammoCurrent = Mathf.Clamp(ammoCurrent + 25, 0, ammoMax);
        ammoText.text = ammoCurrent.ToString() + "/" + ammoMax.ToString();
    }
}
