/**
 * Autogenerated by Thrift Compiler (0.10.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace fightagency
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Ticket : TBase
  {
    private int _id;
    private string _clientName;
    private string _touristsName;
    private string _clientAddress;
    private int _noSeats;
    private int _flightId;

    public int Id
    {
      get
      {
        return _id;
      }
      set
      {
        __isset.id = true;
        this._id = value;
      }
    }

    public string ClientName
    {
      get
      {
        return _clientName;
      }
      set
      {
        __isset.clientName = true;
        this._clientName = value;
      }
    }

    public string TouristsName
    {
      get
      {
        return _touristsName;
      }
      set
      {
        __isset.touristsName = true;
        this._touristsName = value;
      }
    }

    public string ClientAddress
    {
      get
      {
        return _clientAddress;
      }
      set
      {
        __isset.clientAddress = true;
        this._clientAddress = value;
      }
    }

    public int NoSeats
    {
      get
      {
        return _noSeats;
      }
      set
      {
        __isset.noSeats = true;
        this._noSeats = value;
      }
    }

    public int FlightId
    {
      get
      {
        return _flightId;
      }
      set
      {
        __isset.flightId = true;
        this._flightId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool clientName;
      public bool touristsName;
      public bool clientAddress;
      public bool noSeats;
      public bool flightId;
    }

    public Ticket() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.I32) {
                Id = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                ClientName = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                TouristsName = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.String) {
                ClientAddress = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.I32) {
                NoSeats = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 6:
              if (field.Type == TType.I32) {
                FlightId = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("Ticket");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.id) {
          field.Name = "id";
          field.Type = TType.I32;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Id);
          oprot.WriteFieldEnd();
        }
        if (ClientName != null && __isset.clientName) {
          field.Name = "clientName";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ClientName);
          oprot.WriteFieldEnd();
        }
        if (TouristsName != null && __isset.touristsName) {
          field.Name = "touristsName";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(TouristsName);
          oprot.WriteFieldEnd();
        }
        if (ClientAddress != null && __isset.clientAddress) {
          field.Name = "clientAddress";
          field.Type = TType.String;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ClientAddress);
          oprot.WriteFieldEnd();
        }
        if (__isset.noSeats) {
          field.Name = "noSeats";
          field.Type = TType.I32;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(NoSeats);
          oprot.WriteFieldEnd();
        }
        if (__isset.flightId) {
          field.Name = "flightId";
          field.Type = TType.I32;
          field.ID = 6;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(FlightId);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("Ticket(");
      bool __first = true;
      if (__isset.id) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Id: ");
        __sb.Append(Id);
      }
      if (ClientName != null && __isset.clientName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ClientName: ");
        __sb.Append(ClientName);
      }
      if (TouristsName != null && __isset.touristsName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("TouristsName: ");
        __sb.Append(TouristsName);
      }
      if (ClientAddress != null && __isset.clientAddress) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ClientAddress: ");
        __sb.Append(ClientAddress);
      }
      if (__isset.noSeats) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("NoSeats: ");
        __sb.Append(NoSeats);
      }
      if (__isset.flightId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("FlightId: ");
        __sb.Append(FlightId);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
