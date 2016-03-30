using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;

public class PlayFabContext : MVCSContext
{
    public PlayFabContextMediator playFabContext;

    public PlayFabContext(MonoBehaviour ctxView, bool autoMap) : base(ctxView, autoMap)
    {
        playFabContext = (PlayFabContextMediator)ctxView;
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    protected override void mapBindings()
    {

        //Bind Signals Cross Context
        //Matchmaking APIs
        #region Matchmaking APIs
        injectionBinder.Bind<AuthUserSignal>().CrossContext();
        injectionBinder.Bind<AuthUserResponseSignal>().CrossContext();
        injectionBinder.Bind<PlayerJoinedSignal>().CrossContext();
        injectionBinder.Bind<PlayerJoinedResponseSignal>().CrossContext();
        injectionBinder.Bind<PlayerLeftSignal>().CrossContext();
        injectionBinder.Bind<PlayerLeftResponseSignal>().CrossContext();
        injectionBinder.Bind<StartGameSignal>().CrossContext();
        injectionBinder.Bind<StartGameResponseSignal>().CrossContext();
        injectionBinder.Bind<UserInfoSignal>().CrossContext();
        injectionBinder.Bind<UserInfoResponseSignal>().CrossContext();
        #endregion
        //Authentication
        #region Authentication
        injectionBinder.Bind<AuthenticateSessionTicketSignal>().CrossContext();
        injectionBinder.Bind<AuthenticateSessionTicketResponseSignal>().CrossContext();
        #endregion
        //Account Management
        #region Account Management
        injectionBinder.Bind<GetPlayFabIDsFromFacebookIDsSignal>().CrossContext();
        injectionBinder.Bind<GetPlayFabIDsFromFacebookIDsResponseSignal>().CrossContext();
        injectionBinder.Bind<GetPlayFabIDsFromSteamIDsSignal>().CrossContext();
        injectionBinder.Bind<GetPlayFabIDsFromSteamIDsResponseSignal>().CrossContext();
        injectionBinder.Bind<GetUserAccountInfoSignal>().CrossContext();
        injectionBinder.Bind<GetUserAccountInfoResponseSignal>().CrossContext();
        injectionBinder.Bind<SendPushNotificationSignal>().CrossContext();
        injectionBinder.Bind<SendPushNotificationResponseSignal>().CrossContext();
        #endregion
        //Player Data Management
        #region Player Data Management
        injectionBinder.Bind<DeleteUsersSignal>().CrossContext();
        injectionBinder.Bind<DeleteUsersResponseSignal>().CrossContext();
        injectionBinder.Bind<GetLeaderboardSignal>().CrossContext();
        injectionBinder.Bind<GetLeaderboardResponseSignal>().CrossContext();
        injectionBinder.Bind<GetLeaderboardAroundUserSignal>().CrossContext();
        injectionBinder.Bind<GetLeaderboardAroundUserResponseSignal>().CrossContext();
        injectionBinder.Bind<GetPlayerStatisticsSignal>().CrossContext();
        injectionBinder.Bind<GetPlayerStatisticsResponseSignal>().CrossContext();
        injectionBinder.Bind<GetPlayerStatisticVersionsSignal>().CrossContext();
        injectionBinder.Bind<GetPlayerStatisticVersionsResponseSignal>().CrossContext();
        injectionBinder.Bind<GetUserDataSignal>().CrossContext();
        injectionBinder.Bind<GetUserDataResponseSignal>().CrossContext();
        injectionBinder.Bind<GetUserInternalDataSignal>().CrossContext();
        injectionBinder.Bind<GetUserInternalDataResponseSignal>().CrossContext();
        injectionBinder.Bind<GetUserPublisherDataSignal>().CrossContext();
        injectionBinder.Bind<GetUserPublisherDataResponseSignal>().CrossContext();
        injectionBinder.Bind<GetUserPublisherInternalDataSignal>().CrossContext();
        injectionBinder.Bind<GetUserPublisherInternalDataResponseSignal>().CrossContext();
        injectionBinder.Bind<GetUserPublisherReadOnlyDataSignal>().CrossContext();
        injectionBinder.Bind<GetUserPublisherReadOnlyDataResponseSignal>().CrossContext();
        injectionBinder.Bind<GetUserReadOnlyDataSignal>().CrossContext();
        injectionBinder.Bind<GetUserReadOnlyDataResponseSignal>().CrossContext();
        injectionBinder.Bind<GetUserStatisticsSignal>().CrossContext();
        injectionBinder.Bind<GetUserStatisticsResponseSignal>().CrossContext();
        injectionBinder.Bind<UpdatePlayerStatisticsSignal>().CrossContext();
        injectionBinder.Bind<UpdatePlayerStatisticsResponseSignal>().CrossContext();
        injectionBinder.Bind<UpdateUserDataSignal>().CrossContext();
        injectionBinder.Bind<UpdateUserDataResponseSignal>().CrossContext();
        injectionBinder.Bind<UpdateUserInternalDataSignal>().CrossContext();
        injectionBinder.Bind<UpdateUserInternalDataResponseSignal>().CrossContext();
        injectionBinder.Bind<UpdateUserPublisherDataSignal>().CrossContext();
        injectionBinder.Bind<UpdateUserPublisherDataResponseSignal>().CrossContext();
        injectionBinder.Bind<UpdateUserPublisherInternalDataSignal>().CrossContext();
        injectionBinder.Bind<UpdateUserPublisherInternalDataResponseSignal>().CrossContext();
        injectionBinder.Bind<UpdateUserPublisherReadOnlyDataSignal>().CrossContext();
        injectionBinder.Bind<UpdateUserPublisherReadOnlyDataResponseSignal>().CrossContext();
        injectionBinder.Bind<UpdateUserReadOnlyDataSignal>().CrossContext();
        injectionBinder.Bind<UpdateUserReadOnlyDataResponseSignal>().CrossContext();
        injectionBinder.Bind<UpdateUserStatisticsSignal>().CrossContext();
        injectionBinder.Bind<UpdateUserStatisticsResponseSignal>().CrossContext();
        #endregion
        //Title-Wide Data Management
        #region Title-Wide Data Management
        injectionBinder.Bind<GetCatalogItemsSignal>().CrossContext();
        injectionBinder.Bind<GetCatalogItemsResponseSignal>().CrossContext();
        injectionBinder.Bind<GetTitleDataSignal>().CrossContext();
        injectionBinder.Bind<GetTitleDataResponseSignal>().CrossContext();
        injectionBinder.Bind<GetTitleInternalDataSignal>().CrossContext();
        injectionBinder.Bind<GetTitleInternalDataResponseSignal>().CrossContext();
        injectionBinder.Bind<GetTitleNewsSignal>().CrossContext();
        injectionBinder.Bind<GetTitleNewsResponseSignal>().CrossContext();
        injectionBinder.Bind<SetTitleDataSignal>().CrossContext();
        injectionBinder.Bind<SetTitleDataResponseSignal>().CrossContext();
        injectionBinder.Bind<SetTitleInternalDataSignal>().CrossContext();
        injectionBinder.Bind<SetTitleInternalDataResponseSignal>().CrossContext();
        #endregion
        //Player Item Management
        #region Player Item Management
        injectionBinder.Bind<AddCharacterVirtualCurrencySignal>().CrossContext();
        injectionBinder.Bind<AddCharacterVirtualCurrencyResponseSignal>().CrossContext();
        injectionBinder.Bind<AddUserVirtualCurrencySignal>().CrossContext();
        injectionBinder.Bind<AddUserVirtualCurrencyResponseSignal>().CrossContext();
        injectionBinder.Bind<ConsumeItemSignal>().CrossContext();
        injectionBinder.Bind<ConsumeItemResponseSignal>().CrossContext();
        injectionBinder.Bind<GetCharacterInventorySignal>().CrossContext();
        injectionBinder.Bind<GetCharacterInventoryResponseSignal>().CrossContext();
        injectionBinder.Bind<GetUserInventorySignal>().CrossContext();
        injectionBinder.Bind<GetUserInventoryResponseSignal>().CrossContext();
        injectionBinder.Bind<GrantItemsToCharacterSignal>().CrossContext();
        injectionBinder.Bind<GrantItemsToCharacterResponseSignal>().CrossContext();
        injectionBinder.Bind<GrantItemsToUserSignal>().CrossContext();
        injectionBinder.Bind<GrantItemsToUserResponseSignal>().CrossContext();
        injectionBinder.Bind<GrantItemsToUsersSignal>().CrossContext();
        injectionBinder.Bind<GrantItemsToUsersResponseSignal>().CrossContext();
        injectionBinder.Bind<ModifyItemUsesSignal>().CrossContext();
        injectionBinder.Bind<ModifyItemUsesResponseSignal>().CrossContext();
        injectionBinder.Bind<MoveItemToCharacterFromCharacterSignal>().CrossContext();
        injectionBinder.Bind<MoveItemToCharacterFromCharacterResponseSignal>().CrossContext();
        injectionBinder.Bind<MoveItemToCharacterFromUserSignal>().CrossContext();
        injectionBinder.Bind<MoveItemToCharacterFromUserResponseSignal>().CrossContext();
        injectionBinder.Bind<MoveItemToUserFromCharacterSignal>().CrossContext();
        injectionBinder.Bind<MoveItemToUserFromCharacterResponseSignal>().CrossContext();
        injectionBinder.Bind<RedeemCouponSignal>().CrossContext();
        injectionBinder.Bind<RedeemCouponResponseSignal>().CrossContext();
        injectionBinder.Bind<ReportPlayerSignal>().CrossContext();
        injectionBinder.Bind<ReportPlayerResponseSignal>().CrossContext();
        injectionBinder.Bind<RevokeInventoryItemSignal>().CrossContext();
        injectionBinder.Bind<RevokeInventoryItemResponseSignal>().CrossContext();
        injectionBinder.Bind<SubtractCharacterVirtualCurrencySignal>().CrossContext();
        injectionBinder.Bind<SubtractCharacterVirtualCurrencyResponseSignal>().CrossContext();
        injectionBinder.Bind<SubtractUserVirtualCurrencySignal>().CrossContext();
        injectionBinder.Bind<SubtractUserVirtualCurrencyResponseSignal>().CrossContext();
        injectionBinder.Bind<UnlockContainerInstanceSignal>().CrossContext();
        injectionBinder.Bind<UnlockContainerInstanceResponseSignal>().CrossContext();
        injectionBinder.Bind<UnlockContainerItemSignal>().CrossContext();
        injectionBinder.Bind<UnlockContainerItemResponseSignal>().CrossContext();
        injectionBinder.Bind<UpdateUserInventoryItemCustomDataSignal>().CrossContext();
        injectionBinder.Bind<UpdateUserInventoryItemCustomDataResponseSignal>().CrossContext();
        #endregion
        //Friend List Management
        #region Friend List Management
        #endregion
        //Matchmaking APIs
        #region Matchmaking APIs
        injectionBinder.Bind<NotifyMatchmakerPlayerLeftSignal>().CrossContext();
        injectionBinder.Bind<NotifyMatchmakerPlayerLeftResponseSignal>().CrossContext();
        injectionBinder.Bind<RedeemMatchmakerTicketSignal>().CrossContext();
        injectionBinder.Bind<RedeemMatchmakerTicketResponseSignal>().CrossContext();
        #endregion
        //Steam-Specific APIs
        #region Steam-Specific APIs
        injectionBinder.Bind<AwardSteamAchievementSignal>().CrossContext();
        injectionBinder.Bind<AwardSteamAchievementResponseSignal>().CrossContext();
        #endregion
        //Analytics
        #region Analytics
        injectionBinder.Bind<LogEventSignal>().CrossContext();
        injectionBinder.Bind<LogEventResponseSignal>().CrossContext();
        #endregion
        //Shared Group Data
        #region Shared Group Data
        injectionBinder.Bind<AddSharedGroupMembersSignal>().CrossContext();
        injectionBinder.Bind<AddSharedGroupMembersResponseSignal>().CrossContext();
        injectionBinder.Bind<CreateSharedGroupSignal>().CrossContext();
        injectionBinder.Bind<CreateSharedGroupResponseSignal>().CrossContext();
        injectionBinder.Bind<DeleteSharedGroupSignal>().CrossContext();
        injectionBinder.Bind<DeleteSharedGroupResponseSignal>().CrossContext();
        injectionBinder.Bind<GetPublisherDataSignal>().CrossContext();
        injectionBinder.Bind<GetPublisherDataResponseSignal>().CrossContext();
        injectionBinder.Bind<GetSharedGroupDataSignal>().CrossContext();
        injectionBinder.Bind<GetSharedGroupDataResponseSignal>().CrossContext();
        injectionBinder.Bind<RemoveSharedGroupMembersSignal>().CrossContext();
        injectionBinder.Bind<RemoveSharedGroupMembersResponseSignal>().CrossContext();
        injectionBinder.Bind<SetPublisherDataSignal>().CrossContext();
        injectionBinder.Bind<SetPublisherDataResponseSignal>().CrossContext();
        injectionBinder.Bind<UpdateSharedGroupDataSignal>().CrossContext();
        injectionBinder.Bind<UpdateSharedGroupDataResponseSignal>().CrossContext();
        #endregion
        //Server-Side Cloud Script
        #region Server-Side Cloud Script
        #endregion
        //Content
        #region Content
        injectionBinder.Bind<GetContentDownloadUrlSignal>().CrossContext();
        injectionBinder.Bind<GetContentDownloadUrlResponseSignal>().CrossContext();
        #endregion
        //Characters
        #region Characters
        injectionBinder.Bind<DeleteCharacterFromUserSignal>().CrossContext();
        injectionBinder.Bind<DeleteCharacterFromUserResponseSignal>().CrossContext();
        injectionBinder.Bind<GetAllUsersCharactersSignal>().CrossContext();
        injectionBinder.Bind<GetAllUsersCharactersResponseSignal>().CrossContext();
        injectionBinder.Bind<GetCharacterLeaderboardSignal>().CrossContext();
        injectionBinder.Bind<GetCharacterLeaderboardResponseSignal>().CrossContext();
        injectionBinder.Bind<GetCharacterStatisticsSignal>().CrossContext();
        injectionBinder.Bind<GetCharacterStatisticsResponseSignal>().CrossContext();
        injectionBinder.Bind<GetLeaderboardAroundCharacterSignal>().CrossContext();
        injectionBinder.Bind<GetLeaderboardAroundCharacterResponseSignal>().CrossContext();
        injectionBinder.Bind<GetLeaderboardForUserCharactersSignal>().CrossContext();
        injectionBinder.Bind<GetLeaderboardForUserCharactersResponseSignal>().CrossContext();
        injectionBinder.Bind<GrantCharacterToUserSignal>().CrossContext();
        injectionBinder.Bind<GrantCharacterToUserResponseSignal>().CrossContext();
        injectionBinder.Bind<UpdateCharacterStatisticsSignal>().CrossContext();
        injectionBinder.Bind<UpdateCharacterStatisticsResponseSignal>().CrossContext();
        #endregion
        //Character Data
        #region Character Data
        injectionBinder.Bind<GetCharacterDataSignal>().CrossContext();
        injectionBinder.Bind<GetCharacterDataResponseSignal>().CrossContext();
        injectionBinder.Bind<GetCharacterInternalDataSignal>().CrossContext();
        injectionBinder.Bind<GetCharacterInternalDataResponseSignal>().CrossContext();
        injectionBinder.Bind<GetCharacterReadOnlyDataSignal>().CrossContext();
        injectionBinder.Bind<GetCharacterReadOnlyDataResponseSignal>().CrossContext();
        injectionBinder.Bind<UpdateCharacterDataSignal>().CrossContext();
        injectionBinder.Bind<UpdateCharacterDataResponseSignal>().CrossContext();
        injectionBinder.Bind<UpdateCharacterInternalDataSignal>().CrossContext();
        injectionBinder.Bind<UpdateCharacterInternalDataResponseSignal>().CrossContext();
        injectionBinder.Bind<UpdateCharacterReadOnlyDataSignal>().CrossContext();
        injectionBinder.Bind<UpdateCharacterReadOnlyDataResponseSignal>().CrossContext();
        #endregion
        //Guilds
        #region Guilds
        #endregion
    }
}