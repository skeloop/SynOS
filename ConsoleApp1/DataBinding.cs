using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SynOS
{
    // Methoden um Klassen, Enums, Structs zu analysieren. 
    public class DataBinding
    {
        public object data;
        public DynamicData dynamicData;

        public static string[] GetVariableNames(object obj)
        {
            // Ermittlung des Typs der Instanz
            Type type = obj.GetType();

            // Ermittlung aller Feldnamen
            var fieldNames = type.GetFields(BindingFlags.Public | BindingFlags.Instance)
                                 .Select(field => field.Name);

            // Ermittlung aller Eigenschaftsnamen
            var propertyNames = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                    .Select(prop => prop.Name);

            // Kombination von Feld- und Eigenschaftsnamen in einem Array
            return fieldNames.Concat(propertyNames).ToArray();
        }

        public static string GetInstanceName(object obj)
        {
            return "Class: " + obj.GetType().Name;
        }
    }
    // Soll Dynanische Werte speichern und bereitstellen
    public class DynamicData : DataBinding
    {
        public static List<string> GetDynamicDataVariableNames(object obj)
        {
            List<string> dynamicDataVariableNames = new List<string>();

            Type type = obj.GetType();

            // Ermittlung aller Feldnamen vom Typ DynamicData
            var fieldNames = type.GetFields(BindingFlags.Public | BindingFlags.Instance)
                                 .Where(field => field.FieldType == typeof(DynamicData))
                                 .Select(field => field.Name);

            // Ermittlung aller Eigenschaftsnamen vom Typ DynamicData
            var propertyNames = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                    .Where(prop => prop.PropertyType == typeof(DynamicData))
                                    .Select(prop => prop.Name);

            // Hinzufügen der gefundenen Namen zur Liste
            dynamicDataVariableNames.AddRange(fieldNames);
            dynamicDataVariableNames.AddRange(propertyNames);

            return dynamicDataVariableNames;
        }

    }
}
