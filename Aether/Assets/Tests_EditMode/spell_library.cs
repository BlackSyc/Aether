using System.Collections;
using System.Collections.Generic;
using Aether.Spells;
using Aether.Spells.ScriptableObjects;
using NSubstitute;
using NUnit.Framework;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class spell_library
    {
        [Test]
        public void active_spell_changes_when_set()
        {
            // ARRANGE
            SpellLibrary spellLibrary = new SpellLibrary();
            Spell spell1 = ScriptableObject.CreateInstance<Spell>();
            Spell spell2 = ScriptableObject.CreateInstance<Spell>();

            Spell latestActiveSpell = null;
            spellLibrary.OnActiveSpellChanged += x => latestActiveSpell = x;


            // ACT
            spellLibrary.Add(spell1);
            spellLibrary.Add(spell2);


            // ASSERT
            Assert.AreNotEqual(spell1, spellLibrary.ActiveSpell);
            Assert.AreEqual(spell2, spellLibrary.ActiveSpell);
            Assert.AreEqual(spell2, latestActiveSpell);
        }

        [Test]
        public void active_spell_changes_to_null_when_set()
        {
            // ARRANGE
            SpellLibrary spellLibrary = new SpellLibrary();
            Spell spell = null;

            Spell latestActiveSpell = ScriptableObject.CreateInstance<Spell>();
            spellLibrary.OnActiveSpellChanged += x => latestActiveSpell = x;

            // ACT
            spellLibrary.Add(spell);

            // ASSERT
            Assert.AreEqual(spell, spellLibrary.ActiveSpell);
            Assert.IsNull(latestActiveSpell);
        }

        [Test]
        public void active_spell_changes_to_null_when_spell_is_removed()
        {
            // ARRANGE
            SpellLibrary spellLibrary = new SpellLibrary();
            Spell spell = ScriptableObject.CreateInstance<Spell>();

            Spell latestActiveSpell = spell;
            spellLibrary.OnActiveSpellChanged += x => latestActiveSpell = x;

            spellLibrary.Add(spell);


            // ACT
            spellLibrary.Remove(spell);


            // ASSERT
            Assert.IsNull(latestActiveSpell);
            Assert.IsNull(spellLibrary.ActiveSpell);
        }

        [Test]
        public void spell_is_added_to_library_when_active_spell_is_set()
        {
            // ARRANGE
            SpellLibrary spellLibrary = new SpellLibrary();
            Spell spell1 = ScriptableObject.CreateInstance<Spell>();
            Spell spell2 = ScriptableObject.CreateInstance<Spell>();

            // ACT
            spellLibrary.Add(spell1);
            spellLibrary.Add(spell2);

            // ASSERT
            Assert.IsTrue(spellLibrary.Contains(spell1));
            Assert.IsTrue(spellLibrary.Contains(spell2));
        }

        [Test]
        public void spell_is_added_to_library_when_spell_is_added()
        {
            // ARRANGE
            SpellLibrary spellLibrary = new SpellLibrary();
            Spell spell1 = ScriptableObject.CreateInstance<Spell>();
            Spell spell2 = ScriptableObject.CreateInstance<Spell>();

            // ACT
            spellLibrary.Add(spell1, false);
            spellLibrary.Add(spell2, false);

            // ASSERT
            Assert.IsNull(spellLibrary.ActiveSpell);
            Assert.IsTrue(spellLibrary.Contains(spell1));
            Assert.IsTrue(spellLibrary.Contains(spell2));
        }

        [Test]
        public void spell_is_removed_from_library_when_spell_is_removed()
        {
            // ARRANGE
            SpellLibrary spellLibrary = new SpellLibrary();
            Spell spell = ScriptableObject.CreateInstance<Spell>();
            spellLibrary.Add(spell);

            // ACT
            spellLibrary.Remove(spell);

            // ASSERT
            Assert.IsFalse(spellLibrary.Contains(spell));
        }

        [Test]
        public void cast_succeeds_with_active_spell()
        {
            // ARRANGE
            SpellLibrary spellLibrary = new SpellLibrary();
            Spell spell = ScriptableObject.CreateInstance<Spell>();
            spellLibrary.Add(spell);

            // ACT
            bool castSuccess = spellLibrary.TryCast(out var spellCast, null, null, null, false);

            // ASSERT
            Assert.IsTrue(castSuccess);
            Assert.IsNotNull(spellCast);
        }

        [Test]
        public void cast_fails_when_active_spell_is_not_set()
        {
            // ARRANGE
            SpellLibrary spellLibrary = new SpellLibrary();

            // ACT
            bool castSuccess = spellLibrary.TryCast(out var spellCast, null, null, null, false);

            // ASSERT
            Assert.IsFalse(castSuccess);
            Assert.IsNull(spellCast);
        }

        [Test]
        public void cast_fails_when_library_is_on_cooldown()
        {
            // ARRANGE
            ISpellLibrary spellLibrary = new SpellLibrary(10f);
            Spell spell = ScriptableObject.CreateInstance<Spell>();
            spellLibrary.Add(spell);

            // ACT
            bool castSuccess = spellLibrary.TryCast(out var spellCast, null, null, null, false);

            // ASSERT
            Assert.IsFalse(castSuccess);
            Assert.IsNull(spellCast);
        }
    }
}
