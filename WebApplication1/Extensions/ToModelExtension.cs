﻿using System;
using System.Linq;
using System.Reflection;

namespace WebApplication1.Extensions
{
    public static class ToModelExtension
    {
        public static object PropertyValueExtensionMethod<TEntity, TModel>(this TEntity entityObject)
        {
            Type modelType = typeof(TModel);
            PropertyInfo[] modelProperties = modelType.GetProperties();
            object? modelObject = Activator.CreateInstance(modelType);

            foreach (PropertyInfo modelProperty in modelProperties)
            {
                PropertyInfo entityPropertyInfo = entityObject.GetType().GetProperty(modelProperty.Name);
                if (entityPropertyInfo.Name == modelProperty.Name && entityPropertyInfo.PropertyType == modelProperty.PropertyType)
                {
                    object value = entityPropertyInfo.GetValue(entityObject);
                    Type propertyType = modelProperty.PropertyType;

                    modelProperty.SetValue(modelObject, Convert.ChangeType(value, propertyType));
                }
            }
            return modelObject;
        }
    }
}

