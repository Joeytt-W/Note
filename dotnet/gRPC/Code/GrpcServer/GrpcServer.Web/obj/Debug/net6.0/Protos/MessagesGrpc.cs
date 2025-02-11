// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/Messages.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcServer.Web.Protos {
  public static partial class EmployeeService
  {
    static readonly string __ServiceName = "EmployeeService";

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
    static readonly grpc::Marshaller<global::GrpcServer.Web.Protos.GetByNoRequest> __Marshaller_GetByNoRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Web.Protos.GetByNoRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Web.Protos.EmployeeResponse> __Marshaller_EmployeeResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Web.Protos.EmployeeResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Web.Protos.GetAllRequest> __Marshaller_GetAllRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Web.Protos.GetAllRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Web.Protos.AddPhotoRequest> __Marshaller_AddPhotoRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Web.Protos.AddPhotoRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Web.Protos.AddPhotoResponse> __Marshaller_AddPhotoResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Web.Protos.AddPhotoResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServer.Web.Protos.EmployeeRequest> __Marshaller_EmployeeRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServer.Web.Protos.EmployeeRequest.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServer.Web.Protos.GetByNoRequest, global::GrpcServer.Web.Protos.EmployeeResponse> __Method_GetByNo = new grpc::Method<global::GrpcServer.Web.Protos.GetByNoRequest, global::GrpcServer.Web.Protos.EmployeeResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetByNo",
        __Marshaller_GetByNoRequest,
        __Marshaller_EmployeeResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServer.Web.Protos.GetAllRequest, global::GrpcServer.Web.Protos.EmployeeResponse> __Method_GetAll = new grpc::Method<global::GrpcServer.Web.Protos.GetAllRequest, global::GrpcServer.Web.Protos.EmployeeResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetAll",
        __Marshaller_GetAllRequest,
        __Marshaller_EmployeeResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServer.Web.Protos.AddPhotoRequest, global::GrpcServer.Web.Protos.AddPhotoResponse> __Method_AddPhoto = new grpc::Method<global::GrpcServer.Web.Protos.AddPhotoRequest, global::GrpcServer.Web.Protos.AddPhotoResponse>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "AddPhoto",
        __Marshaller_AddPhotoRequest,
        __Marshaller_AddPhotoResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServer.Web.Protos.EmployeeRequest, global::GrpcServer.Web.Protos.EmployeeResponse> __Method_Save = new grpc::Method<global::GrpcServer.Web.Protos.EmployeeRequest, global::GrpcServer.Web.Protos.EmployeeResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Save",
        __Marshaller_EmployeeRequest,
        __Marshaller_EmployeeResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServer.Web.Protos.EmployeeRequest, global::GrpcServer.Web.Protos.EmployeeResponse> __Method_SaveAll = new grpc::Method<global::GrpcServer.Web.Protos.EmployeeRequest, global::GrpcServer.Web.Protos.EmployeeResponse>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "SaveAll",
        __Marshaller_EmployeeRequest,
        __Marshaller_EmployeeResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcServer.Web.Protos.MessagesReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of EmployeeService</summary>
    [grpc::BindServiceMethod(typeof(EmployeeService), "BindService")]
    public abstract partial class EmployeeServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcServer.Web.Protos.EmployeeResponse> GetByNo(global::GrpcServer.Web.Protos.GetByNoRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GetAll(global::GrpcServer.Web.Protos.GetAllRequest request, grpc::IServerStreamWriter<global::GrpcServer.Web.Protos.EmployeeResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcServer.Web.Protos.AddPhotoResponse> AddPhoto(grpc::IAsyncStreamReader<global::GrpcServer.Web.Protos.AddPhotoRequest> requestStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcServer.Web.Protos.EmployeeResponse> Save(global::GrpcServer.Web.Protos.EmployeeRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task SaveAll(grpc::IAsyncStreamReader<global::GrpcServer.Web.Protos.EmployeeRequest> requestStream, grpc::IServerStreamWriter<global::GrpcServer.Web.Protos.EmployeeResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(EmployeeServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetByNo, serviceImpl.GetByNo)
          .AddMethod(__Method_GetAll, serviceImpl.GetAll)
          .AddMethod(__Method_AddPhoto, serviceImpl.AddPhoto)
          .AddMethod(__Method_Save, serviceImpl.Save)
          .AddMethod(__Method_SaveAll, serviceImpl.SaveAll).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, EmployeeServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetByNo, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcServer.Web.Protos.GetByNoRequest, global::GrpcServer.Web.Protos.EmployeeResponse>(serviceImpl.GetByNo));
      serviceBinder.AddMethod(__Method_GetAll, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::GrpcServer.Web.Protos.GetAllRequest, global::GrpcServer.Web.Protos.EmployeeResponse>(serviceImpl.GetAll));
      serviceBinder.AddMethod(__Method_AddPhoto, serviceImpl == null ? null : new grpc::ClientStreamingServerMethod<global::GrpcServer.Web.Protos.AddPhotoRequest, global::GrpcServer.Web.Protos.AddPhotoResponse>(serviceImpl.AddPhoto));
      serviceBinder.AddMethod(__Method_Save, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcServer.Web.Protos.EmployeeRequest, global::GrpcServer.Web.Protos.EmployeeResponse>(serviceImpl.Save));
      serviceBinder.AddMethod(__Method_SaveAll, serviceImpl == null ? null : new grpc::DuplexStreamingServerMethod<global::GrpcServer.Web.Protos.EmployeeRequest, global::GrpcServer.Web.Protos.EmployeeResponse>(serviceImpl.SaveAll));
    }

  }
}
#endregion
