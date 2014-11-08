using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CsQuery.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.ModelBinding;
using Nancy.Testing;

namespace Nancy.Serialization.NetJSON.Tests
{
    [TestClass]
    public class ModelBindingFixture
    {
        [TestMethod]
        public void when_binding_to_a_class()
        {
            // Given
            var module = new ConfigurableNancyModule(c => c.Post("/stuff", (_, m) =>
            {
                var stuff = m.Bind<Stuff>();
                return stuff.Id.ToString();
            }));
            var bootstrapper = new TestBootstrapper(config => config.Module(module));

            // When
            var browser = new Browser(bootstrapper);
            var result = browser.Post("/stuff", with =>
            {
                with.HttpRequest();
                with.JsonBody(new Stuff(1), new NetJSONSerializer());
            });

            // Then
            Assert.AreEqual(1, int.Parse(result.Body.AsString()));
        }

        [TestMethod]
        public void when_binding_to_a_collection()
        {
            // Given
            var module = new ConfigurableNancyModule(c => c.Post("/stuff", (_, m) =>
            {
                var stuff = m.Bind<List<Stuff>>();
                return stuff.Count.ToString();
            }));
            var bootstrapper = new TestBootstrapper(config => config.Module(module));

            // When
            var browser = new Browser(bootstrapper);
            var result = browser.Post("/stuff", with =>
            {
                with.HttpRequest();
                with.JsonBody(new List<Stuff> { new Stuff(1), new Stuff(2) }, new NetJSONSerializer());
            });

            // Then
            Assert.AreEqual(2, int.Parse(result.Body.AsString()));
        }

        [TestMethod]
        public void when_binding_to_a_collection_with_blacklisted_property()
        {
            // Given
            var guid = Guid.NewGuid();
            string source = string.Format("{{\"SomeString\":\"some string value\",\"SomeGuid\":\"{0}\"}}", guid);

            var context = new BindingContext
            {
                DestinationType = typeof(Stuff),
                ValidModelProperties = typeof(Stuff).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(propertyInfo => propertyInfo.Name != "SomeString"),
            };

            // Given
            var module = new ConfigurableNancyModule(c => c.Post("/stuff", (_, m) =>
            {
                var stuff = m.Bind<List<Stuff>>("SomeString");
                return stuff.ToJSON();
            }));
            var bootstrapper = new TestBootstrapper(config => config.Module(module));

            // When
            var browser = new Browser(bootstrapper);
            var result = browser.Post("/stuff", with =>
            {
                with.HttpRequest();
                with.JsonBody(new List<Stuff> { new Stuff(1, "one"), new Stuff(2, "two") }, new NetJSONSerializer());
            });

            // Then
            Assert.AreEqual("[{\"Id\":1,\"SomeString\":null},{\"Id\":2,\"SomeString\":null}]", result.Body.AsString());
        }
    }

    public class TestBootstrapper : ConfigurableBootstrapper
    {
        public TestBootstrapper(Action<ConfigurableBootstrapperConfigurator> configuration)
            : base(configuration)
        {
        }

        public TestBootstrapper()
        {
        }

        protected override IEnumerable<Type> BodyDeserializers
        {
            get
            {
                yield return typeof(NetJSONBodyDeserializer);
            }
        }
    }

    public class Stuff
    {
        public Stuff()
        {
        }

        public int Id { get; set; }

        public string SomeString { get; set; }

        public Stuff(int id, string someString = "")
        {
            Id = id;
            SomeString = someString;
        }
    }
}