#if ENABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.EntityModels
{
    [Serializable]
    public class AbortFileUploadsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes EntityType;
        /// <summary>
        /// Names of the files to have their pending uploads aborted.
        /// </summary>
        public List<string> FileNames;
        /// <summary>
        /// The expected version of the profile, if set and doesn't match the current version of the profile the operation will not
        /// be performed.
        /// </summary>
        public int? ProfileVersion;
    }

    [Serializable]
    public class AbortFileUploadsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes? EntityType;
        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;
    }

    [Serializable]
    public class AcceptGroupApplicationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Optional: ID of the entity to accept as. If specified, this must be the same entity as the claimant or an entity that is
        /// a child of the claimant entity. Defaults to the claimant entity.
        /// </summary>
        public string AcceptingEntityId;
        /// <summary>
        /// Optional. Type of the entity to accept as. If specified, must be the same entity as the claimant or an entity that is a
        /// child of the claimant entity. Defaults to the claimant entity.
        /// </summary>
        public string AcceptingEntityType;
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes EntityType;
        /// <summary>
        /// ID of the group that the entity is requesting membership to
        /// </summary>
        public string GroupId;
    }

    [Serializable]
    public class AcceptGroupInvitationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes EntityType;
        /// <summary>
        /// ID of the group to accept the invite of
        /// </summary>
        public string GroupId;
    }

    [Serializable]
    public class AddMembersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// ID of the group that the entities are being added to
        /// </summary>
        public string GroupId;
        /// <summary>
        /// List of entities to add to the group. Only entities of type title_player_account and character may be added to groups.
        /// </summary>
        public List<EntityTypeId> Members;
        /// <summary>
        /// Optional: The ID of the existing role to add the entities to. If this is not specified, the default member role for the
        /// group will be used. Role IDs must be between 1 and 64 characters long.
        /// </summary>
        public string RoleId;
    }

    [Serializable]
    public class ApplyToGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Optional, default true. Automatically accept an outstanding invitation if one exists instead of creating an application
        /// </summary>
        public bool? AutoAcceptOutstandingInvite;
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes? EntityType;
        /// <summary>
        /// ID of the group to submit an application to
        /// </summary>
        public string GroupId;
    }

    [Serializable]
    public class BlockEntityRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes EntityType;
        /// <summary>
        /// ID of the group that the entities are being blocked from
        /// </summary>
        public string GroupId;
    }

    [Serializable]
    public class CreateGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes? EntityType;
        /// <summary>
        /// The name of the group. This is unique at the title level by default.
        /// </summary>
        public string GroupName;
    }

    [Serializable]
    public class CreateGroupRoleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The ID of the group to create the role in
        /// </summary>
        public string GroupId;
        /// <summary>
        /// The ID of the role. This must be unique within the group and cannot be changed. Role IDs must be between 1 and 64
        /// characters long.
        /// </summary>
        public string RoleId;
        /// <summary>
        /// The name of the role. This must be unique within the group and can be changed later. Role names must be between 1 and
        /// 100 characters long
        /// </summary>
        public string RoleName;
    }

    [Serializable]
    public class CreateGroupRoleResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The current version of the group profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;
        /// <summary>
        /// ID for the role
        /// </summary>
        public string RoleId;
        /// <summary>
        /// The name of the role
        /// </summary>
        public string RoleName;
    }

    [Serializable]
    public class DeleteFilesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes EntityType;
        /// <summary>
        /// Names of the files to be deleted.
        /// </summary>
        public List<string> FileNames;
        /// <summary>
        /// The expected version of the profile, if set and doesn't match the current version of the profile the operation will not
        /// be performed.
        /// </summary>
        public int? ProfileVersion;
    }

    [Serializable]
    public class DeleteFilesResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes? EntityType;
        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;
    }

    [Serializable]
    public class DeleteGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// ID of the group or role to remove
        /// </summary>
        public string GroupId;
    }

    [Serializable]
    public class DeleteRoleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// ID of the group or role to remove
        /// </summary>
        public string GroupId;
        /// <summary>
        /// The ID of the role to delete. Role IDs must be between 1 and 64 characters long.
        /// </summary>
        public string RoleId;
    }

    public enum EffectType
    {
        Allow,
        Deny
    }

    [Serializable]
    public class EmptyResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// An entity object and its associated meta data.
    /// </summary>
    [Serializable]
    public class EntityDataObject
    {
        /// <summary>
        /// Un-escaped JSON object, if DataAsObject is true.
        /// </summary>
        public object DataObject;
        /// <summary>
        /// Escaped string JSON body of the object, if DataAsObject is default or false.
        /// </summary>
        public string EscapedDataObject;
        /// <summary>
        /// Name of this object.
        /// </summary>
        public string ObjectName;
    }

    [Serializable]
    public class EntityMember
    {
        public string EntityId;
        public string EntityType;
    }

    [Serializable]
    public class EntityMemberRole
    {
        /// <summary>
        /// The list of members in the role
        /// </summary>
        public List<EntityMember> Members;
        /// <summary>
        /// The ID of the role.
        /// </summary>
        public string RoleId;
        /// <summary>
        /// The name of the role
        /// </summary>
        public string RoleName;
    }

    [Serializable]
    public class EntityPermissionStatement
    {
        /// <summary>
        /// The action this statement effects. Supported effects for Data are 'Read', 'Write' and '*'
        /// </summary>
        public string Action;
        /// <summary>
        /// A comment about the statement. Intended solely for bookkeeping and debugging.
        /// </summary>
        public string Comment;
        /// <summary>
        /// The effect this statement will have. It can be either 'Allow' or 'Deny'
        /// </summary>
        public EffectType Effect;
        /// <summary>
        /// The principal this statement will effect. It may be '*' for any, { "[any entity type]": "[any entity id]" }, {
        /// "FriendOf": true }, { "MemberOf": {  "Segment": "segmentId" } }, { "MemberOf": {  "SharedGroup": "Group ID" } }, {
        /// "title": "TitleId" }, { "namespace": "NamespaceId" }, { "ChildOf" : { "EntityType": "[any entity type]", "EntityId":
        /// "[any entity id]" }. See documentation for full examples and explanations.
        /// </summary>
        public string Principal;
        /// <summary>
        /// The portion of a profile that this statement applies to, such as 'pfrn:data--*!*/Profile/Objects/object1.json'
        /// </summary>
        public string Resource;
    }

    [Serializable]
    public class EntityProfileBody
    {
        /// <summary>
        /// The chain of responsibility for this entity. This is a representation of 'ownership'. It is constructed using the
        /// following formats (replace '[ID]' with the unique identifier for the given entity): Namespace: 'namespace![Namespace
        /// ID]' Title: 'title![Namespace ID]/[Title ID]' Namespace Player Account: 'namespace_player_account![Namespace
        /// ID]/[NamespacePlayerAccount ID]' Title Player Account: 'title_player_account![Namespace ID]/[Title
        /// ID]/[NamespacePlayerAccount ID]/[TitlePlayerAccount ID]' Character: 'character![Namespace ID]/[Title
        /// ID]/[NamespacePlayerAccount ID]/[TitlePlayerAccount ID]/[Character ID]'
        /// </summary>
        public string EntityChain;
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes? EntityType;
        /// <summary>
        /// The files on this profile.
        /// </summary>
        public List<EntityProfileFileMetadata> Files;
        /// <summary>
        /// The objects on this profile.
        /// </summary>
        public List<EntityDataObject> Objects;
        /// <summary>
        /// The permissions that govern access to this entity profile and its properties. Only includes permissions set on this
        /// profile, not global statements from titles and namespaces.
        /// </summary>
        public List<EntityProfilePermissionStatement> Permissions;
        /// <summary>
        /// The version number of the profile in persistent storage at the time of the read. Used for optional optimistic
        /// concurrency during update.
        /// </summary>
        public int VersionNumber;
    }

    /// <summary>
    /// An entity file's meta data. To get a download URL call File/GetFiles API.
    /// </summary>
    [Serializable]
    public class EntityProfileFileMetadata
    {
        /// <summary>
        /// Checksum value for the file
        /// </summary>
        public string Checksum;
        /// <summary>
        /// Name of the file
        /// </summary>
        public string FileName;
        /// <summary>
        /// Last UTC time the file was modified
        /// </summary>
        public DateTime LastModified;
        /// <summary>
        /// Storage service's reported byte count
        /// </summary>
        public int Size;
    }

    [Serializable]
    public class EntityProfilePermissionStatement
    {
        /// <summary>
        /// The action this statement effects. May be 'Read', 'Write' or '*' for both read and write.
        /// </summary>
        public string Action;
        /// <summary>
        /// A comment about the statement. Intended solely for bookkeeping and debugging.
        /// </summary>
        public string Comment;
        /// <summary>
        /// Additional conditions to be applied for entity resources.
        /// </summary>
        public string DataConditions;
        /// <summary>
        /// The effect this statement will have. It may be either Allow or Deny
        /// </summary>
        public EffectType Effect;
        /// <summary>
        /// The principal this statement will effect.
        /// </summary>
        public string Principal;
        /// <summary>
        /// The resource this statements effects. Similar to 'pfrn:data--title![Namespace ID]/[Title ID]/Profile/*'
        /// </summary>
        public string Resource;
    }

    [Serializable]
    public class EntityTypeId
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes? EntityType;
    }

    public enum EntityTypes
    {
        title,
        namespace_player_account,
        title_player_account,
        character,
        group
    }

    [Serializable]
    public class FinalizeFileUploadsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes EntityType;
        /// <summary>
        /// Names of the files to be finalized. Restricted to a-Z, 0-9, '(', ')', '_', '-' and '.'
        /// </summary>
        public List<string> FileNames;
    }

    [Serializable]
    public class FinalizeFileUploadsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes? EntityType;
        /// <summary>
        /// Collection of metadata for the entity's files
        /// </summary>
        public List<GetFileMetadata> Metadata;
        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;
    }

    [Serializable]
    public class GetEntityProfileRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Determines whether the objects will be returned as an escaped Json string or as a un-escaped Json object. Default is
        /// Json string.
        /// </summary>
        public bool? DataAsObject;
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes EntityType;
    }

    [Serializable]
    public class GetEntityProfileResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Entity profile
        /// </summary>
        public EntityProfileBody Profile;
    }

    [Serializable]
    public class GetEntityTokenRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes? EntityType;
    }

    [Serializable]
    public class GetEntityTokenResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The identifier of the entity the token was issued for.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// The token used to set X-EntityToken for all entity based API calls.
        /// </summary>
        public string EntityToken;
        /// <summary>
        /// The type of entity the token was issued for.
        /// </summary>
        public string EntityType;
        /// <summary>
        /// The time the token will expire, if it is an expiring token, in UTC.
        /// </summary>
        public DateTime? TokenExpiration;
    }

    [Serializable]
    public class GetFileMetadata
    {
        /// <summary>
        /// Checksum value for the file
        /// </summary>
        public string Checksum;
        /// <summary>
        /// Download URL where the file can be retrieved
        /// </summary>
        public string DownloadUrl;
        /// <summary>
        /// Name of the file
        /// </summary>
        public string FileName;
        /// <summary>
        /// Last UTC time the file was modified
        /// </summary>
        public DateTime LastModified;
        /// <summary>
        /// Storage service's reported byte count
        /// </summary>
        public int Size;
    }

    [Serializable]
    public class GetFilesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes EntityType;
    }

    [Serializable]
    public class GetFilesResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes? EntityType;
        /// <summary>
        /// Collection of metadata for the entity's files
        /// </summary>
        public List<GetFileMetadata> Metadata;
        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;
    }

    [Serializable]
    public class GetGroupApplicationResponse : PlayFabResultCommon
    {
        /// <summary>
        /// ID of the entity that requested membership
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Type of entity that requested membership
        /// </summary>
        public string EntityType;
        /// <summary>
        /// When the application to join will expire and be deleted
        /// </summary>
        public DateTime Expires;
        /// <summary>
        /// ID of the group that the entity requesting membership to
        /// </summary>
        public string GroupId;
    }

    [Serializable]
    public class GetGroupInviteResponse : PlayFabResultCommon
    {
        /// <summary>
        /// ID of the entity that is invited
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Type of entity that is invited
        /// </summary>
        public string EntityType;
        /// <summary>
        /// When the invitation will expire and be deleted
        /// </summary>
        public DateTime Expires;
        /// <summary>
        /// ID of the group that the entity invited to
        /// </summary>
        public string GroupId;
        /// <summary>
        /// ID of the entity that created the invitation
        /// </summary>
        public string InvitedById;
        /// <summary>
        /// Type of the entity that created the invitation
        /// </summary>
        public string InvitedByType;
        /// <summary>
        /// ID of the role in the group to assign the user to.
        /// </summary>
        public string RoleId;
    }

    [Serializable]
    public class GetGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The ID of the group
        /// </summary>
        public string GroupId;
    }

    [Serializable]
    public class GetGroupResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The ID of the administrator role for the group.
        /// </summary>
        public string AdminRoleId;
        /// <summary>
        /// The server date and time the group was created.
        /// </summary>
        public DateTime Created;
        /// <summary>
        /// ID for the group.
        /// </summary>
        public string GroupId;
        /// <summary>
        /// The name of the group.
        /// </summary>
        public string GroupName;
        /// <summary>
        /// The ID of the default member role for the group.
        /// </summary>
        public string MemberRoleId;
        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;
        /// <summary>
        /// The list of roles and names that belong to the group.
        /// </summary>
        public Dictionary<string,string> Roles;
    }

    [Serializable]
    public class GetObjectsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes EntityType;
        /// <summary>
        /// Determines whether the object will be returned as an escaped JSON string or as a un-escaped JSON object. Default is JSON
        /// object.
        /// </summary>
        public bool? EscapeObject;
    }

    [Serializable]
    public class GetObjectsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes? EntityType;
        /// <summary>
        /// Requested objects that the calling entity has access to
        /// </summary>
        public List<ObjectResult> Objects;
        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;
    }

    [Serializable]
    public class GroupApplication
    {
        /// <summary>
        /// ID of the entity that requested membership
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Type of entity that requested membership
        /// </summary>
        public string EntityType;
        /// <summary>
        /// When the application to join will expire and be deleted
        /// </summary>
        public DateTime Expires;
        /// <summary>
        /// ID of the group that the entity requesting membership to
        /// </summary>
        public string GroupId;
    }

    [Serializable]
    public class GroupBlock
    {
        /// <summary>
        /// ID of the entity that is blocked
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Type of entity that is blocked
        /// </summary>
        public string EntityType;
        /// <summary>
        /// ID of the group that the entity is blocked from
        /// </summary>
        public string GroupId;
    }

    [Serializable]
    public class GroupInvite
    {
        /// <summary>
        /// ID of the entity that is invited
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Type of entity that is invited
        /// </summary>
        public string EntityType;
        /// <summary>
        /// When the invitation will expire and be deleted
        /// </summary>
        public DateTime Expires;
        /// <summary>
        /// ID of the group that the entity invited to
        /// </summary>
        public string GroupId;
        /// <summary>
        /// ID of the entity that created the invitation
        /// </summary>
        public string InvitedById;
        /// <summary>
        /// Type of the entity that created the invitation
        /// </summary>
        public string InvitedByType;
        /// <summary>
        /// ID of the role in the group to assign the user to.
        /// </summary>
        public string RoleId;
    }

    [Serializable]
    public class GroupRole
    {
        /// <summary>
        /// ID for the role
        /// </summary>
        public string RoleId;
        /// <summary>
        /// The name of the role
        /// </summary>
        public string RoleName;
    }

    [Serializable]
    public class GroupWithRoles
    {
        /// <summary>
        /// ID for the group
        /// </summary>
        public string GroupId;
        /// <summary>
        /// The name of the group
        /// </summary>
        public string GroupName;
        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;
        /// <summary>
        /// The list of roles within the group
        /// </summary>
        public List<GroupRole> Roles;
    }

    [Serializable]
    public class InitiateFileUploadMetadata
    {
        /// <summary>
        /// Name of the file.
        /// </summary>
        public string FileName;
        /// <summary>
        /// Location the data should be sent to via an HTTP PUT operation.
        /// </summary>
        public string UploadUrl;
    }

    [Serializable]
    public class InitiateFileUploadsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes EntityType;
        /// <summary>
        /// Names of the files to be set. Restricted to a-Z, 0-9, '(', ')', '_', '-' and '.'
        /// </summary>
        public List<string> FileNames;
        /// <summary>
        /// The expected version of the profile, if set and doesn't match the current version of the profile the operation will not
        /// be performed.
        /// </summary>
        public int? ProfileVersion;
    }

    [Serializable]
    public class InitiateFileUploadsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes? EntityType;
        /// <summary>
        /// The current version of the profile, can be used for concurrency control during updates.
        /// </summary>
        public int ProfileVersion;
        /// <summary>
        /// Collection of file names and upload urls
        /// </summary>
        public List<InitiateFileUploadMetadata> UploadDetails;
    }

    [Serializable]
    public class InviteToGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Optional, default true. Automatically accept an application if one exists instead of creating an invitation
        /// </summary>
        public bool? AutoAcceptOutstandingApplication;
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes EntityType;
        /// <summary>
        /// ID of the group to invite to
        /// </summary>
        public string GroupId;
        /// <summary>
        /// Optional. ID of an existing a role in the group to assign the user to. The group's default member role is used if this
        /// is not specified. Role IDs must be between 1 and 64 characters long.
        /// </summary>
        public string RoleId;
    }

    [Serializable]
    public class IsMemberRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes EntityType;
        /// <summary>
        /// ID of the group to check membership of.
        /// </summary>
        public string GroupId;
        /// <summary>
        /// Optional: ID of the role to check membership of. Defaults to any role (that is, check to see if the entity is a member
        /// of the group in any capacity) if not specified.
        /// </summary>
        public string RoleId;
    }

    [Serializable]
    public class IsMemberResponse : PlayFabResultCommon
    {
        /// <summary>
        /// A value indicating whether or not the entity is a member.
        /// </summary>
        public bool IsMember;
    }

    [Serializable]
    public class ListGroupApplicationResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The requested list of applications to the group.
        /// </summary>
        public List<GroupApplication> Requests;
    }

    [Serializable]
    public class ListGroupApplicationsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// ID of the group to list applications for
        /// </summary>
        public string GroupId;
    }

    [Serializable]
    public class ListGroupBlockRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Type of group to list block entities of
        /// </summary>
        public string GroupId;
    }

    [Serializable]
    public class ListGroupBlockResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The requested list blocked entities.
        /// </summary>
        public List<GroupBlock> BlockedEntities;
    }

    [Serializable]
    public class ListGroupInviteRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// ID of the group to list invitations of
        /// </summary>
        public string GroupId;
    }

    [Serializable]
    public class ListGroupInviteResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The requested list of group invitations.
        /// </summary>
        public List<GroupInvite> Invitations;
    }

    [Serializable]
    public class ListGroupMembersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// ID of the group or role to list the members and roles for
        /// </summary>
        public string GroupId;
    }

    [Serializable]
    public class ListGroupMembersResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The requested list of roles and member entity IDs.
        /// </summary>
        public List<EntityMemberRole> Members;
    }

    [Serializable]
    public class ListMembershipOpportunitiesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes? EntityType;
    }

    [Serializable]
    public class ListMembershipOpportunitiesResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The requested list of group applications.
        /// </summary>
        public List<GroupApplication> Applications;
        /// <summary>
        /// The requested list of group invitations.
        /// </summary>
        public List<GroupInvite> Invitations;
    }

    [Serializable]
    public class ListMembershipRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes? EntityType;
    }

    [Serializable]
    public class ListMembershipResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of groups
        /// </summary>
        public List<GroupWithRoles> Groups;
    }

    [Serializable]
    public class ObjectPermissionStatement
    {
        /// <summary>
        /// The action this statement effects. Supported effects for Data are 'Read', 'Write' and '*'
        /// </summary>
        public string Action;
        /// <summary>
        /// The effect this statement will have. It can be either 'Allow' or 'Deny'
        /// </summary>
        public EffectType Effect;
        /// <summary>
        /// The principal this statement will effect. It may be '*' for any, { "[any entity type]": "[any entity id]" }, {
        /// "FriendOf": true }, { "MemberOf": {  "Segment": "segmentId" } }, { "MemberOf": {  "SharedGroup": "Group ID" } }, {
        /// "title": "TitleId" }, { "namespace": "NamespaceId" }, { "ChildOf" : { "EntityType": "[any entity type]", "EntityId":
        /// "[any entity id]" }. See documentation for full examples and explanations.
        /// </summary>
        public string Principal;
    }

    [Serializable]
    public class ObjectResult : PlayFabResultCommon
    {
        /// <summary>
        /// Un-escaped JSON object, if EscapeObject false or default.
        /// </summary>
        public object DataObject;
        /// <summary>
        /// Escaped string JSON body of the object, if EscapeObject is true.
        /// </summary>
        public string EscapedDataObject;
        /// <summary>
        /// Name of the object. Restricted to a-Z, 0-9, '(', ')', '_', '-' and '.'
        /// </summary>
        public string ObjectName;
    }

    public enum OperationTypes
    {
        Created,
        Updated,
        Deleted,
        None
    }

    [Serializable]
    public class RemoveGroupApplicationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes EntityType;
        /// <summary>
        /// ID of the group that the entity is requesting membership to
        /// </summary>
        public string GroupId;
    }

    [Serializable]
    public class RemoveGroupInvitationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes EntityType;
        /// <summary>
        /// ID of the group that the entity was invited to
        /// </summary>
        public string GroupId;
    }

    [Serializable]
    public class RemoveMembersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// ID of the group that the entities are being removed from. If this is the only role the entities are a member of,
        /// removing them from the role will also remove them from the group.
        /// </summary>
        public string GroupId;
        /// <summary>
        /// List of entities to remove
        /// </summary>
        public List<EntityTypeId> Members;
        /// <summary>
        /// The ID of the role to remove the entities from.
        /// </summary>
        public string RoleId;
    }

    [Serializable]
    public class SetEntityProfilePolicyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes EntityType;
        /// <summary>
        /// The statements to include in the access policy.
        /// </summary>
        public List<EntityPermissionStatement> Statements;
    }

    [Serializable]
    public class SetEntityProfilePolicyResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The permissions that govern access to this entity profile and its properties. Only includes permissions set on this
        /// profile, not global statements from titles and namespaces.
        /// </summary>
        public List<EntityProfilePermissionStatement> Permissions;
    }

    [Serializable]
    public class SetObject
    {
        /// <summary>
        /// Body of the object to be saved. If empty and DeleteObject is true object will be deleted if it exists, or no operation
        /// will occur if it does not exist. Only one of Object or EscapedDataObject fields may be used.
        /// </summary>
        public object DataObject;
        /// <summary>
        /// Flag to indicate that this object should be deleted. Both DataObject and EscapedDataObject must not be set as well.
        /// </summary>
        public bool? DeleteObject;
        /// <summary>
        /// Body of the object to be saved as an escaped JSON string. If empty and DeleteObject is true object will be deleted if it
        /// exists, or no operation will occur if it does not exist. Only one of DataObject or EscapedDataObject fields may be used.
        /// </summary>
        public string EscapedDataObject;
        /// <summary>
        /// Name of  object. Restricted to a-Z, 0-9, '(', ')', '_', '-' and '.'.
        /// </summary>
        public string ObjectName;
        /// <summary>
        /// Simplified permission statements that can be used instead of the more complex full statements. However these are not as
        /// full featured.
        /// </summary>
        public SimplePermissionStatement SimpleStatements;
        /// <summary>
        /// The statements to include in the access policy.
        /// </summary>
        public List<ObjectPermissionStatement> Statements;
        /// <summary>
        /// Flag to indicate if this is not a structured JSON object. If true data must be posted via EscapedDataObject. Saving
        /// unstructured values means that this cannot be used for segmentation and other services.
        /// </summary>
        public bool? Unstructured;
    }

    [Serializable]
    public class SetObjectResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Name of the object
        /// </summary>
        public string ObjectName;
        /// <summary>
        /// Optional reason to explain why the operation was the result that it was.
        /// </summary>
        public string OperationReason;
        /// <summary>
        /// Indicates which operation was completed, either Created, Updated, Deleted or None.
        /// </summary>
        public OperationTypes? SetResult;
    }

    [Serializable]
    public class SetObjectsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes EntityType;
        /// <summary>
        /// Optional field used for concurrency control. By specifying the previously returned value of ProfileVersion from
        /// GetProfile API, you can ensure that the object set will only be performed if the profile has not been updated by any
        /// other clients since the version you last loaded.
        /// </summary>
        public int? ExpectedProfileVersion;
        /// <summary>
        /// Collection of objects to set on the profile.
        /// </summary>
        public List<SetObject> Objects;
    }

    [Serializable]
    public class SetObjectsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// New version of the entity profile.
        /// </summary>
        public int ProfileVersion;
        /// <summary>
        /// New version of the entity profile.
        /// </summary>
        public List<SetObjectResponse> SetResults;
    }

    /// <summary>
    /// Simplified permission statements that can be used instead of the more complex full statements.
    /// </summary>
    [Serializable]
    public class SimplePermissionStatement
    {
        /// <summary>
        /// List of principals to grant Read only access to this object.
        /// </summary>
        public List<object> Read;
        /// <summary>
        /// List of principals to grant Read & Write access to this object.
        /// </summary>
        public List<object> Write;
    }

    [Serializable]
    public class UnblockEntityRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Entity type.
        /// </summary>
        public EntityTypes EntityType;
        /// <summary>
        /// ID of the group that the entities are being unblocked from
        /// </summary>
        public string GroupId;
    }

    [Serializable]
    public class UpdateGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Optional: the ID of an existing role to set as the new administrator role for the group
        /// </summary>
        public string AdminRoleId;
        /// <summary>
        /// Optional field used for concurrency control. By specifying the previously returned value of ProfileVersion from the
        /// GetGroup API, you can ensure that the group data update will only be performed if the group has not been updated by any
        /// other clients since the version you last loaded.
        /// </summary>
        public int? ExpectedProfileVersion;
        /// <summary>
        /// ID of the group to update
        /// </summary>
        public string GroupId;
        /// <summary>
        /// Optional: the new name of the group
        /// </summary>
        public string GroupName;
        /// <summary>
        /// Optional: the ID of an existing role to set as the new member role for the group
        /// </summary>
        public string MemberRoleId;
    }

    [Serializable]
    public class UpdateGroupResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Optional reason to explain why the operation was the result that it was.
        /// </summary>
        public string OperationReason;
        /// <summary>
        /// New version of the group data.
        /// </summary>
        public int ProfileVersion;
        /// <summary>
        /// Indicates which operation was completed, either Created, Updated, Deleted or None.
        /// </summary>
        public OperationTypes? SetResult;
    }

    [Serializable]
    public class UpdateGroupRoleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Optional field used for concurrency control. By specifying the previously returned value of ProfileVersion from the
        /// GetGroup API, you can ensure that the group data update will only be performed if the group has not been updated by any
        /// other clients since the version you last loaded.
        /// </summary>
        public int? ExpectedProfileVersion;
        /// <summary>
        /// ID of the group to update
        /// </summary>
        public string GroupId;
        /// <summary>
        /// ID of the role to update. Role IDs must be between 1 and 64 characters long.
        /// </summary>
        public string RoleId;
        /// <summary>
        /// The new name of the role
        /// </summary>
        public string RoleName;
    }

    [Serializable]
    public class UpdateGroupRoleResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Optional reason to explain why the operation was the result that it was.
        /// </summary>
        public string OperationReason;
        /// <summary>
        /// New version of the role data.
        /// </summary>
        public int ProfileVersion;
        /// <summary>
        /// Indicates which operation was completed, either Created, Updated, Deleted or None.
        /// </summary>
        public OperationTypes? SetResult;
    }
}
#endif
