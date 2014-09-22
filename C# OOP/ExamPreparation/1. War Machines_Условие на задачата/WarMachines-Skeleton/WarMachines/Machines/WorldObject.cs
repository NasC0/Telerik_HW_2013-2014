﻿using System;

namespace WarMachines.Machines
{
    public abstract class WorldObject
    {
        private string name;

        public WorldObject(string name)
        {
            this.Name = name;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                //if (string.IsNullOrEmpty(value))
                //{
                //    throw new ArgumentException("Name cannot be null or empty!");
                //}

                this.name = value;
            }
        }
    }
}
