using PlayFab;
using strange.extensions.command.impl;

#region Matchmaking

/// <summary>
/// Validates a user with the PlayFab service
/// </summary>
public class AuthUserCommand : Command
{
    [Inject] public AuthUserResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.MatchmakerModels.AuthUserRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabMatchmakerAPI.AuthUser(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Informs the PlayFab game server hosting service that the indicated user has joined the Game Server Instance specified
/// </summary>
public class PlayerJoinedCommand : Command
{
    [Inject] public PlayerJoinedResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.MatchmakerModels.PlayerJoinedRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabMatchmakerAPI.PlayerJoined(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Informs the PlayFab game server hosting service that the indicated user has left the Game Server Instance specified
/// </summary>
public class PlayerLeftCommand : Command
{
    [Inject] public PlayerLeftResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.MatchmakerModels.PlayerLeftRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabMatchmakerAPI.PlayerLeft(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Instructs the PlayFab game server hosting service to instantiate a new Game Server Instance
/// </summary>
public class StartGameCommand : Command
{
    [Inject] public StartGameResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.MatchmakerModels.StartGameRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabMatchmakerAPI.StartGame(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the relevant details for a specified user, which the external match-making service can then use to compute
/// effective matches
/// </summary>
public class UserInfoCommand : Command
{
    [Inject] public UserInfoResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.MatchmakerModels.UserInfoRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabMatchmakerAPI.UserInfo(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}
#endregion

#region Account Management

/// <summary>
/// Bans users by PlayFab ID with optional IP address, or MAC address for the provided game.
/// </summary>
public class BanUsersCommand : Command
{
    [Inject] public BanUsersResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.BanUsersRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.BanUsers(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the player's profile
/// </summary>
public class GetPlayerProfileCommand : Command
{
    [Inject] public GetPlayerProfileResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetPlayerProfileRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetPlayerProfile(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
/// </summary>
public class GetPlayFabIDsFromFacebookIDsCommand : Command
{
    [Inject] public GetPlayFabIDsFromFacebookIDsResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetPlayFabIDsFromFacebookIDsRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetPlayFabIDsFromFacebookIDs(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers  are the profile
/// IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
/// </summary>
public class GetPlayFabIDsFromSteamIDsCommand : Command
{
    [Inject] public GetPlayFabIDsFromSteamIDsResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetPlayFabIDsFromSteamIDsRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetPlayFabIDsFromSteamIDs(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the relevant details for a specified user
/// </summary>
public class GetUserAccountInfoCommand : Command
{
    [Inject] public GetUserAccountInfoResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetUserAccountInfoRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetUserAccountInfo(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Gets all bans for a user.
/// </summary>
public class GetUserBansCommand : Command
{
    [Inject] public GetUserBansResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetUserBansRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetUserBans(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Revoke all active bans for a user.
/// </summary>
public class RevokeAllBansForUserCommand : Command
{
    [Inject] public RevokeAllBansForUserResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.RevokeAllBansForUserRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.RevokeAllBansForUser(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Revoke all active bans specified with BanId.
/// </summary>
public class RevokeBansCommand : Command
{
    [Inject] public RevokeBansResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.RevokeBansRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.RevokeBans(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Forces an email to be sent to the registered contact email address for the user's account based on an account recovery
/// email template
/// </summary>
public class SendCustomAccountRecoveryEmailCommand : Command
{
    [Inject] public SendCustomAccountRecoveryEmailResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.SendCustomAccountRecoveryEmailRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.SendCustomAccountRecoveryEmail(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Sends an email based on an email template to a player's contact email
/// </summary>
public class SendEmailFromTemplateCommand : Command
{
    [Inject] public SendEmailFromTemplateResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.SendEmailFromTemplateRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.SendEmailFromTemplate(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured for Push
/// Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
/// </summary>
public class SendPushNotificationCommand : Command
{
    [Inject] public SendPushNotificationResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.SendPushNotificationRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.SendPushNotification(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Update the avatar URL of the specified player
/// </summary>
public class UpdateAvatarUrlCommand : Command
{
    [Inject] public UpdateAvatarUrlResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.UpdateAvatarUrlRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.UpdateAvatarUrl(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Updates information of a list of existing bans specified with Ban Ids.
/// </summary>
public class UpdateBansCommand : Command
{
    [Inject] public UpdateBansResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.UpdateBansRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.UpdateBans(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}
#endregion

#region Analytics

/// <summary>
/// Writes a character-based event into PlayStream.
/// </summary>
public class WriteCharacterEventCommand : Command
{
    [Inject] public WriteCharacterEventResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.WriteServerCharacterEventRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.WriteCharacterEvent(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Writes a player-based event into PlayStream.
/// </summary>
public class WritePlayerEventCommand : Command
{
    [Inject] public WritePlayerEventResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.WriteServerPlayerEventRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.WritePlayerEvent(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Writes a title-based event into PlayStream.
/// </summary>
public class WriteTitleEventCommand : Command
{
    [Inject] public WriteTitleEventResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.WriteTitleEventRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.WriteTitleEvent(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}
#endregion

#region Authentication

/// <summary>
/// Validated a client's session ticket, and if successful, returns details for that user
/// </summary>
public class AuthenticateSessionTicketCommand : Command
{
    [Inject] public AuthenticateSessionTicketResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.AuthenticateSessionTicketRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.AuthenticateSessionTicket(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Sets the player's secret if it is not already set. Player secrets are used to sign API requests. To reset a player's
/// secret use the Admin or Server API method SetPlayerSecret.
/// </summary>
public class SetPlayerSecretCommand : Command
{
    [Inject] public SetPlayerSecretResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.SetPlayerSecretRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.SetPlayerSecret(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}
#endregion

#region Character Data

/// <summary>
/// Retrieves the title-specific custom data for the user which is readable and writable by the client
/// </summary>
public class GetCharacterDataCommand : Command
{
    [Inject] public GetCharacterDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetCharacterDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetCharacterData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the title-specific custom data for the user's character which cannot be accessed by the client
/// </summary>
public class GetCharacterInternalDataCommand : Command
{
    [Inject] public GetCharacterInternalDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetCharacterDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetCharacterInternalData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the title-specific custom data for the user's character which can only be read by the client
/// </summary>
public class GetCharacterReadOnlyDataCommand : Command
{
    [Inject] public GetCharacterReadOnlyDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetCharacterDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetCharacterReadOnlyData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Updates the title-specific custom data for the user's character which is readable and writable by the client
/// </summary>
public class UpdateCharacterDataCommand : Command
{
    [Inject] public UpdateCharacterDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.UpdateCharacterDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.UpdateCharacterData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Updates the title-specific custom data for the user's character which cannot  be accessed by the client
/// </summary>
public class UpdateCharacterInternalDataCommand : Command
{
    [Inject] public UpdateCharacterInternalDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.UpdateCharacterDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.UpdateCharacterInternalData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Updates the title-specific custom data for the user's character which can only be read by the client
/// </summary>
public class UpdateCharacterReadOnlyDataCommand : Command
{
    [Inject] public UpdateCharacterReadOnlyDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.UpdateCharacterDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.UpdateCharacterReadOnlyData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}
#endregion

#region Characters

/// <summary>
/// Deletes the specific character ID from the specified user.
/// </summary>
public class DeleteCharacterFromUserCommand : Command
{
    [Inject] public DeleteCharacterFromUserResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.DeleteCharacterFromUserRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.DeleteCharacterFromUser(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Lists all of the characters that belong to a specific user. CharacterIds are not globally unique; characterId must be
/// evaluated with the parent PlayFabId to guarantee uniqueness.
/// </summary>
public class GetAllUsersCharactersCommand : Command
{
    [Inject] public GetAllUsersCharactersResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.ListUsersCharactersRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetAllUsersCharacters(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
/// </summary>
public class GetCharacterLeaderboardCommand : Command
{
    [Inject] public GetCharacterLeaderboardResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetCharacterLeaderboardRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetCharacterLeaderboard(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the details of all title-specific statistics for the specific character
/// </summary>
public class GetCharacterStatisticsCommand : Command
{
    [Inject] public GetCharacterStatisticsResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetCharacterStatisticsRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetCharacterStatistics(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves a list of ranked characters for the given statistic, centered on the requested user
/// </summary>
public class GetLeaderboardAroundCharacterCommand : Command
{
    [Inject] public GetLeaderboardAroundCharacterResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetLeaderboardAroundCharacterRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetLeaderboardAroundCharacter(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves a list of all of the user's characters for the given statistic.
/// </summary>
public class GetLeaderboardForUserCharactersCommand : Command
{
    [Inject] public GetLeaderboardForUserCharactersResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetLeaderboardForUsersCharactersRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetLeaderboardForUserCharacters(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Grants the specified character type to the user. CharacterIds are not globally unique; characterId must be evaluated
/// with the parent PlayFabId to guarantee uniqueness.
/// </summary>
public class GrantCharacterToUserCommand : Command
{
    [Inject] public GrantCharacterToUserResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GrantCharacterToUserRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GrantCharacterToUser(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Updates the values of the specified title-specific statistics for the specific character
/// </summary>
public class UpdateCharacterStatisticsCommand : Command
{
    [Inject] public UpdateCharacterStatisticsResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.UpdateCharacterStatisticsRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.UpdateCharacterStatistics(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}
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
public class GetContentDownloadUrlCommand : Command
{
    [Inject] public GetContentDownloadUrlResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetContentDownloadUrlRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetContentDownloadUrl(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}
#endregion

#region Friend List Management

/// <summary>
/// Adds the Friend user to the friendlist of the user with PlayFabId. At least one of
/// FriendPlayFabId,FriendUsername,FriendEmail, or FriendTitleDisplayName should be initialized.
/// </summary>
public class AddFriendCommand : Command
{
    [Inject] public AddFriendResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.AddFriendRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.AddFriend(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the current friends for the user with PlayFabId, constrained to users who have PlayFab accounts. Friends from
/// linked accounts (Facebook, Steam) are also included. You may optionally exclude some linked services' friends.
/// </summary>
public class GetFriendsListCommand : Command
{
    [Inject] public GetFriendsListResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetFriendsListRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetFriendsList(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Removes the specified friend from the the user's friend list
/// </summary>
public class RemoveFriendCommand : Command
{
    [Inject] public RemoveFriendResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.RemoveFriendRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.RemoveFriend(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Updates the tag list for a specified user in the friend list of another user
/// </summary>
public class SetFriendTagsCommand : Command
{
    [Inject] public SetFriendTagsResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.SetFriendTagsRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.SetFriendTags(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}
#endregion

#region Matchmaking

/// <summary>
/// Inform the matchmaker that a Game Server Instance is removed.
/// </summary>
public class DeregisterGameCommand : Command
{
    [Inject] public DeregisterGameResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.DeregisterGameRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.DeregisterGame(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Informs the PlayFab match-making service that the user specified has left the Game Server Instance
/// </summary>
public class NotifyMatchmakerPlayerLeftCommand : Command
{
    [Inject] public NotifyMatchmakerPlayerLeftResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.NotifyMatchmakerPlayerLeftRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.NotifyMatchmakerPlayerLeft(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Validates a Game Server session ticket and returns details about the user
/// </summary>
public class RedeemMatchmakerTicketCommand : Command
{
    [Inject] public RedeemMatchmakerTicketResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.RedeemMatchmakerTicketRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.RedeemMatchmakerTicket(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Set the state of the indicated Game Server Instance. Also update the heartbeat for the instance.
/// </summary>
public class RefreshGameServerInstanceHeartbeatCommand : Command
{
    [Inject] public RefreshGameServerInstanceHeartbeatResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.RefreshGameServerInstanceHeartbeatRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.RefreshGameServerInstanceHeartbeat(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Inform the matchmaker that a new Game Server Instance is added.
/// </summary>
public class RegisterGameCommand : Command
{
    [Inject] public RegisterGameResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.RegisterGameRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.RegisterGame(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Sets the custom data of the indicated Game Server Instance
/// </summary>
public class SetGameServerInstanceDataCommand : Command
{
    [Inject] public SetGameServerInstanceDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.SetGameServerInstanceDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.SetGameServerInstanceData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Set the state of the indicated Game Server Instance.
/// </summary>
public class SetGameServerInstanceStateCommand : Command
{
    [Inject] public SetGameServerInstanceStateResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.SetGameServerInstanceStateRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.SetGameServerInstanceState(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Set custom tags for the specified Game Server Instance
/// </summary>
public class SetGameServerInstanceTagsCommand : Command
{
    [Inject] public SetGameServerInstanceTagsResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.SetGameServerInstanceTagsRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.SetGameServerInstanceTags(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}
#endregion

#region Platform Specific Methods

/// <summary>
/// Awards the specified users the specified Steam achievements
/// </summary>
public class AwardSteamAchievementCommand : Command
{
    [Inject] public AwardSteamAchievementResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.AwardSteamAchievementRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.AwardSteamAchievement(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}
#endregion

#region Player Data Management

/// <summary>
/// Deletes the users for the provided game. Deletes custom data, all account linkages, and statistics.
/// </summary>
public class DeleteUsersCommand : Command
{
    [Inject] public DeleteUsersResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.DeleteUsersRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.DeleteUsers(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves a list of ranked friends of the given player for the given statistic, starting from the indicated point in the
/// leaderboard
/// </summary>
public class GetFriendLeaderboardCommand : Command
{
    [Inject] public GetFriendLeaderboardResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetFriendLeaderboardRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetFriendLeaderboard(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
/// </summary>
public class GetLeaderboardCommand : Command
{
    [Inject] public GetLeaderboardResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetLeaderboardRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetLeaderboard(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
/// </summary>
public class GetLeaderboardAroundUserCommand : Command
{
    [Inject] public GetLeaderboardAroundUserResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetLeaderboardAroundUserRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetLeaderboardAroundUser(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Returns whatever info is requested in the response for the user. Note that PII (like email address, facebook id)
/// may be returned. All parameters default to false.
/// </summary>
public class GetPlayerCombinedInfoCommand : Command
{
    [Inject] public GetPlayerCombinedInfoResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetPlayerCombinedInfoRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetPlayerCombinedInfo(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the current version and values for the indicated statistics, for the local player.
/// </summary>
public class GetPlayerStatisticsCommand : Command
{
    [Inject] public GetPlayerStatisticsResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetPlayerStatisticsRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetPlayerStatistics(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the information on the available versions of the specified statistic.
/// </summary>
public class GetPlayerStatisticVersionsCommand : Command
{
    [Inject] public GetPlayerStatisticVersionsResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetPlayerStatisticVersionsRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetPlayerStatisticVersions(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the title-specific custom data for the user which is readable and writable by the client
/// </summary>
public class GetUserDataCommand : Command
{
    [Inject] public GetUserDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetUserDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetUserData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the title-specific custom data for the user which cannot be accessed by the client
/// </summary>
public class GetUserInternalDataCommand : Command
{
    [Inject] public GetUserInternalDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetUserDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetUserInternalData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
/// </summary>
public class GetUserPublisherDataCommand : Command
{
    [Inject] public GetUserPublisherDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetUserDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetUserPublisherData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
/// </summary>
public class GetUserPublisherInternalDataCommand : Command
{
    [Inject] public GetUserPublisherInternalDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetUserDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetUserPublisherInternalData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the publisher-specific custom data for the user which can only be read by the client
/// </summary>
public class GetUserPublisherReadOnlyDataCommand : Command
{
    [Inject] public GetUserPublisherReadOnlyDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetUserDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetUserPublisherReadOnlyData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the title-specific custom data for the user which can only be read by the client
/// </summary>
public class GetUserReadOnlyDataCommand : Command
{
    [Inject] public GetUserReadOnlyDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetUserDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetUserReadOnlyData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Updates the values of the specified title-specific statistics for the user
/// </summary>
public class UpdatePlayerStatisticsCommand : Command
{
    [Inject] public UpdatePlayerStatisticsResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.UpdatePlayerStatisticsRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.UpdatePlayerStatistics(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Updates the title-specific custom data for the user which is readable and writable by the client
/// </summary>
public class UpdateUserDataCommand : Command
{
    [Inject] public UpdateUserDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.UpdateUserDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.UpdateUserData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Updates the title-specific custom data for the user which cannot be accessed by the client
/// </summary>
public class UpdateUserInternalDataCommand : Command
{
    [Inject] public UpdateUserInternalDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.UpdateUserInternalDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.UpdateUserInternalData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Updates the publisher-specific custom data for the user which is readable and writable by the client
/// </summary>
public class UpdateUserPublisherDataCommand : Command
{
    [Inject] public UpdateUserPublisherDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.UpdateUserDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.UpdateUserPublisherData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Updates the publisher-specific custom data for the user which cannot be accessed by the client
/// </summary>
public class UpdateUserPublisherInternalDataCommand : Command
{
    [Inject] public UpdateUserPublisherInternalDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.UpdateUserInternalDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.UpdateUserPublisherInternalData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Updates the publisher-specific custom data for the user which can only be read by the client
/// </summary>
public class UpdateUserPublisherReadOnlyDataCommand : Command
{
    [Inject] public UpdateUserPublisherReadOnlyDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.UpdateUserDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.UpdateUserPublisherReadOnlyData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Updates the title-specific custom data for the user which can only be read by the client
/// </summary>
public class UpdateUserReadOnlyDataCommand : Command
{
    [Inject] public UpdateUserReadOnlyDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.UpdateUserDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.UpdateUserReadOnlyData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}
#endregion

#region Player Item Management

/// <summary>
/// Increments  the character's balance of the specified virtual currency by the stated amount
/// </summary>
public class AddCharacterVirtualCurrencyCommand : Command
{
    [Inject] public AddCharacterVirtualCurrencyResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.AddCharacterVirtualCurrencyRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.AddCharacterVirtualCurrency(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Increments  the user's balance of the specified virtual currency by the stated amount
/// </summary>
public class AddUserVirtualCurrencyCommand : Command
{
    [Inject] public AddUserVirtualCurrencyResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.AddUserVirtualCurrencyRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.AddUserVirtualCurrency(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's inventory.
/// </summary>
public class ConsumeItemCommand : Command
{
    [Inject] public ConsumeItemResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.ConsumeItemRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.ConsumeItem(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Returns the result of an evaluation of a Random Result Table - the ItemId from the game Catalog which would have been
/// added to the player inventory, if the Random Result Table were added via a Bundle or a call to UnlockContainer.
/// </summary>
public class EvaluateRandomResultTableCommand : Command
{
    [Inject] public EvaluateRandomResultTableResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.EvaluateRandomResultTableRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.EvaluateRandomResultTable(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the specified character's current inventory of virtual goods
/// </summary>
public class GetCharacterInventoryCommand : Command
{
    [Inject] public GetCharacterInventoryResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetCharacterInventoryRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetCharacterInventory(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the configuration information for the specified random results tables for the title, including all ItemId
/// values and weights
/// </summary>
public class GetRandomResultTablesCommand : Command
{
    [Inject] public GetRandomResultTablesResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetRandomResultTablesRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetRandomResultTables(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the specified user's current inventory of virtual goods
/// </summary>
public class GetUserInventoryCommand : Command
{
    [Inject] public GetUserInventoryResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetUserInventoryRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetUserInventory(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Adds the specified items to the specified character's inventory
/// </summary>
public class GrantItemsToCharacterCommand : Command
{
    [Inject] public GrantItemsToCharacterResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GrantItemsToCharacterRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GrantItemsToCharacter(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Adds the specified items to the specified user's inventory
/// </summary>
public class GrantItemsToUserCommand : Command
{
    [Inject] public GrantItemsToUserResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GrantItemsToUserRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GrantItemsToUser(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Adds the specified items to the specified user inventories
/// </summary>
public class GrantItemsToUsersCommand : Command
{
    [Inject] public GrantItemsToUsersResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GrantItemsToUsersRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GrantItemsToUsers(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Modifies the number of remaining uses of a player's inventory item
/// </summary>
public class ModifyItemUsesCommand : Command
{
    [Inject] public ModifyItemUsesResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.ModifyItemUsesRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.ModifyItemUses(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Moves an item from a character's inventory into another of the users's character's inventory.
/// </summary>
public class MoveItemToCharacterFromCharacterCommand : Command
{
    [Inject] public MoveItemToCharacterFromCharacterResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.MoveItemToCharacterFromCharacterRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.MoveItemToCharacterFromCharacter(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Moves an item from a user's inventory into their character's inventory.
/// </summary>
public class MoveItemToCharacterFromUserCommand : Command
{
    [Inject] public MoveItemToCharacterFromUserResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.MoveItemToCharacterFromUserRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.MoveItemToCharacterFromUser(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Moves an item from a character's inventory into the owning user's inventory.
/// </summary>
public class MoveItemToUserFromCharacterCommand : Command
{
    [Inject] public MoveItemToUserFromCharacterResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.MoveItemToUserFromCharacterRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.MoveItemToUserFromCharacter(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated  via the
/// Economy->Catalogs tab in the PlayFab Game Manager.
/// </summary>
public class RedeemCouponCommand : Command
{
    [Inject] public RedeemCouponResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.RedeemCouponRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.RedeemCoupon(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Submit a report about a player (due to bad bahavior, etc.) on behalf of another player, so that customer service
/// representatives for the title can take action concerning potentially toxic players.
/// </summary>
public class ReportPlayerCommand : Command
{
    [Inject] public ReportPlayerResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.ReportPlayerServerRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.ReportPlayer(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Revokes access to an item in a user's inventory
/// </summary>
public class RevokeInventoryItemCommand : Command
{
    [Inject] public RevokeInventoryItemResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.RevokeInventoryItemRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.RevokeInventoryItem(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Decrements the character's balance of the specified virtual currency by the stated amount. It is possible to make a VC
/// balance negative with this API.
/// </summary>
public class SubtractCharacterVirtualCurrencyCommand : Command
{
    [Inject] public SubtractCharacterVirtualCurrencyResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.SubtractCharacterVirtualCurrencyRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.SubtractCharacterVirtualCurrency(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Decrements the user's balance of the specified virtual currency by the stated amount. It is possible to make a VC
/// balance negative with this API.
/// </summary>
public class SubtractUserVirtualCurrencyCommand : Command
{
    [Inject] public SubtractUserVirtualCurrencyResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.SubtractUserVirtualCurrencyRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.SubtractUserVirtualCurrency(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Opens a specific container (ContainerItemInstanceId), with a specific key (KeyItemInstanceId, when required), and
/// returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses >
/// 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
/// </summary>
public class UnlockContainerInstanceCommand : Command
{
    [Inject] public UnlockContainerInstanceResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.UnlockContainerInstanceRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.UnlockContainerInstance(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Searches Player or Character inventory for any ItemInstance matching the given CatalogItemId, if necessary unlocks it
/// using any appropriate key, and returns the contents of the opened container. If the container (and key when relevant)
/// are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of
/// ConsumeItem.
/// </summary>
public class UnlockContainerItemCommand : Command
{
    [Inject] public UnlockContainerItemResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.UnlockContainerItemRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.UnlockContainerItem(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Updates the key-value pair data tagged to the specified item, which is read-only from the client.
/// </summary>
public class UpdateUserInventoryItemCustomDataCommand : Command
{
    [Inject] public UpdateUserInventoryItemCustomDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.UpdateUserInventoryItemDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.UpdateUserInventoryItemCustomData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}
#endregion

#region PlayStream

/// <summary>
/// Adds a given tag to a player profile. The tag's namespace is automatically generated based on the source of the tag.
/// </summary>
public class AddPlayerTagCommand : Command
{
    [Inject] public AddPlayerTagResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.AddPlayerTagRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.AddPlayerTag(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves an array of player segment definitions. Results from this can be used in subsequent API calls such as
/// GetPlayersInSegment which requires a Segment ID. While segment names can change the ID for that segment will not change.
/// </summary>
public class GetAllSegmentsCommand : Command
{
    [Inject] public GetAllSegmentsResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetAllSegmentsRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetAllSegments(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// List all segments that a player currently belongs to at this moment in time.
/// </summary>
public class GetPlayerSegmentsCommand : Command
{
    [Inject] public GetPlayerSegmentsResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetPlayersSegmentsRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetPlayerSegments(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Allows for paging through all players in a given segment. This API creates a snapshot of all player profiles that match
/// the segment definition at the time of its creation and lives through the Total Seconds to Live, refreshing its life span
/// on each subsequent use of the Continuation Token. Profiles that change during the course of paging will not be reflected
/// in the results. AB Test segments are currently not supported by this operation.
/// </summary>
public class GetPlayersInSegmentCommand : Command
{
    [Inject] public GetPlayersInSegmentResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetPlayersInSegmentRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetPlayersInSegment(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Get all tags with a given Namespace (optional) from a player profile.
/// </summary>
public class GetPlayerTagsCommand : Command
{
    [Inject] public GetPlayerTagsResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetPlayerTagsRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetPlayerTags(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Remove a given tag from a player profile. The tag's namespace is automatically generated based on the source of the tag.
/// </summary>
public class RemovePlayerTagCommand : Command
{
    [Inject] public RemovePlayerTagResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.RemovePlayerTagRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.RemovePlayerTag(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}
#endregion

#region Server-Side Cloud Script

/// <summary>
/// Executes a CloudScript function, with the 'currentPlayerId' variable set to the specified PlayFabId parameter value.
/// </summary>
public class ExecuteCloudScriptCommand : Command
{
    [Inject] public ExecuteCloudScriptResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.ExecuteCloudScriptServerRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.ExecuteCloudScript(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}
#endregion

#region Shared Group Data

/// <summary>
/// Adds users to the set of those able to update both the shared data, as well as the set of users  in the group. Only
/// users in the group (and the server) can add new members. Shared Groups are designed for sharing data  between a very
/// small number of players, please see our guide: https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class AddSharedGroupMembersCommand : Command
{
    [Inject] public AddSharedGroupMembersResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.AddSharedGroupMembersRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.AddSharedGroupMembers(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Requests the creation of a shared group object, containing key/value pairs which may  be updated by all members of the
/// group. When created by a server, the group will initially have no members.  Shared Groups are designed for sharing data
/// between a very small number of players, please see our guide:
/// https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class CreateSharedGroupCommand : Command
{
    [Inject] public CreateSharedGroupResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.CreateSharedGroupRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.CreateSharedGroup(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Deletes a shared group, freeing up the shared group ID to be reused for a new group.  Shared Groups are designed for
/// sharing data between a very small number of players, please see our guide:
/// https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class DeleteSharedGroupCommand : Command
{
    [Inject] public DeleteSharedGroupResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.DeleteSharedGroupRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.DeleteSharedGroup(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves data stored in a shared group object, as well as the list of members in the group.  The server can access all
/// public and private group data. Shared Groups are designed for sharing data between a very  small number of players,
/// please see our guide: https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class GetSharedGroupDataCommand : Command
{
    [Inject] public GetSharedGroupDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetSharedGroupDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetSharedGroupData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the
/// group can remove members. If as a result of the call, zero users remain with access, the group and its associated data
/// will be deleted. Shared Groups are designed for sharing data between a very small number of players,  please see our
/// guide: https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class RemoveSharedGroupMembersCommand : Command
{
    [Inject] public RemoveSharedGroupMembersResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.RemoveSharedGroupMembersRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.RemoveSharedGroupMembers(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated
/// or added in this call will be readable by users not in the group. By default, data permissions are set to Private.
/// Regardless of the permission setting, only members of the group (and the server) can update the data.  Shared Groups are
/// designed for sharing data between a very small number of players, please see our guide:
/// https://api.playfab.com/docs/tutorials/landing-players/shared-groups
/// </summary>
public class UpdateSharedGroupDataCommand : Command
{
    [Inject] public UpdateSharedGroupDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.UpdateSharedGroupDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.UpdateSharedGroupData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}
#endregion

#region Title-Wide Data Management

/// <summary>
/// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
/// </summary>
public class GetCatalogItemsCommand : Command
{
    [Inject] public GetCatalogItemsResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetCatalogItemsRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetCatalogItems(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the key-value store of custom publisher settings
/// </summary>
public class GetPublisherDataCommand : Command
{
    [Inject] public GetPublisherDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetPublisherDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetPublisherData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the current server time
/// </summary>
public class GetTimeCommand : Command
{
    [Inject] public GetTimeResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetTimeRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetTime(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the key-value store of custom title settings
/// </summary>
public class GetTitleDataCommand : Command
{
    [Inject] public GetTitleDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetTitleDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetTitleData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the key-value store of custom internal title settings
/// </summary>
public class GetTitleInternalDataCommand : Command
{
    [Inject] public GetTitleInternalDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetTitleDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetTitleInternalData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Retrieves the title news feed, as configured in the developer portal
/// </summary>
public class GetTitleNewsCommand : Command
{
    [Inject] public GetTitleNewsResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.GetTitleNewsRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.GetTitleNews(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Updates the key-value store of custom publisher settings
/// </summary>
public class SetPublisherDataCommand : Command
{
    [Inject] public SetPublisherDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.SetPublisherDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.SetPublisherData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Updates the key-value store of custom title settings
/// </summary>
public class SetTitleDataCommand : Command
{
    [Inject] public SetTitleDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.SetTitleDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.SetTitleData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

/// <summary>
/// Updates the key-value store of custom title settings
/// </summary>
public class SetTitleInternalDataCommand : Command
{
    [Inject] public SetTitleInternalDataResponseSignal ResponseSignal { get; set; }
    [Inject] public PlayFab.ServerModels.SetTitleDataRequest Request { get; set; }
    public override void Execute()
    {
        Retain();
        PlayFabServerAPI.SetTitleInternalData(Request, (result) =>
        {
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}
#endregion

