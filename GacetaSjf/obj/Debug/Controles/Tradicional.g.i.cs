﻿#pragma checksum "..\..\..\Controles\Tradicional.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "34DAE679C067AB47BBA66C50836677FB"
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
using Telerik.Windows.Controls.DragDrop;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls.Legend;
using Telerik.Windows.Controls.Primitives;
using Telerik.Windows.Controls.RibbonView;
using Telerik.Windows.Controls.TransitionEffects;
using Telerik.Windows.Controls.TreeListView;
using Telerik.Windows.Controls.TreeView;
using Telerik.Windows.Data;
using Telerik.Windows.DragDrop;
using Telerik.Windows.DragDrop.Behaviors;
using Telerik.Windows.Input.Touch;
using Telerik.Windows.Shapes;


namespace GacetaSjf.Controles {
    
    
    /// <summary>
    /// Tradicional
    /// </summary>
    public partial class Tradicional : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\Controles\Tradicional.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtIus;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Controles\Tradicional.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnIncorpora;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Controles\Tradicional.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSecuencial;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Controles\Tradicional.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadComboBox CbxVolumen;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Controles\Tradicional.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadGridView GTesis;
        
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
            System.Uri resourceLocater = new System.Uri("/GacetaSjf;component/controles/tradicional.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controles\Tradicional.xaml"
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
            
            #line 8 "..\..\..\Controles\Tradicional.xaml"
            ((GacetaSjf.Controles.Tradicional)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TxtIus = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.BtnIncorpora = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Controles\Tradicional.xaml"
            this.BtnIncorpora.Click += new System.Windows.RoutedEventHandler(this.BtnIncorpora_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnSecuencial = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\Controles\Tradicional.xaml"
            this.BtnSecuencial.Click += new System.Windows.RoutedEventHandler(this.BtnSecuencial_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CbxVolumen = ((Telerik.Windows.Controls.RadComboBox)(target));
            
            #line 65 "..\..\..\Controles\Tradicional.xaml"
            this.CbxVolumen.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbxVolumen_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.GTesis = ((Telerik.Windows.Controls.RadGridView)(target));
            
            #line 75 "..\..\..\Controles\Tradicional.xaml"
            this.GTesis.SelectionChanged += new System.EventHandler<Telerik.Windows.Controls.SelectionChangeEventArgs>(this.GTesis_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 75 "..\..\..\Controles\Tradicional.xaml"
            this.GTesis.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.GTesis_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

