﻿#pragma checksum "..\..\..\Views\ChecklistCreate.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C23CF0CF92CB88F836B8373A66C4CBE3CC4D15CF4ED4F2A2F7F2DA0F591BA3A9"
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
    /// ChecklistCreate
    /// </summary>
    public partial class ChecklistCreate : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\Views\ChecklistCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxName;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Views\ChecklistCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listItems;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Views\ChecklistCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddItem;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Views\ChecklistCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\ChecklistCreate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirm;
        
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
            System.Uri resourceLocater = new System.Uri("/Scrum_o_wall;component/views/checklistcreate.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ChecklistCreate.xaml"
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
            this.tbxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.listItems = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.btnAddItem = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Views\ChecklistCreate.xaml"
            this.btnAddItem.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnAddItem_TouchDown);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\Views\ChecklistCreate.xaml"
            this.btnAddItem.Click += new System.Windows.RoutedEventHandler(this.btnAddItem_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\Views\ChecklistCreate.xaml"
            this.btnCancel.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnCancel_TouchDown);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\Views\ChecklistCreate.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Views\ChecklistCreate.xaml"
            this.btnConfirm.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btnConfirm_TouchDown);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\Views\ChecklistCreate.xaml"
            this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.btnConfirm_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

