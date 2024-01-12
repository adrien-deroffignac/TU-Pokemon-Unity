using System;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Définition d'un personnage
    /// </summary>
    public class Character 
    {
        /// <summary>
        /// Stat de base, HP
        /// </summary>
        int _baseHealth;
        /// <summary>
        /// Stat de base, ATK
        /// </summary>
        int _baseAttack;
        /// <summary>
        /// Stat de base, DEF
        /// </summary>
        int _baseDefense;
        /// <summary>
        /// Stat de base, SPE
        /// </summary>
        int _baseSpeed;
        /// <summary>
        /// Type de base
        /// </summary>
        TYPE _baseType;
        int _equipHealth; 
        int _equipAttack;
        int _equipDefense;
        int _equipSpeed;

        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType)
        {
            _baseHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;
            CurrentHealth = MaxHealth;
            CurrentEquipment = null;
            UpdateStats();
        }
        /// <summary>
        /// HP actuel du personnage
        /// </summary>
        public int CurrentHealth { get; private set;}
        public TYPE BaseType { get => _baseType;}

        /// <summary>
        /// HPMax, prendre en compte base et equipement potentiel
        /// </summary>
        public int MaxHealth
        {
            get
            {
                return _equipHealth + _baseHealth;
            }
        }

        /// <summary>
        /// ATK, prendre en compte base et equipement potentiel
        /// </summary>
        public int Attack
        {
        
            get
            {
               return _equipAttack + _baseAttack;
                
            }
        }

        /// <summary>
        /// DEF, prendre en compte base et equipement potentiel
        /// </summary>
        public int Defense
        {
            get
            {
                return _equipDefense+ _baseDefense;
                
            }
        }

        /// <summary>
        /// SPE, prendre en compte base et equipement potentiel
        /// </summary>
        public int Speed
        {
            
            get
            {
                return _equipSpeed + _baseSpeed;
                
            }
        }

        /// <summary>
        /// Equipement unique du personnage
        /// </summary>
        public Equipment CurrentEquipment { get; private set; }
        /// <summary>
        /// null si pas de status
        /// </summary>
        public StatusEffect CurrentStatus { get; private set; }

        public bool IsAlive => CurrentHealth > 0;


        /// <summary>
        /// Application d'un skill contre le personnage
        /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
        /// Vous pouvez adapter au besoin
        /// </summary>
        /// <param name="s">skill attaquant</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ReceiveAttack(Skill s)
        {
            if (s.Power < 0 && CurrentHealth < MaxHealth)
            {
                CurrentHealth += s.Power;
                if(CurrentHealth > MaxHealth)
                {
                    CurrentHealth = MaxHealth;
                }
            }
            else if(s.Power > 0)
            {
                CurrentHealth -= s.Power - Defense;
            }
            if(CurrentHealth <= 0)
            {
                CurrentHealth = 0;
            }
           
        }
        /// <summary>
        /// Equipe un objet au personnage
        /// </summary>
        /// <param name="newEquipment">equipement a appliquer</param>
        /// <exception cref="ArgumentNullException">Si equipement est null</exception>
        public void Equip(Equipment newEquipment)
        {
            if(newEquipment == null)
            {
                throw new ArgumentNullException();
            }
            _equipHealth = newEquipment.BonusHealth;
            _equipAttack = newEquipment.BonusAttack;
            _equipDefense = newEquipment.BonusDefense;
            _equipSpeed = newEquipment.BonusSpeed;
            CurrentEquipment = newEquipment;
            UpdateStats();
        }
        /// <summary>
        /// Desequipe l'objet en cours au personnage
        /// </summary>
        public void Unequip()
        {
            
            
            _equipHealth = 0;
            _equipAttack = 0;
            _equipDefense = 0;
            _equipSpeed = 0;
            CurrentEquipment = null;
            UpdateStats();
        }
        private void UpdateStats()
        {
            if(MaxHealth < CurrentHealth)
            {
                CurrentHealth = MaxHealth;
            }
        }

    }
}
