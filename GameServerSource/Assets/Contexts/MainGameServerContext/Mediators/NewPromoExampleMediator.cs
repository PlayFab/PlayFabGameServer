using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab.ServerModels;
using UnityEngine;
using strange.extensions.mediation.impl;
using UnityEngine.Networking;

public class NewPromoExampleMediator : Mediator {

    [Inject] public NewPromoExampleView View { get; set; }
    [Inject] public UnityNetworkingData UnityNetworkingData { get; set; }
    [Inject] public LogSignal Logger { get; set; }

    [Inject] public GetTitleNewsSignal GetTitleNewsSignal { get; set; }
    [Inject] public GetTitleNewsResponseSignal GetTitleNewsResponse { get; set; }

    private List<TitleNewsItem> _titleNews = new List<TitleNewsItem>();
    private float _time;
    private bool firstTimeCheck = true;

    public class TitleNewsItemMessage : MessageBase
    {
        public DateTime Timestamp;
        public string NewsId;
        public string Title;
        public string Body;
    }


    public override void OnRegister()
    {
        Logger.Dispatch(LoggerTypes.Info, "Populating Title News");
        CheckForPromo();
    }

    private void CheckForPromo()
    {
        GetTitleNewsResponse.AddOnce((result) =>
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


        });
        GetTitleNewsSignal.Dispatch(new GetTitleNewsRequest()
        {
            Count = 10
        });
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
