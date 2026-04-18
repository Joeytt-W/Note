using Core.Entity.DBEntity;
using Core.Entity.Dto;
using Core.Entity.Enum;
using Core.Service.Hepler;
using Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Service.Services
{
    public class PropertyMappingService : IPropertyMappingService
    {
        private readonly Dictionary<string, PropertyMappingValue> _userPropertyMapping =
            new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
            {
                {"ID", new PropertyMappingValue(new List<string>{"ID"}) },
                {"UserName", new PropertyMappingValue(new List<string>{"UserName"}) },
                {"UserCode", new PropertyMappingValue(new List<string>{"UserCode"}) },
                {"Password", new PropertyMappingValue(new List<string>{"Password"}) },
                {"Sex", new PropertyMappingValue(new List<string>{"Sex"}) },
                {"Phone", new PropertyMappingValue(new List<string>{"Phone"}) },
                {"Email", new PropertyMappingValue(new List<string>{"Email"}) },
                {"BirthDate", new PropertyMappingValue(new List<string>{"BirthDate"}) },
                {"CreateTime", new PropertyMappingValue(new List<string>{"CreateTime"}) },
                {"Spell", new PropertyMappingValue(new List<string>{"Spell"}) },
                {"DepartmentID", new PropertyMappingValue(new List<string>{ "DepartmentID"})}
            };


        private readonly IList<IPropertyMapping> _propertyMappings = new List<IPropertyMapping>();

        public PropertyMappingService()
        {
            _propertyMappings.Add(new PropertyMapping<User, User>(_userPropertyMapping));
        }

        public Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>()
        {
            var matchingMapping = _propertyMappings.OfType<PropertyMapping<TSource, TDestination>>();

            var propertyMappings = matchingMapping.ToList();
            if (propertyMappings.Count == 1)
            {
                return propertyMappings.First().MappingDictionary;
            }

            throw new Exception($"无法找到唯一的映射关系：{typeof(TSource)}, {typeof(TDestination)}");
        }

        public bool ValidMappingExistsFor<TSource, TDestination>(string fields)
        {
            var propertyMapping = GetPropertyMapping<TSource, TDestination>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                return true;
            }

            var fieldAfterSplit = fields.Split(",");
            foreach (var field in fieldAfterSplit)
            {
                var trimmedField = field.Trim();
                var indexOfFirstSpace = trimmedField.IndexOf(" ", StringComparison.Ordinal);
                var propertyName = indexOfFirstSpace == -1 ? trimmedField 
                    : trimmedField.Remove(indexOfFirstSpace);

                if (!propertyMapping.ContainsKey(propertyName))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
