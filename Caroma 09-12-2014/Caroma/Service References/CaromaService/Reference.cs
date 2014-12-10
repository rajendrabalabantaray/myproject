﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Caroma.CaromaService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CaromaService.CaromaSoap")]
    public interface CaromaSoap {
        
        // CODEGEN: Generating message contract since element name _userName from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/_getAuthentication", ReplyAction="*")]
        Caroma.CaromaService._getAuthenticationResponse _getAuthentication(Caroma.CaromaService._getAuthenticationRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/_getAuthentication", ReplyAction="*")]
        System.Threading.Tasks.Task<Caroma.CaromaService._getAuthenticationResponse> _getAuthenticationAsync(Caroma.CaromaService._getAuthenticationRequest request);
        
        // CODEGEN: Generating message contract since element name _userName from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/_getProductList", ReplyAction="*")]
        Caroma.CaromaService._getProductListResponse _getProductList(Caroma.CaromaService._getProductListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/_getProductList", ReplyAction="*")]
        System.Threading.Tasks.Task<Caroma.CaromaService._getProductListResponse> _getProductListAsync(Caroma.CaromaService._getProductListRequest request);
        
        // CODEGEN: Generating message contract since element name _userName from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/_getCategoryList", ReplyAction="*")]
        Caroma.CaromaService._getCategoryListResponse _getCategoryList(Caroma.CaromaService._getCategoryListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/_getCategoryList", ReplyAction="*")]
        System.Threading.Tasks.Task<Caroma.CaromaService._getCategoryListResponse> _getCategoryListAsync(Caroma.CaromaService._getCategoryListRequest request);
        
        // CODEGEN: Generating message contract since element name query from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/_getProductTypeSearch", ReplyAction="*")]
        Caroma.CaromaService._getProductTypeSearchResponse _getProductTypeSearch(Caroma.CaromaService._getProductTypeSearchRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/_getProductTypeSearch", ReplyAction="*")]
        System.Threading.Tasks.Task<Caroma.CaromaService._getProductTypeSearchResponse> _getProductTypeSearchAsync(Caroma.CaromaService._getProductTypeSearchRequest request);
        
        // CODEGEN: Generating message contract since element name SearchText from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/_getProductSearch", ReplyAction="*")]
        Caroma.CaromaService._getProductSearchResponse _getProductSearch(Caroma.CaromaService._getProductSearchRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/_getProductSearch", ReplyAction="*")]
        System.Threading.Tasks.Task<Caroma.CaromaService._getProductSearchResponse> _getProductSearchAsync(Caroma.CaromaService._getProductSearchRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/downloadCount", ReplyAction="*")]
        void downloadCount();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/downloadCount", ReplyAction="*")]
        System.Threading.Tasks.Task downloadCountAsync();
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class _getAuthenticationRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="_getAuthentication", Namespace="http://tempuri.org/", Order=0)]
        public Caroma.CaromaService._getAuthenticationRequestBody Body;
        
        public _getAuthenticationRequest() {
        }
        
        public _getAuthenticationRequest(Caroma.CaromaService._getAuthenticationRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class _getAuthenticationRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string _userName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string _password;
        
        public _getAuthenticationRequestBody() {
        }
        
        public _getAuthenticationRequestBody(string _userName, string _password) {
            this._userName = _userName;
            this._password = _password;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class _getAuthenticationResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="_getAuthenticationResponse", Namespace="http://tempuri.org/", Order=0)]
        public Caroma.CaromaService._getAuthenticationResponseBody Body;
        
        public _getAuthenticationResponse() {
        }
        
        public _getAuthenticationResponse(Caroma.CaromaService._getAuthenticationResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class _getAuthenticationResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool _getAuthenticationResult;
        
        public _getAuthenticationResponseBody() {
        }
        
        public _getAuthenticationResponseBody(bool _getAuthenticationResult) {
            this._getAuthenticationResult = _getAuthenticationResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class _getProductListRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="_getProductList", Namespace="http://tempuri.org/", Order=0)]
        public Caroma.CaromaService._getProductListRequestBody Body;
        
        public _getProductListRequest() {
        }
        
        public _getProductListRequest(Caroma.CaromaService._getProductListRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class _getProductListRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string _userName;
        
        public _getProductListRequestBody() {
        }
        
        public _getProductListRequestBody(string _userName) {
            this._userName = _userName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class _getProductListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="_getProductListResponse", Namespace="http://tempuri.org/", Order=0)]
        public Caroma.CaromaService._getProductListResponseBody Body;
        
        public _getProductListResponse() {
        }
        
        public _getProductListResponse(Caroma.CaromaService._getProductListResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class _getProductListResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string _getProductListResult;
        
        public _getProductListResponseBody() {
        }
        
        public _getProductListResponseBody(string _getProductListResult) {
            this._getProductListResult = _getProductListResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class _getCategoryListRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="_getCategoryList", Namespace="http://tempuri.org/", Order=0)]
        public Caroma.CaromaService._getCategoryListRequestBody Body;
        
        public _getCategoryListRequest() {
        }
        
        public _getCategoryListRequest(Caroma.CaromaService._getCategoryListRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class _getCategoryListRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string _userName;
        
        public _getCategoryListRequestBody() {
        }
        
        public _getCategoryListRequestBody(string _userName) {
            this._userName = _userName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class _getCategoryListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="_getCategoryListResponse", Namespace="http://tempuri.org/", Order=0)]
        public Caroma.CaromaService._getCategoryListResponseBody Body;
        
        public _getCategoryListResponse() {
        }
        
        public _getCategoryListResponse(Caroma.CaromaService._getCategoryListResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class _getCategoryListResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string _getCategoryListResult;
        
        public _getCategoryListResponseBody() {
        }
        
        public _getCategoryListResponseBody(string _getCategoryListResult) {
            this._getCategoryListResult = _getCategoryListResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class _getProductTypeSearchRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="_getProductTypeSearch", Namespace="http://tempuri.org/", Order=0)]
        public Caroma.CaromaService._getProductTypeSearchRequestBody Body;
        
        public _getProductTypeSearchRequest() {
        }
        
        public _getProductTypeSearchRequest(Caroma.CaromaService._getProductTypeSearchRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class _getProductTypeSearchRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string query;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string ProductName;
        
        public _getProductTypeSearchRequestBody() {
        }
        
        public _getProductTypeSearchRequestBody(string query, string ProductName) {
            this.query = query;
            this.ProductName = ProductName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class _getProductTypeSearchResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="_getProductTypeSearchResponse", Namespace="http://tempuri.org/", Order=0)]
        public Caroma.CaromaService._getProductTypeSearchResponseBody Body;
        
        public _getProductTypeSearchResponse() {
        }
        
        public _getProductTypeSearchResponse(Caroma.CaromaService._getProductTypeSearchResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class _getProductTypeSearchResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string _getProductTypeSearchResult;
        
        public _getProductTypeSearchResponseBody() {
        }
        
        public _getProductTypeSearchResponseBody(string _getProductTypeSearchResult) {
            this._getProductTypeSearchResult = _getProductTypeSearchResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class _getProductSearchRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="_getProductSearch", Namespace="http://tempuri.org/", Order=0)]
        public Caroma.CaromaService._getProductSearchRequestBody Body;
        
        public _getProductSearchRequest() {
        }
        
        public _getProductSearchRequest(Caroma.CaromaService._getProductSearchRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class _getProductSearchRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string SearchText;
        
        public _getProductSearchRequestBody() {
        }
        
        public _getProductSearchRequestBody(string SearchText) {
            this.SearchText = SearchText;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class _getProductSearchResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="_getProductSearchResponse", Namespace="http://tempuri.org/", Order=0)]
        public Caroma.CaromaService._getProductSearchResponseBody Body;
        
        public _getProductSearchResponse() {
        }
        
        public _getProductSearchResponse(Caroma.CaromaService._getProductSearchResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class _getProductSearchResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string _getProductSearchResult;
        
        public _getProductSearchResponseBody() {
        }
        
        public _getProductSearchResponseBody(string _getProductSearchResult) {
            this._getProductSearchResult = _getProductSearchResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CaromaSoapChannel : Caroma.CaromaService.CaromaSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CaromaSoapClient : System.ServiceModel.ClientBase<Caroma.CaromaService.CaromaSoap>, Caroma.CaromaService.CaromaSoap {
        
        public CaromaSoapClient() {
        }
        
        public CaromaSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CaromaSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CaromaSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CaromaSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Caroma.CaromaService._getAuthenticationResponse Caroma.CaromaService.CaromaSoap._getAuthentication(Caroma.CaromaService._getAuthenticationRequest request) {
            return base.Channel._getAuthentication(request);
        }
        
        public bool _getAuthentication(string _userName, string _password) {
            Caroma.CaromaService._getAuthenticationRequest inValue = new Caroma.CaromaService._getAuthenticationRequest();
            inValue.Body = new Caroma.CaromaService._getAuthenticationRequestBody();
            inValue.Body._userName = _userName;
            inValue.Body._password = _password;
            Caroma.CaromaService._getAuthenticationResponse retVal = ((Caroma.CaromaService.CaromaSoap)(this))._getAuthentication(inValue);
            return retVal.Body._getAuthenticationResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Caroma.CaromaService._getAuthenticationResponse> Caroma.CaromaService.CaromaSoap._getAuthenticationAsync(Caroma.CaromaService._getAuthenticationRequest request) {
            return base.Channel._getAuthenticationAsync(request);
        }
        
        public System.Threading.Tasks.Task<Caroma.CaromaService._getAuthenticationResponse> _getAuthenticationAsync(string _userName, string _password) {
            Caroma.CaromaService._getAuthenticationRequest inValue = new Caroma.CaromaService._getAuthenticationRequest();
            inValue.Body = new Caroma.CaromaService._getAuthenticationRequestBody();
            inValue.Body._userName = _userName;
            inValue.Body._password = _password;
            return ((Caroma.CaromaService.CaromaSoap)(this))._getAuthenticationAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Caroma.CaromaService._getProductListResponse Caroma.CaromaService.CaromaSoap._getProductList(Caroma.CaromaService._getProductListRequest request) {
            return base.Channel._getProductList(request);
        }
        
        public string _getProductList(string _userName) {
            Caroma.CaromaService._getProductListRequest inValue = new Caroma.CaromaService._getProductListRequest();
            inValue.Body = new Caroma.CaromaService._getProductListRequestBody();
            inValue.Body._userName = _userName;
            Caroma.CaromaService._getProductListResponse retVal = ((Caroma.CaromaService.CaromaSoap)(this))._getProductList(inValue);
            return retVal.Body._getProductListResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Caroma.CaromaService._getProductListResponse> Caroma.CaromaService.CaromaSoap._getProductListAsync(Caroma.CaromaService._getProductListRequest request) {
            return base.Channel._getProductListAsync(request);
        }
        
        public System.Threading.Tasks.Task<Caroma.CaromaService._getProductListResponse> _getProductListAsync(string _userName) {
            Caroma.CaromaService._getProductListRequest inValue = new Caroma.CaromaService._getProductListRequest();
            inValue.Body = new Caroma.CaromaService._getProductListRequestBody();
            inValue.Body._userName = _userName;
            return ((Caroma.CaromaService.CaromaSoap)(this))._getProductListAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Caroma.CaromaService._getCategoryListResponse Caroma.CaromaService.CaromaSoap._getCategoryList(Caroma.CaromaService._getCategoryListRequest request) {
            return base.Channel._getCategoryList(request);
        }
        
        public string _getCategoryList(string _userName) {
            Caroma.CaromaService._getCategoryListRequest inValue = new Caroma.CaromaService._getCategoryListRequest();
            inValue.Body = new Caroma.CaromaService._getCategoryListRequestBody();
            inValue.Body._userName = _userName;
            Caroma.CaromaService._getCategoryListResponse retVal = ((Caroma.CaromaService.CaromaSoap)(this))._getCategoryList(inValue);
            return retVal.Body._getCategoryListResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Caroma.CaromaService._getCategoryListResponse> Caroma.CaromaService.CaromaSoap._getCategoryListAsync(Caroma.CaromaService._getCategoryListRequest request) {
            return base.Channel._getCategoryListAsync(request);
        }
        
        public System.Threading.Tasks.Task<Caroma.CaromaService._getCategoryListResponse> _getCategoryListAsync(string _userName) {
            Caroma.CaromaService._getCategoryListRequest inValue = new Caroma.CaromaService._getCategoryListRequest();
            inValue.Body = new Caroma.CaromaService._getCategoryListRequestBody();
            inValue.Body._userName = _userName;
            return ((Caroma.CaromaService.CaromaSoap)(this))._getCategoryListAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Caroma.CaromaService._getProductTypeSearchResponse Caroma.CaromaService.CaromaSoap._getProductTypeSearch(Caroma.CaromaService._getProductTypeSearchRequest request) {
            return base.Channel._getProductTypeSearch(request);
        }
        
        public string _getProductTypeSearch(string query, string ProductName) {
            Caroma.CaromaService._getProductTypeSearchRequest inValue = new Caroma.CaromaService._getProductTypeSearchRequest();
            inValue.Body = new Caroma.CaromaService._getProductTypeSearchRequestBody();
            inValue.Body.query = query;
            inValue.Body.ProductName = ProductName;
            Caroma.CaromaService._getProductTypeSearchResponse retVal = ((Caroma.CaromaService.CaromaSoap)(this))._getProductTypeSearch(inValue);
            return retVal.Body._getProductTypeSearchResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Caroma.CaromaService._getProductTypeSearchResponse> Caroma.CaromaService.CaromaSoap._getProductTypeSearchAsync(Caroma.CaromaService._getProductTypeSearchRequest request) {
            return base.Channel._getProductTypeSearchAsync(request);
        }
        
        public System.Threading.Tasks.Task<Caroma.CaromaService._getProductTypeSearchResponse> _getProductTypeSearchAsync(string query, string ProductName) {
            Caroma.CaromaService._getProductTypeSearchRequest inValue = new Caroma.CaromaService._getProductTypeSearchRequest();
            inValue.Body = new Caroma.CaromaService._getProductTypeSearchRequestBody();
            inValue.Body.query = query;
            inValue.Body.ProductName = ProductName;
            return ((Caroma.CaromaService.CaromaSoap)(this))._getProductTypeSearchAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Caroma.CaromaService._getProductSearchResponse Caroma.CaromaService.CaromaSoap._getProductSearch(Caroma.CaromaService._getProductSearchRequest request) {
            return base.Channel._getProductSearch(request);
        }
        
        public string _getProductSearch(string SearchText) {
            Caroma.CaromaService._getProductSearchRequest inValue = new Caroma.CaromaService._getProductSearchRequest();
            inValue.Body = new Caroma.CaromaService._getProductSearchRequestBody();
            inValue.Body.SearchText = SearchText;
            Caroma.CaromaService._getProductSearchResponse retVal = ((Caroma.CaromaService.CaromaSoap)(this))._getProductSearch(inValue);
            return retVal.Body._getProductSearchResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Caroma.CaromaService._getProductSearchResponse> Caroma.CaromaService.CaromaSoap._getProductSearchAsync(Caroma.CaromaService._getProductSearchRequest request) {
            return base.Channel._getProductSearchAsync(request);
        }
        
        public System.Threading.Tasks.Task<Caroma.CaromaService._getProductSearchResponse> _getProductSearchAsync(string SearchText) {
            Caroma.CaromaService._getProductSearchRequest inValue = new Caroma.CaromaService._getProductSearchRequest();
            inValue.Body = new Caroma.CaromaService._getProductSearchRequestBody();
            inValue.Body.SearchText = SearchText;
            return ((Caroma.CaromaService.CaromaSoap)(this))._getProductSearchAsync(inValue);
        }
        
        public void downloadCount() {
            base.Channel.downloadCount();
        }
        
        public System.Threading.Tasks.Task downloadCountAsync() {
            return base.Channel.downloadCountAsync();
        }
    }
}