using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : TDMonoBehaviour
{
    private static BuildManager instance;
    public static BuildManager Instance=>instance;

    [Header("References")]
    [SerializeField] protected List<Tower> towers;

    private int selectedTower = 0;
    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.Log("Just allow 1 BuildManager exists");
        instance = this;
    }

    public Tower getSelectedTower()
    {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        this.selectedTower = _selectedTower;
    }
}
