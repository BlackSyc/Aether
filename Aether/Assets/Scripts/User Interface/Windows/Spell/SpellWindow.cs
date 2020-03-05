using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellWindow : MonoBehaviour
{
    [SerializeField]
    private SpellSystem spellSystem;

    [SerializeField]
    private SpellButton missiles;

    [SerializeField]
    private SpellButton spellButton2;

    [SerializeField]
    private SpellButton spellButton3;

    [SerializeField]
    private SpellButton spellButton4;

    [SerializeField]
    private SpellButton spellButton5;

    [SerializeField]
    private SpellButton spellButton6;

    [SerializeField]
    private SpellButton spellButton7;

    private void LinkSpellButtons()
    {
        missiles.LinkToSpellType(spellSystem.Missile);
        spellButton2.LinkToSpellType(spellSystem.spellType2);
        spellButton3.LinkToSpellType(spellSystem.spellType3);
        spellButton4.LinkToSpellType(spellSystem.spellType4);
        spellButton5.LinkToSpellType(spellSystem.spellType5);
        spellButton6.LinkToSpellType(spellSystem.spellType6);
        spellButton7.LinkToSpellType(spellSystem.spellType7);

    }
    void Start()
    {
        LinkSpellButtons();
    }
}
