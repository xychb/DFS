﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DFS
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="CME")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertSMConnectivity(SMConnectivity instance);
    partial void UpdateSMConnectivity(SMConnectivity instance);
    partial void DeleteSMConnectivity(SMConnectivity instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::DFS.Properties.Settings.Default.CMEConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<SMConnectivity> SMConnectivities
		{
			get
			{
				return this.GetTable<SMConnectivity>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SMConnectivity")]
	public partial class SMConnectivity : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ConnectivityID;
		
		private int _FromObjectID;
		
		private int _FromObjectTypeid;
		
		private int _ToObjectID;
		
		private int _ToObjectTypeid;
		
		private int _ConnectivityType;
		
		private System.Nullable<int> _SequenceID;
		
		private int _Status;
		
		private System.DateTime _CreatedDate;
		
		private System.Nullable<int> _CreatedBy;
		
		private System.Nullable<System.DateTime> _ModifiedDate;
		
		private System.Nullable<int> _ModifiedBy;
		
		private int _ConnectivityHWStatus;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnConnectivityIDChanging(int value);
    partial void OnConnectivityIDChanged();
    partial void OnFromObjectIDChanging(int value);
    partial void OnFromObjectIDChanged();
    partial void OnFromObjectTypeidChanging(int value);
    partial void OnFromObjectTypeidChanged();
    partial void OnToObjectIDChanging(int value);
    partial void OnToObjectIDChanged();
    partial void OnToObjectTypeidChanging(int value);
    partial void OnToObjectTypeidChanged();
    partial void OnConnectivityTypeChanging(int value);
    partial void OnConnectivityTypeChanged();
    partial void OnSequenceIDChanging(System.Nullable<int> value);
    partial void OnSequenceIDChanged();
    partial void OnStatusChanging(int value);
    partial void OnStatusChanged();
    partial void OnCreatedDateChanging(System.DateTime value);
    partial void OnCreatedDateChanged();
    partial void OnCreatedByChanging(System.Nullable<int> value);
    partial void OnCreatedByChanged();
    partial void OnModifiedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnModifiedDateChanged();
    partial void OnModifiedByChanging(System.Nullable<int> value);
    partial void OnModifiedByChanged();
    partial void OnConnectivityHWStatusChanging(int value);
    partial void OnConnectivityHWStatusChanged();
    #endregion
		
		public SMConnectivity()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ConnectivityID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ConnectivityID
		{
			get
			{
				return this._ConnectivityID;
			}
			set
			{
				if ((this._ConnectivityID != value))
				{
					this.OnConnectivityIDChanging(value);
					this.SendPropertyChanging();
					this._ConnectivityID = value;
					this.SendPropertyChanged("ConnectivityID");
					this.OnConnectivityIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FromObjectID", DbType="Int NOT NULL")]
		public int FromObjectID
		{
			get
			{
				return this._FromObjectID;
			}
			set
			{
				if ((this._FromObjectID != value))
				{
					this.OnFromObjectIDChanging(value);
					this.SendPropertyChanging();
					this._FromObjectID = value;
					this.SendPropertyChanged("FromObjectID");
					this.OnFromObjectIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FromObjectTypeid", DbType="Int NOT NULL")]
		public int FromObjectTypeid
		{
			get
			{
				return this._FromObjectTypeid;
			}
			set
			{
				if ((this._FromObjectTypeid != value))
				{
					this.OnFromObjectTypeidChanging(value);
					this.SendPropertyChanging();
					this._FromObjectTypeid = value;
					this.SendPropertyChanged("FromObjectTypeid");
					this.OnFromObjectTypeidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ToObjectID", DbType="Int NOT NULL")]
		public int ToObjectID
		{
			get
			{
				return this._ToObjectID;
			}
			set
			{
				if ((this._ToObjectID != value))
				{
					this.OnToObjectIDChanging(value);
					this.SendPropertyChanging();
					this._ToObjectID = value;
					this.SendPropertyChanged("ToObjectID");
					this.OnToObjectIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ToObjectTypeid", DbType="Int NOT NULL")]
		public int ToObjectTypeid
		{
			get
			{
				return this._ToObjectTypeid;
			}
			set
			{
				if ((this._ToObjectTypeid != value))
				{
					this.OnToObjectTypeidChanging(value);
					this.SendPropertyChanging();
					this._ToObjectTypeid = value;
					this.SendPropertyChanged("ToObjectTypeid");
					this.OnToObjectTypeidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ConnectivityType", DbType="Int NOT NULL")]
		public int ConnectivityType
		{
			get
			{
				return this._ConnectivityType;
			}
			set
			{
				if ((this._ConnectivityType != value))
				{
					this.OnConnectivityTypeChanging(value);
					this.SendPropertyChanging();
					this._ConnectivityType = value;
					this.SendPropertyChanged("ConnectivityType");
					this.OnConnectivityTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SequenceID", DbType="Int")]
		public System.Nullable<int> SequenceID
		{
			get
			{
				return this._SequenceID;
			}
			set
			{
				if ((this._SequenceID != value))
				{
					this.OnSequenceIDChanging(value);
					this.SendPropertyChanging();
					this._SequenceID = value;
					this.SendPropertyChanged("SequenceID");
					this.OnSequenceIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Int NOT NULL")]
		public int Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreatedDate
		{
			get
			{
				return this._CreatedDate;
			}
			set
			{
				if ((this._CreatedDate != value))
				{
					this.OnCreatedDateChanging(value);
					this.SendPropertyChanging();
					this._CreatedDate = value;
					this.SendPropertyChanged("CreatedDate");
					this.OnCreatedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedBy", DbType="Int")]
		public System.Nullable<int> CreatedBy
		{
			get
			{
				return this._CreatedBy;
			}
			set
			{
				if ((this._CreatedBy != value))
				{
					this.OnCreatedByChanging(value);
					this.SendPropertyChanging();
					this._CreatedBy = value;
					this.SendPropertyChanged("CreatedBy");
					this.OnCreatedByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				if ((this._ModifiedDate != value))
				{
					this.OnModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._ModifiedDate = value;
					this.SendPropertyChanged("ModifiedDate");
					this.OnModifiedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedBy", DbType="Int")]
		public System.Nullable<int> ModifiedBy
		{
			get
			{
				return this._ModifiedBy;
			}
			set
			{
				if ((this._ModifiedBy != value))
				{
					this.OnModifiedByChanging(value);
					this.SendPropertyChanging();
					this._ModifiedBy = value;
					this.SendPropertyChanged("ModifiedBy");
					this.OnModifiedByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ConnectivityHWStatus", DbType="Int NOT NULL")]
		public int ConnectivityHWStatus
		{
			get
			{
				return this._ConnectivityHWStatus;
			}
			set
			{
				if ((this._ConnectivityHWStatus != value))
				{
					this.OnConnectivityHWStatusChanging(value);
					this.SendPropertyChanging();
					this._ConnectivityHWStatus = value;
					this.SendPropertyChanged("ConnectivityHWStatus");
					this.OnConnectivityHWStatusChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591