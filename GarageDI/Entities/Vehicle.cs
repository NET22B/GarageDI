using GarageDI.Attributes;
using GarageDI.Utils;
using System;
using System.Text;

namespace GarageDI.Entities
{
    public class Vehicle : IVehicle
    {
        private string regNo;

        public static Predicate<string> Check;
        public static Action Callback;

        public string Name { get; }


        public Vehicle()
        {
            Name = GetType().Name;
        }
        

        [Beautify("Registration number")]
        [Include(1)]
        public string RegNo
        {
            get => regNo;
            set
            {
                if ((bool)Check?.Invoke(value.ToUpper()))
                    regNo = value.ToUpper();
                else
                    Callback?.Invoke();
                return;
            }
        }

        private string color;

        [Include]
        public string Color
        {
            get { return color; }
            set { color = value.ToUpper(); }
        }

        public virtual object this[string name]
        {
            get
            {
                return this.GetType().GetProperty(name).GetValue(this);
            }
            set
            {
                this.GetType().GetProperty(name).SetValue(this, value);
            }
        }

        public virtual string Print()
        {
            var builder = new StringBuilder().Append($"[{this.GetType().Name}]\t");

            Array.ForEach(this.GetPropertiesWithIncludedAttribute(),
                           p => builder.Append($" {p.GetDisplayText()}:{p.GetValue(this)}"));

            return builder.ToString();
        }
    }
}
