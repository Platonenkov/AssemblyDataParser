using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using AssemblyDataParser.WPF.Annotations;

namespace AssemblyDataParser.WPF.Converters.Base
{
    [MarkupExtensionReturnType(typeof(ValueConverter))]
    public abstract class ValueConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider sp) => this;

        public abstract object Convert(object v, [NotNull] Type t, object p, [NotNull] CultureInfo c);

        public virtual object ConvertBack(object v, [NotNull] Type t, object p, [NotNull] CultureInfo c) => throw new NotSupportedException();
    }
}
