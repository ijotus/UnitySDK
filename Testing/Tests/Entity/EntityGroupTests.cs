using System.Collections.Generic;
using PlayFab.Json;
using UnityEngine;

#if !DISABLE_PLAYFABCLIENT_API && ENABLE_PLAYFABSERVER_API && ENABLE_PLAYFABENTITY_API

namespace PlayFab.UUnit
{
    public class EntityGroupTests : UUnitTestCase
    {
        private TestTitleDataLoader.TestTitleData _testTitleData;

        private const string TestGroupName = "TestGroup2";

        // Test variables
        private int _testInteger;
        private string _playFabId;
        private string _playerEntityId;
        private string _groupId;
        private readonly string[] _characterNames = { "Ragnar", "Alena", "Brey" };
        private readonly Dictionary<string, string> _charIdbyName = new Dictionary<string, string>();

        public override void ClassSetUp()
        {
            PlayFabEntityAPI.ForgetAllCredentials();
        }

        public override void SetUp(UUnitTestContext testContext)
        {
            if (string.IsNullOrEmpty(PlayFabSettings.DeveloperSecretKey))
                testContext.Fail("Cannot get a title token without the devSecretKey.");

            _testTitleData = TestTitleDataLoader.LoadTestTitleData();

            // Verify all the inputs won't cause crashes in the tests
            var titleInfoSet = !string.IsNullOrEmpty(PlayFabSettings.TitleId);
            if (!titleInfoSet)
                testContext.Skip(); // We cannot do client tests if the titleId is not given

            if (_testTitleData.extraHeaders != null)
                foreach (var pair in _testTitleData.extraHeaders)
                    Internal.PlayFabHttp.GlobalHeaderInjection[pair.Key] = pair.Value;
        }

        public override void Tick(UUnitTestContext testContext)
        {
            // Do nothing, because the test finishes asynchronously
        }

        public override void TearDown(UUnitTestContext testContext)
        {
            if (PlayFabClientAPI.IsClientLoggedIn())
                testContext.Fail("This test suite should not result in a permanent client login.");
        }

        public override void ClassTearDown()
        {
            PlayFabEntityAPI.ForgetAllCredentials();
        }

        private void OnSharedError(PlayFabError error)
        {
            // This error was not expected.  Report it and fail.
            ((UUnitTestContext)error.CustomData).Fail(error.GenerateErrorReport());
        }

        [UUnitTest]
        public void EntityClientLogin(UUnitTestContext testContext)
        {
            var loginRequest = new ClientModels.LoginWithCustomIDRequest
            {
                CustomId = PlayFabSettings.BuildIdentifier,
                CreateAccount = true,
                LoginTitlePlayerAccountEntity = true
            };
            PlayFabClientAPI.LoginWithCustomID(loginRequest, PlayFabUUnitUtils.ApiActionWrapper<ClientModels.LoginResult>(testContext, OnLogin), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, OnSharedError), testContext);
        }
        private void OnLogin(ClientModels.LoginResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.True(PlayFabClientAPI.IsClientLoggedIn(), "User login failed");
            _playerEntityId = result.EntityToken.EntityId;
            _playFabId = result.PlayFabId;

            PlayFabClientAPI.ForgetAllCredentials(); // I don't want to be logged in as a client, I just want the IDs.
            testContext.EndTest(UUnitFinishState.PASSED, PlayFabSettings.TitleId + ", " + result.PlayFabId);
        }

        [UUnitTest]
        public void GetTitleEntityToken(UUnitTestContext testContext)
        {
            if (PlayFabClientAPI.IsClientLoggedIn())
                testContext.Fail("Cannot get a title token if the client is logged in.");

            PlayFabEntityAPI.GetEntityToken(null, PlayFabUUnitUtils.ApiActionWrapper<EntityModels.GetEntityTokenResponse>(testContext, OnGetTitleEntityToken), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, OnSharedError), testContext);
        }
        public void OnGetTitleEntityToken(EntityModels.GetEntityTokenResponse result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            testContext.False(PlayFabClientAPI.IsClientLoggedIn());
            testContext.ObjEquals(result.EntityId, PlayFabSettings.TitleId);
            testContext.StringEquals(result.EntityType, EntityModels.EntityTypes.title.ToString());

            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        [UUnitTest]
        public void GenerateCharacters(UUnitTestContext testContext)
        {
            var request = new ServerModels.ListUsersCharactersRequest { PlayFabId = _playFabId };
            PlayFabServerAPI.GetAllUsersCharacters(request, PlayFabUUnitUtils.ApiActionWrapper<ServerModels.ListUsersCharactersResult>(testContext, OnGetCharacters), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, OnSharedError), testContext);
        }

        private void OnGetCharacters(ServerModels.ListUsersCharactersResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            var needChars = new HashSet<string>(_characterNames);
            foreach (var pfChar in result.Characters)
            {
                if (needChars.Remove(pfChar.CharacterName))
                {
                    Debug.LogWarning("Got Char: " + pfChar.CharacterName + ", " + pfChar.CharacterId);
                    _charIdbyName[pfChar.CharacterName] = pfChar.CharacterId;
                }
            }

            if (needChars.Count > 0)
            {
                foreach (var eachCharName in needChars)
                {
                    var request = new ServerModels.GrantCharacterToUserRequest { PlayFabId = _playFabId, CharacterName = eachCharName, CharacterType = "test" };
                    PlayFabServerAPI.GrantCharacterToUser(request, PlayFabUUnitUtils.ApiActionWrapper<ServerModels.GrantCharacterToUserResult>(testContext, OnGrantChar), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, OnSharedError), testContext);
                }
            }
            else
            {
                testContext.EndTest(UUnitFinishState.PASSED, JsonWrapper.SerializeObject(_charIdbyName));
                Debug.LogWarning("OnGetCharacters Chars: " + JsonWrapper.SerializeObject(_charIdbyName));
            }
        }
        private void OnGrantChar(ServerModels.GrantCharacterToUserResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            var request = new ServerModels.ListUsersCharactersRequest { PlayFabId = _playFabId };
            PlayFabServerAPI.GetAllUsersCharacters(request, PlayFabUUnitUtils.ApiActionWrapper<ServerModels.ListUsersCharactersResult>(testContext, OnGetCharacters), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, OnSharedError), testContext);
        }

        // [UUnitTest]
        public void CleanGuildMemberships(UUnitTestContext testContext)
        {
            _testInteger = _charIdbyName.Count + 1;

            // Get the 
            var request = new EntityModels.ListMembershipRequest
            {
                EntityId = _playerEntityId,
                EntityType = EntityModels.EntityTypes.title_player_account
            };
            PlayFabEntityAPI.ListMembership(request, PlayFabUUnitUtils.ApiActionWrapper<EntityModels.ListMembershipResponse>(testContext, ClearGroupsForEntity), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, OnSharedError), testContext);

            foreach (var eachPair in _charIdbyName)
            {
                request.EntityId = eachPair.Value;
                request.EntityType = EntityModels.EntityTypes.character;
                PlayFabEntityAPI.ListMembership(request, PlayFabUUnitUtils.ApiActionWrapper<EntityModels.ListMembershipResponse>(testContext, ClearGroupsForEntity), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, OnSharedError), testContext);
            }
        }
        private void ClearGroupsForEntity(EntityModels.ListMembershipResponse result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            foreach (var group in result.Groups)
            {
                var request = new EntityModels.DeleteGroupRequest { GroupId = group.GroupId };
                PlayFabEntityAPI.DeleteGroup(request, PlayFabUUnitUtils.ApiActionWrapper<EntityModels.EmptyResult>(testContext, OnClearGroup), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, OnSharedError), testContext);
            }

            if (result.Groups.Count == 0)
                OnClearGroup(new EntityModels.EmptyResult { CustomData = testContext });
        }
        private void OnClearGroup(EntityModels.EmptyResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            _testInteger--;
            if (_testInteger == 0)
                testContext.EndTest(UUnitFinishState.PASSED, null);
            else if (_testInteger < 0)
                testContext.Fail("Failure with the test itself: More callbacks received, than API calls expected to be made");
        }

        [UUnitTest]
        public void CreateGroup(UUnitTestContext testContext)
        {
            var request = new EntityModels.CreateGroupRequest { GroupName = TestGroupName, EntityId = _charIdbyName["Ragnar"], EntityType = EntityModels.EntityTypes.character };
            PlayFabEntityAPI.CreateGroup(request, PlayFabUUnitUtils.ApiActionWrapper<EntityModels.CreateGroupResponse>(testContext, OnCreateGroup), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, OnSharedError), testContext);
        }
        private void OnCreateGroup(EntityModels.CreateGroupResponse result)
        {
            _groupId = result.GroupId;

            var testContext = (UUnitTestContext)result.CustomData;
            var prevRequest = (EntityModels.CreateGroupRequest) result.Request;

            testContext.EndTest(UUnitFinishState.PASSED, "GroupId: " + _groupId + ", CharacterId:" + prevRequest.EntityId);
        }

        [UUnitTest]
        public void InviteAndAccept(UUnitTestContext testContext)
        {
            var request = new EntityModels.InviteToGroupRequest { GroupId = _groupId, EntityId = _charIdbyName["Alena"], EntityType = EntityModels.EntityTypes.character };
            PlayFabEntityAPI.InviteToGroup(request, PlayFabUUnitUtils.ApiActionWrapper<EntityModels.InviteToGroupResponse>(testContext, OnInvite), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, OnSharedError), testContext);
        }
        public void OnInvite(EntityModels.InviteToGroupResponse result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            var prevRequest = (EntityModels.InviteToGroupRequest)result.Request;

            var request = new EntityModels.AcceptGroupInvitationRequest { GroupId = _groupId, EntityId = prevRequest.EntityId, EntityType = EntityModels.EntityTypes.character };
            PlayFabEntityAPI.AcceptGroupInvitation(request, PlayFabUUnitUtils.ApiActionWrapper<EntityModels.EmptyResult>(testContext, OnAcceptInvite), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, OnSharedError), testContext);
        }
        public void OnAcceptInvite(EntityModels.EmptyResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            var prevRequest = (EntityModels.AcceptGroupInvitationRequest)result.Request;

            testContext.EndTest(UUnitFinishState.PASSED, "GroupId: " + _groupId + ", CharacterId:" + prevRequest.EntityId);
        }

        [UUnitTest]
        public void ApplyAndAccept(UUnitTestContext testContext)
        {
            Debug.LogWarning("Apply Chars: " + JsonWrapper.SerializeObject(_charIdbyName));
            var request = new EntityModels.ApplyToGroupRequest { GroupId = _groupId, EntityId = _charIdbyName["Brey"], EntityType = EntityModels.EntityTypes.character };
            PlayFabEntityAPI.ApplyToGroup(request, PlayFabUUnitUtils.ApiActionWrapper<EntityModels.GetGroupApplicationResponse>(testContext, OnApply), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, OnSharedError), testContext);
        }
        public void OnApply(EntityModels.GetGroupApplicationResponse result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            var prevRequest = (EntityModels.ApplyToGroupRequest)result.Request;

            var request = new EntityModels.AcceptGroupApplicationRequest { GroupId = _groupId, EntityId = prevRequest.EntityId, EntityType = EntityModels.EntityTypes.character };
            PlayFabEntityAPI.AcceptGroupApplication(request, PlayFabUUnitUtils.ApiActionWrapper<EntityModels.EmptyResult>(testContext, OnAcceptApplication), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, OnSharedError), testContext);
        }
        public void OnAcceptApplication(EntityModels.EmptyResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            var prevRequest = (EntityModels.AcceptGroupApplicationRequest)result.Request;

            testContext.EndTest(UUnitFinishState.PASSED, "GroupId: " + _groupId + ", CharacterId:" + prevRequest.EntityId);
        }

        [UUnitTest]
        public void KickMember(UUnitTestContext testContext)
        {
            Debug.LogWarning("Kick Chars: " + JsonWrapper.SerializeObject(_charIdbyName));
            var kickList = new List<EntityModels.EntityTypeId>
            {
                new EntityModels.EntityTypeId { EntityType = EntityModels.EntityTypes.character, EntityId = _charIdbyName["Brey"] },
                new EntityModels.EntityTypeId { EntityType = EntityModels.EntityTypes.character, EntityId = _charIdbyName["Alena"] },
            };
            var request = new EntityModels.RemoveMembersRequest { GroupId = _groupId, Members = kickList };
            PlayFabEntityAPI.RemoveMembers(request, PlayFabUUnitUtils.ApiActionWrapper<EntityModels.EmptyResult>(testContext, OnRemoveMembers), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, OnSharedError), testContext);
        }
        private void OnRemoveMembers(EntityModels.EmptyResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        [UUnitTest]
        public void FinalDeleteGroup(UUnitTestContext testContext)
        {
            var request = new EntityModels.DeleteGroupRequest { GroupId = _groupId };
            PlayFabEntityAPI.DeleteGroup(request, PlayFabUUnitUtils.ApiActionWrapper<EntityModels.EmptyResult>(testContext, OnDelGroup), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, OnSharedError), testContext);
        }
        private void OnDelGroup(EntityModels.EmptyResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.EndTest(UUnitFinishState.PASSED, _groupId);
        }
    }
}
#endif
