using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.injector.api;
using strange.extensions.mediation.api;

public class PlayFabContextManager : StrangePackage
{
    public override void MapBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
        // Bind Context & Commands

        #region Matchmaking
        /// <summary>
        /// Validates a user with the PlayFab service
        /// </summary>
        injectionBinder.Bind<AuthUserSignal>();
        injectionBinder.Bind<AuthUserResponseSignal>();
        commandBinder.Bind<AuthUserSignal>().To<AuthUserCommand>();
        commandBinder.Bind<AuthUserResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Informs the PlayFab game server hosting service that the indicated user has joined the Game Server Instance specified
        /// </summary>
        injectionBinder.Bind<PlayerJoinedSignal>();
        injectionBinder.Bind<PlayerJoinedResponseSignal>();
        commandBinder.Bind<PlayerJoinedSignal>().To<PlayerJoinedCommand>();
        commandBinder.Bind<PlayerJoinedResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Informs the PlayFab game server hosting service that the indicated user has left the Game Server Instance specified
        /// </summary>
        injectionBinder.Bind<PlayerLeftSignal>();
        injectionBinder.Bind<PlayerLeftResponseSignal>();
        commandBinder.Bind<PlayerLeftSignal>().To<PlayerLeftCommand>();
        commandBinder.Bind<PlayerLeftResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Instructs the PlayFab game server hosting service to instantiate a new Game Server Instance
        /// </summary>
        injectionBinder.Bind<StartGameSignal>();
        injectionBinder.Bind<StartGameResponseSignal>();
        commandBinder.Bind<StartGameSignal>().To<StartGameCommand>();
        commandBinder.Bind<StartGameResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the relevant details for a specified user, which the external match-making service can then use to compute
        /// effective matches
        /// </summary>
        injectionBinder.Bind<UserInfoSignal>();
        injectionBinder.Bind<UserInfoResponseSignal>();
        commandBinder.Bind<UserInfoSignal>().To<UserInfoCommand>();
        commandBinder.Bind<UserInfoResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Account Management
        /// <summary>
        /// Bans users by PlayFab ID with optional IP address, or MAC address for the provided game.
        /// </summary>
        injectionBinder.Bind<BanUsersSignal>();
        injectionBinder.Bind<BanUsersResponseSignal>();
        commandBinder.Bind<BanUsersSignal>().To<BanUsersCommand>();
        commandBinder.Bind<BanUsersResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the player's profile
        /// </summary>
        injectionBinder.Bind<GetPlayerProfileSignal>();
        injectionBinder.Bind<GetPlayerProfileResponseSignal>();
        commandBinder.Bind<GetPlayerProfileSignal>().To<GetPlayerProfileCommand>();
        commandBinder.Bind<GetPlayerProfileResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
        /// </summary>
        injectionBinder.Bind<GetPlayFabIDsFromFacebookIDsSignal>();
        injectionBinder.Bind<GetPlayFabIDsFromFacebookIDsResponseSignal>();
        commandBinder.Bind<GetPlayFabIDsFromFacebookIDsSignal>().To<GetPlayFabIDsFromFacebookIDsCommand>();
        commandBinder.Bind<GetPlayFabIDsFromFacebookIDsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers  are the profile
        /// IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
        /// </summary>
        injectionBinder.Bind<GetPlayFabIDsFromSteamIDsSignal>();
        injectionBinder.Bind<GetPlayFabIDsFromSteamIDsResponseSignal>();
        commandBinder.Bind<GetPlayFabIDsFromSteamIDsSignal>().To<GetPlayFabIDsFromSteamIDsCommand>();
        commandBinder.Bind<GetPlayFabIDsFromSteamIDsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the relevant details for a specified user
        /// </summary>
        injectionBinder.Bind<GetUserAccountInfoSignal>();
        injectionBinder.Bind<GetUserAccountInfoResponseSignal>();
        commandBinder.Bind<GetUserAccountInfoSignal>().To<GetUserAccountInfoCommand>();
        commandBinder.Bind<GetUserAccountInfoResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Gets all bans for a user.
        /// </summary>
        injectionBinder.Bind<GetUserBansSignal>();
        injectionBinder.Bind<GetUserBansResponseSignal>();
        commandBinder.Bind<GetUserBansSignal>().To<GetUserBansCommand>();
        commandBinder.Bind<GetUserBansResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Revoke all active bans for a user.
        /// </summary>
        injectionBinder.Bind<RevokeAllBansForUserSignal>();
        injectionBinder.Bind<RevokeAllBansForUserResponseSignal>();
        commandBinder.Bind<RevokeAllBansForUserSignal>().To<RevokeAllBansForUserCommand>();
        commandBinder.Bind<RevokeAllBansForUserResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Revoke all active bans specified with BanId.
        /// </summary>
        injectionBinder.Bind<RevokeBansSignal>();
        injectionBinder.Bind<RevokeBansResponseSignal>();
        commandBinder.Bind<RevokeBansSignal>().To<RevokeBansCommand>();
        commandBinder.Bind<RevokeBansResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Forces an email to be sent to the registered contact email address for the user's account based on an account recovery
        /// email template
        /// </summary>
        injectionBinder.Bind<SendCustomAccountRecoveryEmailSignal>();
        injectionBinder.Bind<SendCustomAccountRecoveryEmailResponseSignal>();
        commandBinder.Bind<SendCustomAccountRecoveryEmailSignal>().To<SendCustomAccountRecoveryEmailCommand>();
        commandBinder.Bind<SendCustomAccountRecoveryEmailResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Sends an email based on an email template to a player's contact email
        /// </summary>
        injectionBinder.Bind<SendEmailFromTemplateSignal>();
        injectionBinder.Bind<SendEmailFromTemplateResponseSignal>();
        commandBinder.Bind<SendEmailFromTemplateSignal>().To<SendEmailFromTemplateCommand>();
        commandBinder.Bind<SendEmailFromTemplateResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured for Push
        /// Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
        /// </summary>
        injectionBinder.Bind<SendPushNotificationSignal>();
        injectionBinder.Bind<SendPushNotificationResponseSignal>();
        commandBinder.Bind<SendPushNotificationSignal>().To<SendPushNotificationCommand>();
        commandBinder.Bind<SendPushNotificationResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Update the avatar URL of the specified player
        /// </summary>
        injectionBinder.Bind<UpdateAvatarUrlSignal>();
        injectionBinder.Bind<UpdateAvatarUrlResponseSignal>();
        commandBinder.Bind<UpdateAvatarUrlSignal>().To<UpdateAvatarUrlCommand>();
        commandBinder.Bind<UpdateAvatarUrlResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates information of a list of existing bans specified with Ban Ids.
        /// </summary>
        injectionBinder.Bind<UpdateBansSignal>();
        injectionBinder.Bind<UpdateBansResponseSignal>();
        commandBinder.Bind<UpdateBansSignal>().To<UpdateBansCommand>();
        commandBinder.Bind<UpdateBansResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Analytics
        /// <summary>
        /// Writes a character-based event into PlayStream.
        /// </summary>
        injectionBinder.Bind<WriteCharacterEventSignal>();
        injectionBinder.Bind<WriteCharacterEventResponseSignal>();
        commandBinder.Bind<WriteCharacterEventSignal>().To<WriteCharacterEventCommand>();
        commandBinder.Bind<WriteCharacterEventResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Writes a player-based event into PlayStream.
        /// </summary>
        injectionBinder.Bind<WritePlayerEventSignal>();
        injectionBinder.Bind<WritePlayerEventResponseSignal>();
        commandBinder.Bind<WritePlayerEventSignal>().To<WritePlayerEventCommand>();
        commandBinder.Bind<WritePlayerEventResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Writes a title-based event into PlayStream.
        /// </summary>
        injectionBinder.Bind<WriteTitleEventSignal>();
        injectionBinder.Bind<WriteTitleEventResponseSignal>();
        commandBinder.Bind<WriteTitleEventSignal>().To<WriteTitleEventCommand>();
        commandBinder.Bind<WriteTitleEventResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Authentication
        /// <summary>
        /// Validated a client's session ticket, and if successful, returns details for that user
        /// </summary>
        injectionBinder.Bind<AuthenticateSessionTicketSignal>();
        injectionBinder.Bind<AuthenticateSessionTicketResponseSignal>();
        commandBinder.Bind<AuthenticateSessionTicketSignal>().To<AuthenticateSessionTicketCommand>();
        commandBinder.Bind<AuthenticateSessionTicketResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Sets the player's secret if it is not already set. Player secrets are used to sign API requests. To reset a player's
        /// secret use the Admin or Server API method SetPlayerSecret.
        /// </summary>
        injectionBinder.Bind<SetPlayerSecretSignal>();
        injectionBinder.Bind<SetPlayerSecretResponseSignal>();
        commandBinder.Bind<SetPlayerSecretSignal>().To<SetPlayerSecretCommand>();
        commandBinder.Bind<SetPlayerSecretResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Character Data
        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        injectionBinder.Bind<GetCharacterDataSignal>();
        injectionBinder.Bind<GetCharacterDataResponseSignal>();
        commandBinder.Bind<GetCharacterDataSignal>().To<GetCharacterDataCommand>();
        commandBinder.Bind<GetCharacterDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the title-specific custom data for the user's character which cannot be accessed by the client
        /// </summary>
        injectionBinder.Bind<GetCharacterInternalDataSignal>();
        injectionBinder.Bind<GetCharacterInternalDataResponseSignal>();
        commandBinder.Bind<GetCharacterInternalDataSignal>().To<GetCharacterInternalDataCommand>();
        commandBinder.Bind<GetCharacterInternalDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the title-specific custom data for the user's character which can only be read by the client
        /// </summary>
        injectionBinder.Bind<GetCharacterReadOnlyDataSignal>();
        injectionBinder.Bind<GetCharacterReadOnlyDataResponseSignal>();
        commandBinder.Bind<GetCharacterReadOnlyDataSignal>().To<GetCharacterReadOnlyDataCommand>();
        commandBinder.Bind<GetCharacterReadOnlyDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the title-specific custom data for the user's character which is readable and writable by the client
        /// </summary>
        injectionBinder.Bind<UpdateCharacterDataSignal>();
        injectionBinder.Bind<UpdateCharacterDataResponseSignal>();
        commandBinder.Bind<UpdateCharacterDataSignal>().To<UpdateCharacterDataCommand>();
        commandBinder.Bind<UpdateCharacterDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the title-specific custom data for the user's character which cannot  be accessed by the client
        /// </summary>
        injectionBinder.Bind<UpdateCharacterInternalDataSignal>();
        injectionBinder.Bind<UpdateCharacterInternalDataResponseSignal>();
        commandBinder.Bind<UpdateCharacterInternalDataSignal>().To<UpdateCharacterInternalDataCommand>();
        commandBinder.Bind<UpdateCharacterInternalDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the title-specific custom data for the user's character which can only be read by the client
        /// </summary>
        injectionBinder.Bind<UpdateCharacterReadOnlyDataSignal>();
        injectionBinder.Bind<UpdateCharacterReadOnlyDataResponseSignal>();
        commandBinder.Bind<UpdateCharacterReadOnlyDataSignal>().To<UpdateCharacterReadOnlyDataCommand>();
        commandBinder.Bind<UpdateCharacterReadOnlyDataResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Characters
        /// <summary>
        /// Deletes the specific character ID from the specified user.
        /// </summary>
        injectionBinder.Bind<DeleteCharacterFromUserSignal>();
        injectionBinder.Bind<DeleteCharacterFromUserResponseSignal>();
        commandBinder.Bind<DeleteCharacterFromUserSignal>().To<DeleteCharacterFromUserCommand>();
        commandBinder.Bind<DeleteCharacterFromUserResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Lists all of the characters that belong to a specific user. CharacterIds are not globally unique; characterId must be
        /// evaluated with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        injectionBinder.Bind<GetAllUsersCharactersSignal>();
        injectionBinder.Bind<GetAllUsersCharactersResponseSignal>();
        commandBinder.Bind<GetAllUsersCharactersSignal>().To<GetAllUsersCharactersCommand>();
        commandBinder.Bind<GetAllUsersCharactersResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        injectionBinder.Bind<GetCharacterLeaderboardSignal>();
        injectionBinder.Bind<GetCharacterLeaderboardResponseSignal>();
        commandBinder.Bind<GetCharacterLeaderboardSignal>().To<GetCharacterLeaderboardCommand>();
        commandBinder.Bind<GetCharacterLeaderboardResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the details of all title-specific statistics for the specific character
        /// </summary>
        injectionBinder.Bind<GetCharacterStatisticsSignal>();
        injectionBinder.Bind<GetCharacterStatisticsResponseSignal>();
        commandBinder.Bind<GetCharacterStatisticsSignal>().To<GetCharacterStatisticsCommand>();
        commandBinder.Bind<GetCharacterStatisticsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, centered on the requested user
        /// </summary>
        injectionBinder.Bind<GetLeaderboardAroundCharacterSignal>();
        injectionBinder.Bind<GetLeaderboardAroundCharacterResponseSignal>();
        commandBinder.Bind<GetLeaderboardAroundCharacterSignal>().To<GetLeaderboardAroundCharacterCommand>();
        commandBinder.Bind<GetLeaderboardAroundCharacterResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves a list of all of the user's characters for the given statistic.
        /// </summary>
        injectionBinder.Bind<GetLeaderboardForUserCharactersSignal>();
        injectionBinder.Bind<GetLeaderboardForUserCharactersResponseSignal>();
        commandBinder.Bind<GetLeaderboardForUserCharactersSignal>().To<GetLeaderboardForUserCharactersCommand>();
        commandBinder.Bind<GetLeaderboardForUserCharactersResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Grants the specified character type to the user. CharacterIds are not globally unique; characterId must be evaluated
        /// with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        injectionBinder.Bind<GrantCharacterToUserSignal>();
        injectionBinder.Bind<GrantCharacterToUserResponseSignal>();
        commandBinder.Bind<GrantCharacterToUserSignal>().To<GrantCharacterToUserCommand>();
        commandBinder.Bind<GrantCharacterToUserResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the specific character
        /// </summary>
        injectionBinder.Bind<UpdateCharacterStatisticsSignal>();
        injectionBinder.Bind<UpdateCharacterStatisticsResponseSignal>();
        commandBinder.Bind<UpdateCharacterStatisticsSignal>().To<UpdateCharacterStatisticsCommand>();
        commandBinder.Bind<UpdateCharacterStatisticsResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Content
        /// <summary>
        /// This API retrieves a pre-signed URL for accessing a content file for the title. A subsequent  HTTP GET to the returned
        /// URL will attempt to download the content. A HEAD query to the returned URL will attempt to  retrieve the metadata of the
        /// content. Note that a successful result does not guarantee the existence of this content -  if it has not been uploaded,
        /// the query to retrieve the data will fail. See this post for more information:
        /// https://community.playfab.com/hc/en-us/community/posts/205469488-How-to-upload-files-to-PlayFab-s-Content-Service.
        /// Also, please be aware that the Content service is specifically PlayFab's CDN offering, for which standard CDN rates
        /// apply.
        /// </summary>
        injectionBinder.Bind<GetContentDownloadUrlSignal>();
        injectionBinder.Bind<GetContentDownloadUrlResponseSignal>();
        commandBinder.Bind<GetContentDownloadUrlSignal>().To<GetContentDownloadUrlCommand>();
        commandBinder.Bind<GetContentDownloadUrlResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Friend List Management
        /// <summary>
        /// Adds the Friend user to the friendlist of the user with PlayFabId. At least one of
        /// FriendPlayFabId,FriendUsername,FriendEmail, or FriendTitleDisplayName should be initialized.
        /// </summary>
        injectionBinder.Bind<AddFriendSignal>();
        injectionBinder.Bind<AddFriendResponseSignal>();
        commandBinder.Bind<AddFriendSignal>().To<AddFriendCommand>();
        commandBinder.Bind<AddFriendResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the current friends for the user with PlayFabId, constrained to users who have PlayFab accounts. Friends from
        /// linked accounts (Facebook, Steam) are also included. You may optionally exclude some linked services' friends.
        /// </summary>
        injectionBinder.Bind<GetFriendsListSignal>();
        injectionBinder.Bind<GetFriendsListResponseSignal>();
        commandBinder.Bind<GetFriendsListSignal>().To<GetFriendsListCommand>();
        commandBinder.Bind<GetFriendsListResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Removes the specified friend from the the user's friend list
        /// </summary>
        injectionBinder.Bind<RemoveFriendSignal>();
        injectionBinder.Bind<RemoveFriendResponseSignal>();
        commandBinder.Bind<RemoveFriendSignal>().To<RemoveFriendCommand>();
        commandBinder.Bind<RemoveFriendResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the tag list for a specified user in the friend list of another user
        /// </summary>
        injectionBinder.Bind<SetFriendTagsSignal>();
        injectionBinder.Bind<SetFriendTagsResponseSignal>();
        commandBinder.Bind<SetFriendTagsSignal>().To<SetFriendTagsCommand>();
        commandBinder.Bind<SetFriendTagsResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Matchmaking
        /// <summary>
        /// Inform the matchmaker that a Game Server Instance is removed.
        /// </summary>
        injectionBinder.Bind<DeregisterGameSignal>();
        injectionBinder.Bind<DeregisterGameResponseSignal>();
        commandBinder.Bind<DeregisterGameSignal>().To<DeregisterGameCommand>();
        commandBinder.Bind<DeregisterGameResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Informs the PlayFab match-making service that the user specified has left the Game Server Instance
        /// </summary>
        injectionBinder.Bind<NotifyMatchmakerPlayerLeftSignal>();
        injectionBinder.Bind<NotifyMatchmakerPlayerLeftResponseSignal>();
        commandBinder.Bind<NotifyMatchmakerPlayerLeftSignal>().To<NotifyMatchmakerPlayerLeftCommand>();
        commandBinder.Bind<NotifyMatchmakerPlayerLeftResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Validates a Game Server session ticket and returns details about the user
        /// </summary>
        injectionBinder.Bind<RedeemMatchmakerTicketSignal>();
        injectionBinder.Bind<RedeemMatchmakerTicketResponseSignal>();
        commandBinder.Bind<RedeemMatchmakerTicketSignal>().To<RedeemMatchmakerTicketCommand>();
        commandBinder.Bind<RedeemMatchmakerTicketResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Set the state of the indicated Game Server Instance. Also update the heartbeat for the instance.
        /// </summary>
        injectionBinder.Bind<RefreshGameServerInstanceHeartbeatSignal>();
        injectionBinder.Bind<RefreshGameServerInstanceHeartbeatResponseSignal>();
        commandBinder.Bind<RefreshGameServerInstanceHeartbeatSignal>().To<RefreshGameServerInstanceHeartbeatCommand>();
        commandBinder.Bind<RefreshGameServerInstanceHeartbeatResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Inform the matchmaker that a new Game Server Instance is added.
        /// </summary>
        injectionBinder.Bind<RegisterGameSignal>();
        injectionBinder.Bind<RegisterGameResponseSignal>();
        commandBinder.Bind<RegisterGameSignal>().To<RegisterGameCommand>();
        commandBinder.Bind<RegisterGameResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Sets the custom data of the indicated Game Server Instance
        /// </summary>
        injectionBinder.Bind<SetGameServerInstanceDataSignal>();
        injectionBinder.Bind<SetGameServerInstanceDataResponseSignal>();
        commandBinder.Bind<SetGameServerInstanceDataSignal>().To<SetGameServerInstanceDataCommand>();
        commandBinder.Bind<SetGameServerInstanceDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Set the state of the indicated Game Server Instance.
        /// </summary>
        injectionBinder.Bind<SetGameServerInstanceStateSignal>();
        injectionBinder.Bind<SetGameServerInstanceStateResponseSignal>();
        commandBinder.Bind<SetGameServerInstanceStateSignal>().To<SetGameServerInstanceStateCommand>();
        commandBinder.Bind<SetGameServerInstanceStateResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Set custom tags for the specified Game Server Instance
        /// </summary>
        injectionBinder.Bind<SetGameServerInstanceTagsSignal>();
        injectionBinder.Bind<SetGameServerInstanceTagsResponseSignal>();
        commandBinder.Bind<SetGameServerInstanceTagsSignal>().To<SetGameServerInstanceTagsCommand>();
        commandBinder.Bind<SetGameServerInstanceTagsResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Platform Specific Methods
        /// <summary>
        /// Awards the specified users the specified Steam achievements
        /// </summary>
        injectionBinder.Bind<AwardSteamAchievementSignal>();
        injectionBinder.Bind<AwardSteamAchievementResponseSignal>();
        commandBinder.Bind<AwardSteamAchievementSignal>().To<AwardSteamAchievementCommand>();
        commandBinder.Bind<AwardSteamAchievementResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Player Data Management
        /// <summary>
        /// Deletes the users for the provided game. Deletes custom data, all account linkages, and statistics.
        /// </summary>
        injectionBinder.Bind<DeleteUsersSignal>();
        injectionBinder.Bind<DeleteUsersResponseSignal>();
        commandBinder.Bind<DeleteUsersSignal>().To<DeleteUsersCommand>();
        commandBinder.Bind<DeleteUsersResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves a list of ranked friends of the given player for the given statistic, starting from the indicated point in the
        /// leaderboard
        /// </summary>
        injectionBinder.Bind<GetFriendLeaderboardSignal>();
        injectionBinder.Bind<GetFriendLeaderboardResponseSignal>();
        commandBinder.Bind<GetFriendLeaderboardSignal>().To<GetFriendLeaderboardCommand>();
        commandBinder.Bind<GetFriendLeaderboardResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        injectionBinder.Bind<GetLeaderboardSignal>();
        injectionBinder.Bind<GetLeaderboardResponseSignal>();
        commandBinder.Bind<GetLeaderboardSignal>().To<GetLeaderboardCommand>();
        commandBinder.Bind<GetLeaderboardResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
        /// </summary>
        injectionBinder.Bind<GetLeaderboardAroundUserSignal>();
        injectionBinder.Bind<GetLeaderboardAroundUserResponseSignal>();
        commandBinder.Bind<GetLeaderboardAroundUserSignal>().To<GetLeaderboardAroundUserCommand>();
        commandBinder.Bind<GetLeaderboardAroundUserResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Returns whatever info is requested in the response for the user. Note that PII (like email address, facebook id)
        /// may be returned. All parameters default to false.
        /// </summary>
        injectionBinder.Bind<GetPlayerCombinedInfoSignal>();
        injectionBinder.Bind<GetPlayerCombinedInfoResponseSignal>();
        commandBinder.Bind<GetPlayerCombinedInfoSignal>().To<GetPlayerCombinedInfoCommand>();
        commandBinder.Bind<GetPlayerCombinedInfoResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the current version and values for the indicated statistics, for the local player.
        /// </summary>
        injectionBinder.Bind<GetPlayerStatisticsSignal>();
        injectionBinder.Bind<GetPlayerStatisticsResponseSignal>();
        commandBinder.Bind<GetPlayerStatisticsSignal>().To<GetPlayerStatisticsCommand>();
        commandBinder.Bind<GetPlayerStatisticsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the information on the available versions of the specified statistic.
        /// </summary>
        injectionBinder.Bind<GetPlayerStatisticVersionsSignal>();
        injectionBinder.Bind<GetPlayerStatisticVersionsResponseSignal>();
        commandBinder.Bind<GetPlayerStatisticVersionsSignal>().To<GetPlayerStatisticVersionsCommand>();
        commandBinder.Bind<GetPlayerStatisticVersionsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        injectionBinder.Bind<GetUserDataSignal>();
        injectionBinder.Bind<GetUserDataResponseSignal>();
        commandBinder.Bind<GetUserDataSignal>().To<GetUserDataCommand>();
        commandBinder.Bind<GetUserDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        injectionBinder.Bind<GetUserInternalDataSignal>();
        injectionBinder.Bind<GetUserInternalDataResponseSignal>();
        commandBinder.Bind<GetUserInternalDataSignal>().To<GetUserInternalDataCommand>();
        commandBinder.Bind<GetUserInternalDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        injectionBinder.Bind<GetUserPublisherDataSignal>();
        injectionBinder.Bind<GetUserPublisherDataResponseSignal>();
        commandBinder.Bind<GetUserPublisherDataSignal>().To<GetUserPublisherDataCommand>();
        commandBinder.Bind<GetUserPublisherDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        injectionBinder.Bind<GetUserPublisherInternalDataSignal>();
        injectionBinder.Bind<GetUserPublisherInternalDataResponseSignal>();
        commandBinder.Bind<GetUserPublisherInternalDataSignal>().To<GetUserPublisherInternalDataCommand>();
        commandBinder.Bind<GetUserPublisherInternalDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        injectionBinder.Bind<GetUserPublisherReadOnlyDataSignal>();
        injectionBinder.Bind<GetUserPublisherReadOnlyDataResponseSignal>();
        commandBinder.Bind<GetUserPublisherReadOnlyDataSignal>().To<GetUserPublisherReadOnlyDataCommand>();
        commandBinder.Bind<GetUserPublisherReadOnlyDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        injectionBinder.Bind<GetUserReadOnlyDataSignal>();
        injectionBinder.Bind<GetUserReadOnlyDataResponseSignal>();
        commandBinder.Bind<GetUserReadOnlyDataSignal>().To<GetUserReadOnlyDataCommand>();
        commandBinder.Bind<GetUserReadOnlyDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the user
        /// </summary>
        injectionBinder.Bind<UpdatePlayerStatisticsSignal>();
        injectionBinder.Bind<UpdatePlayerStatisticsResponseSignal>();
        commandBinder.Bind<UpdatePlayerStatisticsSignal>().To<UpdatePlayerStatisticsCommand>();
        commandBinder.Bind<UpdatePlayerStatisticsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        injectionBinder.Bind<UpdateUserDataSignal>();
        injectionBinder.Bind<UpdateUserDataResponseSignal>();
        commandBinder.Bind<UpdateUserDataSignal>().To<UpdateUserDataCommand>();
        commandBinder.Bind<UpdateUserDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        injectionBinder.Bind<UpdateUserInternalDataSignal>();
        injectionBinder.Bind<UpdateUserInternalDataResponseSignal>();
        commandBinder.Bind<UpdateUserInternalDataSignal>().To<UpdateUserInternalDataCommand>();
        commandBinder.Bind<UpdateUserInternalDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        injectionBinder.Bind<UpdateUserPublisherDataSignal>();
        injectionBinder.Bind<UpdateUserPublisherDataResponseSignal>();
        commandBinder.Bind<UpdateUserPublisherDataSignal>().To<UpdateUserPublisherDataCommand>();
        commandBinder.Bind<UpdateUserPublisherDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        injectionBinder.Bind<UpdateUserPublisherInternalDataSignal>();
        injectionBinder.Bind<UpdateUserPublisherInternalDataResponseSignal>();
        commandBinder.Bind<UpdateUserPublisherInternalDataSignal>().To<UpdateUserPublisherInternalDataCommand>();
        commandBinder.Bind<UpdateUserPublisherInternalDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        injectionBinder.Bind<UpdateUserPublisherReadOnlyDataSignal>();
        injectionBinder.Bind<UpdateUserPublisherReadOnlyDataResponseSignal>();
        commandBinder.Bind<UpdateUserPublisherReadOnlyDataSignal>().To<UpdateUserPublisherReadOnlyDataCommand>();
        commandBinder.Bind<UpdateUserPublisherReadOnlyDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the title-specific custom data for the user which can only be read by the client
        /// </summary>
        injectionBinder.Bind<UpdateUserReadOnlyDataSignal>();
        injectionBinder.Bind<UpdateUserReadOnlyDataResponseSignal>();
        commandBinder.Bind<UpdateUserReadOnlyDataSignal>().To<UpdateUserReadOnlyDataCommand>();
        commandBinder.Bind<UpdateUserReadOnlyDataResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Player Item Management
        /// <summary>
        /// Increments  the character's balance of the specified virtual currency by the stated amount
        /// </summary>
        injectionBinder.Bind<AddCharacterVirtualCurrencySignal>();
        injectionBinder.Bind<AddCharacterVirtualCurrencyResponseSignal>();
        commandBinder.Bind<AddCharacterVirtualCurrencySignal>().To<AddCharacterVirtualCurrencyCommand>();
        commandBinder.Bind<AddCharacterVirtualCurrencyResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Increments  the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        injectionBinder.Bind<AddUserVirtualCurrencySignal>();
        injectionBinder.Bind<AddUserVirtualCurrencyResponseSignal>();
        commandBinder.Bind<AddUserVirtualCurrencySignal>().To<AddUserVirtualCurrencyCommand>();
        commandBinder.Bind<AddUserVirtualCurrencyResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's inventory.
        /// </summary>
        injectionBinder.Bind<ConsumeItemSignal>();
        injectionBinder.Bind<ConsumeItemResponseSignal>();
        commandBinder.Bind<ConsumeItemSignal>().To<ConsumeItemCommand>();
        commandBinder.Bind<ConsumeItemResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Returns the result of an evaluation of a Random Result Table - the ItemId from the game Catalog which would have been
        /// added to the player inventory, if the Random Result Table were added via a Bundle or a call to UnlockContainer.
        /// </summary>
        injectionBinder.Bind<EvaluateRandomResultTableSignal>();
        injectionBinder.Bind<EvaluateRandomResultTableResponseSignal>();
        commandBinder.Bind<EvaluateRandomResultTableSignal>().To<EvaluateRandomResultTableCommand>();
        commandBinder.Bind<EvaluateRandomResultTableResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the specified character's current inventory of virtual goods
        /// </summary>
        injectionBinder.Bind<GetCharacterInventorySignal>();
        injectionBinder.Bind<GetCharacterInventoryResponseSignal>();
        commandBinder.Bind<GetCharacterInventorySignal>().To<GetCharacterInventoryCommand>();
        commandBinder.Bind<GetCharacterInventoryResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the configuration information for the specified random results tables for the title, including all ItemId
        /// values and weights
        /// </summary>
        injectionBinder.Bind<GetRandomResultTablesSignal>();
        injectionBinder.Bind<GetRandomResultTablesResponseSignal>();
        commandBinder.Bind<GetRandomResultTablesSignal>().To<GetRandomResultTablesCommand>();
        commandBinder.Bind<GetRandomResultTablesResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the specified user's current inventory of virtual goods
        /// </summary>
        injectionBinder.Bind<GetUserInventorySignal>();
        injectionBinder.Bind<GetUserInventoryResponseSignal>();
        commandBinder.Bind<GetUserInventorySignal>().To<GetUserInventoryCommand>();
        commandBinder.Bind<GetUserInventoryResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Adds the specified items to the specified character's inventory
        /// </summary>
        injectionBinder.Bind<GrantItemsToCharacterSignal>();
        injectionBinder.Bind<GrantItemsToCharacterResponseSignal>();
        commandBinder.Bind<GrantItemsToCharacterSignal>().To<GrantItemsToCharacterCommand>();
        commandBinder.Bind<GrantItemsToCharacterResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Adds the specified items to the specified user's inventory
        /// </summary>
        injectionBinder.Bind<GrantItemsToUserSignal>();
        injectionBinder.Bind<GrantItemsToUserResponseSignal>();
        commandBinder.Bind<GrantItemsToUserSignal>().To<GrantItemsToUserCommand>();
        commandBinder.Bind<GrantItemsToUserResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Adds the specified items to the specified user inventories
        /// </summary>
        injectionBinder.Bind<GrantItemsToUsersSignal>();
        injectionBinder.Bind<GrantItemsToUsersResponseSignal>();
        commandBinder.Bind<GrantItemsToUsersSignal>().To<GrantItemsToUsersCommand>();
        commandBinder.Bind<GrantItemsToUsersResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Modifies the number of remaining uses of a player's inventory item
        /// </summary>
        injectionBinder.Bind<ModifyItemUsesSignal>();
        injectionBinder.Bind<ModifyItemUsesResponseSignal>();
        commandBinder.Bind<ModifyItemUsesSignal>().To<ModifyItemUsesCommand>();
        commandBinder.Bind<ModifyItemUsesResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Moves an item from a character's inventory into another of the users's character's inventory.
        /// </summary>
        injectionBinder.Bind<MoveItemToCharacterFromCharacterSignal>();
        injectionBinder.Bind<MoveItemToCharacterFromCharacterResponseSignal>();
        commandBinder.Bind<MoveItemToCharacterFromCharacterSignal>().To<MoveItemToCharacterFromCharacterCommand>();
        commandBinder.Bind<MoveItemToCharacterFromCharacterResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Moves an item from a user's inventory into their character's inventory.
        /// </summary>
        injectionBinder.Bind<MoveItemToCharacterFromUserSignal>();
        injectionBinder.Bind<MoveItemToCharacterFromUserResponseSignal>();
        commandBinder.Bind<MoveItemToCharacterFromUserSignal>().To<MoveItemToCharacterFromUserCommand>();
        commandBinder.Bind<MoveItemToCharacterFromUserResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Moves an item from a character's inventory into the owning user's inventory.
        /// </summary>
        injectionBinder.Bind<MoveItemToUserFromCharacterSignal>();
        injectionBinder.Bind<MoveItemToUserFromCharacterResponseSignal>();
        commandBinder.Bind<MoveItemToUserFromCharacterSignal>().To<MoveItemToUserFromCharacterCommand>();
        commandBinder.Bind<MoveItemToUserFromCharacterResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated  via the
        /// Economy->Catalogs tab in the PlayFab Game Manager.
        /// </summary>
        injectionBinder.Bind<RedeemCouponSignal>();
        injectionBinder.Bind<RedeemCouponResponseSignal>();
        commandBinder.Bind<RedeemCouponSignal>().To<RedeemCouponCommand>();
        commandBinder.Bind<RedeemCouponResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Submit a report about a player (due to bad bahavior, etc.) on behalf of another player, so that customer service
        /// representatives for the title can take action concerning potentially toxic players.
        /// </summary>
        injectionBinder.Bind<ReportPlayerSignal>();
        injectionBinder.Bind<ReportPlayerResponseSignal>();
        commandBinder.Bind<ReportPlayerSignal>().To<ReportPlayerCommand>();
        commandBinder.Bind<ReportPlayerResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Revokes access to an item in a user's inventory
        /// </summary>
        injectionBinder.Bind<RevokeInventoryItemSignal>();
        injectionBinder.Bind<RevokeInventoryItemResponseSignal>();
        commandBinder.Bind<RevokeInventoryItemSignal>().To<RevokeInventoryItemCommand>();
        commandBinder.Bind<RevokeInventoryItemResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Decrements the character's balance of the specified virtual currency by the stated amount. It is possible to make a VC
        /// balance negative with this API.
        /// </summary>
        injectionBinder.Bind<SubtractCharacterVirtualCurrencySignal>();
        injectionBinder.Bind<SubtractCharacterVirtualCurrencyResponseSignal>();
        commandBinder.Bind<SubtractCharacterVirtualCurrencySignal>().To<SubtractCharacterVirtualCurrencyCommand>();
        commandBinder.Bind<SubtractCharacterVirtualCurrencyResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Decrements the user's balance of the specified virtual currency by the stated amount. It is possible to make a VC
        /// balance negative with this API.
        /// </summary>
        injectionBinder.Bind<SubtractUserVirtualCurrencySignal>();
        injectionBinder.Bind<SubtractUserVirtualCurrencyResponseSignal>();
        commandBinder.Bind<SubtractUserVirtualCurrencySignal>().To<SubtractUserVirtualCurrencyCommand>();
        commandBinder.Bind<SubtractUserVirtualCurrencyResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Opens a specific container (ContainerItemInstanceId), with a specific key (KeyItemInstanceId, when required), and
        /// returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses >
        /// 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        injectionBinder.Bind<UnlockContainerInstanceSignal>();
        injectionBinder.Bind<UnlockContainerInstanceResponseSignal>();
        commandBinder.Bind<UnlockContainerInstanceSignal>().To<UnlockContainerInstanceCommand>();
        commandBinder.Bind<UnlockContainerInstanceResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Searches Player or Character inventory for any ItemInstance matching the given CatalogItemId, if necessary unlocks it
        /// using any appropriate key, and returns the contents of the opened container. If the container (and key when relevant)
        /// are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of
        /// ConsumeItem.
        /// </summary>
        injectionBinder.Bind<UnlockContainerItemSignal>();
        injectionBinder.Bind<UnlockContainerItemResponseSignal>();
        commandBinder.Bind<UnlockContainerItemSignal>().To<UnlockContainerItemCommand>();
        commandBinder.Bind<UnlockContainerItemResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the key-value pair data tagged to the specified item, which is read-only from the client.
        /// </summary>
        injectionBinder.Bind<UpdateUserInventoryItemCustomDataSignal>();
        injectionBinder.Bind<UpdateUserInventoryItemCustomDataResponseSignal>();
        commandBinder.Bind<UpdateUserInventoryItemCustomDataSignal>().To<UpdateUserInventoryItemCustomDataCommand>();
        commandBinder.Bind<UpdateUserInventoryItemCustomDataResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region PlayStream
        /// <summary>
        /// Adds a given tag to a player profile. The tag's namespace is automatically generated based on the source of the tag.
        /// </summary>
        injectionBinder.Bind<AddPlayerTagSignal>();
        injectionBinder.Bind<AddPlayerTagResponseSignal>();
        commandBinder.Bind<AddPlayerTagSignal>().To<AddPlayerTagCommand>();
        commandBinder.Bind<AddPlayerTagResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves an array of player segment definitions. Results from this can be used in subsequent API calls such as
        /// GetPlayersInSegment which requires a Segment ID. While segment names can change the ID for that segment will not change.
        /// </summary>
        injectionBinder.Bind<GetAllSegmentsSignal>();
        injectionBinder.Bind<GetAllSegmentsResponseSignal>();
        commandBinder.Bind<GetAllSegmentsSignal>().To<GetAllSegmentsCommand>();
        commandBinder.Bind<GetAllSegmentsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// List all segments that a player currently belongs to at this moment in time.
        /// </summary>
        injectionBinder.Bind<GetPlayerSegmentsSignal>();
        injectionBinder.Bind<GetPlayerSegmentsResponseSignal>();
        commandBinder.Bind<GetPlayerSegmentsSignal>().To<GetPlayerSegmentsCommand>();
        commandBinder.Bind<GetPlayerSegmentsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Allows for paging through all players in a given segment. This API creates a snapshot of all player profiles that match
        /// the segment definition at the time of its creation and lives through the Total Seconds to Live, refreshing its life span
        /// on each subsequent use of the Continuation Token. Profiles that change during the course of paging will not be reflected
        /// in the results. AB Test segments are currently not supported by this operation.
        /// </summary>
        injectionBinder.Bind<GetPlayersInSegmentSignal>();
        injectionBinder.Bind<GetPlayersInSegmentResponseSignal>();
        commandBinder.Bind<GetPlayersInSegmentSignal>().To<GetPlayersInSegmentCommand>();
        commandBinder.Bind<GetPlayersInSegmentResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Get all tags with a given Namespace (optional) from a player profile.
        /// </summary>
        injectionBinder.Bind<GetPlayerTagsSignal>();
        injectionBinder.Bind<GetPlayerTagsResponseSignal>();
        commandBinder.Bind<GetPlayerTagsSignal>().To<GetPlayerTagsCommand>();
        commandBinder.Bind<GetPlayerTagsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Remove a given tag from a player profile. The tag's namespace is automatically generated based on the source of the tag.
        /// </summary>
        injectionBinder.Bind<RemovePlayerTagSignal>();
        injectionBinder.Bind<RemovePlayerTagResponseSignal>();
        commandBinder.Bind<RemovePlayerTagSignal>().To<RemovePlayerTagCommand>();
        commandBinder.Bind<RemovePlayerTagResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Server-Side Cloud Script
        /// <summary>
        /// Executes a CloudScript function, with the 'currentPlayerId' variable set to the specified PlayFabId parameter value.
        /// </summary>
        injectionBinder.Bind<ExecuteCloudScriptSignal>();
        injectionBinder.Bind<ExecuteCloudScriptResponseSignal>();
        commandBinder.Bind<ExecuteCloudScriptSignal>().To<ExecuteCloudScriptCommand>();
        commandBinder.Bind<ExecuteCloudScriptResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Shared Group Data
        /// <summary>
        /// Adds users to the set of those able to update both the shared data, as well as the set of users  in the group. Only
        /// users in the group (and the server) can add new members. Shared Groups are designed for sharing data  between a very
        /// small number of players, please see our guide: https://api.playfab.com/docs/tutorials/landing-players/shared-groups
        /// </summary>
        injectionBinder.Bind<AddSharedGroupMembersSignal>();
        injectionBinder.Bind<AddSharedGroupMembersResponseSignal>();
        commandBinder.Bind<AddSharedGroupMembersSignal>().To<AddSharedGroupMembersCommand>();
        commandBinder.Bind<AddSharedGroupMembersResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Requests the creation of a shared group object, containing key/value pairs which may  be updated by all members of the
        /// group. When created by a server, the group will initially have no members.  Shared Groups are designed for sharing data
        /// between a very small number of players, please see our guide:
        /// https://api.playfab.com/docs/tutorials/landing-players/shared-groups
        /// </summary>
        injectionBinder.Bind<CreateSharedGroupSignal>();
        injectionBinder.Bind<CreateSharedGroupResponseSignal>();
        commandBinder.Bind<CreateSharedGroupSignal>().To<CreateSharedGroupCommand>();
        commandBinder.Bind<CreateSharedGroupResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Deletes a shared group, freeing up the shared group ID to be reused for a new group.  Shared Groups are designed for
        /// sharing data between a very small number of players, please see our guide:
        /// https://api.playfab.com/docs/tutorials/landing-players/shared-groups
        /// </summary>
        injectionBinder.Bind<DeleteSharedGroupSignal>();
        injectionBinder.Bind<DeleteSharedGroupResponseSignal>();
        commandBinder.Bind<DeleteSharedGroupSignal>().To<DeleteSharedGroupCommand>();
        commandBinder.Bind<DeleteSharedGroupResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves data stored in a shared group object, as well as the list of members in the group.  The server can access all
        /// public and private group data. Shared Groups are designed for sharing data between a very  small number of players,
        /// please see our guide: https://api.playfab.com/docs/tutorials/landing-players/shared-groups
        /// </summary>
        injectionBinder.Bind<GetSharedGroupDataSignal>();
        injectionBinder.Bind<GetSharedGroupDataResponseSignal>();
        commandBinder.Bind<GetSharedGroupDataSignal>().To<GetSharedGroupDataCommand>();
        commandBinder.Bind<GetSharedGroupDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the
        /// group can remove members. If as a result of the call, zero users remain with access, the group and its associated data
        /// will be deleted. Shared Groups are designed for sharing data between a very small number of players,  please see our
        /// guide: https://api.playfab.com/docs/tutorials/landing-players/shared-groups
        /// </summary>
        injectionBinder.Bind<RemoveSharedGroupMembersSignal>();
        injectionBinder.Bind<RemoveSharedGroupMembersResponseSignal>();
        commandBinder.Bind<RemoveSharedGroupMembersSignal>().To<RemoveSharedGroupMembersCommand>();
        commandBinder.Bind<RemoveSharedGroupMembersResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated
        /// or added in this call will be readable by users not in the group. By default, data permissions are set to Private.
        /// Regardless of the permission setting, only members of the group (and the server) can update the data.  Shared Groups are
        /// designed for sharing data between a very small number of players, please see our guide:
        /// https://api.playfab.com/docs/tutorials/landing-players/shared-groups
        /// </summary>
        injectionBinder.Bind<UpdateSharedGroupDataSignal>();
        injectionBinder.Bind<UpdateSharedGroupDataResponseSignal>();
        commandBinder.Bind<UpdateSharedGroupDataSignal>().To<UpdateSharedGroupDataCommand>();
        commandBinder.Bind<UpdateSharedGroupDataResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Title-Wide Data Management
        /// <summary>
        /// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        injectionBinder.Bind<GetCatalogItemsSignal>();
        injectionBinder.Bind<GetCatalogItemsResponseSignal>();
        commandBinder.Bind<GetCatalogItemsSignal>().To<GetCatalogItemsCommand>();
        commandBinder.Bind<GetCatalogItemsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        injectionBinder.Bind<GetPublisherDataSignal>();
        injectionBinder.Bind<GetPublisherDataResponseSignal>();
        commandBinder.Bind<GetPublisherDataSignal>().To<GetPublisherDataCommand>();
        commandBinder.Bind<GetPublisherDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the current server time
        /// </summary>
        injectionBinder.Bind<GetTimeSignal>();
        injectionBinder.Bind<GetTimeResponseSignal>();
        commandBinder.Bind<GetTimeSignal>().To<GetTimeCommand>();
        commandBinder.Bind<GetTimeResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the key-value store of custom title settings
        /// </summary>
        injectionBinder.Bind<GetTitleDataSignal>();
        injectionBinder.Bind<GetTitleDataResponseSignal>();
        commandBinder.Bind<GetTitleDataSignal>().To<GetTitleDataCommand>();
        commandBinder.Bind<GetTitleDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the key-value store of custom internal title settings
        /// </summary>
        injectionBinder.Bind<GetTitleInternalDataSignal>();
        injectionBinder.Bind<GetTitleInternalDataResponseSignal>();
        commandBinder.Bind<GetTitleInternalDataSignal>().To<GetTitleInternalDataCommand>();
        commandBinder.Bind<GetTitleInternalDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the title news feed, as configured in the developer portal
        /// </summary>
        injectionBinder.Bind<GetTitleNewsSignal>();
        injectionBinder.Bind<GetTitleNewsResponseSignal>();
        commandBinder.Bind<GetTitleNewsSignal>().To<GetTitleNewsCommand>();
        commandBinder.Bind<GetTitleNewsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the key-value store of custom publisher settings
        /// </summary>
        injectionBinder.Bind<SetPublisherDataSignal>();
        injectionBinder.Bind<SetPublisherDataResponseSignal>();
        commandBinder.Bind<SetPublisherDataSignal>().To<SetPublisherDataCommand>();
        commandBinder.Bind<SetPublisherDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the key-value store of custom title settings
        /// </summary>
        injectionBinder.Bind<SetTitleDataSignal>();
        injectionBinder.Bind<SetTitleDataResponseSignal>();
        commandBinder.Bind<SetTitleDataSignal>().To<SetTitleDataCommand>();
        commandBinder.Bind<SetTitleDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the key-value store of custom title settings
        /// </summary>
        injectionBinder.Bind<SetTitleInternalDataSignal>();
        injectionBinder.Bind<SetTitleInternalDataResponseSignal>();
        commandBinder.Bind<SetTitleInternalDataSignal>().To<SetTitleInternalDataCommand>();
        commandBinder.Bind<SetTitleInternalDataResponseSignal>(); //Create empty overrideable binding.

        #endregion
    }

    public override void PostBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
    }
}
