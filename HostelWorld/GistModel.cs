using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NUnit.Framework;

namespace HostelWorld
{
    

    public class Payload
    {
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "public")]
        public bool Public { get; set; }

        [DataMember(Name = "files")]
        public Files Files { get; set; }
    }

    public class Files
    {
        [DataMember(Name = "hello_world.rb")]
        public HelloWorldRb HelloWorldRb { get; set; }
    }

    public class HelloWorldRb
    {
        [DataMember(Name = "content")]
        public string Content { get; set; }
    }


    [DataContract]
    public class Owner
    {
        [DataMember(Name = "login")]
        public string Login { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "gists_url")]
        public string GistsUrl { get; set; }

        [DataMember(Name = "starred_url")]
        public string StarredUrl { get; set; }

        [DataMember(Name = "subscriptions_url")]
        public string SubscriptionsUrl { get; set; }


    }

    [DataContract]
    public class Gist
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "git_pull_url")]
        public string GitPullUrl { get; set; }

        [DataMember(Name = "git_push_url")]
        public string GitPushUrl { get; set; }

        [DataMember(Name = "files")]
        public Files Files { get; set; }

        [DataMember(Name = "public")]
        public bool Public { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "comments")]
        public int Comments { get; set; }

        [DataMember(Name = "user")]
        public object User { get; set; }

        [DataMember(Name = "comments_url")]
        public string CommentsUrl { get; set; }

        [DataMember(Name = "owner")]
        public Owner Owner { get; set; }

    }
}
