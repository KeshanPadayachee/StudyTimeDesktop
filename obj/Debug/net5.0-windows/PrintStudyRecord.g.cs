#pragma checksum "..\..\..\PrintStudyRecord.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3980CC15C807BE34751B624F7CA792A98D3C2B18"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using StudyTime;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace StudyTime {
    
    
    /// <summary>
    /// PrintStudyRecord
    /// </summary>
    public partial class PrintStudyRecord : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\PrintStudyRecord.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdBackground1;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\PrintStudyRecord.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdBackground2;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\PrintStudyRecord.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPrint;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\PrintStudyRecord.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPrintOption;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\PrintStudyRecord.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkPrintAllRecords;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\PrintStudyRecord.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbFilter;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\PrintStudyRecord.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrint;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\PrintStudyRecord.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/StudyTime;component/printstudyrecord.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PrintStudyRecord.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.grdBackground1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.grdBackground2 = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.lblPrint = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lblPrintOption = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.chkPrintAllRecords = ((System.Windows.Controls.CheckBox)(target));
            
            #line 14 "..\..\..\PrintStudyRecord.xaml"
            this.chkPrintAllRecords.Checked += new System.Windows.RoutedEventHandler(this.chkPrintAllRecords_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cmbFilter = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.btnPrint = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\PrintStudyRecord.xaml"
            this.btnPrint.Click += new System.Windows.RoutedEventHandler(this.btnPrint_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\PrintStudyRecord.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

