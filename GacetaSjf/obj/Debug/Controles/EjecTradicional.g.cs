﻿#pragma checksum "..\..\..\Controles\EjecTradicional.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6F6E98BF9EDD5D9574DCB42EF4C1AA9C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;
using Telerik.Windows.Controls.Carousel;
using Telerik.Windows.Controls.Docking;
using Telerik.Windows.Controls.DragDrop;
using Telerik.Windows.Controls.FixedDocumentViewersUI;
using Telerik.Windows.Controls.GanttView;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls.Legend;
using Telerik.Windows.Controls.Primitives;
using Telerik.Windows.Controls.RibbonView;
using Telerik.Windows.Controls.Scheduling;
using Telerik.Windows.Controls.TransitionEffects;
using Telerik.Windows.Controls.TreeListView;
using Telerik.Windows.Controls.TreeView;
using Telerik.Windows.Data;
using Telerik.Windows.Documents.Model;
using Telerik.Windows.DragDrop;
using Telerik.Windows.DragDrop.Behaviors;
using Telerik.Windows.Input.Touch;
using Telerik.Windows.Rendering;
using Telerik.Windows.Shapes;


namespace GacetaSjf.Controles {
    
    
    /// <summary>
    /// EjecTradicional
    /// </summary>
    public partial class EjecTradicional : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\Controles\EjecTradicional.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSecuencial;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Controles\EjecTradicional.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtIus;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Controles\EjecTradicional.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnIncorpora;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Controles\EjecTradicional.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadGridView GEjecutoria;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GacetaSjf;component/controles/ejectradicional.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controles\EjecTradicional.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\Controles\EjecTradicional.xaml"
            ((GacetaSjf.Controles.EjecTradicional)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnSecuencial = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Controles\EjecTradicional.xaml"
            this.BtnSecuencial.Click += new System.Windows.RoutedEventHandler(this.BtnSecuencial_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TxtIus = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.BtnIncorpora = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\Controles\EjecTradicional.xaml"
            this.BtnIncorpora.Click += new System.Windows.RoutedEventHandler(this.BtnIncorpora_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.GEjecutoria = ((Telerik.Windows.Controls.RadGridView)(target));
            
            #line 67 "..\..\..\Controles\EjecTradicional.xaml"
            this.GEjecutoria.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.GEjecutoria_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 69 "..\..\..\Controles\EjecTradicional.xaml"
            this.GEjecutoria.SelectionChanged += new System.EventHandler<Telerik.Windows.Controls.SelectionChangeEventArgs>(this.GEjecutoria_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
