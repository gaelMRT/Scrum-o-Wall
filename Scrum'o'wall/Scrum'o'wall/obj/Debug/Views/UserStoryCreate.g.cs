﻿#pragma checksum "..\..\..\Views\UserStoryCreate.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6265ACDB20B29E23EEC91B306AC65D8B27CEFC1B7EF2B9EC805366220575B42C"
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
    /// UserStoryCreate
    /// </summary>
    public partial class UserStoryCreate : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\Views\UserStoryCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxDesc;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Views\UserStoryCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpckrDateLimit;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Views\UserStoryCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxComplexity;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Views\UserStoryCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxPriority;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\UserStoryCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxType;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Views\UserStoryCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirm;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Views\UserStoryCreate.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Scrum_o_wall;component/views/userstorycreate.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\UserStoryCreate.xaml"
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
            this.tbxDesc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.dtpckrDateLimit = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.tbxComplexity = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\..\Views\UserStoryCreate.xaml"
            this.tbxComplexity.KeyDown += new System.Windows.Input.KeyEventHandler(this.tbxComplexity_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbxPriority = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.cbxType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.btnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\Views\UserStoryCreate.xaml"
            this.btnConfirm.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnConfirm_Click);
            
            #line default
            #line hidden
            
            #line 40 "..\..\..\Views\UserStoryCreate.xaml"
            this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.btnConfirm_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Views\UserStoryCreate.xaml"
            this.btnCancel.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnCancel_Click);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\Views\UserStoryCreate.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

