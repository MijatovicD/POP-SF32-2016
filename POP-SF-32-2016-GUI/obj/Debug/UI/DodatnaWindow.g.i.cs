﻿#pragma checksum "..\..\..\UI\DodatnaWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5E1CF7A86963C913E35179529C8424DA70667FEA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using POP_SF_32_2016_GUI.UI;
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


namespace POP_SF_32_2016_GUI.UI {
    
    
    /// <summary>
    /// DodatnaWindow
    /// </summary>
    public partial class DodatnaWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\UI\DodatnaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgUsluga;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\UI\DodatnaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPretraga;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\UI\DodatnaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbSortiraj;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-SF-32-2016-GUI;component/ui/dodatnawindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\DodatnaWindow.xaml"
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
            this.dgUsluga = ((System.Windows.Controls.DataGrid)(target));
            
            #line 14 "..\..\..\UI\DodatnaWindow.xaml"
            this.dgUsluga.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dgUsluga_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 15 "..\..\..\UI\DodatnaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DodajUslugu_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 16 "..\..\..\UI\DodatnaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IzmeniUslugu_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 17 "..\..\..\UI\DodatnaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Izbrsi_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 18 "..\..\..\UI\DodatnaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Zatvori_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tbPretraga = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\..\UI\DodatnaWindow.xaml"
            this.tbPretraga.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbPretraga_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cbSortiraj = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\UI\DodatnaWindow.xaml"
            this.cbSortiraj.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbSortiraj_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

