﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.5420
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 2.0.50727.5420 版自动生成。
// 
#pragma warning disable 1591

namespace THOK.Services.DzInspurWarehouseOperationService {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WarehouseOperationServiceSoapBinding", Namespace="http://10.89.128.22:9080/L3/services/WarehouseOperationService")]
    public partial class WarehouseOperationServiceService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ScanNewBillOperationCompleted;
        
        private System.Threading.SendOrPostCallback HitShelfOperationCompleted;
        
        private System.Threading.SendOrPostCallback HitShelfConfirmOperationCompleted;
        
        private System.Threading.SendOrPostCallback HitShelfConfirmSJOperationCompleted;
        
        private System.Threading.SendOrPostCallback StockTakeOperationCompleted;
        
        private System.Threading.SendOrPostCallback StockTakeConfirmOperationCompleted;
        
        private System.Threading.SendOrPostCallback StockMoveOperationCompleted;
        
        private System.Threading.SendOrPostCallback StockMoveConfirmOperationCompleted;
        
        private System.Threading.SendOrPostCallback StockOutOperationCompleted;
        
        private System.Threading.SendOrPostCallback StockOutConfirmOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WarehouseOperationServiceService() {
            this.Url = global::THOK.Services.Properties.Settings.Default.THOK_Services_DzInspurWarehouseOperationService_WarehouseOperationServiceService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ScanNewBillCompletedEventHandler ScanNewBillCompleted;
        
        /// <remarks/>
        public event HitShelfCompletedEventHandler HitShelfCompleted;
        
        /// <remarks/>
        public event HitShelfConfirmCompletedEventHandler HitShelfConfirmCompleted;
        
        /// <remarks/>
        public event HitShelfConfirmSJCompletedEventHandler HitShelfConfirmSJCompleted;
        
        /// <remarks/>
        public event StockTakeCompletedEventHandler StockTakeCompleted;
        
        /// <remarks/>
        public event StockTakeConfirmCompletedEventHandler StockTakeConfirmCompleted;
        
        /// <remarks/>
        public event StockMoveCompletedEventHandler StockMoveCompleted;
        
        /// <remarks/>
        public event StockMoveConfirmCompletedEventHandler StockMoveConfirmCompleted;
        
        /// <remarks/>
        public event StockOutCompletedEventHandler StockOutCompleted;
        
        /// <remarks/>
        public event StockOutConfirmCompletedEventHandler StockOutConfirmCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://chinasofti.webItfc.l3.lc.com", ResponseNamespace="http://10.89.128.22:9080/L3/services/WarehouseOperationService")]
        [return: System.Xml.Serialization.SoapElementAttribute("ScanNewBillReturn")]
        public string ScanNewBill() {
            object[] results = this.Invoke("ScanNewBill", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ScanNewBillAsync() {
            this.ScanNewBillAsync(null);
        }
        
        /// <remarks/>
        public void ScanNewBillAsync(object userState) {
            if ((this.ScanNewBillOperationCompleted == null)) {
                this.ScanNewBillOperationCompleted = new System.Threading.SendOrPostCallback(this.OnScanNewBillOperationCompleted);
            }
            this.InvokeAsync("ScanNewBill", new object[0], this.ScanNewBillOperationCompleted, userState);
        }
        
        private void OnScanNewBillOperationCompleted(object arg) {
            if ((this.ScanNewBillCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ScanNewBillCompleted(this, new ScanNewBillCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://chinasofti.webItfc.l3.lc.com", ResponseNamespace="http://10.89.128.22:9080/L3/services/WarehouseOperationService")]
        [return: System.Xml.Serialization.SoapElementAttribute("HitShelfReturn")]
        public string HitShelf(string voucherNum) {
            object[] results = this.Invoke("HitShelf", new object[] {
                        voucherNum});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HitShelfAsync(string voucherNum) {
            this.HitShelfAsync(voucherNum, null);
        }
        
        /// <remarks/>
        public void HitShelfAsync(string voucherNum, object userState) {
            if ((this.HitShelfOperationCompleted == null)) {
                this.HitShelfOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHitShelfOperationCompleted);
            }
            this.InvokeAsync("HitShelf", new object[] {
                        voucherNum}, this.HitShelfOperationCompleted, userState);
        }
        
        private void OnHitShelfOperationCompleted(object arg) {
            if ((this.HitShelfCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HitShelfCompleted(this, new HitShelfCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://chinasofti.webItfc.l3.lc.com", ResponseNamespace="http://10.89.128.22:9080/L3/services/WarehouseOperationService")]
        [return: System.Xml.Serialization.SoapElementAttribute("HitShelfConfirmReturn")]
        public string HitShelfConfirm(string Param) {
            object[] results = this.Invoke("HitShelfConfirm", new object[] {
                        Param});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HitShelfConfirmAsync(string Param) {
            this.HitShelfConfirmAsync(Param, null);
        }
        
        /// <remarks/>
        public void HitShelfConfirmAsync(string Param, object userState) {
            if ((this.HitShelfConfirmOperationCompleted == null)) {
                this.HitShelfConfirmOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHitShelfConfirmOperationCompleted);
            }
            this.InvokeAsync("HitShelfConfirm", new object[] {
                        Param}, this.HitShelfConfirmOperationCompleted, userState);
        }
        
        private void OnHitShelfConfirmOperationCompleted(object arg) {
            if ((this.HitShelfConfirmCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HitShelfConfirmCompleted(this, new HitShelfConfirmCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://chinasofti.webItfc.l3.lc.com", ResponseNamespace="http://10.89.128.22:9080/L3/services/WarehouseOperationService")]
        [return: System.Xml.Serialization.SoapElementAttribute("HitShelfConfirmSJReturn")]
        public string HitShelfConfirmSJ(string Param) {
            object[] results = this.Invoke("HitShelfConfirmSJ", new object[] {
                        Param});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HitShelfConfirmSJAsync(string Param) {
            this.HitShelfConfirmSJAsync(Param, null);
        }
        
        /// <remarks/>
        public void HitShelfConfirmSJAsync(string Param, object userState) {
            if ((this.HitShelfConfirmSJOperationCompleted == null)) {
                this.HitShelfConfirmSJOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHitShelfConfirmSJOperationCompleted);
            }
            this.InvokeAsync("HitShelfConfirmSJ", new object[] {
                        Param}, this.HitShelfConfirmSJOperationCompleted, userState);
        }
        
        private void OnHitShelfConfirmSJOperationCompleted(object arg) {
            if ((this.HitShelfConfirmSJCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HitShelfConfirmSJCompleted(this, new HitShelfConfirmSJCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://chinasofti.webItfc.l3.lc.com", ResponseNamespace="http://10.89.128.22:9080/L3/services/WarehouseOperationService")]
        [return: System.Xml.Serialization.SoapElementAttribute("StockTakeReturn")]
        public string StockTake(string checkNum) {
            object[] results = this.Invoke("StockTake", new object[] {
                        checkNum});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void StockTakeAsync(string checkNum) {
            this.StockTakeAsync(checkNum, null);
        }
        
        /// <remarks/>
        public void StockTakeAsync(string checkNum, object userState) {
            if ((this.StockTakeOperationCompleted == null)) {
                this.StockTakeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnStockTakeOperationCompleted);
            }
            this.InvokeAsync("StockTake", new object[] {
                        checkNum}, this.StockTakeOperationCompleted, userState);
        }
        
        private void OnStockTakeOperationCompleted(object arg) {
            if ((this.StockTakeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.StockTakeCompleted(this, new StockTakeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://chinasofti.webItfc.l3.lc.com", ResponseNamespace="http://10.89.128.22:9080/L3/services/WarehouseOperationService")]
        [return: System.Xml.Serialization.SoapElementAttribute("StockTakeConfirmReturn")]
        public string StockTakeConfirm(string Param) {
            object[] results = this.Invoke("StockTakeConfirm", new object[] {
                        Param});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void StockTakeConfirmAsync(string Param) {
            this.StockTakeConfirmAsync(Param, null);
        }
        
        /// <remarks/>
        public void StockTakeConfirmAsync(string Param, object userState) {
            if ((this.StockTakeConfirmOperationCompleted == null)) {
                this.StockTakeConfirmOperationCompleted = new System.Threading.SendOrPostCallback(this.OnStockTakeConfirmOperationCompleted);
            }
            this.InvokeAsync("StockTakeConfirm", new object[] {
                        Param}, this.StockTakeConfirmOperationCompleted, userState);
        }
        
        private void OnStockTakeConfirmOperationCompleted(object arg) {
            if ((this.StockTakeConfirmCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.StockTakeConfirmCompleted(this, new StockTakeConfirmCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://chinasofti.webItfc.l3.lc.com", ResponseNamespace="http://10.89.128.22:9080/L3/services/WarehouseOperationService")]
        [return: System.Xml.Serialization.SoapElementAttribute("StockMoveReturn")]
        public string StockMove(string storeMoveId) {
            object[] results = this.Invoke("StockMove", new object[] {
                        storeMoveId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void StockMoveAsync(string storeMoveId) {
            this.StockMoveAsync(storeMoveId, null);
        }
        
        /// <remarks/>
        public void StockMoveAsync(string storeMoveId, object userState) {
            if ((this.StockMoveOperationCompleted == null)) {
                this.StockMoveOperationCompleted = new System.Threading.SendOrPostCallback(this.OnStockMoveOperationCompleted);
            }
            this.InvokeAsync("StockMove", new object[] {
                        storeMoveId}, this.StockMoveOperationCompleted, userState);
        }
        
        private void OnStockMoveOperationCompleted(object arg) {
            if ((this.StockMoveCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.StockMoveCompleted(this, new StockMoveCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://chinasofti.webItfc.l3.lc.com", ResponseNamespace="http://10.89.128.22:9080/L3/services/WarehouseOperationService")]
        [return: System.Xml.Serialization.SoapElementAttribute("StockMoveConfirmReturn")]
        public string StockMoveConfirm(string Param) {
            object[] results = this.Invoke("StockMoveConfirm", new object[] {
                        Param});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void StockMoveConfirmAsync(string Param) {
            this.StockMoveConfirmAsync(Param, null);
        }
        
        /// <remarks/>
        public void StockMoveConfirmAsync(string Param, object userState) {
            if ((this.StockMoveConfirmOperationCompleted == null)) {
                this.StockMoveConfirmOperationCompleted = new System.Threading.SendOrPostCallback(this.OnStockMoveConfirmOperationCompleted);
            }
            this.InvokeAsync("StockMoveConfirm", new object[] {
                        Param}, this.StockMoveConfirmOperationCompleted, userState);
        }
        
        private void OnStockMoveConfirmOperationCompleted(object arg) {
            if ((this.StockMoveConfirmCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.StockMoveConfirmCompleted(this, new StockMoveConfirmCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://chinasofti.webItfc.l3.lc.com", ResponseNamespace="http://10.89.128.22:9080/L3/services/WarehouseOperationService")]
        [return: System.Xml.Serialization.SoapElementAttribute("StockOutReturn")]
        public string StockOut(string storeOutId) {
            object[] results = this.Invoke("StockOut", new object[] {
                        storeOutId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void StockOutAsync(string storeOutId) {
            this.StockOutAsync(storeOutId, null);
        }
        
        /// <remarks/>
        public void StockOutAsync(string storeOutId, object userState) {
            if ((this.StockOutOperationCompleted == null)) {
                this.StockOutOperationCompleted = new System.Threading.SendOrPostCallback(this.OnStockOutOperationCompleted);
            }
            this.InvokeAsync("StockOut", new object[] {
                        storeOutId}, this.StockOutOperationCompleted, userState);
        }
        
        private void OnStockOutOperationCompleted(object arg) {
            if ((this.StockOutCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.StockOutCompleted(this, new StockOutCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://chinasofti.webItfc.l3.lc.com", ResponseNamespace="http://10.89.128.22:9080/L3/services/WarehouseOperationService")]
        [return: System.Xml.Serialization.SoapElementAttribute("StockOutConfirmReturn")]
        public string StockOutConfirm(string Param) {
            object[] results = this.Invoke("StockOutConfirm", new object[] {
                        Param});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void StockOutConfirmAsync(string Param) {
            this.StockOutConfirmAsync(Param, null);
        }
        
        /// <remarks/>
        public void StockOutConfirmAsync(string Param, object userState) {
            if ((this.StockOutConfirmOperationCompleted == null)) {
                this.StockOutConfirmOperationCompleted = new System.Threading.SendOrPostCallback(this.OnStockOutConfirmOperationCompleted);
            }
            this.InvokeAsync("StockOutConfirm", new object[] {
                        Param}, this.StockOutConfirmOperationCompleted, userState);
        }
        
        private void OnStockOutConfirmOperationCompleted(object arg) {
            if ((this.StockOutConfirmCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.StockOutConfirmCompleted(this, new StockOutConfirmCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void ScanNewBillCompletedEventHandler(object sender, ScanNewBillCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ScanNewBillCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ScanNewBillCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void HitShelfCompletedEventHandler(object sender, HitShelfCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HitShelfCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HitShelfCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void HitShelfConfirmCompletedEventHandler(object sender, HitShelfConfirmCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HitShelfConfirmCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HitShelfConfirmCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void HitShelfConfirmSJCompletedEventHandler(object sender, HitShelfConfirmSJCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HitShelfConfirmSJCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HitShelfConfirmSJCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void StockTakeCompletedEventHandler(object sender, StockTakeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class StockTakeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal StockTakeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void StockTakeConfirmCompletedEventHandler(object sender, StockTakeConfirmCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class StockTakeConfirmCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal StockTakeConfirmCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void StockMoveCompletedEventHandler(object sender, StockMoveCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class StockMoveCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal StockMoveCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void StockMoveConfirmCompletedEventHandler(object sender, StockMoveConfirmCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class StockMoveConfirmCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal StockMoveConfirmCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void StockOutCompletedEventHandler(object sender, StockOutCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class StockOutCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal StockOutCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void StockOutConfirmCompletedEventHandler(object sender, StockOutConfirmCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class StockOutConfirmCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal StockOutConfirmCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591