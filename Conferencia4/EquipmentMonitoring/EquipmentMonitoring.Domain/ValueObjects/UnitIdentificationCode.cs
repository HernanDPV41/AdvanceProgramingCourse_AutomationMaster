using EquipmentMonitoring.Domain.Common;
using EquipmentMonitoring.Domain.Errors;
using EquipmentMonitoring.Domain.Rules;
using FluentResults;
using System.Text.RegularExpressions;

namespace EquipmentMonitoring.Domain.ValueObjects
{
    /// <summary>
    /// Código de identificación de una unidad.
    /// </summary>
    public class UnitIdentificationCode
        : ValueObject
    {
        public string Value { get; }

        /// <summary>
        /// Requerido por EF.
        /// </summary>
        private UnitIdentificationCode() { }

        private UnitIdentificationCode(
            string value)
        {
            Value = value;
        }

        public static Result<UnitIdentificationCode> Create(string value)
        {
            var result = CheckRules(
                new CodeMustHaveSeparator(value));
            if (result.IsFailed)
                return result.ToResult<UnitIdentificationCode>();

            result = CheckRules(
                new CodeMustStartWithLetters(value), 
                new CodeMustEndWithNumbers(value));
            if(result.IsFailed)
                return result.ToResult<UnitIdentificationCode>();

            return Result.Ok(new UnitIdentificationCode(value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            return new[] { Value };
        }
    }
}
