﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "90D0F23315195E969C637FD690CF087EF018DB63421B1C52C0ACB64579480057"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AirSpaceTrouvetto;
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


namespace AirSpaceTrouvetto {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AirSpaceTrouvetto.MainWindow MainWindows;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Menu_Open;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Menu_SaveAs;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Menu_Print;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Menu_Flp_QuickEdit;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_AltMax;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_DistMax;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Remove;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Add;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListView_SectorList;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label_CursorAltitude;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label_CursorDistance;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas Canvas_graph;
        
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
            System.Uri resourceLocater = new System.Uri("/AirSpaceTrouvetto;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.MainWindows = ((AirSpaceTrouvetto.MainWindow)(target));
            return;
            case 2:
            this.Menu_Open = ((System.Windows.Controls.MenuItem)(target));
            
            #line 12 "..\..\MainWindow.xaml"
            this.Menu_Open.Click += new System.Windows.RoutedEventHandler(this.OpenFile);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Menu_SaveAs = ((System.Windows.Controls.MenuItem)(target));
            
            #line 13 "..\..\MainWindow.xaml"
            this.Menu_SaveAs.Click += new System.Windows.RoutedEventHandler(this.Menu_SaveAs_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Menu_Print = ((System.Windows.Controls.MenuItem)(target));
            
            #line 14 "..\..\MainWindow.xaml"
            this.Menu_Print.Click += new System.Windows.RoutedEventHandler(this.Menu_Print_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Menu_Flp_QuickEdit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 17 "..\..\MainWindow.xaml"
            this.Menu_Flp_QuickEdit.Click += new System.Windows.RoutedEventHandler(this.Menu_Flp_QuickEdit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TextBox_AltMax = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\MainWindow.xaml"
            this.TextBox_AltMax.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_AltMax_LostFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TextBox_DistMax = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\MainWindow.xaml"
            this.TextBox_DistMax.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_DistMax_LostFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Button_Remove = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\MainWindow.xaml"
            this.Button_Remove.Click += new System.Windows.RoutedEventHandler(this.Button_Remove_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Button_Add = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\MainWindow.xaml"
            this.Button_Add.Click += new System.Windows.RoutedEventHandler(this.Button_Add_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ListView_SectorList = ((System.Windows.Controls.ListView)(target));
            
            #line 35 "..\..\MainWindow.xaml"
            this.ListView_SectorList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ListView_SectorList_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Label_CursorAltitude = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.Label_CursorDistance = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.Canvas_graph = ((System.Windows.Controls.Canvas)(target));
            
            #line 52 "..\..\MainWindow.xaml"
            this.Canvas_graph.Loaded += new System.Windows.RoutedEventHandler(this.OnLoad);
            
            #line default
            #line hidden
            
            #line 52 "..\..\MainWindow.xaml"
            this.Canvas_graph.SizeChanged += new System.Windows.SizeChangedEventHandler(this.OnSizeChanged);
            
            #line default
            #line hidden
            
            #line 52 "..\..\MainWindow.xaml"
            this.Canvas_graph.MouseMove += new System.Windows.Input.MouseEventHandler(this.Canevas_graph_MouseMove);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

