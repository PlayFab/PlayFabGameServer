using System;
using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;


public class CreateChannelSignal : Signal<CreateChannelMessage> { }
public class CreateChannelCommand : Command
{
    [Inject] public CreateChannelMessage Message { get; set; }
    public override void Execute()
    {
        
    }
}

public class JoinChannelSignal : Signal<JoinChannelMessage> { }

public class JoinChannelCommand : Command
{
    [Inject] public JoinChannelMessage Message { get; set; }
    public override void Execute()
    {
        
    }
}

public class LeaveChannelSignal : Signal<LeaveChannelMessage> { }

public class LeaveChannelCommand : Command
{
    [Inject] public LeaveChannelMessage Message { get; set; }
    public override void Execute()
    {

    }
}

public class SendMessageSignal : Signal<ChatMessage> { }

public class SendMessageCommand : Command
{
    [Inject] public ChatMessage Message { get; set; }
    public override void Execute()
    {
        
    }
}