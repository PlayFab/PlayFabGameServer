﻿using strange.extensions.command.api;
using strange.extensions.injector.api;
using strange.extensions.mediation.api;
using UnityEngine;

public class ChatServerManager : StrangePackage
{
    public override void MapBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
        //Bind chatServerData Object
        var chatServerData = Object.FindObjectOfType<ChatServerData>();
        injectionBinder.Bind<ChatServerData>().To(chatServerData).ToSingleton().CrossContext();

        //Bind Mediators to Views
        mediationBinder.Bind<ChatServerListenerView>().To<ChatServerListener>();

        commandBinder.Bind<CreateChannelSignal>().To<CreateChannelCommand>();
        commandBinder.Bind<JoinChannelSignal>().To<JoinChannelCommand>();
        commandBinder.Bind<LeaveChannelSignal>().To<LeaveChannelCommand>();
        commandBinder.Bind<SendMessageSignal>().To<SendMessageCommand>();
        commandBinder.Bind<SendJoinedReponseSignal>().To<SendJoinedReponseCommand>();
        commandBinder.Bind<SendCreateChannelReponseSignal>().To<SendCreateChannelReponseCommand>();
    }

    public override void PostBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
        
    }
}