using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject kael;
    public GameObject hattori;
    public GameObject volkan;

    private GameObject currentCharacter;

    private void Start()
    {
        TrocarPara(kael);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            TrocarPara(kael);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            TrocarPara(hattori);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            TrocarPara(volkan);
    }

    void TrocarPara(GameObject personagem)
    {
        if (currentCharacter != null)
            currentCharacter.SetActive(false);

        currentCharacter = personagem;
        currentCharacter.SetActive(true);
    }
}
