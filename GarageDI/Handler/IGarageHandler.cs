using GarageDI.DTO;
using GarageDI.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GarageDI.Handler
{
    public interface IGarageHandler
    {
        bool IsGarageFull { get; }

        bool Park(IVehicle v);
        IVehicle GetVehicle((IVehicle, PropertyInfo[]) vehicleProp);
        IVehicle Get(string regNo);
        List<VehicleCountDTO> GetByType();
        List<IVehicle> GetAll();
        bool Leave(string regNo);
        IEnumerable<IVehicle> SearchVehicle((IVehicle, PropertyInfo[]) vehicleProp);
    }
}
