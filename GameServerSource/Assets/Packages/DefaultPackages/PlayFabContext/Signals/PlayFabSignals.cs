using strange.extensions.signal.impl;

#region Base Signals

#region Matchmaking

/// <summary>
/// Validates a user with the PlayFab service
/// </summary>
public class AuthUserSignal : Signal<PlayFab.MatchmakerModels.AuthUserRequest> { }

/// <summary>
/// Informs the PlayFab game server hosting service that the indicated user has joined the Game Server Instance specified
/// </summary>
public class PlayerJoinedSignal : Signal<PlayFab.MatchmakerModels.PlayerJoinedRequest> { }

/// <summary>
/// Informs the PlayFab game server hosting service that the indicated user has left the Game Server Instance specified
/// </summary>
public class PlayerLeftSignal : Signal<PlayFab.MatchmakerModels.PlayerLeftRequest> { }

/// <summary>
/// Instructs the PlayFab game server hosting service to instantiate a new Game Server Instance
/// </summary>
public class StartGameSignal : Signal<PlayFab.MatchmakerModels.StartGameRequest> { }

/// <summary>
/// Retrieves the relevant details for a specified user, which the external match-making service can then use to compute
/// effective matches
/// </summary>
public class UserInfoSignal : Signal<PlayFab.MatchmakerModels.UserInfoRequest> { }

#endregion

#region Account Management

/// <summary>
/// Bans users by PlayFab ID with optional IP address, or MAC address for the provided game.
/// </summary>
public class BanUsersSignal : Signal<PlayFab.ServerModels.BanUsersRequest> { }

/// <summary>
/// Retrieves the player's profile
/// </summary>
public class GetPlayerProfileSignal : Signal<PlayFab.ServerModels.GetPlayerProfileRequest> { }

/// <summary>
/// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
/// </summary>
public class GetPlayFabIDsFromFacebookIDsSignal : Signal<PlayFab.ServerModels.GetPlayFabIDsFromFacebookIDsRequest> { }

/// <summary>
/// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers  are the profile
/// IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
/// </summary>
public class GetPlayFabIDsFromSteamIDsSignal : Signal<PlayFab.ServerModels.GetPlayFabIDsFromSteamIDsRequest> { }

/// <summary>
/// Retrieves the relevant details for a specified user
/// </summary>
public class GetUserAccountInfoSignal : Signal<PlayFab.ServerModels.GetUserAccountInfoRequest> { }

/// <summary>
/// Gets all bans for a user.
/// </summary>
public class GetUserBansSignal : Signal<PlayFab.ServerModels.GetUserBansRequest> { }

/// <summary>
/// Revoke all active bans for a user.
/// </summary>
public class RevokeAllBansForUserSignal : Signal<PlayFab.ServerModels.RevokeAllBansForUserRequest> { }

/// <summary>
/// Revoke all active bans specified with BanId.
/// </summary>
public class RevokeBansSignal : Signal<PlayFab.ServerModels.RevokeBansRequest> { }

/// <summary>
/// Forces an email to be sent to the registered contact email address for the user's account based on an account recovery
/// email template
/// </summary>
public class SendCustomAccountRecoveryEmailSignal : Signal<PlayFab.ServerModels.SendCustomAccountRecoveryEmailRequest> { }

/// <summary>
/// Sends an email based on an email template to a player's contact email
/// </summary>
public class SendEmailFromTemplateSignal : Signal<PlayFab.ServerModels.SendEmailFromTemplateRequest> { }

/// <summary>
/// Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured for Push
/// Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
/// </summary>
public class SendPushNotificationSignal : Signal<PlayFab.ServerModels.SendPushNotificationRequest> { }

/// <summary>
/// Update the avatar URL of the specified player
/// </summary>
public class UpdateAvatarUrlSignal : Signal<PlayFab.ServerModels.UpdateAvatarUrlRequest> { }

/// <summary>
/// Updates information of a list of existing bans specified with Ban Ids.
/// </summary>
public class UpdateBansSignal : Signal<PlayFab.ServerModels.UpdateBansRequest> { }

#endregion

#region Analytics

/// <summary>
/// Writes a character-based event into PlayStream.
/// </summary>
public class WriteCharacterEventSignal : Signal<PlayFab.ServerModels.WriteServerCharacterEventRequest> { }

/// <summary>
/// Writes a player-based event into PlayStream.
/// </summary>
public class WritePlayerEventSignal : Signal<PlayFab.ServerModels.WriteServerPlayerEventRequest> { }

/// <summary>
/// Writes a title-based event into PlayStream.
/// </summary>
public class WriteTitleEventSignal : Signal<PlayFab.ServerModels.WriteTitleEventRequest> { }

#endregion

#region Authentication

/// <summary>
/// Validated a client's session ticket, and if successful, returns details for that user
/// </summary>
public class AuthenticateSessionTicketSignal : Signal<PlayFab.ServerModels.AuthenticateSessionTicketRequest> { }

/// <summary>
/// Sets the player's secret if it is not already set. Player secrets are used to sign API requests. To reset a player's
/// secret use the Admin or Server API method SetPlayerSecret.
/// </summary>
public class SetPlayerSecretSignal : Signal<PlayFab.ServerModels.SetPlayerSecretRequest> { }

#endregion

#region Character Data

/// <summary>
/// Retrieves the title-specific custom data for the user which is readable and writable by the client
/// </summary>
public class GetCharacterDataSignal : Signal<PlayFab.ServerModels.GetCharacterDataRequest> { }

/// <summary>
/// Retrieves the title-specific custom data for the user's character which cannot be accessed by the client
/// </summary>
public class GetCharacterInternalDataSignal : Signal<PlayFab.ServerModels.GetCharacterDataRequest> { }

/// <summary>
/// Retrieves the title-specific custom data for the user's character which can only be read by the client
/// </summary>
public class GetCharacterReadOnlyDataSignal : Signal<PlayFab.ServerModels.GetCharacterDataRequest> { }

/// <summary>
/// Updates the title-specific custom data for the user's character which is readable and writable by the client
/// </summary>
public class UpdateCharacterDataSignal : Signal<PlayFab.ServerModels.UpdateCharacterDataRequest> { }

/// <summary>
/// Updates the title-specific custom data for the user's character which cannot  be accessed by the client
/// </summary>
public class UpdateCharacterInternalDataSignal : Signal<PlayFab.ServerModels.UpdateCharacterDataRequest> { }

/// <summary>
/// Updates the title-specific custom data for the user's character which can only be read by the client
/// </summary>
public class UpdateCharacterReadOnlyDataSignal : Signal<PlayFab.ServerModels.UpdateCharacterDataRequest> { }

#endregion

#region Characters

/// <summary>
/// Deletes the specific character ID from the specified user.
/// </summary>
public class DeleteCharacterFromUserSignal : Signal<PlayFab.ServerModels.DeleteCharacterFromUserRequest> { }

/// <summary>
/// Lists all of the characters that belong to a specific user. CharacterIds are not globally unique; characterId must be
/// evaluated with the parent PlayFabId to guarantee uniqueness.
/// </summary>
public class GetAllUsersCharactersSignal : Signal<PlayFab.ServerModels.ListUsersCharactersRequest> { }

/// <summary>
/// Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
/// </summary>
public class GetCharacterLeaderboardSignal : Signal<PlayFab.ServerModels.GetCharacterLeaderboardRequest> { }

/// <summary>
/// Retrieves the details of all title-specific statistics for the specific character
/// </summary>
public class GetCharacterStatisticsSignal : Signal<PlayFab.ServerModels.GetCharacterStatisticsRequest> { }

/// <summary>
/// Retrieves a list of ranked characters for the given statistic, centered on the requested user
/// </summary>
public class GetLeaderboardAroundCharacterSignal : Signal<PlayFab.ServerModels.GetLeaderboardAroundCharacterRequest> { }

/// <summary>
/// Retrieves a list of all of the user's characters for the given statistic.
/// </summary>
public class GetLeaderboardForUserCharactersSignal : Signal<PlayFab.ServerModels.GetLeaderboardForUsersCharactersRequest> { }

/// <summary>
/// Grants the specified character type to the user. CharacterIds are not globally unique; characterId must be evaluated
/// with the parent PlayFabId to guarantee uniqueness.
/// </summary>
public class GrantCharacterToUserSignal : Signal<PlayFab.ServerModels.GrantCharacterToUserRequest> { }

/// <summary>
/// Updates the values of the specified title-specific statistics for the specific character
/// </summary>
public class UpdateCharacterStatisticsSignal : Signal<PlayFab.ServerModels.UpdateCharacterStatisticsRequest> { }

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
public class GetContentDownloadUrlSignal : Signal<PlayFab.ServerModels.GetContentDownloadUrlRequest> { }

#endregion

#region Friend List Management

/// <summary>
/// Adds the Friend user to the friendlist of the user with PlayFabId. At least one of
/// FriendPlayFabId,FriendUsername,FriendEmail, or FriendTitleDisplayName should be initialized.
/// </summary>
public class AddFriendSignal : Signal<PlayFab.ServerModels.AddFriendRequest> { }

/// <summary>
/// Retrieves the current friends for the user with PlayFabId, constrained to users who have PlayFab accounts. Friends from
/// linked accounts (Facebook, Steam) are also included. You may optionally exclude some linked services' friends.
/// </summary>
public class GetFriendsListSignal : Signal<PlayFab.ServerModels.GetFriendsListRequest> { }

/// <summary>
/// Removes the specified friend from the the user's friend list
/// </summary>
public class RemoveFriendSignal : Signal<PlayFab.ServerModels.RemoveFriendRequest> { }

/// <summary>
/// Updates the tag list for a specified user in the friend list of another user
/// </summary>
public class SetFriendTagsSignal : Signal<PlayFab.ServerModels.SetFriendTagsRequest> { }

#endregion

#region Matchmaking

/// <summary>
/// Inform the matchmaker that a Game Server Instance is removed.
/// </summary>
public class DeregisterGameSignal : Signal<PlayFab.ServerModels.DeregisterGameRequest> { }

/// <summary>
/// Informs the PlayFab match-making service that the user specified has left the Game Server Instance
/// </summary>
public class NotifyMatchmakerPlayerLeftSignal : Signal<PlayFab.ServerModels.NotifyMatchmakerPlayerLeftRequest> { }

/// <summary>
/// Validates a Game Server session ticket and returns details about the user
/// </summary>
public class RedeemMatchmakerTicketSignal : Signal<PlayFab.ServerModels.RedeemMatchmakerTicketRequest> { }

/// <summary>
/// Set the state of the indicated Game Server Instance. Also update the heartbeat for the instance.
/// </summary>
public class RefreshGameServerInstanceHeartbeatSignal : Signal<PlayFab.ServerModels.RefreshGameServerInstanceHeartbeatRequest> { }

/// <summary>
/// Inform the matchmaker that a new Game Server Instance is added.
/// </summary>
public class RegisterGameSignal : Signal<PlayFab.ServerModels.RegisterGameRequest> { }

/// <summary>
/// Sets the custom data of the indicated Game Server Instance
/// </summary>
public class SetGameServerInstanceDataSignal : Signal<PlayFab.ServerModels.SetGameServerInstanceDataRequest> { }

/// <summary>
/// Set the state of the indicated Game Server Instance.
/// </summary>
public class SetGameServerInstanceStateSignal : Signal<PlayFab.ServerModels.SetGameServerInstanceStateRequest> { }

/// <summary>
/// Set custom tags for the specified Game Server Instance
/// </summary>
public class SetGameServerInstanceTagsSignal : Signal<PlayFab.ServerModels.SetGameServerInstanceTagsRequest> { }

#endregion

#region Platform Specific Methods

/// <summary>
/// Awards the specified users the specified Steam achievements
/// </summary>
public class AwardSteamAchievementSignal : Signal<PlayFab.ServerModels.AwardSteamAchievementRequest> { }

#endregion

#region Player Data Management

/// <summary>
/// Deletes the users for the provided game. Deletes custom data, all account linkages, and statistics.
/// </summary>
public class DeleteUsersSignal : Signal<PlayFab.ServerModels.DeleteUsersRequest> { }

/// <summary>
/// Retrieves a list of ranked friends of the given player for the given statistic, starting from the indicated point in the
/// leaderboard
/// </summary>
public class GetFriendLeaderboardSignal : Signal<PlayFab.ServerModels.GetFriendLeaderboardRequest> { }

/// <summary>
/// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
/// </summary>
public class GetLeaderboardSignal : Signal<PlayFab.ServerModels.GetLeaderboardRequest> { }

/// <summary>
/// Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
/// </summary>
public class GetLeaderboardAroundUserSignal : Signal<PlayFab.ServerModels.GetLeaderboardAroundUserRequest> { }

/// <summary>
/// Returns whatever info is requested in the response for the user. Note that PII (like email address, facebook id)
/// may be returned. All parameters default to false.
/// </summary>
public class GetPlayerCombinedInfoSignal : Signal<PlayFab.ServerModels.GetPlayerCombinedInfoRequest> { }

/// <summary>
/// Retrieves the current version and values for the indicated statistics, for the local player.
/// </summary>
public class GetPlayerStatisticsSignal : Signal<PlayFab.ServerModels.GetPlayerStatisticsRequest> { }

/// <summary>
/// Retrieves the information on the available versions of the specified statistic.
/// </summary>
public class GetPlayerStatisticVersionsSignal : Signal<PlayFab.ServerModels.GetPlayerStatisticVersionsRequest> { }

/// <summary>
/// Retrieves the title-specific custom data for the user which is readable and writable by the client
/// </summary>
public class GetUserDataSignal : Signal<PlayFab.ServerModels.GetUserDataRequest> { }

/// <summary>
/// Retrieves the title-specific custom data for the user which cannot be accessed by the client
/// </summary>
public class GetUserInternalDataSignal : Signal<PlayFab.ServerModels.GetUserDataRequest> { }

/// <summary>
/// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
/// </summary>
public class GetUserPublisherDataSignal : Signal<PlayFab.ServerModels.GetUserDataRequest> { }

/// <summary>
/// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
/// </summary>
public class GetUserPublisherInternalDataSignal : Signal<PlayFab.ServerModels.GetUserDataRequest> { }

/// <summary>
/// Retrieves the publisher-specific custom data for the user which can only be read by the client
/// </summary>
public class GetUserPublisherReadOnlyDataSignal : Signal<PlayFab.ServerModels.GetUserDataRequest> { }

/// <summary>
/// Retrieves the title-specific custom data for the user which can only be read by the client
/// </summary>
public class GetUserReadOnlyDataSignal : Signal<PlayFab.ServerModels.GetUserDataRequest> { }

/// <summary>
/// Updates the values of the specified title-specific statistics for the user
/// </summary>
public class UpdatePlayerStatisticsSignal : Signal<PlayFab.ServerModels.UpdatePlayerStatisticsRequest> { }

/// <summary>
/// Updates the title-specific custom data for the user which is readable and writable by the client
/// </summary>
public class UpdateUserDataSignal : Signal<PlayFab.ServerModels.UpdateUserDataRequest> { }

/// <summary>
/// Updates the title-specific custom data for the user which cannot be accessed by the client
/// </summary>
public class UpdateUserInternalDataSignal : Signal<PlayFab.ServerModels.UpdateUserInternalDataRequest> { }

/// <summary>
/// Updates the publisher-specific custom data for the user which is readable and writable by the client
/// </summary>
public class UpdateUserPublisherDataSignal : Signal<PlayFab.ServerModels.UpdateUserDataRequest> { }

/// <summary>
/// Updates the publisher-specific custom data for the user which cannot be accessed by the client
/// </summary>
public class UpdateUserPublisherInternalDataSignal : Signal<PlayFab.ServerModels.UpdateUserInternalDataRequest> { }

/// <summary>
/// Updates the publisher-specific custom data for the user which can only be read by the client
/// </summary>
public class UpdateUserPublisherReadOnlyDataSignal : Signal<PlayFab.ServerModels.UpdateUserDataRequest> { }

/// <summary>
/// Updates the title-specific custom data for the user which can only be read by the client
/// </summary>
public class UpdateUserReadOnlyDataSignal : Signal<PlayFab.ServerModels.UpdateUserDataRequest> { }

#endregion

#region Player Item Management

/// <summary>
/// Increments  the character's balance of the specified virtual currency by the stated amount
/// </summary>
public class AddCharacterVirtualCurrencySignal : Signal<PlayFab.ServerModels.AddCharacterVirtualCurrencyRequest> { }

/// <summary>
/// Increments  the user's balance of the specified virtual currency by the stated amount
/// </summary>
public class AddUserVirtualCurrencySignal : Signal<PlayFab.ServerModels.AddUserVirtualCurrencyRequest> { }

/// <summary>
/// Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's inventory.
/// </summary>
public class ConsumeItemSignal : Signal<PlayFab.ServerModels.ConsumeItemRequest> { }

/// <summary>
/// Returns the result of an evaluation of a Random Result Table - the ItemId from the game Catalog which would have been
/// added to the player inventory, if the Random Result Table were added via a Bundle or a call to UnlockContainer.
/// </summary>
public class EvaluateRandomResultTableSignal : Signal<PlayFab.ServerModels.EvaluateRandomResultTableRequest> { }

/// <summary>
/// Retrieves the specified character's current inventory of virtual goods
/// </summary>
public class GetCharacterInventorySignal : Signal<PlayFab.ServerModels.GetCharacterInventoryRequest> { }

/// <summary>
/// Retrieves the configuration information for the specified random results tables for the title, including all ItemId
/// values and weights
/// </summary>
public class GetRandomResultTablesSignal : Signal<PlayFab.ServerModels.GetRandomResultTablesRequest> { }

/// <summary>
/// Retrieves the specified user's current inventory of virtual goods
/// </summary>
public class GetUserInventorySignal : Signal<PlayFab.ServerModels.GetUserInventoryRequest> { }

/// <summary>
/// Adds the specified items to the specified character's inventory
/// </summary>
public class GrantItemsToCharacterSignal : Signal<PlayFab.ServerModels.GrantItemsToCharacterRequest> { }

/// <summary>
/// Adds the specified items to the specified user's inventory
/// </summary>
public class GrantItemsToUserSignal : Signal<PlayFab.ServerModels.GrantItemsToUserRequest> { }

/// <summary>
/// Adds the specified items to the specified user inventories
/// </summary>
public class GrantItemsToUsersSignal : Signal<PlayFab.ServerModels.GrantItemsToUsersRequest> { }

/// <summary>
/// Modifies the number of remaining uses of a player's inventory item
/// </summary>
public class ModifyItemUsesSignal : Signal<PlayFab.ServerModels.ModifyItemUsesRequest> { }

/// <summary>
/// Moves an item from a character's inventory into another of the users's character's inventory.
/// </summary>
public class MoveItemToCharacterFromCharacterSignal : Signal<PlayFab.ServerModels.MoveItemToCharacterFromCharacterRequest> { }

/// <summary>
/// Moves an item from a user's inventory into their character's inventory.
/// </summary>
public class MoveItemToCharacterFromUserSignal : Signal<PlayFab.ServerModels.MoveItemToCharacterFromUserRequest> { }

/// <summary>
/// Moves an item from a character's inventory into the owning user's inventory.
/// </summary>
public class MoveItemToUserFromCharacterSignal : Signal<PlayFab.ServerModels.MoveItemToUserFromCharacterRequest> { }

/// <summary>
/// Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated  via the
/// Economy->Catalogs tab in the PlayFab Game Manager.
/// </summary>
public class RedeemCouponSignal : Signal<PlayFab.ServerModels.RedeemCouponRequest> { }

/// <summary>
/// Submit a report about a player (due to bad bahavior, etc.) on behalf of another player, so that customer service
/// representatives for the title can take action concerning potentially toxic players.
/// </summary>
public class ReportPlayerSignal : Signal<PlayFab.ServerModels.ReportPlayerServerRequest> { }

/// <summary>
/// Revokes access to an item in a user's inventory
/// </summary>
public class RevokeInventoryItemSignal : Signal<PlayFab.ServerModels.RevokeInventoryItemRequest> { }

/// <summary>
/// Decrements the character's balance of the specified virtual currency by the stated amount. It is possible to make a VC
/// balance negative with this API.
/// </summary>
public class SubtractCharacterVirtualCurrencySignal : Signal<PlayFab.ServerModels.SubtractCharacterVirtualCurrencyRequest> { }

/// <summary>
/// Decrements the user's balance of the specified virtual currency by the stated amount. It is possible to make a VC
/// balance negative with this API.
/// </summary>
public class SubtractUserVirtualCurrencySignal : Signal<PlayFab.ServerModels.SubtractUserVirtualCurrencyRequest> { }

/// <summary>
/// Opens a specific container (ContainerItemInstanceId), with a specific key (KeyItemInstanceId, when required), and
/// returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses >
/// 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
/// </summary>
public class UnlockContainerInstanceSignal : Signal<PlayFab.ServerModels.UnlockContainerInstanceRequest> { }

/// <summary>
/// Searches Player or Character inventory for any ItemInstance matching the given CatalogItemId, if necessary unlocks it
/// using any appropriate key, and returns the contents of the opened container. If the container (and key when relevant)
/// are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of
/// ConsumeItem.
/// </summary>
public class UnlockContainerItemSignal : Signal<PlayFab.ServerModels.UnlockContainerItemRequest> { }

/// <summary>
/// Updates the key-value pair data tagged to the specified item, which is read-only from the client.
/// </summary>
public class UpdateUserInventoryItemCustomDataSignal : Signal<PlayFab.ServerModels.UpdateUserInventoryItemDataRequest> { }

#endregion

#region PlayStream

/// <summary>
/// Adds a given tag to a player profile. The tag's namespace is automatically generated based on the source of the tag.
/// </summary>
public class AddPlayerTagSignal : Signal<PlayFab.ServerModels.AddPlayerTagRequest> { }

/// <summary>
/// Retrieves an array of player segment definitions. Results from this can be used in subsequent API calls such as
/// GetPlayersInSegment which requires a Segment ID. While segment names can change the ID for that segment will not change.
/// </summary>
public class GetAllSegmentsSignal : Signal<PlayFab.ServerModels.GetAllSegmentsRequest> { }

/// <summary>
/// List all segments that a player currently belongs to at this moment in time.
/// </summary>
public class GetPlayerSegmentsSignal : Signal<PlayFab.ServerModels.GetPlayersSegmentsRequest> { }

/// <summary>
/// Allows for paging through all players in a given segment. This API creates a snapshot of all player profiles that match
/// the segment definition at the time of its creation and lives through the Total Seconds to Live, refreshing its life span
/// on each subsequent use of the Continuation Token. Profiles that change during the course of paging will not be reflected
/// in the results. AB Test segments are currently not supported by this operation.
/// </summary>
public class GetPlayersInSegmentSignal : Signal<PlayFab.ServerModels.GetPlayersInSegmentRequest> { }

/// <summary>
/// Get all tags with a given Namespace (optional) from a player profile.
/// </summary>
public class GetPlayerTagsSignal : Signal<PlayFab.ServerModels.GetPlayerTagsRequest> { }

/// <summary>
/// Remove a given tag from a player profile. The tag's namespace is automatically generated based on the source of the tag.
/// </summary>
public class RemovePlayerTagSignal : Signal<PlayFab.ServerModels.RemovePlayerTagRequest> { }

#endregion

#region Server-Side Cloud Script

/// <summary>
/// Executes a CloudScript function, with the 'currentPlayerId' variable set to the specified PlayFabId parameter value.
/// </summary>
public class ExecuteCloudScriptSignal : Signal<PlayFab.ServerModels.ExecuteCloudScriptServerRequest> { }

#endregion

#region Shared Group Data

/// <summary>
/// Adds users to the set of those able to update both the shared data, as well as the set of users  in the group. Only
/// users in the group (and the server) can add new members. Shared Groups are designed for sharing data  between a very
/// small number of players, please see our guide: https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class AddSharedGroupMembersSignal : Signal<PlayFab.ServerModels.AddSharedGroupMembersRequest> { }

/// <summary>
/// Requests the creation of a shared group object, containing key/value pairs which may  be updated by all members of the
/// group. When created by a server, the group will initially have no members.  Shared Groups are designed for sharing data
/// between a very small number of players, please see our guide:
/// https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class CreateSharedGroupSignal : Signal<PlayFab.ServerModels.CreateSharedGroupRequest> { }

/// <summary>
/// Deletes a shared group, freeing up the shared group ID to be reused for a new group.  Shared Groups are designed for
/// sharing data between a very small number of players, please see our guide:
/// https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class DeleteSharedGroupSignal : Signal<PlayFab.ServerModels.DeleteSharedGroupRequest> { }

/// <summary>
/// Retrieves data stored in a shared group object, as well as the list of members in the group.  The server can access all
/// public and private group data. Shared Groups are designed for sharing data between a very  small number of players,
/// please see our guide: https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class GetSharedGroupDataSignal : Signal<PlayFab.ServerModels.GetSharedGroupDataRequest> { }

/// <summary>
/// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the
/// group can remove members. If as a result of the call, zero users remain with access, the group and its associated data
/// will be deleted. Shared Groups are designed for sharing data between a very small number of players,  please see our
/// guide: https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class RemoveSharedGroupMembersSignal : Signal<PlayFab.ServerModels.RemoveSharedGroupMembersRequest> { }

/// <summary>
/// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated
/// or added in this call will be readable by users not in the group. By default, data permissions are set to Private.
/// Regardless of the permission setting, only members of the group (and the server) can update the data.  Shared Groups are
/// designed for sharing data between a very small number of players, please see our guide:
/// https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class UpdateSharedGroupDataSignal : Signal<PlayFab.ServerModels.UpdateSharedGroupDataRequest> { }

#endregion

#region Title-Wide Data Management

/// <summary>
/// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
/// </summary>
public class GetCatalogItemsSignal : Signal<PlayFab.ServerModels.GetCatalogItemsRequest> { }

/// <summary>
/// Retrieves the key-value store of custom publisher settings
/// </summary>
public class GetPublisherDataSignal : Signal<PlayFab.ServerModels.GetPublisherDataRequest> { }

/// <summary>
/// Retrieves the current server time
/// </summary>
public class GetTimeSignal : Signal<PlayFab.ServerModels.GetTimeRequest> { }

/// <summary>
/// Retrieves the key-value store of custom title settings
/// </summary>
public class GetTitleDataSignal : Signal<PlayFab.ServerModels.GetTitleDataRequest> { }

/// <summary>
/// Retrieves the key-value store of custom internal title settings
/// </summary>
public class GetTitleInternalDataSignal : Signal<PlayFab.ServerModels.GetTitleDataRequest> { }

/// <summary>
/// Retrieves the title news feed, as configured in the developer portal
/// </summary>
public class GetTitleNewsSignal : Signal<PlayFab.ServerModels.GetTitleNewsRequest> { }

/// <summary>
/// Updates the key-value store of custom publisher settings
/// </summary>
public class SetPublisherDataSignal : Signal<PlayFab.ServerModels.SetPublisherDataRequest> { }

/// <summary>
/// Updates the key-value store of custom title settings
/// </summary>
public class SetTitleDataSignal : Signal<PlayFab.ServerModels.SetTitleDataRequest> { }

/// <summary>
/// Updates the key-value store of custom title settings
/// </summary>
public class SetTitleInternalDataSignal : Signal<PlayFab.ServerModels.SetTitleDataRequest> { }

#endregion

#endregion

#region Response Signals

#region Matchmaking

/// <summary>
/// Validates a user with the PlayFab service
/// </summary>
public class AuthUserResponseSignal : Signal<PlayFab.MatchmakerModels.AuthUserResponse> { }

/// <summary>
/// Informs the PlayFab game server hosting service that the indicated user has joined the Game Server Instance specified
/// </summary>
public class PlayerJoinedResponseSignal : Signal<PlayFab.MatchmakerModels.PlayerJoinedResponse> { }

/// <summary>
/// Informs the PlayFab game server hosting service that the indicated user has left the Game Server Instance specified
/// </summary>
public class PlayerLeftResponseSignal : Signal<PlayFab.MatchmakerModels.PlayerLeftResponse> { }

/// <summary>
/// Instructs the PlayFab game server hosting service to instantiate a new Game Server Instance
/// </summary>
public class StartGameResponseSignal : Signal<PlayFab.MatchmakerModels.StartGameResponse> { }

/// <summary>
/// Retrieves the relevant details for a specified user, which the external match-making service can then use to compute
/// effective matches
/// </summary>
public class UserInfoResponseSignal : Signal<PlayFab.MatchmakerModels.UserInfoResponse> { }

#endregion

#region Account Management

/// <summary>
/// Bans users by PlayFab ID with optional IP address, or MAC address for the provided game.
/// </summary>
public class BanUsersResponseSignal : Signal<PlayFab.ServerModels.BanUsersResult> { }

/// <summary>
/// Retrieves the player's profile
/// </summary>
public class GetPlayerProfileResponseSignal : Signal<PlayFab.ServerModels.GetPlayerProfileResult> { }

/// <summary>
/// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
/// </summary>
public class GetPlayFabIDsFromFacebookIDsResponseSignal : Signal<PlayFab.ServerModels.GetPlayFabIDsFromFacebookIDsResult> { }

/// <summary>
/// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers  are the profile
/// IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
/// </summary>
public class GetPlayFabIDsFromSteamIDsResponseSignal : Signal<PlayFab.ServerModels.GetPlayFabIDsFromSteamIDsResult> { }

/// <summary>
/// Retrieves the relevant details for a specified user
/// </summary>
public class GetUserAccountInfoResponseSignal : Signal<PlayFab.ServerModels.GetUserAccountInfoResult> { }

/// <summary>
/// Gets all bans for a user.
/// </summary>
public class GetUserBansResponseSignal : Signal<PlayFab.ServerModels.GetUserBansResult> { }

/// <summary>
/// Revoke all active bans for a user.
/// </summary>
public class RevokeAllBansForUserResponseSignal : Signal<PlayFab.ServerModels.RevokeAllBansForUserResult> { }

/// <summary>
/// Revoke all active bans specified with BanId.
/// </summary>
public class RevokeBansResponseSignal : Signal<PlayFab.ServerModels.RevokeBansResult> { }

/// <summary>
/// Forces an email to be sent to the registered contact email address for the user's account based on an account recovery
/// email template
/// </summary>
public class SendCustomAccountRecoveryEmailResponseSignal : Signal<PlayFab.ServerModels.SendCustomAccountRecoveryEmailResult> { }

/// <summary>
/// Sends an email based on an email template to a player's contact email
/// </summary>
public class SendEmailFromTemplateResponseSignal : Signal<PlayFab.ServerModels.SendEmailFromTemplateResult> { }

/// <summary>
/// Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured for Push
/// Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
/// </summary>
public class SendPushNotificationResponseSignal : Signal<PlayFab.ServerModels.SendPushNotificationResult> { }

/// <summary>
/// Update the avatar URL of the specified player
/// </summary>
public class UpdateAvatarUrlResponseSignal : Signal<PlayFab.ServerModels.EmptyResult> { }

/// <summary>
/// Updates information of a list of existing bans specified with Ban Ids.
/// </summary>
public class UpdateBansResponseSignal : Signal<PlayFab.ServerModels.UpdateBansResult> { }

#endregion

#region Analytics

/// <summary>
/// Writes a character-based event into PlayStream.
/// </summary>
public class WriteCharacterEventResponseSignal : Signal<PlayFab.ServerModels.WriteEventResponse> { }

/// <summary>
/// Writes a player-based event into PlayStream.
/// </summary>
public class WritePlayerEventResponseSignal : Signal<PlayFab.ServerModels.WriteEventResponse> { }

/// <summary>
/// Writes a title-based event into PlayStream.
/// </summary>
public class WriteTitleEventResponseSignal : Signal<PlayFab.ServerModels.WriteEventResponse> { }

#endregion

#region Authentication

/// <summary>
/// Validated a client's session ticket, and if successful, returns details for that user
/// </summary>
public class AuthenticateSessionTicketResponseSignal : Signal<PlayFab.ServerModels.AuthenticateSessionTicketResult> { }

/// <summary>
/// Sets the player's secret if it is not already set. Player secrets are used to sign API requests. To reset a player's
/// secret use the Admin or Server API method SetPlayerSecret.
/// </summary>
public class SetPlayerSecretResponseSignal : Signal<PlayFab.ServerModels.SetPlayerSecretResult> { }

#endregion

#region Character Data

/// <summary>
/// Retrieves the title-specific custom data for the user which is readable and writable by the client
/// </summary>
public class GetCharacterDataResponseSignal : Signal<PlayFab.ServerModels.GetCharacterDataResult> { }

/// <summary>
/// Retrieves the title-specific custom data for the user's character which cannot be accessed by the client
/// </summary>
public class GetCharacterInternalDataResponseSignal : Signal<PlayFab.ServerModels.GetCharacterDataResult> { }

/// <summary>
/// Retrieves the title-specific custom data for the user's character which can only be read by the client
/// </summary>
public class GetCharacterReadOnlyDataResponseSignal : Signal<PlayFab.ServerModels.GetCharacterDataResult> { }

/// <summary>
/// Updates the title-specific custom data for the user's character which is readable and writable by the client
/// </summary>
public class UpdateCharacterDataResponseSignal : Signal<PlayFab.ServerModels.UpdateCharacterDataResult> { }

/// <summary>
/// Updates the title-specific custom data for the user's character which cannot  be accessed by the client
/// </summary>
public class UpdateCharacterInternalDataResponseSignal : Signal<PlayFab.ServerModels.UpdateCharacterDataResult> { }

/// <summary>
/// Updates the title-specific custom data for the user's character which can only be read by the client
/// </summary>
public class UpdateCharacterReadOnlyDataResponseSignal : Signal<PlayFab.ServerModels.UpdateCharacterDataResult> { }

#endregion

#region Characters

/// <summary>
/// Deletes the specific character ID from the specified user.
/// </summary>
public class DeleteCharacterFromUserResponseSignal : Signal<PlayFab.ServerModels.DeleteCharacterFromUserResult> { }

/// <summary>
/// Lists all of the characters that belong to a specific user. CharacterIds are not globally unique; characterId must be
/// evaluated with the parent PlayFabId to guarantee uniqueness.
/// </summary>
public class GetAllUsersCharactersResponseSignal : Signal<PlayFab.ServerModels.ListUsersCharactersResult> { }

/// <summary>
/// Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
/// </summary>
public class GetCharacterLeaderboardResponseSignal : Signal<PlayFab.ServerModels.GetCharacterLeaderboardResult> { }

/// <summary>
/// Retrieves the details of all title-specific statistics for the specific character
/// </summary>
public class GetCharacterStatisticsResponseSignal : Signal<PlayFab.ServerModels.GetCharacterStatisticsResult> { }

/// <summary>
/// Retrieves a list of ranked characters for the given statistic, centered on the requested user
/// </summary>
public class GetLeaderboardAroundCharacterResponseSignal : Signal<PlayFab.ServerModels.GetLeaderboardAroundCharacterResult> { }

/// <summary>
/// Retrieves a list of all of the user's characters for the given statistic.
/// </summary>
public class GetLeaderboardForUserCharactersResponseSignal : Signal<PlayFab.ServerModels.GetLeaderboardForUsersCharactersResult> { }

/// <summary>
/// Grants the specified character type to the user. CharacterIds are not globally unique; characterId must be evaluated
/// with the parent PlayFabId to guarantee uniqueness.
/// </summary>
public class GrantCharacterToUserResponseSignal : Signal<PlayFab.ServerModels.GrantCharacterToUserResult> { }

/// <summary>
/// Updates the values of the specified title-specific statistics for the specific character
/// </summary>
public class UpdateCharacterStatisticsResponseSignal : Signal<PlayFab.ServerModels.UpdateCharacterStatisticsResult> { }

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
public class GetContentDownloadUrlResponseSignal : Signal<PlayFab.ServerModels.GetContentDownloadUrlResult> { }

#endregion

#region Friend List Management

/// <summary>
/// Adds the Friend user to the friendlist of the user with PlayFabId. At least one of
/// FriendPlayFabId,FriendUsername,FriendEmail, or FriendTitleDisplayName should be initialized.
/// </summary>
public class AddFriendResponseSignal : Signal<PlayFab.ServerModels.EmptyResult> { }

/// <summary>
/// Retrieves the current friends for the user with PlayFabId, constrained to users who have PlayFab accounts. Friends from
/// linked accounts (Facebook, Steam) are also included. You may optionally exclude some linked services' friends.
/// </summary>
public class GetFriendsListResponseSignal : Signal<PlayFab.ServerModels.GetFriendsListResult> { }

/// <summary>
/// Removes the specified friend from the the user's friend list
/// </summary>
public class RemoveFriendResponseSignal : Signal<PlayFab.ServerModels.EmptyResult> { }

/// <summary>
/// Updates the tag list for a specified user in the friend list of another user
/// </summary>
public class SetFriendTagsResponseSignal : Signal<PlayFab.ServerModels.EmptyResult> { }

#endregion

#region Matchmaking

/// <summary>
/// Inform the matchmaker that a Game Server Instance is removed.
/// </summary>
public class DeregisterGameResponseSignal : Signal<PlayFab.ServerModels.DeregisterGameResponse> { }

/// <summary>
/// Informs the PlayFab match-making service that the user specified has left the Game Server Instance
/// </summary>
public class NotifyMatchmakerPlayerLeftResponseSignal : Signal<PlayFab.ServerModels.NotifyMatchmakerPlayerLeftResult> { }

/// <summary>
/// Validates a Game Server session ticket and returns details about the user
/// </summary>
public class RedeemMatchmakerTicketResponseSignal : Signal<PlayFab.ServerModels.RedeemMatchmakerTicketResult> { }

/// <summary>
/// Set the state of the indicated Game Server Instance. Also update the heartbeat for the instance.
/// </summary>
public class RefreshGameServerInstanceHeartbeatResponseSignal : Signal<PlayFab.ServerModels.RefreshGameServerInstanceHeartbeatResult> { }

/// <summary>
/// Inform the matchmaker that a new Game Server Instance is added.
/// </summary>
public class RegisterGameResponseSignal : Signal<PlayFab.ServerModels.RegisterGameResponse> { }

/// <summary>
/// Sets the custom data of the indicated Game Server Instance
/// </summary>
public class SetGameServerInstanceDataResponseSignal : Signal<PlayFab.ServerModels.SetGameServerInstanceDataResult> { }

/// <summary>
/// Set the state of the indicated Game Server Instance.
/// </summary>
public class SetGameServerInstanceStateResponseSignal : Signal<PlayFab.ServerModels.SetGameServerInstanceStateResult> { }

/// <summary>
/// Set custom tags for the specified Game Server Instance
/// </summary>
public class SetGameServerInstanceTagsResponseSignal : Signal<PlayFab.ServerModels.SetGameServerInstanceTagsResult> { }

#endregion

#region Platform Specific Methods

/// <summary>
/// Awards the specified users the specified Steam achievements
/// </summary>
public class AwardSteamAchievementResponseSignal : Signal<PlayFab.ServerModels.AwardSteamAchievementResult> { }

#endregion

#region Player Data Management

/// <summary>
/// Deletes the users for the provided game. Deletes custom data, all account linkages, and statistics.
/// </summary>
public class DeleteUsersResponseSignal : Signal<PlayFab.ServerModels.DeleteUsersResult> { }

/// <summary>
/// Retrieves a list of ranked friends of the given player for the given statistic, starting from the indicated point in the
/// leaderboard
/// </summary>
public class GetFriendLeaderboardResponseSignal : Signal<PlayFab.ServerModels.GetLeaderboardResult> { }

/// <summary>
/// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
/// </summary>
public class GetLeaderboardResponseSignal : Signal<PlayFab.ServerModels.GetLeaderboardResult> { }

/// <summary>
/// Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
/// </summary>
public class GetLeaderboardAroundUserResponseSignal : Signal<PlayFab.ServerModels.GetLeaderboardAroundUserResult> { }

/// <summary>
/// Returns whatever info is requested in the response for the user. Note that PII (like email address, facebook id)
/// may be returned. All parameters default to false.
/// </summary>
public class GetPlayerCombinedInfoResponseSignal : Signal<PlayFab.ServerModels.GetPlayerCombinedInfoResult> { }

/// <summary>
/// Retrieves the current version and values for the indicated statistics, for the local player.
/// </summary>
public class GetPlayerStatisticsResponseSignal : Signal<PlayFab.ServerModels.GetPlayerStatisticsResult> { }

/// <summary>
/// Retrieves the information on the available versions of the specified statistic.
/// </summary>
public class GetPlayerStatisticVersionsResponseSignal : Signal<PlayFab.ServerModels.GetPlayerStatisticVersionsResult> { }

/// <summary>
/// Retrieves the title-specific custom data for the user which is readable and writable by the client
/// </summary>
public class GetUserDataResponseSignal : Signal<PlayFab.ServerModels.GetUserDataResult> { }

/// <summary>
/// Retrieves the title-specific custom data for the user which cannot be accessed by the client
/// </summary>
public class GetUserInternalDataResponseSignal : Signal<PlayFab.ServerModels.GetUserDataResult> { }

/// <summary>
/// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
/// </summary>
public class GetUserPublisherDataResponseSignal : Signal<PlayFab.ServerModels.GetUserDataResult> { }

/// <summary>
/// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
/// </summary>
public class GetUserPublisherInternalDataResponseSignal : Signal<PlayFab.ServerModels.GetUserDataResult> { }

/// <summary>
/// Retrieves the publisher-specific custom data for the user which can only be read by the client
/// </summary>
public class GetUserPublisherReadOnlyDataResponseSignal : Signal<PlayFab.ServerModels.GetUserDataResult> { }

/// <summary>
/// Retrieves the title-specific custom data for the user which can only be read by the client
/// </summary>
public class GetUserReadOnlyDataResponseSignal : Signal<PlayFab.ServerModels.GetUserDataResult> { }

/// <summary>
/// Updates the values of the specified title-specific statistics for the user
/// </summary>
public class UpdatePlayerStatisticsResponseSignal : Signal<PlayFab.ServerModels.UpdatePlayerStatisticsResult> { }

/// <summary>
/// Updates the title-specific custom data for the user which is readable and writable by the client
/// </summary>
public class UpdateUserDataResponseSignal : Signal<PlayFab.ServerModels.UpdateUserDataResult> { }

/// <summary>
/// Updates the title-specific custom data for the user which cannot be accessed by the client
/// </summary>
public class UpdateUserInternalDataResponseSignal : Signal<PlayFab.ServerModels.UpdateUserDataResult> { }

/// <summary>
/// Updates the publisher-specific custom data for the user which is readable and writable by the client
/// </summary>
public class UpdateUserPublisherDataResponseSignal : Signal<PlayFab.ServerModels.UpdateUserDataResult> { }

/// <summary>
/// Updates the publisher-specific custom data for the user which cannot be accessed by the client
/// </summary>
public class UpdateUserPublisherInternalDataResponseSignal : Signal<PlayFab.ServerModels.UpdateUserDataResult> { }

/// <summary>
/// Updates the publisher-specific custom data for the user which can only be read by the client
/// </summary>
public class UpdateUserPublisherReadOnlyDataResponseSignal : Signal<PlayFab.ServerModels.UpdateUserDataResult> { }

/// <summary>
/// Updates the title-specific custom data for the user which can only be read by the client
/// </summary>
public class UpdateUserReadOnlyDataResponseSignal : Signal<PlayFab.ServerModels.UpdateUserDataResult> { }

#endregion

#region Player Item Management

/// <summary>
/// Increments  the character's balance of the specified virtual currency by the stated amount
/// </summary>
public class AddCharacterVirtualCurrencyResponseSignal : Signal<PlayFab.ServerModels.ModifyCharacterVirtualCurrencyResult> { }

/// <summary>
/// Increments  the user's balance of the specified virtual currency by the stated amount
/// </summary>
public class AddUserVirtualCurrencyResponseSignal : Signal<PlayFab.ServerModels.ModifyUserVirtualCurrencyResult> { }

/// <summary>
/// Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's inventory.
/// </summary>
public class ConsumeItemResponseSignal : Signal<PlayFab.ServerModels.ConsumeItemResult> { }

/// <summary>
/// Returns the result of an evaluation of a Random Result Table - the ItemId from the game Catalog which would have been
/// added to the player inventory, if the Random Result Table were added via a Bundle or a call to UnlockContainer.
/// </summary>
public class EvaluateRandomResultTableResponseSignal : Signal<PlayFab.ServerModels.EvaluateRandomResultTableResult> { }

/// <summary>
/// Retrieves the specified character's current inventory of virtual goods
/// </summary>
public class GetCharacterInventoryResponseSignal : Signal<PlayFab.ServerModels.GetCharacterInventoryResult> { }

/// <summary>
/// Retrieves the configuration information for the specified random results tables for the title, including all ItemId
/// values and weights
/// </summary>
public class GetRandomResultTablesResponseSignal : Signal<PlayFab.ServerModels.GetRandomResultTablesResult> { }

/// <summary>
/// Retrieves the specified user's current inventory of virtual goods
/// </summary>
public class GetUserInventoryResponseSignal : Signal<PlayFab.ServerModels.GetUserInventoryResult> { }

/// <summary>
/// Adds the specified items to the specified character's inventory
/// </summary>
public class GrantItemsToCharacterResponseSignal : Signal<PlayFab.ServerModels.GrantItemsToCharacterResult> { }

/// <summary>
/// Adds the specified items to the specified user's inventory
/// </summary>
public class GrantItemsToUserResponseSignal : Signal<PlayFab.ServerModels.GrantItemsToUserResult> { }

/// <summary>
/// Adds the specified items to the specified user inventories
/// </summary>
public class GrantItemsToUsersResponseSignal : Signal<PlayFab.ServerModels.GrantItemsToUsersResult> { }

/// <summary>
/// Modifies the number of remaining uses of a player's inventory item
/// </summary>
public class ModifyItemUsesResponseSignal : Signal<PlayFab.ServerModels.ModifyItemUsesResult> { }

/// <summary>
/// Moves an item from a character's inventory into another of the users's character's inventory.
/// </summary>
public class MoveItemToCharacterFromCharacterResponseSignal : Signal<PlayFab.ServerModels.MoveItemToCharacterFromCharacterResult> { }

/// <summary>
/// Moves an item from a user's inventory into their character's inventory.
/// </summary>
public class MoveItemToCharacterFromUserResponseSignal : Signal<PlayFab.ServerModels.MoveItemToCharacterFromUserResult> { }

/// <summary>
/// Moves an item from a character's inventory into the owning user's inventory.
/// </summary>
public class MoveItemToUserFromCharacterResponseSignal : Signal<PlayFab.ServerModels.MoveItemToUserFromCharacterResult> { }

/// <summary>
/// Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated  via the
/// Economy->Catalogs tab in the PlayFab Game Manager.
/// </summary>
public class RedeemCouponResponseSignal : Signal<PlayFab.ServerModels.RedeemCouponResult> { }

/// <summary>
/// Submit a report about a player (due to bad bahavior, etc.) on behalf of another player, so that customer service
/// representatives for the title can take action concerning potentially toxic players.
/// </summary>
public class ReportPlayerResponseSignal : Signal<PlayFab.ServerModels.ReportPlayerServerResult> { }

/// <summary>
/// Revokes access to an item in a user's inventory
/// </summary>
public class RevokeInventoryItemResponseSignal : Signal<PlayFab.ServerModels.RevokeInventoryResult> { }

/// <summary>
/// Decrements the character's balance of the specified virtual currency by the stated amount. It is possible to make a VC
/// balance negative with this API.
/// </summary>
public class SubtractCharacterVirtualCurrencyResponseSignal : Signal<PlayFab.ServerModels.ModifyCharacterVirtualCurrencyResult> { }

/// <summary>
/// Decrements the user's balance of the specified virtual currency by the stated amount. It is possible to make a VC
/// balance negative with this API.
/// </summary>
public class SubtractUserVirtualCurrencyResponseSignal : Signal<PlayFab.ServerModels.ModifyUserVirtualCurrencyResult> { }

/// <summary>
/// Opens a specific container (ContainerItemInstanceId), with a specific key (KeyItemInstanceId, when required), and
/// returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses >
/// 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
/// </summary>
public class UnlockContainerInstanceResponseSignal : Signal<PlayFab.ServerModels.UnlockContainerItemResult> { }

/// <summary>
/// Searches Player or Character inventory for any ItemInstance matching the given CatalogItemId, if necessary unlocks it
/// using any appropriate key, and returns the contents of the opened container. If the container (and key when relevant)
/// are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of
/// ConsumeItem.
/// </summary>
public class UnlockContainerItemResponseSignal : Signal<PlayFab.ServerModels.UnlockContainerItemResult> { }

/// <summary>
/// Updates the key-value pair data tagged to the specified item, which is read-only from the client.
/// </summary>
public class UpdateUserInventoryItemCustomDataResponseSignal : Signal<PlayFab.ServerModels.EmptyResult> { }

#endregion

#region PlayStream

/// <summary>
/// Adds a given tag to a player profile. The tag's namespace is automatically generated based on the source of the tag.
/// </summary>
public class AddPlayerTagResponseSignal : Signal<PlayFab.ServerModels.AddPlayerTagResult> { }

/// <summary>
/// Retrieves an array of player segment definitions. Results from this can be used in subsequent API calls such as
/// GetPlayersInSegment which requires a Segment ID. While segment names can change the ID for that segment will not change.
/// </summary>
public class GetAllSegmentsResponseSignal : Signal<PlayFab.ServerModels.GetAllSegmentsResult> { }

/// <summary>
/// List all segments that a player currently belongs to at this moment in time.
/// </summary>
public class GetPlayerSegmentsResponseSignal : Signal<PlayFab.ServerModels.GetPlayerSegmentsResult> { }

/// <summary>
/// Allows for paging through all players in a given segment. This API creates a snapshot of all player profiles that match
/// the segment definition at the time of its creation and lives through the Total Seconds to Live, refreshing its life span
/// on each subsequent use of the Continuation Token. Profiles that change during the course of paging will not be reflected
/// in the results. AB Test segments are currently not supported by this operation.
/// </summary>
public class GetPlayersInSegmentResponseSignal : Signal<PlayFab.ServerModels.GetPlayersInSegmentResult> { }

/// <summary>
/// Get all tags with a given Namespace (optional) from a player profile.
/// </summary>
public class GetPlayerTagsResponseSignal : Signal<PlayFab.ServerModels.GetPlayerTagsResult> { }

/// <summary>
/// Remove a given tag from a player profile. The tag's namespace is automatically generated based on the source of the tag.
/// </summary>
public class RemovePlayerTagResponseSignal : Signal<PlayFab.ServerModels.RemovePlayerTagResult> { }

#endregion

#region Server-Side Cloud Script

/// <summary>
/// Executes a CloudScript function, with the 'currentPlayerId' variable set to the specified PlayFabId parameter value.
/// </summary>
public class ExecuteCloudScriptResponseSignal : Signal<PlayFab.ServerModels.ExecuteCloudScriptResult> { }

#endregion

#region Shared Group Data

/// <summary>
/// Adds users to the set of those able to update both the shared data, as well as the set of users  in the group. Only
/// users in the group (and the server) can add new members. Shared Groups are designed for sharing data  between a very
/// small number of players, please see our guide: https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class AddSharedGroupMembersResponseSignal : Signal<PlayFab.ServerModels.AddSharedGroupMembersResult> { }

/// <summary>
/// Requests the creation of a shared group object, containing key/value pairs which may  be updated by all members of the
/// group. When created by a server, the group will initially have no members.  Shared Groups are designed for sharing data
/// between a very small number of players, please see our guide:
/// https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class CreateSharedGroupResponseSignal : Signal<PlayFab.ServerModels.CreateSharedGroupResult> { }

/// <summary>
/// Deletes a shared group, freeing up the shared group ID to be reused for a new group.  Shared Groups are designed for
/// sharing data between a very small number of players, please see our guide:
/// https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class DeleteSharedGroupResponseSignal : Signal<PlayFab.ServerModels.EmptyResult> { }

/// <summary>
/// Retrieves data stored in a shared group object, as well as the list of members in the group.  The server can access all
/// public and private group data. Shared Groups are designed for sharing data between a very  small number of players,
/// please see our guide: https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class GetSharedGroupDataResponseSignal : Signal<PlayFab.ServerModels.GetSharedGroupDataResult> { }

/// <summary>
/// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the
/// group can remove members. If as a result of the call, zero users remain with access, the group and its associated data
/// will be deleted. Shared Groups are designed for sharing data between a very small number of players,  please see our
/// guide: https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class RemoveSharedGroupMembersResponseSignal : Signal<PlayFab.ServerModels.RemoveSharedGroupMembersResult> { }

/// <summary>
/// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated
/// or added in this call will be readable by users not in the group. By default, data permissions are set to Private.
/// Regardless of the permission setting, only members of the group (and the server) can update the data.  Shared Groups are
/// designed for sharing data between a very small number of players, please see our guide:
/// https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class UpdateSharedGroupDataResponseSignal : Signal<PlayFab.ServerModels.UpdateSharedGroupDataResult> { }

#endregion

#region Title-Wide Data Management

/// <summary>
/// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
/// </summary>
public class GetCatalogItemsResponseSignal : Signal<PlayFab.ServerModels.GetCatalogItemsResult> { }

/// <summary>
/// Retrieves the key-value store of custom publisher settings
/// </summary>
public class GetPublisherDataResponseSignal : Signal<PlayFab.ServerModels.GetPublisherDataResult> { }

/// <summary>
/// Retrieves the current server time
/// </summary>
public class GetTimeResponseSignal : Signal<PlayFab.ServerModels.GetTimeResult> { }

/// <summary>
/// Retrieves the key-value store of custom title settings
/// </summary>
public class GetTitleDataResponseSignal : Signal<PlayFab.ServerModels.GetTitleDataResult> { }

/// <summary>
/// Retrieves the key-value store of custom internal title settings
/// </summary>
public class GetTitleInternalDataResponseSignal : Signal<PlayFab.ServerModels.GetTitleDataResult> { }

/// <summary>
/// Retrieves the title news feed, as configured in the developer portal
/// </summary>
public class GetTitleNewsResponseSignal : Signal<PlayFab.ServerModels.GetTitleNewsResult> { }

/// <summary>
/// Updates the key-value store of custom publisher settings
/// </summary>
public class SetPublisherDataResponseSignal : Signal<PlayFab.ServerModels.SetPublisherDataResult> { }

/// <summary>
/// Updates the key-value store of custom title settings
/// </summary>
public class SetTitleDataResponseSignal : Signal<PlayFab.ServerModels.SetTitleDataResult> { }

/// <summary>
/// Updates the key-value store of custom title settings
/// </summary>
public class SetTitleInternalDataResponseSignal : Signal<PlayFab.ServerModels.SetTitleDataResult> { }

#endregion

#endregion
