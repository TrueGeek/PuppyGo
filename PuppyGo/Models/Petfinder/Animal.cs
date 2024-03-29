﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PuppyGo.Models.Petfinder
{

    public class Animal
    {

        public int id { get; set; }
        public string organization_id { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public string species { get; set; }
        public Breeds breeds { get; set; }
        public Colors colors { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public string size { get; set; }
        public string coat { get; set; }
        public Attributes attributes { get; set; }
        public Environment environment { get; set; }
        public List<object> tags { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Photo> photos { get; set; }
        public string status { get; set; }
        public DateTime status_changed_at { get; set; }
        public DateTime published_at { get; set; }
        public double distance { get; set; }
        public Contact contact { get; set; }
        public Links _links { get; set; }

        public string Thumbnail => photos.Where(x => !string.IsNullOrEmpty(x.medium)).FirstOrDefault()?.medium;

    }

    public class Links
    {
        public HrefLink self { get; set; }
        public HrefLink type { get; set; }
        public HrefLink organization { get; set; }
    }

    public class Photo
    {
        public string small { get; set; }
        public string medium { get; set; }
        public string large { get; set; }
        public string full { get; set; }
    }

    public class Breeds
    {
        public string primary { get; set; }
        public string secondary { get; set; }
        public bool mixed { get; set; }
        public bool unknown { get; set; }
    }

    public class Colors
    {
        public string primary { get; set; }
        public string secondary { get; set; }
        public object tertiary { get; set; }
    }

    public class Attributes
    {
        public bool spayed_neutered { get; set; }
        public bool house_trained { get; set; }
        public object declawed { get; set; }
        public bool special_needs { get; set; }
        public bool shots_current { get; set; }
    }

    public class Environment
    {
        public bool? children { get; set; }
        public bool? dogs { get; set; }
        public bool? cats { get; set; }
    }

    public class Contact
    {
        public string email { get; set; }
        public string phone { get; set; }
        public Address address { get; set; }
    }

    public class Address
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
    }

}
