using _2023_GC_A2_Partiel_POO.Level_2;
using NUnit.Framework;
using System;
namespace _2023_GC_A2_Partiel_POO.Tests.Level_2
{
    public class FightMoreTests
    {
        // Tu as probablement remarqué qu'il y a encore beaucoup de code qui n'a pas été testé ...
        // À présent c'est à toi de créer les TU sur le reste et de les implémenter
        
        // Ce que tu peux ajouter:
        // - Ajouter davantage de sécurité sur les tests apportés
            // - un heal ne régénère pas plus que les HP Max
            // - si on abaisse les HPMax les HP courant doivent suivre si c'est au dessus de la nouvelle valeur
            // - ajouter un equipement qui rend les attaques prioritaires puis l'enlever et voir que l'attaque n'est plus prioritaire etc)
        // - Le support des status (sleep et burn) qui font des effets à la fin du tour et/ou empeche le pkmn d'agir
        // - Gérer la notion de force/faiblesse avec les différentes attaques à disposition (skills.cs)
        // - Cumuler les force/faiblesses en ajoutant un type pour l'équipement qui rendrait plus sensible/résistant à un type
        [Test]
        public void HealMax()
        {
            Character pikachu = new Character(100, 50, 30, 20, TYPE.NORMAL);
            Character mewtwo = new Character(1000, 500, 300, 200, TYPE.NORMAL);            
            Fight f = new Fight(pikachu, mewtwo);
            Heal heal = new Heal();
            
            f.ExecuteTurn(heal, heal);
            Assert.That(pikachu.CurrentHealth, Is.EqualTo(100));
            Assert.That(mewtwo.CurrentHealth, Is.EqualTo(1000));
        }
        [Test]
        public void HealMarche()
        {
            Character mewtwo = new Character(1000, 1, 300, 200, TYPE.NORMAL);  
            Character pikachu = new Character(200, 50, 30, 20, TYPE.NORMAL);
            Fight f = new Fight(pikachu, mewtwo);
            Heal heal = new Heal();
            Punch punch = new Punch();
            
            f.ExecuteTurn(punch, heal);
            Assert.That(pikachu.CurrentHealth, Is.EqualTo(200));
        }

        [Test]
        public void StatusEffectMarchent()
        {
            Character mewtwo = new Character(1000, 1, 300, 200, TYPE.NORMAL);  
            Character pikachu = new Character(200, 50, 30, 20, TYPE.NORMAL);
            Fight f = new Fight(pikachu, mewtwo);
            MagicalGrass g = new MagicalGrass();
            
            f.ExecuteTurn(g, g);
            Assert.That
        }
    }
}
