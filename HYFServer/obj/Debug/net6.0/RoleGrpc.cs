// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: role.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace HYFServer {
  public static partial class RoleService
  {
    static readonly string __ServiceName = "role.RoleService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HYFServer.RoleInfoRequest> __Marshaller_role_RoleInfoRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HYFServer.RoleInfoRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HYFServer.RoleInfoResponse> __Marshaller_role_RoleInfoResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HYFServer.RoleInfoResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HYFServer.RoleUpLvRequest> __Marshaller_role_RoleUpLvRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HYFServer.RoleUpLvRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HYFServer.RoleUpLvResponse> __Marshaller_role_RoleUpLvResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HYFServer.RoleUpLvResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HYFServer.RoleAddVipRequest> __Marshaller_role_RoleAddVipRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HYFServer.RoleAddVipRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HYFServer.RoleAddVipResponse> __Marshaller_role_RoleAddVipResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HYFServer.RoleAddVipResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::HYFServer.RoleInfoRequest, global::HYFServer.RoleInfoResponse> __Method_RoleInfo = new grpc::Method<global::HYFServer.RoleInfoRequest, global::HYFServer.RoleInfoResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RoleInfo",
        __Marshaller_role_RoleInfoRequest,
        __Marshaller_role_RoleInfoResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::HYFServer.RoleUpLvRequest, global::HYFServer.RoleUpLvResponse> __Method_RoleUpLv = new grpc::Method<global::HYFServer.RoleUpLvRequest, global::HYFServer.RoleUpLvResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RoleUpLv",
        __Marshaller_role_RoleUpLvRequest,
        __Marshaller_role_RoleUpLvResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::HYFServer.RoleAddVipRequest, global::HYFServer.RoleAddVipResponse> __Method_RoleAddVip = new grpc::Method<global::HYFServer.RoleAddVipRequest, global::HYFServer.RoleAddVipResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RoleAddVip",
        __Marshaller_role_RoleAddVipRequest,
        __Marshaller_role_RoleAddVipResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::HYFServer.RoleReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of RoleService</summary>
    [grpc::BindServiceMethod(typeof(RoleService), "BindService")]
    public abstract partial class RoleServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::HYFServer.RoleInfoResponse> RoleInfo(global::HYFServer.RoleInfoRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::HYFServer.RoleUpLvResponse> RoleUpLv(global::HYFServer.RoleUpLvRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::HYFServer.RoleAddVipResponse> RoleAddVip(global::HYFServer.RoleAddVipRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(RoleServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_RoleInfo, serviceImpl.RoleInfo)
          .AddMethod(__Method_RoleUpLv, serviceImpl.RoleUpLv)
          .AddMethod(__Method_RoleAddVip, serviceImpl.RoleAddVip).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, RoleServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_RoleInfo, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::HYFServer.RoleInfoRequest, global::HYFServer.RoleInfoResponse>(serviceImpl.RoleInfo));
      serviceBinder.AddMethod(__Method_RoleUpLv, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::HYFServer.RoleUpLvRequest, global::HYFServer.RoleUpLvResponse>(serviceImpl.RoleUpLv));
      serviceBinder.AddMethod(__Method_RoleAddVip, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::HYFServer.RoleAddVipRequest, global::HYFServer.RoleAddVipResponse>(serviceImpl.RoleAddVip));
    }

  }
}
#endregion
