using System.Windows;
using System.Windows.Controls;

namespace AssemblyDataParser.WPF.View
{
    /// <summary>
    /// Логика взаимодействия для AssemblyDataView.xaml
    /// </summary>
    public partial class AssemblyDataView : UserControl
    {
        public AssemblyDataView()
        {
            InitializeComponent();
        }

        #region LibraryNameVisibility : bool - Show Library name

        /// <summary>Show Library name</summary>
        public static readonly DependencyProperty LibraryNameVisibilityProperty =
            DependencyProperty.Register(
                nameof(LibraryNameVisibility),
                typeof(bool),
                typeof(AssemblyDataView),
                new PropertyMetadata(true));

        /// <summary>Show Library name</summary>
        public bool LibraryNameVisibility { get => (bool) GetValue(LibraryNameVisibilityProperty); set => SetValue(LibraryNameVisibilityProperty, value); }

        #endregion

        #region VersionVisibility : bool - Show Version

        /// <summary>Show Version</summary>
        public static readonly DependencyProperty VersionVisibilityProperty =
            DependencyProperty.Register(
                nameof(VersionVisibility),
                typeof(bool),
                typeof(AssemblyDataView),
                new PropertyMetadata(true));

        /// <summary>Show Version</summary>
        public bool VersionVisibility { get => (bool) GetValue(VersionVisibilityProperty); set => SetValue(VersionVisibilityProperty, value); }

        #endregion

        #region BuildFromVisibility : bool - Show from (build time)

        /// <summary>Show from (build time)</summary>
        public static readonly DependencyProperty BuildFromVisibilityProperty =
            DependencyProperty.Register(
                nameof(BuildFromVisibility),
                typeof(bool),
                typeof(AssemblyDataView),
                new PropertyMetadata(true));

        /// <summary>Show from (build time)</summary>
        public bool BuildFromVisibility { get => (bool) GetValue(BuildFromVisibilityProperty); set => SetValue(BuildFromVisibilityProperty, value); }

        #endregion

        #region BuildAtVisibility : bool - Show Build at section

        /// <summary>Show Build at section</summary>
        public static readonly DependencyProperty BuildAtVisibilityProperty =
            DependencyProperty.Register(
                nameof(BuildAtVisibility),
                typeof(bool),
                typeof(AssemblyDataView),
                new PropertyMetadata(true));

        /// <summary>Show Build at section</summary>
        public bool BuildAtVisibility { get => (bool) GetValue(BuildAtVisibilityProperty); set => SetValue(BuildAtVisibilityProperty, value); }

        #endregion

        #region FileVersionVisibility : bool - Show File Version

        /// <summary>Show File Version</summary>
        public static readonly DependencyProperty FileVersionVisibilityProperty =
            DependencyProperty.Register(
                nameof(FileVersionVisibility),
                typeof(bool),
                typeof(AssemblyDataView),
                new PropertyMetadata(true));

        /// <summary>Show File Version</summary>
        public bool FileVersionVisibility { get => (bool) GetValue(FileVersionVisibilityProperty); set => SetValue(FileVersionVisibilityProperty, value); }

        #endregion

        #region ProjectVisibility : bool - Show Project/Product info

        /// <summary>Show Project/Product info</summary>
        public static readonly DependencyProperty ProjectVisibilityProperty =
            DependencyProperty.Register(
                nameof(ProjectVisibility),
                typeof(bool),
                typeof(AssemblyDataView),
                new PropertyMetadata(true));

        /// <summary>Show Project/Product info</summary>
        public bool ProjectVisibility { get => (bool) GetValue(ProjectVisibilityProperty); set => SetValue(ProjectVisibilityProperty, value); }

        #endregion

        #region TrademarkVisibility : bool - Show TradeMark

        /// <summary>Show TradeMark</summary>
        public static readonly DependencyProperty TrademarkVisibilityProperty =
            DependencyProperty.Register(
                nameof(TrademarkVisibility),
                typeof(bool),
                typeof(AssemblyDataView),
                new PropertyMetadata(true));

        /// <summary>Show TradeMark</summary>
        public bool TrademarkVisibility { get => (bool) GetValue(TrademarkVisibilityProperty); set => SetValue(TrademarkVisibilityProperty, value); }

        #endregion

        #region CompanyVisibility : bool - Show Company

        /// <summary>Show Company</summary>
        public static readonly DependencyProperty CompanyVisibilityProperty =
            DependencyProperty.Register(
                nameof(CompanyVisibility),
                typeof(bool),
                typeof(AssemblyDataView),
                new PropertyMetadata(true));

        /// <summary>Show Company</summary>
        public bool CompanyVisibility { get => (bool) GetValue(CompanyVisibilityProperty); set => SetValue(CompanyVisibilityProperty, value); }

        #endregion

        #region Copyright : bool - Show Copyright

        /// <summary>Show Copyright</summary>
        public static readonly DependencyProperty CopyrightVisibilityProperty =
            DependencyProperty.Register(
                nameof(CopyrightVisibility),
                typeof(bool),
                typeof(AssemblyDataView),
                new PropertyMetadata(true));

        /// <summary>Show Copyright</summary>
        public bool CopyrightVisibility { get => (bool) GetValue(CopyrightVisibilityProperty); set => SetValue(CopyrightVisibilityProperty, value); }

        #endregion

        #region ConfigurationVisibility : bool - Show Configuration

        /// <summary>Show Configuration</summary>
        public static readonly DependencyProperty ConfigurationVisibilityProperty =
            DependencyProperty.Register(
                nameof(ConfigurationVisibility),
                typeof(bool),
                typeof(AssemblyDataView),
                new PropertyMetadata(false));

        /// <summary>Show Configuration</summary>
        public bool ConfigurationVisibility { get => (bool) GetValue(ConfigurationVisibilityProperty); set => SetValue(ConfigurationVisibilityProperty, value); }

        #endregion

        #region DescriptionVisibility : bool - Show Description

        /// <summary>Show Description</summary>
        public static readonly DependencyProperty DescriptionVisibilityProperty =
            DependencyProperty.Register(
                nameof(DescriptionVisibility),
                typeof(bool),
                typeof(AssemblyDataView),
                new PropertyMetadata(true));

        /// <summary>Show Description</summary>
        public bool DescriptionVisibility { get => (bool) GetValue(DescriptionVisibilityProperty); set => SetValue(DescriptionVisibilityProperty, value); }

        #endregion
    }
}
