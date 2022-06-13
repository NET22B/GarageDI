using GarageDI.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace VehicleCollection
{
   public class InMemoryGarage<T> : IGarage<T> where T : IVehicle
    {
        private readonly T[] vehicles;
        private int capacity;

        public string Name { get; }
        public int Capacity => capacity;
        public int Count { get; private set; } = 0;
        public bool IsFull => Count >= Capacity;

        public InMemoryGarage(ISettings sett)
        {
            if (sett is null) throw new ArgumentNullException(nameof(ISettings));

            Name = sett.Name;
            capacity = Math.Max(0, sett.Size);
            vehicles = new T[capacity]; 
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var v in vehicles)
            {
                if (v != null) yield return v;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Park(T vehicle)
        {
            bool result = false;
            if (IsFull) return result;

            for (int i = 0; i < vehicles.Length; i++)
            {
                if(vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    result = true;
                    Count++;
                    break;
                }
            }
            return result;
        }

        public bool Leave(T vehicle)
        {
            bool result = false;
            if (vehicle is null) return result;

            var index = Array.IndexOf(vehicles, vehicle);

            if(index >= 0)
            {
                vehicles[index] = default;
                Count--;
                result = true;
            }
        
            return result;
        }
    }
}
