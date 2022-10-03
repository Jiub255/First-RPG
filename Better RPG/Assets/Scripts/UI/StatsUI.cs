using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public GameObject statsUI;

    public HealthSO healthSO;
    public Text healthText;
    
    public StatSO attackSO;
    public Text attackText;

    public StatSO defenseSO;
    public Text defenseText;

    public IntSO levelSO;
    public Text levelText;

    public IntSO experienceSO;
    public Text experienceText;

    // new input system stuff
    public PlayerInputActions playerControls;

    private InputAction openInventory;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        openInventory = playerControls.Player.OpenInventory;
        openInventory.Enable();
        openInventory.performed += OpenStats;
    }

    private void OnDisable()
    {
        openInventory.Disable();
    }

    void Start()
    {
        UpdateStats();
    }

    void OpenStats(InputAction.CallbackContext context)
    {
        statsUI.SetActive(!statsUI.activeSelf);
    }

    public void UpdateStats()
    {
        Debug.Log("Updating Stats UI");

        healthText.text = "Health: " + healthSO.currentHealth + " / " + healthSO.maxHealth;
        attackText.text = "Attack: " + attackSO.GetValue();
        defenseText.text = "Defense: " + defenseSO.GetValue();
        levelText.text = "Level: " + levelSO.value;
        experienceText.text = "Experience: " + experienceSO.value;
    }
}