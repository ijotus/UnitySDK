#if ENABLE_PLAYFABENTITY_API
using PlayFab.EntityModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<AbortFileUploadsRequest> OnEntityAbortFileUploadsRequestEvent;
        public event PlayFabResultEvent<AbortFileUploadsResponse> OnEntityAbortFileUploadsResultEvent;
        public event PlayFabRequestEvent<AcceptGroupInviteRequest> OnEntityAcceptInviteRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityAcceptInviteResultEvent;
        public event PlayFabRequestEvent<AcceptGroupJoinRequestRequest> OnEntityAcceptJoinRequestRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityAcceptJoinRequestResultEvent;
        public event PlayFabRequestEvent<AddGroupMembersRequest> OnEntityAddGroupMembersRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityAddGroupMembersResultEvent;
        public event PlayFabRequestEvent<AddRoleMembersRequest> OnEntityAddRoleMembersRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityAddRoleMembersResultEvent;
        public event PlayFabRequestEvent<CreateGroupBlockRequest> OnEntityCreateBlockRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityCreateBlockResultEvent;
        public event PlayFabRequestEvent<CreateGroupRequest> OnEntityCreateGroupRequestEvent;
        public event PlayFabResultEvent<GetGroupResponse> OnEntityCreateGroupResultEvent;
        public event PlayFabRequestEvent<CreateGroupInviteRequest> OnEntityCreateInviteRequestEvent;
        public event PlayFabResultEvent<GetGroupInviteResponse> OnEntityCreateInviteResultEvent;
        public event PlayFabRequestEvent<CreateJoinRequestRequest> OnEntityCreateJoinRequestRequestEvent;
        public event PlayFabResultEvent<GetGroupJoinRequestResponse> OnEntityCreateJoinRequestResultEvent;
        public event PlayFabRequestEvent<CreateGroupRoleRequest> OnEntityCreateRoleRequestEvent;
        public event PlayFabResultEvent<GetGroupRoleResponse> OnEntityCreateRoleResultEvent;
        public event PlayFabRequestEvent<DeleteFilesRequest> OnEntityDeleteFilesRequestEvent;
        public event PlayFabResultEvent<DeleteFilesResponse> OnEntityDeleteFilesResultEvent;
        public event PlayFabRequestEvent<DeleteGroupRequest> OnEntityDeleteGroupRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityDeleteGroupResultEvent;
        public event PlayFabRequestEvent<DeleteInviteRequest> OnEntityDeleteInviteRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityDeleteInviteResultEvent;
        public event PlayFabRequestEvent<DeleteJoinRequestRequest> OnEntityDeleteJoinRequestRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityDeleteJoinRequestResultEvent;
        public event PlayFabRequestEvent<DeleteRoleRequest> OnEntityDeleteRoleRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityDeleteRoleResultEvent;
        public event PlayFabRequestEvent<FinalizeFileUploadsRequest> OnEntityFinalizeFileUploadsRequestEvent;
        public event PlayFabResultEvent<FinalizeFileUploadsResponse> OnEntityFinalizeFileUploadsResultEvent;
        public event PlayFabRequestEvent<GetEntityTokenRequest> OnEntityGetEntityTokenRequestEvent;
        public event PlayFabResultEvent<GetEntityTokenResponse> OnEntityGetEntityTokenResultEvent;
        public event PlayFabRequestEvent<GetFilesRequest> OnEntityGetFilesRequestEvent;
        public event PlayFabResultEvent<GetFilesResponse> OnEntityGetFilesResultEvent;
        public event PlayFabRequestEvent<GetGroupRequest> OnEntityGetGroupRequestEvent;
        public event PlayFabResultEvent<GetGroupResponse> OnEntityGetGroupResultEvent;
        public event PlayFabRequestEvent<GetObjectsRequest> OnEntityGetObjectsRequestEvent;
        public event PlayFabResultEvent<GetObjectsResponse> OnEntityGetObjectsResultEvent;
        public event PlayFabRequestEvent<GetEntityProfileRequest> OnEntityGetProfileRequestEvent;
        public event PlayFabResultEvent<GetEntityProfileResponse> OnEntityGetProfileResultEvent;
        public event PlayFabRequestEvent<GetGroupRoleRequest> OnEntityGetRoleRequestEvent;
        public event PlayFabResultEvent<GetGroupRoleResponse> OnEntityGetRoleResultEvent;
        public event PlayFabRequestEvent<InitiateFileUploadsRequest> OnEntityInitiateFileUploadsRequestEvent;
        public event PlayFabResultEvent<InitiateFileUploadsResponse> OnEntityInitiateFileUploadsResultEvent;
        public event PlayFabRequestEvent<IsMemberOfGroupRequest> OnEntityIsMemberOfGroupRequestEvent;
        public event PlayFabResultEvent<IsMemberOfGroupResponse> OnEntityIsMemberOfGroupResultEvent;
        public event PlayFabRequestEvent<IsMemberOfRoleRequest> OnEntityIsMemberOfRoleRequestEvent;
        public event PlayFabResultEvent<IsMemberOfRoleResponse> OnEntityIsMemberOfRoleResultEvent;
        public event PlayFabRequestEvent<ListGroupBlockRequest> OnEntityListBlocksRequestEvent;
        public event PlayFabResultEvent<ListGroupBlockResponse> OnEntityListBlocksResultEvent;
        public event PlayFabRequestEvent<ListGroupAndRolesMembershipRequest> OnEntityListGroupAndRolesMembershipRequestEvent;
        public event PlayFabResultEvent<ListGroupAndRoleResponse> OnEntityListGroupAndRolesMembershipResultEvent;
        public event PlayFabRequestEvent<ListGroupMembersRequest> OnEntityListGroupMembersRequestEvent;
        public event PlayFabResultEvent<ListGroupMembersResponse> OnEntityListGroupMembersResultEvent;
        public event PlayFabRequestEvent<ListGroupMembersByRoleRequest> OnEntityListGroupMembersByRoleRequestEvent;
        public event PlayFabResultEvent<ListGroupMembersByRoleResponse> OnEntityListGroupMembersByRoleResultEvent;
        public event PlayFabRequestEvent<ListGroupRolesRequest> OnEntityListGroupRolesRequestEvent;
        public event PlayFabResultEvent<ListGroupRolesResponse> OnEntityListGroupRolesResultEvent;
        public event PlayFabRequestEvent<ListGroupInviteRequest> OnEntityListInvitesRequestEvent;
        public event PlayFabResultEvent<ListGroupInviteResponse> OnEntityListInvitesResultEvent;
        public event PlayFabRequestEvent<ListGroupJoinRequestRequest> OnEntityListJoinRequestsRequestEvent;
        public event PlayFabResultEvent<ListGroupJoinRequestResponse> OnEntityListJoinRequestsResultEvent;
        public event PlayFabRequestEvent<ListMyJoinRequestsAndInvitesRequest> OnEntityListMyInvitesRequestEvent;
        public event PlayFabResultEvent<ListMyJoinRequestsAndInvitesResponse> OnEntityListMyInvitesResultEvent;
        public event PlayFabRequestEvent<ListRoleMembersRequest> OnEntityListRoleMembersRequestEvent;
        public event PlayFabResultEvent<ListRoleMembersResponse> OnEntityListRoleMembersResultEvent;
        public event PlayFabRequestEvent<RemoveGroupBlockRequest> OnEntityRemoveBlockRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityRemoveBlockResultEvent;
        public event PlayFabRequestEvent<RemoveGroupMembersRequest> OnEntityRemoveGroupMembersRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityRemoveGroupMembersResultEvent;
        public event PlayFabRequestEvent<RemoveRoleMembersRequest> OnEntityRemoveRoleMembersRequestEvent;
        public event PlayFabResultEvent<EmptyResult> OnEntityRemoveRoleMembersResultEvent;
        public event PlayFabRequestEvent<SetObjectsRequest> OnEntitySetObjectsRequestEvent;
        public event PlayFabResultEvent<SetObjectsResponse> OnEntitySetObjectsResultEvent;
        public event PlayFabRequestEvent<SetEntityProfilePolicyRequest> OnEntitySetProfilePolicyRequestEvent;
        public event PlayFabResultEvent<SetEntityProfilePolicyResponse> OnEntitySetProfilePolicyResultEvent;
        public event PlayFabRequestEvent<UpdateGroupRequest> OnEntityUpdateGroupRequestEvent;
        public event PlayFabResultEvent<UpdateGroupResponse> OnEntityUpdateGroupResultEvent;
        public event PlayFabRequestEvent<UpdateGroupRoleRequest> OnEntityUpdateRoleRequestEvent;
        public event PlayFabResultEvent<UpdateGroupRoleResponse> OnEntityUpdateRoleResultEvent;
    }
}
#endif
