using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.injector.api;
using strange.extensions.mediation.api;

public class PlayFabContextManager : StrangePackage
{
    public override void MapBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
        // Bind Signals Cross Context

        #region Matchmaking APIs
        injectionBinder.Bind<AuthUserSignal>();
        injectionBinder.Bind<AuthUserResponseSignal>();
        injectionBinder.Bind<PlayerJoinedSignal>();
        injectionBinder.Bind<PlayerJoinedResponseSignal>();
        injectionBinder.Bind<PlayerLeftSignal>();
        injectionBinder.Bind<PlayerLeftResponseSignal>();
        injectionBinder.Bind<StartGameSignal>();
        injectionBinder.Bind<StartGameResponseSignal>();
        injectionBinder.Bind<UserInfoSignal>();
        injectionBinder.Bind<UserInfoResponseSignal>();
        #endregion

        #region Authentication
        injectionBinder.Bind<AuthenticateSessionTicketSignal>();
        injectionBinder.Bind<AuthenticateSessionTicketResponseSignal>();
        #endregion

        #region Account Management
        injectionBinder.Bind<GetPlayFabIDsFromFacebookIDsSignal>();
        injectionBinder.Bind<GetPlayFabIDsFromFacebookIDsResponseSignal>();
        injectionBinder.Bind<GetPlayFabIDsFromSteamIDsSignal>();
        injectionBinder.Bind<GetPlayFabIDsFromSteamIDsResponseSignal>();
        injectionBinder.Bind<GetUserAccountInfoSignal>();
        injectionBinder.Bind<GetUserAccountInfoResponseSignal>();
        injectionBinder.Bind<SendPushNotificationSignal>();
        injectionBinder.Bind<SendPushNotificationResponseSignal>();
        #endregion

        #region Player Data Management
        injectionBinder.Bind<DeleteUsersSignal>();
        injectionBinder.Bind<DeleteUsersResponseSignal>();
        injectionBinder.Bind<GetLeaderboardSignal>();
        injectionBinder.Bind<GetLeaderboardResponseSignal>();
        injectionBinder.Bind<GetLeaderboardAroundUserSignal>();
        injectionBinder.Bind<GetLeaderboardAroundUserResponseSignal>();
        injectionBinder.Bind<GetPlayerCombinedInfoSignal>();
        injectionBinder.Bind<GetPlayerCombinedInfoResponseSignal>();
        injectionBinder.Bind<GetPlayerStatisticsSignal>();
        injectionBinder.Bind<GetPlayerStatisticsResponseSignal>();
        injectionBinder.Bind<GetPlayerStatisticVersionsSignal>();
        injectionBinder.Bind<GetPlayerStatisticVersionsResponseSignal>();
        injectionBinder.Bind<GetUserDataSignal>();
        injectionBinder.Bind<GetUserDataResponseSignal>();
        injectionBinder.Bind<GetUserInternalDataSignal>();
        injectionBinder.Bind<GetUserInternalDataResponseSignal>();
        injectionBinder.Bind<GetUserPublisherDataSignal>();
        injectionBinder.Bind<GetUserPublisherDataResponseSignal>();
        injectionBinder.Bind<GetUserPublisherInternalDataSignal>();
        injectionBinder.Bind<GetUserPublisherInternalDataResponseSignal>();
        injectionBinder.Bind<GetUserPublisherReadOnlyDataSignal>();
        injectionBinder.Bind<GetUserPublisherReadOnlyDataResponseSignal>();
        injectionBinder.Bind<GetUserReadOnlyDataSignal>();
        injectionBinder.Bind<GetUserReadOnlyDataResponseSignal>();
        injectionBinder.Bind<GetUserStatisticsSignal>();
        injectionBinder.Bind<GetUserStatisticsResponseSignal>();
        injectionBinder.Bind<UpdatePlayerStatisticsSignal>();
        injectionBinder.Bind<UpdatePlayerStatisticsResponseSignal>();
        injectionBinder.Bind<UpdateUserDataSignal>();
        injectionBinder.Bind<UpdateUserDataResponseSignal>();
        injectionBinder.Bind<UpdateUserInternalDataSignal>();
        injectionBinder.Bind<UpdateUserInternalDataResponseSignal>();
        injectionBinder.Bind<UpdateUserPublisherDataSignal>();
        injectionBinder.Bind<UpdateUserPublisherDataResponseSignal>();
        injectionBinder.Bind<UpdateUserPublisherInternalDataSignal>();
        injectionBinder.Bind<UpdateUserPublisherInternalDataResponseSignal>();
        injectionBinder.Bind<UpdateUserPublisherReadOnlyDataSignal>();
        injectionBinder.Bind<UpdateUserPublisherReadOnlyDataResponseSignal>();
        injectionBinder.Bind<UpdateUserReadOnlyDataSignal>();
        injectionBinder.Bind<UpdateUserReadOnlyDataResponseSignal>();
        injectionBinder.Bind<UpdateUserStatisticsSignal>();
        injectionBinder.Bind<UpdateUserStatisticsResponseSignal>();
        #endregion

        #region Title-Wide Data Management
        injectionBinder.Bind<GetCatalogItemsSignal>();
        injectionBinder.Bind<GetCatalogItemsResponseSignal>();
        injectionBinder.Bind<GetPublisherDataSignal>();
        injectionBinder.Bind<GetPublisherDataResponseSignal>();
        injectionBinder.Bind<GetTitleDataSignal>();
        injectionBinder.Bind<GetTitleDataResponseSignal>();
        injectionBinder.Bind<GetTitleInternalDataSignal>();
        injectionBinder.Bind<GetTitleInternalDataResponseSignal>();
        injectionBinder.Bind<GetTitleNewsSignal>();
        injectionBinder.Bind<GetTitleNewsResponseSignal>();
        injectionBinder.Bind<SetPublisherDataSignal>();
        injectionBinder.Bind<SetPublisherDataResponseSignal>();
        injectionBinder.Bind<SetTitleDataSignal>();
        injectionBinder.Bind<SetTitleDataResponseSignal>();
        injectionBinder.Bind<SetTitleInternalDataSignal>();
        injectionBinder.Bind<SetTitleInternalDataResponseSignal>();
        #endregion

        #region Player Item Management
        injectionBinder.Bind<AddCharacterVirtualCurrencySignal>();
        injectionBinder.Bind<AddCharacterVirtualCurrencyResponseSignal>();
        injectionBinder.Bind<AddUserVirtualCurrencySignal>();
        injectionBinder.Bind<AddUserVirtualCurrencyResponseSignal>();
        injectionBinder.Bind<ConsumeItemSignal>();
        injectionBinder.Bind<ConsumeItemResponseSignal>();
        injectionBinder.Bind<EvaluateRandomResultTableSignal>();
        injectionBinder.Bind<EvaluateRandomResultTableResponseSignal>();
        injectionBinder.Bind<GetCharacterInventorySignal>();
        injectionBinder.Bind<GetCharacterInventoryResponseSignal>();
        injectionBinder.Bind<GetUserInventorySignal>();
        injectionBinder.Bind<GetUserInventoryResponseSignal>();
        injectionBinder.Bind<GrantItemsToCharacterSignal>();
        injectionBinder.Bind<GrantItemsToCharacterResponseSignal>();
        injectionBinder.Bind<GrantItemsToUserSignal>();
        injectionBinder.Bind<GrantItemsToUserResponseSignal>();
        injectionBinder.Bind<GrantItemsToUsersSignal>();
        injectionBinder.Bind<GrantItemsToUsersResponseSignal>();
        injectionBinder.Bind<ModifyItemUsesSignal>();
        injectionBinder.Bind<ModifyItemUsesResponseSignal>();
        injectionBinder.Bind<MoveItemToCharacterFromCharacterSignal>();
        injectionBinder.Bind<MoveItemToCharacterFromCharacterResponseSignal>();
        injectionBinder.Bind<MoveItemToCharacterFromUserSignal>();
        injectionBinder.Bind<MoveItemToCharacterFromUserResponseSignal>();
        injectionBinder.Bind<MoveItemToUserFromCharacterSignal>();
        injectionBinder.Bind<MoveItemToUserFromCharacterResponseSignal>();
        injectionBinder.Bind<RedeemCouponSignal>();
        injectionBinder.Bind<RedeemCouponResponseSignal>();
        injectionBinder.Bind<ReportPlayerSignal>();
        injectionBinder.Bind<ReportPlayerResponseSignal>();
        injectionBinder.Bind<RevokeInventoryItemSignal>();
        injectionBinder.Bind<RevokeInventoryItemResponseSignal>();
        injectionBinder.Bind<SubtractCharacterVirtualCurrencySignal>();
        injectionBinder.Bind<SubtractCharacterVirtualCurrencyResponseSignal>();
        injectionBinder.Bind<SubtractUserVirtualCurrencySignal>();
        injectionBinder.Bind<SubtractUserVirtualCurrencyResponseSignal>();
        injectionBinder.Bind<UnlockContainerInstanceSignal>();
        injectionBinder.Bind<UnlockContainerInstanceResponseSignal>();
        injectionBinder.Bind<UnlockContainerItemSignal>();
        injectionBinder.Bind<UnlockContainerItemResponseSignal>();
        injectionBinder.Bind<UpdateUserInventoryItemCustomDataSignal>();
        injectionBinder.Bind<UpdateUserInventoryItemCustomDataResponseSignal>();
        #endregion

        #region Friend List Management
        #endregion

        #region Matchmaking APIs
        injectionBinder.Bind<NotifyMatchmakerPlayerLeftSignal>();
        injectionBinder.Bind<NotifyMatchmakerPlayerLeftResponseSignal>();
        injectionBinder.Bind<RedeemMatchmakerTicketSignal>();
        injectionBinder.Bind<RedeemMatchmakerTicketResponseSignal>();
        injectionBinder.Bind<SetGameServerInstanceDataSignal>();
        injectionBinder.Bind<SetGameServerInstanceDataResponseSignal>();
        injectionBinder.Bind<SetGameServerInstanceStateSignal>();
        injectionBinder.Bind<SetGameServerInstanceStateResponseSignal>();
        #endregion

        #region Steam-Specific APIs
        injectionBinder.Bind<AwardSteamAchievementSignal>();
        injectionBinder.Bind<AwardSteamAchievementResponseSignal>();
        #endregion

        #region Analytics
        injectionBinder.Bind<LogEventSignal>();
        injectionBinder.Bind<LogEventResponseSignal>();
        injectionBinder.Bind<WriteCharacterEventSignal>();
        injectionBinder.Bind<WriteCharacterEventResponseSignal>();
        injectionBinder.Bind<WritePlayerEventSignal>();
        injectionBinder.Bind<WritePlayerEventResponseSignal>();
        injectionBinder.Bind<WriteTitleEventSignal>();
        injectionBinder.Bind<WriteTitleEventResponseSignal>();
        #endregion

        #region Shared Group Data
        injectionBinder.Bind<AddSharedGroupMembersSignal>();
        injectionBinder.Bind<AddSharedGroupMembersResponseSignal>();
        injectionBinder.Bind<CreateSharedGroupSignal>();
        injectionBinder.Bind<CreateSharedGroupResponseSignal>();
        injectionBinder.Bind<DeleteSharedGroupSignal>();
        injectionBinder.Bind<DeleteSharedGroupResponseSignal>();
        injectionBinder.Bind<GetSharedGroupDataSignal>();
        injectionBinder.Bind<GetSharedGroupDataResponseSignal>();
        injectionBinder.Bind<RemoveSharedGroupMembersSignal>();
        injectionBinder.Bind<RemoveSharedGroupMembersResponseSignal>();
        injectionBinder.Bind<UpdateSharedGroupDataSignal>();
        injectionBinder.Bind<UpdateSharedGroupDataResponseSignal>();
        #endregion

        #region Server-Side Cloud Script
        injectionBinder.Bind<ExecuteCloudScriptSignal>();
        injectionBinder.Bind<ExecuteCloudScriptResponseSignal>();
        #endregion

        #region Content
        injectionBinder.Bind<GetContentDownloadUrlSignal>();
        injectionBinder.Bind<GetContentDownloadUrlResponseSignal>();
        #endregion

        #region Characters
        injectionBinder.Bind<DeleteCharacterFromUserSignal>();
        injectionBinder.Bind<DeleteCharacterFromUserResponseSignal>();
        injectionBinder.Bind<GetAllUsersCharactersSignal>();
        injectionBinder.Bind<GetAllUsersCharactersResponseSignal>();
        injectionBinder.Bind<GetCharacterLeaderboardSignal>();
        injectionBinder.Bind<GetCharacterLeaderboardResponseSignal>();
        injectionBinder.Bind<GetCharacterStatisticsSignal>();
        injectionBinder.Bind<GetCharacterStatisticsResponseSignal>();
        injectionBinder.Bind<GetLeaderboardAroundCharacterSignal>();
        injectionBinder.Bind<GetLeaderboardAroundCharacterResponseSignal>();
        injectionBinder.Bind<GetLeaderboardForUserCharactersSignal>();
        injectionBinder.Bind<GetLeaderboardForUserCharactersResponseSignal>();
        injectionBinder.Bind<GrantCharacterToUserSignal>();
        injectionBinder.Bind<GrantCharacterToUserResponseSignal>();
        injectionBinder.Bind<UpdateCharacterStatisticsSignal>();
        injectionBinder.Bind<UpdateCharacterStatisticsResponseSignal>();
        #endregion

        #region Character Data
        injectionBinder.Bind<GetCharacterDataSignal>();
        injectionBinder.Bind<GetCharacterDataResponseSignal>();
        injectionBinder.Bind<GetCharacterInternalDataSignal>();
        injectionBinder.Bind<GetCharacterInternalDataResponseSignal>();
        injectionBinder.Bind<GetCharacterReadOnlyDataSignal>();
        injectionBinder.Bind<GetCharacterReadOnlyDataResponseSignal>();
        injectionBinder.Bind<UpdateCharacterDataSignal>();
        injectionBinder.Bind<UpdateCharacterDataResponseSignal>();
        injectionBinder.Bind<UpdateCharacterInternalDataSignal>();
        injectionBinder.Bind<UpdateCharacterInternalDataResponseSignal>();
        injectionBinder.Bind<UpdateCharacterReadOnlyDataSignal>();
        injectionBinder.Bind<UpdateCharacterReadOnlyDataResponseSignal>();
        #endregion

        #region Guilds
        #endregion

        #region PlayStream
        injectionBinder.Bind<GetAllSegmentsSignal>();
        injectionBinder.Bind<GetAllSegmentsResponseSignal>();
        injectionBinder.Bind<GetPlayerSegmentsSignal>();
        injectionBinder.Bind<GetPlayerSegmentsResponseSignal>();
        injectionBinder.Bind<GetPlayersInSegmentSignal>();
        injectionBinder.Bind<GetPlayersInSegmentResponseSignal>();
        #endregion

        // Bind Commands

        #region Matchmaking APIs
        /// <summary>
        /// Validates a user with the PlayFab service
        /// </summary>
        commandBinder.Bind<AuthUserSignal>().To<AuthUserCommand>();
        commandBinder.Bind<AuthUserResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Informs the PlayFab game server hosting service that the indicated user has joined the Game Server Instance specified
        /// </summary>
        commandBinder.Bind<PlayerJoinedSignal>().To<PlayerJoinedCommand>();
        commandBinder.Bind<PlayerJoinedResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Informs the PlayFab game server hosting service that the indicated user has left the Game Server Instance specified
        /// </summary>
        commandBinder.Bind<PlayerLeftSignal>().To<PlayerLeftCommand>();
        commandBinder.Bind<PlayerLeftResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Instructs the PlayFab game server hosting service to instantiate a new Game Server Instance
        /// </summary>
        commandBinder.Bind<StartGameSignal>().To<StartGameCommand>();
        commandBinder.Bind<StartGameResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the relevant details for a specified user, which the external match-making service can then use to compute effective matches
        /// </summary>
        commandBinder.Bind<UserInfoSignal>().To<UserInfoCommand>();
        commandBinder.Bind<UserInfoResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Authentication
        /// <summary>
        /// Validated a client's session ticket, and if successful, returns details for that user
        /// </summary>
        commandBinder.Bind<AuthenticateSessionTicketSignal>().To<AuthenticateSessionTicketCommand>();
        commandBinder.Bind<AuthenticateSessionTicketResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Account Management
        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
        /// </summary>
        commandBinder.Bind<GetPlayFabIDsFromFacebookIDsSignal>().To<GetPlayFabIDsFromFacebookIDsCommand>();
        commandBinder.Bind<GetPlayFabIDsFromFacebookIDsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers  are the profile IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
        /// </summary>
        commandBinder.Bind<GetPlayFabIDsFromSteamIDsSignal>().To<GetPlayFabIDsFromSteamIDsCommand>();
        commandBinder.Bind<GetPlayFabIDsFromSteamIDsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the relevant details for a specified user
        /// </summary>
        commandBinder.Bind<GetUserAccountInfoSignal>().To<GetUserAccountInfoCommand>();
        commandBinder.Bind<GetUserAccountInfoResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured for Push Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
        /// </summary>
        commandBinder.Bind<SendPushNotificationSignal>().To<SendPushNotificationCommand>();
        commandBinder.Bind<SendPushNotificationResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Player Data Management
        /// <summary>
        /// Deletes the users for the provided game. Deletes custom data, all account linkages, and statistics.
        /// </summary>
        commandBinder.Bind<DeleteUsersSignal>().To<DeleteUsersCommand>();
        commandBinder.Bind<DeleteUsersResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        commandBinder.Bind<GetLeaderboardSignal>().To<GetLeaderboardCommand>();
        commandBinder.Bind<GetLeaderboardResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
        /// </summary>
        commandBinder.Bind<GetLeaderboardAroundUserSignal>().To<GetLeaderboardAroundUserCommand>();
        commandBinder.Bind<GetLeaderboardAroundUserResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Returns whatever info is requested in the response for the user. Note that PII (like email address, facebook id)             may be returned. All parameters default to false.
        /// </summary>
        commandBinder.Bind<GetPlayerCombinedInfoSignal>().To<GetPlayerCombinedInfoCommand>();
        commandBinder.Bind<GetPlayerCombinedInfoResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the current version and values for the indicated statistics, for the local player.
        /// </summary>
        commandBinder.Bind<GetPlayerStatisticsSignal>().To<GetPlayerStatisticsCommand>();
        commandBinder.Bind<GetPlayerStatisticsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the information on the available versions of the specified statistic.
        /// </summary>
        commandBinder.Bind<GetPlayerStatisticVersionsSignal>().To<GetPlayerStatisticVersionsCommand>();
        commandBinder.Bind<GetPlayerStatisticVersionsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        commandBinder.Bind<GetUserDataSignal>().To<GetUserDataCommand>();
        commandBinder.Bind<GetUserDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        commandBinder.Bind<GetUserInternalDataSignal>().To<GetUserInternalDataCommand>();
        commandBinder.Bind<GetUserInternalDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        commandBinder.Bind<GetUserPublisherDataSignal>().To<GetUserPublisherDataCommand>();
        commandBinder.Bind<GetUserPublisherDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        commandBinder.Bind<GetUserPublisherInternalDataSignal>().To<GetUserPublisherInternalDataCommand>();
        commandBinder.Bind<GetUserPublisherInternalDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        commandBinder.Bind<GetUserPublisherReadOnlyDataSignal>().To<GetUserPublisherReadOnlyDataCommand>();
        commandBinder.Bind<GetUserPublisherReadOnlyDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        commandBinder.Bind<GetUserReadOnlyDataSignal>().To<GetUserReadOnlyDataCommand>();
        commandBinder.Bind<GetUserReadOnlyDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the details of all title-specific statistics for the user
        /// </summary>
        commandBinder.Bind<GetUserStatisticsSignal>().To<GetUserStatisticsCommand>();
        commandBinder.Bind<GetUserStatisticsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the user
        /// </summary>
        commandBinder.Bind<UpdatePlayerStatisticsSignal>().To<UpdatePlayerStatisticsCommand>();
        commandBinder.Bind<UpdatePlayerStatisticsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        commandBinder.Bind<UpdateUserDataSignal>().To<UpdateUserDataCommand>();
        commandBinder.Bind<UpdateUserDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        commandBinder.Bind<UpdateUserInternalDataSignal>().To<UpdateUserInternalDataCommand>();
        commandBinder.Bind<UpdateUserInternalDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        commandBinder.Bind<UpdateUserPublisherDataSignal>().To<UpdateUserPublisherDataCommand>();
        commandBinder.Bind<UpdateUserPublisherDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        commandBinder.Bind<UpdateUserPublisherInternalDataSignal>().To<UpdateUserPublisherInternalDataCommand>();
        commandBinder.Bind<UpdateUserPublisherInternalDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        commandBinder.Bind<UpdateUserPublisherReadOnlyDataSignal>().To<UpdateUserPublisherReadOnlyDataCommand>();
        commandBinder.Bind<UpdateUserPublisherReadOnlyDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the title-specific custom data for the user which can only be read by the client
        /// </summary>
        commandBinder.Bind<UpdateUserReadOnlyDataSignal>().To<UpdateUserReadOnlyDataCommand>();
        commandBinder.Bind<UpdateUserReadOnlyDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the user. By default, clients are not permitted to update statistics. Developers may override this setting in the Game Manager > Settings > API Features.
        /// </summary>
        commandBinder.Bind<UpdateUserStatisticsSignal>().To<UpdateUserStatisticsCommand>();
        commandBinder.Bind<UpdateUserStatisticsResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Title-Wide Data Management
        /// <summary>
        /// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        commandBinder.Bind<GetCatalogItemsSignal>().To<GetCatalogItemsCommand>();
        commandBinder.Bind<GetCatalogItemsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        commandBinder.Bind<GetPublisherDataSignal>().To<GetPublisherDataCommand>();
        commandBinder.Bind<GetPublisherDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the key-value store of custom title settings
        /// </summary>
        commandBinder.Bind<GetTitleDataSignal>().To<GetTitleDataCommand>();
        commandBinder.Bind<GetTitleDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the key-value store of custom internal title settings
        /// </summary>
        commandBinder.Bind<GetTitleInternalDataSignal>().To<GetTitleInternalDataCommand>();
        commandBinder.Bind<GetTitleInternalDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the title news feed, as configured in the developer portal
        /// </summary>
        commandBinder.Bind<GetTitleNewsSignal>().To<GetTitleNewsCommand>();
        commandBinder.Bind<GetTitleNewsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the key-value store of custom publisher settings
        /// </summary>
        commandBinder.Bind<SetPublisherDataSignal>().To<SetPublisherDataCommand>();
        commandBinder.Bind<SetPublisherDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the key-value store of custom title settings
        /// </summary>
        commandBinder.Bind<SetTitleDataSignal>().To<SetTitleDataCommand>();
        commandBinder.Bind<SetTitleDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the key-value store of custom title settings
        /// </summary>
        commandBinder.Bind<SetTitleInternalDataSignal>().To<SetTitleInternalDataCommand>();
        commandBinder.Bind<SetTitleInternalDataResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Player Item Management
        /// <summary>
        /// Increments  the character's balance of the specified virtual currency by the stated amount
        /// </summary>
        commandBinder.Bind<AddCharacterVirtualCurrencySignal>().To<AddCharacterVirtualCurrencyCommand>();
        commandBinder.Bind<AddCharacterVirtualCurrencyResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Increments  the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        commandBinder.Bind<AddUserVirtualCurrencySignal>().To<AddUserVirtualCurrencyCommand>();
        commandBinder.Bind<AddUserVirtualCurrencyResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's inventory.
        /// </summary>
        commandBinder.Bind<ConsumeItemSignal>().To<ConsumeItemCommand>();
        commandBinder.Bind<ConsumeItemResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Returns the result of an evaluation of a Random Result Table - the ItemId from the game Catalog which would have been added to the player inventory, if the Random Result Table were added via a Bundle or a call to UnlockContainer.
        /// </summary>
        commandBinder.Bind<EvaluateRandomResultTableSignal>().To<EvaluateRandomResultTableCommand>();
        commandBinder.Bind<EvaluateRandomResultTableResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the specified character's current inventory of virtual goods
        /// </summary>
        commandBinder.Bind<GetCharacterInventorySignal>().To<GetCharacterInventoryCommand>();
        commandBinder.Bind<GetCharacterInventoryResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the specified user's current inventory of virtual goods
        /// </summary>
        commandBinder.Bind<GetUserInventorySignal>().To<GetUserInventoryCommand>();
        commandBinder.Bind<GetUserInventoryResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Adds the specified items to the specified character's inventory
        /// </summary>
        commandBinder.Bind<GrantItemsToCharacterSignal>().To<GrantItemsToCharacterCommand>();
        commandBinder.Bind<GrantItemsToCharacterResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Adds the specified items to the specified user's inventory
        /// </summary>
        commandBinder.Bind<GrantItemsToUserSignal>().To<GrantItemsToUserCommand>();
        commandBinder.Bind<GrantItemsToUserResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Adds the specified items to the specified user inventories
        /// </summary>
        commandBinder.Bind<GrantItemsToUsersSignal>().To<GrantItemsToUsersCommand>();
        commandBinder.Bind<GrantItemsToUsersResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Modifies the number of remaining uses of a player's inventory item
        /// </summary>
        commandBinder.Bind<ModifyItemUsesSignal>().To<ModifyItemUsesCommand>();
        commandBinder.Bind<ModifyItemUsesResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Moves an item from a character's inventory into another of the users's character's inventory.
        /// </summary>
        commandBinder.Bind<MoveItemToCharacterFromCharacterSignal>().To<MoveItemToCharacterFromCharacterCommand>();
        commandBinder.Bind<MoveItemToCharacterFromCharacterResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Moves an item from a user's inventory into their character's inventory.
        /// </summary>
        commandBinder.Bind<MoveItemToCharacterFromUserSignal>().To<MoveItemToCharacterFromUserCommand>();
        commandBinder.Bind<MoveItemToCharacterFromUserResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Moves an item from a character's inventory into the owning user's inventory.
        /// </summary>
        commandBinder.Bind<MoveItemToUserFromCharacterSignal>().To<MoveItemToUserFromCharacterCommand>();
        commandBinder.Bind<MoveItemToUserFromCharacterResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated  via the Promotions->Coupons tab in the PlayFab Game Manager. See this post for more information on coupons:  https://playfab.com/blog/2015/06/18/using-stores-and-coupons-game-manager
        /// </summary>
        commandBinder.Bind<RedeemCouponSignal>().To<RedeemCouponCommand>();
        commandBinder.Bind<RedeemCouponResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Submit a report about a player (due to bad bahavior, etc.) on behalf of another player, so that customer service representatives for the title can take action concerning potentially toxic players.
        /// </summary>
        commandBinder.Bind<ReportPlayerSignal>().To<ReportPlayerCommand>();
        commandBinder.Bind<ReportPlayerResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Revokes access to an item in a user's inventory
        /// </summary>
        commandBinder.Bind<RevokeInventoryItemSignal>().To<RevokeInventoryItemCommand>();
        commandBinder.Bind<RevokeInventoryItemResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Decrements the character's balance of the specified virtual currency by the stated amount
        /// </summary>
        commandBinder.Bind<SubtractCharacterVirtualCurrencySignal>().To<SubtractCharacterVirtualCurrencyCommand>();
        commandBinder.Bind<SubtractCharacterVirtualCurrencyResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Decrements the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        commandBinder.Bind<SubtractUserVirtualCurrencySignal>().To<SubtractUserVirtualCurrencyCommand>();
        commandBinder.Bind<SubtractUserVirtualCurrencyResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Opens a specific container (ContainerItemInstanceId), with a specific key (KeyItemInstanceId, when required), and returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        commandBinder.Bind<UnlockContainerInstanceSignal>().To<UnlockContainerInstanceCommand>();
        commandBinder.Bind<UnlockContainerInstanceResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Searches Player or Character inventory for any ItemInstance matching the given CatalogItemId, if necessary unlocks it using any appropriate key, and returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        commandBinder.Bind<UnlockContainerItemSignal>().To<UnlockContainerItemCommand>();
        commandBinder.Bind<UnlockContainerItemResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the key-value pair data tagged to the specified item, which is read-only from the client.
        /// </summary>
        commandBinder.Bind<UpdateUserInventoryItemCustomDataSignal>().To<UpdateUserInventoryItemCustomDataCommand>();
        commandBinder.Bind<UpdateUserInventoryItemCustomDataResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Friend List Management
        #endregion

        #region Matchmaking APIs
        /// <summary>
        /// Informs the PlayFab match-making service that the user specified has left the Game Server Instance
        /// </summary>
        commandBinder.Bind<NotifyMatchmakerPlayerLeftSignal>().To<NotifyMatchmakerPlayerLeftCommand>();
        commandBinder.Bind<NotifyMatchmakerPlayerLeftResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Validates a Game Server session ticket and returns details about the user
        /// </summary>
        commandBinder.Bind<RedeemMatchmakerTicketSignal>().To<RedeemMatchmakerTicketCommand>();
        commandBinder.Bind<RedeemMatchmakerTicketResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Sets the custom data of the indicated Game Server Instance
        /// </summary>
        commandBinder.Bind<SetGameServerInstanceDataSignal>().To<SetGameServerInstanceDataCommand>();
        commandBinder.Bind<SetGameServerInstanceDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Set the state of the indicated Game Server Instance.
        /// </summary>
        commandBinder.Bind<SetGameServerInstanceStateSignal>().To<SetGameServerInstanceStateCommand>();
        commandBinder.Bind<SetGameServerInstanceStateResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Steam-Specific APIs
        /// <summary>
        /// Awards the specified users the specified Steam achievements
        /// </summary>
        commandBinder.Bind<AwardSteamAchievementSignal>().To<AwardSteamAchievementCommand>();
        commandBinder.Bind<AwardSteamAchievementResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Analytics
        /// <summary>
        /// Logs a custom analytics event
        /// </summary>
        commandBinder.Bind<LogEventSignal>().To<LogEventCommand>();
        commandBinder.Bind<LogEventResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Writes a character-based event into PlayStream.
        /// </summary>
        commandBinder.Bind<WriteCharacterEventSignal>().To<WriteCharacterEventCommand>();
        commandBinder.Bind<WriteCharacterEventResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Writes a player-based event into PlayStream.
        /// </summary>
        commandBinder.Bind<WritePlayerEventSignal>().To<WritePlayerEventCommand>();
        commandBinder.Bind<WritePlayerEventResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Writes a title-based event into PlayStream.
        /// </summary>
        commandBinder.Bind<WriteTitleEventSignal>().To<WriteTitleEventCommand>();
        commandBinder.Bind<WriteTitleEventResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Shared Group Data
        /// <summary>
        /// Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users in the group (and the server) can add new members.
        /// </summary>
        commandBinder.Bind<AddSharedGroupMembersSignal>().To<AddSharedGroupMembersCommand>();
        commandBinder.Bind<AddSharedGroupMembersResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the group. When created by a server, the group will initially have no members.
        /// </summary>
        commandBinder.Bind<CreateSharedGroupSignal>().To<CreateSharedGroupCommand>();
        commandBinder.Bind<CreateSharedGroupResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Deletes a shared group, freeing up the shared group ID to be reused for a new group
        /// </summary>
        commandBinder.Bind<DeleteSharedGroupSignal>().To<DeleteSharedGroupCommand>();
        commandBinder.Bind<DeleteSharedGroupResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves data stored in a shared group object, as well as the list of members in the group. The server can access all public and private group data.
        /// </summary>
        commandBinder.Bind<GetSharedGroupDataSignal>().To<GetSharedGroupDataCommand>();
        commandBinder.Bind<GetSharedGroupDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the group can remove members. If as a result of the call, zero users remain with access, the group and its associated data will be deleted.
        /// </summary>
        commandBinder.Bind<RemoveSharedGroupMembersSignal>().To<RemoveSharedGroupMembersCommand>();
        commandBinder.Bind<RemoveSharedGroupMembersResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated or added in this call will be readable by users not in the group. By default, data permissions are set to Private. Regardless of the permission setting, only members of the group (and the server) can update the data.
        /// </summary>
        commandBinder.Bind<UpdateSharedGroupDataSignal>().To<UpdateSharedGroupDataCommand>();
        commandBinder.Bind<UpdateSharedGroupDataResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Server-Side Cloud Script
        /// <summary>
        /// Executes a CloudScript function, with the 'currentPlayerId' variable set to the specified PlayFabId parameter value.
        /// </summary>
        commandBinder.Bind<ExecuteCloudScriptSignal>().To<ExecuteCloudScriptCommand>();
        commandBinder.Bind<ExecuteCloudScriptResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Content
        /// <summary>
        /// This API retrieves a pre-signed URL for accessing a content file for the title. A subsequent  HTTP GET to the returned URL will attempt to download the content. A HEAD query to the returned URL will attempt to  retrieve the metadata of the content. Note that a successful result does not guarantee the existence of this content -  if it has not been uploaded, the query to retrieve the data will fail. See this post for more information:  https://community.playfab.com/hc/en-us/community/posts/205469488-How-to-upload-files-to-PlayFab-s-Content-Service
        /// </summary>
        commandBinder.Bind<GetContentDownloadUrlSignal>().To<GetContentDownloadUrlCommand>();
        commandBinder.Bind<GetContentDownloadUrlResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Characters
        /// <summary>
        /// Deletes the specific character ID from the specified user.
        /// </summary>
        commandBinder.Bind<DeleteCharacterFromUserSignal>().To<DeleteCharacterFromUserCommand>();
        commandBinder.Bind<DeleteCharacterFromUserResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Lists all of the characters that belong to a specific user. CharacterIds are not globally unique; characterId must be evaluated with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        commandBinder.Bind<GetAllUsersCharactersSignal>().To<GetAllUsersCharactersCommand>();
        commandBinder.Bind<GetAllUsersCharactersResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        commandBinder.Bind<GetCharacterLeaderboardSignal>().To<GetCharacterLeaderboardCommand>();
        commandBinder.Bind<GetCharacterLeaderboardResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the details of all title-specific statistics for the specific character
        /// </summary>
        commandBinder.Bind<GetCharacterStatisticsSignal>().To<GetCharacterStatisticsCommand>();
        commandBinder.Bind<GetCharacterStatisticsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, centered on the requested user
        /// </summary>
        commandBinder.Bind<GetLeaderboardAroundCharacterSignal>().To<GetLeaderboardAroundCharacterCommand>();
        commandBinder.Bind<GetLeaderboardAroundCharacterResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves a list of all of the user's characters for the given statistic.
        /// </summary>
        commandBinder.Bind<GetLeaderboardForUserCharactersSignal>().To<GetLeaderboardForUserCharactersCommand>();
        commandBinder.Bind<GetLeaderboardForUserCharactersResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Grants the specified character type to the user. CharacterIds are not globally unique; characterId must be evaluated with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        commandBinder.Bind<GrantCharacterToUserSignal>().To<GrantCharacterToUserCommand>();
        commandBinder.Bind<GrantCharacterToUserResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the specific character
        /// </summary>
        commandBinder.Bind<UpdateCharacterStatisticsSignal>().To<UpdateCharacterStatisticsCommand>();
        commandBinder.Bind<UpdateCharacterStatisticsResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Character Data
        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        commandBinder.Bind<GetCharacterDataSignal>().To<GetCharacterDataCommand>();
        commandBinder.Bind<GetCharacterDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the title-specific custom data for the user's character which cannot be accessed by the client
        /// </summary>
        commandBinder.Bind<GetCharacterInternalDataSignal>().To<GetCharacterInternalDataCommand>();
        commandBinder.Bind<GetCharacterInternalDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Retrieves the title-specific custom data for the user's character which can only be read by the client
        /// </summary>
        commandBinder.Bind<GetCharacterReadOnlyDataSignal>().To<GetCharacterReadOnlyDataCommand>();
        commandBinder.Bind<GetCharacterReadOnlyDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the title-specific custom data for the user's chjaracter which is readable and writable by the client
        /// </summary>
        commandBinder.Bind<UpdateCharacterDataSignal>().To<UpdateCharacterDataCommand>();
        commandBinder.Bind<UpdateCharacterDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the title-specific custom data for the user's character which cannot  be accessed by the client
        /// </summary>
        commandBinder.Bind<UpdateCharacterInternalDataSignal>().To<UpdateCharacterInternalDataCommand>();
        commandBinder.Bind<UpdateCharacterInternalDataResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Updates the title-specific custom data for the user's character which can only be read by the client
        /// </summary>
        commandBinder.Bind<UpdateCharacterReadOnlyDataSignal>().To<UpdateCharacterReadOnlyDataCommand>();
        commandBinder.Bind<UpdateCharacterReadOnlyDataResponseSignal>(); //Create empty overrideable binding.

        #endregion

        #region Guilds
        #endregion

        #region PlayStream
        /// <summary>
        /// Retrieves an array of player segment definitions. Results from this can be used in subsequent API calls such as GetPlayersInSegment which requires a Segment ID. While segment names can change the ID for that segment will not change.
        /// </summary>
        commandBinder.Bind<GetAllSegmentsSignal>().To<GetAllSegmentsCommand>();
        commandBinder.Bind<GetAllSegmentsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// List all segments that a player currently belongs to at this moment in time.
        /// </summary>
        commandBinder.Bind<GetPlayerSegmentsSignal>().To<GetPlayerSegmentsCommand>();
        commandBinder.Bind<GetPlayerSegmentsResponseSignal>(); //Create empty overrideable binding.

        /// <summary>
        /// Allows for paging through all players in a given segment. This API creates a snapshot of all player profiles that match the segment definition at the time of its creation and lives through the Total Seconds to Live, refreshing its life span on each subsequent use of the Continuation Token. Profiles that change during the course of paging will not be reflected in the results. AB Test segments are currently not supported by this operation.
        /// </summary>
        commandBinder.Bind<GetPlayersInSegmentSignal>().To<GetPlayersInSegmentCommand>();
        commandBinder.Bind<GetPlayersInSegmentResponseSignal>(); //Create empty overrideable binding.

        #endregion
    }

    public override void PostBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
    }
}
