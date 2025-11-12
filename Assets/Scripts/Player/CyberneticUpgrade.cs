
using UnityEngine;

[CreateAssetMenu(menuName = "EclipseGenesis/CyberneticUpgrade")]
public class CyberneticUpgrade : ScriptableObject
{
    public string upgradeName = "Implante não nomeado";
    [TextArea]
    public string description;

    public int healthBonus = 0;
    public int damageBonus = 0;
    public float speedMultiplier = 1f;
}
