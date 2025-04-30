using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentMonitoring.Domain.Errors
{
    public static class UnitIdentificationCodeErrors
    {
        public static Error CodeDoesNotHaveSeparator =>
            new Error("Unit code must have \"-\" as a separator.");

        public static Error CodeDoesNotStartsWithLetters =>
            new Error("The left part of the code must be letters.");

        public static Error CodeDoesNotEndsWithNumbers =>
            new Error("The left part of the code must be letters.");

    }
}
