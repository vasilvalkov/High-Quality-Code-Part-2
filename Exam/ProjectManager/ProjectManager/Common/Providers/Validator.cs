using ProjectManager.Common.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ProjectManager.Common.Providers
{
    public class Validator
    {
        public static void Validate<T>(T obj) where T : class
        {
            IEnumerable<string> errors = GetValidationErrors(obj);

            if (errors.Count() > 0)
            {
                throw new UserValidationException(errors.First());
            }
        }

        private static IEnumerable<string> GetValidationErrors(object obj)
        {
            Type t = obj.GetType();
            PropertyInfo[] p = t.GetProperties();
            Type attrType = typeof(ValidationAttribute);

            foreach (var propertyInfo in p)
            {
                object[] customAttributes = propertyInfo.GetCustomAttributes(attrType, inherit: true);
                foreach (var customAttribute in customAttributes)
                {
                    var validationAttribute = (ValidationAttribute)customAttribute;

                    bool valid = validationAttribute.IsValid(propertyInfo.GetValue(obj, BindingFlags.GetProperty, null, null, null));

                    if (!valid)
                    {
                        yield return validationAttribute.ErrorMessage;
                    }
                }
            }
        }
    }
}