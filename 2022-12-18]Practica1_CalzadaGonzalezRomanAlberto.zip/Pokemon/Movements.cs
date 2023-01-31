﻿using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Pokemon
{
    class Movements
    {
        string category;
        string name;
        int ID;
        int pp;
        int power;
        int accuracy;
        int priority;

        public Movements(string category, string name, int iD, int pp, int power,int accuracy , int priority)
        {
            this.category = category;
            this.name = name;
            ID = iD;
            this.pp = pp;
            this.power = power;
            this.accuracy = accuracy;
            this.priority = priority;
        }

        
        //Getters y Setters de los atributos.
        public string GetCategory()
        {
            return category;
        }

        public void SetCategory(string value)
        {
            category = value;
        }
       
        public string GetName()
        {
            return name;
        }

        public void SetName(string value)
        {
            name = value;
        }

        public int GetID()
        {
            return ID;
        }

        public void SetID(int value)
        {
            ID = value;
        }

        public int GetPp()
        {
            return pp;
        }

        public int GetPpMax()
        {
            return pp;
        }

        public void SetPp(int value)
        {
            pp = value;
        }

        public int GetPower()
        {
            return power;
        }

        public void SetPower(int value)
        {
            power = value;
        }

        public int GetAccuracy()
        {
            return accuracy;
        }

        public void SetAccuracy(int value)
        {
            accuracy = value;
        }
        public int CalculateAccuracy() //Calcular precisión de un movimiento.
        {
            Random random = new Random();
            int randomAccuracy= random.Next(0,101);
            return randomAccuracy;
        }

        public int GetPriority()
        {
            return priority;
        }

        public void SetPriority(int value)
        {
            priority = value;
        }
    }
}
