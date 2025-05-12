using EquipmentMonitoring.Domain.Common;
using EquipmentMonitoring.Domain.Errors;
using EquipmentMonitoring.Domain.ValueObjects;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EquipmentMonitoring.Domain.Rules
{

    public record CodeMustHaveSeparator(
        string Value)
        : IBusinessRule
    {
        public Result CheckRule()
        {
            if (!Value.Contains("-"))
                return Result.Fail(UnitIdentificationCodeErrors.CodeDoesNotHaveSeparator);
            return Result.Ok();
        }
    }

    public record CodeMustStartWithLetters(
        string Value)
        : IBusinessRule
    {
        public Result CheckRule()
        {
            if (!Regex.IsMatch(Value.Split('-')[0], @"^[a-zA-Z]+$"))
                return Result.Fail(UnitIdentificationCodeErrors.CodeDoesNotStartsWithLetters);
            return Result.Ok();
        }
    }

    public record CodeMustEndWithNumbers(
        string Value)
        : IBusinessRule
    {
        public Result CheckRule()
        {
            if (int.TryParse(Value.Split('-')[0], out int result))
                return Result.Fail(UnitIdentificationCodeErrors.CodeDoesNotEndsWithNumbers);
            return Result.Ok();
        }
    }

}
