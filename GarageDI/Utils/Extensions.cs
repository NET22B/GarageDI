using GarageDI.Attributes;
using GarageDI.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace GarageDI.Utils
{
   public static class Extensions
    {
        public static (IVehicle, PropertyInfo[]) GetInstanceAndPropsForType(this VehicleType vehicleType)
        {
           
            Type type = Type.GetType($"GarageDI.Entities.{vehicleType}", throwOnError: true);

            var vehicle = (IVehicle)Activator.CreateInstance(type);
            var properties = vehicle.GetPropertiesWithIncludedAttribute();

            return (vehicle, properties);
        } 

        public static PropertyInfo[] GetPropertiesWithIncludedAttribute<T>(this T type)  where T : IVehicle
        {
                 return type.GetType()
                            .GetProperties()
                            .Where(p => p.GetCustomAttribute(typeof(Include)) != null)
                            .OrderBy(p => ((Include)p.GetCustomAttribute(typeof(Include))).Order)
                            .ToArray();
        }

        public static string GetDisplayText(this PropertyInfo prop)
        {
            var attr = prop.GetCustomAttribute<Beautify>();
            return attr is null ? prop.Name : attr.Text;
        }

        //Not Used!
        //Just testing
        public static Dictionary<PropertyInfo, string> GetProps2(this VehicleType vehicleType)
        {
            var dict = new Dictionary<PropertyInfo, string>();

            var type = Type.GetType($"GarageDI.Entities.{vehicleType}");
            if (type is null) return null;
            var vehicle = (Vehicle)Activator.CreateInstance(type);

            var properties = vehicle.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var attrs = prop.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    if(attr is Beautify beauty)
                    {
                        dict.Add(prop, beauty.Text);
                    }
                }
            }
            return dict;
        }
    }
}
  
