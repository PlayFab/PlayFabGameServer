using PlayFab;
using PlayFab.MatchmakerModels;
using PlayFab.ServerModels;
using strange.extensions.command.impl;
using Object = UnityEngine.Object;





//Matchmaking APIs
#region Matchmaking APIs

///<summary>
///Validates a user with the PlayFab service
///</summary>
public class AuthUserCommand : Command {
    [Inject] public AuthUserResponseSignal ResponseSignal {get; set;}
    [Inject] public AuthUserRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabMatchmakerAPI.AuthUser(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Informs the PlayFab game server hosting service that the indicated user has joined the Game Server Instance specified
///</summary>
public class PlayerJoinedCommand : Command {
    [Inject] public PlayerJoinedResponseSignal ResponseSignal {get; set;}
    [Inject] public PlayerJoinedRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabMatchmakerAPI.PlayerJoined(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Informs the PlayFab game server hosting service that the indicated user has left the Game Server Instance specified
///</summary>
public class PlayerLeftCommand : Command {
    [Inject] public PlayerLeftResponseSignal ResponseSignal {get; set;}
    [Inject] public PlayerLeftRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabMatchmakerAPI.PlayerLeft(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Instructs the PlayFab game server hosting service to instantiate a new Game Server Instance
///</summary>
public class StartGameCommand : Command {
    [Inject] public StartGameResponseSignal ResponseSignal {get; set;}
    [Inject] public StartGameRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabMatchmakerAPI.StartGame(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the relevant details for a specified user, which the external match-making service can then use to compute effective matches
///</summary>
public class UserInfoCommand : Command {
    [Inject] public UserInfoResponseSignal ResponseSignal {get; set;}
    [Inject] public UserInfoRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabMatchmakerAPI.UserInfo(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

#endregion





//Authentication
#region Authentication

///<summary>
///Validated a client's session ticket, and if successful, returns details for that user
///</summary>
public class AuthenticateSessionTicketCommand : Command {
    [Inject] public AuthenticateSessionTicketResponseSignal ResponseSignal {get; set;}
    [Inject] public AuthenticateSessionTicketRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.AuthenticateSessionTicket(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

#endregion
//Account Management
#region Account Management

///<summary>
///Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
///</summary>
public class GetPlayFabIDsFromFacebookIDsCommand : Command {
    [Inject] public GetPlayFabIDsFromFacebookIDsResponseSignal ResponseSignal {get; set;}
    [Inject] public GetPlayFabIDsFromFacebookIDsRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetPlayFabIDsFromFacebookIDs(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers  are the profile IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
///</summary>
public class GetPlayFabIDsFromSteamIDsCommand : Command {
    [Inject] public GetPlayFabIDsFromSteamIDsResponseSignal ResponseSignal {get; set;}
    [Inject] public GetPlayFabIDsFromSteamIDsRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetPlayFabIDsFromSteamIDs(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the relevant details for a specified user
///</summary>
public class GetUserAccountInfoCommand : Command {
    [Inject] public GetUserAccountInfoResponseSignal ResponseSignal {get; set;}
    [Inject] public GetUserAccountInfoRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetUserAccountInfo(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured for Push Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
///</summary>
public class SendPushNotificationCommand : Command {
    [Inject] public SendPushNotificationResponseSignal ResponseSignal {get; set;}
    [Inject] public SendPushNotificationRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.SendPushNotification(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

#endregion
//Player Data Management
#region Player Data Management

///<summary>
///Deletes the users for the provided game. Deletes custom data, all account linkages, and statistics.
///</summary>
public class DeleteUsersCommand : Command {
    [Inject] public DeleteUsersResponseSignal ResponseSignal {get; set;}
    [Inject] public DeleteUsersRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.DeleteUsers(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
///</summary>
public class GetLeaderboardCommand : Command {
    [Inject] public GetLeaderboardResponseSignal ResponseSignal {get; set;}
    [Inject] public GetLeaderboardRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetLeaderboard(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
///</summary>
public class GetLeaderboardAroundUserCommand : Command {
    [Inject] public GetLeaderboardAroundUserResponseSignal ResponseSignal {get; set;}
    [Inject] public GetLeaderboardAroundUserRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetLeaderboardAroundUser(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the current version and values for the indicated statistics, for the local player.
///</summary>
public class GetPlayerStatisticsCommand : Command {
    [Inject] public GetPlayerStatisticsResponseSignal ResponseSignal {get; set;}
    [Inject] public GetPlayerStatisticsRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetPlayerStatistics(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the information on the available versions of the specified statistic.
///</summary>
public class GetPlayerStatisticVersionsCommand : Command {
    [Inject] public GetPlayerStatisticVersionsResponseSignal ResponseSignal {get; set;}
    [Inject] public GetPlayerStatisticVersionsRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetPlayerStatisticVersions(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the title-specific custom data for the user which is readable and writable by the client
///</summary>
public class GetUserDataCommand : Command {
    [Inject] public GetUserDataResponseSignal ResponseSignal {get; set;}
    [Inject] public GetUserDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetUserData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the title-specific custom data for the user which cannot be accessed by the client
///</summary>
public class GetUserInternalDataCommand : Command {
    [Inject] public GetUserInternalDataResponseSignal ResponseSignal {get; set;}
    [Inject] public GetUserDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetUserInternalData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the publisher-specific custom data for the user which is readable and writable by the client
///</summary>
public class GetUserPublisherDataCommand : Command {
    [Inject] public GetUserPublisherDataResponseSignal ResponseSignal {get; set;}
    [Inject] public GetUserDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetUserPublisherData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
///</summary>
public class GetUserPublisherInternalDataCommand : Command {
    [Inject] public GetUserPublisherInternalDataResponseSignal ResponseSignal {get; set;}
    [Inject] public GetUserDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetUserPublisherInternalData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the publisher-specific custom data for the user which can only be read by the client
///</summary>
public class GetUserPublisherReadOnlyDataCommand : Command {
    [Inject] public GetUserPublisherReadOnlyDataResponseSignal ResponseSignal {get; set;}
    [Inject] public GetUserDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetUserPublisherReadOnlyData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the title-specific custom data for the user which can only be read by the client
///</summary>
public class GetUserReadOnlyDataCommand : Command {
    [Inject] public GetUserReadOnlyDataResponseSignal ResponseSignal {get; set;}
    [Inject] public GetUserDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetUserReadOnlyData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the details of all title-specific statistics for the user
///</summary>
public class GetUserStatisticsCommand : Command {
    [Inject] public GetUserStatisticsResponseSignal ResponseSignal {get; set;}
    [Inject] public GetUserStatisticsRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetUserStatistics(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Updates the values of the specified title-specific statistics for the user
///</summary>
public class UpdatePlayerStatisticsCommand : Command {
    [Inject] public UpdatePlayerStatisticsResponseSignal ResponseSignal {get; set;}
    [Inject] public UpdatePlayerStatisticsRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.UpdatePlayerStatistics(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Updates the title-specific custom data for the user which is readable and writable by the client
///</summary>
public class UpdateUserDataCommand : Command {
    [Inject] public UpdateUserDataResponseSignal ResponseSignal {get; set;}
    [Inject] public UpdateUserDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.UpdateUserData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Updates the title-specific custom data for the user which cannot be accessed by the client
///</summary>
public class UpdateUserInternalDataCommand : Command {
    [Inject] public UpdateUserInternalDataResponseSignal ResponseSignal {get; set;}
    [Inject] public UpdateUserInternalDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.UpdateUserInternalData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Updates the publisher-specific custom data for the user which is readable and writable by the client
///</summary>
public class UpdateUserPublisherDataCommand : Command {
    [Inject] public UpdateUserPublisherDataResponseSignal ResponseSignal {get; set;}
    [Inject] public UpdateUserDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.UpdateUserPublisherData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Updates the publisher-specific custom data for the user which cannot be accessed by the client
///</summary>
public class UpdateUserPublisherInternalDataCommand : Command {
    [Inject] public UpdateUserPublisherInternalDataResponseSignal ResponseSignal {get; set;}
    [Inject] public UpdateUserInternalDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.UpdateUserPublisherInternalData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Updates the publisher-specific custom data for the user which can only be read by the client
///</summary>
public class UpdateUserPublisherReadOnlyDataCommand : Command {
    [Inject] public UpdateUserPublisherReadOnlyDataResponseSignal ResponseSignal {get; set;}
    [Inject] public UpdateUserDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.UpdateUserPublisherReadOnlyData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Updates the title-specific custom data for the user which can only be read by the client
///</summary>
public class UpdateUserReadOnlyDataCommand : Command {
    [Inject] public UpdateUserReadOnlyDataResponseSignal ResponseSignal {get; set;}
    [Inject] public UpdateUserDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.UpdateUserReadOnlyData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Updates the values of the specified title-specific statistics for the user
///</summary>
public class UpdateUserStatisticsCommand : Command {
    [Inject] public UpdateUserStatisticsResponseSignal ResponseSignal {get; set;}
    [Inject] public UpdateUserStatisticsRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.UpdateUserStatistics(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

#endregion
//Title-Wide Data Management
#region Title-Wide Data Management

///<summary>
///Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
///</summary>
public class GetCatalogItemsCommand : Command {
    [Inject] public GetCatalogItemsResponseSignal ResponseSignal {get; set;}
    [Inject] public GetCatalogItemsRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetCatalogItems(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the key-value store of custom title settings
///</summary>
public class GetTitleDataCommand : Command {
    [Inject] public GetTitleDataResponseSignal ResponseSignal {get; set;}
    [Inject] public GetTitleDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetTitleData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the key-value store of custom internal title settings
///</summary>
public class GetTitleInternalDataCommand : Command {
    [Inject] public GetTitleInternalDataResponseSignal ResponseSignal {get; set;}
    [Inject] public GetTitleDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetTitleInternalData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the title news feed, as configured in the developer portal
///</summary>
public class GetTitleNewsCommand : Command {
    [Inject] public GetTitleNewsResponseSignal ResponseSignal {get; set;}
    [Inject] public GetTitleNewsRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetTitleNews(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Updates the key-value store of custom title settings
///</summary>
public class SetTitleDataCommand : Command {
    [Inject] public SetTitleDataResponseSignal ResponseSignal {get; set;}
    [Inject] public SetTitleDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.SetTitleData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Updates the key-value store of custom title settings
///</summary>
public class SetTitleInternalDataCommand : Command {
    [Inject] public SetTitleInternalDataResponseSignal ResponseSignal {get; set;}
    [Inject] public SetTitleDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.SetTitleInternalData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

#endregion
//Player Item Management
#region Player Item Management

///<summary>
///Increments  the character's balance of the specified virtual currency by the stated amount
///</summary>
public class AddCharacterVirtualCurrencyCommand : Command {
    [Inject] public AddCharacterVirtualCurrencyResponseSignal ResponseSignal {get; set;}
    [Inject] public AddCharacterVirtualCurrencyRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.AddCharacterVirtualCurrency(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Increments  the user's balance of the specified virtual currency by the stated amount
///</summary>
public class AddUserVirtualCurrencyCommand : Command {
    [Inject] public AddUserVirtualCurrencyResponseSignal ResponseSignal {get; set;}
    [Inject] public AddUserVirtualCurrencyRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.AddUserVirtualCurrency(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's inventory.
///</summary>
public class ConsumeItemCommand : Command {
    [Inject] public ConsumeItemResponseSignal ResponseSignal {get; set;}
    [Inject] public ConsumeItemRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.ConsumeItem(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the specified character's current inventory of virtual goods
///</summary>
public class GetCharacterInventoryCommand : Command {
    [Inject] public GetCharacterInventoryResponseSignal ResponseSignal {get; set;}
    [Inject] public GetCharacterInventoryRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetCharacterInventory(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the specified user's current inventory of virtual goods
///</summary>
public class GetUserInventoryCommand : Command {
    [Inject] public GetUserInventoryResponseSignal ResponseSignal {get; set;}
    [Inject] public GetUserInventoryRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetUserInventory(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Adds the specified items to the specified character's inventory
///</summary>
public class GrantItemsToCharacterCommand : Command {
    [Inject] public GrantItemsToCharacterResponseSignal ResponseSignal {get; set;}
    [Inject] public GrantItemsToCharacterRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GrantItemsToCharacter(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Adds the specified items to the specified user's inventory
///</summary>
public class GrantItemsToUserCommand : Command {
    [Inject] public GrantItemsToUserResponseSignal ResponseSignal {get; set;}
    [Inject] public GrantItemsToUserRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GrantItemsToUser(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Adds the specified items to the specified user inventories
///</summary>
public class GrantItemsToUsersCommand : Command {
    [Inject] public GrantItemsToUsersResponseSignal ResponseSignal {get; set;}
    [Inject] public GrantItemsToUsersRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GrantItemsToUsers(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Modifies the number of remaining uses of a player's inventory item
///</summary>
public class ModifyItemUsesCommand : Command {
    [Inject] public ModifyItemUsesResponseSignal ResponseSignal {get; set;}
    [Inject] public ModifyItemUsesRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.ModifyItemUses(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Moves an item from a character's inventory into another of the users's character's inventory.
///</summary>
public class MoveItemToCharacterFromCharacterCommand : Command {
    [Inject] public MoveItemToCharacterFromCharacterResponseSignal ResponseSignal {get; set;}
    [Inject] public MoveItemToCharacterFromCharacterRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.MoveItemToCharacterFromCharacter(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Moves an item from a user's inventory into their character's inventory.
///</summary>
public class MoveItemToCharacterFromUserCommand : Command {
    [Inject] public MoveItemToCharacterFromUserResponseSignal ResponseSignal {get; set;}
    [Inject] public MoveItemToCharacterFromUserRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.MoveItemToCharacterFromUser(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Moves an item from a character's inventory into the owning user's inventory.
///</summary>
public class MoveItemToUserFromCharacterCommand : Command {
    [Inject] public MoveItemToUserFromCharacterResponseSignal ResponseSignal {get; set;}
    [Inject] public MoveItemToUserFromCharacterRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.MoveItemToUserFromCharacter(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated  via the Promotions->Coupons tab in the PlayFab Game Manager. See this post for more information on coupons:  https://playfab.com/blog/2015/06/18/using-stores-and-coupons-game-manager
///</summary>
public class RedeemCouponCommand : Command {
    [Inject] public RedeemCouponResponseSignal ResponseSignal {get; set;}
    [Inject] public RedeemCouponRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.RedeemCoupon(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Submit a report about a player (due to bad bahavior, etc.) on behalf of another player, so that customer service representatives for the title can take action concerning potentially toxic players.
///</summary>
public class ReportPlayerCommand : Command {
    [Inject] public ReportPlayerResponseSignal ResponseSignal {get; set;}
    [Inject] public ReportPlayerServerRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.ReportPlayer(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Revokes access to an item in a user's inventory
///</summary>
public class RevokeInventoryItemCommand : Command {
    [Inject] public RevokeInventoryItemResponseSignal ResponseSignal {get; set;}
    [Inject] public RevokeInventoryItemRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.RevokeInventoryItem(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Decrements the character's balance of the specified virtual currency by the stated amount
///</summary>
public class SubtractCharacterVirtualCurrencyCommand : Command {
    [Inject] public SubtractCharacterVirtualCurrencyResponseSignal ResponseSignal {get; set;}
    [Inject] public SubtractCharacterVirtualCurrencyRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.SubtractCharacterVirtualCurrency(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Decrements the user's balance of the specified virtual currency by the stated amount
///</summary>
public class SubtractUserVirtualCurrencyCommand : Command {
    [Inject] public SubtractUserVirtualCurrencyResponseSignal ResponseSignal {get; set;}
    [Inject] public SubtractUserVirtualCurrencyRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.SubtractUserVirtualCurrency(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Opens a specific container (ContainerItemInstanceId), with a specific key (KeyItemInstanceId, when required), and returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
///</summary>
public class UnlockContainerInstanceCommand : Command {
    [Inject] public UnlockContainerInstanceResponseSignal ResponseSignal {get; set;}
    [Inject] public UnlockContainerInstanceRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.UnlockContainerInstance(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Searches Player or Character inventory for any ItemInstance matching the given CatalogItemId, if necessary unlocks it using any appropriate key, and returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
///</summary>
public class UnlockContainerItemCommand : Command {
    [Inject] public UnlockContainerItemResponseSignal ResponseSignal {get; set;}
    [Inject] public UnlockContainerItemRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.UnlockContainerItem(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Updates the key-value pair data tagged to the specified item, which is read-only from the client.
///</summary>
public class UpdateUserInventoryItemCustomDataCommand : Command {
    [Inject] public UpdateUserInventoryItemCustomDataResponseSignal ResponseSignal {get; set;}
    [Inject] public UpdateUserInventoryItemDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.UpdateUserInventoryItemCustomData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

#endregion
//Friend List Management
#region Friend List Management

#endregion
//Matchmaking APIs
#region Matchmaking APIs

///<summary>
///Informs the PlayFab match-making service that the user specified has left the Game Server Instance
///</summary>
public class NotifyMatchmakerPlayerLeftCommand : Command {
    [Inject] public NotifyMatchmakerPlayerLeftResponseSignal ResponseSignal {get; set;}
    [Inject] public NotifyMatchmakerPlayerLeftRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.NotifyMatchmakerPlayerLeft(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Validates a Game Server session ticket and returns details about the user
///</summary>
public class RedeemMatchmakerTicketCommand : Command {
    [Inject] public RedeemMatchmakerTicketResponseSignal ResponseSignal {get; set;}
    [Inject] public RedeemMatchmakerTicketRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.RedeemMatchmakerTicket(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

#endregion
//Steam-Specific APIs
#region Steam-Specific APIs

///<summary>
///Awards the specified users the specified Steam achievements
///</summary>
public class AwardSteamAchievementCommand : Command {
    [Inject] public AwardSteamAchievementResponseSignal ResponseSignal {get; set;}
    [Inject] public AwardSteamAchievementRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.AwardSteamAchievement(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

#endregion
//Analytics
#region Analytics

///<summary>
///Logs a custom analytics event
///</summary>
public class LogEventCommand : Command {
    [Inject] public LogEventResponseSignal ResponseSignal {get; set;}
    [Inject] public LogEventRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.LogEvent(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

#endregion
//Shared Group Data
#region Shared Group Data

///<summary>
///Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users in the group (and the server) can add new members.
///</summary>
public class AddSharedGroupMembersCommand : Command {
    [Inject] public AddSharedGroupMembersResponseSignal ResponseSignal {get; set;}
    [Inject] public AddSharedGroupMembersRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.AddSharedGroupMembers(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the group. When created by a server, the group will initially have no members.
///</summary>
public class CreateSharedGroupCommand : Command {
    [Inject] public CreateSharedGroupResponseSignal ResponseSignal {get; set;}
    [Inject] public CreateSharedGroupRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.CreateSharedGroup(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Deletes a shared group, freeing up the shared group ID to be reused for a new group
///</summary>
public class DeleteSharedGroupCommand : Command {
    [Inject] public DeleteSharedGroupResponseSignal ResponseSignal {get; set;}
    [Inject] public DeleteSharedGroupRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.DeleteSharedGroup(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the key-value store of custom publisher settings
///</summary>
public class GetPublisherDataCommand : Command {
    [Inject] public GetPublisherDataResponseSignal ResponseSignal {get; set;}
    [Inject] public GetPublisherDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetPublisherData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves data stored in a shared group object, as well as the list of members in the group. The server can access all public and private group data.
///</summary>
public class GetSharedGroupDataCommand : Command {
    [Inject] public GetSharedGroupDataResponseSignal ResponseSignal {get; set;}
    [Inject] public GetSharedGroupDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetSharedGroupData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the group can remove members. If as a result of the call, zero users remain with access, the group and its associated data will be deleted.
///</summary>
public class RemoveSharedGroupMembersCommand : Command {
    [Inject] public RemoveSharedGroupMembersResponseSignal ResponseSignal {get; set;}
    [Inject] public RemoveSharedGroupMembersRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.RemoveSharedGroupMembers(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Updates the key-value store of custom publisher settings
///</summary>
public class SetPublisherDataCommand : Command {
    [Inject] public SetPublisherDataResponseSignal ResponseSignal {get; set;}
    [Inject] public SetPublisherDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.SetPublisherData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated or added in this call will be readable by users not in the group. By default, data permissions are set to Private. Regardless of the permission setting, only members of the group (and the server) can update the data.
///</summary>
public class UpdateSharedGroupDataCommand : Command {
    [Inject] public UpdateSharedGroupDataResponseSignal ResponseSignal {get; set;}
    [Inject] public UpdateSharedGroupDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.UpdateSharedGroupData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

#endregion
//Server-Side Cloud Script
#region Server-Side Cloud Script

#endregion
//Content
#region Content

///<summary>
///This API retrieves a pre-signed URL for accessing a content file for the title. A subsequent  HTTP GET to the returned URL will attempt to download the content. A HEAD query to the returned URL will attempt to  retrieve the metadata of the content. Note that a successful result does not guarantee the existence of this content -  if it has not been uploaded, the query to retrieve the data will fail. See this post for more information:  https://community.playfab.com/hc/en-us/community/posts/205469488-How-to-upload-files-to-PlayFab-s-Content-Service
///</summary>
public class GetContentDownloadUrlCommand : Command {
    [Inject] public GetContentDownloadUrlResponseSignal ResponseSignal {get; set;}
    [Inject] public GetContentDownloadUrlRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetContentDownloadUrl(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

#endregion
//Characters
#region Characters

///<summary>
///Deletes the specific character ID from the specified user.
///</summary>
public class DeleteCharacterFromUserCommand : Command {
    [Inject] public DeleteCharacterFromUserResponseSignal ResponseSignal {get; set;}
    [Inject] public DeleteCharacterFromUserRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.DeleteCharacterFromUser(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Lists all of the characters that belong to a specific user.
///</summary>
public class GetAllUsersCharactersCommand : Command {
    [Inject] public GetAllUsersCharactersResponseSignal ResponseSignal {get; set;}
    [Inject] public ListUsersCharactersRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetAllUsersCharacters(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
///</summary>
public class GetCharacterLeaderboardCommand : Command {
    [Inject] public GetCharacterLeaderboardResponseSignal ResponseSignal {get; set;}
    [Inject] public GetCharacterLeaderboardRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetCharacterLeaderboard(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the details of all title-specific statistics for the specific character
///</summary>
public class GetCharacterStatisticsCommand : Command {
    [Inject] public GetCharacterStatisticsResponseSignal ResponseSignal {get; set;}
    [Inject] public GetCharacterStatisticsRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetCharacterStatistics(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves a list of ranked characters for the given statistic, centered on the requested user
///</summary>
public class GetLeaderboardAroundCharacterCommand : Command {
    [Inject] public GetLeaderboardAroundCharacterResponseSignal ResponseSignal {get; set;}
    [Inject] public GetLeaderboardAroundCharacterRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetLeaderboardAroundCharacter(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves a list of all of the user's characters for the given statistic.
///</summary>
public class GetLeaderboardForUserCharactersCommand : Command {
    [Inject] public GetLeaderboardForUserCharactersResponseSignal ResponseSignal {get; set;}
    [Inject] public GetLeaderboardForUsersCharactersRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetLeaderboardForUserCharacters(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Grants the specified character type to the user.
///</summary>
public class GrantCharacterToUserCommand : Command {
    [Inject] public GrantCharacterToUserResponseSignal ResponseSignal {get; set;}
    [Inject] public GrantCharacterToUserRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GrantCharacterToUser(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Updates the values of the specified title-specific statistics for the specific character
///</summary>
public class UpdateCharacterStatisticsCommand : Command {
    [Inject] public UpdateCharacterStatisticsResponseSignal ResponseSignal {get; set;}
    [Inject] public UpdateCharacterStatisticsRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.UpdateCharacterStatistics(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

#endregion
//Character Data
#region Character Data

///<summary>
///Retrieves the title-specific custom data for the user which is readable and writable by the client
///</summary>
public class GetCharacterDataCommand : Command {
    [Inject] public GetCharacterDataResponseSignal ResponseSignal {get; set;}
    [Inject] public GetCharacterDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetCharacterData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the title-specific custom data for the user's character which cannot be accessed by the client
///</summary>
public class GetCharacterInternalDataCommand : Command {
    [Inject] public GetCharacterInternalDataResponseSignal ResponseSignal {get; set;}
    [Inject] public GetCharacterDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetCharacterInternalData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Retrieves the title-specific custom data for the user's character which can only be read by the client
///</summary>
public class GetCharacterReadOnlyDataCommand : Command {
    [Inject] public GetCharacterReadOnlyDataResponseSignal ResponseSignal {get; set;}
    [Inject] public GetCharacterDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.GetCharacterReadOnlyData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Updates the title-specific custom data for the user's chjaracter which is readable and writable by the client
///</summary>
public class UpdateCharacterDataCommand : Command {
    [Inject] public UpdateCharacterDataResponseSignal ResponseSignal {get; set;}
    [Inject] public UpdateCharacterDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.UpdateCharacterData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Updates the title-specific custom data for the user's character which cannot  be accessed by the client
///</summary>
public class UpdateCharacterInternalDataCommand : Command {
    [Inject] public UpdateCharacterInternalDataResponseSignal ResponseSignal {get; set;}
    [Inject] public UpdateCharacterDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.UpdateCharacterInternalData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

///<summary>
///Updates the title-specific custom data for the user's character which can only be read by the client
///</summary>
public class UpdateCharacterReadOnlyDataCommand : Command {
    [Inject] public UpdateCharacterReadOnlyDataResponseSignal ResponseSignal {get; set;}
    [Inject] public UpdateCharacterDataRequest Request {get; set;}
    public override void Execute(){
        Retain();
        PlayFabServerAPI.UpdateCharacterReadOnlyData(Request,(result)=>{
            //TODO: Map Result data to PlayFabDataStore.
            Release();
            ResponseSignal.Dispatch(result);
        }, PlayFabErrorHandler.HandlePlayFabError);
    }
}

#endregion
//Guilds
#region Guilds

#endregion


