﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.GData.Client;
using Google.GData.Health;
using System.Xml;
using Google.GData.Extensions;
using System.Net;

namespace OnlineBalanceBoardScale
{
    class GoogleHealth
    {
        
        private string user;
        private string password;
        private string pid;
        private string profile;
        private HealthService service;
        private HealthQuery query;

        public GoogleHealth() { }
        public GoogleHealth(string user, string password)
        {
            this.user = user;
            this.password = password;
        }
        private string getPid(String pname)
        {
            HealthFeed feed = service.Query(new HealthQuery(HealthQuery.ProfileListFeed));
            foreach (AtomEntry entry in feed.Entries)
            {
                if (entry.Title.Text == pname)
                {
                    return entry.Content.Content;
                }
            }
            return "";
        }
        private string setPidProfile()
        {
            //HealthFeed feed = service.Query(new HealthQuery(HealthQuery.ProfileListFeed))

            HealthFeed feed = service.Query(new HealthQuery("https://www.google.com/health/feeds/profile/list"));
            foreach (AtomEntry entry in feed.Entries)
            {
                this.profile = entry.Title.Text;
                this.pid = entry.Content.Content;
            }
            return this.pid;
        }
        public bool connect(){
            service = new HealthService("exampleCo-exampleApp-1");

           //GAuthSubRequestFactory authFactory = new GAuthSubRequestFactory("weaver", "exampleCo-exampleApp-1");
            
            //service = new HealthService(authFactory.ApplicationName);
            service.setUserCredentials(user, password);
            query = HealthQuery.ProfileQueryForId(pid);
            setPidProfile();

            query = HealthQuery.ProfileQueryForId(pid);

            return true;
        }
        public static void runTest()
        {
            GoogleHealth goo = new GoogleHealth("rtgonzalez", "Termo1234");
            goo.connect();
            goo.insertNoticeFile(@"insert.xml");

            
           
        }
        public void insertNoticeFile(String file)
        {
            insertNotice(System.IO.File.ReadAllText(file));

        }
        public void insertNotice(String xmlNotice)
        {
            AtomEntry newNotice = new AtomEntry();
            newNotice.Title.Text = "A test message";
            newNotice.Content.Content = "This is a test message.";
            XmlDocument ccrDoc = new XmlDocument();
            ccrDoc.LoadXml(xmlNotice);
            newNotice.ExtensionElements.Add(new XmlExtension(ccrDoc.DocumentElement));
            
            service.Insert(new Uri(HealthQuery.RegisterFeed + pid), newNotice);
        }
    }
}
