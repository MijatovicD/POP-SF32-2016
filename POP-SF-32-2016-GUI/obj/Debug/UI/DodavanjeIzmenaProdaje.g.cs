﻿#pragma checksum "..\..\..\UI\DodavanjeIzmenaProdaje.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2665188C90670E9DED168E70F4BB2DADC4B1EA00"
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
    /// DodavanjeIzmenaProdaje
    /// </summary>
    public partial class DodavanjeIzmenaProdaje : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\UI\DodavanjeIzmenaProdaje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dDatumProdaje;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\UI\DodavanjeIzmenaProdaje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbKupac;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\UI\DodavanjeIzmenaProdaje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbCena;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\UI\DodavanjeIzmenaProdaje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgNamestajP;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\UI\DodavanjeIzmenaProdaje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgUslugaP;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-SF-32-2016-GUI;component/ui/dodavanjeizmenaprodaje.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\DodavanjeIzmenaProdaje.xaml"
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
            this.dDatumProdaje = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            
            #line 17 "..\..\..\UI\DodavanjeIzmenaProdaje.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SacuvajIzmene);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbKupac = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.lbCena = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            
            #line 20 "..\..\..\UI\DodavanjeIzmenaProdaje.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dgNamestajP = ((System.Windows.Controls.DataGrid)(target));
            
            #line 21 "..\..\..\UI\DodavanjeIzmenaProdaje.xaml"
            this.dgNamestajP.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dgNamestajP_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dgUslugaP = ((System.Windows.Controls.DataGrid)(target));
            
            #line 22 "..\..\..\UI\DodavanjeIzmenaProdaje.xaml"
            this.dgUslugaP.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dgUslugaP_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 24 "..\..\..\UI\DodavanjeIzmenaProdaje.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Dodaj_Uslugu);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 25 "..\..\..\UI\DodavanjeIzmenaProdaje.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IzbrisiNamestaj);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 26 "..\..\..\UI\DodavanjeIzmenaProdaje.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IzbrisiUslugu);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

