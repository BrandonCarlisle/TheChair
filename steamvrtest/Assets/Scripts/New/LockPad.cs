using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPad : MonoBehaviour
{
    [SerializeField]
    private List<int> m_combination;

    [SerializeField]
    private GameObject m_door;

    [SerializeField]
    private AudioSource m_wrongAudio;

    private List<int> combinationInput;

    private int combinationLength = 0;

    // Start is called before the first frame update
    void Start()
    {
        combinationInput = new List<int>(3);
        for (int i = 0; i < m_combination.Count; i++)
            combinationInput.Add(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(combinationLength == m_combination.Count)
        {
            Debug.Log("Calling CheckCombination...");
            CheckCombination();
        }
    }

    public void InputNumber(int value)
    {
        Debug.Log(value + " was Pressed");
        combinationInput[combinationLength] = value;
        combinationLength++;
    }

    void UnlockCupboard()
    {
        Debug.Log("Cupboard unlocked!");
        m_door.SetActive(false);
    }

    public void ClearCombination()
    {
        combinationLength = 0;

        combinationInput.Clear();
        for (int i = 0; i < m_combination.Count; i++)
            combinationInput.Add(0);
    }

    void CheckCombination()
    {
        bool combinationEqual = true;

        Debug.Log("The user combination containts: " + combinationInput[0] + ", " + combinationInput[1] + ", " + combinationInput[2]);

        for (int i = 0; i < m_combination.Count; i++)
        {
            if (m_combination[i] != combinationInput[i])
            {
                combinationEqual = false;
            }
        }
        if (combinationEqual)
        {
            Debug.Log("The combination is correct!");

            UnlockCupboard();
            ClearCombination();
        }
        else
        {
            Debug.Log("The combination is wrong.");

            //Play negative sound
            m_wrongAudio.Play();
            ClearCombination();
        }
    }
}
