using PlayFab.MatchmakerModels;
using PlayFab.ServerModels;
using strange.extensions.signal.impl;

//Base Signals
#region Base Signals

    
//Matchmaking APIs
#region Matchmaking APIs
    
    ///<summary>
    ///Validates a user with the PlayFab service
    ///</summary>
    public class AuthUserSignal : Signal<AuthUserRequest> { }
    
    ///<summary>
    ///Informs the PlayFab game server hosting service that the indicated user has joined the Game Server Instance specified
    ///</summary>
    public class PlayerJoinedSignal : Signal<PlayerJoinedRequest> { }
    
    ///<summary>
    ///Informs the PlayFab game server hosting service that the indicated user has left the Game Server Instance specified
    ///</summary>
    public class PlayerLeftSignal : Signal<PlayerLeftRequest> { }
    
    ///<summary>
    ///Instructs the PlayFab game server hosting service to instantiate a new Game Server Instance
    ///</summary>
    public class StartGameSignal : Signal<StartGameRequest> { }
    
    ///<summary>
    ///Retrieves the relevant details for a specified user, which the external match-making service can then use to compute effective matches
    ///</summary>
    public class UserInfoSignal : Signal<UserInfoRequest> { }
    
#endregion
    
//Authentication
#region Authentication
    
    ///<summary>
    ///Validated a client's session ticket, and if successful, returns details for that user
    ///</summary>
    public class AuthenticateSessionTicketSignal : Signal<AuthenticateSessionTicketRequest> { }
    
#endregion
    
//Account Management
#region Account Management
    
    ///<summary>
    ///Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
    ///</summary>
    public class GetPlayFabIDsFromFacebookIDsSignal : Signal<GetPlayFabIDsFromFacebookIDsRequest> { }
    
    ///<summary>
    ///Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers  are the profile IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
    ///</summary>
    public class GetPlayFabIDsFromSteamIDsSignal : Signal<GetPlayFabIDsFromSteamIDsRequest> { }
    
    ///<summary>
    ///Retrieves the relevant details for a specified user
    ///</summary>
    public class GetUserAccountInfoSignal : Signal<GetUserAccountInfoRequest> { }
    
    ///<summary>
    ///Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured for Push Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
    ///</summary>
    public class SendPushNotificationSignal : Signal<SendPushNotificationRequest> { }
    
#endregion
    
//Player Data Management
#region Player Data Management
    
    ///<summary>
    ///Deletes the users for the provided game. Deletes custom data, all account linkages, and statistics.
    ///</summary>
    public class DeleteUsersSignal : Signal<DeleteUsersRequest> { }
    
    ///<summary>
    ///Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
    ///</summary>
    public class GetLeaderboardSignal : Signal<GetLeaderboardRequest> { }
    
    ///<summary>
    ///Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
    ///</summary>
    public class GetLeaderboardAroundUserSignal : Signal<GetLeaderboardAroundUserRequest> { }
    
    ///<summary>
    ///Retrieves the current version and values for the indicated statistics, for the local player.
    ///</summary>
    public class GetPlayerStatisticsSignal : Signal<GetPlayerStatisticsRequest> { }
    
    ///<summary>
    ///Retrieves the information on the available versions of the specified statistic.
    ///</summary>
    public class GetPlayerStatisticVersionsSignal : Signal<GetPlayerStatisticVersionsRequest> { }
    
    ///<summary>
    ///Retrieves the title-specific custom data for the user which is readable and writable by the client
    ///</summary>
    public class GetUserDataSignal : Signal<GetUserDataRequest> { }
    
    ///<summary>
    ///Retrieves the title-specific custom data for the user which cannot be accessed by the client
    ///</summary>
    public class GetUserInternalDataSignal : Signal<GetUserDataRequest> { }
    
    ///<summary>
    ///Retrieves the publisher-specific custom data for the user which is readable and writable by the client
    ///</summary>
    public class GetUserPublisherDataSignal : Signal<GetUserDataRequest> { }
    
    ///<summary>
    ///Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
    ///</summary>
    public class GetUserPublisherInternalDataSignal : Signal<GetUserDataRequest> { }
    
    ///<summary>
    ///Retrieves the publisher-specific custom data for the user which can only be read by the client
    ///</summary>
    public class GetUserPublisherReadOnlyDataSignal : Signal<GetUserDataRequest> { }
    
    ///<summary>
    ///Retrieves the title-specific custom data for the user which can only be read by the client
    ///</summary>
    public class GetUserReadOnlyDataSignal : Signal<GetUserDataRequest> { }
    
    ///<summary>
    ///Retrieves the details of all title-specific statistics for the user
    ///</summary>
    public class GetUserStatisticsSignal : Signal<GetUserStatisticsRequest> { }
    
    ///<summary>
    ///Updates the values of the specified title-specific statistics for the user
    ///</summary>
    public class UpdatePlayerStatisticsSignal : Signal<UpdatePlayerStatisticsRequest> { }
    
    ///<summary>
    ///Updates the title-specific custom data for the user which is readable and writable by the client
    ///</summary>
    public class UpdateUserDataSignal : Signal<UpdateUserDataRequest> { }
    
    ///<summary>
    ///Updates the title-specific custom data for the user which cannot be accessed by the client
    ///</summary>
    public class UpdateUserInternalDataSignal : Signal<UpdateUserInternalDataRequest> { }
    
    ///<summary>
    ///Updates the publisher-specific custom data for the user which is readable and writable by the client
    ///</summary>
    public class UpdateUserPublisherDataSignal : Signal<UpdateUserDataRequest> { }
    
    ///<summary>
    ///Updates the publisher-specific custom data for the user which cannot be accessed by the client
    ///</summary>
    public class UpdateUserPublisherInternalDataSignal : Signal<UpdateUserInternalDataRequest> { }
    
    ///<summary>
    ///Updates the publisher-specific custom data for the user which can only be read by the client
    ///</summary>
    public class UpdateUserPublisherReadOnlyDataSignal : Signal<UpdateUserDataRequest> { }
    
    ///<summary>
    ///Updates the title-specific custom data for the user which can only be read by the client
    ///</summary>
    public class UpdateUserReadOnlyDataSignal : Signal<UpdateUserDataRequest> { }
    
    ///<summary>
    ///Updates the values of the specified title-specific statistics for the user
    ///</summary>
    public class UpdateUserStatisticsSignal : Signal<UpdateUserStatisticsRequest> { }
    
#endregion
    
//Title-Wide Data Management
#region Title-Wide Data Management
    
    ///<summary>
    ///Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
    ///</summary>
    public class GetCatalogItemsSignal : Signal<GetCatalogItemsRequest> { }
    
    ///<summary>
    ///Retrieves the key-value store of custom title settings
    ///</summary>
    public class GetTitleDataSignal : Signal<GetTitleDataRequest> { }
    
    ///<summary>
    ///Retrieves the key-value store of custom internal title settings
    ///</summary>
    public class GetTitleInternalDataSignal : Signal<GetTitleDataRequest> { }
    
    ///<summary>
    ///Retrieves the title news feed, as configured in the developer portal
    ///</summary>
    public class GetTitleNewsSignal : Signal<GetTitleNewsRequest> { }
    
    ///<summary>
    ///Updates the key-value store of custom title settings
    ///</summary>
    public class SetTitleDataSignal : Signal<SetTitleDataRequest> { }
    
    ///<summary>
    ///Updates the key-value store of custom title settings
    ///</summary>
    public class SetTitleInternalDataSignal : Signal<SetTitleDataRequest> { }
    
#endregion
    
//Player Item Management
#region Player Item Management
    
    ///<summary>
    ///Increments  the character's balance of the specified virtual currency by the stated amount
    ///</summary>
    public class AddCharacterVirtualCurrencySignal : Signal<AddCharacterVirtualCurrencyRequest> { }
    
    ///<summary>
    ///Increments  the user's balance of the specified virtual currency by the stated amount
    ///</summary>
    public class AddUserVirtualCurrencySignal : Signal<AddUserVirtualCurrencyRequest> { }
    
    ///<summary>
    ///Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's inventory.
    ///</summary>
    public class ConsumeItemSignal : Signal<ConsumeItemRequest> { }
    
    ///<summary>
    ///Retrieves the specified character's current inventory of virtual goods
    ///</summary>
    public class GetCharacterInventorySignal : Signal<GetCharacterInventoryRequest> { }
    
    ///<summary>
    ///Retrieves the specified user's current inventory of virtual goods
    ///</summary>
    public class GetUserInventorySignal : Signal<GetUserInventoryRequest> { }
    
    ///<summary>
    ///Adds the specified items to the specified character's inventory
    ///</summary>
    public class GrantItemsToCharacterSignal : Signal<GrantItemsToCharacterRequest> { }
    
    ///<summary>
    ///Adds the specified items to the specified user's inventory
    ///</summary>
    public class GrantItemsToUserSignal : Signal<GrantItemsToUserRequest> { }
    
    ///<summary>
    ///Adds the specified items to the specified user inventories
    ///</summary>
    public class GrantItemsToUsersSignal : Signal<GrantItemsToUsersRequest> { }
    
    ///<summary>
    ///Modifies the number of remaining uses of a player's inventory item
    ///</summary>
    public class ModifyItemUsesSignal : Signal<ModifyItemUsesRequest> { }
    
    ///<summary>
    ///Moves an item from a character's inventory into another of the users's character's inventory.
    ///</summary>
    public class MoveItemToCharacterFromCharacterSignal : Signal<MoveItemToCharacterFromCharacterRequest> { }
    
    ///<summary>
    ///Moves an item from a user's inventory into their character's inventory.
    ///</summary>
    public class MoveItemToCharacterFromUserSignal : Signal<MoveItemToCharacterFromUserRequest> { }
    
    ///<summary>
    ///Moves an item from a character's inventory into the owning user's inventory.
    ///</summary>
    public class MoveItemToUserFromCharacterSignal : Signal<MoveItemToUserFromCharacterRequest> { }
    
    ///<summary>
    ///Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated  via the Promotions->Coupons tab in the PlayFab Game Manager. See this post for more information on coupons:  https://playfab.com/blog/2015/06/18/using-stores-and-coupons-game-manager
    ///</summary>
    public class RedeemCouponSignal : Signal<RedeemCouponRequest> { }
    
    ///<summary>
    ///Submit a report about a player (due to bad bahavior, etc.) on behalf of another player, so that customer service representatives for the title can take action concerning potentially toxic players.
    ///</summary>
    public class ReportPlayerSignal : Signal<ReportPlayerServerRequest> { }
    
    ///<summary>
    ///Revokes access to an item in a user's inventory
    ///</summary>
    public class RevokeInventoryItemSignal : Signal<RevokeInventoryItemRequest> { }
    
    ///<summary>
    ///Decrements the character's balance of the specified virtual currency by the stated amount
    ///</summary>
    public class SubtractCharacterVirtualCurrencySignal : Signal<SubtractCharacterVirtualCurrencyRequest> { }
    
    ///<summary>
    ///Decrements the user's balance of the specified virtual currency by the stated amount
    ///</summary>
    public class SubtractUserVirtualCurrencySignal : Signal<SubtractUserVirtualCurrencyRequest> { }
    
    ///<summary>
    ///Opens a specific container (ContainerItemInstanceId), with a specific key (KeyItemInstanceId, when required), and returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
    ///</summary>
    public class UnlockContainerInstanceSignal : Signal<UnlockContainerInstanceRequest> { }
    
    ///<summary>
    ///Searches Player or Character inventory for any ItemInstance matching the given CatalogItemId, if necessary unlocks it using any appropriate key, and returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
    ///</summary>
    public class UnlockContainerItemSignal : Signal<UnlockContainerItemRequest> { }
    
    ///<summary>
    ///Updates the key-value pair data tagged to the specified item, which is read-only from the client.
    ///</summary>
    public class UpdateUserInventoryItemCustomDataSignal : Signal<UpdateUserInventoryItemDataRequest> { }
    
#endregion
    
//Friend List Management
#region Friend List Management
    
#endregion
    
//Matchmaking APIs
#region Matchmaking APIs
    
    ///<summary>
    ///Informs the PlayFab match-making service that the user specified has left the Game Server Instance
    ///</summary>
    public class NotifyMatchmakerPlayerLeftSignal : Signal<NotifyMatchmakerPlayerLeftRequest> { }
    
    ///<summary>
    ///Validates a Game Server session ticket and returns details about the user
    ///</summary>
    public class RedeemMatchmakerTicketSignal : Signal<RedeemMatchmakerTicketRequest> { }
    
#endregion
    
//Steam-Specific APIs
#region Steam-Specific APIs
    
    ///<summary>
    ///Awards the specified users the specified Steam achievements
    ///</summary>
    public class AwardSteamAchievementSignal : Signal<AwardSteamAchievementRequest> { }
    
#endregion
    
//Analytics
#region Analytics
    
    ///<summary>
    ///Logs a custom analytics event
    ///</summary>
    public class LogEventSignal : Signal<LogEventRequest> { }
    
#endregion
    
//Shared Group Data
#region Shared Group Data
    
    ///<summary>
    ///Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users in the group (and the server) can add new members.
    ///</summary>
    public class AddSharedGroupMembersSignal : Signal<AddSharedGroupMembersRequest> { }
    
    ///<summary>
    ///Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the group. When created by a server, the group will initially have no members.
    ///</summary>
    public class CreateSharedGroupSignal : Signal<CreateSharedGroupRequest> { }
    
    ///<summary>
    ///Deletes a shared group, freeing up the shared group ID to be reused for a new group
    ///</summary>
    public class DeleteSharedGroupSignal : Signal<DeleteSharedGroupRequest> { }
    
    ///<summary>
    ///Retrieves the key-value store of custom publisher settings
    ///</summary>
    public class GetPublisherDataSignal : Signal<GetPublisherDataRequest> { }
    
    ///<summary>
    ///Retrieves data stored in a shared group object, as well as the list of members in the group. The server can access all public and private group data.
    ///</summary>
    public class GetSharedGroupDataSignal : Signal<GetSharedGroupDataRequest> { }
    
    ///<summary>
    ///Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the group can remove members. If as a result of the call, zero users remain with access, the group and its associated data will be deleted.
    ///</summary>
    public class RemoveSharedGroupMembersSignal : Signal<RemoveSharedGroupMembersRequest> { }
    
    ///<summary>
    ///Updates the key-value store of custom publisher settings
    ///</summary>
    public class SetPublisherDataSignal : Signal<SetPublisherDataRequest> { }
    
    ///<summary>
    ///Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated or added in this call will be readable by users not in the group. By default, data permissions are set to Private. Regardless of the permission setting, only members of the group (and the server) can update the data.
    ///</summary>
    public class UpdateSharedGroupDataSignal : Signal<UpdateSharedGroupDataRequest> { }
    
#endregion
    
//Server-Side Cloud Script
#region Server-Side Cloud Script
    
#endregion
    
//Content
#region Content
    
    ///<summary>
    ///This API retrieves a pre-signed URL for accessing a content file for the title. A subsequent  HTTP GET to the returned URL will attempt to download the content. A HEAD query to the returned URL will attempt to  retrieve the metadata of the content. Note that a successful result does not guarantee the existence of this content -  if it has not been uploaded, the query to retrieve the data will fail. See this post for more information:  https://community.playfab.com/hc/en-us/community/posts/205469488-How-to-upload-files-to-PlayFab-s-Content-Service
    ///</summary>
    public class GetContentDownloadUrlSignal : Signal<GetContentDownloadUrlRequest> { }
    
#endregion
    
//Characters
#region Characters
    
    ///<summary>
    ///Deletes the specific character ID from the specified user.
    ///</summary>
    public class DeleteCharacterFromUserSignal : Signal<DeleteCharacterFromUserRequest> { }
    
    ///<summary>
    ///Lists all of the characters that belong to a specific user.
    ///</summary>
    public class GetAllUsersCharactersSignal : Signal<ListUsersCharactersRequest> { }
    
    ///<summary>
    ///Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
    ///</summary>
    public class GetCharacterLeaderboardSignal : Signal<GetCharacterLeaderboardRequest> { }
    
    ///<summary>
    ///Retrieves the details of all title-specific statistics for the specific character
    ///</summary>
    public class GetCharacterStatisticsSignal : Signal<GetCharacterStatisticsRequest> { }
    
    ///<summary>
    ///Retrieves a list of ranked characters for the given statistic, centered on the requested user
    ///</summary>
    public class GetLeaderboardAroundCharacterSignal : Signal<GetLeaderboardAroundCharacterRequest> { }
    
    ///<summary>
    ///Retrieves a list of all of the user's characters for the given statistic.
    ///</summary>
    public class GetLeaderboardForUserCharactersSignal : Signal<GetLeaderboardForUsersCharactersRequest> { }
    
    ///<summary>
    ///Grants the specified character type to the user.
    ///</summary>
    public class GrantCharacterToUserSignal : Signal<GrantCharacterToUserRequest> { }
    
    ///<summary>
    ///Updates the values of the specified title-specific statistics for the specific character
    ///</summary>
    public class UpdateCharacterStatisticsSignal : Signal<UpdateCharacterStatisticsRequest> { }
    
#endregion
    
//Character Data
#region Character Data
    
    ///<summary>
    ///Retrieves the title-specific custom data for the user which is readable and writable by the client
    ///</summary>
    public class GetCharacterDataSignal : Signal<GetCharacterDataRequest> { }
    
    ///<summary>
    ///Retrieves the title-specific custom data for the user's character which cannot be accessed by the client
    ///</summary>
    public class GetCharacterInternalDataSignal : Signal<GetCharacterDataRequest> { }
    
    ///<summary>
    ///Retrieves the title-specific custom data for the user's character which can only be read by the client
    ///</summary>
    public class GetCharacterReadOnlyDataSignal : Signal<GetCharacterDataRequest> { }
    
    ///<summary>
    ///Updates the title-specific custom data for the user's chjaracter which is readable and writable by the client
    ///</summary>
    public class UpdateCharacterDataSignal : Signal<UpdateCharacterDataRequest> { }
    
    ///<summary>
    ///Updates the title-specific custom data for the user's character which cannot  be accessed by the client
    ///</summary>
    public class UpdateCharacterInternalDataSignal : Signal<UpdateCharacterDataRequest> { }
    
    ///<summary>
    ///Updates the title-specific custom data for the user's character which can only be read by the client
    ///</summary>
    public class UpdateCharacterReadOnlyDataSignal : Signal<UpdateCharacterDataRequest> { }
    
#endregion
    
//Guilds
#region Guilds
    
#endregion
#endregion

//Response Signals
#region Response Signals

//Matchmaking APIs
#region Matchmaking APIs

    ///<summary>
    ///Validates a user with the PlayFab service
    ///</summary>
    public class AuthUserResponseSignal : Signal<AuthUserResponse> { }

    ///<summary>
    ///Informs the PlayFab game server hosting service that the indicated user has joined the Game Server Instance specified
    ///</summary>
    public class PlayerJoinedResponseSignal : Signal<PlayerJoinedResponse> { }

    ///<summary>
    ///Informs the PlayFab game server hosting service that the indicated user has left the Game Server Instance specified
    ///</summary>
    public class PlayerLeftResponseSignal : Signal<PlayerLeftResponse> { }

    ///<summary>
    ///Instructs the PlayFab game server hosting service to instantiate a new Game Server Instance
    ///</summary>
    public class StartGameResponseSignal : Signal<StartGameResponse> { }

    ///<summary>
    ///Retrieves the relevant details for a specified user, which the external match-making service can then use to compute effective matches
    ///</summary>
    public class UserInfoResponseSignal : Signal<UserInfoResponse> { }

#endregion

//Authentication
#region Authentication

    ///<summary>
    ///Validated a client's session ticket, and if successful, returns details for that user
    ///</summary>
    public class AuthenticateSessionTicketResponseSignal : Signal<AuthenticateSessionTicketResult> { }

#endregion

//Account Management
#region Account Management

    ///<summary>
    ///Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
    ///</summary>
    public class GetPlayFabIDsFromFacebookIDsResponseSignal : Signal<GetPlayFabIDsFromFacebookIDsResult> { }

    ///<summary>
    ///Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers  are the profile IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
    ///</summary>
    public class GetPlayFabIDsFromSteamIDsResponseSignal : Signal<GetPlayFabIDsFromSteamIDsResult> { }

    ///<summary>
    ///Retrieves the relevant details for a specified user
    ///</summary>
    public class GetUserAccountInfoResponseSignal : Signal<GetUserAccountInfoResult> { }

    ///<summary>
    ///Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured for Push Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
    ///</summary>
    public class SendPushNotificationResponseSignal : Signal<SendPushNotificationResult> { }

#endregion

//Player Data Management
#region Player Data Management

    ///<summary>
    ///Deletes the users for the provided game. Deletes custom data, all account linkages, and statistics.
    ///</summary>
    public class DeleteUsersResponseSignal : Signal<DeleteUsersResult> { }

    ///<summary>
    ///Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
    ///</summary>
    public class GetLeaderboardResponseSignal : Signal<GetLeaderboardResult> { }

    ///<summary>
    ///Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
    ///</summary>
    public class GetLeaderboardAroundUserResponseSignal : Signal<GetLeaderboardAroundUserResult> { }

    ///<summary>
    ///Retrieves the current version and values for the indicated statistics, for the local player.
    ///</summary>
    public class GetPlayerStatisticsResponseSignal : Signal<GetPlayerStatisticsResult> { }

    ///<summary>
    ///Retrieves the information on the available versions of the specified statistic.
    ///</summary>
    public class GetPlayerStatisticVersionsResponseSignal : Signal<GetPlayerStatisticVersionsResult> { }

    ///<summary>
    ///Retrieves the title-specific custom data for the user which is readable and writable by the client
    ///</summary>
    public class GetUserDataResponseSignal : Signal<GetUserDataResult> { }

    ///<summary>
    ///Retrieves the title-specific custom data for the user which cannot be accessed by the client
    ///</summary>
    public class GetUserInternalDataResponseSignal : Signal<GetUserDataResult> { }

    ///<summary>
    ///Retrieves the publisher-specific custom data for the user which is readable and writable by the client
    ///</summary>
    public class GetUserPublisherDataResponseSignal : Signal<GetUserDataResult> { }

    ///<summary>
    ///Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
    ///</summary>
    public class GetUserPublisherInternalDataResponseSignal : Signal<GetUserDataResult> { }

    ///<summary>
    ///Retrieves the publisher-specific custom data for the user which can only be read by the client
    ///</summary>
    public class GetUserPublisherReadOnlyDataResponseSignal : Signal<GetUserDataResult> { }

    ///<summary>
    ///Retrieves the title-specific custom data for the user which can only be read by the client
    ///</summary>
    public class GetUserReadOnlyDataResponseSignal : Signal<GetUserDataResult> { }

    ///<summary>
    ///Retrieves the details of all title-specific statistics for the user
    ///</summary>
    public class GetUserStatisticsResponseSignal : Signal<GetUserStatisticsResult> { }

    ///<summary>
    ///Updates the values of the specified title-specific statistics for the user
    ///</summary>
    public class UpdatePlayerStatisticsResponseSignal : Signal<UpdatePlayerStatisticsResult> { }

    ///<summary>
    ///Updates the title-specific custom data for the user which is readable and writable by the client
    ///</summary>
    public class UpdateUserDataResponseSignal : Signal<UpdateUserDataResult> { }

    ///<summary>
    ///Updates the title-specific custom data for the user which cannot be accessed by the client
    ///</summary>
    public class UpdateUserInternalDataResponseSignal : Signal<UpdateUserDataResult> { }

    ///<summary>
    ///Updates the publisher-specific custom data for the user which is readable and writable by the client
    ///</summary>
    public class UpdateUserPublisherDataResponseSignal : Signal<UpdateUserDataResult> { }

    ///<summary>
    ///Updates the publisher-specific custom data for the user which cannot be accessed by the client
    ///</summary>
    public class UpdateUserPublisherInternalDataResponseSignal : Signal<UpdateUserDataResult> { }

    ///<summary>
    ///Updates the publisher-specific custom data for the user which can only be read by the client
    ///</summary>
    public class UpdateUserPublisherReadOnlyDataResponseSignal : Signal<UpdateUserDataResult> { }

    ///<summary>
    ///Updates the title-specific custom data for the user which can only be read by the client
    ///</summary>
    public class UpdateUserReadOnlyDataResponseSignal : Signal<UpdateUserDataResult> { }

    ///<summary>
    ///Updates the values of the specified title-specific statistics for the user
    ///</summary>
    public class UpdateUserStatisticsResponseSignal : Signal<UpdateUserStatisticsResult> { }

#endregion

//Title-Wide Data Management
#region Title-Wide Data Management

    ///<summary>
    ///Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
    ///</summary>
    public class GetCatalogItemsResponseSignal : Signal<GetCatalogItemsResult> { }

    ///<summary>
    ///Retrieves the key-value store of custom title settings
    ///</summary>
    public class GetTitleDataResponseSignal : Signal<GetTitleDataResult> { }

    ///<summary>
    ///Retrieves the key-value store of custom internal title settings
    ///</summary>
    public class GetTitleInternalDataResponseSignal : Signal<GetTitleDataResult> { }

    ///<summary>
    ///Retrieves the title news feed, as configured in the developer portal
    ///</summary>
    public class GetTitleNewsResponseSignal : Signal<GetTitleNewsResult> { }

    ///<summary>
    ///Updates the key-value store of custom title settings
    ///</summary>
    public class SetTitleDataResponseSignal : Signal<SetTitleDataResult> { }

    ///<summary>
    ///Updates the key-value store of custom title settings
    ///</summary>
    public class SetTitleInternalDataResponseSignal : Signal<SetTitleDataResult> { }

#endregion

//Player Item Management
#region Player Item Management

    ///<summary>
    ///Increments  the character's balance of the specified virtual currency by the stated amount
    ///</summary>
    public class AddCharacterVirtualCurrencyResponseSignal : Signal<ModifyCharacterVirtualCurrencyResult> { }

    ///<summary>
    ///Increments  the user's balance of the specified virtual currency by the stated amount
    ///</summary>
    public class AddUserVirtualCurrencyResponseSignal : Signal<ModifyUserVirtualCurrencyResult> { }

    ///<summary>
    ///Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's inventory.
    ///</summary>
    public class ConsumeItemResponseSignal : Signal<ConsumeItemResult> { }

    ///<summary>
    ///Retrieves the specified character's current inventory of virtual goods
    ///</summary>
    public class GetCharacterInventoryResponseSignal : Signal<GetCharacterInventoryResult> { }

    ///<summary>
    ///Retrieves the specified user's current inventory of virtual goods
    ///</summary>
    public class GetUserInventoryResponseSignal : Signal<GetUserInventoryResult> { }

    ///<summary>
    ///Adds the specified items to the specified character's inventory
    ///</summary>
    public class GrantItemsToCharacterResponseSignal : Signal<GrantItemsToCharacterResult> { }

    ///<summary>
    ///Adds the specified items to the specified user's inventory
    ///</summary>
    public class GrantItemsToUserResponseSignal : Signal<GrantItemsToUserResult> { }

    ///<summary>
    ///Adds the specified items to the specified user inventories
    ///</summary>
    public class GrantItemsToUsersResponseSignal : Signal<GrantItemsToUsersResult> { }

    ///<summary>
    ///Modifies the number of remaining uses of a player's inventory item
    ///</summary>
    public class ModifyItemUsesResponseSignal : Signal<ModifyItemUsesResult> { }

    ///<summary>
    ///Moves an item from a character's inventory into another of the users's character's inventory.
    ///</summary>
    public class MoveItemToCharacterFromCharacterResponseSignal : Signal<MoveItemToCharacterFromCharacterResult> { }

    ///<summary>
    ///Moves an item from a user's inventory into their character's inventory.
    ///</summary>
    public class MoveItemToCharacterFromUserResponseSignal : Signal<MoveItemToCharacterFromUserResult> { }

    ///<summary>
    ///Moves an item from a character's inventory into the owning user's inventory.
    ///</summary>
    public class MoveItemToUserFromCharacterResponseSignal : Signal<MoveItemToUserFromCharacterResult> { }

    ///<summary>
    ///Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated  via the Promotions->Coupons tab in the PlayFab Game Manager. See this post for more information on coupons:  https://playfab.com/blog/2015/06/18/using-stores-and-coupons-game-manager
    ///</summary>
    public class RedeemCouponResponseSignal : Signal<RedeemCouponResult> { }

    ///<summary>
    ///Submit a report about a player (due to bad bahavior, etc.) on behalf of another player, so that customer service representatives for the title can take action concerning potentially toxic players.
    ///</summary>
    public class ReportPlayerResponseSignal : Signal<ReportPlayerServerResult> { }

    ///<summary>
    ///Revokes access to an item in a user's inventory
    ///</summary>
    public class RevokeInventoryItemResponseSignal : Signal<RevokeInventoryResult> { }

    ///<summary>
    ///Decrements the character's balance of the specified virtual currency by the stated amount
    ///</summary>
    public class SubtractCharacterVirtualCurrencyResponseSignal : Signal<ModifyCharacterVirtualCurrencyResult> { }

    ///<summary>
    ///Decrements the user's balance of the specified virtual currency by the stated amount
    ///</summary>
    public class SubtractUserVirtualCurrencyResponseSignal : Signal<ModifyUserVirtualCurrencyResult> { }

    ///<summary>
    ///Opens a specific container (ContainerItemInstanceId), with a specific key (KeyItemInstanceId, when required), and returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
    ///</summary>
    public class UnlockContainerInstanceResponseSignal : Signal<UnlockContainerItemResult> { }

    ///<summary>
    ///Searches Player or Character inventory for any ItemInstance matching the given CatalogItemId, if necessary unlocks it using any appropriate key, and returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
    ///</summary>
    public class UnlockContainerItemResponseSignal : Signal<UnlockContainerItemResult> { }

    ///<summary>
    ///Updates the key-value pair data tagged to the specified item, which is read-only from the client.
    ///</summary>
    public class UpdateUserInventoryItemCustomDataResponseSignal : Signal<EmptyResult> { }

#endregion

//Friend List Management
#region Friend List Management

#endregion

//Matchmaking APIs
#region Matchmaking APIs

    ///<summary>
    ///Informs the PlayFab match-making service that the user specified has left the Game Server Instance
    ///</summary>
    public class NotifyMatchmakerPlayerLeftResponseSignal : Signal<NotifyMatchmakerPlayerLeftResult> { }

    ///<summary>
    ///Validates a Game Server session ticket and returns details about the user
    ///</summary>
    public class RedeemMatchmakerTicketResponseSignal : Signal<RedeemMatchmakerTicketResult> { }

#endregion

//Steam-Specific APIs
#region Steam-Specific APIs

    ///<summary>
    ///Awards the specified users the specified Steam achievements
    ///</summary>
    public class AwardSteamAchievementResponseSignal : Signal<AwardSteamAchievementResult> { }

#endregion

//Analytics
#region Analytics

    ///<summary>
    ///Logs a custom analytics event
    ///</summary>
    public class LogEventResponseSignal : Signal<LogEventResult> { }

#endregion

//Shared Group Data
#region Shared Group Data

    ///<summary>
    ///Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users in the group (and the server) can add new members.
    ///</summary>
    public class AddSharedGroupMembersResponseSignal : Signal<AddSharedGroupMembersResult> { }

    ///<summary>
    ///Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the group. When created by a server, the group will initially have no members.
    ///</summary>
    public class CreateSharedGroupResponseSignal : Signal<CreateSharedGroupResult> { }

    ///<summary>
    ///Deletes a shared group, freeing up the shared group ID to be reused for a new group
    ///</summary>
    public class DeleteSharedGroupResponseSignal : Signal<EmptyResult> { }

    ///<summary>
    ///Retrieves the key-value store of custom publisher settings
    ///</summary>
    public class GetPublisherDataResponseSignal : Signal<GetPublisherDataResult> { }

    ///<summary>
    ///Retrieves data stored in a shared group object, as well as the list of members in the group. The server can access all public and private group data.
    ///</summary>
    public class GetSharedGroupDataResponseSignal : Signal<GetSharedGroupDataResult> { }

    ///<summary>
    ///Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the group can remove members. If as a result of the call, zero users remain with access, the group and its associated data will be deleted.
    ///</summary>
    public class RemoveSharedGroupMembersResponseSignal : Signal<RemoveSharedGroupMembersResult> { }

    ///<summary>
    ///Updates the key-value store of custom publisher settings
    ///</summary>
    public class SetPublisherDataResponseSignal : Signal<SetPublisherDataResult> { }

    ///<summary>
    ///Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated or added in this call will be readable by users not in the group. By default, data permissions are set to Private. Regardless of the permission setting, only members of the group (and the server) can update the data.
    ///</summary>
    public class UpdateSharedGroupDataResponseSignal : Signal<UpdateSharedGroupDataResult> { }

#endregion

//Server-Side Cloud Script
#region Server-Side Cloud Script

#endregion

//Content
#region Content

    ///<summary>
    ///This API retrieves a pre-signed URL for accessing a content file for the title. A subsequent  HTTP GET to the returned URL will attempt to download the content. A HEAD query to the returned URL will attempt to  retrieve the metadata of the content. Note that a successful result does not guarantee the existence of this content -  if it has not been uploaded, the query to retrieve the data will fail. See this post for more information:  https://community.playfab.com/hc/en-us/community/posts/205469488-How-to-upload-files-to-PlayFab-s-Content-Service
    ///</summary>
    public class GetContentDownloadUrlResponseSignal : Signal<GetContentDownloadUrlResult> { }

#endregion

//Characters
#region Characters

    ///<summary>
    ///Deletes the specific character ID from the specified user.
    ///</summary>
    public class DeleteCharacterFromUserResponseSignal : Signal<DeleteCharacterFromUserResult> { }

    ///<summary>
    ///Lists all of the characters that belong to a specific user.
    ///</summary>
    public class GetAllUsersCharactersResponseSignal : Signal<ListUsersCharactersResult> { }

    ///<summary>
    ///Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
    ///</summary>
    public class GetCharacterLeaderboardResponseSignal : Signal<GetCharacterLeaderboardResult> { }

    ///<summary>
    ///Retrieves the details of all title-specific statistics for the specific character
    ///</summary>
    public class GetCharacterStatisticsResponseSignal : Signal<GetCharacterStatisticsResult> { }

    ///<summary>
    ///Retrieves a list of ranked characters for the given statistic, centered on the requested user
    ///</summary>
    public class GetLeaderboardAroundCharacterResponseSignal : Signal<GetLeaderboardAroundCharacterResult> { }

    ///<summary>
    ///Retrieves a list of all of the user's characters for the given statistic.
    ///</summary>
    public class GetLeaderboardForUserCharactersResponseSignal : Signal<GetLeaderboardForUsersCharactersResult> { }

    ///<summary>
    ///Grants the specified character type to the user.
    ///</summary>
    public class GrantCharacterToUserResponseSignal : Signal<GrantCharacterToUserResult> { }

    ///<summary>
    ///Updates the values of the specified title-specific statistics for the specific character
    ///</summary>
    public class UpdateCharacterStatisticsResponseSignal : Signal<UpdateCharacterStatisticsResult> { }

#endregion

//Character Data
#region Character Data

    ///<summary>
    ///Retrieves the title-specific custom data for the user which is readable and writable by the client
    ///</summary>
    public class GetCharacterDataResponseSignal : Signal<GetCharacterDataResult> { }

    ///<summary>
    ///Retrieves the title-specific custom data for the user's character which cannot be accessed by the client
    ///</summary>
    public class GetCharacterInternalDataResponseSignal : Signal<GetCharacterDataResult> { }

    ///<summary>
    ///Retrieves the title-specific custom data for the user's character which can only be read by the client
    ///</summary>
    public class GetCharacterReadOnlyDataResponseSignal : Signal<GetCharacterDataResult> { }

    ///<summary>
    ///Updates the title-specific custom data for the user's chjaracter which is readable and writable by the client
    ///</summary>
    public class UpdateCharacterDataResponseSignal : Signal<UpdateCharacterDataResult> { }

    ///<summary>
    ///Updates the title-specific custom data for the user's character which cannot  be accessed by the client
    ///</summary>
    public class UpdateCharacterInternalDataResponseSignal : Signal<UpdateCharacterDataResult> { }

    ///<summary>
    ///Updates the title-specific custom data for the user's character which can only be read by the client
    ///</summary>
    public class UpdateCharacterReadOnlyDataResponseSignal : Signal<UpdateCharacterDataResult> { }

#endregion

//Guilds
#region Guilds

#endregion

#endregion
