using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;


namespace Helthy_Shop.Data.ViewModels
{
    public class RequiredListAttribute : ValidationAttribute, IClientModelValidator
    {
        public RequiredListAttribute()
        {
            ErrorMessage = "Выберите хотя бы одну диету";
        }

        public override bool IsValid(object value)
        {
            if (value is IEnumerable list)
            {
                foreach (var item in list)
                {
                    // Если хотя бы один элемент присутствует, считаем поле заполненным
                    return true;
                }
            }
            return false;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-requiredlist", ErrorMessage);
        }

        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }
            attributes.Add(key, value);
            return true;
        }
    }
}
