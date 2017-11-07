﻿using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab.Internal;
using PlayFab.ServerModels;
using UnityEngine;
using strange.extensions.mediation.impl;
using UnityEngine.Networking;

public class NewPromoExampleMediator : Mediator {

    [Inject] public NewPromoExampleView View { get; set; }
    [Inject] public UnityNetworkingData UnityNetworkingData { get; set; }
    [Inject] public LogSignal Logger { get; set; }

    private List<TitleNewsItem> _titleNews = new List<TitleNewsItem>();
    private float _time;
    private bool firstTimeCheck = true;

    public class TitleNewsItemMessage : MessageBase
    {
        public DateTime Timestamp;
        public string NewsId;
        public string Title;
        public string Body;
        public override void Serialize(NetworkWriter writer)
        {
            var json = PlayFab.Json.JsonWrapper.SerializeObject(Timestamp, PlayFab.Json.SimpleJsonInstance.ApiSerializerStrategy);
            writer.Write(json);
            writer.Write(NewsId);
            writer.Write(Title);
            writer.Write(Body);
        }

        public override void Deserialize(NetworkReader reader)
        {
            Timestamp = PlayFab.Json.JsonWrapper.DeserializeObject<DateTime>(reader.ReadString());
            NewsId = reader.ReadString();
            Title = reader.ReadString();
            Body = reader.ReadString();
        }
    }


    public override void OnRegister()
    {
        Logger.Dispatch(LoggerTypes.Info, "Populating Title News");
        CheckForPromo();
    }

    private void CheckForPromo()
    {
        PlayFab.PlayFabServerAPI.GetTitleNews(new GetTitleNewsRequest() { Count = 10 }, (result) =>
        {
            if (firstTimeCheck)
            {
                _titleNews = result.News;
                firstTimeCheck = false;
                return;
            }

            foreach (var newsItem in result.News)
            {
                var foundItem = _titleNews.Find(tn => tn.NewsId == newsItem.NewsId);
                if (foundItem != null)
                {
                    continue;
                }
                NotifyClients(newsItem);
                _titleNews.Add(newsItem);
            }

        }, null);

        firstTimeCheck = false;
    }

    private void NotifyClients(TitleNewsItem newsItem)
    {
        foreach (var uconn in UnityNetworkingData.Connections)
        {
            Logger.Dispatch(LoggerTypes.Info, string.Format("Sending Title News to client {0}", uconn.ConnectionId ));
            uconn.Connection.Send(1010, new TitleNewsItemMessage
            {
                NewsId = newsItem.NewsId,
                Title = newsItem.Title,
                Timestamp = newsItem.Timestamp,
                Body = newsItem.Body
            });
        }
    }


    void FixedUpdate()
    {
        if (View != null && _time < View.CheckAfterSeconds)
        {
            _time += Time.deltaTime;
        }
        else if (View != null && _time >= View.CheckAfterSeconds)
        {
            CheckForPromo();
            _time = 0f;
        }

    }

}
