
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
// using Microsoft.SqlServer.Types;
using System.Runtime.Serialization;
using System.ComponentModel;
using inercya.EntityLite;	
using inercya.EntityLite.Extensions;	

namespace Web.Entities
{
	[Serializable]
	[DataContract]
	[SqlEntity(BaseTableName="users")]
	public partial class User
	{
		private Int32 _userId;
		[DataMember]
		[SqlField(DbType.Int32, 4, Precision = 10, IsKey=true, ColumnName ="user_id", BaseColumnName ="user_id", BaseTableName = "users" )]
		public Int32 UserId 
		{ 
		    get { return _userId; } 
			set 
			{
			    _userId = value;
			}
        }

		private String _userName;
		[DataMember]
		[SqlField(DbType.AnsiString, 128, ColumnName ="user_name", BaseColumnName ="user_name", BaseTableName = "users" )]
		public String UserName 
		{ 
		    get { return _userName; } 
			set 
			{
			    _userName = value;
			}
        }

		private String _userMail;
		[DataMember]
		[SqlField(DbType.AnsiString, 128, ColumnName ="user_mail", BaseColumnName ="user_mail", BaseTableName = "users" )]
		public String UserMail 
		{ 
		    get { return _userMail; } 
			set 
			{
			    _userMail = value;
			}
        }

		private String _loginName;
		[DataMember]
		[SqlField(DbType.AnsiString, 128, ColumnName ="login_name", BaseColumnName ="login_name", BaseTableName = "users" )]
		public String LoginName 
		{ 
		    get { return _loginName; } 
			set 
			{
			    _loginName = value;
			}
        }

		private Boolean _isActive;
		[DataMember]
		[SqlField(DbType.Boolean, 1, ColumnName ="is_active", BaseColumnName ="is_active", BaseTableName = "users" )]
		public Boolean IsActive 
		{ 
		    get { return _isActive; } 
			set 
			{
			    _isActive = value;
			}
        }

		private DateTime _createdDate;
		[DataMember]
		[SqlField(DbType.DateTime, 8, Precision = 23, Scale=3, ColumnName ="created_date", BaseColumnName ="created_date", BaseTableName = "users" )]
		public DateTime CreatedDate 
		{ 
		    get { return _createdDate; } 
			set 
			{
			    _createdDate = value;
			}
        }

		private Int32 _createdBy;
		[DataMember]
		[SqlField(DbType.Int32, 4, Precision = 10, ColumnName ="created_by", BaseColumnName ="created_by", BaseTableName = "users" )]
		public Int32 CreatedBy 
		{ 
		    get { return _createdBy; } 
			set 
			{
			    _createdBy = value;
			}
        }

		private DateTime _modifiedDate;
		[DataMember]
		[SqlField(DbType.DateTime, 8, Precision = 23, Scale=3, ColumnName ="modified_date", BaseColumnName ="modified_date", BaseTableName = "users" )]
		public DateTime ModifiedDate 
		{ 
		    get { return _modifiedDate; } 
			set 
			{
			    _modifiedDate = value;
			}
        }

		private Int32 _modifiedBy;
		[DataMember]
		[SqlField(DbType.Int32, 4, Precision = 10, ColumnName ="modified_by", BaseColumnName ="modified_by", BaseTableName = "users" )]
		public Int32 ModifiedBy 
		{ 
		    get { return _modifiedBy; } 
			set 
			{
			    _modifiedBy = value;
			}
        }

		private Int32? _roleId;
		[DataMember]
		[SqlField(DbType.Int32, 4, Precision = 10, AllowNull = true, ColumnName ="role_id" )]
		public Int32? RoleId 
		{ 
		    get { return _roleId; } 
			set 
			{
			    _roleId = value;
			}
        }

		private Int32 _entityId;
		[DataMember]
		[SqlField(DbType.Int32, 4, Precision = 10, ColumnName ="entity_id" )]
		public Int32 EntityId 
		{ 
		    get { return _entityId; } 
			set 
			{
			    _entityId = value;
			}
        }

		private Int32 _entityTypeId;
		[DataMember]
		[SqlField(DbType.Int32, 4, Precision = 10, ColumnName ="entity_type_id" )]
		public Int32 EntityTypeId 
		{ 
		    get { return _entityTypeId; } 
			set 
			{
			    _entityTypeId = value;
			}
        }

		private Int32 _permissionId;
		[DataMember]
		[SqlField(DbType.Int32, 4, Precision = 10, ColumnName ="permission_id" )]
		public Int32 PermissionId 
		{ 
		    get { return _permissionId; } 
			set 
			{
			    _permissionId = value;
			}
        }

		private String _roleName;
		[DataMember]
		[SqlField(DbType.AnsiString, 128, ColumnName ="role_name" )]
		public String RoleName 
		{ 
		    get { return _roleName; } 
			set 
			{
			    _roleName = value;
			}
        }

		private String _permissionName;
		[DataMember]
		[SqlField(DbType.AnsiString, 128, ColumnName ="permission_name" )]
		public String PermissionName 
		{ 
		    get { return _permissionName; } 
			set 
			{
			    _permissionName = value;
			}
        }

		private String _permissionInvariantName;
		[DataMember]
		[SqlField(DbType.AnsiString, 128, ColumnName ="permission_invariant_name" )]
		public String PermissionInvariantName 
		{ 
		    get { return _permissionInvariantName; } 
			set 
			{
			    _permissionInvariantName = value;
			}
        }

		private String _entityTypeName;
		[DataMember]
		[SqlField(DbType.AnsiString, 128, ColumnName ="entity_type_name" )]
		public String EntityTypeName 
		{ 
		    get { return _entityTypeName; } 
			set 
			{
			    _entityTypeName = value;
			}
        }

		private Int32 _userRoleEntityId;
		[DataMember]
		[SqlField(DbType.Int32, 4, Precision = 10, IsKey=true, ColumnName ="user_role_entity_id" )]
		public Int32 UserRoleEntityId 
		{ 
		    get { return _userRoleEntityId; } 
			set 
			{
			    _userRoleEntityId = value;
			}
        }

		private String _roleInvariantName;
		[DataMember]
		[SqlField(DbType.AnsiString, 128, ColumnName ="role_invariant_name" )]
		public String RoleInvariantName 
		{ 
		    get { return _roleInvariantName; } 
			set 
			{
			    _roleInvariantName = value;
			}
        }

		private String _permissions;
		[DataMember]
		[SqlField(DbType.String, 2147483647, ColumnName ="Permissions" )]
		public String Permissions 
		{ 
		    get { return _permissions; } 
			set 
			{
			    _permissions = value;
			}
        }


	}

	public partial class UserRepository : Repository<User> 
	{
		public UserRepository(DataService DataService) : base(DataService)
		{
		}

		public new ContractManagementDataService  DataService  
		{
			get { return (ContractManagementDataService) base.DataService; }
			set { base.DataService = value; }
		}

		public User Get(string projectionName, System.Int32 userId)
		{
			return ((IRepository<User>)this).Get(projectionName, userId, FetchMode.UseIdentityMap);
		}

		public User Get(string projectionName, System.Int32 userId, FetchMode fetchMode = FetchMode.UseIdentityMap)
		{
			return ((IRepository<User>)this).Get(projectionName, userId, fetchMode);
		}

		public User Get(Projection projection, System.Int32 userId)
		{
			return ((IRepository<User>)this).Get(projection, userId, FetchMode.UseIdentityMap);
		}

		public User Get(Projection projection, System.Int32 userId, FetchMode fetchMode = FetchMode.UseIdentityMap)
		{
			return ((IRepository<User>)this).Get(projection, userId, fetchMode);
		}

		public User Get(string projectionName, System.Int32 userId, params string[] fields)
		{
			return ((IRepository<User>)this).Get(projectionName, userId, fields);
		}

		public User Get(Projection projection, System.Int32 userId, params string[] fields)
		{
			return ((IRepository<User>)this).Get(projection, userId, fields);
		}

		public bool Delete(System.Int32 userId)
		{
			var entity = new User { UserId = userId };
			return this.Delete(entity);
		}
		// asyncrhonous methods

		public Task<User> GetAsync(string projectionName, System.Int32 userId)
		{
			return ((IRepository<User>)this).GetAsync(projectionName, userId, FetchMode.UseIdentityMap);
		}

		public Task<User> GetAsync(string projectionName, System.Int32 userId, FetchMode fetchMode = FetchMode.UseIdentityMap)
		{
			return ((IRepository<User>)this).GetAsync(projectionName, userId, fetchMode);
		}

		public Task<User> GetAsync(Projection projection, System.Int32 userId)
		{
			return ((IRepository<User>)this).GetAsync(projection, userId, FetchMode.UseIdentityMap);
		}

		public Task<User> GetAsync(Projection projection, System.Int32 userId, FetchMode fetchMode = FetchMode.UseIdentityMap)
		{
			return ((IRepository<User>)this).GetAsync(projection, userId, fetchMode);
		}

		public Task<User> GetAsync(string projectionName, System.Int32 userId, params string[] fields)
		{
			return ((IRepository<User>)this).GetAsync(projectionName, userId, fields);
		}

		public Task<User> GetAsync(Projection projection, System.Int32 userId, params string[] fields)
		{
			return ((IRepository<User>)this).GetAsync(projection, userId, fields);
		}

		public Task<bool> DeleteAsync(System.Int32 userId)
		{
			var entity = new User { UserId = userId };
			return this.DeleteAsync(entity);
		}

	}
	[Obsolete("Use nameof instead")]
	public static partial class UserFields
	{
		public const string UserId = "UserId";
		public const string UserName = "UserName";
		public const string UserMail = "UserMail";
		public const string LoginName = "LoginName";
		public const string IsActive = "IsActive";
		public const string CreatedDate = "CreatedDate";
		public const string CreatedBy = "CreatedBy";
		public const string ModifiedDate = "ModifiedDate";
		public const string ModifiedBy = "ModifiedBy";
		public const string RoleId = "RoleId";
		public const string EntityId = "EntityId";
		public const string EntityTypeId = "EntityTypeId";
		public const string PermissionId = "PermissionId";
		public const string RoleName = "RoleName";
		public const string PermissionName = "PermissionName";
		public const string PermissionInvariantName = "PermissionInvariantName";
		public const string EntityTypeName = "EntityTypeName";
		public const string UserRoleEntityId = "UserRoleEntityId";
		public const string RoleInvariantName = "RoleInvariantName";
		public const string Permissions = "Permissions";
	}

}

namespace Web.Entities
{
	public partial class ContractManagementDataService : DataService
	{
		partial void OnCreated();

		private void Init()
		{
			EntityNameToEntityViewTransform = TextTransform.ToUnderscoreLowerCaseNamingConvention;
			EntityLiteProvider.DefaultSchema = "dbo";
			AuditDateTimeKind = DateTimeKind.Utc;
			OnCreated();
		}

        public ContractManagementDataService() : base("ContractManagement")
        {
			Init();
        }

        public ContractManagementDataService(string connectionStringName) : base(connectionStringName)
        {
			Init();
        }

        public ContractManagementDataService(string connectionString, string providerName) : base(connectionString, providerName)
        {
			Init();
        }

		private Web.Entities.UserRepository _UserRepository;
		public Web.Entities.UserRepository UserRepository
		{
			get 
			{
				if ( _UserRepository == null)
				{
					_UserRepository = new Web.Entities.UserRepository(this);
				}
				return _UserRepository;
			}
		}
	}
}
