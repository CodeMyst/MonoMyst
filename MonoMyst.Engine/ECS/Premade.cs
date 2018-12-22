using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using YamlDotNet.Serialization;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization.NamingConventions;

namespace MonoMyst.Engine.ECS
{
    public class Premade
    {
        public static Entity Create (string premadePath)
        {
            Entity result = null;

            using (StreamReader sr = new StreamReader (premadePath))
            {
                YamlStream yaml = new YamlStream ();
                yaml.Load (sr);

                YamlMappingNode mapping = (YamlMappingNode) yaml.Documents [0].RootNode;

                string entityName = mapping.Children [new YamlScalarNode ("Name")].ToString ();
                
                result = new Entity (entityName);

                List<Type> monomystComponents = Assembly.GetExecutingAssembly ().GetTypes ().Where (t => t.IsComponent () && !t.IsInterface && !t.IsAbstract).ToList ();
                List<Type> gameComponents = Assembly.GetEntryAssembly ().GetTypes ().Where (t => t.IsComponent () && !t.IsInterface && !t.IsAbstract).ToList ();
                IEnumerable<Type> allComponentTypes = monomystComponents.Concat (gameComponents);

                YamlSequenceNode components = (YamlSequenceNode) mapping.Children [new YamlScalarNode ("Components")];
                foreach (YamlMappingNode component in components)
                {
                    string componentTypeName = component.Children [new YamlScalarNode ("Type")].ToString ();

                    Type componentType = allComponentTypes.First (t => t.Name == componentTypeName);

                    Component entityComponent = result.AddComponent (componentType);

                    PropertyInfo [] componentProperties = componentType.GetProperties ();

                    foreach (KeyValuePair<YamlNode, YamlNode> property in component.Children)
                    {
                        if (property.Key.ToString () == "Type") continue;

                        PropertyInfo componentProperty = componentProperties.First (c => c.Name == property.Key.ToString ());
                        if (componentProperty.PropertyType == typeof (Vector2))
                            SetVector2Value (entityComponent, componentProperty, (YamlMappingNode) property.Value);
                        else if (componentProperty.PropertyType == typeof (Texture2D))
                            SetTexture2DValue (entityComponent, componentProperty, property.Value);
                        else if (componentProperty.PropertyType == typeof (Color))
                            SetColorValue (entityComponent, componentProperty, property.Value);
                        else if (componentProperty.PropertyType == typeof (Dictionary<string, Texture2D>))
                            SetStringTexture2DMapValue (entityComponent, componentProperty, (YamlSequenceNode) property.Value);
                        else if (componentProperty.PropertyType.IsPrimitive || componentProperty.PropertyType == typeof (string))
                            SetPrimitiveValue (entityComponent, componentProperty, property.Value);
                        else
                            System.Console.WriteLine($"Type {componentProperty.PropertyType.Name} isn't supported as a Premade type yet.");
                    }
                }
            }

            return result;
        }

        private static void SetPrimitiveValue (Component component, PropertyInfo property, YamlNode yamlNode)
        {
            property.SetValue (component, Convert.ChangeType (yamlNode.ToString (), property.PropertyType));
        }

        private static void SetVector2Value (Component component, PropertyInfo property, YamlMappingNode yamlNode)
        {
            float x = float.Parse (yamlNode.Children [new YamlScalarNode ("X")].ToString ());
            float y = float.Parse (yamlNode.Children [new YamlScalarNode ("Y")].ToString ());
            Vector2 res = new Vector2 (x, y);
            property.SetValue (component, res);
        }

        private static void SetTexture2DValue (Component component, PropertyInfo property, YamlNode yamlNode)
        {
            string spriteName = yamlNode.ToString ();

            // TODO: (#5) Need a better way to handle this
            if (spriteName == "MonoMyst/Rectangle")
            {
                property.SetValue (component, MGame.GraphicUtilities.Rectangle);
                return;
            }

            ContentManager content = MGame.GameServices.GetService<ContentManager> ();
            
            Texture2D res = content.Load<Texture2D> (spriteName);
            property.SetValue (component, res);
        }

        private static void SetColorValue (Component component, PropertyInfo property, YamlNode yamlNode)
        {
            PropertyInfo colorInfo = typeof (Color).GetProperty (yamlNode.ToString ());
            Color res = (Color) colorInfo.GetValue (null, null);
            property.SetValue (component, res);
        }

        private static void SetStringTexture2DMapValue (Component component, PropertyInfo property, YamlSequenceNode yamlNode)
        {
            ContentManager content = MGame.GameServices.GetService<ContentManager> ();

            Dictionary<string, Texture2D> res = new Dictionary<string, Texture2D> ();

            foreach (YamlNode element in yamlNode.Children)
            {
                YamlMappingNode mappingNode = (YamlMappingNode) element;
                foreach (var node in mappingNode)
                {
                    res.Add (node.Key.ToString (), content.Load<Texture2D> (node.Value.ToString ()));
                }
            }

            property.SetValue (component, res);
        }
    }
}