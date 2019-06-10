using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Tizen.NUI.XamlBinding;

namespace Tizen.NUI.StyleSheets
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class Style
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Style()
        {
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, string> Declarations { get; set; } = new Dictionary<string, string>();
        Dictionary<KeyValuePair<string, string>, object> convertedValues = new Dictionary<KeyValuePair<string, string>, object>();

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Style Parse(CssReader reader, char stopChar = '\0')
        {
            Style style = new Style();
            string propertyName = null, propertyValue = null;

            int p;
            reader.SkipWhiteSpaces();
            bool readingName = true;
            while ((p = reader.Peek()) > 0) {
                switch (unchecked((char)p)) {
                case ':':
                    reader.Read();
                    readingName = false;
                    reader.SkipWhiteSpaces();
                    break;
                case ';':
                    reader.Read();
                    if (!string.IsNullOrEmpty(propertyName) && !string.IsNullOrEmpty(propertyValue))
                        style.Declarations.Add(propertyName, propertyValue);
                    propertyName = propertyValue = null;
                    readingName = true;
                    reader.SkipWhiteSpaces();
                    break;
                default:
                    if ((char)p == stopChar)
                        return style;

                    if (readingName) {
                        propertyName = reader.ReadIdent();
                        if (propertyName == null)
                            throw new Exception();
                    } else 
                        propertyValue = reader.ReadUntil(stopChar, ';', ':');
                    break;
                }
            }
            return style;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Apply(Element styleable, bool inheriting = false)
        {
            if (styleable == null)
                throw new ArgumentNullException(nameof(styleable));

            foreach (var decl in Declarations) {
                var property = ((IStylable)styleable).GetProperty(decl.Key, inheriting);
                if (property == null)
                    continue;
                if (string.Equals(decl.Value, "initial", StringComparison.OrdinalIgnoreCase))
                    styleable.ClearValue(property, fromStyle: true);
                else {
                    object value;
                    if (!convertedValues.TryGetValue(decl, out value))
                        convertedValues[decl] = (value = Convert(styleable, decl.Value, property));
                    styleable.SetValue(property, value, fromStyle: true);
                }
            }

            foreach (var child in styleable.LogicalChildrenInternal) {
                var ve = child as Element;
                if (ve == null)
                    continue;
                Apply(ve, inheriting: true);
            }
        }

        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static object Convert(object target, object value, BindableProperty property)
        {
            Func<MemberInfo> minforetriever = () =>    property.DeclaringType.GetRuntimeProperty(property.PropertyName) as MemberInfo
                                                    ?? property.DeclaringType.GetRuntimeMethod("Get" + property.PropertyName, new[] { typeof(BindableObject) }) as MemberInfo;
            var serviceProvider = new StyleSheetServiceProvider(target, property);
            // return value.ConvertTo(property.ReturnType, minforetriever, serviceProvider);
            return null;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UnApply(IStylable styleable)
        {
            throw new NotImplementedException();
        }
    }
}