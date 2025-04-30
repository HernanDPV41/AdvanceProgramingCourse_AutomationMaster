using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentMonitoring.Domain.Errors
{
    public static class NetworkAddressErrors
    {
        public static Error InvalidIPAddressFormat =>
            new Error("Invalid IP address format");

        public static Error InvalidPort =>
            new Error("Invalid port value.");

    }
}
