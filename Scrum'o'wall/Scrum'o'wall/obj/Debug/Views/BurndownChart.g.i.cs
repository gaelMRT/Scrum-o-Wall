﻿#pragma checksum "..\..\..\Views\BurndownChart.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ED2156816850EBF3A7AE8AC01505642852F434CB4FEC58668F6492C9D358C130"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Scrum_o_wall.Views;
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


namespace Scrum_o_wall.Views {
    
    
    /// <summary>
    /// BurndownChart
    /// </summary>
    public partial class BurndownChart : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Views\BurndownChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Quit;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Views\BurndownChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Line lnIdeal;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Views\BurndownChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Polyline lnCurrent;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Views\BurndownChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDayBegin;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Views\BurndownChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDayEnd;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views\BurndownChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblComplexityMax;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Views\BurndownChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblComplexityZero;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Views\BurndownChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/Scrum_o_wall;component/views/burndownchart.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\BurndownChart.xaml"
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
            this.Quit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 13 "..\..\..\Views\BurndownChart.xaml"
            this.Quit.Click += new System.Windows.RoutedEventHandler(this.Quit_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lnIdeal = ((System.Windows.Shapes.Line)(target));
            return;
            case 3:
            this.lnCurrent = ((System.Windows.Shapes.Polyline)(target));
            return;
            case 4:
            this.lblDayBegin = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lblDayEnd = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblComplexityMax = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblComplexityZero = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Views\BurndownChart.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\Views\BurndownChart.xaml"
            this.btnCancel.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnCancel_TouchDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

