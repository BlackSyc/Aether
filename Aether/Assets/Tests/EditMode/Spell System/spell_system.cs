using NUnit.Framework;
using ScriptableObjects;
using UnityEngine;

namespace Tests
{
    public class spell_system
    {
        //#region AddSpell
        //[Test]
        //public void spell_library_is_created_when_spell_is_added_to_non_existing_library()
        //{
        //    // ARRANGE
        //    GameObject testObject = new GameObject();
        //    testObject.AddComponent<PlayerTargetSystem>();
        //    SpellSystem spellSystem = testObject.AddComponent<SpellSystem>();

        //    Spell spell10 = ScriptableObject.CreateInstance<Spell>();
        //    Spell spell11 = ScriptableObject.CreateInstance<Spell>();

            
        //    // ACT
        //    spellSystem.AddSpell(10, spell10);
        //    spellSystem.AddSpell(11, spell11);


        //    // ASSERT
        //    Assert.IsNotNull(spellSystem.SpellLibraries[10]);
        //    Assert.IsNotNull(spellSystem.SpellLibraries[11]);

        //    Assert.AreEqual(spell10, spellSystem.SpellLibraries[10].ActiveSpell);
        //    Assert.AreEqual(spell11, spellSystem.SpellLibraries[11].ActiveSpell);
        //}

        //[Test]
        //public void active_spell_changes_in_library_when_spell_is_added_with_active_flag()
        //{
        //    // ARRANGE
        //    GameObject testObject = new GameObject();
        //    testObject.AddComponent<PlayerTargetSystem>();
        //    SpellSystem spellSystem = testObject.AddComponent<SpellSystem>();

        //    Spell spell1 = ScriptableObject.CreateInstance<Spell>();
        //    Spell spell2 = ScriptableObject.CreateInstance<Spell>();

        //    Spell spellFromEvent = null;


        //    // ACT
        //    spellSystem.AddSpell(0, spell1);
        //    spellSystem.OnActiveSpellChanged += x => spellFromEvent = x.ActiveSpell;
        //    spellSystem.AddSpell(0, spell2);


        //    // ASSERT
        //    Assert.AreEqual(spell2, spellFromEvent);
        //    Assert.AreEqual(spell2, spellSystem.SpellLibraries[0].ActiveSpell);
        //}
        //#endregion

        //#region RemoveSpell
        //[Test]
        //public void remove_spell_from_library_if_it_exists()
        //{
        //    // ARRANGE
        //    GameObject testObject = new GameObject();
        //    testObject.AddComponent<PlayerTargetSystem>();
        //    SpellSystem spellSystem = testObject.AddComponent<SpellSystem>();

        //    Spell spell = ScriptableObject.CreateInstance<Spell>();
        //    spellSystem.AddSpell(0, spell);

        //    Spell spellFromEvent = null;
        //    spellSystem.OnActiveSpellChanged += x => spellFromEvent = x.ActiveSpell;


        //    // ACT
        //    spellSystem.RemoveSpell(0, spell);


        //    // ASSERT
        //    Assert.IsNull(spellSystem.SpellLibraries[0].ActiveSpell);
        //    Assert.IsNull(spellFromEvent);
        //}

        //[Test]
        //public void dont_do_anything_if_library_doesnt_exist()
        //{
        //    // ARRANGE
        //    GameObject testObject = new GameObject();
        //    testObject.AddComponent<PlayerTargetSystem>();
        //    SpellSystem spellSystem = testObject.AddComponent<SpellSystem>();

        //    Spell spell = ScriptableObject.CreateInstance<Spell>();
        //    spellSystem.AddSpell(1, spell);

        //    bool eventFired = false;
        //    spellSystem.OnActiveSpellChanged += x => eventFired = true;


        //    // ACT
        //    spellSystem.RemoveSpell(0, spell);


        //    // ASSERT
        //    Assert.IsNull(spellSystem.SpellLibraries[0]);
        //    Assert.IsNotNull(spellSystem.SpellLibraries[1]);
        //    Assert.AreEqual(spell, spellSystem.SpellLibraries[1].ActiveSpell);
        //    Assert.IsFalse(eventFired);
        //}
        //#endregion

        //#region GetCombinedLayerMask
        //[Test]
        //public void layer_mask_is_empty_if_no_spells_are_active()
        //{
        //    // ARRANGE
        //    GameObject testObject = new GameObject();
        //    testObject.AddComponent<PlayerTargetSystem>();
        //    SpellSystem spellSystem = testObject.AddComponent<SpellSystem>();


        //    // ACT
        //    LayerMask result = spellSystem.GetCombinedLayerMask();


        //    // ASSERT
        //    Assert.AreEqual(new LayerMask().value, result.value);

        //}

        //[Test]
        //public void layer_mask_is_equal_to_layer_of_single_active_spell()
        //{
        //    // ARRANGE
        //    GameObject testObject = new GameObject();
        //    testObject.AddComponent<PlayerTargetSystem>();
        //    SpellSystem spellSystem = testObject.AddComponent<SpellSystem>();


        //    LayerMask layerMask = Layers.EnemyLayer;
        //    Spell spell = ScriptableObject.CreateInstance<Spell>();
        //    spell.LayerMask = layerMask;

        //    spellSystem.AddSpell(0, spell);


        //    // ACT
        //    LayerMask result = spellSystem.GetCombinedLayerMask();


        //    // ASSERT
        //    Assert.AreEqual(layerMask.value, result.value);
        //}

        //[Test]
        //public void layer_mask_is_equal_to_combined_layers_of_multiple_active_spells()
        //{
        //    // ARRANGE
        //    GameObject testObject = new GameObject();
        //    testObject.AddComponent<PlayerTargetSystem>();
        //    SpellSystem spellSystem = testObject.AddComponent<SpellSystem>();


        //    LayerMask enemyLayerMask = Layers.EnemyLayer;
        //    LayerMask friendlyLayerMask = Layers.FriendlyLayer;
        //    LayerMask combinedLayerMask = enemyLayerMask | friendlyLayerMask;

        //    LayerMask obstructionLayerMask = Layers.ObstructionLayer;


        //    Spell spell1 = ScriptableObject.CreateInstance<Spell>();
        //    spell1.LayerMask = enemyLayerMask;

        //    Spell spell2 = ScriptableObject.CreateInstance<Spell>();
        //    spell2.LayerMask = friendlyLayerMask;

        //    Spell spell3 = ScriptableObject.CreateInstance<Spell>();
        //    spell3.LayerMask = obstructionLayerMask;

        //    spellSystem.AddSpell(0, spell1);
        //    spellSystem.AddSpell(1, spell2);
        //    spellSystem.AddSpell(1, spell3, false);


        //    // ACT
        //    LayerMask result = spellSystem.GetCombinedLayerMask();


        //    // ASSERT
        //    Assert.AreEqual(combinedLayerMask.value , result.value);
        //}
        //#endregion

        //#region CastSpell
        //[Test]
        //public void cast_spell_succeeds_in_a_new_isntance_of_spellcast()
        //{
        //    //// ARRANGE
        //    //GameObject testObject = new GameObject();
        //    //SpellSystem spellSystem = testObject.AddComponent<SpellSystem>();
        //    //spellSystem.TargetSystem = Substitute.For<ITargetSystem>();
        //    //spellSystem.TargetSystem.GetCurrentTarget(new LayerMask()).Returns(new Aether.TargetSystem.ITarget(Vector3.zero));


        //    //Spell spell = ScriptableObject.CreateInstance<Spell>();

        //    //spellSystem.AddSpell(0, spell);

        //    //SpellCast result = null;

        //    //spellSystem.OnSpellIsCast += x => result = x;

        //    //// ASSERT
        //    //Assert.IsNull(result);

        //    //// ACT
        //    //spellSystem.CastSpell(0);

        //    //// ASSERT
        //    //Assert.IsNotNull(result);
        //    //Assert.AreEqual(spell, result.Spell);
        //}
        //#endregion
    }
}
