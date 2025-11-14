using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Painéis/UI")]
    public Slider lifeBar;

    private void Awake()
    {
        Instance = this;
    }

    public void AtualizarVida(int vidaAtual, int vidaMaxima)
    {
        float porcentagem = (float)vidaAtual / vidaMaxima;
        lifeBar.value = porcentagem;
    }
}

